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

namespace ADSAutomationPhaseII.TC_10603.TC_10603_TC2
{
   
    [TestModule("97CC04B9-4101-439E-907A-F8ABC430B0B8", ModuleType.UserCode, 1)]
    public class AnalyticsRefAndTrendsLines : ITestModule
    {
        
        void ITestModule.Run()
        {
           StartProcess(); 
        }
        
        bool StartProcess()
        {
        	try{
        		Steps.ClickOnFileAndOpenMenus();
        		Steps.EnterFilePathAndClickOpenButton();
        		Steps.MaximizeVisualAnalyticsWindow();
        		Steps.SelectEntireWindow();
        		Steps.ShowTrendLines();
        		Steps.AddRefLinesBandOrBox();
        		Steps.SelectLineAndEntireTableActiononAddRefLineBandOrBoxDialog();
        		Steps.LinePanelAddRefLineBandOrBoxDialogSetParam("SUM(Profit)", "Sum","None");
        		Steps.firstLineFormattingPanelLineTab();
        		Steps.HoriLineFormattingPanelAddRefLineBandOrBoxDialog();
        		Steps.FillAboveFormattingPanelAddRefLineBandOrBoxDialog("Olive Green");
        		Steps.FillBelowFormattingPanelAddRefLineBandOrBoxDialog("Brown");
        		Steps.CheckRecalculateLineAddRefLineBandOrBoxDialog();
        		Steps.ClickonApplyOkAdd();
        		Steps.SelectEntireWindow();
        		Steps.ValidateFirstLine();
        		
        		Steps.AddRefLinesBandOrBox();
        		Steps.SelectLineAndEntireTableActiononAddRefLineBandOrBoxDialog();
        		Steps.LinePanelAddRefLineBandOrBoxDialogSetParam("SUM(Profit)", "Average","None");
        		Steps.SecLineFormattingPanelLineTab();
        		Steps.DirAllignmentFormattingPanelAddRefLineBandOrBoxDialog();
        		Steps.FillAboveFormattingPanelAddRefLineBandOrBoxDialog("Dark Blue");
        		Steps.FillBelowFormattingPanelAddRefLineBandOrBoxDialog("Light Orange");
        		Steps.UnCheckRecalculateLineAddRefLineBandOrBoxDialog();
        		Steps.ClickonApplyOkAdd();
        		Steps.ValidateSecLine();
        		
        		Steps.AddRefLinesBandOrBox();
        		Steps.SelectLineAndEntireTableActiononAddRefLineBandOrBoxDialog();
        		Steps.LinePanelAddRefLineBandOrBoxDialogSetParam("SUM(Profit)", "Median","None");
				Steps.ThirdLineFormattingPanelAddRefLineBandOrBoxDialog();
        		Steps.VerticleAllignmentFormattingPanelAddRefLineBandOrBoxDialog();
        		Steps.FillAboveFormattingPanelAddRefLineBandOrBoxDialog("Lime");
        		Steps.FillBelowFormattingPanelAddRefLineBandOrBoxDialog("Green");
        		Steps.CheckRecalculateLineAddRefLineBandOrBoxDialog();
        		Steps.ClickonApplyOkAdd();
        		Steps.ValidateThirdLine();
        		
        		Steps.AddRefLinesBandOrBox();
        		Steps.SelectLineAndEntireTableActiononAddRefLineBandOrBoxDialog();
        		Steps.LinePanelAddRefLineBandOrBoxDialogSetParam("SUM(Profit)", "Percentile 10","None");
        		Steps.firstLineFormattingPanelLineTab();
        		Steps.HoriLineFormattingPanelAddRefLineBandOrBoxDialog();
        		Steps.FillAboveFormattingPanelAddRefLineBandOrBoxDialog("Dark Yellow");
        		Steps.FillBelowFormattingPanelAddRefLineBandOrBoxDialog("Plum");
        		Steps.UnCheckRecalculateLineAddRefLineBandOrBoxDialog();
        		Steps.ClickonApplyOkAdd();
				Steps.ValidateFirstLineRepeat();
				
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
