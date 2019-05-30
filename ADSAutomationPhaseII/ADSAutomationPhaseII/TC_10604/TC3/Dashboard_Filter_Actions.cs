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
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Preconditions;
using ADSAutomationPhaseII.Configuration;
using ADSAutomationPhaseII.TC_10589;
using ADSAutomationPhaseII.TC_10599;


namespace ADSAutomationPhaseII.TC_10604.TC3
{
    [TestModule("FD07A67C-BA39-4D54-A479-E4B580E7C204", ModuleType.UserCode, 1)]
    public class Dashboard_Filter_Actions : ITestModule
    {
        public Dashboard_Filter_Actions()
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
        		TC_10589.Steps.ClickOnFileMenu();
        		TC_10589.Steps.ClickOnOpenMenu();
        		Steps.EnterFilePath();
        		TC_10589.Steps.ClickOnOpenButton();
        		TC_10599.Steps.Maximize();
        		Steps.ActionSetting();
        		Steps.SelectCalifornia();
        		Steps.ValidateCaliforniaChart();
        		Steps.UnSelectCalifornia();
        		Steps.ValidateUnselectMapChart();
        		Steps.SelectCaliforniaAndNevadaFromMap();
        		Steps.UnSelectCaliforniaAndNevadaFromMap();
        		Steps.RemoveActionSetting();
        		TC_10599.Steps.CloseViz();
        		TC_10589.Steps.ClickOnDiscard();
        	}
        	catch(Exception e)
        	{
        		Steps.CloseOnOpenFileError();
        		Steps.CloseOnVisualAnalyticsError();
        		Reports.ReportLog(e.Message, Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
        	}
        	
        	return true;        	
        }
    }
}
