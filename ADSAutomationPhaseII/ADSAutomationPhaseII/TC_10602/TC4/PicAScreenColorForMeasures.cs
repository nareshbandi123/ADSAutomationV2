
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

namespace ADSAutomationPhaseII.TC_10602.TC4
{
   
    [TestModule("0C480327-29AC-4BBF-87BC-8012AC7F224D", ModuleType.UserCode, 1)]
    public class PicAScreenColorForMeasures : BaseClass, ITestModule
    {
       
        public PicAScreenColorForMeasures()
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
        		Steps.ClickonWorkSheet3();
        		Steps.SelectEntireWindow();
        		Steps.ValidateWorkSheet3();
        		Steps.ClickonDropDownBox();
        		Steps.SelectPie();
        		Steps.SelectEntireWindow();
        		Steps.ValidateChangetoPieChart();
        		Steps.ClickonColorWindow3();
        		Steps.SelectEditColors();
        		Steps.ClickonCentralButton();
        		Steps.ClickonPickScreenColor();
        		Steps.ClickonApply();
        		Steps.CloseEditPopup();        		
        		Steps.CloseWorkSheet3();
        		TC_10593.Steps.DiscardButton();
        	} 
        	catch (Exception ex)
        	{
        		Steps.CloseWorkSheet3();
        		TC_10593.Steps.DiscardButton();
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
        	}
        	return true;
        }
    }
}
