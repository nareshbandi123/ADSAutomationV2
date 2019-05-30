﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Configuration;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Preconditions;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace ADSAutomationPhaseII.TC_10567.TC5
{
    [TestModule("F3FA9DA9-6742-473F-86BF-C24286EF6C7F", ModuleType.UserCode, 1)]
    public class Precondition : Base.BaseClass, ITestModule
    {
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
        		TreeItem server = Preconditions.Steps.GetServerTreeFromTCName(Config.TestCaseName);
        		Preconditions.Steps.CloseTab(server.Text);  
	      		Preconditions.Steps.SelectedServerTreeItem = server;
	      		Preconditions.Steps.SelectedServerName = server.Text;
	      		server.RightClickThis();
        		Preconditions.Steps.ConnectServer();
        		Preconditions.Steps.QueryAnalyser();
        		Preconditions.Steps.CreateDatabase();
        		Preconditions.Steps.CloseTab(server.Text);        		
        		Preconditions.Steps.QueryAnalyser();
        		if(Config.SchemaServers.Contains(server.Text))
        			Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB_CAPS);
    			else
    				Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
        		Preconditions.Steps.CreateTable();
        		Preconditions.Steps.CreateTrigger();
        		Preconditions.Steps.CloseTab(server.Text);
        	}
        	catch(Exception ex)
        	{
        		Preconditions.Steps.isPreconditionDone = false;
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
        	}
        	return true;        	
        }
    }
}