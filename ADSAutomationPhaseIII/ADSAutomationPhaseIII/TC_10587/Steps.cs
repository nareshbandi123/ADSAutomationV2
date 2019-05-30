using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using Ranorex;
using Ranorex.Core.Repository;
using WinForms = System.Windows.Forms;

using Ranorex.Core;
using Ranorex.Core.Testing;
using ADSAutomationPhaseIII.Base;
using ADSAutomationPhaseIII.Extensions;
using ADSAutomationPhaseIII.Commons;
using ADSAutomationPhaseIII.Preconditions;
using ADSAutomationPhaseIII.Configuration;

namespace ADSAutomationPhaseIII.TC_10587
{
	public class Steps
	{
		public static TC10587 repo = TC10587.Instance;
		public static string TC_10587_PATH = System.Configuration.ConfigurationManager.AppSettings["TC_10587_Path"].ToString();
		
		public static void ClickOnFilesTab()
		{
			try
			{
				if(repo.Application.FileSystemInfo.Exists(3000))
				{
					//do nothing
				}
				else
				{
					repo.Application.FilesTabInfo.WaitForItemExists(30000);
					repo.Application.FilesTab.ClickThis();
				}
				Reports.ReportLog("ClickOnFilesTab", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnFilesTab" +ex.Message);
			}
		}
		
		public static void NavigateToPerforce()
		{
			try
			{
				repo.Application.FileSystemInfo.WaitForItemExists(30000);
				repo.Application.FileSystem.RightClickThis();
				Reports.ReportLog("FileSystem", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				repo.Datastudio.VersionControlInfo.WaitForItemExists(30000);
				repo.Datastudio.VersionControl.ClickThis();
				Reports.ReportLog("VersionControl", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				repo.Datastudio1.PerforceInfo.WaitForItemExists(30000);
				repo.Datastudio1.Perforce.ClickThis();
				Reports.ReportLog("Perforce", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				repo.Datastudio2.CheckoutInfo.WaitForItemExists(30000);
				repo.Datastudio2.Checkout.ClickThis();
				Reports.ReportLog("Checkout", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : NavigateToPerforce" +ex.Message);
			}
		}
		
		public static void NavigateToPerforce1()
		{
			try
			{
				repo.Application.RepositoryPath1Info.WaitForItemExists(30000);
				repo.Application.RepositoryPath1.RightClickThis();
				Reports.ReportLog("RepositoryPath1", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				repo.Datastudio.VersionControlInfo.WaitForItemExists(30000);
				repo.Datastudio.VersionControl.ClickThis();
				Reports.ReportLog("VersionControl", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				repo.Datastudio1.PerforceInfo.WaitForItemExists(30000);
				repo.Datastudio1.Perforce.ClickThis();
				Reports.ReportLog("Perforce", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				repo.Datastudio2.CheckoutInfo.WaitForItemExists(30000);
				repo.Datastudio2.Checkout.ClickThis();
				Reports.ReportLog("Checkout", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : NavigateToPerforce" +ex.Message);
			}
		}
		
		public static void EnterURL()
		{
			try
			{
				repo.Configuration.UrlInfo.WaitForItemExists(30000);
				repo.Configuration.Url.TextBoxText("p4jrpc://172.24.1.154:1666");
				Reports.ReportLog("EnterURL", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : EnterURL" +ex.Message);
			}
		}
		
		public static void EnterUsername()
		{
			try
			{
				repo.Configuration.UsernameInfo.WaitForItemExists(30000);
				repo.Configuration.Username.TextBoxText("cigniti");
				Reports.ReportLog("EnterUsername", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : EnterUsername" +ex.Message);
			}
		}
		
		public static void EnterPassword()
		{
			try
			{
				repo.Configuration.PasswordInfo.WaitForItemExists(30000);
				repo.Configuration.Password.TextBoxText("cigniti");
				Reports.ReportLog("EnterPassword", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : EnterPassword" +ex.Message);
			}
		}
		
		public static void CreateNewPerforce()
		{
			try
			{
				repo.Configuration.CreateNewPerforceInfo.WaitForItemExists(30000);
				repo.Configuration.CreateNewPerforce.ClickThis();
				Reports.ReportLog("CreateNewPerforce", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CreateNewPerforce" +ex.Message);
			}
		}
		
		public static void CreateWorkspace()
		{
			try
			{
				repo.Configuration.WorkspaceInfo.WaitForItemExists(30000);
				repo.Configuration.Workspace.TextBoxText("ADS");
				Reports.ReportLog("CreateWorkspace", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CreateWorkspace" +ex.Message);
			}
		}
		
		public static void CreateFolderPath()
		{
			try
			{
				repo.Configuration.FolderInfo.WaitForItemExists(30000);
				repo.Configuration.Folder.TextBoxText("C:\\Users\\Admin\\Documents\\Aqua Data Studio Repository");
				Reports.ReportLog("CreateFolderPath", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CreateFolderPath" +ex.Message);
			}
		}
		
		public static void ClickConfigurationOk()
		{
			try
			{
				repo.Configuration.OkButtonInfo.WaitForItemExists(30000);
				repo.Configuration.OkButton.ClickThis();
				Reports.ReportLog("ClickConfigurationOk", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickConfigurationOk" +ex.Message);
			}
		}
		
		public static void ClickCheckoutOk()
		{
			try
			{
				System.Threading.Thread.Sleep(3000);
				repo.Checkout.OkButtonInfo.WaitForItemExists(30000);
				repo.Checkout.OkButton.ClickThis();
				Reports.ReportLog("ClickCheckoutOk", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickCheckoutOk" +ex.Message);
			}
		}
		
		public static void SelectExistingRepository()
		{
			try
			{
				repo.Configuration.SelectExistingInfo.WaitForItemExists(30000);
				repo.Configuration.SelectExisting.ClickThis();
				Reports.ReportLog("SelectExistingRepository", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectExistingRepository" +ex.Message);
			}
		}
		
		public static void CreateNewFile()
		{
			try
			{
				repo.Application.RepositoryPath2Info.WaitForItemExists(30000);
				repo.Application.RepositoryPath2.RightClickThis();
				repo.Datastudio.NewInfo.WaitForItemExists(30000);
				repo.Datastudio.New.ClickThis();
				repo.CreateFile.NameInfo.WaitForItemExists(30000);
				repo.CreateFile.Name.TextBoxText("Test" + System.DateTime.Now.ToString("yyyyMMddHHmmssfff"));
				repo.CreateFile.OkButtonInfo.WaitForItemExists(30000);
				repo.CreateFile.OkButton.ClickThis();
				
				Reports.ReportLog("CreateNewFile", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CreateNewFile" +ex.Message);
			}
		}
		
		public static void MarkForAdd()
		{
			try
			{
				repo.Application.RepositoryPath2Info.WaitForItemExists(30000);
				repo.Application.RepositoryPath2.Expand();
				
				repo.Application.TestFileInfo.WaitForItemExists(30000);
				repo.Application.TestFile.RightClickThis();
				repo.Datastudio.VersionControlInfo.WaitForItemExists(30000);
				repo.Datastudio.VersionControl.ClickThis();
				repo.Datastudio.MarkForAddInfo.WaitForItemExists(30000);
				repo.Datastudio.MarkForAdd.ClickThis();
				repo.MarkForAdd.OkButtonInfo.WaitForItemExists(30000);
				repo.MarkForAdd.OkButton.ClickThis();
				
				Reports.ReportLog("MarkForAdd", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : MarkForAdd" +ex.Message);
			}
		}
		
		public static void Commit()
		{
			try
			{
				repo.Application.TestFileInfo.WaitForItemExists(30000);
				repo.Application.TestFile.RightClickThis();
				repo.SunAwtWindow.CommitInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.Commit.ClickThis();
				repo.Commit.CommitButtonInfo.WaitForItemExists(30000);
				repo.Commit.CommitButton.ClickThis();
				Reports.ReportLog("Commit", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : Commit" +ex.Message);
			}
		}
		
		public static void UpdateSync()
		{
			try
			{
				repo.Application.TestFileInfo.WaitForItemExists(30000);
				repo.Application.TestFile.RightClickThis();
				repo.SunAwtWindow.UpdateSyncInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.UpdateSync.ClickThis();
				repo.Update.OkButtonInfo.WaitForItemExists(30000);
				repo.Update.OkButton.ClickThis();
				Reports.ReportLog("UpdateSync", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : UpdateSync" +ex.Message);
			}
		}
		
		public static void ChekoutFile()
		{
			try
			{
				repo.Application.TestFileInfo.WaitForItemExists(30000);
				repo.Application.TestFile.RightClickThis();
				repo.Datastudio.VersionControlInfo.WaitForItemExists(30000);
				repo.Datastudio.VersionControl.ClickThis();
				repo.Datastudio.CheckoutInfo.WaitForItemExists(30000);
				repo.Datastudio.Checkout.ClickThis();
				Reports.ReportLog("ChekoutFile", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ChekoutFile" +ex.Message);
			}
		}
		
		public static void OpenTextEditor()
		{
			try
			{
				repo.Application.TestFileInfo.WaitForItemExists(30000);
				repo.Application.TestFile.RightClickThis();
				repo.SunAwtWindow.OpenInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.Open.ClickThis();
				repo.TextEditor.OpenTextEditorInfo.WaitForItemExists(30000);
				repo.TextEditor.OpenTextEditor.ClickThis();
				Reports.ReportLog("OpenTextEditor", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : OpenTextEditor" +ex.Message);
			}
		}
		
		public static void EditText()
		{
			try
			{
				repo.AquaDataStudio.EditorWindow.Click();
				repo.AquaDataStudio.EditorWindow.PressKeys("SELECT * FROM ADS");
				repo.AquaDataStudio.EditorWindow.Click();
				repo.AquaDataStudio.SaveInfo.WaitForItemExists(30000);
				repo.AquaDataStudio.Save.ClickThis();
				Reports.ReportLog("EditText", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : EditText" +ex.Message);
			}
		}
		
		public static void CloseEditor()
		{
			try
			{
				System.Threading.Thread.Sleep(3000);
				Keyboard.Press(Keyboard.ToKey("Ctrl+F4"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				System.Threading.Thread.Sleep(3000);
				Reports.ReportLog("CloseEditor", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CloseEditor" +ex.Message);
			}
		}
		
		public static void CommitEditing()
		{
			try
			{
				repo.Application.TestFileInfo.WaitForItemExists(30000);
				repo.Application.TestFile.RightClickThis();
				repo.SunAwtWindow.CommitInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.Commit.ClickThis();
				repo.Commit.CommitButtonInfo.WaitForItemExists(30000);
				repo.Commit.CommitButton.ClickThis();
				Reports.ReportLog("CommitEditing", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CommitEditing" +ex.Message);
			}
		}
		
		public static void ClickOnServersTab()
		{
			try
			{
				System.Threading.Thread.Sleep(3000);
				repo.Application.ServersTabInfo.WaitForItemExists(30000);
				repo.Application.ServersTab.ClickThis();
				Reports.ReportLog("ClickOnServersTab", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnServersTab" +ex.Message);
			}
		}
		
		public static void UnMountWorkSpace()
		{
			try
			{
				System.Threading.Thread.Sleep(3000);
				repo.Application.RepositoryPath1Info.WaitForItemExists(30000);
				repo.Application.RepositoryPath1.RightClickThis();
				repo.Datastudio.UnMountInfo.WaitForItemExists(30000);
				repo.Datastudio.UnMount.ClickThis();
				repo.UnMount.YesInfo.WaitForItemExists(30000);
				repo.UnMount.Yes.ClickThis();
				Reports.ReportLog("UnMountWorkSpace", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : UnMountWorkSpace" +ex.Message);
			}
		}
		
		public static void SelectBrowseDepots()
		{
			try
			{
				repo.Application.RepositoryPath1Info.WaitForItemExists(30000);
				repo.Application.RepositoryPath1.RightClickThis();
				repo.Datastudio.VersionControlInfo.WaitForItemExists(30000);
				repo.Datastudio.VersionControl.ClickThis();
				repo.Datastudio1.BrowseDepotsInfo.WaitForItemExists(30000);
				repo.Datastudio1.BrowseDepots.ClickThis();
				System.Threading.Thread.Sleep(3000);
				Reports.ReportLog("SelectBrowseDepots", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectBrowseDepots" +ex.Message);
			}
		}
		
		public static void ExpandDepot()
		{
			try
			{
				repo.PerforceServer.DepotInfo.WaitForItemExists(30000);
				repo.PerforceServer.Depot.DoubleClickThis();
				System.Threading.Thread.Sleep(3000);
				repo.PerforceServer.CloseInfo.WaitForItemExists(30000);
				repo.PerforceServer.Close.ClickThis();
				Reports.ReportLog("ExpandDepot", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ExpandDepot" +ex.Message);
			}
		}
		
		public static void SelectEditWorspaceClient()
		{
			try
			{
				repo.Application.RepositoryPath1Info.WaitForItemExists(30000);
				repo.Application.RepositoryPath1.RightClickThis();
				repo.Datastudio.VersionControlInfo.WaitForItemExists(30000);
				repo.Datastudio.VersionControl.ClickThis();
				repo.Datastudio1.EditWorkspaceClientInfo.WaitForItemExists(30000);
				repo.Datastudio1.EditWorkspaceClient.ClickThis();
				Reports.ReportLog("SelectEditWorspaceClient", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectEditWorspaceClient" +ex.Message);
			}
		}
		
		public static void ClickOnView()
		{
			try
			{
				repo.Edit.ViewTabInfo.WaitForItemExists(30000);
				repo.Edit.ViewTab.ClickThis();
				Reports.ReportLog("ClickOnView", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnView" +ex.Message);
			}
		}
		
		public static void ExpandView()
		{
			try
			{
				repo.Edit.DepotInfo.WaitForItemExists(30000);
				repo.Edit.Depot.DoubleClickThis();
				repo.Edit.F1Info.WaitForItemExists(30000);
				repo.Edit.F1.RightClickThis();
				repo.Edit.CloseInfo.WaitForItemExists(30000);
				repo.Edit.Close.ClickThis();
				Reports.ReportLog("ExpandView", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ExpandView" +ex.Message);
			}
		}
		
		public static void ShowHistory()
		{
			try
			{
				repo.Application.RepositoryPath1Info.WaitForItemExists(30000);
				repo.Application.RepositoryPath1.RightClickThis();
				repo.Datastudio.VersionControlInfo.WaitForItemExists(30000);
				repo.Datastudio.VersionControl.ClickThis();
				repo.Datastudio1.ShowHistoryInfo.WaitForItemExists(30000);
				repo.Datastudio1.ShowHistory.ClickThis();
				Reports.ReportLog("ShowHistory", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ShowHistory" +ex.Message);
			}
		}
		
		public static void ValidateRevisionHistory()
		{
			try
			{
				repo.History.RevisionHistoryInfo.WaitForItemExists(30000);
				if(repo.History.RevisionHistory.IsHeader)
				{
					Reports.ReportLog("ValidateRevisionHistory", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateRevisionHistory" +ex.Message);
			}
		}
		
		public static void ValidateDateSubmitted()
		{
			try
			{
				repo.History.DateSubmittedInfo.WaitForItemExists(30000);
				if(repo.History.DateSubmitted.IsHeader)
				{
					Reports.ReportLog("ValidateDateSubmitted", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateDateSubmitted" +ex.Message);
			}
		}
		
		public static void ValidateSubmittedBy()
		{
			try
			{
				repo.History.SubmittedByInfo.WaitForItemExists(30000);
				if(repo.History.SubmittedBy.IsHeader)
				{
					Reports.ReportLog("ValidateSubmittedBy", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateSubmittedBy" +ex.Message);
			}
		}
		
		public static void ValidateDescription()
		{
			try
			{
				repo.History.DescriptionInfo.WaitForItemExists(30000);
				if(repo.History.Description.IsHeader)
				{
					Reports.ReportLog("ValidateDescription", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateDescription" +ex.Message);
			}
		}
		
		public static void ShowChanges()
		{
			try
			{
				repo.History.RevisionCellInfo.WaitForItemExists(30000);
				repo.History.RevisionCell.RightClickThis();
				repo.SunAwtWindow.ShowChangesInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.ShowChanges.ClickThis();
				repo.CompareWindow.CloseInfo.WaitForItemExists(30000);
				repo.CompareWindow.Close.ClickThis();
				repo.History.CloseInfo.WaitForItemExists(30000);
				repo.History.Close.ClickThis();
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ShowChanges" +ex.Message);
			}
		}
	}
}
