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

namespace ADSAutomationPhaseIII.TC_10587.TC1
{
    [TestModule("5BE291C2-C53E-4BDA-8717-0781E12CB5AC", ModuleType.UserCode, 1)]
    public class VersionControl_Perforce : BaseClass, ITestModule
    {
        public VersionControl_Perforce()
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
        		Steps.ClickOnFilesTab();
        		Steps.NavigateToPerforce();
        		Steps.EnterURL();
        		Steps.EnterUsername();
        		Steps.EnterPassword();
        		Steps.CreateNewPerforce();
        		Steps.CreateWorkspace();
        		Steps.CreateFolderPath();
        		Steps.ClickConfigurationOk();
        		Steps.ClickCheckoutOk();
        	}
        	catch(Exception e)
        	{
        		Reports.ReportLog(e.Message, Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
        	}
        	
        	return true;        	
        }
    }
}
