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
using ADSAutomationV1Phase1Part1.TC_10536;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace ADSAutomationPhaseII.TC_10536.TC2
{
    [TestModule("EC9C3FEF-EE4B-4DD2-926E-57259DB0B86E", ModuleType.UserCode, 1)]
    public class Cassandra : BaseClass, ITestModule
    {
    	public static TC10536Repo repo = TC10536Repo.Instance;
        public Cassandra()
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
        		Steps.ClickOnTools();
				Steps.SelectCompareTools();
				Steps.SelectSchemaCompare();
								
        		Steps.ClickOnLeftChooseServer();
        		Steps.SelectADSDb1();
        		Steps.ClickOkButton();
        		
				Steps.ClickOnRightChooseServer();
				Steps.SelectADSDb();
				Steps.ClickOkButton();
				
				Steps.SetSchema();
				Steps.UnselectSchemaObjects();
				Steps.SelectSchemaTable();
				Steps.UnselectLeftObjects();
				Steps.SelectLeftTable();
				Steps.UnselectRightObjects();
				Steps.SelectRightTable();
				
				Steps.ClickOnCompareButton();
				Steps.ClickOnTable();
				
				Steps.ClickOnSpreadSheetIcon();
				Steps.ClickOnCloseButton();
				
				Preconditions.Steps.CloseTab();
        	}
        	catch (Exception ex)
        	{
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
        	}
        
        	return true;
        }


    }
}