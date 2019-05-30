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
using ADSAutomationPhaseII.Base;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Preconditions;
using ADSAutomationPhaseII.Configuration;
using ADSAutomationPhaseII.TC_10556;
using ADSAutomationPhaseII.TC_10602;

namespace ADSAutomationPhaseII.TC_10609.TC_10609_TC2
{
    
    [TestModule("680B5891-8FA0-4FAF-BC44-D6559EA01FEC", ModuleType.UserCode, 1)]
    public class CalculatedFields :BaseClass, ITestModule
    {
        void ITestModule.Run()
        {
            StartProcess();        	
        }
        
        bool StartProcess()
        {
        	try
        	{
				TC_10556.Steps.IsServerRegistered();
		  		TC_10556.Steps.ConnectServer();
        		TC_10556.Steps.ClickQARun();
        		TC_10556.Steps.ClickNewVA();

        		Steps.CreateNewWorksheet();
        		Steps.CreateCalculatedfield();
        		Steps.SelectAggregateFun();
        		Steps.DoubleClickSUM();
        		Steps.DoubleClickFreight();
        		Steps.DoubleClickSave();
        		Steps.DragCustomerNameToColumnsDeck();
        		Steps.DragProfitToRowsDeck();
        		Steps.DragAggCalculator1ToRowsDeck();
        		Steps.SelectEntireWindow();
        		Steps.ValidateCalc1Drag();
        		Steps.AggCalculator1AndEdit();
        		Steps.SelectAggregateFunEditCalcFieldDialog();
        		Steps.DoubleClickCOUNTD();
        		Steps.DoubleClickCardType();
        		Steps.DoubleClickSaveEditCalcFieldDialog();
				Steps.RenameAggCalculator1("Calculation2");
        		Steps.VerifyRenamedCalculator("Calculation2");
        		Steps.DragFreightToRowsDeck();
        		Steps.PeformVariousActions();
        		Steps.FindIcon();
        		Steps.ReplaceIcon();
        		Steps.CloseEditCalculatedFieldDialog();
				Steps.CloseVisualAnalyticsDailog();
        		TC_10602.Steps.DiscardButton();
        		TC_10556.Steps.DisConnectServer();       		
        	}
        	catch(Exception e)
        	{
        		Steps.CloseVisualAnalyticsDailog();
        		TC_10602.Steps.DiscardButton();
        		TC_10556.Steps.DisConnectServer();
        		Reports.ReportLog(e.Message, Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
        	}        	
        	return true;
        }
        
    }
}
