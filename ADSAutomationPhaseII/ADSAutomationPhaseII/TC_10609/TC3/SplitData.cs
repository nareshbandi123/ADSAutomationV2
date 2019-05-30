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
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Preconditions;
using ADSAutomationPhaseII.Configuration;

namespace ADSAutomationPhaseII.TC_10609.TC_10609_TC3
{
    
    [TestModule("DCB2DA87-A949-469A-AEDF-03D611781098", ModuleType.UserCode, 1)]
    public class SplitData : BaseClass, ITestModule
    {        
        void ITestModule.Run()
        {
            StartProcess();        	
        }
        
        bool StartProcess()
        {
        	try
        	{
        		Steps.ClickOnFileAndOpenMenus();
        		Steps.EnterFilePathAndClickOpenButton();
        		Steps.MaximizeVisualAnalyticsWindow();
        		Steps.SplitMyField(";");
        		Steps.VerifySplitMyField();
        		Steps.VerifyMyFieldAfrerUndo();
        		Steps.VerifyMyFieldAfrerRedo();
        		Steps.DragMyFieldSplit1ToColumnsDeck();
        		Steps.DragMyFieldSplit2ToRowsDeck();
        		Steps.CloseVisualAnalyticsDailog();        		
        	}
        	catch(Exception e)
        	{
        		Steps.CloseVisualAnalyticsDailog();
        		Reports.ReportLog(e.Message, Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
        	}        	
        	return true;
        }
        
        
    }
}
