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
using ADSAutomationPhaseII.TC_10593;

namespace ADSAutomationPhaseII.TC_10603.TC1
{
    [TestModule("752FD728-10B2-4AEF-B2D0-BCEBDEBB757A", ModuleType.UserCode, 1)]
    public class TrendLines : BaseClass, ITestModule
    {
    	public TrendLines(){}
        
        void ITestModule.Run()
        {
            StartProcess();
        }
        
        bool StartProcess()
        {
        	try
        	{
        		Steps.ClickOnFileAndOpenMenus();
        		Steps.EnterFilePathAndClickOpenButton();
        		Steps.MaximizeVisualAnalyticsWindow();
        		Steps.SelectEntireWindow();
        		Steps.ShowTrendLines();
        		Steps.EditTrendLines();
        		Steps.LinearModelType();
        		Steps.RecalcTrendlinesBasedonDtSelection();
        		Steps.BeginTrendatFirstDtPoint();
        		Steps.OkButton();
        		Steps.ValidateLinearModelType();
        		
        		Steps.DescribeTrendModel();
        		Steps.CloseTrendLineDetailsDialog();        		
        		Steps.EditTrendLines();
        		Steps.LogarithmicModelType();
        		Steps.RecalcTrendlinesBasedonDtSelection();
        		Steps.BeginTrendatFirstDtPoint();
        		Steps.OkButton();
        		Steps.ValidateLogarithmicModelType();       		
        		
        		Steps.EditTrendLines();
        		Steps.ExponentialModelType();
        		Steps.RecalcTrendlinesBasedonDtSelection();
        		Steps.BeginTrendatFirstDtPoint();
        		Steps.OkButton();
        		Steps.ValidateExponentialModelType();
        			
        		Steps.EditTrendLines();
        		Steps.PolynomialDegreeModelType("2");
        		Steps.RecalcTrendlinesBasedonDtSelection();
        		Steps.BeginTrendatFirstDtPoint();
        		Steps.OkButton();
        		Steps.ValidatePolynomialDegree2ModelType();
      		
        		Steps.EditTrendLines();
        		Steps.PolynomialDegreeModelType("3");
        		Steps.ShowConfidenceBands();
        		Steps.RecalcTrendlinesBasedonDtSelection();
        		Steps.BeginTrendatFirstDtPoint();
        		Steps.OkButton();
        		Steps.ValidateShowConfidenceBandsPolynomialDegree3ModelType();   
        		
        		Steps.EditTrendLines();
        		Steps.PolynomialDegreeModelType("3");
        		Steps.ForceYIntercepttoZero();
        		Steps.RecalcTrendlinesBasedonDtSelection();
        		Steps.BeginTrendatFirstDtPoint();
        		Steps.OkButton();
        		Steps.ValidateForceYInterceptPolynomialDegree3ModelType();   		
        		Steps.CloseVisualAnalyticsDailog();
        	}
        	catch(Exception e)
        	{
        		Reports.ReportLog(e.Message, Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
        		Steps.CloseTrendLineDetailsDialog();
        		Steps.CloseVisualAnalyticsDailog();
        	}
        	return true;
        }
        
    }
}
