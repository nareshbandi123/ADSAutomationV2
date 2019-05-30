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
using ADSAutomationPhaseII.TC_10593;

namespace ADSAutomationPhaseII.TC_10609.TC_10609_TC1
{
    
    [TestModule("16E526BD-47F0-4000-B461-7B6BFF37B1C6", ModuleType.UserCode, 1)]
    public class VisualAnalyticsFieldandParameters : BaseClass, ITestModule
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
				Steps.CreateParameter();
        		Steps.CreateParameterSetParam("parameter1", "sets the unit  cost in the profit calculation", "Integer");
        		Steps.DragCustomerNameToColumnsDeck();
        		Steps.DragProfitToRowsDeck();
        		Steps.DragParameterToRowsDeck();
        		Steps.EditParameter1SetParam("Integer", "12");
        		Steps.PasteDataSetParam();
        		Steps.ClickOnSaveButtEditParameter1Dailog();
        		Steps.DtTimeEditParameter1SetParam("Date Time");
        		Steps.VerifyTodayDate();
        		Steps.ClickonAnyOptionandSaveButton();
        		Steps.ShowParameterControl();
        		Steps.ChangedToDtTime();
        		Steps.DuplicateParameter();
        		Steps.RenameParameter("Parameter23");
        		Steps.Deleteparameter23();
        		Steps.CreateParameter();
        		Steps.CreateParameterSetParam("parameter1", "sets the unit  cost in the profit calculation", "Integer");
        		Steps.CreateCalculatedFieldParameter();
        		Steps.GiveCalSaveCreateCalculatedFieldDailog("calculation1");
        			
        		Steps.CloseVisualAnalyticsDailog();
        		TC_10602.Steps.DiscardButton();
        		TC_10556.Steps.DisConnectServer();
        	}
        	catch(Exception e)
        	{
        		Steps.CloseEditParameterDialog();
        		Steps.CloseVisualAnalyticsDailog();
        		TC_10602.Steps.DiscardButton();
        		TC_10556.Steps.DisConnectServer();
        		Reports.ReportLog(e.Message, Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
        	}        	
        	return true;
        }
        
        
    }
}
