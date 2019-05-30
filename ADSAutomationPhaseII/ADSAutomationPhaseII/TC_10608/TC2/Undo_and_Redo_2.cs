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

namespace ADSAutomationPhaseII.TC_10608.TC2
{
    [TestModule("15A7863D-F630-4CEE-9CA3-7508773C0588", ModuleType.UserCode, 1)]
    public class Undo_and_Redo_2 : ITestModule
    {
        public Undo_and_Redo_2()
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
        		Steps.NavigateToWorksheet2();
        		Steps.SortEast();
        		Steps.KeepOnly();
        		Steps.ClickUndo();
        		Steps.ValidateUndo1Case2();
        		Steps.ClickUndo();
        		Steps.ValidateUndo2Case2();
        		Steps.ClickRedo();
        		Steps.ValidateRedo1Case2();
        		Steps.ClickRedo();
        		Steps.ValidateRedo2Case2();
        		Steps.RemoveRegion();
        		Steps.ClickUndo();
        		Steps.ValidateUndo3Case2();
        		Steps.ClickRedo();
        		Steps.ValidalidateRedo3Case2();
        		Steps.RemoveProductCategory();
        		Steps.RemoveRegionFromColumn();
        		Steps.SelectShapeChart();
        		Steps.DragStateOrProvinceToGeo();
        		Steps.SelectSolidCircle();
        		Steps.SlideTo50Percent();
        		Steps.UnCheckShowStateBorders();
        		Steps.SelectColor();
        		Steps.SelectBorder();
        		Steps.SelectHalo();
        		Steps.SetOpacityTo70Percent();
        		Steps.SelectShowDataLabels();
        		Steps.SelectAllowOverlap();
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
