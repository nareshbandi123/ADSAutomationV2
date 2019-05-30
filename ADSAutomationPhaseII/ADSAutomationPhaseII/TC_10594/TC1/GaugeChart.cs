using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

using WinForms = System.Windows.Forms;
using ADSAutomationPhaseII.Commons;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

using ADSAutomationPhaseII.Base;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Configuration;
using ADSAutomationPhaseII.TC_10590;

namespace ADSAutomationPhaseII.TC_10594.TC1
{
	
	[TestModule("3476B80A-2050-47E7-B471-1B80D565AC7D", ModuleType.UserCode, 1)]
	public class GaugeChart : BaseClass, ITestModule
	{
		public GaugeChart()
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
				TC_10590.Steps.ClickonOpen();
				Steps.SelectNewFile();
				Steps.ClickonOpenButton();
				Steps.ClickonWorkSheet();
				Steps.SelectNewWorkSheet();
				Steps.DragProductCategoryandState_DimentionstoColumns();
				Steps.ValidateProductCategoryandState_DimentionstoColumns();
				Steps.DragProfitMeasuremet();
				Steps.ClickonVisualization();
				Steps.ClickonGaugeMapIcon();
				Steps.ValidateGaugeMapIcon();
				Steps.DeselectVisualization();
				Steps.DragProductCategoryDimensionsLabel();
				Steps.ValidateChangePCtoLabel();
				Steps.SelectForegroundAndBackground();
				Steps.ChartPropertiesOptionsRedtoBlue();
				Steps.ValidateChartPropertiesOptionsRedtoBlue();
				Steps.ChartOptionValuesforGreenandBlue();
				Steps.Chartvalidation();
				Steps.ValidateChartOptionValuesforGreenandBlue();
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
