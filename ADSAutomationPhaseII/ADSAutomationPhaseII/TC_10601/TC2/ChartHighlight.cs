using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

using WinForms = System.Windows.Forms;
using ADSAutomationPhaseII.Base;
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.TC_10594;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace ADSAutomationPhaseII.TC_10601.TC2
{
    [TestModule("EB6FB961-1CEC-4654-A597-D9DF8E6B42C6", ModuleType.UserCode, 1)]
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
				Steps.ClickonNewworksheet12();
				Steps.DragRegionAndSales();
				Steps.ClickCentralandEast();
				Steps.ClickCopiersandEnvelopes();
				Steps.ValidateClickCopiersandEnvelopes();
				Steps.ClickExclude();
				Steps.ValidateClickExclude();
				Steps.ClickUndo();
				Steps.ClickUndo();
				Steps.ClickSwapandKeeponlySelect();
				Steps.ValidateSelectSwapandKeeponly();
				Steps.Worksheet3Testdatapreparation();
				Steps.ClickOntheChartKeepOnly();
				Steps.ValidateKeepOnly_Worksheet3();
				Steps.ClickUndo();
				Steps.ClickOntheChartExclude();
				Steps.ValidateExclude_Worksheet3();
				Steps.ClickUndo();
				Steps.ClickonVisualization();
				Steps.ClickKeeponlyAfterSwap();
				Steps.ValidateSwapKeeponly_Worksheet3();				
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
