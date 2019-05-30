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

namespace ADSAutomationPhaseII.TC_10610.TC_10609_TC1
{
    
    [TestModule("594B97EE-5D7C-427C-9C38-AE10E81DA3FA", ModuleType.UserCode, 1)]
    public class CombinationCharts : BaseClass, ITestModule
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
        		Steps.DragOrderdateToColumnsDeck();
        		Steps.DragProfitToRowsDeck();
        		Steps.DragSalesToRowsDeck();
        		Steps.DragUnitPriceToRowsDeck();
        		Steps.SelectBarChartTypeProfitRowsDeck();
        		Steps.SelectShapeChartTypeSalesRowsDeck();
        		Steps.SelectLineChartTypeUnitPriceRowsDeck();
        		Steps.ClickSortIconSUMAxis();
        		Steps.ClickOnUndoButton();
        		Steps.ClickTwoBars();
        		Steps.ValidateTwoBarselected();
        		Steps.ClickOnBlankPart();
        		Steps.ClickOnAxesAndMergedAxesSharedScale();
        		Steps.SelectTwoCircles();
        		Steps.DragRegionToColorDeck();
        		Steps.ClickOnEast();
        		Steps.ValidateAfterClickOnEast();
        		Steps.ClickOnColorDeckAndEditColors();
        		Steps.SelectMetroTheme();
        		Steps.ClickOnAssignPalette();
        		Steps.ClickOnSaveButtonEditColorsRegion();
        		Steps.ClickOnSUMSalesChartPropertiesPanel();
        		Steps.DragRegionToShapeDeck();
        		Steps.ClickOnAxesAndSelectMergedAxesSeparateScale();
        		Steps.RightClickOnSUMProfit();
        		Steps.ClickOnFormat();
        		Steps.ClickOnCurrencyStandardAndOK();
        		Steps.RightClickOnSUMSales();
        		Steps.ClickOnShowAxisAndRightOnly();
        		Steps.ShowTrendLines();
        		Steps.RightClickOnSUMSalesAxis();
        		Steps.ClickOnEditAxisAndSetTitle("Annual Sales");
        		Steps.VerifyToolTipExists();
        		Steps.CloseVisualAnalyticsDailog();        		
        	}
        	catch(Exception e)
        	{
        		Steps.CloseVisualAnalyticsDailog();
        		Reports.ReportLog(e.Message, Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
        	}        	
        	return true;
        }
        
    }
}
