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

namespace ADSAutomationPhaseIII.TC_10569.TC4
{
    
    [TestModule("AB7A831E-21D0-4105-B043-04CD83BBFBE1", ModuleType.UserCode, 1)]
    public class FileTransferandRemoteCmdExe : BaseClass, ITestModule
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
        		Steps.FolderNameNewProjectDailog("FileTransferRemoteCmdExe");
        		Steps.SelectFileTransferAndRemoteCmdExeNewProjectDailog();
        		Steps.CLickOkButtAndCloseNewProjectDailog();
        		Steps.CheckQAEditorTransferRemoteCmdExe();
        		Steps.CheckFileTransferAndRemoteCmdExeFolderFileStructure();
        		Steps.CheckFileTransferXjsFile();
        		Steps.CloseQATemplateEditorTabTransferRemoteCmdExe();
				Steps.Cleanup("FileTransferRemoteCmdExe");        		
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
