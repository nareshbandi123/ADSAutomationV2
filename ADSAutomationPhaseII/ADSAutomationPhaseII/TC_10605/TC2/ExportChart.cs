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

namespace ADSAutomationPhaseII.TC_10605.TC2
{
    
    [TestModule("E837284C-EDA3-4C82-B672-396FAC08B2CA", ModuleType.UserCode, 1)]
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
				Steps.ClickonHTMLIcon("Worksheet_TC2");
				Steps.ClickonClosePDFFile();
				Steps.CloseVisualizationwindow();
				Steps.Cleanupfolder("Worksheet_TC2_files");
				Steps.Cleanup("Worksheet_TC2",".html");
				
		}
			catch (Exception ex)
			{
				Steps.CloseVisualizationwindow();
				Steps.Cleanupfolder("Worksheet_TC2_files");
				Steps.Cleanup("Worksheet_TC2",".html");
				Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
			}
			return true;
		}
    }
}
