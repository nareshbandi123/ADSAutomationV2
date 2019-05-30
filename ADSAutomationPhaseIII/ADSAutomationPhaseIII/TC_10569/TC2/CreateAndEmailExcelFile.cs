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

namespace ADSAutomationPhaseIII.TC_10569.TC2
{
    [TestModule("B79CB719-789C-4C94-B181-458F04567049", ModuleType.UserCode, 1)]
    public class CreateAndEmailExcelFile : BaseClass, ITestModule
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
        		Steps.FolderNameNewProjectDailog("ADSSample");
        		Steps.SelectCreateAndEmailExcelFileNewProjectDailog();
        		Steps.CLickOkButtAndCloseNewProjectDailog();
        		Steps.CheckQATemplateEditor();
        		Steps.CheckADSSampleFolderFileStructure();
        		Steps.CheckCreateandEmailExcelFileUnderProjectTree();
        		Steps.CloseQATemplateEditor();
				Steps.Cleanup("ADSSample");
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
