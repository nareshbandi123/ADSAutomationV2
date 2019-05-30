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

namespace ADSAutomationPhaseIII.TC_10570.TC2
{
    
    [TestModule("106CB3AC-35AD-4459-B14A-E7C12AA4D67B", ModuleType.UserCode, 1)]
    
    public class Editor_MongoAutoCompletion : BaseClass, ITestModule
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
				Steps.SelectDefaultSyntax(1);
				Steps.SelectLocalDBServerListMango("use ads_db");
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