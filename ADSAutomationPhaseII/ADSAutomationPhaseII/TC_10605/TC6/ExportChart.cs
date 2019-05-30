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

namespace ADSAutomationPhaseII.TC_10605.TC6
{
    [TestModule("283DB3EF-2880-4E50-9B5C-B93B86DFD13F", ModuleType.UserCode, 1)]
    
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
				Steps.ClickonExcelWorksheet3("NewWorksheet_TC6");
				Steps.CloseDownloadexcelWindow();
				Steps.CloseVisualizationwindow();
				Steps.Cleanup("NewWorksheet_TC6",".xlsx");
				
		}
			catch (Exception ex)
			{
				Steps.CloseVisualizationwindow();
				Steps.Cleanup("NewWorksheet_TC6",".xlsx");
				Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
			}
			return true;
		}
    }
}
