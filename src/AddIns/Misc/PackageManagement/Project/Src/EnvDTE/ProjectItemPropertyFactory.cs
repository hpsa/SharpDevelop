﻿// Copyright (c) AlphaSierraPapa for the SharpDevelop Team (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

using System;
using System.Collections.Generic;

namespace ICSharpCode.PackageManagement.EnvDTE
{
	public class ProjectItemPropertyFactory : IPropertyFactory
	{
		ProjectItem projectItem;
		
		public ProjectItemPropertyFactory(ProjectItem projectItem)
		{
			this.projectItem = projectItem;
		}
		
		public Property CreateProperty(string name)
		{
			return new ProjectItemProperty(projectItem, name);
		}
		
		public IEnumerator<Property> GetEnumerator()
		{
			yield return new ProjectItemProperty(projectItem, ProjectItem.CopyToOutputDirectoryPropertyName);
			yield return new ProjectItemProperty(projectItem, ProjectItem.CustomToolPropertyName);
			yield return new ProjectItemProperty(projectItem, ProjectItem.FullPathPropertyName);
		}
	}
}
