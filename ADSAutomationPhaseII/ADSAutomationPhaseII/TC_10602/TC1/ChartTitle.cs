using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;
using ADSAutomationPhaseII.Base;
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Configuration;
using ADSAutomationPhaseII.TC_10556;

namespace ADSAutomationPhaseII.TC_10602.TC1
{
   
    [TestModule("54662522-8930-46CB-AB98-BDD5EE41D9CC", ModuleType.UserCode, 1)]
    public class ChartTitle : BaseClass, ITestModule
    {
        
        public ChartTitle()
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
        		TC_10556.Steps.IsServerRegistered();
		  		TC_10556.Steps.ConnectServer();
        		TC_10556.Steps.ClickQARun();
        		TC_10556.Steps.ClickNewVA();
        		Steps.ClickonWorkSheet();
        		Steps.CreateNewWorkSheet();
        		Steps.ClickonWorkSheet1();
        		Steps.ClickonEditTitle();
        		Steps.ModifytheName();
        		Steps.SelectResetTitleOption();
        		Steps.SelectHideTitleOption();
        		Steps.ClickonWorkSheet();
        		Steps.SelectShowTitleOption();
        		TC_10556.Steps.ClickCloseVA();
        		Steps.DiscardButton();
        	} 
        	catch (Exception ex)
        	{
        		TC_10556.Steps.ClickCloseVA();
        		Steps.DiscardButton();
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
        	}
        	return true;
        }
    }
}
