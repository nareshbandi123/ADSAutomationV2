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
using ADSAutomationPhaseII.TC_10589;
using ADSAutomationPhaseII.TC_10599;

namespace ADSAutomationPhaseII.TC_10608.TC5
{
    [TestModule("280418A5-409A-46E0-9DFC-447639C997BD", ModuleType.UserCode, 1)]
    public class Undo_and_Redo_5 : ITestModule
    {
        public Undo_and_Redo_5()
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
        		TC_10589.Steps.ClickOnFileMenu();
        		TC_10589.Steps.ClickOnOpenMenu();
        		Steps.EnterFilePath();
        		TC_10589.Steps.ClickOnOpenButton();
        		TC_10599.Steps.Maximize();
        		Steps.NavigateToWorksheet5();
        		Steps.SelectShipModeAndRegion();
        		Steps.SelectCreateCombinedRegion();
        		Steps.ChangeName();
        		Steps.ClickOnSave();
        		Steps.DragCombined1ToColumn();
        		Steps.EditSeparator();
        		Steps.DeleteCombined();
        		Steps.ClickUndo();
        		Steps.ValidateUndo1Case5();
        		Steps.ClickUndo();
        		Steps.ValidateUndo2Case5();
        		Steps.ClickUndo();
        		Steps.ValidateUndo3Case5();
        		Steps.ClickUndo();
        		Steps.ValidateUndo4Case5();
        		Steps.SelectCreateBin();
        		Steps.SelectNumberOfBins();
        		Steps.ClickCreateBinOk();
        		Steps.DragSalesBinToColumn();
        		Steps.EditNumberOfCreateBins();
        		Steps.DeleteSalesBin();
        		Steps.ClickUndo();
        		Steps.ValidateUndo5Case5();
        		Steps.ClickUndo();
        		Steps.ValidateUndo6Case5();
        		Steps.ClickUndo();
        		Steps.ValidateUndo7Case5();
        		TC_10599.Steps.CloseViz();
        		TC_10589.Steps.ClickOnDiscard();
        	}
        	catch(Exception e)
        	{
        		Steps.CloseOnOpenFileError();
        		Steps.CloseOnVisualAnalyticsError();
        		Reports.ReportLog(e.Message, Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
        	}
        	
        	return true;        	
        }
    }
}
