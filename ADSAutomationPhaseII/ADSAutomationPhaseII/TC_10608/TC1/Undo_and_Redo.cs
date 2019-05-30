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

namespace ADSAutomationPhaseII.TC_10608.TC1
{
    [TestModule("47ABF288-C541-4389-9DD7-4636692A08C3", ModuleType.UserCode, 1)]
    public class Undo_and_Redo : BaseClass, ITestModule
    {
        public Undo_and_Redo()
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
        		Steps.DragProfitToRowPanel();
        		Steps.SelectAverage();
        		Steps.SelectAreaChartType();
        		Steps.ClickUndo();
        		Steps.ValidateRevertToAvgProfit();
        		Steps.ClickUndo();
        		Steps.ValidateRevertToSUMProfit();
        		Steps.ClickUndo();
        		Steps.ValidateRevertToNoProfitInRowPanel();
        		Steps.ClickRedo();
        		Steps.ValidateRevertToSUMProfitRedo();
        		Steps.ClickRedo();
        		Steps.ValidateRevertToAvgProfitRedo();
        		Steps.ClickRedo();
        		Steps.ValidateRevertToAreaChart();
        		Steps.SelectDualAxes();
        		Steps.ValidateDualAxesChart();
        		Steps.DeleteWorksheet1();
        		Steps.ValidateWorksheet2();
        		Steps.ClickUndo();
        		Steps.ClickUndo();
        		Steps.ClickRedo();
        		Steps.RemoveAvgProfit();
        		Steps.ClickUndo();
        		Steps.DragRegionsToColors();
        		Steps.ClickOnAvgAccordion();
        		Steps.DragDiscountToColors();
        		Steps.ClickUndo();
        		Steps.ClickUndo();
        		Steps.ClickRedo();
        		Steps.ClickRedo();
        		Steps.SortSUMSales();
        		Steps.ClickUndo();
        		Steps.ClickUndo();
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
