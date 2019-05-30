using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

using WinForms = System.Windows.Forms;
using ADSAutomationPhaseIII.Commons;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

using ADSAutomationPhaseIII.Base;
using ADSAutomationPhaseIII.Extensions;
using ADSAutomationPhaseIII.Configuration;

namespace ADSAutomationPhaseIII.TC_10570.TC4
{
    
    [TestModule("4311277B-C236-40EA-8CB4-D1709F0E70BB", ModuleType.UserCode, 1)]
   
    public class Editor_MongoAutoCompletion : Base.BaseClass, ITestModule
    {
   
    	public Editor_MongoAutoCompletion()
    
		{
			
		}
		void ITestModule.Run()
		{
			StartProcess();
		}
		
		bool StartProcess()
		{
			try
			{
				Steps.ClickonFileMenu();
				Steps.ClickonOptions();
				Steps.ClickExpandQueryAnalyzer();
				Steps.SelectMangoDB();
				Steps.SelectAutoCompletion(true);
				Steps.SelectDefaultSyntax(0);
				Steps.SelectMongoDB_Database("tom");
				Steps.SelectDatabasefromList();
				Steps.CloseQueryPanel();
			}
				
			catch (Exception ex)
			{
				Steps.CloseQueryPanel();
				Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
			}
			return true;
		}

    }
          
}
