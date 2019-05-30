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
using ADSAutomationPhaseII.TC_10593;

namespace ADSAutomationPhaseII.TC_10603.TC_10603_TC5
{
    
    [TestModule("1C4CFD54-A690-4DB8-9131-1C12929BE7C4", ModuleType.UserCode, 1)]
    public class VisualAnalyticsRefandTrendsLinesBoxplot : ITestModule
    {        
    	void ITestModule.Run()
        {
            StartProcess();        	
        }
        
        bool StartProcess()
        {
        	try
        	{
        		Steps.ClickOnFileAndOpenMenus();
        		Steps.EnterFilePathAndClickOpenButton();
        		Steps.MaximizeVisualAnalyticsWindow();
        		Steps.SelectEntireWindow();
        		Steps.ClickonVisualizationAndBoxPlotIcon();
        		Steps.EditRefLinesBandOrBox();
        		Steps.SelectBoxPlotAndWhiskersExtend("Data within 1.5 times the IQR");
        		Steps.SelectStyle("Modern");
        		Steps.FillBoxPlotTab("Dark Green");
        		Steps.SelectFirstLineAndColorBorderBoxPlotTab("Orange");
        		Steps.SelectFirstLineAndGreenColorWhiskerBoxPlotTab();
        		Steps.ClickonApplyOkAdd();
        		Steps.SelectEntireWindow();
        		Steps.ValidateBoxIconTab1();
        		
        		Steps.EditRefLinesBandOrBox();
        		Steps.SelectBoxPlotAndWhiskersExtend("Data within 1.5 times the IQR");
        		Steps.CheckHideUnderlyingMarks();
        		Steps.SelectStyle("Classic");
        		Steps.FillRedColorBoxPlotTab();
        		Steps.SelectSecLineAndBlueColorBorderBoxPlotTab();        		
        		Steps.SelectSecLineAndYelloColorWhiskerBoxPlotTab();
        		Steps.ClickonApplyOkAdd();
        		Steps.SelectEntireWindow();
        		Steps.ValidateBoxIconTab2();
        		
        		Steps.EditRefLinesBandOrBox();
        		Steps.SelectBoxPlotAndWhiskersExtend("Maximum extend of the data");
        		Steps.UnCheckHideUnderlyingMarks();
        		Steps.SelectStyle("Classic with dual fill ");
        		Steps.FillPinkColorBoxPlotTab();
        		Steps.SelectThirdineAndLimeColorBorderBoxPlotTab();
        		Steps.SelectThirdLineAndLavanderColorWhiskerBoxPlotTab();
        		Steps.ClickonApplyOkAdd();
        		Steps.ValidateBoxIconTab3();
        		
        		Steps.EditRefLinesBandOrBox();
        		Steps.SelectBoxPlotAndWhiskersExtend("Maximum extend of the data");
        		Steps.CheckHideUnderlyingMarks();
        		Steps.SelectStyle("Outline");
        		Steps.SelectFourthlineAndSkyBlueColorBorderBoxPlotTab();
        		Steps.SelectThirdLineAndVioletColorWhiskerBoxPlotTab();
        		Steps.ClickonApplyOkAdd();
        		Steps.ValidateBoxIconTab4();
        		
        		Steps.CloseTrendLineDetailsDialog();
        		Steps.CloseVisualAnalyticsDailog();        		
        	}
        	catch(Exception e)
        	{
        		Steps.CloseTrendLineDetailsDialog();
        		Steps.CloseVisualAnalyticsDailog();
        		Reports.ReportLog(e.Message, Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
        	}        	
        	return true;
        }
        
    }
}
