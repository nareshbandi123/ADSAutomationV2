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
using ADSAutomationPhaseIII.TC_10574;

namespace ADSAutomationPhaseIII.TC_10584.TC1
	
{
   
    [TestModule("5EE3D41A-5341-416A-9212-EC67804DF526", ModuleType.UserCode, 1)]
    
    public class SchemaTree : BaseClass, ITestModule
    {
       
        public SchemaTree()
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
				Steps.RightClickLocalDatabaseConnect();
				Steps.RightClickLocalDatabasefailed();
				Steps.VerifyFailedDatabase();
				Steps.VerifyItemsSchemaBrowserTitlePanelBar();
				Steps.ClickonMaximizePanel();
				Steps.OpenServerQueryAnalyzer();
				Steps.RightclickunselectPinnedmodeoption();
				Steps.ClickonAnalyzertwice();
				Steps.CreatenewServerGroup();
				Steps.DeleteWorkgroup();
				Steps.RightclickSelectFloatingoption();
				Steps.RightclickSelectDockedModeoption();
				Steps.RightclickSelectSplitmode();
				Steps.RightclickSelectandclickonMoveTo();
				Steps.RightclickSelectHideOptionAndF1();				
				Steps.ClickonHorizontalAndVerticalScrollbar();
				Steps.ClickonF5Details();
				Steps.ClickInformixServer();
				Steps.ClickOracleServer();
				Steps.ClickonSQLServer();
				Preconditions.Steps.CloseTab();
			}
			catch (Exception ex)
			{
				Preconditions.Steps.CloseTab();
				Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
			}
			return true;
		}
    }
}
