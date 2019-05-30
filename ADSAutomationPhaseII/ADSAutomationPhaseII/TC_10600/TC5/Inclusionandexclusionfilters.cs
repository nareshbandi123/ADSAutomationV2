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
using ADSAutomationPhaseII.TC_10556;
using ADSAutomationPhaseII.TC_10602;
using ADSAutomationPhaseII.TC_10590;

namespace ADSAutomationPhaseII.TC_10600.TC5
{
    
    [TestModule("915C2B40-C780-4473-A5B6-7FDCFC4649CC", ModuleType.UserCode, 1)]
    public class Inclusionandexclusionfilters : BaseClass, ITestModule
    {
       
        public Inclusionandexclusionfilters()
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
        		TC_10590.Steps.ClickonFileMenu();
        		TC_10590.Steps.ClickonOpen();
        		Steps.SelectNewFile();
        		TC_10602.Steps.ClickonOpenButton();
        		TC_10602.Steps.SelectEntireWindow();
        		Steps.ValidateTestFilteringData();
        		Steps.SelectTwoYears();
        		Steps.ValidateAfterSelectTwoyears();
        		Steps.SelectTwoColors();
        		Steps.ValidateAfterSelectTwoColors();
        		TC_10556.Steps.ClickCloseVA();
        	} 
        	catch (Exception ex)
        	{
        		TC_10556.Steps.ClickCloseVA();
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
        	}
        	return true;
        }
    }
}
