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

namespace ADSAutomationPhaseII.TC_10605.TC22
{
    
    [TestModule("4965D610-8AC5-4C8E-88D2-72DCB3412FF4", ModuleType.UserCode, 1)]
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
				Steps.Click_Worksheet10();				
				Steps.ClickonPDF_FileMenu();				
				Steps.General_Range_Select(2);
				Steps.SelectGeneralWorsheets();
				Steps.General_PaperSize_Select("Letter  (8 1/2 x 11 in)");
				Steps.General_Orientation_Select(2);
				Steps.General_Show_Select(true, true, false, false);
				Steps.General_Legent_Select(0);
				Steps.General_Addons_Select(true,true,true);
				Steps.Click_LayoutTab();
				Steps.Layout_PageOrder_Select(1);
				Steps.Layout_Margin_Select("0.5","0.5","0.5","0.5");
				Steps.Click_PrintScaling();
				Steps.PrintScaling_Select(true);
				Steps.ClickonNextAndSaveFile("Worksheet_TC22");
				Steps.ClickonClosePDFFile();
				Steps.CloseVisualizationwindow();
				Steps.Cleanup("Worksheet_TC22");
				
		}
			catch (Exception ex)
			{
				Steps.CloseVisualizationwindow();
				Steps.Cleanup("Worksheet_TC22");
				Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
			}
			return true;
		}
    }
}