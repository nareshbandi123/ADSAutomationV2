using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

using WinForms = System.Windows.Forms;
using ADSAutomationPhaseIII.Commons;
using ADSAutomationPhaseIII.Configuration;
using ADSAutomationPhaseIII.Extensions;
using ADSAutomationPhaseIII.Preconditions;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Repository;
using Ranorex.Core.Testing;

namespace ADSAutomationPhaseIII.TC_10570
{
	
    public static class Steps 
    {
        public static TC10570Repo repo = TC10570Repo.Instance;
        public static int waittime = 10000;
        
        public static void CreateDatabase()
		{
			try 
			{
				repo.Application.MongoDBServerlistInfo.WaitForItemExists(waittime);
				repo.Application.MongoDBServerlist.DoubleClick();
				repo.Application.CreateDatabasePanel.DatabasesInfo.WaitForItemExists(waittime);
				repo.Application.CreateDatabasePanel.Databases.RightClickThis();
				repo.Datastudio.CreateDatabase.ClickThis();
				repo.Application.CreateDatabasePanel.DatabaseName.PressKeys("ads_DBNew");
				repo.Application.CreateDatabasePanel.CollectionsName.PressKeys("ads_DBNew_Collections");
				repo.Application.CreateDatabasePanel.CreateDBButton.ClickThis();
				if (repo.CreatedDBExists.ButtonOKInfo.Exists(5000))
				{
					repo.CreatedDBExists.ButtonOK.ClickThis();
					repo.Application.CreateDatabasePanel.CreateDatabase.RightClickThis();
					repo.Datastudio.Close.ClickThis();
					repo.CreateDatabase.DiscardButtonInfo.WaitForItemExists(waittime);
					repo.CreateDatabase.DiscardButton.ClickThis();
				}
				Thread.Sleep(3000);
				
				Reports.ReportLog("CreateDatabase", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonFileMenu : " + ex.Message);
			}
		}
        
        public static void DropDB()
		{
			try 
			{
				repo.Application.CreateDatabasePanel.AdsDBNewInfo.WaitForItemExists(waittime);
				repo.Application.CreateDatabasePanel.AdsDBNew.MoveTo();
				repo.Application.CreateDatabasePanel.AdsDBNew.RightClick();
				repo.Datastudio.DropDatabaseInfo.WaitForItemExists(waittime);
				repo.Datastudio.DropDatabase.ClickThis();
				repo.DropDatabase.SelfInfo.WaitForItemExists(waittime);
				repo.DropDatabase.ButtonYes.ClickThis();
				
				Reports.ReportLog("CreateDatabase", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonFileMenu : " + ex.Message);
			}
		}
        public static void ClickonFileMenu()
		{
			try 
			{
				repo.Application.FileMenuInfo.WaitForItemExists(waittime);
				repo.Application.FileMenu.ClickThis();
				Reports.ReportLog("ClickonFileMenu", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonFileMenu : " + ex.Message);
			}
		}
        
        public static void ClickonOptions()
		{
			try 
			{
				repo.Datastudio.OptionsInfo.WaitForItemExists(waittime);
				repo.Datastudio.Options.ClickThis();
				
				Reports.ReportLog("ClickonOptions", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonOptions : " + ex.Message);
			}
		}	
        
        public static void ClickExpandQueryAnalyzer()
		{
			try 
			{
				if(!repo.Options.MenuOptions.MangoDBSQLInfo.Exists(5000))
				{					
					repo.Options.MenuOptions.Options_QueryAnalyserInfo.WaitForItemExists(waittime);
					repo.Options.MenuOptions.Options_QueryAnalyser.DoubleClick();
				}
								
				Reports.ReportLog("ClickExpandQueryAnalyzer", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickExpandQueryAnalyzer : " + ex.Message);
			}
		}
   		
		public static void SelectMangoDB()
		{
			try 
			{
				repo.Options.MenuOptions.MangoDBSQLInfo.WaitForItemExists(waittime);
				repo.Options.MenuOptions.MangoDBSQL.ClickThis();
								
				Reports.ReportLog("SelectMangoDB", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectMangoDB : " + ex.Message);
			}
		}	

		public static void SelectDefaultSyntax(int DBName)
		{
			try
			{ 
				repo.Options.MongoSQLInfo.WaitForItemExists(waittime);
				repo.Options.MongoSQL.ClickThis();
				
				if (DBName == 0)
				{
					repo.Options.MongoSQL.PressKeys("MongoSQL");
				}
				else if(DBName == 1)
				{
					repo.Options.MongoSQLInfo.WaitForItemExists(waittime);
					repo.Options.MongoSQL.ClickThis();
					repo.Options.DefaultSyntaxButtInfo.WaitForItemExists(waittime);
					repo.Options.DefaultSyntaxButt.ClickThis();
					repo.Datastudio.MongoJSInfo.WaitForItemExists(waittime);
					repo.Datastudio.MongoJS.ClickThis();
				}
				
				repo.Options.ButtonOKInfo.WaitForItemExists(waittime);
				repo.Options.ButtonOK.ClickThis();
				
				Reports.ReportLog("SelectDefaultSyntax", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectDefaultSyntax : " + ex.Message);
			}
		}
		
		public static void SelectAutoCompletion(bool checkbox)
		{
			try
			{ 
				if (!repo.Options.AutoCompletionCheckboxChecked.Selected)
					repo.Options.AutoCompletionCheckboxChecked.Selected = checkbox;
				
				Reports.ReportLog("SelectAutoCompletion", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectAutoCompletion : " + ex.Message);
			}
		}
		
		public static void SelectTestDB(bool checkbox)
		{
			try
			{ repo.Application.MongoDBServerlist.EnsureVisible();
				repo.Application.MongoDBServerlist.RightClickThis();
				repo.Datastudio.QueryAnalyzer.ClickThis();
				repo.Application.CreateDatabasePanel.QueryPanelDropdownarrowInfo.WaitForItemExists(waittime);
				repo.Application.CreateDatabasePanel.QueryPanelDropdownarrow.ClickThis();
				repo.Datastudio.TestDBCreatedInfo.WaitForItemExists(waittime);
				repo.Datastudio.TestDBCreated.ClickThis();
				
				Reports.ReportLog("SelectTestDB", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectTestDB : " + ex.Message);
			}
		}
		
		public static void SelectLocalDBServerList(string query1)
		{
			try
			{ 
				repo.Application.MongoDBServerlist.EnsureVisible();
				repo.Application.MongoDBServerlist.RightClickThis();
				repo.Datastudio.QueryAnalyzer.ClickThis();
				repo.Application.CreateDatabasePanel.QueryPanelDropdownarrowInfo.WaitForItemExists(waittime);
				repo.Application.CreateDatabasePanel.QueryPanelDropdownarrow.ClickThis();
				repo.Datastudio.DBCreatedInfo.WaitForItemExists(waittime);
				repo.Datastudio.DBCreated.ClickThis();
				repo.FileMenu.QueryTextArea.PressKeys(query1);
				Keyboard.Press(" ");
				Thread.Sleep(1000);
          	  	Keyboard.Press("{Down}");
            	Keyboard.Press("{TAB}");
				repo.FileMenu.ExecuteButton.ClickThis();
				
				Reports.ReportLog("SelectLocalDBServerList", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectLocalDBServerList : " + ex.Message);
			}
		}
		
		public static void SelectDatabase()
		{
			try 
			{
				repo.Application.CreateDatabasePanel.QueryPanelDropdownarrowInfo.WaitForItemExists(waittime);
				repo.Application.CreateDatabasePanel.QueryPanelDropdownarrow.ClickThis();
				repo.Datastudio.DBCreatedInfo.WaitForItemExists(waittime);
				repo.Datastudio.DBCreated.ClickThis();
				Reports.ReportLog("SelectDatabase", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectDatabase : " + ex.Message);
			}
		}
		
		public static void SelectLocalDBServerListMango(string query)
		{
			try
			{ 
				repo.Application.MongoDBServerlist.EnsureVisible();
				repo.Application.MongoDBServerlist.RightClickThis();
				repo.Datastudio.QueryAnalyzer.ClickThis();
				repo.Application.CreateDatabasePanel.QueryPanelDropdownarrowInfo.WaitForItemExists(waittime);
				repo.Application.CreateDatabasePanel.QueryPanelDropdownarrow.ClickThis();
				repo.Datastudio.TestDBCreatedInfo.WaitForItemExists(waittime);
				repo.Datastudio.TestDBCreated.ClickThis();
				repo.FileMenu.QueryTextArea.PressKeys(query);
				Keyboard.Press(" ");
				Thread.Sleep(1000);
          	  	Keyboard.Press("{Down}");
            	Keyboard.Press("{TAB}");
				repo.FileMenu.ExecuteButton.ClickThis();
				
				Reports.ReportLog("SelectLocalDBServerListMango", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectLocalDBServerListMango : " + ex.Message);
			}
		}
		
		public static void CloseQueryPanel()
		{
			try
			{ 
				if (repo.FileMenu.TabPage_QueryPanelInfo.Exists(5000))
				{
					repo.FileMenu.TabPage_QueryPanel.RightClickThis();
					repo.Datastudio.CloseInfo.WaitForItemExists(waittime);
					repo.Datastudio.Close.ClickThis();
					repo.CloseQueryPanelpopup.DiscardInfo.WaitForItemExists(waittime);
					repo.CloseQueryPanelpopup.Discard.ClickThis();
				}
				Reports.ReportLog("CloseQueryPanel", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CloseQueryPanel : " + ex.Message);
			}
		}
		
		public static void SelectMongoDB_Database(string mongoDBname)
		{
			try
			{ 
				repo.Application.MongoDBServerlist.EnsureVisible();				
				repo.Application.MongoDBServerlist.RightClickThis();
				repo.Datastudio.QueryAnalyzer.ClickThis();
				repo.Application.CreateDatabasePanel.QueryPanelDropdownarrowInfo.WaitForItemExists(waittime);
				repo.Application.CreateDatabasePanel.QueryPanelDropdownarrow.ClickThis();
				
				if (mongoDBname == "ads_db")
				{
					repo.Datastudio.AdsDbDropdown.ClickThis();				
				}				
				else if (mongoDBname == "tom")
				{
					repo.Datastudio.TomDBDropdown.ClickThis();
				}
				Reports.ReportLog("SelectMongoDB_Database", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectMongoDB_Database : " + ex.Message);
			}
		}
    
		public static void SelectTabelAndColumnfromList()
		{
			try
			{ 
			
              Keyboard.Press("select * from");
			  Keyboard.Press(" ");
		      Thread.Sleep(1000);	
			  Keyboard.Press("{Down}");		      
              Keyboard.Press("{Return}");
              Keyboard.Press(" ");
              Keyboard.Press("where");
              Keyboard.Press(" ");
              Thread.Sleep(1000);
              Keyboard.Press("{Down}");
              Keyboard.Press("{Return}");
            
            Reports.ReportLog("SelectTabelAndColumnfromList", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
            
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectTabelAndColumnfromList : " + ex.Message);
			}
		}
		
		public static void SelectDatabasefromList()
		{
			try
			{ 
            repo.FileMenu.EditorMangoDB.Click("308;140");           
            Keyboard.Press("db.");
            Thread.Sleep(1000);
            Keyboard.Press("{Down}");
            Keyboard.Press("{TAB}");
            Keyboard.Press(".");
            Thread.Sleep(1000);            
            Keyboard.Press("{Down}");             
        	Keyboard.Press("{TAB}");
            
            Reports.ReportLog("SelectDatabasefromList", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectDatabasefromList : " + ex.Message);
			}
		}
		
		public static void ValidateQueryPane()
		{
			try
			{
				Validate.Exists(repo.FileMenu.QueryTextValidate);
				Reports.ReportLog("ValidateQueryPane", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateQueryPane  : " + ex.Message);
			}
		}
		
	}
    
}
