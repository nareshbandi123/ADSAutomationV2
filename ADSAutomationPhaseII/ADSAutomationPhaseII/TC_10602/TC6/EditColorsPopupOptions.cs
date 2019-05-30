
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

namespace ADSAutomationPhaseII.TC_10602.TC6
{
   
    [TestModule("383B4E33-4BC9-4FA8-9C2E-665EF7CC86DC", ModuleType.UserCode, 1)]
    public class EditColorsPopupOptions : BaseClass, ITestModule
    {
        
        public EditColorsPopupOptions()
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
        		Steps.ClickonWorkSheet7();
        		Steps.SelectEntireWindow();
        		Steps.ValidateWorkSheet7();
        		Steps.ClickonColorWindow7();
        		Steps.SelectEditColors();
        		Steps.CheckSteppedColor();
        		Steps.SettheSteppedValue();
        		Steps.SelectYellowColor();
        		Steps.ClickonOkayforSaleWindow();
        		Steps.ValidateSteppedValueChanges();
        		Steps.ClickonColorWindow7();
        		Steps.SelectEditColors();
        		Steps.UnCheckSteppedColor();
        		Steps.CheckReversedBox();
        		Steps.ClickonOkayforSaleWindow();
        		Steps.ClickonColorWindow7();
        		Steps.SelectEditColors();
        		Steps.SelectRedGreenDiverging();
        		Steps.CheckFullColorRange();
        		Steps.ClickonOkayforSaleWindow();      		
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
