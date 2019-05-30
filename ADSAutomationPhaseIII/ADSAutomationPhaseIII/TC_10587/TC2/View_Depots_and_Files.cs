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

namespace ADSAutomationPhaseIII.TC_10587.TC2
{
    [TestModule("0A1EE441-DDBE-4442-A3F3-80D929B2B8AA", ModuleType.UserCode, 1)]
    public class View_Depots_and_Files : ITestModule
    {
        public View_Depots_and_Files()
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
        		Steps.SelectBrowseDepots();
        		Steps.ExpandDepot();
        		Steps.UnMountWorkSpace();
        		Steps.ClickOnServersTab();
        	}
        	catch(Exception e)
        	{
        		Reports.ReportLog(e.Message, Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
        	}
        	
        	return true;        	
        }

    }
}
