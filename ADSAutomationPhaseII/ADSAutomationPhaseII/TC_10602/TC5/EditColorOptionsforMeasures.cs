
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

namespace ADSAutomationPhaseII.TC_10602.TC5
{
   
    [TestModule("161607D5-7245-4951-AD42-905E698318D2", ModuleType.UserCode, 1)]
    public class EditColorOptionsforMeasures : BaseClass, ITestModule
    {
        
        public EditColorOptionsforMeasures()
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
        		Steps.CloseWindow();
        		TC_10593.Steps.DiscardButton();
        	} 
        	catch (Exception ex)
        	{
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
        	}
        	return true;
        }
    }
}
