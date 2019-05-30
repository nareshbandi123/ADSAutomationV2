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

namespace ADSAutomationPhaseIII.TC_10569.TC1
{
    
    [TestModule("EDCF9403-D134-4F23-824D-6FEB9941C145", ModuleType.UserCode, 1)]
    public class Projects : BaseClass, ITestModule
    {
    	 public static TC_10569_10572Repo repo = TC_10569_10572Repo.Instance;
     
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
        		Steps.FolderNameNewProjectDailog("ADS");
        		Steps.SelectNoneAndClickOnCreateNewProjectDailog();
        		Steps.CLickOkButtAndCloseNewProjectDailog();
        		Steps.CheckADSFolderFileStructure();
        		Steps.OpenNewScriptNewScriptDailog();
        		Steps.CreateNewScript("sample");
        		Steps.OpenRegisterServerDialog();
        		Steps.RegisterServerDialogSetParam("Amazon Redshift", "root", "Amazon11", "aquafold.ctslhmmdmjtr.us-east-1.redshift.amazonaws.com", "5439", "aquafold");
        		Steps.CloseConnectionTestSUCCESSDialog();
        		Steps.SaveRegisterServerDialog();
        		Steps.SelectFloatingModeServersTab();
        		Steps.ClickOnProject();
        		Steps.DragServerToServerFolder();        		
        		Steps.CreateNewUserFile("sample");
        		Steps.RightClickOnProjectTreeAndClickOnNewFolder();
        		Steps.CreateNewFolder("ads");
        		Steps.RemoveFlotingFromServer();
        		Steps.Cleanup("ADS");
        		Steps.Cleanup("ads");
//        		Steps.ClickOnServersTab();          		
        	}
        	catch(Exception e)
        	{
				Steps.Cleanup("ADS");
        		Steps.Cleanup("ads");
				Steps.ClickOnServersTab();          		        		
        		Reports.ReportLog(e.Message, Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
        	}        	
        	return true;
        }
        
    }
}
