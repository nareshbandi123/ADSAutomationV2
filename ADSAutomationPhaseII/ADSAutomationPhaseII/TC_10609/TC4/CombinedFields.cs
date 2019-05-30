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

namespace ADSAutomationPhaseII.TC_10609.TC_10609_TC4
{
    
    [TestModule("A9F4FE56-A9A8-48D9-96C7-65A888FD6060", ModuleType.UserCode, 1)]
    public class CombinedFields : BaseClass, ITestModule
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
        		Steps.CombineProductCategoryAndShipMethod();
        		Steps.SaveCreateConbinedFieldDialog();
        		Steps.EditProductCategoryShipMethodCombined();
        		Steps.DragProductCategoryShipMethodCombinedToColumnsDeck();
        		Steps.DragTotalDueToRowsDeck();
        		Steps.SelectEntireWindow();
        		Steps.ValidateProductCategoryShipMethodCombined();
        		Steps.DuplicateProductCategoryShipMethodCombined();
        		Steps.RenameDuplicateCombined("Product category &  ship method (combined)23");
        		Steps.DragFreightToRowsDeck();
        		Steps.DeleteDuplicateCombined();
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
