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

namespace ADSAutomationPhaseIII.TC_10569
{
    
    [TestModule("E7914759-B848-478E-A558-CD47AF4F4151", ModuleType.UserCode, 1)]
    public class DatabaseSchemaAndDataExporter : BaseClass, ITestModule
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
        		Steps.FolderNameNewProjectDailog("ADSDtSchemExporter");
        		Steps.SelectDatabaseSchemaAndDataExporterNewProjectDailog();
        		Steps.CLickOkButtAndCloseNewProjectDailog();
        		Steps.CheckQATemplateEditorDtSchemExporter();
        		Steps.CheckDtSchemExporterFolderFileStructure();
        		Steps.CheckDtbaseSchemaAndDataExporterXjsFile();
        		Steps.CloseQATemplateEditorDtSchemExporter();
        		Steps.Cleanup("ADSDtSchemExporter");
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
