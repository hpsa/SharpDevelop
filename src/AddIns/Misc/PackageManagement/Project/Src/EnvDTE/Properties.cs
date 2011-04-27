﻿// Copyright (c) AlphaSierraPapa for the SharpDevelop Team (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

using System;
using ICSharpCode.SharpDevelop.Project;

namespace ICSharpCode.PackageManagement.EnvDTE
{
	public class Properties
	{
		Project project;
		
		public Properties(Project project)
		{
			this.project = project;
		}
		
		public Property Item(string propertyName)
		{
			return new Property(project, propertyName);
		}
	}
}