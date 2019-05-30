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

namespace ADSAutomationPhaseII.TC_10605.TC_13
{
    
    [TestModule("6B8EEEEF-B180-4926-9E14-97F767048EA2", ModuleType.UserCode, 1)]
    
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
				Steps.Click_Worksheet3();
				Steps.ClickonPDF_FileMenu();				
				Steps.General_Range_Select(0);
				Steps.General_PaperSize_Select("Letter  (8 1/2 x 11 in)");
				Steps.General_Orientation_Select(0);
				Steps.General_Show_Select(true, false, false, false);
				Steps.General_Addons_Select(true,true,false);
				Steps.Click_LayoutTab();
				Steps.Layout_PageOrder_Select(0);
				Steps.Layout_Margin_Select("1","0.5","0.5","0");
				Steps.Click_PrintScaling();
				Steps.PrintScaling_Select(true);
				Steps.ClickonNextAndSaveFile("Worksheet_TC13");
				Steps.ClickonClosePDFFile();
				Steps.CloseVisualizationwindow();
				Steps.Cleanup("Worksheet_TC13");
								
		}
			catch (Exception ex)
			{
				Steps.CloseVisualizationwindow();
				Steps.Cleanup("Worksheet_TC13");
				Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
			}
			return true;
		}
    }
}
