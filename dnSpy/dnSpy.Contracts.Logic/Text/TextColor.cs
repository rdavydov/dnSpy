﻿/*
    Copyright (C) 2014-2016 de4dot@gmail.com

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

using System.Diagnostics;

namespace dnSpy.Contracts.Text {
	/// <summary>
	/// Text color
	/// </summary>
	public enum TextColor {
		// IMPORTANT: The order must match dnSpy.Contracts.Themes.ColorType

#pragma warning disable 1591 // Missing XML comment for publicly visible type or member
		Text,
		Operator,
		Punctuation,
		Number,
		Comment,
		Keyword,
		String,
		VerbatimString,
		Char,
		Namespace,
		Type,
		SealedType,
		StaticType,
		Delegate,
		Enum,
		Interface,
		ValueType,
		TypeGenericParameter,
		MethodGenericParameter,
		InstanceMethod,
		StaticMethod,
		ExtensionMethod,
		InstanceField,
		EnumField,
		LiteralField,
		StaticField,
		InstanceEvent,
		StaticEvent,
		InstanceProperty,
		StaticProperty,
		Local,
		Parameter,
		PreprocessorKeyword,
		PreprocessorText,
		Label,
		OpCode,
		ILDirective,
		ILModule,
		ExcludedCode,
		XmlDocCommentAttributeName,
		XmlDocCommentAttributeQuotes,
		XmlDocCommentAttributeValue,
		XmlDocCommentCDataSection,
		XmlDocCommentComment,
		XmlDocCommentDelimiter,
		XmlDocCommentEntityReference,
		XmlDocCommentName,
		XmlDocCommentProcessingInstruction,
		XmlDocCommentText,
		XmlLiteralAttributeName,
		XmlLiteralAttributeQuotes,
		XmlLiteralAttributeValue,
		XmlLiteralCDataSection,
		XmlLiteralComment,
		XmlLiteralDelimiter,
		XmlLiteralEmbeddedExpression,
		XmlLiteralEntityReference,
		XmlLiteralName,
		XmlLiteralProcessingInstruction,
		XmlLiteralText,
		XmlAttributeName,
		XmlAttributeQuotes,
		XmlAttributeValue,
		XmlCDataSection,
		XmlComment,
		XmlDelimiter,
		XmlKeyword,
		XmlName,
		XmlProcessingInstruction,
		XmlText,
		XmlDocToolTipColon,
		XmlDocToolTipExample,
		XmlDocToolTipExceptionCref,
		XmlDocToolTipReturns,
		XmlDocToolTipSeeCref,
		XmlDocToolTipSeeLangword,
		XmlDocToolTipSeeAlso,
		XmlDocToolTipSeeAlsoCref,
		XmlDocToolTipParamRefName,
		XmlDocToolTipParamName,
		XmlDocToolTipTypeParamName,
		XmlDocToolTipValue,
		XmlDocToolTipSummary,
		XmlDocToolTipText,
		Assembly,
		AssemblyExe,
		Module,
		DirectoryPart,
		FileNameNoExtension,
		FileExtension,
		Error,
		ToStringEval,
		ReplPrompt1,
		ReplPrompt2,
		ReplOutputText,
		ReplScriptOutputText,
		Black,
		Blue,
		Cyan,
		DarkBlue,
		DarkCyan,
		DarkGray,
		DarkGreen,
		DarkMagenta,
		DarkRed,
		DarkYellow,
		Gray,
		Green,
		Magenta,
		Red,
		White,
		Yellow,
		InvBlack,
		InvBlue,
		InvCyan,
		InvDarkBlue,
		InvDarkCyan,
		InvDarkGray,
		InvDarkGreen,
		InvDarkMagenta,
		InvDarkRed,
		InvDarkYellow,
		InvGray,
		InvGreen,
		InvMagenta,
		InvRed,
		InvWhite,
		InvYellow,
		DebugLogExceptionHandled,
		DebugLogExceptionUnhandled,
		DebugLogStepFiltering,
		DebugLogLoadModule,
		DebugLogUnloadModule,
		DebugLogExitProcess,
		DebugLogExitThread,
		DebugLogProgramOutput,
		DebugLogMDA,
		DebugLogTimestamp,
		LineNumber,
		ReplLineNumberInput1,
		ReplLineNumberInput2,
		ReplLineNumberOutput,
		Link,
		VisibleWhitespace,
		SelectedText,
		InactiveSelectedText,
		HighlightedReference,
		HighlightedWrittenReference,
		HighlightedDefinition,
		CurrentStatement,
		CurrentStatementMarker,
		CallReturn,
		CallReturnMarker,
		ActiveStatementMarker,
		BreakpointStatement,
		BreakpointStatementMarker,
		DisabledBreakpointStatementMarker,
		CurrentLine,
		CurrentLineNoFocus,
		HexText,
		HexOffset,
		HexByte0,
		HexByte1,
		HexByteError,
		HexAscii,
		HexCaret,
		HexInactiveCaret,
		HexSelection,
		GlyphMargin,
		BraceMatching,
		LineSeparator,
		FindMatchHighlightMarker,
		StructureVisualizerNamespace,
		StructureVisualizerType,
		StructureVisualizerValueType,
		StructureVisualizerInterface,
		StructureVisualizerMethod,
		StructureVisualizerAccessor,
		StructureVisualizerAnonymousMethod,
		StructureVisualizerConstructor,
		StructureVisualizerDestructor,
		StructureVisualizerOperator,
		StructureVisualizerConditional,
		StructureVisualizerLoop,
		StructureVisualizerProperty,
		StructureVisualizerEvent,
		StructureVisualizerTry,
		StructureVisualizerCatch,
		StructureVisualizerFilter,
		StructureVisualizerFinally,
		StructureVisualizerFault,
		StructureVisualizerLock,
		StructureVisualizerUsing,
		StructureVisualizerFixed,
		StructureVisualizerCase,
		StructureVisualizerOther,

		/// <summary>
		/// Must be last
		/// </summary>
		Last,
#pragma warning restore 1591 // Missing XML comment for publicly visible type or member
	}

	/// <summary>
	/// Boxed colors
	/// </summary>
	public static class BoxedTextColor {
#pragma warning disable 1591 // Missing XML comment for publicly visible type or member
		public static readonly object Text = TextColor.Text;
		public static readonly object Operator = TextColor.Operator;
		public static readonly object Punctuation = TextColor.Punctuation;
		public static readonly object Number = TextColor.Number;
		public static readonly object Comment = TextColor.Comment;
		public static readonly object Keyword = TextColor.Keyword;
		public static readonly object String = TextColor.String;
		public static readonly object VerbatimString = TextColor.VerbatimString;
		public static readonly object Char = TextColor.Char;
		public static readonly object Namespace = TextColor.Namespace;
		public static readonly object Type = TextColor.Type;
		public static readonly object SealedType = TextColor.SealedType;
		public static readonly object StaticType = TextColor.StaticType;
		public static readonly object Delegate = TextColor.Delegate;
		public static readonly object Enum = TextColor.Enum;
		public static readonly object Interface = TextColor.Interface;
		public static readonly object ValueType = TextColor.ValueType;
		public static readonly object TypeGenericParameter = TextColor.TypeGenericParameter;
		public static readonly object MethodGenericParameter = TextColor.MethodGenericParameter;
		public static readonly object InstanceMethod = TextColor.InstanceMethod;
		public static readonly object StaticMethod = TextColor.StaticMethod;
		public static readonly object ExtensionMethod = TextColor.ExtensionMethod;
		public static readonly object InstanceField = TextColor.InstanceField;
		public static readonly object EnumField = TextColor.EnumField;
		public static readonly object LiteralField = TextColor.LiteralField;
		public static readonly object StaticField = TextColor.StaticField;
		public static readonly object InstanceEvent = TextColor.InstanceEvent;
		public static readonly object StaticEvent = TextColor.StaticEvent;
		public static readonly object InstanceProperty = TextColor.InstanceProperty;
		public static readonly object StaticProperty = TextColor.StaticProperty;
		public static readonly object Local = TextColor.Local;
		public static readonly object Parameter = TextColor.Parameter;
		public static readonly object PreprocessorKeyword = TextColor.PreprocessorKeyword;
		public static readonly object PreprocessorText = TextColor.PreprocessorText;
		public static readonly object Label = TextColor.Label;
		public static readonly object OpCode = TextColor.OpCode;
		public static readonly object ILDirective = TextColor.ILDirective;
		public static readonly object ILModule = TextColor.ILModule;
		public static readonly object ExcludedCode = TextColor.ExcludedCode;
		public static readonly object XmlDocCommentAttributeName = TextColor.XmlDocCommentAttributeName;
		public static readonly object XmlDocCommentAttributeQuotes = TextColor.XmlDocCommentAttributeQuotes;
		public static readonly object XmlDocCommentAttributeValue = TextColor.XmlDocCommentAttributeValue;
		public static readonly object XmlDocCommentCDataSection = TextColor.XmlDocCommentCDataSection;
		public static readonly object XmlDocCommentComment = TextColor.XmlDocCommentComment;
		public static readonly object XmlDocCommentDelimiter = TextColor.XmlDocCommentDelimiter;
		public static readonly object XmlDocCommentEntityReference = TextColor.XmlDocCommentEntityReference;
		public static readonly object XmlDocCommentName = TextColor.XmlDocCommentName;
		public static readonly object XmlDocCommentProcessingInstruction = TextColor.XmlDocCommentProcessingInstruction;
		public static readonly object XmlDocCommentText = TextColor.XmlDocCommentText;
		public static readonly object XmlLiteralAttributeName = TextColor.XmlLiteralAttributeName;
		public static readonly object XmlLiteralAttributeQuotes = TextColor.XmlLiteralAttributeQuotes;
		public static readonly object XmlLiteralAttributeValue = TextColor.XmlLiteralAttributeValue;
		public static readonly object XmlLiteralCDataSection = TextColor.XmlLiteralCDataSection;
		public static readonly object XmlLiteralComment = TextColor.XmlLiteralComment;
		public static readonly object XmlLiteralDelimiter = TextColor.XmlLiteralDelimiter;
		public static readonly object XmlLiteralEmbeddedExpression = TextColor.XmlLiteralEmbeddedExpression;
		public static readonly object XmlLiteralEntityReference = TextColor.XmlLiteralEntityReference;
		public static readonly object XmlLiteralName = TextColor.XmlLiteralName;
		public static readonly object XmlLiteralProcessingInstruction = TextColor.XmlLiteralProcessingInstruction;
		public static readonly object XmlLiteralText = TextColor.XmlLiteralText;
		public static readonly object XmlAttributeName = TextColor.XmlAttributeName;
		public static readonly object XmlAttributeQuotes = TextColor.XmlAttributeQuotes;
		public static readonly object XmlAttributeValue = TextColor.XmlAttributeValue;
		public static readonly object XmlCDataSection = TextColor.XmlCDataSection;
		public static readonly object XmlComment = TextColor.XmlComment;
		public static readonly object XmlDelimiter = TextColor.XmlDelimiter;
		public static readonly object XmlKeyword = TextColor.XmlKeyword;
		public static readonly object XmlName = TextColor.XmlName;
		public static readonly object XmlProcessingInstruction = TextColor.XmlProcessingInstruction;
		public static readonly object XmlText = TextColor.XmlText;
		public static readonly object XmlDocToolTipColon = TextColor.XmlDocToolTipColon;
		public static readonly object XmlDocToolTipExample = TextColor.XmlDocToolTipExample;
		public static readonly object XmlDocToolTipExceptionCref = TextColor.XmlDocToolTipExceptionCref;
		public static readonly object XmlDocToolTipReturns = TextColor.XmlDocToolTipReturns;
		public static readonly object XmlDocToolTipSeeCref = TextColor.XmlDocToolTipSeeCref;
		public static readonly object XmlDocToolTipSeeLangword = TextColor.XmlDocToolTipSeeLangword;
		public static readonly object XmlDocToolTipSeeAlso = TextColor.XmlDocToolTipSeeAlso;
		public static readonly object XmlDocToolTipSeeAlsoCref = TextColor.XmlDocToolTipSeeAlsoCref;
		public static readonly object XmlDocToolTipParamRefName = TextColor.XmlDocToolTipParamRefName;
		public static readonly object XmlDocToolTipParamName = TextColor.XmlDocToolTipParamName;
		public static readonly object XmlDocToolTipTypeParamName = TextColor.XmlDocToolTipTypeParamName;
		public static readonly object XmlDocToolTipValue = TextColor.XmlDocToolTipValue;
		public static readonly object XmlDocToolTipSummary = TextColor.XmlDocToolTipSummary;
		public static readonly object XmlDocToolTipText = TextColor.XmlDocToolTipText;
		public static readonly object Assembly = TextColor.Assembly;
		public static readonly object AssemblyExe = TextColor.AssemblyExe;
		public static readonly object Module = TextColor.Module;
		public static readonly object DirectoryPart = TextColor.DirectoryPart;
		public static readonly object FileNameNoExtension = TextColor.FileNameNoExtension;
		public static readonly object FileExtension = TextColor.FileExtension;
		public static readonly object Error = TextColor.Error;
		public static readonly object ToStringEval = TextColor.ToStringEval;
		public static readonly object ReplPrompt1 = TextColor.ReplPrompt1;
		public static readonly object ReplPrompt2 = TextColor.ReplPrompt2;
		public static readonly object ReplOutputText = TextColor.ReplOutputText;
		public static readonly object ReplScriptOutputText = TextColor.ReplScriptOutputText;
		public static readonly object Black = TextColor.Black;
		public static readonly object Blue = TextColor.Blue;
		public static readonly object Cyan = TextColor.Cyan;
		public static readonly object DarkBlue = TextColor.DarkBlue;
		public static readonly object DarkCyan = TextColor.DarkCyan;
		public static readonly object DarkGray = TextColor.DarkGray;
		public static readonly object DarkGreen = TextColor.DarkGreen;
		public static readonly object DarkMagenta = TextColor.DarkMagenta;
		public static readonly object DarkRed = TextColor.DarkRed;
		public static readonly object DarkYellow = TextColor.DarkYellow;
		public static readonly object Gray = TextColor.Gray;
		public static readonly object Green = TextColor.Green;
		public static readonly object Magenta = TextColor.Magenta;
		public static readonly object Red = TextColor.Red;
		public static readonly object White = TextColor.White;
		public static readonly object Yellow = TextColor.Yellow;
		public static readonly object InvBlack = TextColor.InvBlack;
		public static readonly object InvBlue = TextColor.InvBlue;
		public static readonly object InvCyan = TextColor.InvCyan;
		public static readonly object InvDarkBlue = TextColor.InvDarkBlue;
		public static readonly object InvDarkCyan = TextColor.InvDarkCyan;
		public static readonly object InvDarkGray = TextColor.InvDarkGray;
		public static readonly object InvDarkGreen = TextColor.InvDarkGreen;
		public static readonly object InvDarkMagenta = TextColor.InvDarkMagenta;
		public static readonly object InvDarkRed = TextColor.InvDarkRed;
		public static readonly object InvDarkYellow = TextColor.InvDarkYellow;
		public static readonly object InvGray = TextColor.InvGray;
		public static readonly object InvGreen = TextColor.InvGreen;
		public static readonly object InvMagenta = TextColor.InvMagenta;
		public static readonly object InvRed = TextColor.InvRed;
		public static readonly object InvWhite = TextColor.InvWhite;
		public static readonly object InvYellow = TextColor.InvYellow;
		public static readonly object DebugLogExceptionHandled = TextColor.DebugLogExceptionHandled;
		public static readonly object DebugLogExceptionUnhandled = TextColor.DebugLogExceptionUnhandled;
		public static readonly object DebugLogStepFiltering = TextColor.DebugLogStepFiltering;
		public static readonly object DebugLogLoadModule = TextColor.DebugLogLoadModule;
		public static readonly object DebugLogUnloadModule = TextColor.DebugLogUnloadModule;
		public static readonly object DebugLogExitProcess = TextColor.DebugLogExitProcess;
		public static readonly object DebugLogExitThread = TextColor.DebugLogExitThread;
		public static readonly object DebugLogProgramOutput = TextColor.DebugLogProgramOutput;
		public static readonly object DebugLogMDA = TextColor.DebugLogMDA;
		public static readonly object DebugLogTimestamp = TextColor.DebugLogTimestamp;
		public static readonly object LineNumber = TextColor.LineNumber;
		public static readonly object ReplLineNumberInput1 = TextColor.ReplLineNumberInput1;
		public static readonly object ReplLineNumberInput2 = TextColor.ReplLineNumberInput2;
		public static readonly object ReplLineNumberOutput = TextColor.ReplLineNumberOutput;
		public static readonly object Link = TextColor.Link;
		public static readonly object VisibleWhitespace = TextColor.VisibleWhitespace;
		public static readonly object SelectedText = TextColor.SelectedText;
		public static readonly object InactiveSelectedText = TextColor.InactiveSelectedText;
		public static readonly object HighlightedReference = TextColor.HighlightedReference;
		public static readonly object HighlightedWrittenReference = TextColor.HighlightedWrittenReference;
		public static readonly object HighlightedDefinition = TextColor.HighlightedDefinition;
		public static readonly object CurrentStatement = TextColor.CurrentStatement;
		public static readonly object CurrentStatementMarker = TextColor.CurrentStatementMarker;
		public static readonly object CallReturn = TextColor.CallReturn;
		public static readonly object CallReturnMarker = TextColor.CallReturnMarker;
		public static readonly object ActiveStatementMarker = TextColor.ActiveStatementMarker;
		public static readonly object BreakpointStatement = TextColor.BreakpointStatement;
		public static readonly object BreakpointStatementMarker = TextColor.BreakpointStatementMarker;
		public static readonly object DisabledBreakpointStatementMarker = TextColor.DisabledBreakpointStatementMarker;
		public static readonly object CurrentLine = TextColor.CurrentLine;
		public static readonly object CurrentLineNoFocus = TextColor.CurrentLineNoFocus;
		public static readonly object HexText = TextColor.HexText;
		public static readonly object HexOffset = TextColor.HexOffset;
		public static readonly object HexByte0 = TextColor.HexByte0;
		public static readonly object HexByte1 = TextColor.HexByte1;
		public static readonly object HexByteError = TextColor.HexByteError;
		public static readonly object HexAscii = TextColor.HexAscii;
		public static readonly object HexCaret = TextColor.HexCaret;
		public static readonly object HexInactiveCaret = TextColor.HexInactiveCaret;
		public static readonly object HexSelection = TextColor.HexSelection;
		public static readonly object GlyphMargin = TextColor.GlyphMargin;
		public static readonly object BraceMatching = TextColor.BraceMatching;
		public static readonly object LineSeparator = TextColor.LineSeparator;
		public static readonly object FindMatchHighlightMarker = TextColor.FindMatchHighlightMarker;
		public static readonly object StructureVisualizerNamespace = TextColor.StructureVisualizerNamespace;
		public static readonly object StructureVisualizerType = TextColor.StructureVisualizerType;
		public static readonly object StructureVisualizerValueType = TextColor.StructureVisualizerValueType;
		public static readonly object StructureVisualizerInterface = TextColor.StructureVisualizerInterface;
		public static readonly object StructureVisualizerMethod = TextColor.StructureVisualizerMethod;
		public static readonly object StructureVisualizerAccessor = TextColor.StructureVisualizerAccessor;
		public static readonly object StructureVisualizerAnonymousMethod = TextColor.StructureVisualizerAnonymousMethod;
		public static readonly object StructureVisualizerConstructor = TextColor.StructureVisualizerConstructor;
		public static readonly object StructureVisualizerDestructor = TextColor.StructureVisualizerDestructor;
		public static readonly object StructureVisualizerOperator = TextColor.StructureVisualizerOperator;
		public static readonly object StructureVisualizerConditional = TextColor.StructureVisualizerConditional;
		public static readonly object StructureVisualizerLoop = TextColor.StructureVisualizerLoop;
		public static readonly object StructureVisualizerProperty = TextColor.StructureVisualizerProperty;
		public static readonly object StructureVisualizerEvent = TextColor.StructureVisualizerEvent;
		public static readonly object StructureVisualizerTry = TextColor.StructureVisualizerTry;
		public static readonly object StructureVisualizerCatch = TextColor.StructureVisualizerCatch;
		public static readonly object StructureVisualizerFilter = TextColor.StructureVisualizerFilter;
		public static readonly object StructureVisualizerFinally = TextColor.StructureVisualizerFinally;
		public static readonly object StructureVisualizerFault = TextColor.StructureVisualizerFault;
		public static readonly object StructureVisualizerLock = TextColor.StructureVisualizerLock;
		public static readonly object StructureVisualizerUsing = TextColor.StructureVisualizerUsing;
		public static readonly object StructureVisualizerFixed = TextColor.StructureVisualizerFixed;
		public static readonly object StructureVisualizerCase = TextColor.StructureVisualizerCase;
		public static readonly object StructureVisualizerOther = TextColor.StructureVisualizerOther;

		/// <summary>
		/// Boxes <paramref name="color"/>
		/// </summary>
		/// <param name="color">Color to box</param>
		/// <returns></returns>
		public static object Box(this TextColor color) {
			Debug.Assert(0 <= color && color < TextColor.Last);
			int index = (int)color;
			if ((uint)index < (uint)boxedColors.Length)
				return boxedColors[index];
			return Text;
		}

		static readonly object[] boxedColors = new object[(int)TextColor.Last] {
			Text,
			Operator,
			Punctuation,
			Number,
			Comment,
			Keyword,
			String,
			VerbatimString,
			Char,
			Namespace,
			Type,
			SealedType,
			StaticType,
			Delegate,
			Enum,
			Interface,
			ValueType,
			TypeGenericParameter,
			MethodGenericParameter,
			InstanceMethod,
			StaticMethod,
			ExtensionMethod,
			InstanceField,
			EnumField,
			LiteralField,
			StaticField,
			InstanceEvent,
			StaticEvent,
			InstanceProperty,
			StaticProperty,
			Local,
			Parameter,
			PreprocessorKeyword,
			PreprocessorText,
			Label,
			OpCode,
			ILDirective,
			ILModule,
			ExcludedCode,
			XmlDocCommentAttributeName,
			XmlDocCommentAttributeQuotes,
			XmlDocCommentAttributeValue,
			XmlDocCommentCDataSection,
			XmlDocCommentComment,
			XmlDocCommentDelimiter,
			XmlDocCommentEntityReference,
			XmlDocCommentName,
			XmlDocCommentProcessingInstruction,
			XmlDocCommentText,
			XmlLiteralAttributeName,
			XmlLiteralAttributeQuotes,
			XmlLiteralAttributeValue,
			XmlLiteralCDataSection,
			XmlLiteralComment,
			XmlLiteralDelimiter,
			XmlLiteralEmbeddedExpression,
			XmlLiteralEntityReference,
			XmlLiteralName,
			XmlLiteralProcessingInstruction,
			XmlLiteralText,
			XmlAttributeName,
			XmlAttributeQuotes,
			XmlAttributeValue,
			XmlCDataSection,
			XmlComment,
			XmlDelimiter,
			XmlKeyword,
			XmlName,
			XmlProcessingInstruction,
			XmlText,
			XmlDocToolTipColon,
			XmlDocToolTipExample,
			XmlDocToolTipExceptionCref,
			XmlDocToolTipReturns,
			XmlDocToolTipSeeCref,
			XmlDocToolTipSeeLangword,
			XmlDocToolTipSeeAlso,
			XmlDocToolTipSeeAlsoCref,
			XmlDocToolTipParamRefName,
			XmlDocToolTipParamName,
			XmlDocToolTipTypeParamName,
			XmlDocToolTipValue,
			XmlDocToolTipSummary,
			XmlDocToolTipText,
			Assembly,
			AssemblyExe,
			Module,
			DirectoryPart,
			FileNameNoExtension,
			FileExtension,
			Error,
			ToStringEval,
			ReplPrompt1,
			ReplPrompt2,
			ReplOutputText,
			ReplScriptOutputText,
			Black,
			Blue,
			Cyan,
			DarkBlue,
			DarkCyan,
			DarkGray,
			DarkGreen,
			DarkMagenta,
			DarkRed,
			DarkYellow,
			Gray,
			Green,
			Magenta,
			Red,
			White,
			Yellow,
			InvBlack,
			InvBlue,
			InvCyan,
			InvDarkBlue,
			InvDarkCyan,
			InvDarkGray,
			InvDarkGreen,
			InvDarkMagenta,
			InvDarkRed,
			InvDarkYellow,
			InvGray,
			InvGreen,
			InvMagenta,
			InvRed,
			InvWhite,
			InvYellow,
			DebugLogExceptionHandled,
			DebugLogExceptionUnhandled,
			DebugLogStepFiltering,
			DebugLogLoadModule,
			DebugLogUnloadModule,
			DebugLogExitProcess,
			DebugLogExitThread,
			DebugLogProgramOutput,
			DebugLogMDA,
			DebugLogTimestamp,
			LineNumber,
			ReplLineNumberInput1,
			ReplLineNumberInput2,
			ReplLineNumberOutput,
			Link,
			VisibleWhitespace,
			SelectedText,
			InactiveSelectedText,
			HighlightedReference,
			HighlightedWrittenReference,
			HighlightedDefinition,
			CurrentStatement,
			CurrentStatementMarker,
			CallReturn,
			CallReturnMarker,
			ActiveStatementMarker,
			BreakpointStatement,
			BreakpointStatementMarker,
			DisabledBreakpointStatementMarker,
			CurrentLine,
			CurrentLineNoFocus,
			HexText,
			HexOffset,
			HexByte0,
			HexByte1,
			HexByteError,
			HexAscii,
			HexCaret,
			HexInactiveCaret,
			HexSelection,
			GlyphMargin,
			BraceMatching,
			LineSeparator,
			FindMatchHighlightMarker,
			StructureVisualizerNamespace,
			StructureVisualizerType,
			StructureVisualizerValueType,
			StructureVisualizerInterface,
			StructureVisualizerMethod,
			StructureVisualizerAccessor,
			StructureVisualizerAnonymousMethod,
			StructureVisualizerConstructor,
			StructureVisualizerDestructor,
			StructureVisualizerOperator,
			StructureVisualizerConditional,
			StructureVisualizerLoop,
			StructureVisualizerProperty,
			StructureVisualizerEvent,
			StructureVisualizerTry,
			StructureVisualizerCatch,
			StructureVisualizerFilter,
			StructureVisualizerFinally,
			StructureVisualizerFault,
			StructureVisualizerLock,
			StructureVisualizerUsing,
			StructureVisualizerFixed,
			StructureVisualizerCase,
			StructureVisualizerOther,
		};
#pragma warning restore 1591 // Missing XML comment for publicly visible type or member
	}
}
