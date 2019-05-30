
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
using ADSAutomationPhaseIII.Preconditions;
using ADSAutomationPhaseIII.Extensions;
using ADSAutomationPhaseIII.Configuration;

namespace ADSAutomationPhaseIII.TC_10574.TC2
{
    
    [TestModule("AB99E018-F126-4FEB-855B-E991EDDDC22F", ModuleType.UserCode, 1)]
    public class RearrangingAndDeleting : BaseClass, ITestModule
    {
        
        public RearrangingAndDeleting()
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
        		Steps.ClickonFileMenu();
        		Steps.SelectOptions();
        		Steps.ExpandSQLEditor();
        		Steps.ClickAbbrevations();
        		Steps.ClickonInsertOption();
        		Steps.ClickonUPIcon();
        		Steps.ClickonCreateOption();
        		Steps.ClickonDownIcon();        		
        		Steps.OkayButton();
        		Steps.ClickonFileMenu();
        		Steps.SelectOptions();
        		Steps.ExpandSQLEditor();
        		Steps.ClickAbbrevations();
        		Steps.ClickonSelectOption();
        		Steps.ClickonRemoveIcon();
        		Steps.OkayButton();
        		Steps.ConnectServer();
        		Steps.ProvideSelectAbbreviation("select");
        		Preconditions.Steps.CloseTab();
        		Steps.ClickOnDiscard();
        		Steps.ClickonFileMenu();
        		Steps.SelectOptions();
        		Steps.ExpandSQLEditor();
        		Steps.ClickAbbrevations();
        		Steps.ClickonCreateOption();
        		Steps.ClickonRemoveIcon();
        		Steps.ClickonInsertOption();
        		Steps.ClickonRemoveIcon();
        		Steps.OkayButton();
        		Steps.ClickonFileMenu();
        		Steps.SelectOptions();
        		Steps.CollapseSQLEditor();
        		Steps.OkayButton();
        	} 
        	catch (Exception ex)
        	{
        		Steps.CloseOptionsWindow();
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
        	}
        	return true;
        }
    }
}
