
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

using ADSAutomationPhaseII.Base;
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Configuration;
using ADSAutomationPhaseII.TC_10593;
using ADSAutomationPhaseII.TC_10590;

namespace ADSAutomationPhaseII.TC_10602.TC8
{
   
    [TestModule("5AD8699E-5064-4F68-8AEB-5764F2AA733D", ModuleType.UserCode, 1)]
    public class ChartPropertiesLabel : BaseClass, ITestModule
    {
        
        public ChartPropertiesLabel()
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
        		TC_10593.Steps.ClickonFileMenu();
        		TC_10590.Steps.ClickonOpen();
        		Steps.SelectNewFile();
        		Steps.ClickonOpenButton();
        		Steps.SelectEntireWindow();
        		Steps.ValidateTestFormattingData();
        		Steps.ClickonWorkSheet2();
        		Steps.SelectEntireWindow();
        		Steps.ValidateWorkSheet2();
        		Steps.CLickonLabel();
        		Steps.ShowDataLabel();
        		Steps.ValidateShowDataLabelOption();
        		Steps.CloseWindow();
        		TC_10593.Steps.DiscardButton();
        	} 
        	catch (Exception ex)
        	{
        		Steps.CloseWindow();
        		TC_10593.Steps.DiscardButton();
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
        	}
        	return true;
        }
    }
}
