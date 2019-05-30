
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

namespace ADSAutomationPhaseII.TC_10602.TC2
{
    
    [TestModule("3611D813-A482-4BBE-A5D6-08EFB7F7A481", ModuleType.UserCode, 1)]
    public class SelectAChartColor : ITestModule
    {
        
        public SelectAChartColor()
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
        		Steps.ClickonWorkSheet();
        		Steps.CreateNewWorkSheet();
        		Steps.SelectEntireWindow1();
        		Steps.DragCardTypetoColumn();
        		Steps.ValidateAfterDragCardtypetoColumn();
        		Steps.DragProfittoRow();
        		Steps.ValidateAfterDragProfittoRow();
        		Steps.ClickonColorDeck();
        		Steps.SelectNewColor(); 
        		Steps.ValidateNewColorChart();
        		TC_10556.Steps.ClickCloseVA();
        		TC_10602.Steps.DiscardButton();
        	} 
        	catch (Exception ex)
        	{
        		TC_10556.Steps.ClickCloseVA();
        		TC_10602.Steps.DiscardButton();
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
        	}
        	return true;
        }
    }
}
