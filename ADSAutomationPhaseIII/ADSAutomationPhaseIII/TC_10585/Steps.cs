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


namespace ADSAutomationPhaseIII.TC_10585
{
    
    public class Steps
    {
        public static TC10585Repo repo = TC10585Repo.Instance;
		public static string TC_10585_Path = System.Configuration.ConfigurationManager.AppSettings["TC_10585_Path"].ToString();
		public static int WaitForTime = 20000;
		public static int delay = 2000;
		
		public static void ClickOnLWindowIconKeyboard()
		{
			try 
			{
				Thread.Sleep(5000);
				Keyboard.Press("{LWin}");
				Keyboard.Press("TortoiseSVN Repository Browser");
				Thread.Sleep(delay);
				Keyboard.Press("{Return}");
				Reports.ReportLog("ClickOnLWindowIconKeyboard", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);				
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnLWindowIconKeyboard : " + ex.Message);
			}			
		}
		
		public static void SetRepoURL(string strRepoURL)
		{
			try 
			{
				repo.FormURLDialog.txtURLInfo.WaitForItemExists(WaitForTime);
				repo.FormURLDialog.txtURL.TextBoxText(strRepoURL);
				Reports.ReportLog("SetRepoURL", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);				
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : SetRepoURL : " + ex.Message);
			}			
		}
		
		public static void ClickOKonSVN()
		{
			try 
			{
				repo.FormURLDialog.ButtonOKInfo.WaitForItemExists(WaitForTime);
				repo.FormURLDialog.ButtonOK.ClickThis();
				Reports.ReportLog("ClickOKonSVN", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);				
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOKonSVN : " + ex.Message);
			}			
		}
		
		public static void CreateFolderSVN(string strFolderName)
		{
			try 
			{
				repo.SvnReposTestAuto.AquaDtStudioRepoInfo.WaitForItemExists(WaitForTime);
				if(!repo.SvnReposTestAuto.ADSSqlInfo.Exists(delay))
				{
					repo.SvnReposTestAuto.AquaDtStudioRepo.RightClick();
					repo.SVNSubMenuItems.CreateFolderInfo.WaitForItemExists(WaitForTime);
					repo.SVNSubMenuItems.CreateFolder.ClickThis();
					repo.CreateFolder.FolderNameInfo.WaitForItemExists(WaitForTime);
					repo.CreateFolder.FolderName.TextBoxText(strFolderName);
					repo.CreateFolder.ButtonOK.ClickThis();
					
					Steps.AcceptFolderCreationSVN();
        			Steps.AuthenticationSVN("cigniti", "cigniti");
				}				
				Reports.ReportLog("CreateFolderSVN", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);				
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : CreateFolderSVN : " + ex.Message);
			}			
		}
		
		public static void CheckCreatedFolderSVN()
		{
			try 
			{
				if(repo.SvnReposTestAuto.ADSSqlInfo.Exists(delay))
				{
					Report.Success("Created Folder 'ADS' in SVN Browser");
				}
				else
				{
					throw new Exception("Failed : CheckFolderFolderCreatedSVN: ");
				}
				Reports.ReportLog("CheckCreatedFolderSVN", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);				
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : CheckCreatedFolderSVN : " + ex.Message);
			}			
		}
		
		public static void CloseSVNBrowser()
		{
			try 
			{
				if(repo.SvnReposTestAuto.SelfInfo.Exists(delay))
				{
					repo.SvnReposTestAuto.Self.Close();
				}
				Reports.ReportLog("CloseSVNBrowser", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);				
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : CloseSVNBrowser : " + ex.Message);
			}			
		}
		
		public static void AcceptFolderCreationSVN()
		{
			try 
			{
				repo.EnterLogMessage.ButtonOKInfo.WaitForItemExists(WaitForTime);
				repo.EnterLogMessage.ButtonOK.ClickThis();
				Reports.ReportLog("AcceptFolderCreationSVN", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);				
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : AcceptFolderCreationSVN : " + ex.Message);
			}			
		}
		
