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

namespace ADSAutomationPhaseII.TC_10601.TC3
{
   
    [TestModule("D5457F56-7D43-479C-B5A5-1F3BAD4BD4FD", ModuleType.UserCode, 1)]
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
				Steps.ClickonWorkSheet4fewentrie();
				Steps.ValidateSelectFewColorsinLegend();
				Steps.ClickonKeepOnlyTooltipFewEntiries();
				Steps.ValidateSelectfewKeepOnlyTooltip();
				Steps.ClickUndo();
				Steps.ClickonFewandExclude();
				Steps.ValidateSelectfewExcludeTooltip();
				Steps.ClickUndo();
				Steps.DragRegiontoLabelClickOptions();
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
