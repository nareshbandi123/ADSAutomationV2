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

namespace ADSAutomationPhaseII.TC_10599.TC6
{
    [TestModule("0436CD3F-27DC-48F7-8FC1-9FAB152DD195", ModuleType.UserCode, 1)]
    public class RowColumn_level_sorting : ITestModule
    {
        public RowColumn_level_sorting()
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
        		Steps.NavigateToWorksheet3();
        		Steps.SortAscendingFurniture();
        		Steps.ValidateFurnitureAscending();
        		Steps.SelectColsAdvancedSort();
        		Steps.ClearSorts();
        		Steps.SwapRowsAndColumns();
        		Steps.ValidateSwapRowsAndColumn();
        		Steps.SelectRowsAdvancedSort();
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
