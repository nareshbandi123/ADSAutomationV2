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
using ADSAutomationPhaseIII.Commons;
using ADSAutomationPhaseIII.Configuration;
using ADSAutomationPhaseIII.Extensions;
using ADSAutomationPhaseIII.Preconditions;

namespace ADSAutomationPhaseIII.TC_10585.TC1
{
    
    [TestModule("C2A11342-B9D2-47A4-935D-A1EDB4A7FF1C", ModuleType.UserCode, 1)]
    public class VersionControl_Subversion : BaseClass, ITestModule
    {
    	
    	void ITestModule.Run()
        {
         	StartProcess();
        }
        
        bool StartProcess()
        {
        	try 
        	{
        		Steps.ClickOnFilesTab();
        		
//        		Steps.ClickOnLWindowIconKeyboard();
//        		Steps.SetRepoURL(@"svn://172.24.1.154/C:/Repos/TestAutomation");
//        		Steps.ClickOKonSVN();
        		
        		Steps.RightClickOnFileSystemTree();
        		Steps.NavigateOnVersionControlAndSubversion();
        		Steps.ClickOnCheckout();
        		Steps.VerifyConfVersionControlDailog();
        		Steps.SetRepoPath(@"svn://172.24.1.154/C:/Repos/TestAutomation"); 
        		Steps.SetUserName("cigniti");
        		Steps.SetPassword("cigniti");
        		Steps.ClickOnHEAD();
        		Steps.SetCheckoutDirectory("SVN");
        		Steps.ClickOnOkButton();
        		Steps.CheckCompletedStatus();
        		Steps.ClickOnOKCheckout();
        		Steps.ExpandSVNTree();
        		Steps.ClickOnNew();
        		Steps.ProvideName("ADS");
        		Steps.ClickOnOKNewFile();
        		Steps.RightClickOnADSFile();
        		Steps.ClickOnDeleteFile();
        		Steps.ClickOnYes();
        		Steps.RightClickOnTest1Sql();
        		Steps.ClickOnOpen();
        		Steps.ClickOnOpenInTextEditor();
        		Steps.ModifyScriptsAndClickOnSaveIcon("Modify Data");
        		Steps.CloseEditorTab();
        		Steps.RightClickOnTest1Sql();
        		Steps.ClickOnVersionControl();
        		Steps.ClickOnRevert();
        		Steps.CheckCompletedStatusRevert();
        		Steps.ClickOnOKButtonOnRevert();        		
        		Steps.RightClickOnTest1Sql();
        		Steps.ClickOnOpen();
        		Steps.ClickOnOpenInTextEditor();
        		Steps.CloseEditorTab();
				Steps.DeleteSVNTree();
				Steps.ClickOnServersTab();
        		
        	}
        	catch(Exception e)
        	{
        		Steps.DeleteSVNTree();
//        		Steps.CloseSVNBrowser();
//        		Steps.Cleanup("SVN");
        		Steps.CloseConfigureVersionControlDailog(); 
				Steps.ClickOnServersTab();        		
        		Reports.ReportLog(e.Message, Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
        	}     	
        	return true;
        }
        
    }
}
