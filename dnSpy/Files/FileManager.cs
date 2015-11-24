﻿/*
    Copyright (C) 2014-2015 de4dot@gmail.com

    This file is part of dnSpy

    dnSpy is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    dnSpy is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with dnSpy.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using dnlib.DotNet;
using dnlib.PE;
using dnSpy.Contracts.Files;
using dnSpy.Shared.UI.Files;

namespace dnSpy.Files {
	[Export, Export(typeof(IFileManager)), PartCreationPolicy(CreationPolicy.Shared)]
	sealed class FileManager : IFileManager {
		readonly object lockObj;
		readonly List<IDnSpyFile> files;
		readonly IAssemblyResolver asmResolver;
		readonly IDnSpyFileCreator[] dnSpyFileCreators;

		bool UseMemoryMappedIO { get; set; }
		bool UseDebugSymbols { get; set; }
		public bool UseGAC { get; set; }

		sealed class DisableAssemblyLoadHelper : IDisposable {
			readonly FileManager fileManager;

			public DisableAssemblyLoadHelper(FileManager fileManager) {
				this.fileManager = fileManager;
				Interlocked.Increment(ref fileManager.counter_DisableAssemblyLoad);
			}

			public void Dispose() {
				Interlocked.Decrement(ref fileManager.counter_DisableAssemblyLoad);
			}
		}

		internal bool AssemblyLoadEnabled {
			get { return counter_DisableAssemblyLoad == 0; }
		}
		int counter_DisableAssemblyLoad;

		public IDisposable DisableAssemblyLoad() {
			return new DisableAssemblyLoadHelper(this);
		}

		public event EventHandler<NotifyFileCollectionChangedEventArgs> CollectionChanged;

		[ImportingConstructor]
		FileManager([ImportMany] IDnSpyFileCreator[] dnSpyFileCreators) {
			this.lockObj = new object();
			this.files = new List<IDnSpyFile>();
			this.asmResolver = new AssemblyResolver(this);
			this.dnSpyFileCreators = dnSpyFileCreators.OrderBy(a => a.Order).ToArray();
			//TODO: Initialize these from the settings
			this.UseMemoryMappedIO = true;
			this.UseDebugSymbols = true;
			this.UseGAC = true;
		}

		void CallCollectionChanged(NotifyFileCollectionChangedEventArgs eventArgs) {
			if (dispatcher != null)
				dispatcher(() => CallCollectionChanged2(eventArgs));
			else
				CallCollectionChanged2(eventArgs);
		}

		void CallCollectionChanged2(NotifyFileCollectionChangedEventArgs eventArgs) {
			var c = CollectionChanged;
			if (c != null)
				c(this, eventArgs);
		}

		public IDnSpyFile[] GetFiles() {
			lock (lockObj)
				return files.ToArray();
		}

		public void Clear() {
			IDnSpyFile[] oldFiles;
			lock (lockObj) {
				oldFiles = files.ToArray();
				files.Clear();
			}
			if (oldFiles.Length != 0)
				CallCollectionChanged(NotifyFileCollectionChangedEventArgs.CreateClear(oldFiles));
		}

		public IDnSpyFile FindAssembly(IAssembly assembly) {
			lock (lockObj) {
				var comparer = new AssemblyNameComparer(AssemblyNameComparerFlags.All);
				foreach (var file in files) {
					if (comparer.Equals(file.AssemblyDef, assembly))
						return file;
				}
				return null;
			}
		}

		public IDnSpyFile Resolve(IAssembly asm, ModuleDef sourceModule) {
			var file = FindAssembly(asm);
			if (file != null)
				return file;
			var asmDef = this.asmResolver.Resolve(asm, sourceModule);
			if (asmDef != null)
				return FindAssembly(asm);
			return null;
		}

		IDnSpyFile Find(IDnSpyFilenameKey key) {
			lock (lockObj)
				return Find_NoLock(key);
		}

		IDnSpyFile Find_NoLock(IDnSpyFilenameKey key) {
			Debug.Assert(key != null);
			if (key == null)
				return null;
			foreach (var file in files) {
				if (key.Equals(file.Key))
					return file;
			}
			return null;
		}

		public IDnSpyFile GetOrAdd(IDnSpyFile file) {
			if (file == null)
				throw new ArgumentNullException();

			IDnSpyFile result;
			lock (lockObj)
				result = GetOrAdd_NoLock(file);
			if (result == file)
				CallCollectionChanged(NotifyFileCollectionChangedEventArgs.CreateAdd(result));
			return result;
		}

		internal IDnSpyFile GetOrAddCanDispose(IDnSpyFile file) {
			file.IsAutoLoaded = true;
			var result = Find(file.Key);
			if (result == null) {
				if (!AssemblyLoadEnabled)
					return DisableMMapdIO(file);
				result = GetOrAdd(file);
			}
			if (result != file)
				Dispose(file);
			return result;
		}

		// Should be called if we don't save it in the files list. It will eventually be GC'd but it's
		// better to disable mmap'd I/O as soon as possible. The file must've been created by us.
		static IDnSpyFile DisableMMapdIO(IDnSpyFile file) {
			var peImage = file.PEImage;
			if (peImage != null)
				peImage.UnsafeDisableMemoryMappedIO();
			return file;
		}

		IDnSpyFile GetOrAdd_NoLock(IDnSpyFile file) {
			var existing = Find_NoLock(file.Key);
			if (existing != null)
				return existing;

			files.Add(file);
			return file;
		}

		public IDnSpyFile GetOrCreate(string filename) {
			return GetOrCreate(filename, false);
		}

		internal IDnSpyFile GetOrCreate(string filename, bool isAutoLoaded) {
			var key = new FilenameKey(filename);
			var existing = Find(key);
			if (existing != null)
				return existing;

			var newFile = CreateDnSpyFile(filename);
			newFile.IsAutoLoaded = isAutoLoaded;
			if (!AssemblyLoadEnabled)
				return DisableMMapdIO(newFile);

			var result = GetOrAdd(newFile);
			if (result != newFile)
				Dispose(newFile);

			return result;
		}

		static void Dispose(IDnSpyFile file) {
			var id = file as IDisposable;
			if (id != null)
				id.Dispose();
		}

		internal IDnSpyFile CreateDnSpyFile(string filename) {
			if (dnSpyFileCreators.Length > 0) {
				var context = new DnSpyFileCreatorContext(this, filename);
				foreach (var creator in dnSpyFileCreators) {
					try {
						var file = creator.Create(context);
						if (file != null)
							return file;
					}
					catch (Exception ex) {
						Debug.WriteLine(string.Format("IDnSpyFileCreator ({0}) failed with an exception: {1}", creator.GetType(), ex.Message));
					}
				}
			}

			try {
				// Quick check to prevent exceptions from being thrown
				if (!File.Exists(filename))
					return new DnSpyUnknownFile(filename);

				IPEImage peImage;

				if (UseMemoryMappedIO)
					peImage = new PEImage(filename);
				else
					peImage = new PEImage(File.ReadAllBytes(filename), filename);

				var dotNetDir = peImage.ImageNTHeaders.OptionalHeader.DataDirectories[14];
				bool isDotNet = dotNetDir.VirtualAddress != 0 && dotNetDir.Size >= 0x48;
				if (isDotNet) {
					try {
						var options = new ModuleCreationOptions(DnSpyDotNetFileBase.CreateModuleContext(asmResolver));
						return DnSpyDotNetFile.CreateAssembly(ModuleDefMD.Load(peImage, options), UseDebugSymbols);
					}
					catch {
					}
				}

				return new DnSpyPEFile(peImage);
			}
			catch {
			}
			return new DnSpyUnknownFile(filename);
		}

		public void Remove(IDnSpyFilenameKey key) {
			Debug.Assert(key != null);
			if (key == null)
				return;

			IDnSpyFile removedFile;
			lock (lockObj)
				removedFile = Remove_NoLock(key);
			Debug.Assert(removedFile != null);

			if (removedFile != null)
				CallCollectionChanged(NotifyFileCollectionChangedEventArgs.CreateRemove(removedFile));
		}

		IDnSpyFile Remove_NoLock(IDnSpyFilenameKey key) {
			if (key == null)
				return null;

			for (int i = 0; i < files.Count; i++) {
				if (key.Equals(files[i].Key)) {
					files.RemoveAt(i);
					return files[i];
				}
			}

			return null;
		}

		public void SetDispatcher(Action<Action> action) {
			if (action == null)
				throw new ArgumentNullException();
			if (dispatcher != null)
				throw new InvalidOperationException("SetDispatcher() can only be called once");
			dispatcher = action;
		}
		Action<Action> dispatcher;
	}
}
