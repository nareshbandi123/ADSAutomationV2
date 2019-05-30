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

namespace ADSAutomationPhaseII.TC_10608.TC6
{
    [TestModule("63FE20B8-E1A2-4A4A-B885-C71942F39C97", ModuleType.UserCode, 1)]
    public class Undo_And_Redo_6 : ITestModule
    {
     
        public Undo_And_Redo_6()
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
        		Steps.SelectNewDashboard();
        		Steps.AddWorksheet1ToDashboard();
        		Steps.AddWorksheet2ToDashboard();
        		Steps.RemoveFromDashboard();
        		Steps.EditTextHelloWorld();
        		Steps.SelectImage();
        		Steps.OpenImage();
        		Steps.RemoveImage();
        		Steps.ClickUndo();
        		Steps.ValidateUndo1Case6();
        		Steps.ClickUndo();
        		Steps.ValidateUndo2Case6();
        		Steps.ClickUndo();
        		Steps.ValidateUndo3Case6();
        		Steps.ClickUndo();
        		Steps.ValidateUndo4Case6();
        		Steps.ClickUndo();
        		Steps.ValidateUndo5Case6();
        		Steps.ClickUndo();
        		Steps.ClickRedo();
        		Steps.ClickRedo();
        		Steps.ClickRedo();
        		Steps.ClickRedo();
        		Steps.ClickRedo();
        		Steps.ClickRedo();
        		Steps.EditTextHiThere();
        		Steps.DeleteDashboard1();
        		Steps.ClickUndo();
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
