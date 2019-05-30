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
using ADSAutomationPhaseII.TC_10590;

namespace ADSAutomationPhaseII.TC_10599.TC1
{
    [TestModule("690BC87B-97DF-416F-BE13-810AD0D32749", ModuleType.UserCode, 1)]
    public class RowColumn_levelsorting : ITestModule
    {
        public RowColumn_levelsorting()
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
        		TC_10590.Steps.ClickonOpen();
        		Steps.EnterFilePath();
        		TC_10589.Steps.ClickOnOpenButton();
        		Steps.Maximize();
        		Steps.SortEast();
        		Steps.ValidateEastDescendingChart();
				Steps.SortEast();
				Steps.ValidateEastAscendingChart();
				Steps.SortEast();
				Steps.ValidateEastDefaultChart();
				Steps.SortBookCasesVeritical();
				Steps.ValidateBookCasesDescending();
				Steps.SortBookCasesVeritical();
				Steps.ValidateBookCasesAscending();
				Steps.SortBookCasesVeritical();
				Steps.ValidateBookCasesDefault();
        		Steps.CloseViz();
        		TC_10589.Steps.ClickOnDiscard();
        	}
        	catch(Exception e)
        	{
        		Steps.CloseOnOpenFileError();
        		Steps.CloseOnVisualAnalyticsError();
        		TC_10589.Steps.ClickOnDiscard();
        		Reports.ReportLog(e.Message, Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
        	}
        	
        	return true;        	
        }

    }
}
