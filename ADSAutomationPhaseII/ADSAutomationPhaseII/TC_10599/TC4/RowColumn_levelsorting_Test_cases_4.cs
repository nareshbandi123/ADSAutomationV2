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

namespace ADSAutomationPhaseII.TC_10599.TC4
{
    [TestModule("AEB4D701-1C4F-45EA-953D-8935C1EE25A8", ModuleType.UserCode, 1)]
    public class RowColumn_levelsorting_Test_cases_4 : ITestModule
    {
        public RowColumn_levelsorting_Test_cases_4()
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
        		Steps.SelectSumSalesDifference();
        		Steps.ValidateDifferenceChart();
        		Steps.SortBookCasesForTestCases4();
        		Steps.ValidateBookCasesTestCase4();
        		Steps.ClearSorts();
        		Steps.SelectSUMSalesTableDown();
        		Steps.ValidateTableDown();
        		Steps.SortEastDescendingForTestCase4();
        		Steps.ValidateEastSortTestCase4();
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
