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

namespace ADSAutomationPhaseII.TC_10599.TC9
{
    [TestModule("26F08786-9151-4413-B545-61C7F64157D8", ModuleType.UserCode, 1)]
    public class Advanced_Sorting_2 : BaseClass, ITestModule
    {
        public Advanced_Sorting_2()
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
        		Steps.Maximize();
        		Steps.NavigateToWorksheet2();
        		Steps.SelectPerCellByMeasureValues();
        		Steps.ValidatePerCellMeasureChart();
        		Steps.SelectDescendingFromAdvanced();
        		Steps.ValidateDescendingAdvanceChart();
        		Steps.CloseViz();
        		TC_10589.Steps.ClickOnDiscard();
        	}
        	catch(Exception e)
        	{
        		Steps.CloseOnOpenFileError();
        		Steps.CloseOnVisualAnalyticsError();
        		TC_10589.Steps.ClickOnDiscard();
        		Reports.ReportLog(e.Message, Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
        	}
        	
        	return true;        	
        }
    }
}
