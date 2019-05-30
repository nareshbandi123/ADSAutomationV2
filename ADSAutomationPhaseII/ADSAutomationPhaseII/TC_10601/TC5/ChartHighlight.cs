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

namespace ADSAutomationPhaseII.TC_10601.TC5
{
    [TestModule("D2BA5D44-A21B-4E8C-92FD-250A24CE1119", ModuleType.UserCode, 1)]
    public class ChartHighlight : ITestModule
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
				Steps.NavigatetoWorsheet6AndClickMultiple();
				Steps.ValidateClickColorsfromMap1Worksheet6();
				Steps.DragSelectSeveralChart();
				Steps.ValidateSelectedChartSegmentsClickKeeponly();				
				Steps.NavigatetoWorsheet7AndClickMultiple();
				Steps.ValidateClickColorsfromMap1();
				Steps.DragSelectSeveralChart_Worsheet7();	
				Steps.ValidateSelectedChartSegmentsClickExlude7();
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