		public static void AuthenticationSVN(string strUn, string strPWD)
		{
			try 
			{
				if(repo.Authentication.SelfInfo.Exists(delay))
				{
					repo.Authentication.txtUNInfo.WaitForItemExists(delay);
					repo.Authentication.txtUN.TextBoxText(strUn);
					repo.Authentication.txtPWD.TextBoxText(strPWD);
					repo.Authentication.ButtonOK.ClickThis();
				}
				Reports.ReportLog("AuthenticationSVN", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);				
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : AuthenticationSVN : " + ex.Message);
			}			
		}
		
		public static void CreateSVNRepositoryFolder()
		{
			try 
			{
				//TODO: 1. Open Tortoise SVN - Repo Browser, 2. Provide URL "svn://172.24.1.154/C:\Repos\TestAutomation" in Tortoise SVN, 2. Create a folder (ex: ADS) in Tortoise SVN repository
				Reports.ReportLog("CreateSVNRepositoryFolder", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : CreateSVNRepositoryFolder : " + ex.Message);
			}			
		}
		
		public static void ClickOnFilesTab()
		{
			try
			{
				if(!repo.AquaDataStudio.FileSystemTreeInfo.Exists(30000))
				{
					repo.AquaDataStudio.F2FilesTabInfo.WaitForExists(WaitForTime);
					repo.AquaDataStudio.F2FilesTab.ClickThis();
					if(!repo.AquaDataStudio.F2FilesTab.Checked)
					{
						repo.AquaDataStudio.F2FilesTabInfo.WaitForExists(WaitForTime);
						repo.AquaDataStudio.F2FilesTab.ClickThis();
					}						
				}
				Reports.ReportLog("ClickOnFilesTab", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnFilesTab : " + ex.Message);
			}
		}
		
		public static void RightClickOnFileSystemTree()
		{
			try
			{
				if(!repo.AquaDataStudio.FileSystemTreeInfo.Exists(WaitForTime))
				{
					repo.AquaDataStudio.F2FilesTab.ClickThis();
					repo.AquaDataStudio.FileSystemTreeInfo.WaitForExists(15000);
				}
				repo.AquaDataStudio.FileSystemTree.ClickThis();
				repo.AquaDataStudio.FileSystemTree.RightClickThis();
				Reports.ReportLog("RightClickOnFileSystemTree", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : RightClickOnFileSystemTree : " + ex.Message);
			}
		}
		
		public static void ClickOnVersionControl()
		{
			try
			{
				repo.SubMenuItem.VersionControlInfo.WaitForItemExists(WaitForTime);
				repo.SubMenuItem.VersionControl.ClickThis();
				Reports.ReportLog("ClickOnVersionControl", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnVersionControl : " + ex.Message);
			}
		}
		
		public static void NavigateOnVersionControlAndSubversion()
		{
			try
			{
				if(!repo.SubMenuItem.VersionControlInfo.Exists(WaitForTime))
				{
					repo.AquaDataStudio.FileSystemTree.ClickThis();
					repo.AquaDataStudio.FileSystemTree.RightClickThis();
				}
				repo.SubMenuItem.VersionControl.ClickThis();
				repo.SubMenuItem.SubversionInfo.WaitForItemExists(WaitForTime);
				repo.SubMenuItem.Subversion.ClickThis();
				Reports.ReportLog("NavigateOnVersionControlAndSubversion", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : NavigateOnVersionControlAndSubversion : " + ex.Message);
			}
		}
		
		public static void ClickOnCheckout()
		{
			try
			{
				repo.SubMenuItem.CheckoutInfo.WaitForExists(WaitForTime);
				repo.SubMenuItem.Checkout.ClickThis();
				Reports.ReportLog("ClickOnCheckout", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnCheckout : " + ex.Message);
			}
		}
		
		public static void VerifyConfVersionControlDailog()
		{
			try
			{
				if(repo.ConfigureVersionControlDailog.SelfInfo.Exists(WaitForTime))
				{
					Report.Success("Configure Version Control Dailog Found");
				}
				else
				{
					throw new Exception("Failed : VerifyConfVersionControlDailog : Configure Version Control Dailog Not Found");
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : VerifyConfVersionControlDailog : " + ex.Message);
			}
		}
		
		public static void SetRepoPath(string strRepoURL)
		{
			try
			{
				repo.ConfigureVersionControlDailog.RepoPathInfo.WaitForItemExists(WaitForTime);
				repo.ConfigureVersionControlDailog.RepoPath.TextBoxText(strRepoURL);
				Reports.ReportLog("SetRepoPath", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SetRepoPath : " + ex.Message);
			}
		}
		
		public static void SetUserName(string strUN)
		{
			try
			{
				repo.ConfigureVersionControlDailog.UsernameFieldInfo.WaitForItemExists(WaitForTime);
				repo.ConfigureVersionControlDailog.UsernameField.TextBoxText(strUN);
				Reports.ReportLog("SetUserName", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SetUserName : " + ex.Message);
			}
		}
		
		public static void SetPassword(string strPWD)
		{
			try
			{
				repo.ConfigureVersionControlDailog.PasswordFieldInfo.WaitForItemExists(WaitForTime);
				repo.ConfigureVersionControlDailog.PasswordField.TextBoxText(strPWD);
				Reports.ReportLog("SetPassword", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SetPassword : " + ex.Message);
			}
		}
		
		public static void ClickOnHEAD()
		{
			try
			{
				repo.ConfigureVersionControlDailog.HEADInfo.WaitForItemExists(WaitForTime);
				repo.ConfigureVersionControlDailog.HEAD.ClickThis();
				Reports.ReportLog("ClickOnHEAD", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnHEAD : " + ex.Message);
			}
		}
		
		public static void SetCheckoutDirectory(string strCheckoutDir)
		{
			try
			{
				repo.ConfigureVersionControlDailog.CheckoutFolderPathInfo.WaitForItemExists(WaitForTime);
				repo.ConfigureVersionControlDailog.CheckoutFolderPath.TextBoxText(TC_10585_Path+strCheckoutDir);				
				Reports.ReportLog("SetCheckoutDirectory", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SetCheckoutDirectory : " + ex.Message);
			}
		}
		
		public static void ClickOnOkButton()
		{
			try
			{
				repo.ConfigureVersionControlDailog.ButtonOKInfo.WaitForItemExists(WaitForTime);
				repo.ConfigureVersionControlDailog.ButtonOK.ClickThis();
				Reports.ReportLog("ClickOnOkButton", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnOkButton : " + ex.Message);
			}
		}
		
		public static void CheckCompletedStatus()
		{
			try
			{
				repo.Checkout.CompletedStatusInfo.WaitForItemExists(WaitForTime);
				Reports.ReportLog("CheckCompletedStatus", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				if(repo.Checkout.SelfInfo.Exists(delay))
				{
					repo.Checkout.Self.Close();
				}
				throw new Exception("Failed : CheckCompletedStatus : " + ex.Message);
			}
		}
		
		public static void ClickOnOKCheckout()
		{
			try
			{
				repo.Checkout.ButtonOKInfo.WaitForItemExists(WaitForTime);
				repo.Checkout.ButtonOK.ClickThis();
				Reports.ReportLog("ClickOnOKCheckout", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				if(repo.Checkout.SelfInfo.Exists(delay))
				{
					repo.Checkout.Self.Close();
				}
				throw new Exception("Failed : ClickOnOKCheckout : " + ex.Message);
			}
		}
		
		public static void CloseConfigureVersionControlDailog()
		{
			try
			{
				if(repo.ConfigureVersionControlDailog.SelfInfo.Exists(6000))
				{
					repo.ConfigureVersionControlDailog.Self.Close();
					Reports.ReportLog("CloseConfigureVersionControlDailog", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CloseConfigureVersionControlDailog : " + ex.Message);
			}
		}
		
		public static void ExpandSVNTree()
		{
			try
			{
				repo.AquaDataStudio.SVNTreeInfo.WaitForItemExists(WaitForTime);
				repo.AquaDataStudio.SVNTree.Expand();
				Reports.ReportLog("ExpandSVNTree", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ExpandSVNTree : " + ex.Message);
			}
		}
		
		public static void RightClickOnSVNTree()
		{
			try
			{
				repo.AquaDataStudio.SVNTreeInfo.WaitForItemExists(WaitForTime);
				repo.AquaDataStudio.SVNTree.Expand();
				repo.AquaDataStudio.SVNTree.RightClick();
				Reports.ReportLog("RightClickOnSVNTree", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : RightClickOnSVNTree : " + ex.Message);
			}
		}
		
		public static void ClickOnNew()
		{
			try
			{
					repo.AquaDataStudio.SVNTreeInfo.WaitForItemExists(WaitForTime);
					repo.AquaDataStudio.SVNTree.RightClick();
					repo.SubMenuItem.MenuItemNewInfo.WaitForItemExists(WaitForTime);
					repo.SubMenuItem.MenuItemNew.ClickThis();
						
				Reports.ReportLog("ClickOnNew", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnNew : " + ex.Message);
			}
		}
		
		public static void ProvideName(string strName)
		{
			try
			{
//				if(repo.CreateNewFile.NameFieldInfo.Exists(WaitForTime))
				repo.CreateNewFile.NameField.TextBoxText(strName);
				Reports.ReportLog("ProvideName", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ProvideName : " + ex.Message);
			}
		}
		
		public static void ClickOnOKNewFile()
		{
			try
			{
//				if(repo.CreateNewFile.ButtonOKInfo.Exists(WaitForTime))
					repo.CreateNewFile.ButtonOK.ClickThis();
				Reports.ReportLog("ClickOnOKNewFile", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnOKNewFile : " + ex.Message);
			}
		}
		
		public static void RightClickOnADSFile()
		{
			try
			{
				if(repo.AquaDataStudio.ADSSqlInfo.Exists(WaitForTime))
					repo.AquaDataStudio.ADSSql.RightClickThis();
				Reports.ReportLog("RightClickOnADSFile", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : RightClickOnADSFile : " + ex.Message);
			}
		}	
		
		public static void ClickOnDeleteToVersionControl()
		{
			try
			{
				Thread.Sleep(2000);
				repo.SubMenuItem.DeleteCVInfo.WaitForItemExists(WaitForTime);
				repo.SubMenuItem.DeleteCV.ClickThis();
				Reports.ReportLog("ClickOnDeleteToVersionControl", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnDeleteToVersionControl : " + ex.Message);
			}
		}

		public static void CompletedStatusDeletedFile()
		{
			try
			{
				repo.DeleteDialog.CompletedInfo.WaitForItemExists(WaitForTime);				
				Reports.ReportLog("CompletedStatusDeletedFile", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CompletedStatusDeletedFile : " + ex.Message);
			}
		}
		
		public static void ClickOnOkButtonDeletedFile()
		{
			try
			{
				repo.DeleteDialog.ButtonOKInfo.WaitForItemExists(WaitForTime);	
				repo.DeleteDialog.ButtonOK.ClickThis();
				Reports.ReportLog("ClickOnOkButtonDeletedFile", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnOkButtonDeletedFile : " + ex.Message);
			}
		}
		
		public static void ClickOnDeleteFile()
		{
			try
			{
				repo.SubMenuItem.DeleteInfo.WaitForItemExists(WaitForTime);
				repo.SubMenuItem.Delete.ClickThis();
				Reports.ReportLog("ClickOnDeleteFile", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnDeleteFile : " + ex.Message);
			}
		}
		
		public static void ClickOnYes()
		{
			try
			{
				repo.DeleteDialog.ButtonYesInfo.WaitForItemExists(WaitForTime);
				repo.DeleteDialog.ButtonYes.ClickThis();
				Reports.ReportLog("ClickOnYes", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnYes : " + ex.Message);
			}
		}
		
		public static void RightClickOnTest1Sql()
		{
			try
			{
				repo.AquaDataStudio.Test1SqlInfo.WaitForItemExists(WaitForTime);
				repo.AquaDataStudio.Test1Sql.RightClickThis();
				Reports.ReportLog("RightClickOnTest1Sql", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : RightClickOnTest1Sql : " + ex.Message);
			}
		}
		
		public static void ClickOnOpen()
		{
			try
			{
				repo.SubMenuItem.OpenInfo.WaitForItemExists(WaitForTime);
				repo.SubMenuItem.Open.ClickThis();
				Reports.ReportLog("ClickOnOpen", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnOpen : " + ex.Message);
			}
		}
		
		public static void ClickOnOpenInTextEditor()
		{
			try
			{
				repo.ChooseServerOrDatabase.OpenInTextEditorInfo.WaitForItemExists(WaitForTime);
				repo.ChooseServerOrDatabase.OpenInTextEditor.ClickThis();
				Reports.ReportLog("ClickOnOpenInTextEditor", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				if(repo.ChooseServerOrDatabase.SelfInfo.Exists(delay))
				{
					repo.ChooseServerOrDatabase.Self.Close();
				}
				throw new Exception("Failed : ClickOnOpenInTextEditor : " + ex.Message);
			}
		}
		
		public static void ModifyScriptsAndClickOnSaveIcon(string strDt)
		{
			try
			{
				repo.AquaDataStudio.SaveIconInfo.WaitForItemExists(WaitForTime);
				Keyboard.Press(strDt);
				repo.AquaDataStudio.SaveIcon.ClickThis();
				repo.AquaDataStudio.SVNTree.MoveTo();
				Thread.Sleep(2000);
//				Keyboard.Press(System.Windows.Forms.Keys.S | System.Windows.Forms.Keys.Control, Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Reports.ReportLog("ModifyScriptsAndClickOnSaveIcon", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ModifyScriptsAndClickOnSaveIcon : " + ex.Message);
			}
		}
		
		public static void CloseEditorTab()
		{
			try
			{
				repo.AquaDataStudio.EditorTest1SqlInfo.WaitForItemExists(WaitForTime);
				repo.AquaDataStudio.EditorTest1Sql.RightClickThis();
				repo.SubMenuItem.CloseInfo.WaitForItemExists(WaitForTime);
				repo.SubMenuItem.Close.ClickThis();
				Reports.ReportLog("CloseEditorTab", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CloseEditorTab : " + ex.Message);
			}
		}
		
		public static void ClickOnRevert()
		{
			try
			{
				repo.SubMenuItem.RevertInfo.WaitForItemExists(WaitForTime);
				repo.SubMenuItem.Revert.ClickThis();
				Reports.ReportLog("ClickOnRevert", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnRevert : " + ex.Message);
			}
		}
		
		public static void CheckCompletedStatusRevert()
		{
			try
			{
				repo.Revert.CompletedInfo.WaitForItemExists(WaitForTime);
				Reports.ReportLog("CheckCompletedStatusRevert", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CheckCompletedStatusRevert : " + ex.Message);
			}
		}
		
		public static void ClickOnOKButtonOnRevert()
		{
			try
			{
				repo.Revert.ButtonOKInfo.WaitForItemExists(WaitForTime);
				repo.Revert.ButtonOK.ClickThis();
				Reports.ReportLog("ClickOnOKButtonOnRevert", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnOKButtonOnRevert : " + ex.Message);
			}
		}
		
		public static void RightClickOnSVN()
		{
			try
			{
				repo.AquaDataStudio.SVNTreeInfo.WaitForItemExists(WaitForTime);
				repo.AquaDataStudio.SVNTree.ClickThis();
				Reports.ReportLog("RightClickOnSVN", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : RightClickOnSVN : " + ex.Message);
			}
		}
		
		public static void Cleanup(string strFolderName)
		{
			try 
			{
				Commons.Common.DeleteFolder(TC_10585_Path + strFolderName);	
				Reports.ReportLog("Delete files and folders to cleanup", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
        	{
        		throw new Exception("Failed : Cleanup : " + ex.Message);
        	}
		}
		
		public static void DeleteSVNTree()
		{
			try 
			{
				if(repo.AquaDataStudio.SVNTreeInfo.Exists(WaitForTime))
				{
					repo.AquaDataStudio.SVNTree.ClickThis();
					repo.AquaDataStudio.SVNTree.RightClick();
					if(!repo.SubMenuItem.UnmountDirectoryInfo.Exists(WaitForTime))
					{
						repo.AquaDataStudio.SVNTree.ClickThis();
						repo.AquaDataStudio.SVNTree.RightClick();
					}
					Thread.Sleep(1000);
					repo.SubMenuItem.UnmountDirectory.ClickThis();
					repo.Unmount.ButtonYesInfo.WaitForItemExists(WaitForTime);
					repo.Unmount.ButtonYes.ClickThis();
				}				
				Reports.ReportLog("DeleteSVNTree", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
        	{
        		throw new Exception("Failed : DeleteSVNTree : " + ex.Message);
        	}
		}
		
		public static void ClickOnServersTab()
		{
			try
			{
				System.Threading.Thread.Sleep(2000);
				if(repo.AquaDataStudio.ServersTabInfo.Exists(15000))
					repo.AquaDataStudio.ServersTab.ClickThis();
				Reports.ReportLog("ClickOnServersTab", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnServersTab" +ex.Message);
			}
		}
		
		public static void ClickOnShowHistory()
		{
			try 
			{
				repo.SubMenuItem.ShowHistoryInfo.WaitForItemExists(WaitForTime);
				repo.SubMenuItem.ShowHistory.ClickThis();
				Reports.ReportLog("ClickOnShowHistory", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
        	{
        		throw new Exception("Failed : ClickOnShowHistory : " + ex.Message);
        	}
		}
		
		public static void VerifyShowCompleteHistoryCheckbox()
		{
			try 
			{
				repo.HistoryDialog.History.SelfInfo.WaitForItemExists(WaitForTime);
				if(repo.HistoryDialog.History.ShowCompleteHistoryInfo.Exists(3000))
				{
					Report.Success("'Show Complete History' Checkbox Found");
				}
				else
				{
					Report.Success("'Show Complete History' Checkbox Not Found");
				}				
				Reports.ReportLog("VerifyShowCompleteHistoryCheckbox", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
        	{
        		throw new Exception("Failed : VerifyShowCompleteHistoryCheckbox : " + ex.Message);
        	}
		}
		
		public static void VerifyHistoryColumns()
		{
			try 
			{
				if(repo.HistoryDialog.History.RevisionInfo.Exists(3000))
				{
					Report.Success("'Revision' Column Found");
				}
				else
				{
					Report.Error("'Revision' Column Not Found");
				}
				if(repo.HistoryDialog.History.AuthorInfo.Exists(3000))
				{
					Report.Success("'Author' Column Found");
				}
				else
				{
					Report.Error("'Author' Column Not Found");
				}
				if(repo.HistoryDialog.History.DateInfo.Exists(3000))
				{
					Report.Success("'Date' Column Found");
				}
				else
				{
					Report.Error("'Date' Column Not Found");
				}
				if(repo.HistoryDialog.History.ChangesInfo.Exists(3000))
				{
					Report.Success("'Changes' Column Found");
				}
				else
				{
					Report.Error("'Changes' Column Not Found");
				}
				if(repo.HistoryDialog.History.CommentInfo.Exists(3000))
				{
					Report.Success("'Comment' Column Found");
				}
				else
				{
					Report.Error("'Comment' Column Not Found");
				}
				Reports.ReportLog("VerifyHistoryColumns", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
        	{
        		throw new Exception("Failed : VerifyHistoryColumns : " + ex.Message);
        	}
		}
		
		public static void RightClcik2RowsAndClcikCompare()
		{
			try 
			{
				repo.HistoryDialog.History.SelfInfo.WaitForItemExists(WaitForTime);
				Keyboard.Press("{LControlKey down}");
				if(repo.HistoryDialog.History.Row1Info.Exists(3000))
					repo.HistoryDialog.History.Row1.ClickThis();
				if(repo.HistoryDialog.History.Row2Info.Exists(3000))
				{
					repo.HistoryDialog.History.Row2.ClickThis();
					repo.HistoryDialog.History.Row2.RightClickThis();
					Keyboard.Press("{LControlKey up}");					
					repo.SubMenuItem.CompareInfo.WaitForItemExists(WaitForTime);
					repo.SubMenuItem.Compare.ClickThis();
				}			
								
				Reports.ReportLog("RightClcik2RowsAndClcikCompare", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
        	{
        		throw new Exception("Failed : RightClcik2RowsAndClcikCompare : " + ex.Message);
        	}
		}
		
		public static void CloseCompareDialog()
		{
			try 
			{
				repo.CompareDialog.SelfInfo.WaitForItemExists(WaitForTime);
				repo.CompareDialog.Self.Close();
				Reports.ReportLog("CloseCompareDialog", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
        	{
        		throw new Exception("Failed : CloseCompareDialog : " + ex.Message);
        	}
		}
		
		public static void RightClickOnItem()
		{
			try 
			{
				repo.HistoryDialog.History.Row1Info.WaitForItemExists(WaitForTime);
				repo.HistoryDialog.History.Row1.ClickThis();
				repo.HistoryDialog.History.Row1.RightClickThis();
				Reports.ReportLog("RightClickOnItem", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
        	{
        		throw new Exception("Failed : RightClickOnItem : " + ex.Message);
        	}
		}
		
		public static void ClickShowChanges()
		{
			try 
			{
				repo.SubMenuItem.ShowChangesInfo.WaitForItemExists(WaitForTime);
				repo.SubMenuItem.ShowChanges.Focus();
				repo.SubMenuItem.ShowChanges.ClickThis();
				Reports.ReportLog("RightClickOnItemAndClickShowChanges", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
        	{
        		throw new Exception("Failed : RightClickOnItemAndClickShowChanges : " + ex.Message);
        	}
		}
		
		public static void RightClickOncheckoutRevisionOption()
		{
			try 
			{
				repo.SubMenuItem.CheckoutRevisionInfo.WaitForItemExists(WaitForTime);
				repo.SubMenuItem.CheckoutRevision.ClickThis();
				Reports.ReportLog("RightClickOncheckoutRevisionOption", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
        	{
        		throw new Exception("Failed : RightClickOncheckoutRevisionOption : " + ex.Message);
        	}
		}
		
		public static void ClosecheckoutProjectDialog()
		{
			try 
			{
				repo.CheckoutProject.SelfInfo.WaitForItemExists(WaitForTime);
				repo.CheckoutProject.Self.Close();
				Reports.ReportLog("ClosecheckoutProjectDialog", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
        	{
        		throw new Exception("Failed : ClosecheckoutProjectDialog : " + ex.Message);
        	}
		}
		
		public static void CloseCheckoutProjectDialog()
		{
			try 
			{
				repo.CheckoutProject.SelfInfo.WaitForItemExists(WaitForTime);
				repo.CheckoutProject.Self.Close();
				Reports.ReportLog("CloseCheckoutProjectDialog", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
        	{
        		throw new Exception("Failed : CloseCheckoutProjectDialog : " + ex.Message);
        	}
		}
		
		public static void CloseHistoryDialog()
		{
			try 
			{
				repo.HistoryDialog.SelfInfo.WaitForItemExists(WaitForTime);
				repo.HistoryDialog.Self.Close();
				Reports.ReportLog("CloseHistoryDialog", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
        	{
        		throw new Exception("Failed : CloseHistoryDialog : " + ex.Message);
        	}
		}
		
		public static void ClickOnBrowseRepository()
		{
			try 
			{
				repo.SubMenuItem.BrowseRepositoryInfo.WaitForItemExists(WaitForTime);
				repo.SubMenuItem.BrowseRepository.ClickThis();
				Reports.ReportLog("ClickOnBrowseRepository", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
        	{
        		throw new Exception("Failed : ClickOnBrowseRepository : " + ex.Message);
        	}
		}
		
		
		public static void VerifyBrowseRepositoryDailog()
		{
			try 
			{
				if(repo.BrowserRepository.SelfInfo.Exists(WaitForTime))
				{
					Report.Success("'Browser Repository' Dailog Found");
				}
				else
				{
					Report.Error("'Browser Repository' Dailog Not Found");
				}
				if(repo.BrowserRepository.SplitPane.TreeInfo.Exists(WaitForTime))
				{
					Report.Success("'Tree' is Found 'Browser Repository' Dailog");
				}
				else
				{
					Report.Error("'Tree' is not Found 'Browser Repository' Dailog");
				}
				if(repo.BrowserRepository.SplitPane.ShowCompleteHistoryInfo.Exists(WaitForTime))
				{
					Report.Success("'Show Complete History' checkbox is Found 'Browser Repository' Dailog");
				}
				else
				{
					Report.Error("'Show Complete History' checkbox is not Found 'Browser Repository' Dailog");
				}
				
				Reports.ReportLog("VerifyBrowseRepositoryDailog", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
        	{
        		throw new Exception("Failed : VerifyBrowseRepositoryDailog : " + ex.Message);
        	}
		}
		
		public static void RightClickOnBowserRepoItem()
		{
			try 
			{
				repo.BrowserRepository.Row1Info.WaitForItemExists(WaitForTime);
				repo.BrowserRepository.Row1.ClickThis();
				repo.BrowserRepository.Row1.RightClickThis();
				ClickShowChanges();
				CloseCompareDialog();
				Reports.ReportLog("RightClickOnBowserRepoItem", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
        	{
        		throw new Exception("Failed : RightClickOnBowserRepoItem : " + ex.Message);
        	}
		}
		
		public static void RightClick2RowsAndClcikCompareBrowserRepo()
		{
			try 
			{
				Keyboard.Press("{LControlKey down}");
				if(repo.BrowserRepository.Row1Info.Exists(3000))
					repo.BrowserRepository.Row1.ClickThis();
				if(repo.BrowserRepository.Row2Info.Exists(3000))
				{
					repo.BrowserRepository.Row2.ClickThis();
					repo.BrowserRepository.Row2.RightClickThis();
					Keyboard.Press("{LControlKey up}");
				}				
				repo.SubMenuItem.CompareInfo.WaitForItemExists(WaitForTime);
				repo.SubMenuItem.Compare.ClickThis();
				Reports.ReportLog("RightClick2RowsAndClcikCompareBrowserRepo", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
        	{
        		throw new Exception("Failed : RightClick2RowsAndClcikCompareBrowserRepo : " + ex.Message);
        	}
		}
		
		public static void VerifyOptionsSVNRepoDailog()
		{
			try 
			{
				repo.BrowserRepository.SelfInfo.WaitForItemExists(WaitForTime);
				if(repo.BrowserRepository.SplitPane.SvnTreeInfo.Exists(WaitForTime))
				{
					repo.BrowserRepository.SplitPane.SvnTree.Expand();
					if(repo.BrowserRepository.SplitPane.AquaDataStudioRepositoInfo.Exists(WaitForTime))
					{
						repo.BrowserRepository.SplitPane.AquaDataStudioReposito.RightClickThis();
						if(repo.SubMenuItem.CheckoutInfo.Exists(3000))
						{
							Report.Success("'Checkout' Option found");
						}
						else
						{
							Report.Error("'Checkout' Option Not found");
						}
						if(repo.SubMenuItem.NewRemoteFolderInfo.Exists(3000))
						{
							Report.Success("'New Remote Folder' Option found");
						}
						else
						{
							Report.Error("'New Remote Folder' Option Not found");
						}
						if(repo.SubMenuItem.RenameInfo.Exists(3000))
						{
							Report.Success("'Rename' Option found");
						}
						else
						{
							Report.Error("'Rename' Option Not found");
						}
						if(repo.SubMenuItem.MoveInfo.Exists(3000))
						{
							Report.Success("'Move' Option found");
						}
						else
						{
							Report.Error("'Move' Option Not found");
						}
						if(repo.SubMenuItem.BranchTagInfo.Exists(3000))
						{
							Report.Success("'Branch/Tag' Option found");
						}
						else
						{
							Report.Error("'Branch/Tag' Option Not found");
						}
						if(repo.SubMenuItem.DeleteInfo.Exists(3000))
						{
							Report.Success("'Delete' Option found");
						}
						else
						{
							Report.Error("'Delete' Option Not found");
						}
						if(repo.SubMenuItem.CopyURLToClipboardInfo.Exists(3000))
						{
							Report.Success("'Copy URL To Clipboard' Option found");
						}
						else
						{
							Report.Error("'Copy URL To Clipboard' Option Not found");
						}
					}
					else
					{
						Report.Error("Folder is found under Tree Item so not tested available options like checkout, new remote folder, rename, move, branch, delete, copy url and refresh");
					}
				}
				else
				{
					Report.Error("Tree Item is not found so not tested available options like checkout, new remote folder, rename, move, branch, delete, copy url and refresh");
				}
				Reports.ReportLog("VerifyOptionsSVNRepoDailog", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
        	{
        		throw new Exception("Failed : VerifyOptionsSVNRepoDailog : " + ex.Message);
        	}
		}
		
		public static void CloseSVNRepoDialog()
		{
			try
			{
				repo.BrowserRepository.SelfInfo.WaitForItemExists(WaitForTime);
				repo.BrowserRepository.Self.Close();
				Reports.ReportLog("CloseSVNRepoDialog", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
        	{
        		throw new Exception("Failed : CloseSVNRepoDialog : " + ex.Message);
        	}
		}
		
    }
    
}
