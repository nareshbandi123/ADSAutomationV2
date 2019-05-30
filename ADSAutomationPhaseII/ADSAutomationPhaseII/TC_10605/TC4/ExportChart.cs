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

namespace ADSAutomationPhaseII.TC_10605.TC4
{
    
    [TestModule("2174427F-CD99-4B93-9DC5-72F0A7385888", ModuleType.UserCode, 1)]
    
  public class ExportChart : BaseClass, ITestModule
    {
        
       public ExportChart()
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
				Steps.ClickMaximizebutton();
				Steps.NavigatetoWorsheet3();
				Steps.ClickonImageWorksheet3("Worksheet_TC4");
				Steps.CloseVisualizationwindow();
				Steps.Cleanup("Worksheet_TC4",".png");
		}
			catch (Exception ex)
			{
				Steps.Cleanup("Worksheet_TC4",".png");
				Steps.CloseVisualizationwindow();
				
				Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
			}
			return true;
		}
    }
}
