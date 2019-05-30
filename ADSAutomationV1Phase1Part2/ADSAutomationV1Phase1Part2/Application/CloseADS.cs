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
using ADSAutomationPhaseII.Extensions;
using ADSAutomationV1Phase1Part2.Application;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace ADSAutomationPhaseII.Application
{
    [TestModule("B86A4AEA-FF83-41CC-847D-0BD60C60F495", ModuleType.UserCode, 1)]
    public class CloseADS : BaseClass,  ITestModule
    {
    	AppRepo repo = AppRepo.Instance;
    	
        public CloseADS()
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
        		Ranorex.Host.Local.CloseADSApp();
        		
        		if(repo.ConfirmWindow.ConfirmExitButtonInfo.Exists(5000))
        			repo.ConfirmWindow.ConfirmExitButton.ClickThis();
        		
        		repo.Application.SelfInfo.WaitForNotExists(30000);
        		
        		Reports.ReportLog("ADS Application Close", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
        		
//        		if(repo.Application.SelfInfo.Exists(Commons.Common.ApplicationOpenWaitTime))
//        		{
//	        		repo.Application.CloseButton.ClickThis();
//	        		if(repo.ConfirmWindow.ConfirmExitButtonInfo.Exists(Commons.Common.ApplicationOpenWaitTime))
//	        			repo.ConfirmWindow.ConfirmExitButton.ClickThis();
//	        		repo.Application.SelfInfo.WaitForNotExists(Commons.Common.ApplicationOpenWaitTime);
//	        		
//	        		Reports.ReportLog("ADS Application Close", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
//        		}
        	} 
        	catch (Exception ex) 
        	{
        		Ranorex.Host.Local.ForceCloseADSApp();
        		Reports.ReportLog(ex.Message.ToString(), Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
        	}
        	return true;
        }
    }
}
