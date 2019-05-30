
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
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Configuration;
using ADSAutomationPhaseII.TC_10556;
using ADSAutomationPhaseII.TC_10602;
using ADSAutomationPhaseII.TC_10592;

namespace ADSAutomationPhaseII.TC_10606.TC1
{
   
    [TestModule("AF803ABF-656C-4012-96C4-A02796E02931", ModuleType.UserCode, 1)]
    public class LinesDistributions : BaseClass, ITestModule
    {
        
        public LinesDistributions()
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
        		TC_10556.Steps.ClickonFileMenu();
        		TC_10556.Steps.ClickonOpen();
        		Steps.SelectNewFile();
        		TC_10602.Steps.ClickonOpenButton();
        		Steps.ClickonVisualization();
        	    Steps.SelectPivotGrid();
        	    Steps.DeselectVisualization();
        	    TC_10602.Steps.SelectEntireWindow();
        	    Steps.ValidatePivotGrid();
        	    Steps.ClickonUndoIcon();
        	    Steps.ClickonUndoIcon();
        	    Steps.ClickonVisualization();
        	    Steps.SelectHighlightTable();
        	    Steps.DeselectVisualization();
        	    TC_10602.Steps.SelectEntireWindow();
        	    Steps.ValidateHighlightTable();
        	    Steps.ClickonUndoIcon();
        	    Steps.ClickonUndoIcon();
        	    Steps.ClickonVisualization();
        	    Steps.SelectHeatMap();
        	    Steps.DeselectVisualization();
        	    TC_10602.Steps.SelectEntireWindow();
        	    Steps.ValidateSelectHeatMap();
        	    Steps.ClickonUndoIcon();
        	    Steps.ClickonUndoIcon();
        	    Steps.ClickonVisualization();
        	    Steps.SelectBar();
        	    Steps.DeselectVisualization();
        	    TC_10602.Steps.SelectEntireWindow();
        	    Steps.ClickonUndoIcon();
        	    Steps.ClickonUndoIcon();
        	    Steps.ClickonVisualization();
        	    Steps.SelectSideSidebyBars();
        	    Steps.DeselectVisualization();
        	    TC_10602.Steps.SelectEntireWindow();
        	    Steps.ValidateSidebySideBar();
        	    Steps.ClickonUndoIcon();
        	    Steps.ClickonUndoIcon();
        	    Steps.ClickonVisualization();
        	    Steps.SelectStackedBars();
        	    Steps.DeselectVisualization();
        	    TC_10602.Steps.SelectEntireWindow();
        	    Steps.ValidateStackedBars();
        	    Steps.ClickonUndoIcon();
        	    Steps.ClickonUndoIcon();
        	    Steps.ClickonVisualization();
        	    Steps.SelectLineContinues();
        	    Steps.DeselectVisualization();
        	    TC_10602.Steps.SelectEntireWindow();
        	    Steps.ValidateLineContinues();
        	    Steps.ClickonUndoIcon();
        	    Steps.ClickonUndoIcon();
        	    Steps.ClickonVisualization();
        	    Steps.SelectLineDescrete();
        	    Steps.DeselectVisualization();
        	    TC_10602.Steps.SelectEntireWindow();
        	    Steps.ValidateLineDescrete();
        	    Steps.ClickonUndoIcon();
        	    Steps.ClickonUndoIcon();
        	    Steps.ClickonVisualization();
        	    Steps.SelectDualLine();
        	    Steps.DeselectVisualization();
        	    TC_10602.Steps.SelectEntireWindow();
        	    Steps.ValidateDualLines();
        	    Steps.ClickonUndoIcon();
        	    Steps.ClickonUndoIcon();
        	    Steps.ClickonVisualization();
        	    Steps.SelectAreaContinues();
        	    Steps.DeselectVisualization();
        	    TC_10602.Steps.SelectEntireWindow();
        	    Steps.ValidateSelectAreaContinues();
        	    Steps.ClickonUndoIcon();
        	    Steps.ClickonUndoIcon();
        	    Steps.ClickonVisualization();
        	    Steps.SelectAreaDescrete();
        	    Steps.DeselectVisualization();
        	    TC_10602.Steps.SelectEntireWindow();
        	    Steps.ValidateAreaDescrete();
        	    Steps.ClickonUndoIcon();
        	    Steps.ClickonUndoIcon();
        	    Steps.ClickonVisualization();
        	    Steps.SelectSidebySideArea();
        	    Steps.DeselectVisualization();
        	    TC_10602.Steps.SelectEntireWindow();
        	    Steps.ValidateSidebySideArea();
        	    Steps.ClickonUndoIcon();
        	    Steps.ClickonUndoIcon();
        	    Steps.ClickonVisualization();
        	    Steps.SelectStackedArea();
        	    Steps.DeselectVisualization();
        	    TC_10602.Steps.SelectEntireWindow();
        	    Steps.ValidateStackedArea();
        	    Steps.ClickonUndoIcon();
        	    Steps.ClickonUndoIcon();
        	    Steps.ClickonVisualization();
        	    Steps.SelectDualCombination();
        	    Steps.DeselectVisualization();
        	    TC_10602.Steps.SelectEntireWindow();
        	    Steps.ValidateDualCombination();
        		Steps.ClickonUndoIcon();
        		Steps.ClickonUndoIcon();
        		Steps.ClickonVisualization();
        	    Steps.SelectScotterPlot();
        	    Steps.DeselectVisualization();
        	    TC_10602.Steps.SelectEntireWindow();
        	    Steps.ValidateScotterPlot();
        	    Steps.ClickonUndoIcon();
        	    Steps.ClickonUndoIcon();
        	    Steps.ClickonVisualization();
        	    Steps.SelectFilledMap();
        	    Steps.DeselectVisualization();
        	    TC_10602.Steps.SelectEntireWindow();
        	    Steps.ValidateFilledMap();
        	    Steps.ClickonUndoIcon();
        	    Steps.ClickonUndoIcon();
        	    Steps.ClickonVisualization();
        	    Steps.SelectSymbolMap();
        	    Steps.DeselectVisualization();
        	    TC_10602.Steps.SelectEntireWindow();
        	    Steps.ValidateSymbolMap();
        	    Steps.ClickonUndoIcon();
        	    Steps.ClickonUndoIcon();
        	    Steps.ClickonVisualization();
        	    Steps.SelectPieChart();
        	    Steps.DeselectVisualization();
        	    TC_10602.Steps.SelectEntireWindow();
        	    Steps.ValidatePieChart();
        	    Steps.ClickonUndoIcon();
        	    Steps.ClickonUndoIcon();
        	    Steps.ClickonVisualization();
        	    Steps.SelectSunBurst();
        	    Steps.DeselectVisualization();
        	    TC_10602.Steps.SelectEntireWindow();
        	    Steps.ValidateSunBurst();
        	    Steps.ClickonUndoIcon();
        	    Steps.ClickonUndoIcon();
        	    Steps.ClickonVisualization();
        	    Steps.SelectTreeMap();
        	    Steps.DeselectVisualization();
        	    TC_10602.Steps.SelectEntireWindow();
        	    Steps.ValidateTreemap();
        	    Steps.ClickonUndoIcon();
        	    Steps.ClickonUndoIcon();
        	    Steps.ClickonVisualization();
        	    Steps.SelectCandleStick();
        	    Steps.SelectCandlestickConfiguration();
        	    Steps.DeselectVisualization();
        	    TC_10602.Steps.SelectEntireWindow();
        	    Steps.ValidateCandleStick();
        	    Steps.ClickonUndoIcon();
        	    Steps.ClickonUndoIcon();
        	    Steps.ClickonVisualization();
        	    Steps.SelectHighLowClose();
        		Steps.SelectHLCConfiguration();
        		Steps.DeselectVisualization();
        		TC_10602.Steps.SelectEntireWindow();
        		Steps.ValidateHighLowClose();
        		Steps.ClickonUndoIcon();
        		Steps.ClickonUndoIcon();
        		Steps.ClickonVisualization();
        		Steps.SelectFunnelMap();
        		Steps.DeselectVisualization();
        		TC_10602.Steps.SelectEntireWindow();
        		Steps.ValidateFunnelMap();
        		Steps.ClickonUndoIcon();
        		Steps.ClickonUndoIcon();
        		Steps.ClickonVisualization();
        		Steps.SelectGuageChart();
        		Steps.DeselectVisualization();
        		TC_10602.Steps.SelectEntireWindow();
        		Steps.ValidateGuageChart();
        		Steps.ClickonUndoIcon();
        		Steps.ClickonUndoIcon();
        		Steps.ClickonVisualization();
        		Steps.SelectHorizon();
        		Steps.DeselectVisualization();
        		TC_10602.Steps.SelectEntireWindow();
        		Steps.ValidateHorizon();
        		Steps.ClickonUndoIcon();
        		Steps.ClickonUndoIcon();
        		Steps.ClickonVisualization();
        		Steps.SelectMekko();
        		Steps.DeselectVisualization();
        		TC_10602.Steps.SelectEntireWindow();
        		Steps.ValidateMekkoChart();
        		Steps.ClickonUndoIcon();
        		Steps.ClickonUndoIcon();
        		Steps.ClickonVisualization();
        		Steps.SelectRadar();
        		Steps.DeselectVisualization();
        		TC_10602.Steps.SelectEntireWindow();
        		Steps.ValidateRadarChart();
        		Steps.ClickonUndoIcon();
        		Steps.ClickonUndoIcon();
        		Steps.ClickonVisualization();
        		Steps.SelectBoxPlot();
        		Steps.DeselectVisualization();
        		TC_10602.Steps.SelectEntireWindow();
        		Steps.ValidateBoxPlot();
        		Steps.ClickonUndoIcon();
        		Steps.ClickonUndoIcon();
        		Steps.ClickonVisualization();
        		Steps.SelectBullet();
        		Steps.DeselectVisualization();
        		TC_10602.Steps.SelectEntireWindow();
        		Steps.ValidateBulletChart();
				Steps.ClickonUndoIcon();
      		    TC_10602.Steps.CloseWindow();
        		TC_10593.Steps.DiscardButton();
        	} 
        	catch (Exception ex)
        	{
        		TC_10602.Steps.CloseWindow();
        		TC_10593.Steps.DiscardButton();
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
        	}
        	return true;
        }
    }
}
