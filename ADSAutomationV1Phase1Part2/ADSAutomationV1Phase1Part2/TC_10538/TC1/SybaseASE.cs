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
using ADSAutomationPhaseII.Base;
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Preconditions;

namespace ADSAutomationPhaseII.TC_10538.TC1
{
    [TestModule("D3FF5D3E-2558-4D15-968E-054ECE3B55EA", ModuleType.UserCode, 1)]
    public class SybaseASE : BaseClass, ITestModule
    {
        public SybaseASE()
        {
           
        }
        
        void ITestModule.Run()
        {
        	if(Preconditions.Steps.isPreconditionDone)
	        	StartProcess();
        }
        
        bool StartProcess()
        {
        	try{
	        	Steps.ClickOnServerProperties();
	        	Steps.ClickOnConnectionMonitorTab();
	        	Steps.SelectPingIdleConnection();
	        	Steps.ClickOnSave();
	        	Steps.ClickOnYes();
	        	Preconditions.Steps.QueryAnalyser();
	        	Steps.ClickOnTools();
	        	Steps.ClickOnConectionMonitor();
				Steps.ValidatePing();
				Steps.CloseConnectionMonitor();
        	}
        	catch(Exception ex)
        	{
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
        	}
        	return true;
        	
        }
    }
}
