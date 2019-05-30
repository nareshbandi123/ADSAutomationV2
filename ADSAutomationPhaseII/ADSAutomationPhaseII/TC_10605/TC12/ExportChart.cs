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

namespace ADSAutomationPhaseII.TC_10605.TC12
{
	
	[TestModule("961C374B-878F-451F-979C-B5D6F88AA2BE", ModuleType.UserCode, 1)]
	
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
				Steps.Layout_PageOrder_Select(1);
				Steps.Layout_Margin_Select("0.5","0.5","0.5","0.5");
				Steps.Click_PrintScaling();
				Steps.PrintScaling_Select(false);
				Steps.ClickonNextAndSaveFile("Worksheet_TC12");
				Steps.ClickonClosePDFFile();
				Steps.CloseVisualizationwindow();
				Steps.Cleanup("Worksheet_TC12");
				
			}
			catch (Exception ex)
			{
				Steps.CloseVisualizationwindow();
				Steps.Cleanup("Worksheet_TC12");
				Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
			}
			return true;
		}
	}
}
