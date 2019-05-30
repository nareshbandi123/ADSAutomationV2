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

namespace ADSAutomationPhaseII.TC_10608.TC7
{
    [TestModule("BEAB8278-8FF8-4AB4-BE2F-3BF83FF5F974", ModuleType.UserCode, 1)]
    public class Undo_And_Redo_7 : ITestModule
    {
        public Undo_And_Redo_7()
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
        		Steps.ShowTrendLines();
        		Steps.EditTrendLines();
        		Steps.AddReference();
        		Steps.EditReference();
        		Steps.RemoveReference();
        		Steps.ClickUndo();
        		Steps.ValidateUndo1Case7();
        		Steps.ClickUndo();
        		Steps.ValidateUndo2Case7();
        		Steps.ClickUndo();
        		Steps.ValidateUndo3Case7();
        		Steps.ClickRedo();
        		Steps.ValidateRedo1Case7();
        		Steps.ClickRedo();
        		Steps.ValidateRedo2Case7();
        		Steps.ClickRedo();
        		Steps.ValidateRedo3Case7();
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
