﻿// Copyright (c) 2014 AlphaSierraPapa for the SharpDevelop Team
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this
// software and associated documentation files (the "Software"), to deal in the Software
// without restriction, including without limitation the rights to use, copy, modify, merge,
// publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons
// to whom the Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or
// substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
// PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
// FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
// OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.


namespace dnSpy.Text.AvalonEdit {
	static class NewLineFinder {
		static readonly char[] newline = { '\r', '\n', '\u0085', '\u2028', '\u2029' };

		internal static readonly string[] NewlineStrings = { "\r\n", "\r", "\n", "\u0085", "\u2028", "\u2029" };

		/// <summary>
		/// Gets the location of the next new line character, or SimpleSegment.Invalid
		/// if none is found.
		/// </summary>
		internal static SimpleSegment NextNewLine(ITextSource text, int offset) {
			int textLength = text.TextLength;
			int pos = text.IndexOfAny(newline, offset, textLength - offset);
			if (pos >= 0) {
				if (text.GetCharAt(pos) == '\r') {
					if (pos + 1 < textLength && text.GetCharAt(pos + 1) == '\n')
						return new SimpleSegment(pos, 2);
				}
				return new SimpleSegment(pos, 1);
			}
			return SimpleSegment.Invalid;
		}
	}
}
