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
namespace ADSAutomationPhaseII.TC_10608.TC3
{
    [TestModule("5B881C28-DF3F-4150-8798-441AC93F0EB8", ModuleType.UserCode, 1)]
    public class Undo_And_Redo_3 : ITestModule
    {
        public Undo_And_Redo_3()
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
        		Steps.NavigateToWorksheet3();
        		Steps.SelectTreeMap();
        		Steps.ChooseColorTheme();
        		Steps.SteppedColorAndReversed();
        		Steps.SelectOrangeForMaximum();
        		Steps.SetMinimumValue();
        		Steps.SetCentreValue();
        		Steps.SetMaximumValue();
        		Steps.ClickEditOk();
        		Steps.ResetEdit();
        		Steps.ClickUndo();
        		Steps.ValidateUndo1Case3();
        		Steps.ClickUndo();
        		Steps.ValidateUndo2Case3();
        		Steps.SelectAbsoluteOption();
        		Steps.SelectShowMeasureValues();
        		Steps.ClickUndo();
        		Steps.ValidateUndo3Case3();
        		Steps.ClickUndo();
        		Steps.ValidateUndo4Case3();
        		Steps.ClickUndo();
        		Steps.ValidateUndo5Case3();
        		Steps.ClickRedo();
        		Steps.ValidateRedo1Case3();
        		Steps.ClickRedo();
        		Steps.ValidateRedo2Case3();
        		Steps.ClickRedo();
        		Steps.ValidateRedo3Case3();
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
