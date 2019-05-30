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

using ADSAutomationPhaseII.Configuration;
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.TC_10556;
using ADSAutomationPhaseII.TC_10602;

namespace ADSAutomationPhaseII.TC_10597
{    
    [TestModule("C0B9D862-20D7-4558-B320-6B5539BB3850", ModuleType.UserCode, 1)]
    public class VisualAnalytics_PriceChart : Base.BaseClass, ITestModule
    {
        public VisualAnalytics_PriceChart()
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
        		TC_10556.Steps.IsServerRegistered();
		  		Steps.ConnectServerstock();
        		Steps.ClickQARun();
        		TC_10556.Steps.ClickNewVA();
        		Steps.WaitForVAExists();
        		Steps.DragStockDateToColumn();
        		Steps.DragStockCloseToRow();
        		Steps.SetStockCloseToLeft();
        		Steps.SelectPrice();
        		Steps.DragStockHighToHigh();
        		Steps.DragStockLowToLow();
        		Steps.DragStockSymbolToFilters();
        		Steps.UnselectAll();
        		Steps.SelectAPPL();
        		Steps.ValidateBeforeStockOpen();
        		Steps.DragStockOpenToOpen();
        		Steps.ValidateAfterStockOpen();
        		Steps.EditAxis();
        		Steps.CloseVA();
        		TC_10602.Steps.DiscardButton();
        		TC_10556.Steps.DisConnectServer();
        	}
        	catch(Exception e)
        	{
        		Steps.CloseVA();
        		TC_10556.Steps.ClickCloseTab();
        		Reports.ReportLog(e.Message, Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
        	}
        	
        	return true;
        }
    }
}
