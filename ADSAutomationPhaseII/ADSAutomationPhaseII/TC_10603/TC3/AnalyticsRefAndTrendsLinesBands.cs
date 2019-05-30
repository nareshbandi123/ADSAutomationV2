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

namespace ADSAutomationPhaseII.TC_10603.TC_10603_TC3
{
    
    [TestModule("BC507622-EC2F-45BB-81E7-6F83BF0ECCA4", ModuleType.UserCode, 1)]
    public class AnalyticsRefAndTrendsLinesBands : ITestModule
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
        		Steps.ShowTrendLines();
        		Steps.AddRefLinesBandOrBox();
        		Steps.SelectBandAndPerPaneActions();
        		Steps.BrandToSetParam("SUM(Profit)", "Maximum", "Custom", "Function Name");
				Steps.firstLineFormattingPanelAddRefLineBandOrBoxDialog();
				Steps.RightHoriLineFormattingPanel();
				Steps.FillAboveFormattingPanelAddRefLineBandOrBoxDialog("Lavender");
				Steps.CheckRecalculateBandAddRefLineBandOrBoxDialog();
        		Steps.ClickonApplyOkAdd();
        		Steps.SelectEntireWindow();
        		Steps.ValidateLavenderBand();
        		
        		Steps.AddRefLinesBandOrBox();
        		Steps.SelectBandAndPerPaneActions();
        		Steps.BrandFromSetParam("Average", "SUM(Profit)", "Custom", "Value");
        		Steps.BrandToSetParam("2000","Constant", "Custom", "Value");
        		Steps.SecLineFormattingPanelBand();
        		Steps.TopVerticleAllignmentFormattingPanelBand();
        		Steps.FillAboveFormattingPanelAddRefLineBandOrBoxDialog("Aqua");
        		Steps.UnCheckRecalculateBandAddRefLineBandOrBoxDialog();
        		Steps.ClickonApplyOkAdd();
        		Steps.ValidateAquaBand();
        		
        		Steps.AddRefLinesBandOrBox();
        		Steps.SelectBandAndPerPaneActions();
        		Steps.BrandFromSetParam("Percentile 50", "SUM(Profit)", "Custom", "Value");
        		Steps.BrandToSetParam( "2600", "Constant", "Custom", "Value");
        		Steps.ThirdLineFormattingPanelAddRefLineBandOrBoxDialog();
        		Steps.BottomVerticleAllignmentFormattingPanelBand();
        		Steps.FillAboveFormattingPanelAddRefLineBandOrBoxDialog("Red");
				Steps.CheckRecalculateBandAddRefLineBandOrBoxDialog();
        		Steps.ClickonApplyOkAdd();
        		Steps.ValidateRedBand();
        		
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
