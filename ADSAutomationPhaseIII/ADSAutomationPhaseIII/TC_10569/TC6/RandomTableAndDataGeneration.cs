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

namespace ADSAutomationPhaseIII.TC_10569.TC6
{
    
    [TestModule("26F30CBA-8BB2-4D57-B54A-301EE07876D6", ModuleType.UserCode, 1)]
    public class RandomTableAndDataGeneration : BaseClass, ITestModule
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
        		Steps.FolderNameNewProjectDailog("RandomTblDtGeneration");
        		Steps.SelectRandomTableAndDataGeneration();
        		Steps.CLickOkButtAndCloseNewProjectDailog();
        		Steps.CheckQAEditorRandomTblDtGeneration();
        		Steps.CheckRandomTblAndDtGenerationFolderStructure();
        		Steps.CheckRandomTblAndDtGenerationFolder3Files();
        		Steps.CloseQAEditorRandomTableAndDtGeneration();
        		Steps.Cleanup("RandomTblDtGeneration");
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
