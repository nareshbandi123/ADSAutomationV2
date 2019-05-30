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

namespace ADSAutomationPhaseII.TC_10599.TC7
{
    [TestModule("9A991BEB-1BA8-4B19-8668-524B53E1CDA2", ModuleType.UserCode, 1)]
    public class Toolbar_Sorting : ITestModule
    {
    	public static TC10589 TC10589Repo = TC10589.Instance;
        public Toolbar_Sorting()
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
        		Steps.Maximize();
        		Steps.RemoveProductCategoryFromColumn();
        		Steps.SortSumSalesInAscendingOrder();
        		Steps.ValidateAscendingChart();
        		Steps.SortSumSalesInDescendingOrder();
        		Steps.ValidateDescendingChart();
        		Steps.NavigateToWorksheet2();
        		Steps.SortSumSalesInAscendingOrder();
        		Steps.NavigateToWorksheet4();
        		Steps.SortSumSalesInAscendingOrder();
        		Steps.ValidateAscendingWorksheet4Chart();
        		Steps.ClearSorts();
        		Steps.SelectPie();
        		Steps.DragProductCategoryToColor();
        		Steps.SortSumSalesInAscendingOrder();
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
