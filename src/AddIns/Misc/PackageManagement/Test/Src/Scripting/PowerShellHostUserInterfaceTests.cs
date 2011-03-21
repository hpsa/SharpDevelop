﻿// Copyright (c) AlphaSierraPapa for the SharpDevelop Team (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

using System;
using System.Collections.ObjectModel;
using System.Management.Automation.Host;
using ICSharpCode.PackageManagement.Scripting;
using ICSharpCode.Scripting;
using ICSharpCode.Scripting.Tests.Utils;
using NUnit.Framework;

namespace PackageManagement.Tests.Scripting
{
	[TestFixture]
	public class PowerShellHostUserInterfaceTests
	{
		PowerShellHostUserInterface hostUI;
		FakeScriptingConsole scriptingConsole;
		
		void CreateHostUserInterface()
		{
			scriptingConsole = new FakeScriptingConsole();
			hostUI = new PowerShellHostUserInterface(scriptingConsole);
		}
		
		[Test]
		public void WriteWarningLine_ShowWarningMessage_MessageWrittenToConsole()
		{
			CreateHostUserInterface();
			hostUI.WriteWarningLine("Test");
			
			Assert.AreEqual("Test", scriptingConsole.TextPassedToWriteLine);
		}
		
		[Test]
		public void WriteWarningLine_ShowWarningMessage_ScriptingStyleIsWarning()
		{
			CreateHostUserInterface();
			hostUI.WriteWarningLine("Test");
			
			Assert.AreEqual(ScriptingStyle.Warning, scriptingConsole.ScriptingStylePassedToWriteLine);
		}
		
		[Test]
		public void WriteVerboseLine_ShowVerboseMessage_MessageWrittenToConsole()
		{
			CreateHostUserInterface();
			hostUI.WriteVerboseLine("Test");
			
			Assert.AreEqual("Test", scriptingConsole.TextPassedToWriteLine);
		}
		
		[Test]
		public void WriteVerboseLine_ShowVerboseMessage_ScriptingStyleIsOut()
		{
			CreateHostUserInterface();
			hostUI.WriteVerboseLine("Test");
			
			Assert.AreEqual(ScriptingStyle.Out, scriptingConsole.ScriptingStylePassedToWriteLine);
		}
		
		[Test]
		public void WriteLine_ShowMessage_MessageWrittenToConsole()
		{
			CreateHostUserInterface();
			hostUI.WriteLine("Test");
			
			Assert.AreEqual("Test", scriptingConsole.TextPassedToWriteLine);
		}
		
		[Test]
		public void WriteLine_ShowMessage_ScriptingStyleIsOut()
		{
			CreateHostUserInterface();
			hostUI.WriteLine("Test");
			
			Assert.AreEqual(ScriptingStyle.Out, scriptingConsole.ScriptingStylePassedToWriteLine);
		}
		
		[Test]
		public void WriteErrorLine_ShowErrorMessage_MessageWrittenToConsole()
		{
			CreateHostUserInterface();
			hostUI.WriteErrorLine("Test");
			
			Assert.AreEqual("Test", scriptingConsole.TextPassedToWriteLine);
		}
		
		[Test]
		public void WriteErrorLine_ShowErrorMessage_ScriptingStyleIsError()
		{
			CreateHostUserInterface();
			hostUI.WriteErrorLine("Test");
			
			Assert.AreEqual(ScriptingStyle.Error, scriptingConsole.ScriptingStylePassedToWriteLine);
		}
		
		[Test]
		public void WriteDebugLine_ShowMessage_MessageWrittenToConsole()
		{
			CreateHostUserInterface();
			hostUI.WriteDebugLine("Test");
			
			Assert.AreEqual("Test", scriptingConsole.TextPassedToWriteLine);
		}
		
		[Test]
		public void WriteDebugLine_ShowMessage_ScriptingStyleIsOut()
		{
			CreateHostUserInterface();
			hostUI.WriteDebugLine("Test");
			
			Assert.AreEqual(ScriptingStyle.Out, scriptingConsole.ScriptingStylePassedToWriteLine);
		}
		
		[Test]
		public void Write_ShowMessage_MessageWrittenToConsole()
		{
			CreateHostUserInterface();
			hostUI.Write("Test");
			
			Assert.AreEqual("Test", scriptingConsole.TextPassedToWrite);
		}
		
		[Test]
		public void Write_ShowMessage_ScriptingStyleIsOut()
		{
			CreateHostUserInterface();
			hostUI.Write("Test");
			
			Assert.AreEqual(ScriptingStyle.Out, scriptingConsole.ScriptingStylePassedToWrite);
		}
		
		[Test]
		public void Write_ConsoleColorsSpecified_MessageWrittenToConsole()
		{
			CreateHostUserInterface();
			hostUI.Write(ConsoleColor.Black, ConsoleColor.Red, "Test");
			
			Assert.AreEqual("Test", scriptingConsole.TextPassedToWrite);
		}
		
		[Test]
		public void Write_ConsoleColorsSpecified_ScriptingStyleIsOut()
		{
			CreateHostUserInterface();
			hostUI.Write(ConsoleColor.Black, ConsoleColor.Red, "Test");
			
			Assert.AreEqual(ScriptingStyle.Out, scriptingConsole.ScriptingStylePassedToWrite);
		}
		
		[Test]
		public void PromptForChoice_NoChoices_ReturnsMinusOne()
		{
			CreateHostUserInterface();
			var choices = new Collection<ChoiceDescription>();
			int result = hostUI.PromptForChoice("caption", "message", choices, 2);
			
			Assert.AreEqual(-1, result);
		}
	}
}