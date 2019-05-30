
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
using ADSAutomationPhaseIII.TC_10570;

namespace ADSAutomationPhaseIII.TC_10574.TC1
{
    
    [TestModule("A07BA2A7-EADF-4ED3-BDAA-AE0E92A77724", ModuleType.UserCode, 1)]
    public class CreateMultipleAbbreviations : BaseClass, ITestModule
    {
        
        public CreateMultipleAbbreviations()
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
        		
        		Steps.ClickExpandSymbol();
        		Steps.WriteCreateText();
        		Steps.ClickonCreateOption();
        		Steps.EnterCreateExpandedText();
        		Steps.SelectEnterinDropDown();
        		
        		Steps.ClickExpandSymbol();
        		Steps.WriteInsertText();
        		Steps.ClickonInsertOption();
        		Steps.EnterInsertExpandedText();
        		Steps.SelectTabinDropDown();
        		
        		Steps.ClickExpandSymbol();
        		Steps.WriteSelectText();
        		Steps.ClickonSelectOption();
        		Steps.EnterSelectExpandedText();
        		Steps.SelectSpaceinDropDown();
        		
        		Steps.OkayButton();
        		Steps.ConnectServer();
        		Steps.ProvideSelectAbbreviation("select");
        		Preconditions.Steps.CloseTab();
        		Steps.ClickOnDiscard();
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
