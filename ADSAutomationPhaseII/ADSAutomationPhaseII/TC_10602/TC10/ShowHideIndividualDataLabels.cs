
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

namespace ADSAutomationPhaseII.TC_10602.TC10
{
    
    [TestModule("06858F9A-EC47-43B8-B5A3-F5D36BA40518", ModuleType.UserCode, 1)]
    public class ShowHideIndividualDataLabels : BaseClass, ITestModule
    {
        
        public ShowHideIndividualDataLabels()
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
        		Steps.ClickonWorkSheet4();
        		Steps.SelectEntireWindow();
        		Steps.ValidateWorkSheet4();
        		Steps.ClickonNeverShowLabel();
        		Steps.ValidateNeverShow();
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
