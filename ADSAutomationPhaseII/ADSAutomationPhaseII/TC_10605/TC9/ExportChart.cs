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

namespace ADSAutomationPhaseII.TC_10605.TC9
{
   
    [TestModule("1CBE6A34-D14B-41C7-AEB4-A6D5A72B7134", ModuleType.UserCode, 1)]
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
				Steps.General_PaperSize_Select("Business Envelope #14  (5 x 11 1/2 in)");
				Steps.General_Orientation_Select(0);
				Steps.General_Show_Select(true, true, true, true);
				Steps.General_Legent_Select(0);
				Steps.General_Addons_Select(true,true,true);
				Steps.Click_LayoutTab();
				Steps.Layout_PageOrder_Select(0);
				Steps.Layout_Margin_Select("0.5","0.5","0.5","0.5");
				Steps.Click_PrintScaling();
				Steps.PrintScaling_Select(false);
				Steps.ClickonNextAndSaveFile("Worksheet_TC9");
				Steps.ClickonClosePDFFile();
				Steps.CloseVisualizationwindow();
				Steps.Cleanup("Worksheet_TC9");
		}
			catch (Exception ex)
			{
				Steps.CloseVisualizationwindow();
				Steps.Cleanup("Worksheet_TC9");
				Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
			}
			return true;
		}
    }
}
