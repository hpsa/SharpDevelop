﻿// Copyright (c) AlphaSierraPapa for the SharpDevelop Team (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

using ICSharpCode.SharpDevelop.Editor.Search;
using System;
using System.Diagnostics;
using ICSharpCode.SharpDevelop.Dom.Refactoring;
using ICSharpCode.SharpDevelop.Editor;

namespace SearchAndReplace
{
	public class ForwardTextIterator : ITextIterator
	{
		ProvidedDocumentInformation info;
		
		enum TextIteratorState {
			Resetted,
			Iterating,
			Done,
		}
		
		TextIteratorState state;
		
		IDocument document;
		int       endOffset;
		int       oldOffset = -1;
		
		public IDocument Document {
			get {
				return document;
			}
		}
		
		public char Current {
			get {
				switch (state) {
					case TextIteratorState.Resetted:
						throw new System.InvalidOperationException("Call moveAhead first");
					case TextIteratorState.Iterating:
						return document.GetCharAt(Position);
					case TextIteratorState.Done:
						throw new System.InvalidOperationException("TextIterator is at the end");
					default:
						throw new System.InvalidOperationException("unknown text iterator state");
				}
			}
		}
		
		int position;
		public int Position {
			get {
				return position;
			}
			set {
				position = value;
			}
		}
		
		public ForwardTextIterator(ProvidedDocumentInformation info)
		{
			if (info == null)
				throw new ArgumentNullException("info");
			
			this.info       = info;
			this.document   = info.Document;
			this.position   = info.CurrentOffset;
			this.endOffset  = info.EndOffset;
			
			Reset();
		}
		
		public char GetCharRelative(int offset)
		{
			if (state != TextIteratorState.Iterating) {
				throw new System.InvalidOperationException();
			}
			
			int realOffset = (Position + (1 + Math.Abs(offset) / document.TextLength) * document.TextLength + offset) % document.TextLength;
			return document.GetCharAt(realOffset);
		}
		
		public bool MoveAhead(int numChars)
		{
			Debug.Assert(numChars > 0);
			
			// HACK : ignore files with length 1 (fixes SD-1815)
			if (document.TextLength == 1) {
				state = TextIteratorState.Done;
				return false;
			}
			
			switch (state) {
				case TextIteratorState.Resetted:
					if (document.TextLength == 0) {
						state = TextIteratorState.Done;
						return false;
					}
					Position = endOffset;
					state = TextIteratorState.Iterating;
					return true;
				case TextIteratorState.Done:
					return false;
				case TextIteratorState.Iterating:
					if (oldOffset == -1 && document.TextLength == endOffset) {
						// HACK: Take off one if the iterator start
						// position is at the end of the text.
						Position--;
					}
					
					if (oldOffset != -1 && Position == endOffset - 1 && document.TextLength == endOffset) {
						state = TextIteratorState.Done;
						return false;
					}
					
					Position = (Position + numChars) % document.TextLength;
					bool finish = oldOffset != -1 && (oldOffset > Position || oldOffset < endOffset) && Position >= endOffset;
					
					// HACK: Iterating is complete if Position == endOffset - 1 
					// when the iterator start position was initially at the
					// end of the text.
					if (oldOffset != -1 && oldOffset == endOffset - 1 && document.TextLength == endOffset) {
						finish = true;
					}
					
					oldOffset = Position;
					if (finish) {
						state = TextIteratorState.Done;
						return false;
					}
					return true;
				default:
					throw new Exception("Unknown text iterator state");
			}
		}
		
		public void InformReplace(int offset, int length, int newLength)
		{
			if (offset <= endOffset) {
				endOffset = endOffset - length + newLength;
			}
			
			if (offset <= Position) {
				Position = Position - length + newLength;
			}
			
			if (offset <= oldOffset) {
				oldOffset = oldOffset - length + newLength;
			}
		}

		public void Reset()
		{
			state      = TextIteratorState.Resetted;
			Position   = endOffset;
			oldOffset  = -1;
		}
		
		public override string ToString()
		{
			return String.Format("[ForwardTextIterator: Position={0}, endOffset={1}, state={2}]", Position, endOffset, state);
		}
	}
}
