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
using ADSAutomationPhaseIII.TC_10587; 

namespace ADSAutomationPhaseIII.TC_10585.TC2
{
    
    [TestModule("C208188A-479B-40EE-B38A-72B97AB6B33D", ModuleType.UserCode, 1)]
    public class History_SVNRepositoryBrowser : BaseClass, ITestModule
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
        		
        		Steps.RightClickOnSVNTree();
        		Steps.ClickOnVersionControl();
        		Steps.ClickOnShowHistory();
        		Steps.VerifyShowCompleteHistoryCheckbox();
        		Steps.VerifyHistoryColumns();
        		Steps.RightClcik2RowsAndClcikCompare();
        		Steps.CloseCompareDialog();
        		Steps.RightClickOnItem();
        		Steps.ClickShowChanges();
        		Steps.CloseCompareDialog();
        		Steps.RightClickOnItem();
        		Steps.RightClickOncheckoutRevisionOption();
				Steps.ClosecheckoutProjectDialog();        		
        		Steps.CloseHistoryDialog();
        		
        		Steps.RightClickOnSVNTree();
        		Steps.ClickOnVersionControl();
        		Steps.ClickOnBrowseRepository();
        		Steps.VerifyBrowseRepositoryDailog();
        		Steps.RightClick2RowsAndClcikCompareBrowserRepo();        		
        		Steps.CloseCompareDialog();
        		Steps.RightClickOnBowserRepoItem();
        		Steps.VerifyOptionsSVNRepoDailog();
        		Steps.CloseSVNRepoDialog();
        		
        		Steps.DeleteSVNTree();
//        		Steps.Cleanup("SVN"); 
        		Steps.ClickOnServersTab();
        	}
        	catch(Exception e)
        	{
        		Steps.DeleteSVNTree();
//        		Steps.Cleanup("SVN"); 
        		Steps.ClickOnServersTab();        		
        		Reports.ReportLog(e.Message, Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
        	}     	
        	return true;
        }
        
    }
}
