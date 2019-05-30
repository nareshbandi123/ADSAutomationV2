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

namespace ADSAutomationPhaseII.TC_10601.TC6
{
   
    [TestModule("C4CE04B5-832D-406A-AF40-169B5EB35C1A", ModuleType.UserCode, 1)]
    
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
				Steps.NavigatetoSheet8andSelectmultiple();
				Steps.ValidateseveralchartKeeptooltip();
				Steps.NavigatetoSheet9();
				Steps.SelectmultipleWorsheet9();
				Steps.DragAndSelectExcludeTooltip();
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
