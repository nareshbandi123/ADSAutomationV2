﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Configuration;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Preconditions;
using ADSAutomationPhaseII.TC_10538;
using ADSAutomationV1Phase1Part3.TC_10538;
using ADSAutomationV1Phase1Part3.TC_10547;
using Ranorex;
using Ranorex.Core;

namespace ADSAutomationPhaseII.TC_10547
{
	public static class Steps
	{
		public static TC10547Repo repo = TC10547Repo.Instance;
		public static TC10538 tc10538Repo = TC10538.Instance;
		public static List<string> databasesTree = new List<string>() { "Databases", "Keyspaces", "Schema" };
		public static List<string> schemaTree = new List<string>() { "public" };
		public static List<string> tableTree = new List<string>() { "Tables" };
		public static string TC_10547_PATH = System.Configuration.ConfigurationManager.AppSettings["TC_10547"].ToString();
		
		public static void ConnectServer()
		{
			try
			{
				TreeItem server = Preconditions.Steps.GetServerTreeFromTCName(Config.TestCaseName);
				Preconditions.Steps.SelectedServerTreeItem = server;
				Preconditions.Steps.SelectedServerName = server.Text;
				server.RightClickThis();
				Preconditions.Steps.ConnectServer();
				Reports.ReportLog("Connect to server", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed :  ConnectServer : " + ex.Message );
			}
		}
		
		public static void DisconnectServer()
		{
			try
			{
				Preconditions.Steps.SelectedServerTreeItem.RightClickThis();
				Preconditions.Steps.DisconnectServer();
				Reports.ReportLog("DisconnectServer", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed :  DisconnectServer : " + ex.Message );
			}
		}
		
		public static void ReconnectServer()
		{
			try
			{
				Preconditions.Steps.SelectedServerTreeItem.RightClickThis();
				Preconditions.Steps.ReConnectServer();
				Reports.ReportLog("ReconnectServer", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed :  ReconnectServer : " + ex.Message );
			}
		}
		
		public static void CreateDatabaseQA()
		{
			try
			{
				TreeItem dbTree = null;
				foreach (var item in Preconditions.Steps.SelectedServerTreeItem.Items)
					if(databasesTree.Contains(item.Text)){ dbTree = item; break; }

				if(dbTree != null) { dbTree.EnsureVisible();  dbTree.RightClickThis(); } else {throw new Exception("Failed : CreateDatabaseQA : dbTree is null");}
				
				repo.SunAwtWindow.CreateDBMenuInfo.WaitForItemExists(10000);
				repo.SunAwtWindow.CreateDBMenu.ClickThis();
				
				repo.Application.DBNameTextInfo.WaitForItemExists(10000);
				repo.Application.DBNameText.TextBoxText(Config.ADSDB);
				repo.Application.CreateButtonInfo.WaitForItemExists(10000);
				repo.Application.CreateButton.ClickThis();
				Reports.ReportLog("New database created", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				if(repo.DBCreationFailed.SelfInfo.Exists(new Duration(5000)))
				{
					if(repo.DBCreationFailed.FailedText.TextValue.ToLower().Contains("already exists"))
					{
						repo.DBCreationFailed.OkButtonInfo.WaitForItemExists(10000);
						repo.DBCreationFailed.OkButton.ClickThis();
						
						repo.Application.CancelButtonInfo.WaitForItemExists(10000);
						repo.Application.CancelButton.ClickThis();
						if(repo.CancelCreate.SelfInfo.Exists())
							repo.CancelCreate.DiscardButton.ClickThis();
						Reports.ReportLog("ads_db database already exists", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
						DropDatabaseQA();
					}
				}
				else
				{
					dbTree.Expand();
					TreeItem dbTable = null;
					foreach (var item in dbTree.Items)
					{
						if(item.Text == Config.ADSDB)
						{
							dbTable = item;
							item.ClickThis();
							Reports.ReportLog("Validation : Created DB found under the database tree", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
							break;
						}
					}
					DropDatabaseQA();
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed :  CreateDatabase : " + ex.Message );
			}
		}
		
		public static void DropDatabaseQA()
		{
			try
			{
				Preconditions.Steps.SelectedServerTreeItem.Collapse();
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.DisconnectServer();
				Preconditions.Steps.QueryAnalyser();
				Preconditions.Steps.DropDatabase();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				Reports.ReportLog("DropDatabaseQA", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed :  DropDatabaseQA : " + ex.Message );
			}
		}
		
		public static void ClickDiscard()
		{
			try
			{
				if(repo.FileModified.SelfInfo.Exists()) repo.FileModified.DiscardButton.ClickThis();
			}
			catch (Exception ex)
			{
				throw new Exception("Failed :  ClickDiscard : " + ex.Message );
			}
		}
		
		public static void CreateDBFromMenu1()
		{
			try
			{
				Preconditions.Steps.SelectedServerTreeItem.Collapse();
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.ConnectServer();
				
				TreeItem dbTree = null;
				foreach (var item in Preconditions.Steps.SelectedServerTreeItem.Items)
					if(databasesTree.Contains(item.Text)){ dbTree = item; break; }

				if(dbTree!=null)
				{
					dbTree.Expand();
					
					System.Threading.Thread.Sleep(1000);
					
					foreach (var item in dbTree.Items)
						if(Config.ADSDB != item.Text){ item.RightClick(); break; }
					
					repo.Datastudio1.ScriptObjectToWindowInfo.WaitForItemExists(30000);
					repo.Datastudio1.ScriptObjectToWindow.ClickThis();
					
					repo.Datastudio2.CreateInfo.WaitForItemExists(30000);
					repo.Datastudio2.Create.ClickThis();
					
					repo.Application.ExecuteButtonInfo.WaitForItemExists(30000);
					tc10538Repo.Application.QATextEditorInfo.WaitForItemExists(30000);
					tc10538Repo.Application.QATextEditor.Click();
					string query = "CREATE DATABASE ads_db WITH OWNER = root";
					Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
					Keyboard.Press(Keyboard.ToKey("Delete"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
					tc10538Repo.Application.QATextEditor.PressKeys(query);
					tc10538Repo.Application.QATextEditor.Click();
					
					Preconditions.Steps.ClickQARun();
					Preconditions.Steps.CloseTab(Config.TestCaseName);
					ClickDiscard();
				}
				Reports.ReportLog("CreateDBFromMenu1", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				dbTree.RightClickThis();
				repo.Datastudio1.Refresh.ClickThis();
				dbTree.Expand();
				TreeItem dbTable = null;
				foreach (var item in dbTree.Items)
				{
					if(item.Text == Config.ADSDB)
					{
						dbTable = item;
						item.ClickThis();
						Reports.ReportLog("Validation : Created DB found under the database tree", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
						break;
					}
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed :  CreateDBFromMenu1 : " + ex.Message );
			}
		}
		
		public static void DropDBFromMenu1()
		{
			try
			{
				Preconditions.Steps.SelectedServerTreeItem.Collapse();
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.ConnectServer();
				
				TreeItem dbTree = null;
				foreach (var item in Preconditions.Steps.SelectedServerTreeItem.Items)
					if(databasesTree.Contains(item.Text)){ dbTree = item; break; }

				if(dbTree!=null)
				{
					dbTree.Expand();
					System.Threading.Thread.Sleep(1000);
					foreach (var item in dbTree.Items)
						if(Config.ADSDB != item.Text){ item.RightClick(); break; }
					
					repo.Datastudio1.ScriptObjectToWindowInfo.WaitForItemExists(10000);
					repo.Datastudio1.ScriptObjectToWindow.ClickThis();
					
					repo.Datastudio2.DropInfo.WaitForItemExists(10000);
					repo.Datastudio2.Drop.ClickThis();
					Preconditions.Steps.CloseTab(Config.TestCaseName);
					ClickDiscard();
					DropDatabaseQA();
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed :  DropDBFromMenu1 : " + ex.Message );
			}
		}
		
		public static void CreateDBFromMenu2()
		{
			try
			{
				Preconditions.Steps.SelectedServerTreeItem.Collapse();
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.ConnectServer();
				
				TreeItem dbTree = null;
				foreach (var item in Preconditions.Steps.SelectedServerTreeItem.Items)
					if(databasesTree.Contains(item.Text)){ dbTree = item; break; }

				if(dbTree != null)
				{
					dbTree.Expand();
					System.Threading.Thread.Sleep(1000);
					foreach (var item in dbTree.Items)
						if(Config.ADSDB != item.Text){ item.RightClick(); break; }
					
					repo.Datastudio1.ScriptObjectToNewWindowInfo.WaitForItemExists(10000);
					repo.Datastudio1.ScriptObjectToNewWindow.ClickThis();
					
					repo.Datastudio2.CreateInfo.WaitForItemExists(10000);
					repo.Datastudio2.Create.ClickThis();
					
					repo.Application.ExecuteButtonInfo.WaitForItemExists(10000);
					tc10538Repo.Application.QATextEditorInfo.WaitForItemExists(10000);
					tc10538Repo.Application.QATextEditor.Click();
					string query = "CREATE DATABASE ads_db WITH OWNER = root";
					Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
					Keyboard.Press(Keyboard.ToKey("Delete"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
					tc10538Repo.Application.QATextEditor.PressKeys(query);
					tc10538Repo.Application.QATextEditor.Click();
					
					Preconditions.Steps.ClickQARun();
					Preconditions.Steps.CloseTab(Config.TestCaseName);
					ClickDiscard();
				}
				Reports.ReportLog("CreateDBFromMenu2", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				dbTree.Expand();
				TreeItem dbTable = null;
				foreach (var item in dbTree.Items)
				{
					if(item.Text == Config.ADSDB)
					{
						dbTable = item;
						item.ClickThis();
						Reports.ReportLog("Validation : Created DB found under the database tree", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
						break;
					}
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed :  CreateDBFromMenu2 : " + ex.Message );
			}
		}
		
		public static void DropDBFromMenu2()
		{
			try
			{
				Preconditions.Steps.SelectedServerTreeItem.Collapse();
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.ConnectServer();
				
				TreeItem dbTree = null;
				foreach (var item in Preconditions.Steps.SelectedServerTreeItem.Items)
					if(databasesTree.Contains(item.Text)){ dbTree = item; break; }

				if(dbTree!=null)
				{
					dbTree.Expand();
					System.Threading.Thread.Sleep(1000);
					foreach (var item in dbTree.Items)
						if(Config.ADSDB != item.Text){ item.RightClick(); break; }
					
					repo.Datastudio1.ScriptObjectToNewWindowInfo.WaitForItemExists(10000);
					repo.Datastudio1.ScriptObjectToNewWindow.ClickThis();
					
					repo.Datastudio2.DropInfo.WaitForItemExists(10000);
					repo.Datastudio2.Drop.ClickThis();
					Preconditions.Steps.CloseTab(Config.TestCaseName);
					ClickDiscard();
					DropDatabaseQA();
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed :  DropDBFromMenu2 : " + ex.Message );
			}
		}
		
		public static void CreateDBFromMenu3()
		{
			try
			{
				Preconditions.Steps.SelectedServerTreeItem.Collapse();
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.ConnectServer();
				
				TreeItem dbTree = null;
				foreach (var item in Preconditions.Steps.SelectedServerTreeItem.Items)
					if(databasesTree.Contains(item.Text)){ dbTree = item; break; }

				if(dbTree != null)
				{
					dbTree.Expand();
					System.Threading.Thread.Sleep(1000);
					foreach (var item in dbTree.Items)
						if(Config.ADSDB != item.Text){ item.RightClick(); break; }
					
					repo.Datastudio1.ScriptObjectToFileInfo.WaitForItemExists(10000);
					repo.Datastudio1.ScriptObjectToFile.ClickThis();
					
					repo.Datastudio2.CreateInfo.WaitForItemExists(10000);
					repo.Datastudio2.Create.ClickThis();
					
					Common.DeleteFile(TC_10547_PATH + "ads_db_Create.sql");
					
					repo.SaveFile.FilePathTextbox.TextValue = TC_10547_PATH + "ads_db_Create";
					repo.SaveFile.SaveButton.ClickThis();
				}
				
				Reports.ReportLog("CreateDBFromMenu3", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed :  CreateDBFromMenu3 : " + ex.Message );
			}
		}
		
		public static void DropDBFromMenu3()
		{
			try
			{
				Preconditions.Steps.SelectedServerTreeItem.Collapse();
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.ConnectServer();
				
				TreeItem dbTree = null;
				foreach (var item in Preconditions.Steps.SelectedServerTreeItem.Items)
					if(databasesTree.Contains(item.Text)){ dbTree = item; break; }

				if(dbTree!=null)
				{
					dbTree.Expand();
					System.Threading.Thread.Sleep(1000);
					foreach (var item in dbTree.Items)
						if(Config.ADSDB != item.Text){ item.RightClick(); break; }
					
					repo.Datastudio1.ScriptObjectToFileInfo.WaitForItemExists(10000);
					repo.Datastudio1.ScriptObjectToFile.ClickThis();
					
					repo.Datastudio2.DropInfo.WaitForItemExists(10000);
					repo.Datastudio2.Drop.ClickThis();
					
					Common.DeleteFile(TC_10547_PATH + "ads_db_Drop.sql");
					
					repo.SaveFile.FilePathTextbox.TextValue = TC_10547_PATH + "ads_db_Drop";
					repo.SaveFile.SaveButton.ClickThis();
				}
				Reports.ReportLog("DropDBFromMenu3", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				Common.DeleteFile(TC_10547_PATH + "ads_db_Create.sql");
				Common.DeleteFile(TC_10547_PATH + "ads_db_Drop.sql");
				
				Preconditions.Steps.SelectedServerTreeItem.Collapse();
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.DisconnectServer();
			}
			catch (Exception ex)
			{
				throw new Exception("Failed :  DropDBFromMenu3 : " + ex.Message );
			}
		}
		
		public static void ExecuteTC2()
		{
			try
			{
				ConnectServer();
				
				Preconditions.Steps.SelectedServerTreeItem.Collapse();
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				Preconditions.Steps.CreateDatabase();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				Reports.ReportLog("Create ads_db", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				if(Config.SchemaServers.Contains(Preconditions.Steps.SelectedServerName)) Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB_CAPS);
				else Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
				
				Preconditions.Steps.CreateTable();
				Reports.ReportLog("Create ads_table", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.DisconnectServer();
				
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.ConnectServer();
				
				TreeItem databases = Preconditions.Steps.SelectedServerTreeItem.GetItem("Databases");
				TreeItem adsdb = databases.GetItem("ads_db");
				adsdb.ExpandAll();
				System.Threading.Thread.Sleep(5000);
				
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.DisconnectServer();
				
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				if(Config.SchemaServers.Contains(Preconditions.Steps.SelectedServerName)) Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB_CAPS);
				else Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
				
				Preconditions.Steps.DropTable();
				Reports.ReportLog("drop ads_table", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				Preconditions.Steps.DropDatabase();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				Reports.ReportLog("drop ads_db", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : Query Execution failed : " + ex.Message);
			}
		}
		
		public static void ExecuteTC3(bool isAlter = false)
		{
			try
			{
				ConnectServer();
				
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				Preconditions.Steps.CreateDatabase();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				Preconditions.Steps.DisconnectServer();
				Preconditions.Steps.ConnectServer();
				Reports.ReportLog("Create ads_db", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				TreeItem databasesItem = Preconditions.Steps.SelectedServerTreeItem.GetItem("Databases");
				TreeItem adsdbItem = databasesItem.GetItem(Config.ADSDB);
				TreeItem publicItem = adsdbItem.GetItem("public");
				TreeItem tablesItem = publicItem.GetItem("Tables");
				
				if(tablesItem != null)
				{
					if(tablesItem.Items.Count > 0)
					{
						TreeItem val = tablesItem.GetItem("public.ads_table");
						val.RightClick();
						repo.Datastudio1.DropTableInfo.WaitForItemExists(30000);
						repo.Datastudio1.DropTable.ClickThis();
						if(repo.DropTable.SelfInfo.Exists()) repo.DropTable.YesButton.ClickThis();
					}
					
					tablesItem.RightClick();
					repo.Datastudio1.CreateTable.ClickThis();
					repo.Application.CreateNewTable.TableNameTextboxInfo.WaitForItemExists(30000);
					repo.Application.CreateNewTable.TableNameTextbox.TextBoxText("ads_table");
					repo.Application.CreateNewTable.Column1.DoubleClick();
					repo.Application.CreateNewTable.Column1.PressKeys("name");
					repo.Application.CreateNewTable.CreateButton.ClickThis();
					Reports.ReportLog("Create ads_table done", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
					tablesItem.ExpandAll();
					Reports.ReportLog("Validation : Table schema items done", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
					
					TreeItem adstableItem = tablesItem.GetItem("public.ads_table");
					
					if(isAlter)
					{
						adstableItem.RightClick();
						repo.Datastudio1.AlterTable.ClickThis();
						
						repo.Application.CreateNewTable.Column1.PressKeys("names");
						repo.Application.CreateNewTable.AlterButton.ClickThis();
						Reports.ReportLog("Alter ads_table done", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
					}
					
					
					adstableItem.RightClick();
					repo.Datastudio1.DropTableInfo.WaitForItemExists(30000);
					repo.Datastudio1.DropTable.ClickThis();
					Reports.ReportLog("Drop ads_table done", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
					
					if(repo.DropTable.SelfInfo.Exists()) repo.DropTable.YesButton.ClickThis();
					
					DropDatabaseQA();
				}
				else
				{
					DropDatabaseQA();
				}
			}
			catch (Exception ex)
			{
				DropDatabaseQA();
				throw new Exception("Failed : ExecuteTC3 : "+ ex.Message);
			}
		}
		
		public static void ExecuteTC4()
		{
			try
			{
				ExecuteTC3(true);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ExecuteTC4 : "+ ex.Message);
			}
		}
		
		public static void ExecuteTC5()
		{
			try
			{
				ConnectServer();
				
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				Preconditions.Steps.CreateDatabase();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				Preconditions.Steps.DisconnectServer();
				Preconditions.Steps.ConnectServer();
				Reports.ReportLog("Create ads_db", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				if(Config.SchemaServers.Contains(Preconditions.Steps.SelectedServerName)) Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB_CAPS);
				else Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
				
				Preconditions.Steps.CreateTable();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				Reports.ReportLog("Create ads_table", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				TreeItem databasesItem = Preconditions.Steps.SelectedServerTreeItem.GetItem("Databases");
				TreeItem adsdbItem = databasesItem.GetItem(Config.ADSDB);
				TreeItem publicItem = adsdbItem.GetItem("public");
				TreeItem viewItem = publicItem.GetItem("Views");
				
				if(viewItem != null)
				{
					
					if(viewItem.Items.Count > 0)
					{
						TreeItem val = viewItem.GetItem("public.ads_view");
						val.RightClick();
						repo.Datastudio1.DropViewInfo.WaitForItemExists(30000);
						repo.Datastudio1.DropView.ClickThis();
						if(repo.DropView.SelfInfo.Exists()) repo.DropView.YesButton.ClickThis();
					}
					
					viewItem.RightClick();
					repo.Datastudio1.CreateView.ClickThis();
					repo.Application.CreateView.ViewNameTextboxInfo.WaitForItemExists(30000);
					repo.Application.CreateView.ViewNameTextbox.TextBoxText("ads_view");
					repo.Application.CreateView.SourceTextbox.Click();
					
					string query = "AS SELECT * FROM ads_table";
					Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
					Keyboard.Press(Keyboard.ToKey("Delete"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
					repo.Application.CreateView.SourceTextbox.PressKeys(query);
					repo.Application.CreateView.SourceTextbox.Click();
					repo.Application.CreateView.CreateButton.ClickThis();
					Reports.ReportLog("Create ads_view", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
					TreeItem adsviewItem = viewItem.GetItem("public.ads_view");
					adsviewItem.RightClick();
					repo.Datastudio1.AlterView.ClickThis();
					repo.Application.CreateView.AlterCancelButton.ClickThis();
					Reports.ReportLog("Alter ads_view", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
					adsviewItem.RightClick();
					repo.Datastudio1.DropView.ClickThis();
					if(repo.DropView.SelfInfo.Exists()) repo.DropView.YesButton.ClickThis();
					Reports.ReportLog("drop ads_view", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
					
					TreeItem tablesItem = publicItem.GetItem("Tables");
					TreeItem adstableItem = tablesItem.GetItem("public.ads_table");
					adstableItem.RightClick();
					repo.Datastudio1.DropTable.ClickThis();
					Reports.ReportLog("Drop ads_table done", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
					
					if(repo.DropTable.SelfInfo.Exists()) repo.DropTable.YesButton.ClickThis();
				}
				
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				if(Config.SchemaServers.Contains(Preconditions.Steps.SelectedServerName)) Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB_CAPS);
				else Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
				
				Preconditions.Steps.DropView();
				Preconditions.Steps.DropTable();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				
				DropDatabaseQA();
			}
			catch (Exception ex)
			{
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				if(Config.SchemaServers.Contains(Preconditions.Steps.SelectedServerName)) Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB_CAPS);
				else Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
				
				Preconditions.Steps.DropView();
				Preconditions.Steps.DropTable();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				
				DropDatabaseQA();
				throw new Exception("Failed : ExecuteTC5 : "+ ex.Message);
			}
		}
		
		public static void ExecuteTC6()
		{
			try
			{
				ConnectServer();
				
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				Preconditions.Steps.CreateDatabase();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				Preconditions.Steps.DisconnectServer();
				Preconditions.Steps.ConnectServer();
				Reports.ReportLog("Create ads_db", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				if(Config.SchemaServers.Contains(Preconditions.Steps.SelectedServerName)) Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB_CAPS);
				else Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
				
				Preconditions.Steps.CreateTable();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				Reports.ReportLog("Create ads_table", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				TreeItem databasesItem = Preconditions.Steps.SelectedServerTreeItem.GetItem("Schema");
				TreeItem adsdbItem = databasesItem.GetItem(Config.ADSDB_CAPS);
				TreeItem triggerItem = adsdbItem.GetItem("Triggers");
				
				if(triggerItem != null)
				{
					
					if(triggerItem.Items.Count > 0)
					{
						TreeItem val = triggerItem.GetItem("ADS_DB.ads_trigger [ADS_TABLE]");
						val.RightClick();
						repo.Datastudio1.DropTriggerInfo.WaitForItemExists(30000);
						repo.Datastudio1.DropTrigger.ClickThis();
						if(repo.DropTrigger.SelfInfo.Exists()) repo.DropTrigger.YesButton.ClickThis();
					}
					
					triggerItem.RightClick();
					repo.Datastudio1.CreateTriggerInfo.WaitForItemExists(30000);
					repo.Datastudio1.CreateTrigger.ClickThis();
					repo.Application.Triggers.TriggerNameTextboxInfo.WaitForItemExists(30000);
					repo.Application.Triggers.TriggerNameTextbox.TextBoxText("ads_trigger");
					repo.Application.Triggers.SourceTextbox.Click();
					
					string query = "NO CASCADE BEFORE UPDATE ON ads_db.ads_table \r\n FOR EACH ROW MODE DB2SQL values('Jerry', 'Table x is about to be updated')";
					Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
					Keyboard.Press(Keyboard.ToKey("Delete"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
					repo.Application.Triggers.SourceTextbox.PressKeys(query);
					repo.Application.Triggers.SourceTextbox.Click();
					repo.Application.Triggers.CreateButton.ClickThis();
					if(repo.Application.Triggers.CreateButtonInfo.Exists(2000)) repo.Application.Triggers.CreateButton.ClickThis();
					if(repo.SQLFailed.SelfInfo.Exists(new Duration(2000)))
					{
						repo.SQLFailed.OkButton.ClickThis();
						repo.Application.Triggers.CancelButton.ClickThis();
						repo.DiscardTrigger.DiscardButton.ClickThis();
					}
					Reports.ReportLog("Create ads_trigger", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
					TreeItem adsTriggerItem = triggerItem.GetItem("ADS_DB.ads_trigger [ADS_TABLE]");
					
					if(adsTriggerItem!=null)
					{
						adsTriggerItem.RightClick();
						repo.Datastudio1.DropTrigger.ClickThis();
						if(repo.DropTrigger.SelfInfo.Exists()) repo.DropTrigger.YesButton.ClickThis();
						Reports.ReportLog("drop ads_trigger", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
						
						TreeItem tablesItem = adsdbItem.GetItem("Tables");
						TreeItem adstableItem = tablesItem.GetItem("ADS_DB.ADS_TABLE");
						if(adstableItem!=null)adstableItem.RightClick();
						repo.Datastudio1.DropTable.ClickThis();
						Reports.ReportLog("Drop ads_table done", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
						
						if(repo.DropTable.SelfInfo.Exists()) repo.DropTable.YesButton.ClickThis();
					}
				}
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				if(Config.SchemaServers.Contains(Preconditions.Steps.SelectedServerName)) Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB_CAPS);
				else Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
				
				Preconditions.Steps.DropTrigger();
				Preconditions.Steps.DropTable();
				DropDatabaseQA();
			}
			catch (Exception ex)
			{
				if(repo.SQLFailed.SelfInfo.Exists(new Duration(2000))) { repo.SQLFailed.OkButton.ClickThis(); }
				if(repo.Application.Triggers.SelfInfo.Exists(2000))repo.Application.Triggers.CancelButton.ClickThis();
				if(repo.DiscardTrigger.SelfInfo.Exists(2000))repo.DiscardTrigger.DiscardButton.ClickThis();
				if(repo.DropTrigger.SelfInfo.Exists(1000)) repo.DropTrigger.Self.Close();
				if(repo.DropTable.SelfInfo.Exists(1000)) repo.DropTable.Self.Close();
				
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				if(Config.SchemaServers.Contains(Preconditions.Steps.SelectedServerName)) Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB_CAPS);
				else Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
				
				Preconditions.Steps.DropTrigger();
				Preconditions.Steps.DropTable();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				DropDatabaseQA();
				throw new Exception("Failed : ExecuteTC6 : "+ ex.Message);
			}
		}
		
		public static void ExecuteTC7()
		{
			try
			{
				ConnectServer();
				
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				Preconditions.Steps.CreateDatabase();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				Preconditions.Steps.DisconnectServer();
				Preconditions.Steps.ConnectServer();
				Reports.ReportLog("Create ads_db", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				if(Config.SchemaServers.Contains(Preconditions.Steps.SelectedServerName)) Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB_CAPS);
				else Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
				
				Preconditions.Steps.CreateTable();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				Reports.ReportLog("Create ads_table", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				TreeItem databasesItem = Preconditions.Steps.SelectedServerTreeItem.GetItem("Schema");
				TreeItem adsdbItem = databasesItem.GetItem(Config.ADSDB_CAPS);
				TreeItem procedureItem = adsdbItem.GetItem("Stored Procedures");
				
				if(procedureItem != null)
				{
					
					if(procedureItem.Items.Count > 0)
					{
						TreeItem val = procedureItem.GetItem("ads_procedure");
						val.RightClick();
						repo.Datastudio1.DropProcedureInfo.WaitForItemExists(30000);
						repo.Datastudio1.DropProcedure.ClickThis();
						if(repo.DropProcedure.SelfInfo.Exists()) repo.DropProcedure.YesButton.ClickThis();
					}
					
					procedureItem.RightClick();
					repo.Datastudio1.CreateProcedureInfo.WaitForItemExists(30000);
					repo.Datastudio1.CreateProcedure.ClickThis();
					repo.Application.Procedures.ProcNameTextboxInfo.WaitForItemExists(30000);
					repo.Application.Procedures.ProcNameTextbox.TextBoxText("ads_procedure");
					repo.Application.Procedures.SourceTextbox.Click();
					
					string query = "(IN PARTNUM INTEGER, OUT COST DECIMAL(7,2), OUT QUANTITY INTEGER) \r\n EXTERNAL NAME 'parts.onhand' LANGUAGE JAVA PARAMETER STYLE JAVA";
					Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
					Keyboard.Press(Keyboard.ToKey("Delete"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
					repo.Application.Procedures.SourceTextbox.PressKeys(query);
					repo.Application.Procedures.SourceTextbox.Click();
					repo.Application.Procedures.CreateButton.ClickThis();
					
					
					Reports.ReportLog("Create ads_procedure", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
					TreeItem adsprocedureItem = procedureItem.GetItem("ads_procedure");
					
					if(adsprocedureItem!=null)
					{
						adsprocedureItem.RightClick();
						repo.Datastudio1.AlterProcedure.ClickThis();
						repo.Application.Procedures.AlterCloseButton.ClickThis();
						if(repo.DiscardProcedure.SelfInfo.Exists()) repo.DiscardProcedure.DiscardButton.ClickThis();
						Reports.ReportLog("alter ads_procedure", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
						
						if(adsprocedureItem!=null)adsprocedureItem.RightClick();
						repo.Datastudio1.DropProcedure.ClickThis();
						if(repo.DropProcedure.SelfInfo.Exists()) repo.DropProcedure.YesButton.ClickThis();
						Reports.ReportLog("drop ads_procedure", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
						
						TreeItem tablesItem = adsdbItem.GetItem("Tables");
						TreeItem adstableItem = tablesItem.GetItem("ADS_TABLE");
						if(adstableItem!=null)adstableItem.RightClick();
						repo.Datastudio1.DropTable.ClickThis();
						if(repo.DropTable.SelfInfo.Exists()) repo.DropTable.YesButton.ClickThis();
						Reports.ReportLog("Drop ads_table done", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
					}
					
					DropDatabaseQA();
				}
			}
			catch (Exception ex)
			{
				if(repo.SQLFailed.SelfInfo.Exists(new Duration(1000))) { repo.SQLFailed.OkButton.ClickThis(); }
				
				if(repo.Application.Procedures.CancelButtonInfo.Exists(1000)) repo.Application.Procedures.CancelButton.ClickThis();
				if(repo.DiscardProcedure.DiscardButtonInfo.Exists(1000)) repo.DiscardProcedure.DiscardButton.ClickThis();
				
				
				if(repo.Application.Procedures.AlterCloseButtonInfo.Exists(1000)) repo.Application.Procedures.AlterCloseButton.ClickThis();
				if(repo.DiscardProcedure.SelfInfo.Exists(1000)) repo.DiscardProcedure.DiscardButton.ClickThis();
				
				if(repo.DropProcedure.SelfInfo.Exists(1000)) repo.DropProcedure.YesButton.ClickThis();
				
				if(repo.DropTable.SelfInfo.Exists(1000)) repo.DropTable.Self.Close();
				
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				if(Config.SchemaServers.Contains(Preconditions.Steps.SelectedServerName)) Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB_CAPS);
				else Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
				
				Preconditions.Steps.DropProcedure();
				Preconditions.Steps.DropTable();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				
				DropDatabaseQA();
				throw new Exception("Failed : ExecuteTC7 : "+ ex.Message);
			}
			
		}
		
		public static void ExecuteTC8()
		{
			try
			{
				ConnectServer();
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				Preconditions.Steps.CreateDatabase();
				System.Threading.Thread.Sleep(5000);
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				Preconditions.Steps.DisconnectServer();
				Preconditions.Steps.ConnectServer();
				Reports.ReportLog("Create ads_db", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				if(Config.SchemaServers.Contains(Preconditions.Steps.SelectedServerName)) Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB_CAPS);
				else Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
				
				Preconditions.Steps.CreateTable();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				Reports.ReportLog("Create ads_table", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				TreeItem databasesItem = Preconditions.Steps.SelectedServerTreeItem.GetItem(databasesTree[0]);
				TreeItem adsdbItem = databasesItem.GetItem(Config.ADSDB);
				TreeItem publicItem = adsdbItem.GetItem("public");
				TreeItem functionsItem = publicItem.GetItem("Functions");
				
				if(functionsItem != null)
				{
					if(functionsItem.Items.Count > 0)
					{
						TreeItem val = functionsItem.GetItem("ads_function(23 23)");
						val.RightClick();
						repo.Datastudio1.DropFunctionInfo.WaitForItemExists(30000);
						repo.Datastudio1.DropFunction.ClickThis();
						if(repo.DropFunction.SelfInfo.Exists()) repo.DropFunction.YesButton.ClickThis();
					}
					
					functionsItem.RightClick();
					repo.Datastudio1.CreateFunction.ClickThis();
					repo.Application.Functions.FuncNameTextboxInfo.WaitForItemExists(120000);
					repo.Application.Functions.FuncNameTextbox.TextBoxText("ads_function");
					repo.Application.Functions.SourceTextbox.Click();
					
					string query = "(integer, integer) RETURNS integer AS 'select $1 + $2;' \r\n LANGUAGE SQL IMMUTABLE RETURNS NULL ON NULL INPUT;";
					Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
					Keyboard.Press(Keyboard.ToKey("Delete"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
					repo.Application.Functions.SourceTextbox.PressKeys(query);
					repo.Application.Functions.SourceTextbox.Click();
					repo.Application.Functions.CreateButton.ClickThis();
					Reports.ReportLog("Create ads_function", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
					TreeItem adsfunctionItem =  functionsItem.GetItem("ads_function(23 23)");
					
					if(adsfunctionItem!=null)adsfunctionItem.RightClick();
					repo.Datastudio1.AlterFunction.ClickThis();
					repo.Application.Functions.AlterCloseButton.ClickThis();
					if(repo.DiscardFunction.SelfInfo.Exists()) repo.DiscardFunction.DiscardButton.ClickThis();
					Reports.ReportLog("alter ads_function", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
					
					if(adsfunctionItem!=null)adsfunctionItem.RightClick();
					repo.Datastudio1.DropFunction.ClickThis();
					if(repo.DropFunction.SelfInfo.Exists()) repo.DropFunction.YesButton.ClickThis();
					Reports.ReportLog("drop ads_function", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
					
//					TreeItem tablesItem = adsdbItem.GetItem("Tables");
//					TreeItem adstableItem = tablesItem.GetItem("public.ads_table");
//					if(adstableItem!=null)adstableItem.RightClick();
//					repo.Datastudio.DropTable.ClickThis();
//					if(repo.DropTable.SelfInfo.Exists()) repo.DropTable.YesButton.ClickThis();
//					Reports.ReportLog("Drop ads_table done", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
					
					DropDatabaseQA();
				}
				else
				{
					DropDatabaseQA();
				}
			}
			catch (Exception ex)
			{
				if(repo.SQLFailed.SelfInfo.Exists(new Duration(1000))) { repo.SQLFailed.OkButton.ClickThis(); }
				
				if(repo.Application.Functions.CloseButtonInfo.Exists(1000)) repo.Application.Functions.CloseButton.ClickThis();
				if(repo.DiscardFunction.DiscardButtonInfo.Exists(1000)) repo.DiscardFunction.DiscardButton.ClickThis();
				
				if(repo.Application.Functions.AlterCloseButtonInfo.Exists(1000))repo.Application.Functions.AlterCloseButton.ClickThis();
				if(repo.DiscardFunction.SelfInfo.Exists(1000)) repo.DiscardFunction.DiscardButton.ClickThis();
				
				if(repo.DropFunction.SelfInfo.Exists(1000)) repo.DropFunction.YesButton.ClickThis();
				
				DropDatabaseQA();
				throw new Exception("Failed : ExecuteTC8 : "+ ex.Message);
			}
		}
		
		public static void ExecuteTC9()
		{
			try
			{
				ConnectServer();
				
				Preconditions.Steps.SelectedServerTreeItem.Collapse();
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				Preconditions.Steps.CreateDatabase();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				Reports.ReportLog("Create ads_db", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				if(Config.SchemaServers.Contains(Preconditions.Steps.SelectedServerName)) Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB_CAPS);
				else Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
				
				Preconditions.Steps.CreateTable();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				Reports.ReportLog("Create ads_table", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				TreeItem databaseItem = Preconditions.Steps.SelectedServerTreeItem.GetItem(databasesTree[0]);
				TreeItem adsdbItem = databaseItem.GetItem(Config.ADSDB);
				TreeItem publicItem = adsdbItem.GetItem("public");
				TreeItem tablesItem = publicItem.GetItem("Tables");
				TreeItem adstableItem = tablesItem.GetItem("public.ads_table");
				adstableItem.RightClick();
				repo.Datastudio1.ScriptWin1Info.WaitForItemExists(10000);
				repo.Datastudio1.ScriptWin1.ClickThis();
				repo.Datastudio2.InsertInfo.WaitForItemExists(10000);
				repo.Datastudio2.Insert.ClickThis();
				tc10538Repo.Application.QATextEditorInfo.WaitForItemExists(120000);
				
				string query = "insert into ads_table values (4563, 'Tom', 'ads', 'Tom', 'John' )";
				Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Keyboard.Press(Keyboard.ToKey("Delete"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				tc10538Repo.Application.QATextEditor.PressKeys(query);
				Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Preconditions.Steps.ClickQARun();
				System.Threading.Thread.Sleep(2000);
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists()) repo.FileModified.DiscardButton.ClickThis();
				Reports.ReportLog("ScriptWin1", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				
				adstableItem.RightClick();
				repo.Datastudio1.ScriptWin2.ClickThis();
				repo.Datastudio2.Insert.ClickThis();
				tc10538Repo.Application.QATextEditorInfo.WaitForItemExists(120000);
				
				Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Keyboard.Press(Keyboard.ToKey("Delete"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				tc10538Repo.Application.QATextEditor.PressKeys(query);
				Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Preconditions.Steps.ClickQARun();
				System.Threading.Thread.Sleep(2000);
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists()) repo.FileModified.DiscardButton.ClickThis();
				Reports.ReportLog("ScriptWin2", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				adstableItem.RightClick();
				repo.Datastudio1.ScriptWin3.ClickThis();
				repo.Datastudio2.Insert.ClickThis();
				
				Common.DeleteFile(TC_10547_PATH + "ads_db_Insert.sql");
				repo.SaveFile.SelfInfo.WaitForItemExists(12000);
				repo.SaveFile.FilePathTextbox.TextValue = TC_10547_PATH + "ads_db_Insert";
				repo.SaveFile.SaveButton.ClickThis();
				Common.DeleteFile(TC_10547_PATH + "ads_db_Insert.sql");
				Reports.ReportLog("ScriptWin3", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				adstableItem.RightClick();
				repo.Datastudio1.DropTable.ClickThis();
				if(repo.DropTable.SelfInfo.Exists()) repo.DropTable.YesButton.ClickThis();
				Reports.ReportLog("Drop ads_table done", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				DropDatabaseQA();
			}
			catch (Exception ex)
			{
				
				if(repo.SQLFailed.SelfInfo.Exists(new Duration(1000))) { repo.SQLFailed.OkButton.ClickThis(); }
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists(1000)) repo.FileModified.DiscardButton.ClickThis();
				if(repo.DropTable.SelfInfo.Exists(1000)) repo.DropTable.YesButton.ClickThis();
				DropDatabaseQA();
				throw new Exception("Failed : Execute TC9 : " + ex.Message);
			}
		}
		
		public static void ExecuteTC10()
		{
			try
			{
				ConnectServer();
				
				Preconditions.Steps.SelectedServerTreeItem.Collapse();
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				Preconditions.Steps.CreateDatabase();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				Reports.ReportLog("Create ads_db", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				if(Config.SchemaServers.Contains(Preconditions.Steps.SelectedServerName)) Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB_CAPS);
				else Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
				
				Preconditions.Steps.CreateTable();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				Reports.ReportLog("Create ads_table", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				TreeItem databaseItem = Preconditions.Steps.SelectedServerTreeItem.GetItem(databasesTree[0]);
				TreeItem adsdbItem = databaseItem.GetItem(Config.ADSDB);
				TreeItem publicItem = adsdbItem.GetItem("public");
				TreeItem tablesItem = publicItem.GetItem("Tables");
				TreeItem adstableItem = tablesItem.GetItem("public.ads_table");
				adstableItem.RightClick();
				repo.Datastudio1.ScriptWin1Info.WaitForItemExists(10000);
				repo.Datastudio1.ScriptWin1.ClickThis();
				repo.Datastudio2.Update.ClickThis();
				
				tc10538Repo.Application.QATextEditorInfo.WaitForItemExists(120000);
				string query = "update ads_table set name = 'Tom1' where id = 4563";
				Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Keyboard.Press(Keyboard.ToKey("Delete"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				tc10538Repo.Application.QATextEditor.PressKeys(query);
				Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Preconditions.Steps.ClickQARun();
				System.Threading.Thread.Sleep(2000);
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists()) repo.FileModified.DiscardButton.ClickThis();
				Reports.ReportLog("ScriptWin1", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				adstableItem.RightClick();
				repo.Datastudio1.ScriptWin2.ClickThis();
				repo.Datastudio2.Update.ClickThis();
				
				tc10538Repo.Application.QATextEditorInfo.WaitForItemExists(120000);
				Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Keyboard.Press(Keyboard.ToKey("Delete"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				tc10538Repo.Application.QATextEditor.PressKeys(query);
				Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Preconditions.Steps.ClickQARun();
				System.Threading.Thread.Sleep(2000);
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists()) repo.FileModified.DiscardButton.ClickThis();
				Reports.ReportLog("ScriptWin2", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				adstableItem.RightClick();
				repo.Datastudio1.ScriptWin3.ClickThis();
				repo.Datastudio2.Update.ClickThis();
				
				Common.DeleteFile(TC_10547_PATH + "ads_db_Insert.sql");
				repo.SaveFile.SelfInfo.WaitForItemExists(12000);
				repo.SaveFile.FilePathTextbox.TextValue = TC_10547_PATH + "ads_db_Insert";
				repo.SaveFile.SaveButton.ClickThis();
				Common.DeleteFile(TC_10547_PATH + "ads_db_Insert.sql");
				Reports.ReportLog("ScriptWin3", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				adstableItem.RightClick();
				repo.Datastudio1.DropTable.ClickThis();
				if(repo.DropTable.SelfInfo.Exists()) repo.DropTable.YesButton.ClickThis();
				Reports.ReportLog("Drop ads_table done", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				DropDatabaseQA();
			}
			catch (Exception ex)
			{
				if(repo.SQLFailed.SelfInfo.Exists(new Duration(1000))) { repo.SQLFailed.OkButton.ClickThis(); }
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists(1000)) repo.FileModified.DiscardButton.ClickThis();
				if(repo.DropTable.SelfInfo.Exists(1000)) repo.DropTable.YesButton.ClickThis();
				DropDatabaseQA();
				throw new Exception("Failed : Execute TC10 : " + ex.Message);
			}
		}
		
		public static void ExecuteTC11()
		{
			try
			{
				ConnectServer();
				
				Preconditions.Steps.SelectedServerTreeItem.Collapse();
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				Preconditions.Steps.CreateDatabase();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				Reports.ReportLog("Create ads_db", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				if(Config.SchemaServers.Contains(Preconditions.Steps.SelectedServerName)) Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB_CAPS);
				else Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
				
				Preconditions.Steps.CreateTable();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				Reports.ReportLog("Create ads_table", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				TreeItem databaseItem = Preconditions.Steps.SelectedServerTreeItem.GetItem(databasesTree[0]);
				TreeItem adsdbItem = databaseItem.GetItem(Config.ADSDB);
				TreeItem publicItem = adsdbItem.GetItem("public");
				TreeItem tablesItem = publicItem.GetItem("Tables");
				TreeItem adstableItem = tablesItem.GetItem("public.ads_table");
				adstableItem.RightClick();
				repo.Datastudio1.ScriptWin1Info.WaitForItemExists(10000);
				repo.Datastudio1.ScriptWin1.ClickThis();
				repo.Datastudio2.CreateFull.ClickThis();
				
				tc10538Repo.Application.QATextEditorInfo.WaitForItemExists(120000);
				string query1 = "CREATE TABLE public.ads_table_new1(id int4 NULL, name varchar(256) NULL, project varchar(256) NULL, firstname varchar(256) NULL, lastname varchar(256) NULL)";
				Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Keyboard.Press(Keyboard.ToKey("Delete"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				tc10538Repo.Application.QATextEditor.PressKeys(query1);
				Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Preconditions.Steps.ClickQARun();
				System.Threading.Thread.Sleep(2000);
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists()) repo.FileModified.DiscardButton.ClickThis();
				Reports.ReportLog("ScriptWin1", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				adstableItem.RightClick();
				repo.Datastudio1.ScriptWin2.ClickThis();
				repo.Datastudio2.Update.ClickThis();
				
				tc10538Repo.Application.QATextEditorInfo.WaitForItemExists(120000);
				string query2 = "CREATE TABLE public.ads_table_new2(id int4 NULL, name varchar(256) NULL, project varchar(256) NULL, firstname varchar(256) NULL, lastname varchar(256) NULL)";
				Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Keyboard.Press(Keyboard.ToKey("Delete"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				tc10538Repo.Application.QATextEditor.PressKeys(query2);
				Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Preconditions.Steps.ClickQARun();
				System.Threading.Thread.Sleep(2000);
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists()) repo.FileModified.DiscardButton.ClickThis();
				Reports.ReportLog("ScriptWin2", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				adstableItem.RightClick();
				repo.Datastudio1.ScriptWin3.ClickThis();
				repo.Datastudio2.Update.ClickThis();
				
				Common.DeleteFile(TC_10547_PATH + "ads_db_Insert.sql");
				repo.SaveFile.SelfInfo.WaitForItemExists(12000);
				repo.SaveFile.FilePathTextbox.TextValue = TC_10547_PATH + "ads_db_Insert";
				repo.SaveFile.SaveButton.ClickThis();
				Common.DeleteFile(TC_10547_PATH + "ads_db_Insert.sql");
				Reports.ReportLog("ScriptWin3", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				tablesItem.RightClick();
				repo.Datastudio1.Refresh.ClickThis();
				
				adstableItem.RightClick();
				repo.Datastudio1.DropTable.ClickThis();
				if(repo.DropTable.SelfInfo.Exists()) repo.DropTable.YesButton.ClickThis();
				Reports.ReportLog("Drop ads_table done", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				TreeItem abstable1Item = tablesItem.GetItem("public.ads_table_new1");
				abstable1Item.RightClick();
				repo.Datastudio1.DropTable.ClickThis();
				if(repo.DropTable.SelfInfo.Exists()) repo.DropTable.YesButton.ClickThis();
				
				TreeItem abstable2Item = tablesItem.GetItem("public.ads_table_new2");
				abstable2Item.RightClick();
				repo.Datastudio1.DropTable.ClickThis();
				if(repo.DropTable.SelfInfo.Exists()) repo.DropTable.YesButton.ClickThis();
				Reports.ReportLog("Clean up done", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				DropDatabaseQA();
			}
			catch (Exception ex)
			{
				if(repo.SQLFailed.SelfInfo.Exists(new Duration(1000))) { repo.SQLFailed.OkButton.ClickThis(); }
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists(1000)) repo.FileModified.DiscardButton.ClickThis();
				if(repo.DropTable.SelfInfo.Exists(1000)) repo.DropTable.YesButton.ClickThis();
				
				DropDatabaseQA();
				throw new Exception("Failed : Execute TC11 : " + ex.Message);
			}
		}
		
		public static void ExecuteTC12()
		{
			try
			{
				ConnectServer();
				
				Preconditions.Steps.SelectedServerTreeItem.Collapse();
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				Preconditions.Steps.CreateDatabase();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				Reports.ReportLog("Create ads_db", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				if(Config.SchemaServers.Contains(Preconditions.Steps.SelectedServerName)) Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB_CAPS);
				else Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
				
				Preconditions.Steps.CreateTable();
				Preconditions.Steps.InsertTable();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				Reports.ReportLog("Create & Insert ads_table", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				TreeItem databaseItem = Preconditions.Steps.SelectedServerTreeItem.GetItem(databasesTree[0]);
				TreeItem adsdbItem = databaseItem.GetItem(Config.ADSDB);
				TreeItem publicItem = adsdbItem.GetItem("public");
				TreeItem tablesItem = publicItem.GetItem("Tables");
				TreeItem adstableItem = tablesItem.GetItem("public.ads_table");
				adstableItem.RightClick();
				repo.Datastudio1.ScriptWin1Info.WaitForItemExists(10000);
				repo.Datastudio1.ScriptWin1.ClickThis();
				repo.Datastudio2.Select.ClickThis();
				
				tc10538Repo.Application.QATextEditorInfo.WaitForItemExists(120000);
				string query = "Select * from ads_table";
				Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Keyboard.Press(Keyboard.ToKey("Delete"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				tc10538Repo.Application.QATextEditor.PressKeys(query);
				Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Preconditions.Steps.ClickQARun();
				System.Threading.Thread.Sleep(2000);
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists()) repo.FileModified.DiscardButton.ClickThis();
				Reports.ReportLog("ScriptWin1", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				adstableItem.RightClick();
				repo.Datastudio1.ScriptWin2.ClickThis();
				repo.Datastudio2.Select.ClickThis();
				
				tc10538Repo.Application.QATextEditorInfo.WaitForItemExists(120000);
				Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Keyboard.Press(Keyboard.ToKey("Delete"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				tc10538Repo.Application.QATextEditor.PressKeys(query);
				Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Preconditions.Steps.ClickQARun();
				System.Threading.Thread.Sleep(2000);
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists()) repo.FileModified.DiscardButton.ClickThis();
				Reports.ReportLog("ScriptWin2", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				adstableItem.RightClick();
				repo.Datastudio1.ScriptWin3.ClickThis();
				repo.Datastudio2.Select.ClickThis();
				
				Common.DeleteFile(TC_10547_PATH + "ads_db_Insert.sql");
				repo.SaveFile.SelfInfo.WaitForItemExists(12000);
				repo.SaveFile.FilePathTextbox.TextValue = TC_10547_PATH + "ads_db_Insert";
				repo.SaveFile.SaveButton.ClickThis();
				Common.DeleteFile(TC_10547_PATH + "ads_db_Insert.sql");
				Reports.ReportLog("ScriptWin3", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				tablesItem.RightClick();
				repo.Datastudio1.Refresh.ClickThis();
				
				adstableItem.RightClick();
				repo.Datastudio1.DropTable.ClickThis();
				if(repo.DropTable.SelfInfo.Exists()) repo.DropTable.YesButton.ClickThis();
				Reports.ReportLog("Drop ads_table done", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				DropDatabaseQA();
			}
			catch (Exception ex)
			{
				if(repo.SQLFailed.SelfInfo.Exists(new Duration(1000))) { repo.SQLFailed.OkButton.ClickThis(); }
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists(1000)) repo.FileModified.DiscardButton.ClickThis();
				if(repo.DropTable.SelfInfo.Exists(1000)) repo.DropTable.YesButton.ClickThis();
				DropDatabaseQA();
				throw new Exception("Failed : Execute TC12 : " + ex.Message);
			}
		}
		
		public static void ExecuteTC13()
		{
			try
			{
				ConnectServer();
				
				Preconditions.Steps.SelectedServerTreeItem.Collapse();
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				Preconditions.Steps.CreateDatabase();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				Reports.ReportLog("Create ads_db", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				if(Config.SchemaServers.Contains(Preconditions.Steps.SelectedServerName)) Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB_CAPS);
				else Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
				
				Preconditions.Steps.CreateTable();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				Reports.ReportLog("Create & Insert ads_table", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				TreeItem databaseItem = Preconditions.Steps.SelectedServerTreeItem.GetItem(databasesTree[0]);
				TreeItem adsdbItem = databaseItem.GetItem(Config.ADSDB);
				TreeItem publicItem = adsdbItem.GetItem("public");
				TreeItem tablesItem = publicItem.GetItem("Tables");
				TreeItem adstableItem = tablesItem.GetItem("public.ads_table");
				adstableItem.RightClick();
				repo.Datastudio1.ScriptWin1Info.WaitForItemExists(10000);
				repo.Datastudio1.ScriptWin1.ClickThis();
				repo.Datastudio2.Alter.ClickThis();
				
				tc10538Repo.Application.QATextEditorInfo.WaitForItemExists(120000);
				string query = "ALTER TABLE public.ads_table ADD COLUMN IsActive bool";
				Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Keyboard.Press(Keyboard.ToKey("Delete"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				tc10538Repo.Application.QATextEditor.PressKeys(query);
				Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Preconditions.Steps.ClickQARun();
				System.Threading.Thread.Sleep(2000);
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists()) repo.FileModified.DiscardButton.ClickThis();
				Reports.ReportLog("ScriptWin1", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				adstableItem.RightClick();
				repo.Datastudio1.ScriptWin2.ClickThis();
				repo.Datastudio2.Alter.ClickThis();
				
				tc10538Repo.Application.QATextEditorInfo.WaitForItemExists(120000);
				Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Keyboard.Press(Keyboard.ToKey("Delete"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				tc10538Repo.Application.QATextEditor.PressKeys(query);
				Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Preconditions.Steps.ClickQARun();
				System.Threading.Thread.Sleep(2000);
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists()) repo.FileModified.DiscardButton.ClickThis();
				Reports.ReportLog("ScriptWin2", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				adstableItem.RightClick();
				repo.Datastudio1.ScriptWin3.ClickThis();
				repo.Datastudio2.Alter.ClickThis();
				
				Common.DeleteFile(TC_10547_PATH + "ads_db_Insert.sql");
				repo.SaveFile.SelfInfo.WaitForItemExists(12000);
				repo.SaveFile.FilePathTextbox.TextValue = TC_10547_PATH + "ads_db_Insert";
				repo.SaveFile.SaveButton.ClickThis();
				Common.DeleteFile(TC_10547_PATH + "ads_db_Insert.sql");
				Reports.ReportLog("ScriptWin3", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				tablesItem.RightClick();
				repo.Datastudio1.Refresh.ClickThis();
				adstableItem.Expand();
				adstableItem.RightClick();
				repo.Datastudio1.DropTable.ClickThis();
				if(repo.DropTable.SelfInfo.Exists()) repo.DropTable.YesButton.ClickThis();
				Reports.ReportLog("Drop ads_table done", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				DropDatabaseQA();
			}
			catch (Exception ex)
			{
				if(repo.SQLFailed.SelfInfo.Exists(new Duration(1000))) { repo.SQLFailed.OkButton.ClickThis(); }
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists(1000)) repo.FileModified.DiscardButton.ClickThis();
				if(repo.DropTable.SelfInfo.Exists(1000)) repo.DropTable.YesButton.ClickThis();
				DropDatabaseQA();
				throw new Exception("Failed : Execute TC13 : " + ex.Message);
			}
		}
		
		public static void ExecuteTC14()
		{
			try
			{
				ConnectServer();
				
				Preconditions.Steps.SelectedServerTreeItem.Collapse();
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				Preconditions.Steps.CreateDatabase();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				Reports.ReportLog("Create ads_db", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				if(Config.SchemaServers.Contains(Preconditions.Steps.SelectedServerName)) Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB_CAPS);
				else Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
				
				Preconditions.Steps.CreateTable();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				Reports.ReportLog("Create & Insert ads_table", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				TreeItem databaseItem = Preconditions.Steps.SelectedServerTreeItem.GetItem(databasesTree[0]);
				TreeItem adsdbItem = databaseItem.GetItem(Config.ADSDB);
				TreeItem publicItem = adsdbItem.GetItem("public");
				TreeItem tablesItem = publicItem.GetItem("Tables");
				TreeItem adstableItem = tablesItem.GetItem("public.ads_table");
				adstableItem.RightClick();
				repo.Datastudio1.ScriptWin1Info.WaitForItemExists(10000);
				repo.Datastudio1.ScriptWin1.ClickThis();
				repo.Datastudio2.Drop.ClickThis();
				
				tc10538Repo.Application.QATextEditorInfo.WaitForItemExists(120000);
				string query = "DROP TABLE public.ads_table";
				Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Keyboard.Press(Keyboard.ToKey("Delete"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				tc10538Repo.Application.QATextEditor.PressKeys(query);
				Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Preconditions.Steps.ClickQARun();
				System.Threading.Thread.Sleep(2000);
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists()) repo.FileModified.DiscardButton.ClickThis();
				Reports.ReportLog("ScriptWin1", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				/*adstableItem.RightClick();
				repo.Datastudio.ScriptWin2.ClickThis();
				repo.Datastudio.Drop.ClickThis();
				
				tc10538Repo.Application.QATextEditorInfo.WaitForItemExists(120000);
				Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Keyboard.Press(Keyboard.ToKey("Delete"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				tc10538Repo.Application.QATextEditor.PressKeys(query);
				Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Preconditions.Steps.ClickQARun();
				System.Threading.Thread.Sleep(2000);
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists()) repo.FileModified.DiscardButton.ClickThis();
				Reports.ReportLog("ScriptWin2", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				adstableItem.RightClick();
				repo.Datastudio.ScriptWin3.ClickThis();
				repo.Datastudio.Drop.ClickThis();
				
				Common.DeleteFile(TC_10547_PATH + "ads_db_Insert.sql");
				repo.SaveFile.SelfInfo.WaitForItemExists(12000);
				repo.SaveFile.FilePathTextbox.TextValue = TC_10547_PATH + "ads_db_Insert";
				repo.SaveFile.SaveButton.ClickThis();
				Common.DeleteFile(TC_10547_PATH + "ads_db_Insert.sql");
				Reports.ReportLog("ScriptWin3", Reports.ADSReportLevel.Success, null, Config.TestCaseName);*/
				
				tablesItem.RightClick();
				repo.Datastudio1.Refresh.ClickThis();
				
				DropDatabaseQA();
			}
			catch (Exception ex)
			{
				if(repo.SQLFailed.SelfInfo.Exists(new Duration(1000))) { repo.SQLFailed.OkButton.ClickThis(); }
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists(1000)) repo.FileModified.DiscardButton.ClickThis();
				if(repo.DropTable.SelfInfo.Exists(1000)) repo.DropTable.YesButton.ClickThis();
				
				DropDatabaseQA();
				throw new Exception("Failed : Execute TC14 : " + ex.Message);
			}
		}
		
		public static void ExecuteTC15()
		{
			try
			{
				ConnectServer();
				
				Preconditions.Steps.SelectedServerTreeItem.Collapse();
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				Preconditions.Steps.CreateDatabase();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				Reports.ReportLog("Create ads_db", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				if(Config.SchemaServers.Contains(Preconditions.Steps.SelectedServerName)) Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB_CAPS);
				else Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
				
				Preconditions.Steps.CreateTable();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				Reports.ReportLog("Create & Insert ads_table", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				TreeItem databaseItem = Preconditions.Steps.SelectedServerTreeItem.GetItem(databasesTree[0]);
				TreeItem adsdbItem = databaseItem.GetItem(Config.ADSDB);
				TreeItem publicItem = adsdbItem.GetItem("public");
				TreeItem viewItem = publicItem.GetItem("Views");
				
				viewItem.RightClick();
				repo.Datastudio1.CreateViewInfo.WaitForItemExists(10000);
				repo.Datastudio1.CreateView.ClickThis();
				
				repo.Application.CreateView.ViewNameTextbox.TextBoxText("ads_view1");
				repo.Application.CreateView.SourceTextbox.Click();
				Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Keyboard.Press(Keyboard.ToKey("Delete"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				repo.Application.CreateView.SourceTextbox.PressKeys("as select * from ads_table");
				repo.Application.CreateView.CreateButton.ClickThis();
				
				viewItem.RightClick();
				repo.Datastudio1.CreateViewInfo.WaitForItemExists(10000);
				repo.Datastudio1.CreateView.ClickThis();
				
				repo.Application.CreateView.ViewNameTextbox.TextBoxText("ads_view2");
				repo.Application.CreateView.SourceTextbox.Click();
				Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Keyboard.Press(Keyboard.ToKey("Delete"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				repo.Application.CreateView.SourceTextbox.PressKeys("as select * from ads_table");
				repo.Application.CreateView.CreateButton.ClickThis();
				
				viewItem.RightClick();
				repo.Datastudio1.CreateViewInfo.WaitForItemExists(10000);
				repo.Datastudio1.CreateView.ClickThis();
				
				repo.Application.CreateView.ViewNameTextbox.TextBoxText("ads_view3");
				repo.Application.CreateView.SourceTextbox.Click();
				Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Keyboard.Press(Keyboard.ToKey("Delete"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				repo.Application.CreateView.SourceTextbox.PressKeys("as select * from ads_table");
				repo.Application.CreateView.CreateButton.ClickThis();
				
				viewItem.RightClick();
				repo.Datastudio1.Refresh.ClickThis();
				
				TreeItem adsviewitem1 = viewItem.GetItem("public.ads_view1");
				adsviewitem1.RightClick();
				repo.Datastudio1.ScriptWin1Info.WaitForItemExists(10000);
				repo.Datastudio1.ScriptWin1.ClickThis();
				repo.Datastudio2.Drop.ClickThis();
				tc10538Repo.Application.QATextEditorInfo.WaitForItemExists(120000);
				Preconditions.Steps.ClickQARun();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists()) repo.FileModified.DiscardButton.ClickThis();
				viewItem.RightClick();
				repo.Datastudio1.Refresh.ClickThis();
				Reports.ReportLog("ScriptWin1", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				TreeItem adsviewitem2 = viewItem.GetItem("public.ads_view2");
				adsviewitem2.RightClick();
				repo.Datastudio1.ScriptWin2Info.WaitForItemExists(10000);
				repo.Datastudio1.ScriptWin2.ClickThis();
				repo.Datastudio2.Drop.ClickThis();
				tc10538Repo.Application.QATextEditorInfo.WaitForItemExists(120000);
				Preconditions.Steps.ClickQARun();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists()) repo.FileModified.DiscardButton.ClickThis();
				viewItem.RightClick();
				repo.Datastudio1.Refresh.ClickThis();
				Reports.ReportLog("ScriptWin2", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				TreeItem adsviewitem3 = viewItem.GetItem("public.ads_view3");
				adsviewitem3.RightClick();
				repo.Datastudio1.ScriptWin3Info.WaitForItemExists(10000);
				repo.Datastudio1.ScriptWin3.ClickThis();
				repo.Datastudio2.Drop.ClickThis();
				Common.DeleteFile(TC_10547_PATH + "ads_db_Insert.sql");
				repo.SaveFile.SelfInfo.WaitForItemExists(12000);
				repo.SaveFile.FilePathTextbox.TextValue = TC_10547_PATH + "ads_db_Insert";
				repo.SaveFile.SaveButton.ClickThis();
				Common.DeleteFile(TC_10547_PATH + "ads_db_Insert.sql");
				adsviewitem3.RightClick();
				repo.Datastudio1.DropView.ClickThis();
				if(repo.DropView.SelfInfo.Exists()) repo.DropView.YesButton.ClickThis();
				Reports.ReportLog("ScriptWin3", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				viewItem.RightClick();
				repo.Datastudio1.Refresh.ClickThis();
				
				TreeItem tablesItem = publicItem.GetItem("Tables");
				TreeItem adstableItem = tablesItem.GetItem("public.ads_table");
				adstableItem.RightClick();
				repo.Datastudio1.DropTable.ClickThis();
				if(repo.DropTable.SelfInfo.Exists()) repo.DropTable.YesButton.ClickThis();
				Reports.ReportLog("Drop ads_table done", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				DropDatabaseQA();
			}
			catch (Exception ex)
			{
				
				if(repo.SQLFailed.SelfInfo.Exists(new Duration(1000))) { repo.SQLFailed.OkButton.ClickThis(); }
				
				if(repo.Application.CreateView.CreateCancelInfo.Exists(1000)) repo.Application.CreateView.CreateCancel.ClickThis();
				if(repo.DiscardView.SelfInfo.Exists(1000)) repo.DiscardView.Discard.ClickThis();
				
				if(repo.Application.CreateView.AlterCancelButtonInfo.Exists(1000)) repo.Application.CreateView.AlterCancelButton.ClickThis();
				if(repo.DiscardAlterView.SelfInfo.Exists(1000)) repo.DiscardAlterView.Discard.ClickThis();
				
				if(repo.DropView.SelfInfo.Exists(1000)) repo.DropView.YesButton.ClickThis();
				
				if(repo.DropTable.SelfInfo.Exists(1000)) repo.DropTable.YesButton.ClickThis();
				
				
				DropDatabaseQA();
				throw new Exception("Failed : Execute TC15 : " + ex.Message);
			}
		}
		
		public static void ExecuteTC16()
		{
			try
			{
				ConnectServer();
				
				Preconditions.Steps.SelectedServerTreeItem.Collapse();
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				Preconditions.Steps.CreateDatabase();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				Reports.ReportLog("Create ads_db", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				if(Config.SchemaServers.Contains(Preconditions.Steps.SelectedServerName)) Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB_CAPS);
				else Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
				
				Preconditions.Steps.CreateTableWithConstraints();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				Reports.ReportLog("Create ads_table", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				TreeItem databaseItem = Preconditions.Steps.SelectedServerTreeItem.GetItem(databasesTree[0]);
				TreeItem adsdbItem = databaseItem.GetItem(Config.ADSDB);
				TreeItem publicItem = adsdbItem.GetItem("public");
				TreeItem consItem = publicItem.GetItem("Constraints");
				TreeItem adsconsItem = consItem.GetItem("ads_table_pkey [public.ads_table]");
				
				System.Threading.Thread.Sleep(1000);
				
				adsconsItem.RightClick();
				repo.Datastudio1.ScriptObjectToFileInfo.WaitForItemExists(10000);
				repo.Datastudio1.ScriptObjectToWindow.ClickThis();
				repo.Datastudio2.Drop.ClickThis();
				tc10538Repo.Application.QATextEditorInfo.WaitForItemExists(120000);
				Preconditions.Steps.ClickQARun();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists()) repo.FileModified.DiscardButton.ClickThis();
				
				System.Threading.Thread.Sleep(1000);
				
				consItem.RightClick();
				repo.Datastudio1.Refresh.ClickThis();
				
				TreeItem tablesItem = publicItem.GetItem("Tables");
				TreeItem adstableItem = tablesItem.GetItem("public.ads_table");
				adstableItem.RightClick();
				repo.Datastudio1.DropTable.ClickThis();
				if(repo.DropTable.SelfInfo.Exists()) repo.DropTable.YesButton.ClickThis();
				Reports.ReportLog("Drop ads_table done", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				Preconditions.Steps.DisconnectServer();
				
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				if(Config.SchemaServers.Contains(Preconditions.Steps.SelectedServerName)) Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB_CAPS);
				else Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
				
				Preconditions.Steps.CreateTableWithConstraints();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				Reports.ReportLog("Create ads_table", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				Preconditions.Steps.ConnectServer();
				TreeItem databaseItem1 = Preconditions.Steps.SelectedServerTreeItem.GetItem(databasesTree[0]);
				TreeItem adsdbItem1 = databaseItem1.GetItem(Config.ADSDB);
				TreeItem publicItem1 = adsdbItem1.GetItem("public");
				TreeItem consItem1 = publicItem1.GetItem("Constraints");
				TreeItem adsconsItem1 = consItem1.GetItem("ads_table_pkey [public.ads_table]");
				adsconsItem1.RightClick();
				repo.Datastudio1.ScriptWin2Info.WaitForItemExists(10000);
				repo.Datastudio1.ScriptWin2.ClickThis();
				repo.Datastudio2.Drop.ClickThis();
				tc10538Repo.Application.QATextEditorInfo.WaitForItemExists(120000);
				Preconditions.Steps.ClickQARun();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists()) repo.FileModified.DiscardButton.ClickThis();
				
				consItem.RightClick();
				repo.Datastudio1.Refresh.ClickThis();
				
				tablesItem = publicItem.GetItem("Tables");
				adstableItem = tablesItem.GetItem("public.ads_table");
				adstableItem.RightClick();
				repo.Datastudio1.DropTable.ClickThis();
				if(repo.DropTable.SelfInfo.Exists()) repo.DropTable.YesButton.ClickThis();
				Reports.ReportLog("Drop ads_table done", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				DropDatabaseQA();
			}
			catch (Exception ex)
			{
				if(repo.SQLFailed.SelfInfo.Exists(new Duration(1000))) { repo.SQLFailed.OkButton.ClickThis(); }
				
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists(1000)) repo.FileModified.DiscardButton.ClickThis();
				
				if(repo.DropTable.SelfInfo.Exists(1000)) repo.DropTable.YesButton.ClickThis();
				
				DropDatabaseQA();
				throw new Exception("Failed : Execute TC16 : " + ex.Message);
			}
		}
		
		public static void ExecuteTC17()
		{
			try
			{
				ConnectServer();
				
				Preconditions.Steps.SelectedServerTreeItem.Collapse();
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				Preconditions.Steps.CreateDatabase();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				Reports.ReportLog("Create ads_db", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				if(Config.SchemaServers.Contains(Preconditions.Steps.SelectedServerName)) Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB_CAPS);
				else Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
				
				Preconditions.Steps.CreateTable();
				Preconditions.Steps.CreateTrigger();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				Reports.ReportLog("Create ads_table", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				TreeItem databaseItem = Preconditions.Steps.SelectedServerTreeItem.GetItem(databasesTree[2]);
				TreeItem adsdbItem = databaseItem.GetItem(Config.ADSDB_CAPS);
				TreeItem triggersItem = adsdbItem.GetItem("Triggers");
				TreeItem adstriggerItem = triggersItem.GetItem("ADS_TRIGGER [ADS_TABLE]");
				adstriggerItem.RightClick();
				repo.Datastudio1.ScriptWin1Info.WaitForItemExists(10000);
				repo.Datastudio1.ScriptWin1.ClickThis();
				repo.Datastudio2.Drop.ClickThis();
				tc10538Repo.Application.QATextEditorInfo.WaitForItemExists(120000);
				Preconditions.Steps.ClickQARun();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists()) repo.FileModified.DiscardButton.ClickThis();
				triggersItem.RightClick();
				repo.Datastudio1.Refresh.ClickThis();
				
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				if(Config.SchemaServers.Contains(Preconditions.Steps.SelectedServerName)) Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB_CAPS);
				else Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
				Preconditions.Steps.CreateTrigger();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				triggersItem.RightClick();
				repo.Datastudio1.Refresh.ClickThis();
				Reports.ReportLog("Create ads_table", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				databaseItem = Preconditions.Steps.SelectedServerTreeItem.GetItem(databasesTree[2]);
				adsdbItem = databaseItem.GetItem(Config.ADSDB_CAPS);
				triggersItem = adsdbItem.GetItem("Triggers");
				adstriggerItem = triggersItem.GetItem("ADS_TRIGGER [ADS_TABLE]");
				adstriggerItem.RightClick();
				repo.Datastudio1.ScriptWin2Info.WaitForItemExists(10000);
				repo.Datastudio1.ScriptWin2.ClickThis();
				repo.Datastudio2.Drop.ClickThis();
				tc10538Repo.Application.QATextEditorInfo.WaitForItemExists(120000);
				Preconditions.Steps.ClickQARun();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists()) repo.FileModified.DiscardButton.ClickThis();
				triggersItem.RightClick();
				repo.Datastudio1.Refresh.ClickThis();
				
				TreeItem tablesItem = adsdbItem.GetItem("Tables");
				TreeItem adstableItem = tablesItem.GetItem("ADS_TABLE");
				adstableItem.RightClick();
				repo.Datastudio1.DropTable.ClickThis();
				if(repo.DropTable.SelfInfo.Exists()) repo.DropTable.YesButton.ClickThis();
				
				DropDatabaseQA();
			}
			catch (Exception ex)
			{
				
				if(repo.SQLFailed.SelfInfo.Exists(new Duration(1000))) { repo.SQLFailed.OkButton.ClickThis(); }
				
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists(1000)) repo.FileModified.DiscardButton.ClickThis();
				
				if(repo.DropTable.SelfInfo.Exists(1000)) repo.DropTable.YesButton.ClickThis();
				
				DropDatabaseQA();
				throw new Exception("Failed : Execute TC17 : " + ex.Message);
			}
		}
		
		public static void ExecuteTC18()
		{
			try
			{
				ConnectServer();
				
				Preconditions.Steps.SelectedServerTreeItem.Collapse();
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				Preconditions.Steps.CreateDatabase();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				Reports.ReportLog("Create ads_db", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				if(Config.SchemaServers.Contains(Preconditions.Steps.SelectedServerName)) Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB_CAPS);
				else Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
				
				Preconditions.Steps.CreateTable();
				Preconditions.Steps.CreateProcedure();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				Reports.ReportLog("Create ads_table", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				TreeItem databaseItem = Preconditions.Steps.SelectedServerTreeItem.GetItem(databasesTree[2]);
				TreeItem adsdbItem = databaseItem.GetItem(Config.ADSDB_CAPS);
				TreeItem proceduresItem = adsdbItem.GetItem("Procedures");
				TreeItem adsprocedureItem = proceduresItem.GetItem("ADS_DB.ADS_PROCEDURE");
				adsprocedureItem.RightClick();
				repo.Datastudio1.ScriptWin1Info.WaitForItemExists(10000);
				repo.Datastudio1.ScriptWin1.ClickThis();
				repo.Datastudio2.Drop.ClickThis();
				tc10538Repo.Application.QATextEditorInfo.WaitForItemExists(120000);
				Preconditions.Steps.ClickQARun();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists()) repo.FileModified.DiscardButton.ClickThis();
				proceduresItem.RightClick();
				repo.Datastudio1.Refresh.ClickThis();
				
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				if(Config.SchemaServers.Contains(Preconditions.Steps.SelectedServerName)) Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB_CAPS);
				else Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
				Preconditions.Steps.CreateProcedure();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				proceduresItem.RightClick();
				repo.Datastudio1.Refresh.ClickThis();
				Reports.ReportLog("Create ads_table", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				databaseItem = Preconditions.Steps.SelectedServerTreeItem.GetItem(databasesTree[2]);
				adsdbItem = databaseItem.GetItem(Config.ADSDB_CAPS);
				proceduresItem = adsdbItem.GetItem("Procedures");
				adsprocedureItem = proceduresItem.GetItem("ADS_DB.ADS_PROCEDURE");
				adsprocedureItem.RightClick();
				repo.Datastudio1.ScriptWin2Info.WaitForItemExists(10000);
				repo.Datastudio1.ScriptWin2.ClickThis();
				repo.Datastudio2.Drop.ClickThis();
				tc10538Repo.Application.QATextEditorInfo.WaitForItemExists(120000);
				Preconditions.Steps.ClickQARun();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists()) repo.FileModified.DiscardButton.ClickThis();
				proceduresItem.RightClick();
				repo.Datastudio1.Refresh.ClickThis();
				
				TreeItem tablesItem = adsdbItem.GetItem("Tables");
				TreeItem adstableItem = tablesItem.GetItem("ADS_DB.ADS_TABLE");
				adstableItem.RightClick();
				repo.Datastudio1.DropTable.ClickThis();
				if(repo.DropTable.SelfInfo.Exists()) repo.DropTable.YesButton.ClickThis();
				
				DropDatabaseQA();
			}
			catch (Exception ex)
			{
				
				if(repo.SQLFailed.SelfInfo.Exists(new Duration(1000))) { repo.SQLFailed.OkButton.ClickThis(); }
				
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists(1000)) repo.FileModified.DiscardButton.ClickThis();
				
				if(repo.DropTable.SelfInfo.Exists(1000)) repo.DropTable.YesButton.ClickThis();
				
				DropDatabaseQA();
				throw new Exception("Failed : Execute TC18 : " + ex.Message);
			}
		}
		
		public static void ExecuteTC19()
		{
			try
			{
				ConnectServer();
				
				Preconditions.Steps.SelectedServerTreeItem.Collapse();
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				Preconditions.Steps.CreateDatabase();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				Reports.ReportLog("Create ads_db", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				if(Config.SchemaServers.Contains(Preconditions.Steps.SelectedServerName)) Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB_CAPS);
				else Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
				
				Preconditions.Steps.CreateTable();
				Preconditions.Steps.CreateFunction();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				Reports.ReportLog("Create ads_table", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				TreeItem databaseItem = Preconditions.Steps.SelectedServerTreeItem.GetItem(databasesTree[2]);
				TreeItem adsdbItem = databaseItem.GetItem(Config.ADSDB_CAPS);
				TreeItem functionsItem = adsdbItem.GetItem("Functions");
				TreeItem adsfunctionItem = functionsItem.GetItem("ADS_DB.ADS_FUNCTION");
				adsfunctionItem.RightClick();
				repo.Datastudio1.ScriptWin1Info.WaitForItemExists(10000);
				repo.Datastudio1.ScriptWin1.ClickThis();
				repo.Datastudio2.Drop.ClickThis();
				tc10538Repo.Application.QATextEditorInfo.WaitForItemExists(120000);
				Preconditions.Steps.ClickQARun();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists()) repo.FileModified.DiscardButton.ClickThis();
				functionsItem.RightClick();
				repo.Datastudio1.Refresh.ClickThis();
				
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				if(Config.SchemaServers.Contains(Preconditions.Steps.SelectedServerName)) Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB_CAPS);
				else Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
				Preconditions.Steps.CreateFunction();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				functionsItem.RightClick();
				repo.Datastudio1.Refresh.ClickThis();
				Reports.ReportLog("Create ads_table", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				databaseItem = Preconditions.Steps.SelectedServerTreeItem.GetItem(databasesTree[2]);
				adsdbItem = databaseItem.GetItem(Config.ADSDB_CAPS);
				functionsItem = adsdbItem.GetItem("Functions");
				adsfunctionItem = functionsItem.GetItem("ADS_DB.ADS_FUNCTION");
				adsfunctionItem.RightClick();
				repo.Datastudio1.ScriptWin2Info.WaitForItemExists(10000);
				repo.Datastudio1.ScriptWin2.ClickThis();
				repo.Datastudio2.Drop.ClickThis();
				tc10538Repo.Application.QATextEditorInfo.WaitForItemExists(120000);
				Preconditions.Steps.ClickQARun();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists()) repo.FileModified.DiscardButton.ClickThis();
				functionsItem.RightClick();
				repo.Datastudio1.Refresh.ClickThis();
				
				TreeItem tablesItem = adsdbItem.GetItem("Tables");
				TreeItem adstableItem = tablesItem.GetItem("ADS_DB.ADS_TABLE");
				adstableItem.RightClick();
				repo.Datastudio1.DropTable.ClickThis();
				if(repo.DropTable.SelfInfo.Exists()) repo.DropTable.YesButton.ClickThis();
				
				DropDatabaseQA();
			}
			catch (Exception ex)
			{
				
				if(repo.SQLFailed.SelfInfo.Exists(new Duration(1000))) { repo.SQLFailed.OkButton.ClickThis(); }
				
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists(1000)) repo.FileModified.DiscardButton.ClickThis();
				
				if(repo.DropTable.SelfInfo.Exists(1000)) repo.DropTable.YesButton.ClickThis();
				
				DropDatabaseQA();
				throw new Exception("Failed : Execute TC18 : " + ex.Message);
			}
		}
		
		public static void ExecuteTC20()
		{
			try
			{
				ConnectServer();
				
				Preconditions.Steps.SelectedServerTreeItem.Collapse();
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				Preconditions.Steps.CreateDatabase();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				Reports.ReportLog("Create ads_db", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				if(Config.SchemaServers.Contains(Preconditions.Steps.SelectedServerName)) Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB_CAPS);
				else Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
				
				Preconditions.Steps.CreateTable();
				Preconditions.Steps.CreateEvent();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				Reports.ReportLog("Create ads_table", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				TreeItem databaseItem = Preconditions.Steps.SelectedServerTreeItem.GetItem(databasesTree[0]);
				TreeItem adsdbItem = databaseItem.GetItem(Config.ADSDB);
				TreeItem eventsItem = adsdbItem.GetItem("Events");
				TreeItem adseventItem = eventsItem.GetItem("ads_event");
				System.Threading.Thread.Sleep(1000);
				
				adseventItem.RightClick();
				repo.Datastudio1.ScriptWin1Info.WaitForItemExists(10000);
				repo.Datastudio1.ScriptWin1.ClickThis();
				repo.Datastudio2.Drop.ClickThis();
				tc10538Repo.Application.QATextEditorInfo.WaitForItemExists(120000);
				Preconditions.Steps.ClickQARun();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists()) repo.FileModified.DiscardButton.ClickThis();
				
				System.Threading.Thread.Sleep(1000);
				eventsItem.RightClick();
				repo.Datastudio1.Refresh.ClickThis();
				
				System.Threading.Thread.Sleep(1000);
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				if(Config.SchemaServers.Contains(Preconditions.Steps.SelectedServerName)) Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB_CAPS);
				else Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
				
				Preconditions.Steps.CreateEvent();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				Reports.ReportLog("Create ads_Event", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				System.Threading.Thread.Sleep(1000);
				eventsItem.RightClick();
				repo.Datastudio1.Refresh.ClickThis();
				
				databaseItem = Preconditions.Steps.SelectedServerTreeItem.GetItem(databasesTree[0]);
				adsdbItem = databaseItem.GetItem(Config.ADSDB);
				eventsItem = adsdbItem.GetItem("Events");
				adseventItem = eventsItem.GetItem("ads_event");
				System.Threading.Thread.Sleep(1000);
				adseventItem.RightClick();
				repo.Datastudio1.ScriptWin2Info.WaitForItemExists(10000);
				repo.Datastudio1.ScriptWin2.ClickThis();
				repo.Datastudio2.Drop.ClickThis();
				tc10538Repo.Application.QATextEditorInfo.WaitForItemExists(120000);
				Preconditions.Steps.ClickQARun();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists()) repo.FileModified.DiscardButton.ClickThis();
				System.Threading.Thread.Sleep(1000);
				eventsItem.RightClick();
				repo.Datastudio1.Refresh.ClickThis();
				
				TreeItem tablesItem = adsdbItem.GetItem("Tables");
				TreeItem adstableItem = tablesItem.GetItem("ads_table");
				adstableItem.RightClick();
				repo.Datastudio1.DropTable.ClickThis();
				if(repo.DropTable.SelfInfo.Exists()) repo.DropTable.YesButton.ClickThis();
				Reports.ReportLog("Drop ads_table done", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				DropDatabaseQA();
			}
			catch (Exception ex)
			{
				
				if(repo.SQLFailed.SelfInfo.Exists(new Duration(1000))) { repo.SQLFailed.OkButton.ClickThis(); }
				
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists(1000)) repo.FileModified.DiscardButton.ClickThis();
				
				if(repo.DropTable.SelfInfo.Exists(1000)) repo.DropTable.YesButton.ClickThis();
				
				DropDatabaseQA();
				throw new Exception("Failed : Execute TC20 : " + ex.Message);
			}
		}
		
		public static void ExecuteTC21()
		{
			try
			{
				ConnectServer();
				TreeItem securityItem = Preconditions.Steps.SelectedServerTreeItem.GetItem("Security");
				TreeItem rolesItem = securityItem.GetItem("Roles");
				TreeItem checkadsroleitem = rolesItem.GetItem("ads_role@%");
				if(checkadsroleitem != null)
				{
					checkadsroleitem.RightClick();
					repo.Datastudio1.DropRole.ClickThis();
					if(repo.DropRole.SelfInfo.Exists(5000)) repo.DropRole.YesButton.ClickThis();
				}
				
				rolesItem.RightClick();
				repo.Datastudio1.CreateRoleInfo.WaitForItemExists(10000);
				repo.Datastudio1.CreateRole.ClickThis();
				
				repo.Application.Roles.NewRoleTextboxInfo.WaitForItemExists(10000);
				repo.Application.Roles.NewRoleTextbox.TextBoxText("ads_role");
				repo.Application.Roles.CreateButton.ClickThis();
				if(repo.SQLFailed.OkButtonInfo.Exists(5000)){ repo.SQLFailed.OkButton.ClickThis(); Preconditions.Steps.CloseTab(Config.TestCaseName);}
				rolesItem.RightClick();
				repo.Datastudio1.Refresh.ClickThis();
				TreeItem adsroleItem = rolesItem.GetItem("ads_role@%");
				adsroleItem.RightClick();
				repo.Datastudio1.ScriptWin1Info.WaitForItemExists(10000);
				repo.Datastudio1.ScriptWin1.ClickThis();
				repo.Datastudio2.Drop.ClickThis();
				tc10538Repo.Application.QATextEditorInfo.WaitForItemExists(30000);
				Preconditions.Steps.ClickQARun();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists()) repo.FileModified.DiscardButton.ClickThis();
				
				rolesItem.RightClick();
				repo.Datastudio1.Refresh.ClickThis();
				
				TreeItem Verifyadsroleitem = rolesItem.GetItem("ads_role@%");
				if(Verifyadsroleitem != null)
				{
					Verifyadsroleitem.RightClick();
					repo.Datastudio1.DropRole.ClickThis();
					if(repo.DropRole.SelfInfo.Exists(5000)) repo.DropRole.YesButton.ClickThis();
				}
				
				rolesItem = securityItem.GetItem("Roles");
				rolesItem.RightClick();
				repo.Datastudio1.CreateRoleInfo.WaitForItemExists(10000);
				repo.Datastudio1.CreateRole.ClickThis();
				repo.Application.Roles.NewRoleTextboxInfo.WaitForItemExists(10000);
				repo.Application.Roles.NewRoleTextbox.TextBoxText("ads_role");
				repo.Application.Roles.CreateButton.ClickThis();
				if(repo.SQLFailed.OkButtonInfo.Exists(5000)){ repo.SQLFailed.OkButton.ClickThis(); Preconditions.Steps.CloseTab(Config.TestCaseName); if(repo.FileModified.SelfInfo.Exists(1000)) repo.FileModified.DiscardButton.ClickThis(); }
				rolesItem.RightClick();
				repo.Datastudio1.Refresh.ClickThis();
				
				adsroleItem = rolesItem.GetItem("ads_role@%");
				adsroleItem.RightClick();
				repo.Datastudio1.ScriptWin2Info.WaitForItemExists(10000);
				repo.Datastudio1.ScriptWin2.ClickThis();
				repo.Datastudio2.Drop.ClickThis();
				tc10538Repo.Application.QATextEditorInfo.WaitForItemExists(120000);
				Preconditions.Steps.ClickQARun();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists()) repo.FileModified.DiscardButton.ClickThis();
				rolesItem.RightClick();
				repo.Datastudio1.Refresh.ClickThis();
				
				TreeItem Verifyadsroleitem1 = rolesItem.GetItem("ads_role@%");
				if(Verifyadsroleitem1 != null)
				{
					Verifyadsroleitem1.RightClick();
					repo.Datastudio1.DropRole.ClickThis();
					if(repo.DropRole.SelfInfo.Exists(5000)) repo.DropRole.YesButton.ClickThis();
				}
				
				Preconditions.Steps.SelectedServerTreeItem.RightClick();
				Preconditions.Steps.DisconnectServer();
			}
			catch (Exception ex)
			{
				
				if(repo.SQLFailed.SelfInfo.Exists(new Duration(1000))) { repo.SQLFailed.OkButton.ClickThis(); }
				
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists(1000)) repo.FileModified.DiscardButton.ClickThis();
				
				if(repo.DropTable.SelfInfo.Exists(1000)) repo.DropTable.YesButton.ClickThis();
				
				throw new Exception("Failed : Execute TC21 : " + ex.Message);
			}
		}
		
		public static void ExecuteTC22()
		{
			try
			{
				ConnectServer();
				TreeItem securityItem = Preconditions.Steps.SelectedServerTreeItem.GetItem("Security");
				TreeItem usersItem = securityItem.GetItem("Users");
				TreeItem adsuserItem1 = usersItem.GetItem("ads_user@%");
				
				if(adsuserItem1 != null)
				{
					adsuserItem1.RightClick();
					repo.Datastudio1.ScriptWin1Info.WaitForItemExists(10000);
					repo.Datastudio1.ScriptWin1.ClickThis();
					repo.Datastudio2.Drop.ClickThis();
					tc10538Repo.Application.QATextEditorInfo.WaitForItemExists(120000);
					Preconditions.Steps.ClickQARun();
					Preconditions.Steps.CloseTab(Config.TestCaseName);
					if(repo.FileModified.SelfInfo.Exists()) repo.FileModified.DiscardButton.ClickThis();
					usersItem.RightClick();
					repo.Datastudio1.Refresh.ClickThis();
				}
				
				usersItem.RightClick();
				repo.Datastudio1.CreateUserInfo.WaitForItemExists(10000);
				repo.Datastudio1.CreateUser.ClickThis();
				
				repo.Application.Users.NewUserTextboxInfo.WaitForItemExists(10000);
				repo.Application.Users.NewUserTextbox.TextBoxText("ads_user");
				repo.Application.Users.PasswordTextbox.TextBoxText("ads_user");
				repo.Application.Users.ConfirmPasswordTextbox.TextBoxText("ads_user");
				repo.Application.Users.CreateButton.ClickThis();
				usersItem.RightClick();
				repo.Datastudio1.Refresh.ClickThis();
				
				TreeItem adsuserItem = usersItem.GetItem("ads_user@%");
				adsuserItem.RightClick();
				repo.Datastudio1.ScriptWin1Info.WaitForItemExists(10000);
				repo.Datastudio1.ScriptWin1.ClickThis();
				repo.Datastudio2.Drop.ClickThis();
				tc10538Repo.Application.QATextEditorInfo.WaitForItemExists(120000);
				Preconditions.Steps.ClickQARun();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists()) repo.FileModified.DiscardButton.ClickThis();
				
				usersItem.RightClick();
				repo.Datastudio1.Refresh.ClickThis();
				
				usersItem = securityItem.GetItem("Users");
				usersItem.RightClick();
				repo.Datastudio1.CreateUserInfo.WaitForItemExists(10000);
				repo.Datastudio1.CreateUser.ClickThis();
				repo.Application.Users.NewUserTextboxInfo.WaitForItemExists(10000);
				repo.Application.Users.NewUserTextbox.TextBoxText("ads_user");
				repo.Application.Users.PasswordTextbox.TextBoxText("ads_user");
				repo.Application.Users.ConfirmPasswordTextbox.TextBoxText("ads_user");
				repo.Application.Users.CreateButton.ClickThis();
				
				usersItem.RightClick();
				repo.Datastudio1.Refresh.ClickThis();
				
				adsuserItem = usersItem.GetItem("ads_user@%");
				adsuserItem.RightClick();
				repo.Datastudio1.ScriptWin2Info.WaitForItemExists(10000);
				repo.Datastudio1.ScriptWin2.ClickThis();
				repo.Datastudio2.Drop.ClickThis();
				tc10538Repo.Application.QATextEditorInfo.WaitForItemExists(120000);
				Preconditions.Steps.ClickQARun();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists()) repo.FileModified.DiscardButton.ClickThis();
				usersItem.RightClick();
				repo.Datastudio1.Refresh.ClickThis();
				Preconditions.Steps.SelectedServerTreeItem.RightClick();
				Preconditions.Steps.DisconnectServer();
			}
			catch (Exception ex)
			{
				
				if(repo.SQLFailed.SelfInfo.Exists(new Duration(1000))) { repo.SQLFailed.OkButton.ClickThis(); }
				
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists(1000)) repo.FileModified.DiscardButton.ClickThis();
				
				if(repo.DropTable.SelfInfo.Exists(1000)) repo.DropTable.YesButton.ClickThis();
				
				throw new Exception("Failed : Execute TC22 : " + ex.Message);
			}
		}
		
		public static void ExecuteTC23()
		{
			try
			{
				ConnectServer();
				
				Preconditions.Steps.SelectedServerTreeItem.Collapse();
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				Preconditions.Steps.CreateDatabase();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				Reports.ReportLog("Create ads_db", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				if(Config.SchemaServers.Contains(Preconditions.Steps.SelectedServerName)) Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB_CAPS);
				else Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
				
				Preconditions.Steps.CreateTable();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				Reports.ReportLog("Create ads_table", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				TreeItem securityItem = Preconditions.Steps.SelectedServerTreeItem.GetItem(databasesTree[1]);
				TreeItem adsdbItem = securityItem.GetItem(Config.ADSDB);
				TreeItem tablesItem = adsdbItem.GetItem("Tables");
				TreeItem adstableItem = tablesItem.GetItem("ads_db.ads_table");
				adstableItem.RightClick();
				
				repo.Datastudio1.ScriptWin1Info.WaitForItemExists(10000);
				repo.Datastudio1.ScriptWin1.ClickThis();
				repo.Datastudio2.Grant.ClickThis();
				tc10538Repo.Application.QATextEditorInfo.WaitForItemExists(120000);
				Preconditions.Steps.ClickQARun();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists()) repo.FileModified.DiscardButton.ClickThis();
				
				adstableItem.RightClick();
				repo.Datastudio1.ScriptWin2Info.WaitForItemExists(10000);
				repo.Datastudio1.ScriptWin2.ClickThis();
				repo.Datastudio2.Grant.ClickThis();
				tc10538Repo.Application.QATextEditorInfo.WaitForItemExists(120000);
				Preconditions.Steps.ClickQARun();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists()) repo.FileModified.DiscardButton.ClickThis();
				
				Preconditions.Steps.SelectedServerTreeItem.RightClick();
				Preconditions.Steps.DisconnectServer();
				Preconditions.Steps.QueryAnalyser();
				if(Config.SchemaServers.Contains(Preconditions.Steps.SelectedServerName)) Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB_CAPS);
				else Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
				Preconditions.Steps.DropTable();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				
				DropDatabaseQA();
			}
			catch (Exception ex)
			{
				
				if(repo.SQLFailed.SelfInfo.Exists(new Duration(1000))) { repo.SQLFailed.OkButton.ClickThis(); }
				
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists(1000)) repo.FileModified.DiscardButton.ClickThis();
				
				if(repo.DropTable.SelfInfo.Exists(1000)) repo.DropTable.YesButton.ClickThis();
				
				DropDatabaseQA();
				
				throw new Exception("Failed : Execute TC23 : " + ex.Message);
			}
		}
		
		public static void ExecuteTC24()
		{
			try
			{
				ConnectServer();
				
				Preconditions.Steps.SelectedServerTreeItem.Collapse();
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				Preconditions.Steps.CreateDatabase();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				Reports.ReportLog("Create ads_db", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				if(Config.SchemaServers.Contains(Preconditions.Steps.SelectedServerName)) Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB_CAPS);
				else Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
				
				Preconditions.Steps.CreateTable();
				Preconditions.Steps.CreateView();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				Reports.ReportLog("Create & View ads_table", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				TreeItem securityItem = Preconditions.Steps.SelectedServerTreeItem.GetItem(databasesTree[2]);
				TreeItem adsdbItem = securityItem.GetItem(Config.ADSDB_CAPS);
				TreeItem viewsItem = adsdbItem.GetItem("Views");
				TreeItem adsviewItem = viewsItem.GetItem("ADS_VIEW");
				adsviewItem.RightClick();
				
				repo.Datastudio1.ScriptWin1Info.WaitForItemExists(10000);
				repo.Datastudio1.ScriptWin1.ClickThis();
				repo.Datastudio2.Grant.ClickThis();
				tc10538Repo.Application.QATextEditorInfo.WaitForItemExists(120000);
				Preconditions.Steps.ClickQARun();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				//if(repo.FileModified.SelfInfo.Exists()) repo.FileModified.DiscardButton.ClickThis();
				Reports.ReportLog("Script Window 1 success", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				adsviewItem.RightClick();
				repo.Datastudio1.ScriptWin2Info.WaitForItemExists(10000);
				repo.Datastudio1.ScriptWin2.ClickThis();
				repo.Datastudio2.Grant.ClickThis();
				tc10538Repo.Application.QATextEditorInfo.WaitForItemExists(120000);
				Preconditions.Steps.ClickQARun();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				//if(repo.FileModified.SelfInfo.Exists()) repo.FileModified.DiscardButton.ClickThis();
				Reports.ReportLog("Script Window 2 success", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				Preconditions.Steps.SelectedServerTreeItem.Collapse();
				Preconditions.Steps.SelectedServerTreeItem.RightClick();
				Preconditions.Steps.QueryAnalyser();
				if(Config.SchemaServers.Contains(Preconditions.Steps.SelectedServerName)) Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB_CAPS);
				else Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
				Preconditions.Steps.DropView();
				Reports.ReportLog("Cleanup : drop view", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				Preconditions.Steps.DropTable();
				Reports.ReportLog("Cleanup : drop table", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				
				DropDatabaseQA();
			}
			catch (Exception ex)
			{
				
				if(repo.SQLFailed.SelfInfo.Exists(new Duration(1000))) { repo.SQLFailed.OkButton.ClickThis(); }
				
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists(1000)) repo.FileModified.DiscardButton.ClickThis();
				
				if(repo.DropTable.SelfInfo.Exists(1000)) repo.DropTable.YesButton.ClickThis();
				
				DropDatabaseQA();
				
				throw new Exception("Failed : Execute TC24 : " + ex.Message);
			}
		}
		
		public static void ExecuteTC25()
		{
			try
			{
				ConnectServer();
				
				Preconditions.Steps.SelectedServerTreeItem.Collapse();
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				Preconditions.Steps.CreateDatabase();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				Reports.ReportLog("Create ads_db", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				if(Config.SchemaServers.Contains(Preconditions.Steps.SelectedServerName)) Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB_CAPS);
				else Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
				
				Preconditions.Steps.CreateTable();
				Preconditions.Steps.CreateProcedure();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				Reports.ReportLog("Create & procedure ads_table", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				TreeItem securityItem = Preconditions.Steps.SelectedServerTreeItem.GetItem(databasesTree[2]);
				TreeItem adsdbItem = securityItem.GetItem(Config.ADSDB_CAPS);
				TreeItem proceduresItem = adsdbItem.GetItem("Stored Procedures");
				TreeItem adsprocedureItem = proceduresItem.GetItem("ADS_PROCEDURE");
				adsprocedureItem.RightClick();
				
				repo.Datastudio1.ScriptWin1Info.WaitForItemExists(10000);
				repo.Datastudio1.ScriptWin1.ClickThis();
				repo.Datastudio2.Grant.ClickThis();
				tc10538Repo.Application.QATextEditorInfo.WaitForItemExists(120000);
				Preconditions.Steps.ClickQARun();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists()) repo.FileModified.DiscardButton.ClickThis();
				Reports.ReportLog("Script Window 1 success", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				adsprocedureItem.RightClick();
				repo.Datastudio1.ScriptWin2Info.WaitForItemExists(10000);
				repo.Datastudio1.ScriptWin2.ClickThis();
				repo.Datastudio2.Grant.ClickThis();
				tc10538Repo.Application.QATextEditorInfo.WaitForItemExists(120000);
				Preconditions.Steps.ClickQARun();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists()) repo.FileModified.DiscardButton.ClickThis();
				Reports.ReportLog("Script Window 2 success", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				Preconditions.Steps.SelectedServerTreeItem.Collapse();
				Preconditions.Steps.SelectedServerTreeItem.RightClick();
				Preconditions.Steps.QueryAnalyser();
				if(Config.SchemaServers.Contains(Preconditions.Steps.SelectedServerName)) Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB_CAPS);
				else Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
				Preconditions.Steps.DropProcedure();
				Reports.ReportLog("Cleanup : drop procedure", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				Preconditions.Steps.DropTable();
				Reports.ReportLog("Cleanup : drop table", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				
				DropDatabaseQA();
			}
			catch (Exception ex)
			{
				if(repo.SQLFailed.SelfInfo.Exists(new Duration(1000))) { repo.SQLFailed.OkButton.ClickThis(); }
				
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists(1000)) repo.FileModified.DiscardButton.ClickThis();
				
				if(repo.DropTable.SelfInfo.Exists(1000)) repo.DropTable.YesButton.ClickThis();
				
				DropDatabaseQA();
				
				throw new Exception("Failed : Execute TC25 : " + ex.Message);
			}
		}
		
		public static void ExecuteTC26()
		{
			try
			{
				ConnectServer();
				
				Preconditions.Steps.SelectedServerTreeItem.Collapse();
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				Preconditions.Steps.CreateDatabase();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				Reports.ReportLog("Create ads_db", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				if(Config.SchemaServers.Contains(Preconditions.Steps.SelectedServerName)) Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB_CAPS);
				else Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
				
				Preconditions.Steps.CreateTable();
				Preconditions.Steps.CreateFunction();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				Reports.ReportLog("Create & functions ads_table", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				TreeItem securityItem = Preconditions.Steps.SelectedServerTreeItem.GetItem(databasesTree[2]);
				TreeItem adsdbItem = securityItem.GetItem(Config.ADSDB_CAPS);
				TreeItem functionsItem = adsdbItem.GetItem("User Defined Functions");
				TreeItem adsfunctionItem = functionsItem.GetItem("ADS_FUNCTION");
				System.Threading.Thread.Sleep(1000);
				adsfunctionItem.RightClick();
				repo.Datastudio1.ScriptWin1Info.WaitForItemExists(10000);
				repo.Datastudio1.ScriptWin1.ClickThis();
				repo.Datastudio2.Grant.ClickThis();
				tc10538Repo.Application.QATextEditorInfo.WaitForItemExists(120000);
				Preconditions.Steps.ClickQARun();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists()) repo.FileModified.DiscardButton.ClickThis();
				Reports.ReportLog("Script Window 1 success", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				System.Threading.Thread.Sleep(1000);
				adsfunctionItem.RightClick();
				repo.Datastudio1.ScriptWin2Info.WaitForItemExists(10000);
				repo.Datastudio1.ScriptWin2.ClickThis();
				repo.Datastudio2.Grant.ClickThis();
				tc10538Repo.Application.QATextEditorInfo.WaitForItemExists(120000);
				Preconditions.Steps.ClickQARun();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists()) repo.FileModified.DiscardButton.ClickThis();
				Reports.ReportLog("Script Window 2 success", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				Preconditions.Steps.SelectedServerTreeItem.Collapse();
				Preconditions.Steps.SelectedServerTreeItem.RightClick();
				Preconditions.Steps.QueryAnalyser();
				if(Config.SchemaServers.Contains(Preconditions.Steps.SelectedServerName)) Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB_CAPS);
				else Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
				Preconditions.Steps.DropFunction();
				Reports.ReportLog("Cleanup : drop function", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				Preconditions.Steps.DropTable();
				Reports.ReportLog("Cleanup : drop table", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				
				DropDatabaseQA();
			}
			catch (Exception ex)
			{
				
				if(repo.SQLFailed.SelfInfo.Exists(new Duration(1000))) { repo.SQLFailed.OkButton.ClickThis(); }
				
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists(1000)) repo.FileModified.DiscardButton.ClickThis();
				
				if(repo.DropTable.SelfInfo.Exists(1000)) repo.DropTable.YesButton.ClickThis();
				
				DropDatabaseQA();
				
				throw new Exception("Failed : Execute TC26 : " + ex.Message);
			}
		}
		
		public static void ExecuteTC27()
		{
			try
			{
				ConnectServer();
				
				Preconditions.Steps.SelectedServerTreeItem.Collapse();
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				Preconditions.Steps.CreateDatabase();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				Reports.ReportLog("Create ads_db", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				if(Config.SchemaServers.Contains(Preconditions.Steps.SelectedServerName)) Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB_CAPS);
				else Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
				
				Preconditions.Steps.CreateTable();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				Reports.ReportLog("Create ads_table", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				TreeItem securityItem = Preconditions.Steps.SelectedServerTreeItem.GetItem(databasesTree[1]);
				TreeItem adsdbItem = securityItem.GetItem(Config.ADSDB);
				TreeItem tablesItem = adsdbItem.GetItem("Tables");
				TreeItem adstableItem = tablesItem.GetItem("ads_db.ads_table");
				adstableItem.RightClick();
				
				repo.Datastudio1.ScriptWin1Info.WaitForItemExists(10000);
				repo.Datastudio1.ScriptWin1.ClickThis();
				repo.Datastudio2.Revoke.ClickThis();
				tc10538Repo.Application.QATextEditorInfo.WaitForItemExists(120000);
				Preconditions.Steps.ClickQARun();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists()) repo.FileModified.DiscardButton.ClickThis();
				
				adstableItem.RightClick();
				repo.Datastudio1.ScriptWin2Info.WaitForItemExists(10000);
				repo.Datastudio1.ScriptWin2.ClickThis();
				repo.Datastudio2.Revoke.ClickThis();
				tc10538Repo.Application.QATextEditorInfo.WaitForItemExists(120000);
				Preconditions.Steps.ClickQARun();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists()) repo.FileModified.DiscardButton.ClickThis();
				
				Preconditions.Steps.SelectedServerTreeItem.RightClick();
				Preconditions.Steps.DisconnectServer();
				Preconditions.Steps.QueryAnalyser();
				if(Config.SchemaServers.Contains(Preconditions.Steps.SelectedServerName)) Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB_CAPS);
				else Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
				Preconditions.Steps.DropTable();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				
				DropDatabaseQA();
			}
			catch (Exception ex)
			{
				
				if(repo.SQLFailed.SelfInfo.Exists(new Duration(1000))) { repo.SQLFailed.OkButton.ClickThis(); }
				
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists(1000)) repo.FileModified.DiscardButton.ClickThis();
				
				if(repo.DropTable.SelfInfo.Exists(1000)) repo.DropTable.YesButton.ClickThis();
				
				DropDatabaseQA();
				
				throw new Exception("Failed : Execute TC27 : " + ex.Message);
			}
		}
		
		public static void ExecuteTC28()
		{
			try
			{
				ConnectServer();
				
				Preconditions.Steps.SelectedServerTreeItem.Collapse();
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				Preconditions.Steps.CreateDatabase();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				Reports.ReportLog("Create ads_db", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				if(Config.SchemaServers.Contains(Preconditions.Steps.SelectedServerName)) Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB_CAPS);
				else Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
				
				Preconditions.Steps.CreateTable();
				Preconditions.Steps.CreateView();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				Reports.ReportLog("Create & View ads_table", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				TreeItem securityItem = Preconditions.Steps.SelectedServerTreeItem.GetItem(databasesTree[2]);
				TreeItem adsdbItem = securityItem.GetItem(Config.ADSDB_CAPS);
				TreeItem viewsItem = adsdbItem.GetItem("Views");
				TreeItem adsviewItem = viewsItem.GetItem("ADS_VIEW");
				adsviewItem.RightClick();
				
				repo.Datastudio1.ScriptWin1Info.WaitForItemExists(10000);
				repo.Datastudio1.ScriptWin1.ClickThis();
				repo.Datastudio2.Revoke.ClickThis();
				tc10538Repo.Application.QATextEditorInfo.WaitForItemExists(120000);
				Preconditions.Steps.ClickQARun();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists(new Duration(2000))) repo.FileModified.DiscardButton.ClickThis();
				Reports.ReportLog("Script Window 1 success", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				adsviewItem.RightClick();
				repo.Datastudio1.ScriptWin2Info.WaitForItemExists(10000);
				repo.Datastudio1.ScriptWin2.ClickThis();
				repo.Datastudio2.Revoke.ClickThis();
				tc10538Repo.Application.QATextEditorInfo.WaitForItemExists(120000);
				Preconditions.Steps.ClickQARun();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists(new Duration(2000))) repo.FileModified.DiscardButton.ClickThis();
				Reports.ReportLog("Script Window 2 success", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				Preconditions.Steps.SelectedServerTreeItem.Collapse();
				Preconditions.Steps.SelectedServerTreeItem.RightClick();
				Preconditions.Steps.QueryAnalyser();
				if(Config.SchemaServers.Contains(Preconditions.Steps.SelectedServerName)) Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB_CAPS);
				else Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
				Preconditions.Steps.DropView();
				Reports.ReportLog("Cleanup : drop view", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				Preconditions.Steps.DropTable();
				Reports.ReportLog("Cleanup : drop table", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				
				DropDatabaseQA();
			}
			catch (Exception ex)
			{
				if(repo.SQLFailed.SelfInfo.Exists(new Duration(1000))) { repo.SQLFailed.OkButton.ClickThis(); }
				
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists(1000)) repo.FileModified.DiscardButton.ClickThis();
				
				if(repo.DropTable.SelfInfo.Exists(1000)) repo.DropTable.YesButton.ClickThis();
				
				DropDatabaseQA();
				
				throw new Exception("Failed : Execute TC28 : " + ex.Message);
			}
		}
		
		public static void ExecuteTC29()
		{
			try
			{
				ConnectServer();
				
				Preconditions.Steps.SelectedServerTreeItem.Collapse();
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				Preconditions.Steps.CreateDatabase();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				Reports.ReportLog("Create ads_db", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				if(Config.SchemaServers.Contains(Preconditions.Steps.SelectedServerName)) Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB_CAPS);
				else Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
				
				Preconditions.Steps.CreateTable();
				Preconditions.Steps.CreateProcedure();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				Reports.ReportLog("Create & procedure ads_table", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				TreeItem securityItem = Preconditions.Steps.SelectedServerTreeItem.GetItem(databasesTree[2]);
				TreeItem adsdbItem = securityItem.GetItem(Config.ADSDB_CAPS);
				TreeItem proceduresItem = adsdbItem.GetItem("Stored Procedures");
				TreeItem adsprocedureItem = proceduresItem.GetItem("ADS_PROCEDURE");
				adsprocedureItem.RightClick();
				
				repo.Datastudio1.ScriptWin1Info.WaitForItemExists(10000);
				repo.Datastudio1.ScriptWin1.ClickThis();
				repo.Datastudio2.Revoke.ClickThis();
				tc10538Repo.Application.QATextEditorInfo.WaitForItemExists(120000);
				Preconditions.Steps.ClickQARun();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists()) repo.FileModified.DiscardButton.ClickThis();
				Reports.ReportLog("Script Window 1 success", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				adsprocedureItem.RightClick();
				repo.Datastudio1.ScriptWin2Info.WaitForItemExists(10000);
				repo.Datastudio1.ScriptWin2.ClickThis();
				repo.Datastudio2.Revoke.ClickThis();
				tc10538Repo.Application.QATextEditorInfo.WaitForItemExists(120000);
				Preconditions.Steps.ClickQARun();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists()) repo.FileModified.DiscardButton.ClickThis();
				Reports.ReportLog("Script Window 2 success", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				Preconditions.Steps.SelectedServerTreeItem.Collapse();
				Preconditions.Steps.SelectedServerTreeItem.RightClick();
				Preconditions.Steps.QueryAnalyser();
				if(Config.SchemaServers.Contains(Preconditions.Steps.SelectedServerName)) Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB_CAPS);
				else Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
				Preconditions.Steps.DropProcedure();
				Reports.ReportLog("Cleanup : drop procedure", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				Preconditions.Steps.DropTable();
				Reports.ReportLog("Cleanup : drop table", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				
				DropDatabaseQA();
			}
			catch (Exception ex)
			{
				if(repo.SQLFailed.SelfInfo.Exists(new Duration(1000))) { repo.SQLFailed.OkButton.ClickThis(); }
				
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists(1000)) repo.FileModified.DiscardButton.ClickThis();
				
				if(repo.DropTable.SelfInfo.Exists(1000)) repo.DropTable.YesButton.ClickThis();
				
				DropDatabaseQA();
				
				throw new Exception("Failed : Execute TC29 : " + ex.Message);
			}
		}
		
		public static void ExecuteTC30()
		{
			try
			{
				ConnectServer();
				
				Preconditions.Steps.SelectedServerTreeItem.Collapse();
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				Preconditions.Steps.CreateDatabase();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				Reports.ReportLog("Create ads_db", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				Preconditions.Steps.RightClick(Preconditions.Steps.SelectedServerTreeItem);
				Preconditions.Steps.QueryAnalyser();
				if(Config.SchemaServers.Contains(Preconditions.Steps.SelectedServerName)) Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB_CAPS);
				else Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
				
				Preconditions.Steps.CreateTable();
				Preconditions.Steps.CreateFunction();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				Reports.ReportLog("Create & functions ads_table", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				TreeItem securityItem = Preconditions.Steps.SelectedServerTreeItem.GetItem(databasesTree[2]);
				TreeItem adsdbItem = securityItem.GetItem(Config.ADSDB_CAPS);
				TreeItem functionsItem = adsdbItem.GetItem("User Defined Functions");
				TreeItem adsfunctionItem = functionsItem.GetItem("ADS_FUNCTION");
				adsfunctionItem.RightClick();
				
				repo.Datastudio1.ScriptWin1Info.WaitForItemExists(10000);
				repo.Datastudio1.ScriptWin1.ClickThis();
				repo.Datastudio2.Revoke.ClickThis();
				tc10538Repo.Application.QATextEditorInfo.WaitForItemExists(120000);
				Preconditions.Steps.ClickQARun();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists(new Duration(2000))) repo.FileModified.DiscardButton.ClickThis();
				Reports.ReportLog("Script Window 1 success", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				adsfunctionItem.RightClick();
				repo.Datastudio1.ScriptWin2Info.WaitForItemExists(10000);
				repo.Datastudio1.ScriptWin2.ClickThis();
				repo.Datastudio2.Revoke.ClickThis();
				tc10538Repo.Application.QATextEditorInfo.WaitForItemExists(120000);
				Preconditions.Steps.ClickQARun();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists(new Duration(2000))) repo.FileModified.DiscardButton.ClickThis();
				Reports.ReportLog("Script Window 2 success", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				Preconditions.Steps.SelectedServerTreeItem.Collapse();
				Preconditions.Steps.SelectedServerTreeItem.RightClick();
				Preconditions.Steps.QueryAnalyser();
				if(Config.SchemaServers.Contains(Preconditions.Steps.SelectedServerName)) Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB_CAPS);
				else Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
				Preconditions.Steps.DropFunction();
				Reports.ReportLog("Cleanup : drop function", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				Preconditions.Steps.DropTable();
				Reports.ReportLog("Cleanup : drop table", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				
				DropDatabaseQA();
			}
			catch (Exception ex)
			{
				if(repo.SQLFailed.SelfInfo.Exists(new Duration(1000))) { repo.SQLFailed.OkButton.ClickThis(); }
				
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.FileModified.SelfInfo.Exists(1000)) repo.FileModified.DiscardButton.ClickThis();
				
				if(repo.DropTable.SelfInfo.Exists(1000)) repo.DropTable.YesButton.ClickThis();
				
				DropDatabaseQA();
				
				throw new Exception("Failed : Execute TC30 : " + ex.Message);
			}
		}
		
		public static void ExecuteTC31()
		{
			try
			{
				ConnectServer();
				TreeItem securityItem = Preconditions.Steps.SelectedServerTreeItem.GetItem("Security");
				Reports.ReportLog("Security Expand", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				TreeItem rolesItem = securityItem.GetItem("Roles");
				Reports.ReportLog("Roles Expand", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				TreeItem anyroleItem = rolesItem.Items[0];
				anyroleItem.EnsureVisible();
				Reports.ReportLog("Right click on first Role", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				anyroleItem.RightClick();
				
				System.Threading.Thread.Sleep(2000);
				if (repo.Datastudio1.CreateRoleInfo.Exists(new Duration(1000)))
					Reports.ReportLog(" Validation : Roles CreateRole visible", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				else
					Reports.ReportLog(" Validation : Roles CreateRole not visible", Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
				
				System.Threading.Thread.Sleep(2000);
				if (repo.Datastudio1.AlterRoleInfo.Exists(new Duration(1000)))
					Reports.ReportLog(" Validation : Roles AlterRole visible", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				else
					Reports.ReportLog(" Validation : Roles AlterRole not visible", Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
				
				System.Threading.Thread.Sleep(2000);
				if (repo.Datastudio1.DropRoleInfo.Exists(new Duration(1000)))
					Reports.ReportLog(" Validation : Roles DropRole visible", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				else
					Reports.ReportLog(" Validation : Roles DropRole not visible", Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
				
				System.Threading.Thread.Sleep(2000);
				if (repo.Datastudio1.RolePropertiesInfo.Exists(new Duration(1000)))
					Reports.ReportLog(" Validation : Roles Role Properties visible", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				else
					Reports.ReportLog(" Validation : Roles Role Properties not visible", Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
				
				System.Threading.Thread.Sleep(2000);
				if (repo.Datastudio1.ScriptWin1Info.Exists(new Duration(1000)))
					Reports.ReportLog(" Validation : Roles Script Option 1 visible", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				else
					Reports.ReportLog(" Validation : Roles Script Option 1 not visible", Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
				
				System.Threading.Thread.Sleep(2000);
				if (repo.Datastudio1.ScriptWin2Info.Exists(new Duration(1000)))
					Reports.ReportLog(" Validation : Roles Script Option 2 visible", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				else
					Reports.ReportLog(" Validation : Roles Script Option 2 not visible", Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
				
				System.Threading.Thread.Sleep(2000);
				if (repo.Datastudio1.ScriptWin3Info.Exists(new Duration(1000)))
					Reports.ReportLog(" Validation : Roles Script Option 3 visible", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				else
					Reports.ReportLog(" Validation : Roles Script Option 3 not visible", Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : Execute TC31 : " + ex.Message);
				
			}
		}
		
		public static void ExecuteTC32()
		{
			try
			{
				ConnectServer();
				TreeItem securityItem = Preconditions.Steps.SelectedServerTreeItem.GetItem("Security");
				Reports.ReportLog("Security Expand", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				TreeItem rolesItem = securityItem.GetItem("Roles");
				Reports.ReportLog("Roles Expand", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				TreeItem anyroleItem = rolesItem.Items[0];
				anyroleItem.EnsureVisible();
				Reports.ReportLog("Right click on first Role", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				Reports.ReportLog("Create Role Validation Start", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				anyroleItem.RightClick();
				repo.Datastudio1.CreateRole.ClickThis();
				TC32_Common();
				Reports.ReportLog("Create Role Validation End", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				Reports.ReportLog("Alter Role Validation Start", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				anyroleItem.RightClick();
				repo.Datastudio1.AlterRole.ClickThis();
				TC32_Common();
				Reports.ReportLog("Alter Role Validation End", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				Reports.ReportLog("Drop Role Validation Start", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				anyroleItem.RightClick();
				repo.Datastudio1.DropRole.ClickThis();
				repo.DropRole.NoButton.ClickThis();
				Reports.ReportLog("Drop Role Validation End", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : Execute TC32 : " + ex.Message);
			}
		}
		
		private static void TC32_Common()
		{
			try
			{
				if(repo.Application.Roles.GeneralTabInfo.Exists(new Duration(1000)))
				{
					repo.Application.Roles.GeneralTab.ClickThis();
					Reports.ReportLog(" Validation : Roles General Tab visible", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
					
					if(repo.Application.Roles.NewRoleTextboxInfo.Exists())
						Reports.ReportLog(" Validation : Roles->GeneralTab-> New Role Name visible", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
					else
						Reports.ReportLog(" Validation : Roles->GeneralTab-> New Role Name not visible", Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
					
					if(repo.Application.Roles.HostTextboxInfo.Exists())
						Reports.ReportLog(" Validation : Roles->GeneralTab-> New Host visible", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
					else
						Reports.ReportLog(" Validation : Roles->GeneralTab-> New Host not visible", Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
				}
				else
					Reports.ReportLog(" Validation : Roles General Tab not visible", Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
				
				System.Threading.Thread.Sleep(1000);
				
				if(repo.Application.Roles.RoleTabInfo.Exists(new Duration(1000)))
				{
					repo.Application.Roles.RoleTab.ClickThis();
					Reports.ReportLog(" Validation : RolesTab visible", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
					
					repo.Application.Roles.RolesTableInfo.WaitForItemExists(20000);
					if(repo.Application.Roles.RolesTable.Rows.Count > 0)
						Reports.ReportLog(" Validation : RolesTable visible", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
					else
						Reports.ReportLog(" Validation : RolesTable not visible", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
					Reports.ReportLog(" Validation : RolesTab not visible", Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
				
				System.Threading.Thread.Sleep(1000);
				
				if(repo.Application.Roles.DatabaseAccessTabInfo.Exists(new Duration(1000)))
				{
					repo.Application.Roles.DatabaseAccessTab.ClickThis();
					Reports.ReportLog(" Validation : DatabaseAccessTab visible", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
					
					repo.Application.Roles.PrivilagesTableInfo.WaitForItemExists(20000);
					if(repo.Application.Roles.PrivilagesTable.Rows.Count > 0)
						Reports.ReportLog(" Validation : PrivilagesTable visible", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
					else
						Reports.ReportLog(" Validation : PrivilagesTable not visible", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
					Reports.ReportLog(" Validation : DatabaseAccessTab not visible", Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
				
				System.Threading.Thread.Sleep(1000);
				
				if(repo.Application.Roles.PreviewSqlTabInfo.Exists(new Duration(1000)))
				{
					repo.Application.Roles.PreviewSqlTab.ClickThis();
					Reports.ReportLog(" Validation : PreviewSqlTab visible", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
					
					if(repo.Application.Roles.PreviewEditorInfo.Exists(new Duration(1000)))
						Reports.ReportLog(" Validation : PreviewEditor visible", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
					else
						Reports.ReportLog(" Validation : PreviewEditor not visible", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
					Reports.ReportLog(" Validation : PreviewSqlTab not visible", Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
				
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				if(repo.DiscardRole.SelfInfo.Exists(new Duration(2000))) repo.DiscardRole.DiscardButton.ClickThis();
				Reports.ReportLog("Close Tab", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : Execute TC32 : " + ex.Message);
			}
		}
		
		public static void ExecuteTC33()
		{
			try
			{
				ConnectServer();
				TreeItem securityItem = Preconditions.Steps.SelectedServerTreeItem.GetItem("Security");
				Reports.ReportLog("Security Expand", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				TreeItem rolesItem = securityItem.GetItem("Roles");
				Reports.ReportLog("Roles Expand", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				TreeItem anyroleItem = rolesItem.Items[0];
				anyroleItem.EnsureVisible();
				Reports.ReportLog("Right click on first Role", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				Reports.ReportLog("Role Properties Validation Start", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				anyroleItem.RightClick();
				repo.Datastudio1.RoleProperties.ClickThis();
				TC33_Common();
				Reports.ReportLog("Role Properties Validation End", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : Execute TC33 : " + ex.Message);
			}
		}
		
		private static void TC33_Common()
		{
			try
			{
				if(repo.Application.Roles.GeneralTabInfo.Exists(new Duration(1000)))
				{
					repo.Application.Roles.GeneralTab.ClickThis();
					Reports.ReportLog(" Validation : Roles General Tab visible", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
					Reports.ReportLog(" Validation : Roles General Tab not visible", Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
				
				System.Threading.Thread.Sleep(1000);
				
				if(repo.Application.Roles.RoleTabInfo.Exists(new Duration(1000)))
				{
					repo.Application.Roles.RoleTab.ClickThis();
					Reports.ReportLog(" Validation : RolesTab visible", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
					Reports.ReportLog(" Validation : RolesTab not visible", Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
				
				System.Threading.Thread.Sleep(1000);
				
				if(repo.Application.Roles.DatabaseAccessTabInfo.Exists(new Duration(1000)))
				{
					repo.Application.Roles.DatabaseAccessTab.ClickThis();
					Reports.ReportLog(" Validation : DatabaseAccessTab visible", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
					Reports.ReportLog(" Validation : DatabaseAccessTab not visible", Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
				
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				Reports.ReportLog("Close Tab", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : Execute TC33 Common : " + ex.Message);
			}
		}
	}
}
