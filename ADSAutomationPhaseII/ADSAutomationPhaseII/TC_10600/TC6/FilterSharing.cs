
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
using ADSAutomationPhaseII.TC_10593;
using ADSAutomationPhaseII.TC_10602;
using ADSAutomationPhaseII.TC_10590;

namespace ADSAutomationPhaseII.TC_10600.TC6
{
    
    [TestModule("F638E0D0-ADD1-428B-AC1C-42AE92BA760B", ModuleType.UserCode, 1)]
    public class FilterSharing : BaseClass, ITestModule
    {
        
        public FilterSharing()
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
        		Steps.DragProductCategorytoFilterDeck();
        		Steps.ClickonPC();
        		Steps.SelectWorkSheets();
        		Steps.CLickonSelectedWorkSheets();
        		Steps.CheckAllWorksheets();
        		Steps.ClickonShare();
        		Steps.ClickonTriangleIconPC1();
        		Steps.SelectShowApplyOption();
        		Steps.UncheckAll();
        		Steps.CheckBibShorts();
        		Steps.CheckBrakes();
        		Steps.ClickonApply();
        		Steps.ClickonWorkSheet1();
        		Steps.ValidateWorkSheet1Options();
        		TC_10602.Steps.ClickonWorkSheet2();
        		Steps.ValidateWorkSheet2Options();
        		TC_10602.Steps.ClickonWorkSheet4();
        		Steps.ValidateWorkSheet4Options();
        		Steps.ClickonUndo();
        		Steps.ClickonWorkSheet1();
        		Steps.ValidateWorkSheet1Undo();
        		TC_10602.Steps.ClickonWorkSheet2();
        		Steps.ValidateWorkSheet2Undo();
        		TC_10602.Steps.ClickonWorkSheet4();
        		Steps.ValidateWorkSheet4Undo();
        		Steps.ClickonRedo();
        		Steps.ClickonWorkSheet1();
        		TC_10602.Steps.ClickonWorkSheet2();
        		TC_10602.Steps.ClickonWorkSheet4();
        		Steps.ClickonWorkSheet1();
        		Steps.ClickonTriangleIconPC1();
        		Steps.SelectSingleValueDropDown();
        		Steps.ClickonAllTriangleWindow();
        		Steps.SelectBrakesOption();
        		Steps.ValidateWorkSheet1BrakesOption();
        		TC_10602.Steps.ClickonWorkSheet2();
        		Steps.ValidateWorkSheet2BrakesOption();
        		TC_10602.Steps.ClickonWorkSheet4();
        		Steps.ValidateWorkSheet4BrakesOption();
        		Steps.ClickonPC4();
        		Steps.SelectWorkSheets();
        		Steps.ClickonNotSharedOption();
        		TC_10602.Steps.ClickonWorkSheet3();
        		Steps.ClickonTriangleIconPC1();
        		Steps.SelectMultipleValues();
        		Steps.UncheckAll();
        		Steps.ClickonApply();
        		TC_10602.Steps.ClickonWorkSheet2();
        		Steps.ValidateWorkSheet2AfterCheckAll();
        		TC_10602.Steps.ClickonWorkSheet4();
        		Steps.ValidateWorkSheet4AfterCheckAll();
        		Steps.ClickonPC4();
        		Steps.SelectWorkSheets();
        		Steps.SelectAllDataSource();
        		Steps.ClickonPC4();
        		Steps.RemoveSharedWorkSheet();
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
