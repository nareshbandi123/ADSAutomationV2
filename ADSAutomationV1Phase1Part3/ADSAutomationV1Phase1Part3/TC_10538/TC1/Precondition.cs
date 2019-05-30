﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

using WinForms = System.Windows.Forms;
using ADSAutomationPhaseII.Base;
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Configuration;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Preconditions;
using ADSAutomationV1Phase1Part3.TC_10538;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace ADSAutomationPhaseII.TC_10538
{
    [TestModule("11BC5B6B-5724-46C8-A897-ABBC225DCF00", ModuleType.UserCode, 1)]
    public class Precondition : BaseClass, ITestModule
    {
    	public static TC10538 repo = TC10538.Instance;
        public Precondition()
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
        		Preconditions.Steps.CloseTab();
        		if(!repo.Application.ServerTab.Visible){Steps.ClickOnF1Servers();}
        		TreeItem server = Preconditions.Steps.GetServerTreeFromTCName(Config.TestCaseName);
	      		Preconditions.Steps.SelectedServerTreeItem = server;
	      		Preconditions.Steps.SelectedServerName = server.Text;
	      		server.RightClickThis();
        		Preconditions.Steps.ConnectServer();
        		server.RightClickThis();
				Preconditions.Steps.isPreconditionDone = true; 				
        	}
        	catch (Exception ex) 
        	{
        		Preconditions.Steps.isPreconditionDone = false;
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
        	}
        	return true;
        }
    }
}
