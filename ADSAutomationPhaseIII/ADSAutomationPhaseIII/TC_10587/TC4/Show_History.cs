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

namespace ADSAutomationPhaseIII.TC_10587.TC4
{
    [TestModule("78543563-C16C-49BB-A510-1FA631A3C56E", ModuleType.UserCode, 1)]
    public class Show_History : ITestModule
    {
        public Show_History()
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
        		Steps.ShowHistory();
        		Steps.ValidateRevisionHistory();
        		Steps.ValidateDateSubmitted();
        		Steps.ValidateSubmittedBy();
        		Steps.ValidateDescription();
        		Steps.ShowChanges();
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
