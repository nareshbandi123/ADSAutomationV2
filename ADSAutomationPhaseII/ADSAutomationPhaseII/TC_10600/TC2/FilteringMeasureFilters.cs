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

namespace ADSAutomationPhaseII.TC_10600.TC2
{
   
    [TestModule("D6C630EA-99FF-4E50-B16D-525232E60F37", ModuleType.UserCode, 1)]
    public class FilteringMeasureFilters : BaseClass, ITestModule
    {
       
        public FilteringMeasureFilters()
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
        		Steps.ValidateAfterDragPCtoColumn();
        		Steps.DragProfitToFilterDeck();
        		Steps.ValidateAfterDragProfittoFilterDeck();
        		Steps.DecreasetheSUMValue();
        		Steps.IncreasetheSUMValue();
        		Steps.ClickonTriangleIcon();
        		Steps.ClickonAtleast();
        		Steps.InceaseAtleastValue();
        		Steps.ValidateAfterIncreaseAtleastOption();
        		Steps.ClickonTriangleIcon();
        		Steps.ClickonAtMost();
        		Steps.DecreaseAtmostValue();
        		Steps.ValidateAfterDecreaseAtmostOption();
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
