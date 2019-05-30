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

namespace ADSAutomationPhaseIII.TC_10570.TC3
{
    [TestModule("040F69F4-40FE-4706-B577-13200FC70660", ModuleType.UserCode, 1)]
    
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
				Steps.SelectMongoDB_Database("ads_db");
				Steps.SelectTabelAndColumnfromList();
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