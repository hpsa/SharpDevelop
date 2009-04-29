// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <author name="Daniel Grunwald"/>
//     <version>$Revision$</version>
// </file>

using System;
using ICSharpCode.NRefactory;
using System.Collections.Generic;

namespace ICSharpCode.SharpDevelop.Editor
{
	public interface ITextEditorProvider : IFileDocumentProvider
	{
		ITextEditor TextEditor {
			get;
		}
	}
	
	/// <summary>
	/// Interface for text editors.
	/// </summary>
	public interface ITextEditor : IServiceProvider
	{
		IDocument Document { get; }
		ITextEditorCaret Caret { get; }
		ITextEditorOptions Options { get; }
		
		/// <summary>
		/// Gets the start offset of the selection.
		/// </summary>
		int SelectionStart { get; }
		
		/// <summary>
		/// Gets the length of the selection.
		/// </summary>
		int SelectionLength { get; }
		
		/// <summary>
		/// Gets/Sets the selected text.
		/// </summary>
		string SelectedText { get; set; }
		
		/// <summary>
		/// Sets the selection.
		/// </summary>
		/// <param name="selectionStart">Start offset of the selection</param>
		/// <param name="selectionLength">End offset of the selection</param>
		void Select(int selectionStart, int selectionLength);
		
		/// <summary>
		/// Is raised when the selection changes.
		/// </summary>
		event EventHandler SelectionChanged;
		
		/// <summary>
		/// Sets the caret to the specified line/column and brings the caret into view.
		/// </summary>
		void JumpTo(int line, int column);
		
		string FileName { get; }
		
		[Obsolete]
		void ShowInsightWindow(ICSharpCode.TextEditor.Gui.InsightWindow.IInsightDataProvider provider);
		[Obsolete]
		void ShowCompletionWindow(ICSharpCode.TextEditor.Gui.CompletionWindow.ICompletionDataProvider provider, char ch);
		
		void ShowCompletionWindow(ICompletionItemList data);
		
		/// <summary>
		/// Open a new insight window showing the specific insight items.
		/// </summary>
		/// <param name="items">The insight items to show in the window.</param>
		/// <returns>The insight window.</returns>
		IInsightWindow OpenInsightWindow(IEnumerable<IInsightItem> items);
		
		/// <summary>
		/// Gets the insight window that is currently open.
		/// </summary>
		IInsightWindow ActiveInsightWindow { get; }
	}
	
	public interface ITextEditorOptions
	{
		/// <summary>
		/// Gets the text used for one indentation level.
		/// </summary>
		string IndentationString { get; }
	}
	
	public interface ITextEditorCaret
	{
		/// <summary>
		/// Gets/Sets the caret offset;
		/// </summary>
		int Offset { get; set; }
		
		/// <summary>
		/// Gets/Sets the caret line number.
		/// Line numbers are counted starting from 1.
		/// </summary>
		int Line { get; set; }
		
		/// <summary>
		/// Gets/Sets the caret column number.
		/// Column numbers are counted starting from 1.
		/// </summary>
		int Column { get; set; }
		
		/// <summary>
		/// Gets/sets the caret position.
		/// </summary>
		Location Position { get; set; }
	}
}