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
using ADSAutomationPhaseIII.TC_10587;

namespace ADSAutomationPhaseIII.TC_10569.TC7
{
    
    [TestModule("6D0C7462-4F52-4C0B-B754-6E65FB496D2D", ModuleType.UserCode, 1)]
    public class SchemaCompare : BaseClass, ITestModule
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
        		Steps.FolderNameNewProjectDailog("SchemaCompare");
        		Steps.SelectSchemaCompare();
        		Steps.CLickOkButtAndCloseNewProjectDailog();
        		Steps.CheckQAEditorSchemaCompare();
        		Steps.CheckSchemaCompareFolderStructure();
        		Steps.CheckSchemaCompareFileUnderProjectTree();
        		Steps.CloseQAEditorSchemaCompare();
				Steps.Cleanup("SchemaCompare");

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
