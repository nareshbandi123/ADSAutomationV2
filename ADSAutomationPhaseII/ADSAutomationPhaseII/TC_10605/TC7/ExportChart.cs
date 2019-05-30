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

namespace ADSAutomationPhaseII.TC_10605.TC7
{
    
    [TestModule("8E6AF878-9BF2-4A60-993F-A9ACA3BBC004", ModuleType.UserCode, 1)]
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
				Steps.ClickonPDF_FileMenu();
				Steps.General_Range_Select(0);
				Steps.General_PaperSize_Select("Letter  (8 1/2 x 11 in)");
				Steps.General_Orientation_Select(0);
				Steps.General_Show_Select(true, true, true, true);
				Steps.General_Legent_Select(3);
				Steps.General_Addons_Select(true,true,true);
				Steps.Click_LayoutTab();
				Steps.Layout_PageOrder_Select(0);
				Steps.Layout_Margin_Select("0.5","0.5","0.5","0.5");
				Steps.Click_PrintScaling();
				Steps.PrintScaling_Select(false);
				Steps.ClickonNextAndSaveFile("Worksheet_TC7");
				Steps.ClickonClosePDFFile();
				Steps.CloseVisualizationwindow();
				Steps.Cleanup("Worksheet_TC7");
								
		}
			catch (Exception ex)
			{
				Steps.CloseVisualizationwindow();
				Steps.Cleanup("Worksheet_TC7");
				Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
			}
			return true;
		}
    }
}