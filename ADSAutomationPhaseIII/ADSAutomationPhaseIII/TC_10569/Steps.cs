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
using ADSAutomationPhaseIII.TC_10569;

namespace ADSAutomationPhaseIII.TC_10569
{
    public class Steps
    {
    	
        public static TC_10569_10572Repo repo = TC_10569_10572Repo.Instance;
        public static string TC_10609_Path = System.Configuration.ConfigurationManager.AppSettings["TC_10569_Path"].ToString();
        public static int WaitTime = 30000;
        
        public static void ExplicitWait()
		{
			System.Threading.Thread.Sleep(10000);
		}
        
        public static void ClickOnProject()
		{
			try
			{
				if(!repo.AquaDataStudioDailog.ProjectsTreeInfo.Exists(15000))
				{
					repo.AquaDataStudioDailog.F3Projects.ClickThis();
					Reports.ReportLog("ClickOnProject", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnProject :" + ex.Message);
			}
		}
        
        public static void RightClickOnProjectTreeAndClickOnNewProject()
		{
			try
			{
				if(!repo.AquaDataStudioDailog.ProjectsTreeInfo.Exists(15000))
				{
					repo.AquaDataStudioDailog.F3Projects.ClickThis();
				}
				repo.AquaDataStudioDailog.ProjectsTree.ClickThis();
				repo.AquaDataStudioDailog.ProjectsTree.RightClickThis();
				if(!repo.SubMenuItems.NewProjectInfo.Exists(WaitTime)){
					repo.AquaDataStudioDailog.ProjectsTree.ClickThis();
					repo.AquaDataStudioDailog.ProjectsTree.RightClickThis();
				}
				repo.SubMenuItems.NewProject.ClickThis();
				Reports.ReportLog("RightClickOnProjectTreeAndClickOnNewProject", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : RightClickOnProjectTreeAndClickOnNewProject :" + ex.Message);
			}
		}
        
        public static void RightClickOnProjectTreeAndClickOnNewFolder()
		{
			try
			{
				repo.AquaDataStudioDailog.ProjectsTreeInfo.WaitForItemExists(WaitTime);
				repo.AquaDataStudioDailog.ProjectsTree.RightClickThis();
				repo.SubMenuItems.NewFolderInfo.WaitForItemExists(WaitTime);
				repo.SubMenuItems.NewFolder.ClickThis();
				Reports.ReportLog("RightClickOnProjectTreeAndClickOnNewFolder", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : RightClickOnProjectTreeAndClickOnNewFolder :" + ex.Message);
			}
		}
        
        public static void CreateNewFolder(string strNewScriptName)
		{
			try
			{
				repo.NewFolderDailog.NameTextFieldInfo.WaitForItemExists(WaitTime);
				repo.NewFolderDailog.NameTextField.TextBoxText(strNewScriptName);
				repo.NewFolderDailog.ButtonOK.ClickThis();
				repo.AquaDataStudioDailog.SelfInfo.WaitForItemExists(WaitTime);
				if(repo.AquaDataStudioDailog.TreeItemAdsInfo.Exists()){
					Report.Success("Created 'ads' folder found under root 'Projects'");
				}else{
					Report.Error("Created 'ads' folder not found under root 'Projects'");
				}
				repo.AquaDataStudioDailog.ADSFolderInfo.WaitForItemExists(WaitTime);
				UnExpandTree(repo.AquaDataStudioDailog.ADSFolder);
				RemoveProject(repo.AquaDataStudioDailog.ADSFolder);
				RemoveProject(repo.AquaDataStudioDailog.TreeItemAds);
				Reports.ReportLog("CreateNewFolder", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				if(repo.NewFolderDailog.SelfInfo.Exists(5000)){
					repo.NewFolderDailog.Self.Close();
				}
				throw new Exception("Failed : CreateNewFolder :" + ex.Message);
			}
		}
        
        public static void SelectFloatingModeServersTab()
		{
			try
			{
				repo.AquaDataStudioDailog.F1ServersInfo.WaitForItemExists(WaitTime);
				repo.AquaDataStudioDailog.F1Servers.ClickThis();
				repo.AquaDataStudioDailog.SettingIconInfo.WaitForItemExists(WaitTime);
				repo.AquaDataStudioDailog.SettingIcon.Click();
				repo.SubMenuItems.FloatingModeInfo.WaitForItemExists(WaitTime);
				repo.SubMenuItems.FloatingMode.ClickThis();
				repo.Servers.LocalDatabaseServersInfo.WaitForItemExists(WaitTime);
				ExpandTree(repo.Servers.LocalDatabaseServers);
				Reports.ReportLog("SelectFloatingModeServersTab", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectFloatingModeServersTab :" + ex.Message);
			}
		}
        
        public static void DragServerToServerFolder()
		{
			try
			{
				repo.Servers.Cassandra17224112222Info.WaitForItemExists(30000);
				repo.AquaDataStudioDailog.ServersADSInfo.WaitForItemExists(30000);				
				repo.Servers.Cassandra17224112222.DragThisTo(repo.AquaDataStudioDailog.ServersADS);
				if(repo.AquaDataStudioDailog.DtSchemExporter.Cassandra17224112222Info.Exists(30000)){
					Report.Success("Dragged server (Cassandra) found under Servers folder");
					repo.AquaDataStudioDailog.DtSchemExporter.Cassandra17224112222.RightClick();
					repo.SubMenuItems.UnregisterServer.Click();
					if(repo.UnregisterServer.ButtonYesInfo.Exists(5000))
					{
						repo.UnregisterServer.ButtonYes.ClickThis();
					}
				}
				else
				{
					Report.Error("Dragged server (Cassandra) is not found under Servers folder");
				}
				
				if(repo.AquaDataStudioDailog.DtSchemExporter.AmazonRedshiftInfo.Exists(10000))
				{
					repo.AquaDataStudioDailog.DtSchemExporter.AmazonRedshift.RightClickThis();
					repo.SubMenuItems.UnregisterServer.Click();
					if(repo.UnregisterServer.ButtonYesInfo.Exists(5000))
					{
						repo.UnregisterServer.ButtonYes.ClickThis();
					}
					
				}
//				UnExpandTree(repo.AquaDataStudioDailog.ADSFolder);
				Reports.ReportLog("DragServerToServerFolder", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragServerToServerFolder :" + ex.Message);
			}
		}
        
        public static void FolderNameNewProjectDailog(string strFolderName)
		{
			try
			{
				string strPath = TC_10609_Path+"\\"+strFolderName;
				repo.NewProjectDailog.FolderFieldInfo.WaitForItemExists(WaitTime);
				repo.NewProjectDailog.FolderField.ClickThis();
				Keyboard.Press(System.Windows.Forms.Keys.A | System.Windows.Forms.Keys.Control, 30, Keyboard.DefaultKeyPressTime, 1, true);
				repo.NewProjectDailog.FolderField.Element.SetAttributeValue("text", strPath);				
				Reports.ReportLog("FolderNameNewProjectDailog", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				if(repo.NewProjectDailog.SelfInfo.Exists(5000)){
					repo.NewProjectDailog.Self.Close();
				}
				throw new Exception("Failed : FolderNameNewProjectDailog :" + ex.Message);
			}
		}
        
        public static void SelectNoneAndClickOnCreateNewProjectDailog()
		{
			try
			{
				repo.NewProjectDailog.NoneInfo.WaitForItemExists(WaitTime);
				repo.NewProjectDailog.None.ClickThis();
				repo.NewProjectDailog.CreateButton.ClickThis();
				Thread.Sleep(3000);				
				Reports.ReportLog("SelectNoneAndClickOnCreateNewProjectDailog", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				if(repo.NewProjectDailog.SelfInfo.Exists(5000)){
					repo.NewProjectDailog.Self.Close();
				}
				throw new Exception("Failed : SelectNoneAndClickOnCreateNewProjectDailog :" + ex.Message);
			}
		}
        
        public static void CLickOkButtAndCloseNewProjectDailog()
		{
			try
			{
				if(repo.Warning.SelfInfo.Exists(5000))
				{
					repo.Warning.ButtonOKInfo.WaitForExists(5000);
					repo.Warning.ButtonOK.ClickThis();
					if(repo.NewProjectDailog.SelfInfo.Exists(5000))
					{
						repo.NewProjectDailog.Self.Close();
					}
				}
				Reports.ReportLog("CLickOkButtAndCloseNewProjectDailog", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Failed : CLickOkButtAndCloseNewProjectDailog :" + ex.Message);
			}
		}
        
        public static void SelectCreateAndEmailExcelFileNewProjectDailog()
		{
			try
			{
				repo.NewProjectDailog.CreateAndEmailExcelFile.ClickThis();
				repo.NewProjectDailog.CreateButton.ClickThis();
				Reports.ReportLog("SelectCreateAndEmailExcelFileNewProjectDailog", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				if(repo.NewProjectDailog.SelfInfo.Exists(5000)){
					repo.NewProjectDailog.Self.Close();
				}
				throw new Exception("Failed : SelectCreateAndEmailExcelFileNewProjectDailog :" + ex.Message);
			}
		}
        
        public static void SelectDatabaseSchemaAndDataExporterNewProjectDailog()
		{
			try
			{
				repo.NewProjectDailog.DatabaseSchemaAndDataExporter.ClickThis();
				repo.NewProjectDailog.CreateButton.ClickThis();
				Reports.ReportLog("SelectDatabaseSchemaAndDataExporterNewProjectDailog", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				if(repo.NewProjectDailog.SelfInfo.Exists(5000)){
					repo.NewProjectDailog.Self.Close();
				}
				throw new Exception("Failed : SelectDatabaseSchemaAndDataExporterNewProjectDailog :" + ex.Message);
			}
		}
        
        public static void SelectMultiServerScriptExeNewProjectDailog()
		{
			try
			{
				repo.NewProjectDailog.MultiServerScriptExecute.ClickThis();
				repo.NewProjectDailog.CreateButton.ClickThis();
				Reports.ReportLog("SelectMultiServerScriptExeNewProjectDailog", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				if(repo.NewProjectDailog.SelfInfo.Exists(5000)){
					repo.NewProjectDailog.Self.Close();
				}
				throw new Exception("Failed : SelectMultiServerScriptExeNewProjectDailog :" + ex.Message);
			}
		}
        
        public static void SelectRandomTableAndDataGeneration()
		{
			try
			{
				repo.NewProjectDailog.RandomTableAndDataGeneration.ClickThis();
				repo.NewProjectDailog.CreateButton.ClickThis();
				Reports.ReportLog("SelectRandomTableAndDataGeneration", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				if(repo.NewProjectDailog.SelfInfo.Exists(5000)){
					repo.NewProjectDailog.Self.Close();
				}
				throw new Exception("Failed : SelectRandomTableAndDataGeneration :" + ex.Message);
			}
		}
        
        public static void SelectSchemaCompare()
		{
			try
			{
				repo.NewProjectDailog.SchemaCompare.ClickThis();
				repo.NewProjectDailog.CreateButton.ClickThis();
				Reports.ReportLog("SelectSchemaCompare", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				if(repo.NewProjectDailog.SelfInfo.Exists(5000)){
					repo.NewProjectDailog.Self.Close();
				}
				throw new Exception("Failed : SelectSchemaCompare :" + ex.Message);
			}
		}
        
        public static void SelectFileTransferAndRemoteCmdExeNewProjectDailog()
		{
			try
			{
				repo.NewProjectDailog.FileTransferAndRemoteCmdExe.ClickThis();
				repo.NewProjectDailog.chkFTPTransferFrom.ClickThis();
				repo.NewProjectDailog.CreateButton.ClickThis();
				Reports.ReportLog("SelectFileTransferAndRemoteCmdExeNewProjectDailog", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				if(repo.NewProjectDailog.SelfInfo.Exists(5000)){
					repo.NewProjectDailog.Self.Close();
				}
				throw new Exception("Failed : SelectFileTransferAndRemoteCmdExeNewProjectDailog :" + ex.Message);
			}
		}
        
        public static void CheckADSFolderFileStructure()
		{
			try
			{
				repo.AquaDataStudioDailog.ADSFolderInfo.WaitForItemExists(WaitTime);
				ExpandTree(repo.AquaDataStudioDailog.ADSFolder);
				if(repo.AquaDataStudioDailog.AquaScriptsInfo.Exists(WaitTime)){
					Report.Success("'AquaScripts' Folder is Created under 'ADS' Folder");
				}else{
					Report.Error("'AquaScripts' Folder is not created under 'ADS' Folder");
				}
				if(repo.AquaDataStudioDailog.ServersADSInfo.Exists(WaitTime)){
					Report.Success("'Servers' Folder is Created under 'ADS' Folder");
				}else{
					Report.Error("'Servers' Folder is not created under 'ADS' Folder");
				}
				if(repo.AquaDataStudioDailog.UserFilesInfo.Exists(WaitTime)){
					Report.Success("'UserFiles' Folder is Created under 'ADS' Folder");
				}else{
					Report.Error("'UserFiles' Folder is not created under 'ADS' Folder");
				}								
				Reports.ReportLog("CheckADSFolderFileStructure", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CheckADSFolderFileStructure :" + ex.Message);
			}
		}
        
        public static void CheckADSSampleFolderFileStructure()
		{
			try
			{
				repo.AquaDataStudioDailog.ADSSampleInfo.WaitForItemExists(WaitTime);
				ExpandTree(repo.AquaDataStudioDailog.ADSSample);
				if(repo.AquaDataStudioDailog.AquaScriptsADSSampleInfo.Exists(WaitTime)){
					Report.Success("'AquaScripts' Folder is Created under 'ADS' Sample Folder");
				}else{
					Report.Error("'AquaScripts' Folder is not created under 'ADS' Sample Folder");
				}
				if(repo.AquaDataStudioDailog.ServersADSSampleInfo.Exists(WaitTime)){
					Report.Success("'Servers' Folder is Created under 'ADS' Sample Folder");
				}else{
					Report.Error("'Servers' Folder is not created under 'ADS' Sample Folder");
				}
				if(repo.AquaDataStudioDailog.UserFilesADSSampleInfo.Exists(WaitTime)){
					Report.Success("'UserFiles' Folder is Created under 'ADS' Sample Folder");
				}else{
					Report.Error("'UserFiles' Folder is not created under 'ADS' Sample Folder");
				}								
				Reports.ReportLog("CheckADSSampleFolderFileStructure", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CheckADSSampleFolderFileStructure :" + ex.Message);
			}
		}
        
        public static void CheckDtSchemExporterFolderFileStructure()
		{
			try
			{
				repo.AquaDataStudioDailog.ADSDtSchemExporterInfo.WaitForItemExists(WaitTime);
				ExpandTree(repo.AquaDataStudioDailog.ADSDtSchemExporter);
				if(repo.AquaDataStudioDailog.DtSchemExporter.AquaScriptsDtSchemExporterInfo.Exists(WaitTime)){
					Report.Success("'AquaScripts' Folder is Created under 'ADSDtSchemExporter' Folder");
				}else{
					Report.Error("'AquaScripts' Folder is not created under 'ADSDtSchemExporter' Folder");
				}
				if(repo.AquaDataStudioDailog.DtSchemExporter.ServersDtSchemExporterInfo.Exists(WaitTime)){
					Report.Success("'Servers' Folder is Created under 'ADSDtSchemExporter' Folder");
				}else{
					Report.Error("'Servers' Folder is not created under 'ADSDtSchemExporter' Folder");
				}
				if(repo.AquaDataStudioDailog.DtSchemExporter.UserFilesDtSchemExporterInfo.Exists(WaitTime)){
					Report.Success("'UserFiles' Folder is Created under 'ADSDtSchemExporter' Folder");
				}else{
					Report.Error("'UserFiles' Folder is not created under 'ADSDtSchemExporter' Folder");
				}								
				Reports.ReportLog("CheckDtSchemExporterFolderFileStructure", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CheckDtSchemExporterFolderFileStructure :" + ex.Message);
			}
		}
        
        public static void CheckMultiServerScriptExeFolderStructure()
		{
			try
			{
				repo.AquaDataStudioDailog.FolderContainer.MultiServerScriptExeInfo.WaitForItemExists(WaitTime);
				ExpandTree(repo.AquaDataStudioDailog.FolderContainer.MultiServerScriptExe);
				if(repo.AquaDataStudioDailog.FolderContainer.MultiServerScriptExeStructure.AquaScriptsInfo.Exists(WaitTime)){
					Report.Success("'AquaScripts' Folder is Created under 'MultiServerScriptExe' Folder");
				}else{
					Report.Error("'AquaScripts' Folder is not created under 'MultiServerScriptExe' Folder");
				}
				if(repo.AquaDataStudioDailog.FolderContainer.MultiServerScriptExeStructure.ServersInfo.Exists(WaitTime)){
					Report.Success("'Servers' Folder is Created under 'MultiServerScriptExe' Folder");
				}else{
					Report.Error("'Servers' Folder is not created under 'MultiServerScriptExe' Folder");
				}
				if(repo.AquaDataStudioDailog.FolderContainer.MultiServerScriptExeStructure.UserFilesInfo.Exists(WaitTime)){
					Report.Success("'UserFiles' Folder is Created under 'MultiServerScriptExe' Folder");
				}else{
					Report.Error("'UserFiles' Folder is not created under 'MultiServerScriptExe' Folder");
				}								
				Reports.ReportLog("CheckMultiServerScriptExeFolderStructure", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CheckMultiServerScriptExeFolderStructure :" + ex.Message);
			}
		}
        
        public static void CheckRandomTblAndDtGenerationFolderStructure()
		{
			try
			{
				repo.AquaDataStudioDailog.RandomTblDtGenerationInfo.WaitForItemExists(WaitTime);
				ExpandTree(repo.AquaDataStudioDailog.RandomTblDtGeneration);
				if(repo.AquaDataStudioDailog.RandomTableAndDtGen.AquaScriptsInfo.Exists(WaitTime)){
					Report.Success("'AquaScripts' Folder is Created under 'RandomTblDtGeneration' Folder");
				}else{
					Report.Error("'AquaScripts' Folder is not created under 'RandomTblDtGeneration' Folder");
				}
				if(repo.AquaDataStudioDailog.RandomTableAndDtGen.ServersInfo.Exists(WaitTime)){
					Report.Success("'Servers' Folder is Created under 'RandomTblDtGeneration' Folder");
				}else{
					Report.Error("'Servers' Folder is not created under 'RandomTblDtGeneration' Folder");
				}
				if(repo.AquaDataStudioDailog.RandomTableAndDtGen.UserFilesInfo.Exists(WaitTime)){
					Report.Success("'UserFiles' Folder is Created under 'RandomTblDtGeneration' Folder");
				}else{
					Report.Error("'UserFiles' Folder is not created under 'RandomTblDtGeneration' Folder");
				}								
				Reports.ReportLog("CheckRandomTblAndDtGenerationFolderStructure", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CheckRandomTblAndDtGenerationFolderStructure :" + ex.Message);
			}
		}
        
        public static void CheckSchemaCompareFolderStructure()
		{
			try
			{
				repo.AquaDataStudioDailog.SchemaCompareInfo.WaitForItemExists(WaitTime);
				ExpandTree(repo.AquaDataStudioDailog.SchemaCompare);
				if(repo.AquaDataStudioDailog.SchemaCompareStructure.AquaScriptsInfo.Exists(WaitTime)){
					Report.Success("'AquaScripts' Folder is Created under 'SchemaCompare' Folder");
				}else{
					Report.Error("'AquaScripts' Folder is not created under 'SchemaCompare' Folder");
				}
				if(repo.AquaDataStudioDailog.SchemaCompareStructure.ServersInfo.Exists(WaitTime)){
					Report.Success("'Servers' Folder is Created under 'SchemaCompare' Folder");
				}else{
					Report.Error("'Servers' Folder is not created under 'SchemaCompare' Folder");
				}
				if(repo.AquaDataStudioDailog.SchemaCompareStructure.UserFilesInfo.Exists(WaitTime)){
					Report.Success("'UserFiles' Folder is Created under 'SchemaCompare' Folder");
				}else{
					Report.Error("'UserFiles' Folder is not created under 'SchemaCompare' Folder");
				}								
				Reports.ReportLog("CheckSchemaCompareFolderStructure", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CheckSchemaCompareFolderStructure :" + ex.Message);
			}
		}
        
        public static void CheckFileTransferAndRemoteCmdExeFolderFileStructure()
		{
			try
			{
				repo.AquaDataStudioDailog.FileTransferRemoteCmdExeInfo.WaitForItemExists(WaitTime);
				ExpandTree(repo.AquaDataStudioDailog.FileTransferRemoteCmdExe);
				if(repo.AquaDataStudioDailog.FoldersFileTransferRemoteCmdExe.AquaScriptsInfo.Exists(WaitTime)){
					Report.Success("'AquaScripts' Folder is Created under 'FileTransferAndRemoteCmdExe' Folder");
				}else{
					Report.Error("'AquaScripts' Folder is not created under 'FileTransferAndRemoteCmdExe' Folder");
				}
				if(repo.AquaDataStudioDailog.FoldersFileTransferRemoteCmdExe.ServersInfo.Exists(WaitTime)){
					Report.Success("'Servers' Folder is Created under 'FileTransferAndRemoteCmdExe' Folder");
				}else{
					Report.Error("'Servers' Folder is not created under 'FileTransferAndRemoteCmdExe' Folder");
				}
				if(repo.AquaDataStudioDailog.FoldersFileTransferRemoteCmdExe.UserFilesInfo.Exists(WaitTime)){
					Report.Success("'UserFiles' Folder is Created under 'FileTransferAndRemoteCmdExe' Folder");
				}else{
					Report.Error("'UserFiles' Folder is not created under 'FileTransferAndRemoteCmdExe' Folder");
				}								
				Reports.ReportLog("CheckFileTransferAndRemoteCmdExeFolderFileStructure", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CheckFileTransferAndRemoteCmdExeFolderFileStructure :" + ex.Message);
			}
		}
        
        public static void OpenNewScriptNewScriptDailog()
		{
			try
			{
				ExpandTree(repo.AquaDataStudioDailog.AquaScripts);
				if(!repo.AquaDataStudioDailog.SampleXjsInfo.Exists(5000))
				{
					repo.AquaDataStudioDailog.ADSFolderInfo.WaitForItemExists(WaitTime);
					ExpandTree(repo.AquaDataStudioDailog.ADSFolder);
					repo.AquaDataStudioDailog.AquaScriptsInfo.WaitForItemExists(WaitTime);
					repo.AquaDataStudioDailog.AquaScripts.RightClickThis();
					repo.SubMenuItems.MenuItemNewInfo.WaitForItemExists(WaitTime);
					repo.SubMenuItems.MenuItemNew.ClickThis();	
				}
							
				Reports.ReportLog("OpenNewScriptNewScriptDailog", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : OpenNewScriptNewScriptDailog :" + ex.Message);
			}
		}
        
        public static void CreateNewScript(string strNewScriptName)
		{
			try
			{
				if(!repo.AquaDataStudioDailog.SampleXjsInfo.Exists(5000))
				{
					repo.CreateNewScriptDailog.NameFieldInfo.WaitForItemExists(WaitTime);
					repo.CreateNewScriptDailog.NameField.TextBoxText(strNewScriptName);
					repo.CreateNewScriptDailog.ButtonOK.ClickThis();
					repo.AquaDataStudioDailog.AquaScriptsInfo.WaitForItemExists(WaitTime);
					ExpandTree(repo.AquaDataStudioDailog.AquaScripts);
					if(repo.AquaDataStudioDailog.SampleXjsInfo.Exists(5000))
					{
						Report.Success("Created new scripts 'Sample.xjs' is found");
					}else{
						Report.Error("Created new scripts 'Sample.xjs' is not found");
					}
				}
				if(repo.AquaDataStudioDailog.SampleXjsInfo.Exists(5000))
				{
					repo.AquaDataStudioDailog.SampleXjs.RightClick();
					repo.SubMenuItems.Delete.Click();
					if(repo.Delete.ButtonYesInfo.Exists(10000))
					{
						repo.Delete.ButtonYes.Click();
					}
				}
				Reports.ReportLog("CreateNewScript", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				if(repo.CreateNewScriptDailog.SelfInfo.Exists(5000))
				{
					repo.CreateNewScriptDailog.Self.Close();
				}
				throw new Exception("Failed : CreateNewScript :" + ex.Message);
			}
		}
        
        public static void OpenRegisterServerDialog()
		{
			try
			{
				ExpandTree(repo.AquaDataStudioDailog.ServersADS);
				
				if(repo.AquaDataStudioDailog.DtSchemExporter.Cassandra17224112222Info.Exists(6000)){
					Report.Success("Dragged server (Cassandra) found under Servers folder");
					repo.AquaDataStudioDailog.DtSchemExporter.Cassandra17224112222.RightClick();
					repo.SubMenuItems.UnregisterServer.Click();
					if(repo.UnregisterServer.ButtonYesInfo.Exists(5000))
					{
						repo.UnregisterServer.ButtonYes.ClickThis();
					}
				}
				if(repo.AquaDataStudioDailog.DtSchemExporter.AmazonRedshiftInfo.Exists(6000))
				{
					repo.AquaDataStudioDailog.DtSchemExporter.AmazonRedshift.RightClickThis();
					repo.SubMenuItems.UnregisterServer.Click();
					if(repo.UnregisterServer.ButtonYesInfo.Exists(5000))
					{
						repo.UnregisterServer.ButtonYes.ClickThis();
					}
					
				}
				
				repo.AquaDataStudioDailog.ServersADSInfo.WaitForItemExists(WaitTime);
				repo.AquaDataStudioDailog.ServersADS.RightClickThis();
				repo.SubMenuItems.RegisterServerInfo.WaitForItemExists(WaitTime);
				repo.SubMenuItems.RegisterServer.ClickThis();
				if(repo.RegisterServer.SelfInfo.Exists(30000))
				{
					Report.Success("Register Server Dialog Found");
				}
				else
				{
					Report.Error("Register Server Dialog Found");
				}
				Reports.ReportLog("OpenRegisterServerDialog", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				if(repo.RegisterServer.SelfInfo.Exists(5000))
				{
					repo.RegisterServer.Self.Close();
				}
				throw new Exception("Failed : OpenRegisterServerDialog :" + ex.Message);
			}
		}
        
        public static void RegisterServerDialogSetParam(string strName, string strLogin, string strPWD, string strHost, string strPort, string strDtBase)
        {
        	try
        	{
        		repo.RegisterServer.TxtNameInfo.WaitForItemExists(WaitTime);
        		repo.RegisterServer.TxtName.TextBoxText(strName);
        		repo.RegisterServer.txtLoginName.TextBoxText(strLogin);
        		repo.RegisterServer.txtPassword.TextBoxText(strPWD);
        		repo.RegisterServer.Host.TextBoxText(strHost);
        		repo.RegisterServer.Port.TextBoxText(strPort);
        		repo.RegisterServer.DtBase.TextBoxText(strDtBase);
        		repo.RegisterServer.TestConnection.ClickThis();
        		Reports.ReportLog("RegisterServerDialogSetParam", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
        	}
        	catch (Exception ex)
			{
				if(repo.RegisterServer.SelfInfo.Exists(5000))
				{
					repo.RegisterServer.Self.Close();
				}
				throw new Exception("Failed : RegisterServerDialogSetParam :" + ex.Message);
			}
        }
        
        public static void CloseConnectionTestSUCCESSDialog()
        {
        	try
        	{
        		repo.ConnectionTestSUCCESS.SelfInfo.WaitForItemExists(WaitTime);
        		repo.ConnectionTestSUCCESS.Close.ClickThis();        			
        		Reports.ReportLog("ConnectionTestSUCCESSDialog", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
        	}
        	catch (Exception ex)
			{
				if(repo.ConnectionTest.SelfInfo.Exists(5000))
				{
					repo.ConnectionTest.Self.Close();
				}
				if(repo.RegisterServer.SelfInfo.Exists(5000))
				{
					repo.RegisterServer.Self.Close();
				}
				throw new Exception("Failed : ConnectionTestSUCCESSDialog :" + ex.Message);
			}
        }
        
        public static void SaveRegisterServerDialog()
        {
        	try
        	{
        		repo.RegisterServer.SaveInfo.WaitForItemExists(WaitTime);
        		repo.RegisterServer.Save.ClickThis();        			
        		Reports.ReportLog("SaveRegisterServerDialog", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
        	}
        	catch (Exception ex)
			{
				if(repo.RegisterServer.SelfInfo.Exists(5000))
				{
					repo.RegisterServer.Self.Close();
				}
				throw new Exception("Failed : SaveRegisterServerDialog :" + ex.Message);
			}
        }
        
        public static void CreateNewUserFile(string strNewUserFile)
		{
			try
			{
				repo.AquaDataStudioDailog.UserFilesInfo.WaitForItemExists(WaitTime);
				repo.AquaDataStudioDailog.UserFiles.RightClickThis();
				repo.SubMenuItems.MenuItemNewInfo.WaitForItemExists(WaitTime);
				repo.SubMenuItems.MenuItemNew.ClickThis();		
				repo.CreateNewFileDialog.NameFieldInfo.WaitForItemExists(WaitTime);
				repo.CreateNewFileDialog.NameField.TextBoxText(strNewUserFile);
				repo.CreateNewFileDialog.ButtonOK.ClickThis();
				if(repo.AquaDataStudioDailog.DtSchemExporter.SampleSqlInfo.Exists(6000))
				{
					repo.AquaDataStudioDailog.DtSchemExporter.SampleSql.RightClickThis();
					repo.SubMenuItems.Delete.Click();
					if(repo.Delete.ButtonYesInfo.Exists(6000))
					{
						repo.Delete.ButtonYes.ClickThis();
					}
				}
				Reports.ReportLog("CreateNewUserFile", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				if(repo.CreateNewFileDialog.SelfInfo.Exists(5000))
				{
					repo.CreateNewFileDialog.Self.Close();
				}
				throw new Exception("Failed : CreateNewUserFile :" + ex.Message);
			}
		}
        
        public static void CheckCreateandEmailExcelFileUnderProjectTree()
        {
        	try
        	{
        		ExpandTree(repo.AquaDataStudioDailog.ADSSample);
        		ExpandTree(repo.AquaDataStudioDailog.AquaScriptsADSSample);
        		if(repo.AquaDataStudioDailog.CreateAndEmailExlFileXjsInfo.Exists(WaitTime))
        		{
        			Report.Success("'Create and Email Excel File.xjs' is found under AquaScripts Under ADSSample Folder");
        		}
        		else
        		{
        			Report.Error("'Create and Email Excel File.xjs' is not found under AquaScripts Under ADSSample Folder");
        		}
        		Reports.ReportLog("CheckCreateandEmailExcelFileUnderProjectTree", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
        	}
        	catch(Exception ex)
			{
				throw new Exception("Failed : CheckCreateandEmailExcelFileUnderProjectTree : " + ex.Message);
			}
        }
        
//        public static void CheckMultiServerScriptExeFileUnderProjectTree()
//        {
//        	try
//        	{
//        		ExpandTree(repo.AquaDataStudioDailog.MultiServerScriptExe);
//        		ExpandTree(repo.AquaDataStudioDailog.FolderContainer.MultiServerScriptExeStructure.AquaScripts);
//        		if(repo.AquaDataStudioDailog.FolderContainer.MultiServerScriptExecuteXjsInfo.Exists(WaitTime))
//				{
//        			Report.Success("'Create and Email Excel File.xjs' is found under AquaScripts Under MultiServerScriptExe Folder");
//        		}
//        		else
//        		{
//        			Report.Error("'Create and Email Excel File.xjs' is not found under AquaScripts Under MultiServerScriptExe Folder");
//        		}
//        		Reports.ReportLog("CheckMultiServerScriptExeFileUnderProjectTree", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
//        	}
//        	catch(Exception ex)
//			{
//				throw new Exception("Failed : CheckMultiServerScriptExeFileUnderProjectTree : " + ex.Message);
//			}
//        }
        
        public static void CheckRandomTblAndDtGenerationFolder3Files()
        {
        	try
        	{
        		ExpandTree(repo.AquaDataStudioDailog.RandomTblDtGeneration);
        		ExpandTree(repo.AquaDataStudioDailog.RandomTableAndDtGen.AquaScripts);
        		if(repo.AquaDataStudioDailog.RandomTableAndDtGen.ExecuteTableGenerationScriptXjsInfo.Exists(10000))
        		{
        			Report.Success("'ExecuteTableGenerationScript.xjs' is found under AquaScripts Under 'RandomTblDtGeneration' Folder");
        		}
        		else
        		{
        			Report.Error("'ExecuteTableGenerationScript.xjs' is not found under AquaScripts Under 'RandomTblDtGeneration' Folder");
        		}
        		if(repo.AquaDataStudioDailog.RandomTableAndDtGen.RandomDataGeneratorXjsInfo.Exists(10000))
        		{
        			Report.Success("'RandomDataGenerator.xjs' is found under AquaScripts Under 'RandomTblDtGeneration' Folder");
        		}
        		else
        		{
        			Report.Error("'RandomDataGenerator.xjs' is not found under AquaScripts Under 'RandomTblDtGeneration' Folder");
        		}
        		if(repo.AquaDataStudioDailog.RandomTableAndDtGen.RandomTableGeneratorXjsInfo.Exists(10000))
        		{
        			Report.Success("'RandomTableGenerator.xjs' is found under AquaScripts Under 'RandomTblDtGeneration' Folder");
        		}
        		else
        		{
        			Report.Error("'RandomTableGenerator.xjs' is not found under AquaScripts Under 'RandomTblDtGeneration' Folder");
        		}
        		Reports.ReportLog("CheckRandomTblAndDtGenerationFolder3Files", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
        	}
        	catch(Exception ex)
			{
				throw new Exception("Failed : CheckRandomTblAndDtGenerationFolder3Files : " + ex.Message);
			}
        }
        
        public static void CheckSchemaCompareFileUnderProjectTree()
        {
        	try
        	{
        		ExpandTree(repo.AquaDataStudioDailog.SchemaCompare);
        		ExpandTree(repo.AquaDataStudioDailog.SchemaCompareStructure.AquaScripts);
        		if(repo.AquaDataStudioDailog.SchemaCompareXjsInfo.Exists(WaitTime))
        		{
        			Report.Success("'Schema Compare.xjs' is found under AquaScripts Under SchemaCompare Folder");
        		}
        		else
        		{
        			Report.Error("'Schema Compare.xjs' is not found under AquaScripts Under SchemaCompare Folder");
        		}
        		Reports.ReportLog("CheckSchemaCompareFileUnderProjectTree", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
        	}
        	catch(Exception ex)
			{
				throw new Exception("Failed : CheckSchemaCompareFileUnderProjectTree : " + ex.Message);
			}
        }
        
        public static void CheckFileTransferXjsFile()
        {
        	try
        	{
        		ExpandTree(repo.AquaDataStudioDailog.FileTransferRemoteCmdExe);
				ExpandTree(repo.AquaDataStudioDailog.FoldersFileTransferRemoteCmdExe.AquaScripts);
        		if(repo.AquaDataStudioDailog.FileTransferXjsInfo.Exists(WaitTime))
        		{
        			Report.Success("File Transfer and Remote Command Execution 'xjs' file is found under AquaScripts Under MultiServerScriptExe Folder");
        		}
        		else
        		{
        			Report.Error("File Transfer and Remote Command Execution 'xjs' file is not found under AquaScripts Under MultiServerScriptExe Folder");
        		}
        		Reports.ReportLog("CheckFileTransferXjsFile", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
        	}
        	catch(Exception ex)
			{
				throw new Exception("Failed : CheckFileTransferXjsFile : " + ex.Message);
			}
        }
        
        public static void CheckMultiServerScriptExeFileUnderProjectTree()
        {
        	try
        	{
        		ExpandTree(repo.AquaDataStudioDailog.FolderContainer.MultiServerScriptExe);
        		ExpandTree(repo.AquaDataStudioDailog.FolderContainer.MultiServerScriptExeStructure.AquaScripts);
        		if(repo.AquaDataStudioDailog.FolderContainer.MultiServerScriptExecuteXjsInfo.Exists(WaitTime))
        		{
        			Report.Success("''Multi Server Script Execute.xjs'' is found under AquaScripts Under MultiServerScriptExe Folder");
        		}
        		else
        		{
        			Report.Error("''Multi Server Script Execute.xjs'' is not found under AquaScripts Under MultiServerScriptExe Folder");
        		}
        		Reports.ReportLog("CheckMultiServerScriptExeFileUnderProjectTree", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
        	}
        	catch(Exception ex)
			{
				throw new Exception("Failed : CheckMultiServerScriptExeFileUnderProjectTree : " + ex.Message);
			}
        }
        
        public static void CheckDtbaseSchemaAndDataExporterXjsFile()
        {
        	try
        	{
        		ExpandTree(repo.AquaDataStudioDailog.ADSDtSchemExporter);
        		ExpandTree(repo.AquaDataStudioDailog.DtSchemExporter.AquaScriptsDtSchemExporter);
        		if(repo.AquaDataStudioDailog.DatabaseSchemaAndDataExporterXjsInfo.Exists(WaitTime))
        		{
        			Report.Success("'Database Schema And Data Exporter.xjs' is found under AquaScripts Under ADSSample Folder");
        		}
        		else
        		{
        			Report.Error("'Database Schema And Data Exporter.xjs' is not found under AquaScripts Under ADSSample Folder");
        		}
        		Reports.ReportLog("CheckDtbaseSchemaAndDataExporterXjsFile", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
        	}
        	catch(Exception ex)
			{
				throw new Exception("Failed : CheckDtbaseSchemaAndDataExporterXjsFile : " + ex.Message);
			}
        }
        
        public static void CheckQATemplateEditor()
		{
			try
			{
				if(repo.AquaDataStudioDailog.ADSSampleCreateAndEmailExcelFileXInfo.Exists(WaitTime))
				{
					Report.Success("'QA Template Editor' is found after Create And Email Excel File -- New Project");
				}
				else
				{
					Report.Error("'QA Template Editor' is not found after Create And Email Excel File -- New Project");
				}
				Reports.ReportLog("CheckQATemplateEditor", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : CheckQATemplateEditor : " + ex.Message);
			}
		}
        
        public static void CheckQATemplateEditorDtSchemExporter()
		{
			try
			{
				if(repo.AquaDataStudioDailog.QATemplateEditorDtSchemExporterInfo.Exists(WaitTime))
				{
					Report.Success("'QA Template Editor' is found after Database Schema and Data Exporter -- New Project");
				}
				else
				{
					Report.Error("'QA Template Editor' is not found after Database Schema and Data Exporter -- New Project");
				}
				Reports.ReportLog("CheckQATemplateEditorDtSchemExporter", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : CheckQATemplateEditorDtSchemExporter : " + ex.Message);
			}
		}
        
        public static void CheckQATemplateMultiServerScriptExe()
		{
			try
			{
				if(repo.AquaDataStudioDailog.MultiServerScriptExeMultiServerQAEditorInfo.Exists(WaitTime))
				{
					Report.Success("'QA Template Editor' is found after Multi Server Script Execute -- New Project");
				}
				else
				{
					Report.Error("'QA Template Editor' is not found after Multi Server Script Execute -- New Project");
				}
				Reports.ReportLog("CheckQATemplateMultiServerScriptExe", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : CheckQATemplateMultiServerScriptExe : " + ex.Message);
			}
		}
        
        public static void CheckQAEditorRandomTblDtGeneration()
		{
			try
			{
				if(repo.AquaDataStudioDailog.firstQAEditorRandomTblDtGenerationInfo.Exists(WaitTime))
				{
					Report.Success("'QA Template Editor' is found after Random Table and Data Generation template -- New Project");
				}
				else
				{
					Report.Error("'QA Template Editor' is not found after Random Table and Data Generation template -- New Project");
				}
				Reports.ReportLog("CheckQAEditorRandomTblDtGeneration", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : CheckQAEditorRandomTblDtGeneration : " + ex.Message);
			}
		}
        
        public static void CheckQAEditorSchemaCompare()
		{
			try
			{
				if(repo.AquaDataStudioDailog.SchemaCompareQAEditorInfo.Exists(WaitTime))
				{
					Report.Success("'QA Template Editor' is found after Schema Compare -- New Project");
				}
				else
				{
					Report.Error("'QA Template Editor' is not found after Schema Compare -- New Project");
				}
				Reports.ReportLog("CheckQAEditorSchemaCompare", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : CheckQAEditorSchemaCompare : " + ex.Message);
			}
		}
        
        public static void CheckQAEditorTransferRemoteCmdExe()
		{
			try
			{
				if(repo.AquaDataStudioDailog.FileTransferRemoteCmdExeFTPFromXjsInfo.Exists(WaitTime))
				{
					Report.Success("'QA Template Editor' is found after File Transfer and Remote Command Execution -- New Project");
				}
				else
				{
					Report.Error("'QA Template Editor' is not found after File Transfer and Remote Command Execution -- New Project");
				}
				Reports.ReportLog("CheckQAEditorTransferRemoteCmdExe", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : CheckQAEditorTransferRemoteCmdExe : " + ex.Message);
			}
		}
        
        public static void CloseQATemplateEditor()
		{
			try
			{
				if(repo.AquaDataStudioDailog.ADSSampleCreateAndEmailExcelFileXInfo.Exists(WaitTime))
				{
					repo.AquaDataStudioDailog.ADSSampleCreateAndEmailExcelFileXInfo.WaitForItemExists(WaitTime);
					repo.AquaDataStudioDailog.ADSSampleCreateAndEmailExcelFileX.RightClickThis();
					if(repo.SubMenuItems.CloseInfo.Exists(WaitTime))
					{
						repo.AquaDataStudioDailog.ADSSampleCreateAndEmailExcelFileX.RightClickThis();
					}
					repo.SubMenuItems.CloseInfo.WaitForItemExists(WaitTime);
					repo.SubMenuItems.Close.ClickThis();
				}		
				UnExpandTree(repo.AquaDataStudioDailog.ADSSample);
				RemoveProject(repo.AquaDataStudioDailog.ADSSample);
				Reports.ReportLog("CloseQATemplateEditor", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : CloseQATemplateEditor : " + ex.Message);
			}
		}
        
        public static void CloseQATemplateEditorDtSchemExporter()
		{
			try
			{
				if(repo.AquaDataStudioDailog.QATemplateEditorDtSchemExporterInfo.Exists(WaitTime)){
					repo.AquaDataStudioDailog.QATemplateEditorDtSchemExporterInfo.WaitForItemExists(WaitTime);
					repo.AquaDataStudioDailog.QATemplateEditorDtSchemExporter.RightClickThis();
					if(!repo.SubMenuItems.CloseInfo.Exists(WaitTime))
					{
						repo.AquaDataStudioDailog.QATemplateEditorDtSchemExporter.RightClickThis();
					}
					repo.SubMenuItems.CloseInfo.WaitForItemExists(WaitTime);
					repo.SubMenuItems.Close.ClickThis();
				}			
				
				repo.AquaDataStudioDailog.ADSDtSchemExporterInfo.WaitForItemExists(WaitTime);				
				UnExpandTree(repo.AquaDataStudioDailog.ADSDtSchemExporter);
				RemoveProject(repo.AquaDataStudioDailog.ADSDtSchemExporter);				
				Reports.ReportLog("CloseQATemplateEditorDtSchemExporter", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : CloseQATemplateEditorDtSchemExporter : " + ex.Message);
			}
		}
        
        public static void CloseQATemplateMultiServerScriptExe()
		{
			try
			{
				if(repo.AquaDataStudioDailog.MultiServerScriptExeMultiServerQAEditorInfo.Exists(WaitTime))
				{
					repo.AquaDataStudioDailog.MultiServerScriptExeMultiServerQAEditorInfo.WaitForItemExists(WaitTime);
					repo.AquaDataStudioDailog.MultiServerScriptExeMultiServerQAEditor.RightClickThis();
					if(!repo.SubMenuItems.CloseInfo.Exists(WaitTime))
						repo.AquaDataStudioDailog.MultiServerScriptExeMultiServerQAEditor.RightClickThis();
					repo.SubMenuItems.CloseInfo.WaitForItemExists(WaitTime);
					repo.SubMenuItems.Close.ClickThis();
				}			
				
				repo.AquaDataStudioDailog.FolderContainer.MultiServerScriptExeInfo.WaitForItemExists(WaitTime);
				UnExpandTree(repo.AquaDataStudioDailog.FolderContainer.MultiServerScriptExe);
				RemoveProject(repo.AquaDataStudioDailog.FolderContainer.MultiServerScriptExe);
				Reports.ReportLog("CloseQATemplateMultiServerScriptExe", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : CloseQATemplateMultiServerScriptExe : " + ex.Message);
			}
		}
        
        public static void CloseQAEditorRandomTableAndDtGeneration()
		{
			try
			{
				if(repo.AquaDataStudioDailog.TableGeneratorXjsInfo.Exists(WaitTime))
				{
					repo.AquaDataStudioDailog.TableGeneratorXjs.RightClickThis();
					if(!repo.SubMenuItems.CloseInfo.Exists(WaitTime))
						repo.AquaDataStudioDailog.TableGeneratorXjs.RightClickThis();
					repo.SubMenuItems.CloseInfo.WaitForItemExists(WaitTime);
					repo.SubMenuItems.Close.ClickThis();					
				}
				if(repo.AquaDataStudioDailog.ExecuteTableGenerationInfo.Exists(WaitTime))
				{
					repo.AquaDataStudioDailog.ExecuteTableGeneration.RightClickThis();
					if(!repo.SubMenuItems.CloseInfo.Exists(WaitTime))
						repo.AquaDataStudioDailog.ExecuteTableGeneration.RightClickThis();
					repo.SubMenuItems.CloseInfo.WaitForItemExists(WaitTime);
					repo.SubMenuItems.Close.ClickThis();					
				}
				if(repo.AquaDataStudioDailog.RandomDataGeneratorXjsInfo.Exists(WaitTime))
				{
					repo.AquaDataStudioDailog.RandomDataGeneratorXjs.RightClickThis();
					if(!repo.SubMenuItems.CloseInfo.Exists(WaitTime))
						repo.AquaDataStudioDailog.RandomDataGeneratorXjs.RightClickThis();
					repo.SubMenuItems.CloseInfo.WaitForItemExists(WaitTime);
					repo.SubMenuItems.Close.ClickThis();					
				}

				repo.AquaDataStudioDailog.RandomTblDtGenerationInfo.WaitForItemExists(WaitTime);
				UnExpandTree(repo.AquaDataStudioDailog.RandomTblDtGeneration);
				RemoveProject(repo.AquaDataStudioDailog.RandomTblDtGeneration);			
				Reports.ReportLog("CloseQAEditorRandomTableAndDtGeneration", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : CloseQAEditorRandomTableAndDtGeneration : " + ex.Message);
			}
		}
        
        public static void CloseQAEditorSchemaCompare()
		{
			try
			{
				if(repo.AquaDataStudioDailog.SchemaCompareQAEditorInfo.Exists(WaitTime)){
					repo.AquaDataStudioDailog.SchemaCompareQAEditorInfo.WaitForItemExists(WaitTime);
					repo.AquaDataStudioDailog.SchemaCompareQAEditor.RightClickThis();
					if(repo.SubMenuItems.CloseInfo.Exists(WaitTime))
						repo.AquaDataStudioDailog.SchemaCompareQAEditor.RightClickThis();
					repo.SubMenuItems.CloseInfo.WaitForItemExists(WaitTime);
					repo.SubMenuItems.Close.ClickThis();
				}			
				
				repo.AquaDataStudioDailog.SchemaCompareInfo.WaitForItemExists(WaitTime);
				UnExpandTree(repo.AquaDataStudioDailog.SchemaCompare);
				RemoveProject(repo.AquaDataStudioDailog.SchemaCompare);
				Reports.ReportLog("CloseQAEditorSchemaCompare", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : CloseQAEditorSchemaCompare : " + ex.Message);
			}
		}
        
        public static void CloseQATemplateEditorTabTransferRemoteCmdExe()
		{
			try
			{
				if(repo.AquaDataStudioDailog.FileTransferRemoteCmdExeFTPFromXjsInfo.Exists(WaitTime))
				{
					repo.AquaDataStudioDailog.FileTransferRemoteCmdExeFTPFromXjsInfo.WaitForItemExists(WaitTime);
					repo.AquaDataStudioDailog.FileTransferRemoteCmdExeFTPFromXjs.RightClickThis();
					if(!repo.SubMenuItems.CloseInfo.Exists(WaitTime))
						repo.AquaDataStudioDailog.FileTransferRemoteCmdExeFTPFromXjs.RightClickThis();
					repo.SubMenuItems.CloseInfo.WaitForItemExists(WaitTime);
					repo.SubMenuItems.Close.ClickThis();
				}			
				
				repo.AquaDataStudioDailog.FileTransferRemoteCmdExeInfo.WaitForItemExists(WaitTime);
				UnExpandTree(repo.AquaDataStudioDailog.FileTransferRemoteCmdExe);
				RemoveProject(repo.AquaDataStudioDailog.FileTransferRemoteCmdExe);			
				Reports.ReportLog("CloseQATemplateEditorTabTransferRemoteCmdExe", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : CloseQATemplateEditorTabTransferRemoteCmdExe : " + ex.Message);
			}
		}
        
        public static void RemoveFlotingFromServer()
		{
			try
			{
				Thread.Sleep(4000);
				if(repo.Servers.SettingsIconInfo.Exists(WaitTime))
				{
					repo.Servers.SettingsIcon.Click();
					Thread.Sleep(2000);
					if(!repo.SubMenuItems.FloatingModeInfo.Exists(WaitTime)){
						repo.Servers.SettingsIcon.Click();
					}
					repo.SubMenuItems.FloatingMode.ClickThis();
				}				
				Reports.ReportLog("RemoveFlotingFromServer", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : RemoveFlotingFromServer : " + ex.Message);
			}
		}
        
        public static void ExpandTree(Ranorex.TreeItem objTreeItem)
		{
			try
			{
				objTreeItem.MoveTo();
				objTreeItem.Element.SetAttributeValue("expanded", true);
				if(objTreeItem.Element.GetAttributeValue("expanded").ToString().Trim().ToUpper() == "FALSE")
				{
					objTreeItem.DoubleClick();
				}
				Reports.ReportLog("ExpandTree", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ExpandTree : " + ex.Message);
			}
		}
        
        public static void UnExpandTree(Ranorex.TreeItem objTreeItem)
		{
			try
			{
				objTreeItem.MoveTo();
				objTreeItem.Element.SetAttributeValue("expanded", false);
				if(objTreeItem.Element.GetAttributeValue("expanded").ToString().Trim().ToUpper() == "TRUE")
				{
					objTreeItem.DoubleClick();
				}
				Reports.ReportLog("UnExpandTree", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : UnExpandTree : " + ex.Message);
			}
		}
        
        public static void Cleanup(string strFolderName)
		{
			try 
			{
				Thread.Sleep(3000);
				Commons.Common.DeleteFolder(TC_10609_Path+"\\"+strFolderName);	
				Reports.ReportLog("Delete files and folders to cleanup", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
        	{
        		throw new Exception("Failed : Cleanup : " + ex.Message);
        	}
		}
        
        public static void ClickOnServersTab()
		{
			try
			{
				System.Threading.Thread.Sleep(2000);
				if(repo.AquaDataStudioDailog.ServersTabInfo.Exists(15000))
					repo.AquaDataStudioDailog.ServersTab.ClickThis();
				Reports.ReportLog("ClickOnServersTab", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnServersTab" +ex.Message);
			}
		}
        
        public static void RemoveProject(TreeItem objTreeItem)
        {
        	try 
			{
        		if(objTreeItem.Visible){
        			objTreeItem.RightClickThis();
        			if(repo.SubMenuItems.RemoveInfo.Exists(6000))
        			{
        				repo.SubMenuItems.Remove.ClickThis();
		        		if(repo.RemoveDailog.ButtonYesInfo.Exists(6000))
		        		{
		        			repo.RemoveDailog.ButtonYes.ClickThis();
		        		}
        			}	        		 
        		}        		       		
				Reports.ReportLog("RemoveProject", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
        	{
        		throw new Exception("Failed : RemoveProject : " + ex.Message);
        	}
        }
        
    	
    }
    
}
