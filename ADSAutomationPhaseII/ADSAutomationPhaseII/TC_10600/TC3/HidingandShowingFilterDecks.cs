
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

namespace ADSAutomationPhaseII.TC_10600.TC3
{
   
    [TestModule("4F2300A8-FB0A-4CF2-A7DB-69B3A722C36D", ModuleType.UserCode, 1)]
    public class HidingandShowingFilterDecks : BaseClass, ITestModule
    {
        
        public HidingandShowingFilterDecks()
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
        		Steps.DragPCtoColumn1();
        		Steps.ValidateAfterDragPCtoColumn();
        		Steps.DragProfittoRow();
        		Steps.ValidateAfterDragProfittoRow();
        		Steps.DragProfitToFilterDeck();
        		Steps.DecreaseProfitValue();
        		Steps.ValidateAfterDecreaseProfitValue();
        		Steps.IncreaseProfitValue();
        		Steps.ValidateAfterIncreaseProfitValue();
        		Steps.ClickonTriangleIconProfit();
        		Steps.ClickonAtleast();
        		Steps.IncreaseAtleastValue();
        		Steps.ValidateIncreaseAtleastValue();
        		Steps.ClickonTriangleIconProfit();
        		Steps.ClickonAtMost();
        		Steps.DecreaseAtmostValue1();
        		Steps.ValidateDecreaseAtmostValue();
        		Steps.ClickonTriangleIconProfit();
        		Steps.ClickonHideDeck();
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
