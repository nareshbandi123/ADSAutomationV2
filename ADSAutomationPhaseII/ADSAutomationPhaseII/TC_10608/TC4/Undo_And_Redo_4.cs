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

namespace ADSAutomationPhaseII.TC_10608.TC4
{
    [TestModule("05BCCBF8-4F71-408E-B3BB-57B4A3DB281D", ModuleType.UserCode, 1)]
    public class Undo_And_Redo_4 : ITestModule
    {
        public Undo_And_Redo_4()
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
        		Steps.NavigateToWorksheet4();
        		Steps.SelectDimension();
        		Steps.SelectMeasure();
        		Steps.ClickUndo();
        		Steps.ValidateUndo1Case4();
        		Steps.ClickUndo();
        		Steps.ValidateUndo2Case4();
        		Steps.SelectAttribute();
        		Steps.ClickUndo();
        		Steps.ValidateUndo3Case4();
        		Steps.ConvertToDimension();
        		Steps.DragDiscountToColumn();
        		Steps.ClickUndo();
        		Steps.ValidateUndo4Case4();
        		Steps.ClickUndo();
        		Steps.ValidateUndo5Case4();
        		Steps.DragShipDateToColumn();
        		Steps.SelectCountryFromGeoRole();
        		Steps.ClickUndo();
        		Steps.ValidateUndo6Case4();
        		Steps.CreateCalculatedField();
        		Steps.CreateCalculate1Field();
        		Steps.DragCalculation1ToColumn();
        		Steps.EditCalculation1();
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
