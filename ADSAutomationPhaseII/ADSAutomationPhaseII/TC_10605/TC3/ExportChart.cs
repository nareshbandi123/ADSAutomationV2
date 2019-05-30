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

namespace ADSAutomationPhaseII.TC_10605.TC3
{
    
    [TestModule("ECA386D4-48F2-4BA9-8426-41E8F4B73D66", ModuleType.UserCode, 1)]
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
				Steps.ClickonImageIcon_LegendThirdOption("Worksheet_TC3");
				Steps.CloseWindowThirdOption();
				Steps.CloseVisualizationwindow();
				Steps.Cleanup("Worksheet_TC3",".png");
				
		}
			catch (Exception ex)
			{
				Steps.CloseVisualizationwindow();
				Steps.Cleanup("Worksheet_TC3",".png");
				Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
			}
			return true;
		}
    }
}
