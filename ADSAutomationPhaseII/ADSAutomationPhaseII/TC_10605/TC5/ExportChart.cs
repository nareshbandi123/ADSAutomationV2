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

namespace ADSAutomationPhaseII.TC_10605.TC5
{
    [TestModule("221804B7-3C79-4479-8418-0B7258C7E88A", ModuleType.UserCode, 1)]
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
				Steps.ClickonHTMLWorksheet3("Worksheet_TC5");
				Steps.ClickCloseHTML();
				Steps.CloseVisualizationwindow();
				Steps.Cleanupfolder("Worksheet_TC5_files");
				Steps.Cleanup("Worksheet_TC5",".html");
				
				
		}
			catch (Exception ex)
			{
				Steps.CloseVisualizationwindow();
				Steps.Cleanup("Worksheet_TC5",".html");
				Steps.Cleanupfolder("Worksheet_TC5_files");
				Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
			}
			return true;
		}
    }
}
