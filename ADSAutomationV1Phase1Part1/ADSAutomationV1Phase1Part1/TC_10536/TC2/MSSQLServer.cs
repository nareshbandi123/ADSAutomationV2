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

namespace ADSAutomationPhaseII.TC_10536.TC2
{
    [TestModule("9BE5B820-2E8A-4C25-83AC-A6B842984801", ModuleType.UserCode, 1)]
    public class MSSQLServer : BaseClass, ITestModule
    {
        public MSSQLServer()
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
				Steps.ScanForTables();
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