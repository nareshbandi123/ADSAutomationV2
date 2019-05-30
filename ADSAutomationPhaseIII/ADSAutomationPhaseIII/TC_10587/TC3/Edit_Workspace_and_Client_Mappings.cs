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

namespace ADSAutomationPhaseIII.TC_10587.TC3
{
    [TestModule("CE110196-7E43-4FC1-AC08-619C3B877AC5", ModuleType.UserCode, 1)]
    public class Edit_Workspace_and_Client_Mappings : BaseClass, ITestModule
    {
        public Edit_Workspace_and_Client_Mappings()
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
        		Steps.SelectEditWorspaceClient();
        		Steps.ClickOnView();
        		Steps.ExpandView();
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
