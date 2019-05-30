
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
using ADSAutomationPhaseII.TC_10590;

namespace ADSAutomationPhaseII.TC_10600.TC4
{
   
    [TestModule("001C751E-E714-4AF2-839D-9FBEDE3FC978", ModuleType.UserCode, 1)]
    public class FilteringDatefilters : BaseClass, ITestModule
    {
        
        public FilteringDatefilters()
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
        		TC_10590.Steps.ClickonFileMenu();
        		TC_10590.Steps.ClickonOpen();
        		Steps.SelectNewFile();
        		TC_10602.Steps.ClickonOpenButton();
        		TC_10602.Steps.SelectEntireWindow();
        		Steps.ValidateTestFilteringData();
        		TC_10602.Steps.ClickonWorkSheet3();
        		TC_10602.Steps.SelectEntireWindow();
        		Steps.ValidateWorkSheet3forFilter();
        		Steps.ClickonShipDate();
        		Steps.SelectFormat();
        		Steps.ClickonAutomatic();
        		Steps.ClickonOkayButton();
        		Steps.DecreaseDateFilter();
        		Steps.IncreaseDateFilter();
        		Steps.ClickonShipDate();
        		Steps.SelectFormat();
        		Steps.ClickonStandardDate();
        		Steps.ClickonOkayButton();
        		Steps.IncreaseLongDateValue();
        		Steps.DecreaseLongDateValue();
        		Steps.ClickonShipDate();
        		Steps.CLickon2004Option();
        		Steps.UncheckAlloption();
        		Steps.Checkon2004();
        		Steps.UnCheckon2004();
        		Steps.Check2006();
        		Steps.ClickonFile();
        		Steps.ClickonReverttoSave();
        		Steps.ClickOnRevertOption();
        		TC_10602.Steps.SelectEntireWindow();
        		Steps.RightClickonShipDate();
        		Steps.RemoveShipdate();
        		Steps.DragShipdatetoFilterDeck();
        		Steps.SelectRelativeDateOption();
        		Steps.MaximizetheWindow();
        		Steps.ClickOnThisYearIcon();
        		Steps.Select2006Year();
        		Steps.ClickOnThisYearIcon();
        		Steps.ValidateAfterSelec2006();
        		Steps.ClickOnThisYearIcon();
        		Steps.SelectNextTwoYears();
        		Steps.ClickOnThisYearIcon();
        		Steps.ValidateNextTwoYears();
        		Steps.ClickOnThisYearIcon();
        		Steps.Select2004Year();
        		Steps.ClickOnThisYearIcon();
        		Steps.ValidateSelect2004();
        		Steps.ClickOnThisYearIcon();
        		Steps.SelectLastTwoYears();
        		Steps.ClickOnThisYearIcon();
                Steps.ValidateLastTwoYears();        		
        		TC_10556.Steps.ClickCloseVA();
        	} 
        	catch (Exception ex)
        	{
        		TC_10556.Steps.ClickCloseVA();
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
        	}
        	return true;
        }
    }
}
