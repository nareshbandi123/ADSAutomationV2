using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

using WinForms = System.Windows.Forms;
using ADSAutomationPhaseII.Base;
using ADSAutomationPhaseII.Commons;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace ADSAutomationPhaseII.TC_10601.TC4
{
    
	[TestModule("B3A51D93-ECE9-4D8C-B2D4-5777E6EB53E6", ModuleType.UserCode, 1)]
	
    public class ChartHighlight : BaseClass, ITestModule
	{
		public ChartHighlight()
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
				Steps.ClickonFileMenu();
				Steps.ClickonOpen();
				Steps.SelectNewFile();
				Steps.ClickonOpenButton();				
				Steps.ClickMaximumWindow();
				Steps.NavigatetoWorksheet5SelecttwoColors();
				Steps.ValidateSelect_Chartwith2_colors();
				Steps.ClickonchartClickKeepOnly();
				Steps.ValidateSelectedChartAndClickKeepOnly();
				Steps.ClickUndo();
				Steps.ClickonVisualization();
				Steps.SelectMekkoClick2colors();
				Steps.ValidateSelectMekkoClick2colors();
				Steps.MekkoclickExclude();
				Steps.ValidateSelect_Mekkoclick_Exclude();
				Steps.ClickUndo();
				Steps.CloseVisualChart();
				Steps.ClickonSwapRowsandColumnsicon();
				Steps.ValidateSwapRowsColumnsicon();
				Steps.ClickonSwapRowsandColumnsSelect2Colors();				
				Steps.SelectedChartKeepOnly();
				Steps.ValidateAfterclickon_SwapIcon_Keep_Only();
				Steps.ClickUndo();
				Steps.ClickonVisualization();
				Steps.ClickonRadarExclude();
				Steps.ValidateRadarExcludeSelection();
				Steps.CloseVAWindow();	
			}
			catch (Exception ex)
			{
				Steps.CloseVAWindow();
				Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
			}
			return true;
		}
    }
}
