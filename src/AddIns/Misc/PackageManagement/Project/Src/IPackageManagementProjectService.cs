﻿// Copyright (c) AlphaSierraPapa for the SharpDevelop Team (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

using System;
using ICSharpCode.SharpDevelop.Project;

namespace ICSharpCode.PackageManagement
{
	public interface IPackageManagementProjectService
	{
		IProject CurrentProject { get; }
		Solution OpenSolution { get; }
		
		event ProjectEventHandler ProjectAdded;
		event SolutionFolderEventHandler SolutionFolderRemoved;
		event EventHandler SolutionClosed;
		event EventHandler<SolutionEventArgs> SolutionLoaded;
		
		void RefreshProjectBrowser();
	}
}