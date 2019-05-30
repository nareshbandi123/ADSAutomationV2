
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


namespace ADSAutomationPhaseII.TC_10602.TC3
{
  
    [TestModule("C3CBBB3C-7AAA-4A63-8A71-2F9F9F5ABE7A", ModuleType.UserCode, 1)]
    public class ColorThemesAssignPalette : BaseClass, ITestModule
    {
        
        public ColorThemesAssignPalette()
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
        		TC_10593.Steps.ClickonOpen();
        		Steps.SelectNewFile();
        		Steps.ClickonOpenButton();
        		Steps.SelectEntireWindow();
        		Steps.ValidateTestFormattingData();
        		Steps.ClickonWorkSheet3();
        		Steps.SelectEntireWindow();
        		Steps.ValidateWorkSheet3();
        		Steps.ClickonDropDownBox();
        		Steps.SelectPie();
        		Steps.ClickonColorWindow3();
        		Steps.SelectEditColors();
        		Steps.SelectThemeColor();
        		Steps.ClickonAssignPalette();
        		Steps.ClickonApply();
        		Steps.ClickonOkayButton();
        		Steps.ValidateChangeColorTheme();
        		Steps.ClickonUndoIcon();
        		Steps.ClickonWorkSheet2();
        		Steps.SelectEntireWindow();
        		Steps.ValidateWorkSheet2();
        		Steps.ClickonColorWindow2();
        		Steps.SelectEditColors();
        		Steps.ClickonMeasureValue();
        		Steps.SelectThemeColor1();
        		Steps.CloseEditPopup1();
        		Steps.CloseWindow1();
        	} 
        	catch (Exception ex)
        	{
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
        		Steps.CloseWindow1();
        	}
        	return true;
        }
    }
}
