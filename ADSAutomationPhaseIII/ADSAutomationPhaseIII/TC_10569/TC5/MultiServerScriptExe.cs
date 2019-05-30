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
using ADSAutomationPhaseIII.Base;
using ADSAutomationPhaseIII.Extensions;
using ADSAutomationPhaseIII.Commons;
using ADSAutomationPhaseIII.Preconditions;
using ADSAutomationPhaseIII.Configuration;

namespace ADSAutomationPhaseIII.TC_10569.TC5
{
    
    [TestModule("C72C6EEF-E2DC-43CD-BDC0-064BE96390BB", ModuleType.UserCode, 1)]
    public class MultiServerScriptExe : BaseClass, ITestModule
    {
        void ITestModule.Run()
        {
            StartProcess();
        }
        
        bool StartProcess()
        {
        	try
        	{
        		Steps.ClickOnProject();
        		Steps.RightClickOnProjectTreeAndClickOnNewProject();
        		Steps.FolderNameNewProjectDailog("MultiServerScriptExe");
        		Steps.SelectMultiServerScriptExeNewProjectDailog();
        		Steps.CLickOkButtAndCloseNewProjectDailog();
        		Steps.CheckQATemplateMultiServerScriptExe();
        		Steps.CheckMultiServerScriptExeFolderStructure();
        		Steps.CheckMultiServerScriptExeFileUnderProjectTree();
        		Steps.CloseQATemplateMultiServerScriptExe();
				Steps.Cleanup("MultiServerScriptExe");
				Steps.ClickOnServersTab();          						
        	}
        	catch(Exception e)
        	{   
				Steps.ClickOnServersTab();          		        		
        		Reports.ReportLog(e.Message, Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
        	}        	
        	return true;
        }
    }
}
