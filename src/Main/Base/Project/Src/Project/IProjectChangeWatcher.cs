// Copyright (c) AlphaSierraPapa for the SharpDevelop Team (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)
using System;
using System.IO;
using ICSharpCode.Core;
using ICSharpCode.SharpDevelop.Gui;

namespace ICSharpCode.SharpDevelop.Project
{
	public interface IProjectChangeWatcher : IDisposable
	{
		void Enable();
		void Disable();
		void Rename(string newFileName);
		/// <summary>
		/// Pauses (disables) the change watcher and remembers the last state it was in for the Restore method.
		/// </summary>
		void Pause();
		/// <summary>
		/// Restores the change watcher to the state it was when calling Pause or does nothing if no such call was made
		/// </summary>
		void Restore();
	}
	
	public sealed class MockProjectChangeWatcher : IProjectChangeWatcher
	{
		public void Enable()
		{
		}
		
		public void Disable()
		{
		}
		
		public void Rename(string newFileName)
		{
		}
		
		public void Dispose()
		{
		}
		
		public void Pause()
		{
		}
		
		public void Restore()
		{
		}
	}
}
