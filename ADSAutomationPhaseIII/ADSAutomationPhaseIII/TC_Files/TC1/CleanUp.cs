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
    [TestModule("2A3DCA17-9154-4654-916C-42EE8673EC47", ModuleType.UserCode, 1)]
    public class CleanUp : BaseClass, ITestModule
    {
    	public static string TC_Files_PATH = System.Configuration.ConfigurationManager.AppSettings["TC_Files_Path"].ToString();
        public CleanUp()
        {
           
        }
 		void ITestModule.Run()
        {
        	if(Preconditions.Steps.isPreconditionDone)
            	StarProcess();
        }

 		bool StarProcess()
        {
        	try 
        	{
        		Preconditions.Steps.CloseTab();
        		TreeItem server = Preconditions.Steps.GetServerTreeFromTCName(Config.TestCaseName);
        		Preconditions.Steps.SelectedServerTreeItem = server;
        		Preconditions.Steps.SelectedServerName = server.Text;
        		Common.DeleteFile(TC_Files_PATH + "ADS.sql");
        		Common.DeleteFile(TC_Files_PATH + "ADS_Results.sql");
        		Common.DeleteFile(TC_Files_PATH + "Test.sql");
        		server.RightClick();
        		Preconditions.Steps.DisconnectServer();
        		Preconditions.Steps.QueryAnalyser();
        		if(Config.SchemaServers.Contains(server.Text))
        			Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB_CAPS);
    			else
    				Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
        		Preconditions.Steps.DropTable();
        		Preconditions.Steps.CloseTab(server.Text);
        		Preconditions.Steps.QueryAnalyser();
        		Preconditions.Steps.DropDatabase();
        		Preconditions.Steps.CloseTab(server.Text);
        		Preconditions.Steps.isPreconditionDone = false;
        	} 
        	catch (Exception ex) 
        	{
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
        	}
        	return true;
         }
    }
        
}
