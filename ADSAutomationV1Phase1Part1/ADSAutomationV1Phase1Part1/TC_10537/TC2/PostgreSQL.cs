﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;
using ADSAutomationPhaseII.Commons;

namespace ADSAutomationPhaseII.TC_10537.TC2
{
    [TestModule("EB6CA29B-0AC4-4DC9-96C2-EA093FBD38E1", ModuleType.UserCode, 1)]
    public class PostgreSQL : Base.BaseClass, ITestModule
    {
       
        public PostgreSQL()
        {
           
        }

        void ITestModule.Run()
        {
        	if(Preconditions.Steps.isPreconditionDone)
            	StartProcess();	
        }
        
        bool StartProcess()
        {
        	try 
        	{
        		Steps.ClickOnToolsMenu();
        		Steps.ClickOnImport();
        		Steps.SelectServerImport();
        		Steps.ClickOkButton();
        		Steps.SelectImportFile();
        		Steps.ClickOnNext();
        		Steps.SelectTable();
        		Steps.ClickOnNext();
        		Steps.ClickOnNext();
        		Steps.ClickOnNext();
        		Steps.CheckImportStatus();
        	} 
        	catch (Exception ex) 
        	{
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
        	}
        	return true;
        }
    }
}
