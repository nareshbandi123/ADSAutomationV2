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
using ADSAutomationPhaseIII.Base;
using ADSAutomationPhaseIII.Commons;
using ADSAutomationPhaseIII.Configuration;
using ADSAutomationPhaseIII.Extensions;
using ADSAutomationPhaseIII.Preconditions;

namespace ADSAutomationPhaseIII.TC_Files.TC1
{
    [TestModule("28E4C5F2-3BC3-4A85-98CB-8FFAA6D42532", ModuleType.UserCode, 1)]
    public class AmazonRedshift : BaseClass, ITestModule
    {
       
        public AmazonRedshift()
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
        		Preconditions.Steps.QueryAnalyser();
        		Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
        		Preconditions.Steps.SelectTable();
        		Steps.SaveQuery();
        		Steps.EnterFileSaveText();
        		Steps.SaveQueryFile();
        		Steps.ClickOnFileMenu();
        		Steps.SelectSaveResult();
        		Steps.Browse();
        		Steps.SaveResult();
        		Steps.ClickOnSelect();
        		Steps.SaveToFile();
        		Preconditions.Steps.CloseTab();
        		Steps.ClickOnFileMenu();
        		Steps.OpenRecent();
        		Steps.OpenRecentADSFile();
        		Preconditions.Steps.CloseTab();
        		Preconditions.Steps.QueryAnalyser();
        		Steps.ClickOnFileMenu();
        		Steps.OpenInCurrentWindow();
        		Steps.EnterADSFilePath();
        		Steps.OpenADSFile();
        		System.Threading.Thread.Sleep(3000);
        		Steps.EditADS();
        		Steps.Execute();
        		System.Threading.Thread.Sleep(3000);
        		Steps.ClickOnFileMenu();
        		Steps.NewCurrentWindow();
        		Steps.CancelButton();
        		Steps.ClickOnFileMenu();
        		Steps.SaveAs();
        		Steps.EnterSaveFilePath();
        		Steps.ClickOnSave();
        	}
        	catch(Exception e)
        	{
        		Reports.ReportLog(e.Message, Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
        	}
        	
        	return true;        	
        }     
    }
}
