using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

using WinForms = System.Windows.Forms;
using ADSAutomationPhaseII.Base;
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Configuration;
using ADSAutomationPhaseII.Preconditions;
using ADSAutomationV1Phase1Part1.TC_10536;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace ADSAutomationPhaseII.TC_10536.TC3
{
    [TestModule("3CDC2BA3-0786-4DB1-8D54-57B73F8C8696", ModuleType.UserCode, 1)]
    public class Cassandra : BaseClass, ITestModule
    {
    	public static TC10536Repo repo = TC10536Repo.Instance;
        public Cassandra()
        {
            
        }
        
     	void ITestModule.Run()
        {
        	if(Preconditions.Steps.isPreconditionDone)
	        	StartProcess();
        }
        
        bool StartProcess()
        {
        	try 
        	{  
        		Preconditions.Steps.QueryAnalyserTab();
        		Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
        		Preconditions.Steps.SelectTable_ShortcutKey();
        		
        		Preconditions.Steps.QueryAnalyserTab();
        		Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB1, true);
        		Preconditions.Steps.SelectSecondTable_ShortcutKey();
        		
        		Steps.ClickOnTools();
				Steps.SelectCompareTools();
				Steps.SelectResultCompare();
				
				Steps.ClickOnResultTab();
				Steps.ClickOnResultSet1();
				Steps.ClickOnResultSet2();
				Steps.ClickOnOkButton();
				Steps.CompareResult();
				Steps.ClickOnRefresh();
				Steps.ClickOnResultTab();
				Steps.ClickOnResultListSet1();
				Steps.ClickOnResultListSet2();
				Steps.ClickOnOkButton();
				Steps.CompareResult();
				Steps.Save();
				Steps.Browse();				
				Steps.EnterFileName();
				Steps.SaveHtml();
				Steps.ClickOnOk();
				Steps.Navigate();
				Steps.ClickOnSpreadSheet();
				Steps.ResultCompareFilters();			
        	}        	
        	catch (Exception ex)
        	{
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
        	}
        
        	return true;
        }

    }
}
