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

namespace ADSAutomationPhaseII.TC_10605.TC14
{
    
    [TestModule("8A24275E-A354-46F8-9B7E-8401F2F6AAF1", ModuleType.UserCode, 1)]
    
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
				Steps.ClickonPDF_Dashboard();				
				Steps.General_Range_Select_Dashboard(0);
				Steps.General_PaperSize_Select("Letter  (8 1/2 x 11 in)");
				Steps.General_Orientation_Select(0);
				Steps.Click_LayoutTab();
				Steps.Layout_PageOrder_Select(1);
				Steps.Layout_Margin_Select("0.5","0.5","0.5","0.5");
				Steps.Click_PrintScaling();
				Steps.PrintScaling_Select(false);
				Steps.ClickonNextAndSaveFile("Dashboard_TC14");
				Steps.ClickonClosePDFFile();
				Steps.CloseVisualizationwindow();
				Steps.Cleanup("Dashboard_TC14");
								
		}
			catch (Exception ex)
			{
				Steps.CloseVisualizationwindow();
				Steps.Cleanup("Dashboard_TC14");
				Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
			}
			return true;
		}
    }
}
