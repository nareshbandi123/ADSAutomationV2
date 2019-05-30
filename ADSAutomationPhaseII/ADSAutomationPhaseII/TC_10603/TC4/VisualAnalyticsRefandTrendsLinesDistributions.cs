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

namespace ADSAutomationPhaseII.TC_10603.TC_10603_TC4
{
    
    [TestModule("D8EE3952-802D-471B-BB5F-A786A5AD8FEB", ModuleType.UserCode, 1)]
    public class VisualAnalyticsRefandTrendsLinesDistributions : ITestModule
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
        		Steps.SelectDistributionAndPerCellActionons();
        		Steps.PercentageValueFieldLinePanelDistributionSetParam("60", "Sum");
        		Steps.LabelFieldLinePanelDistributionSetParam("Value");
        		Steps.firstLineFormattingPanelAddRefLineBandOrBoxDialog();
        		Steps.CenterHoriLineFormattingPanelDistribution();
        		Steps.FillFormattingPanelAddRefLineBandOrBoxDialog("Blue");
        		Steps.SelectFillAboveCmb();
        		Steps.CheckRecalculDistributionCmb();
        		Steps.ClickonApplyOkAdd();
        		Steps.SelectEntireWindow();
        		Steps.ValidatePercentageDistribution();
        		
        		Steps.AddRefLinesBandOrBox();
        		Steps.SelectDistributionAndPerCellActionons();
        		Steps.PercentilesValueFieldLinePanelDistributionSetParam("90");
        		Steps.LabelFieldLinePanelDistributionSetParam("Value");
        		Steps.SecLineFormattingPanelDistribution();
        		Steps.TopVerticleAllignmentFormattingPanelDistribution();
        		Steps.FillFormattingPanelAddRefLineBandOrBoxDialog("Blue");
        		Steps.SelectFillBelowCmb();
        		Steps.UnCheckRecalculDistributionCmb();
        		Steps.ClickonApplyOkAdd();
        		Steps.ValidatePercentileDistribution();
        		
        		Steps.AddRefLinesBandOrBox();
        		Steps.SelectDistributionAndPerCellActionons();
        		Steps.QuantilesValueFieldLinePanelDistributionSetParam("4");
        		Steps.LabelFieldLinePanelDistributionSetParam("Value");
        		Steps.ThirdLineFormattingPanelDistribution();
        		Steps.BottomVerticleAllignmentFormattingPanelDistribution();
        		Steps.FillFormattingPanelAddRefLineBandOrBoxDialog("Green");
        		Steps.SelectSymmetricCmb();
        		Steps.CheckRecalculDistributionCmb();
        		Steps.ClickonApplyOkAdd();
        		Steps.ValidateQuantileDistribution();
        		
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
