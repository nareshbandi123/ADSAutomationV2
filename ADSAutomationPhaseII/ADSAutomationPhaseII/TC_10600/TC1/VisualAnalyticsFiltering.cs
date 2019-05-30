
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
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Configuration;
using ADSAutomationPhaseII.TC_10556;
using ADSAutomationPhaseII.TC_10602;

namespace ADSAutomationPhaseII.TC_10600.TC1
{
    
    [TestModule("C2E6D516-CDBF-465C-B1EF-26BC4B6BF8B2", ModuleType.UserCode, 1)]
    public class VisualAnalyticsFiltering : BaseClass, ITestModule
    {
        
        public VisualAnalyticsFiltering()
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
		  		TC_10556.Steps.ConnectServer();
        		TC_10556.Steps.ClickQARun();
        		TC_10556.Steps.ClickNewVA();
        		Steps.SelectEntireWindow();
        		Steps.DragPCtoColumn();
        		Steps.ValidateAfterDragPCtoColumn();
        		Steps.DragPCtoRow();
        		Steps.ValidateAfterDragPCtoRow();
        		Steps.DragCurrencycodetoFilters();
        		Steps.ValidateAfterDragCurrencycodetoFilterDeck();
        		Steps.ClickonUncheckAll();
        		Steps.ValidateAfterUncheckAll();
        		Steps.GBPOption();
        		Steps.ValidateAfterClickGBPCurrency();
        		Steps.SelectAvailableCurrencyCodes();
        		Steps.ClickonTrinagleIcon();
        		Steps.ClickonTopNWindow();
        		Steps.ClickonFieldOption();
        		Steps.SelectTopandBottom();
        		Steps.SelectEnterValues();
        		Steps.ClickonOkButton();
        		Steps.ValidateTOPNWindowOptions();
        		TC_10556.Steps.ClickCloseVA();
        		TC_10602.Steps.DiscardButton();
        		TC_10556.Steps.DisConnectServer();
        	} 
        	catch (Exception ex)
        	{
        		TC_10556.Steps.ClickCloseVA();
        		TC_10602.Steps.DiscardButton();
        		TC_10556.Steps.DisConnectServer();
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
        	}
        	return true;
        }
    }
}
