// Copyright (c) AlphaSierraPapa for the SharpDevelop Team (for details please see \doc\copyright.txt)
// This code is distributed under the BSD license (for details please see \src\AddIns\Debugger\Debugger.AddIn\license.txt)

using System.Windows.Controls;
using Debugger;
using ICSharpCode.SharpDevelop.Debugging;
using ICSharpCode.SharpDevelop.Services;

namespace ICSharpCode.SharpDevelop.Gui.Pads
{
	public abstract class DebuggerPad : AbstractPadContent
	{
		protected DockPanel panel;
		ToolBar toolbar;
		protected WindowsDebugger debugger;
		
		public override object Control {
			get {
				return panel;
			}
		}
		
		public DebuggerPad()
		{
			// UI
			this.panel = new DockPanel();
			this.toolbar = BuildToolBar();
			
			if (this.toolbar != null) {
				this.toolbar.SetValue(DockPanel.DockProperty, Dock.Top);
			
				this.panel.Children.Add(toolbar);
			}
			
			InitializeComponents();
			
			DebuggerService.CurrentDebuggerChanged += OnDebuggerChanged;
			OnDebuggerChanged(null, null);
		}
		
		protected virtual void OnDebuggerChanged(object sender, System.EventArgs e)
		{
			if (debugger != null)
			{
				debugger.ProcessSelected -= OnSelectedProcess;
			}
			
			if (DebuggerService.CurrentDebugger != null && DebuggerService.CurrentDebugger is WindowsDebugger)
			{
				debugger = (WindowsDebugger) DebuggerService.CurrentDebugger;
				debugger.ProcessSelected += OnSelectedProcess;
				SelectProcess(debugger.DebuggedProcess);
				RefreshPad();
			}
		}
		
		protected virtual void InitializeComponents()
		{
			
		}
		
		protected virtual void OnSelectedProcess(object sender, ProcessEventArgs args)
		{
			SelectProcess(args.Process);
		}
		
		protected virtual void SelectProcess(Process process)
		{
			
		}
		
		public virtual void RefreshPad()
		{
			
		}
		
		protected virtual ToolBar BuildToolBar()
		{
			return null;
		}
	}
}
