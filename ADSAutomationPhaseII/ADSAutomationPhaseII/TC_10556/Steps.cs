using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

using WinForms = System.Windows.Forms;
using System.Windows.Forms;
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Preconditions;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace ADSAutomationPhaseII.TC_10556
{
	public static class Steps
	{
		
		public static TC10556Repo repo = TC10556Repo.Instance;
		public static PreconditionRepo preRepo = PreconditionRepo.Instance;
		public static string MSEXCEL_PATH = System.Configuration.ConfigurationManager.AppSettings["MSEXCEL_PATH"].ToString();
		public static string TC_10556_PATH = System.Configuration.ConfigurationManager.AppSettings["TC_10556"].ToString();
		
		
		public static bool MsExcelExists()
		{
			bool isfound = false;
			try
			{
				preRepo.ServersList.LocalDBServersTreeItemInfo.WaitForItemExists(30000);
				foreach (var item in preRepo.ServersList.LocalDBServersTreeItem.Items)
					if(item.Text == "MSExcel"){ isfound = true; break;}
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : MsExcelExists : " + ex.Message);
			}
			return isfound;
		}

		public static void RegisterServer()
		{
			try
			{
				preRepo.ServersList.LocalDBServersTreeItemInfo.WaitForItemExists(30000);
				preRepo.ServersList.LocalDBServersTreeItem.RightClick();
				Keyboard.Press(Keyboard.ToKey("Insert"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : RegisterServer : " + ex.Message);
			}
		}
		
		public static void SelectMSExcel()
		{
			try
			{
				repo.RegisterServer.MSExcelInfo.WaitForItemExists(30000);
				repo.RegisterServer.MSExcel.ClickThis();
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : SelectMSExcel : " + ex.Message);
			}
		}
		
		public static void EnterName()
		{
			try
			{
				repo.RegServerExcel.NameTextboxInfo.WaitForItemExists(30000);
				repo.RegServerExcel.NameTextbox.TextBoxText("MSExcel");
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : EnterName : " + ex.Message);
			}
		}
		
		public static void EnterDirectory()
		{
			try
			{
				repo.RegServerExcel.DirectoryTextboxInfo.WaitForItemExists(30000);
				repo.RegServerExcel.DirectoryTextbox.TextBoxText(MSEXCEL_PATH + "bistudio_example.xlsx");
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : EnterDirectory : " + ex.Message);
			}
		}
		
		public static void ClickTestConnection()
		{
			try
			{
				repo.RegServerExcel.TestConnectionButtonInfo.WaitForItemExists(30000);
				repo.RegServerExcel.TestConnectionButton.ClickThis();
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickTestConnection : " + ex.Message);
			}
		}
		
		public static bool CheckConnectionStatus()
		{
			try
			{
				return repo.ConnectionStatus.ConnectionStatusTextInfo.Exists();
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : CheckConnectionStatus : " + ex.Message);
			}
		}
		
		public static void ClickCloseButton()
		{
			try
			{
				repo.ConnectionStatus.CloseButtonInfo.WaitForItemExists(30000);
				repo.ConnectionStatus.CloseButton.ClickThis();
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickCloseButton : " + ex.Message);
			}
		}
		
		public static void ClickSaveButton()
		{
			try
			{
				repo.RegServerExcel.SaveButtonInfo.WaitForItemExists(30000);
				repo.RegServerExcel.SaveButton.ClickThis();
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickSaveButton : " + ex.Message);
			}
		}
		
		public static void IsServerRegistered()
		{
			try
			{
				if(!MsExcelExists())
				{
					RegisterServer();
					SelectMSExcel();
					EnterName();
					EnterDirectory();
					ClickTestConnection();
					if(CheckConnectionStatus())
					{
						ClickCloseButton();
						ClickSaveButton();
					}
				}
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : IsServerRegistered : " + ex.Message);
			}
		}
		
		public static void ConnectServer()
		{
			try
			{
				preRepo.ServersList.LocalDBServersTreeItemInfo.WaitForItemExists(30000);
				TreeItem MsExcelTree = null;
				
				foreach (var item in preRepo.ServersList.LocalDBServersTreeItem.Items)
				{
					if(item.Text == "MSExcel")
					{
						MsExcelTree = item;
						break;
					}
				}
				
				if(MsExcelTree != null)
				{
					MsExcelTree.EnsureVisible();
					MsExcelTree.RightClickThis();
					Keyboard.Press(Keyboard.ToKey("Ctrl+Insert"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
					System.Threading.Thread.Sleep(1000);
					Keyboard.Press(Keyboard.ToKey("Ctrl+Q"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				}
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ConnectServer : " + ex.Message);
			}
		}
		
		public static void DisConnectServer()
		{
			try
			{
				preRepo.ServersList.LocalDBServersTreeItemInfo.WaitForItemExists(30000);
				TreeItem MsExcelTree = null;
				
				foreach (var item in preRepo.ServersList.LocalDBServersTreeItem.Items)
				{
					if(item.Text == "MSExcel")
					{
						MsExcelTree = item;
						break;
					}
				}
				
				if(MsExcelTree != null)
				{
					MsExcelTree.EnsureVisible();
					MsExcelTree.RightClickThis();
					Keyboard.Press(Keyboard.ToKey("Ctrl+Delete"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				}
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : DisConnectServer : " + ex.Message);
			}
		}
		
		public static void ClickQARun()
		{
			try
			{
				repo.QuaryAnalyzerWindow.QueryBoxInfo.WaitForItemExists(30000);
				repo.QuaryAnalyzerWindow.QueryBox.Click();
				repo.QuaryAnalyzerWindow.QueryBox.PressKeys("select * from bistudio_example");
				Keyboard.Press(Keyboard.ToKey("Ctrl+E"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Reports.ReportLog("results Displayed", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickQARun : " + ex.Message);
			}
		}
		
		public static void ClickNewVA()
		{
			try
			{
				repo.QuaryAnalyzerWindow.NewVAInfo.WaitForItemExists(15000);
				repo.QuaryAnalyzerWindow.NewVA.ClickThis();
				Reports.ReportLog("Visual Analytics window displayed", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickNewVA : " + ex.Message);
			}
		}
		
		public static void MoveToColumn()
		{
			try
			{
				repo.VAWindow.ShipDateInfo.WaitForItemExists(10000);
				
				repo.VAWindow.ShipDate.Click("40;11");
				Delay.Milliseconds(200);
				
				repo.VAWindow.ShipDate.MoveTo("39;11");
				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
				Delay.Milliseconds(200);
				
				repo.VAWindow.ShipDate.MoveTo("47;3");
				Delay.Milliseconds(200);
				
				repo.VAWindow.ColumnContainer.MoveTo("59;11");
				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				Delay.Milliseconds(200);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : MoveToColumn : " + ex.Message);
			}
		}
		
		public static void MoveToRows()
		{
			try
			{
				repo.VAWindow.ProfitsInfo.WaitForItemExists(30000);
				
				repo.VAWindow.Profits.Click("48;8");
				Delay.Milliseconds(200);
				
				repo.VAWindow.Profits.MoveTo("42;9");
				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
				Delay.Milliseconds(200);
				
				repo.VAWindow.Profits.MoveTo("50;1");
				Delay.Milliseconds(200);
				
				repo.VAWindow.RowContainer.MoveTo("62;8");
				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				Delay.Milliseconds(400);
				
				repo.VAWindow.CardTypeInfo.WaitForExists(15000);
				repo.VAWindow.CardType.Click("67;10");
				Delay.Milliseconds(200);
				
				repo.VAWindow.CardType.MoveTo("61;8");
				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
				Delay.Milliseconds(200);
				
				repo.VAWindow.CardType.MoveTo("69;0");
				Delay.Milliseconds(200);
				
				repo.VAWindow.RowContainer.MoveTo("57;10");
				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				Delay.Milliseconds(200);
				
				Reports.ReportLog("Default Chart generated", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : MoveToRows : " + ex.Message);
			}
		}
		
		public static void RightClickData()
		{
			try
			{
				repo.VAWindow.ChartContainerInfo.WaitForItemExists(Common.ApplicationOpenWaitTime);
				System.Threading.Thread.Sleep(5000);
				repo.VAWindow.RenameDataInfo.WaitForItemExists(5000);
				repo.VAWindow.RenameData.EnsureVisible();
				repo.VAWindow.RenameData.Click();
				Ranorex.Mouse.Click(repo.VAWindow.RenameData, System.Windows.Forms.MouseButtons.Right, new Point(30, 10));
				System.Threading.Thread.Sleep(200);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : RightClickData : " + ex.Message);
			}
		}
		
		public static void RenameData()
		{
			try
			{
				repo.SunAwtWindow.RenameInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.Rename.ClickThis();
				Reports.ReportLog("Rename Data pop-up Displayed", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				repo.RenameWindow.TextBoxInfo.WaitForItemExists(30000);
				repo.RenameWindow.TextBox.TextBoxText("Sales Data");
				
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickOkButton : " + ex.Message);
			}
		}
		
		public static void ClickOkButton()
		{
			try
			{
				repo.RenameWindow.ClickRenameInfo.WaitForItemExists(30000);
				repo.RenameWindow.ClickRename.ClickThis();
				Reports.ReportLog("Data pane is changed to Sales Data", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickOkButton : " + ex.Message);
			}
		}
		
		public static void SaveWorkBook()
		{
			try
			{
				repo.VAWindow.SaveIconInfo.WaitForItemExists(30000);
				repo.VAWindow.SaveIcon.ClickThis();
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : SaveWorkBook : " + ex.Message);
			}
		}
		
		public static void EnterWorkbookName()
		{
			try
			{
				repo.SaveFolderWindow.WorkBookNameInfo.WaitForItemExists(30000);
				repo.SaveFolderWindow.WorkBookName.TextBoxText(TC_10556_PATH + "VA-tests.vizw");
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : EnterWorkbookName : " + ex.Message);
			}
		}
		
		public static void SaveButton()
		{
			try
			{
				repo.SaveFolderWindow.SaveInfo.WaitForItemExists(30000);
				repo.SaveFolderWindow.Save.ClickThis();
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : SaveButton : " + ex.Message);
			}
		}
		
		public static void ClickCloseVA()
		{
			try
			{
				if(repo.VAWindow.CloseWindowInfo.Exists(5000))
					repo.VAWindow.CloseWindow.ClickThis();
				
				if(repo.SaveChanges.SelfInfo.Exists(new Duration(5000)))
					repo.SaveChanges.DiscardButton.ClickThis();
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickCloseVA : " + ex.Message);
			}
		}
		
		public static void ClickCloseTab()
		{
			try
			{
				Preconditions.Steps.CloseTab("");
				if(repo.FileModified.SelfInfo.Exists(new Duration(30000)))
					repo.FileModified.DiscardButton.ClickThis();
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickCloseTab : " + ex.Message);
			}
		}
		
		public static void Cleanup()
		{
			Commons.Common.DeleteFile(TC_10556_PATH + "VA-tests.vizw");
		}
		
		public static void ClickonFileMenu()
		{
			try
			{
				repo.Application.FileMenuInfo.WaitForItemExists(30000);
				repo.Application.FileMenu.EnsureVisible();
				repo.Application.FileMenu.ClickThis();
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonFileMenu : " + ex.Message);
			}
		}
		
		public static void ClickonOpen()
		{
			try
			{
				repo.DataStudio.OpenFileInfo.WaitForItemExists(30000);
				repo.DataStudio.OpenFile.ClickThis();
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonOpen : " + ex.Message);
			}
		}
		
		public static void SelecttheFile()
		{
			try
			{
				repo.OpenWindow.FilePathTextbox.TextBoxText(TC_10556_PATH + "VA-tests.vizw");
				
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : SelecttheFile : " + ex.Message);
			}
		}
		
		public static void SelectNewFile()
		{
			try
			{
				repo.OpenWindow.FilePathTextbox.TextBoxText(TC_10556_PATH + "VA-tests.vizx");
				
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : SelectNewFile : " + ex.Message);
			}
		}
		
		public static void ClickonOpenButton()
		{
			try
			{
				repo.OpenWindow.OpenButton.ClickThis();
				Reports.ReportLog("Dislayed with VA-tests.vizw data", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonOpenButton : " + ex.Message);
			}
		}
		
		public static void RightClickonSalesData()
		{
			try
			{
				repo.DataPaneWindow.SalesdataInfo.WaitForItemExists(10000);
				Ranorex.Mouse.Click(repo.DataPaneWindow.Salesdata, System.Windows.Forms.MouseButtons.Right, new Point(30, 10));
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : RightClickonSalesData : " + ex.Message);
			}
		}
		
		public static void ClickonExtract()
		{
			try
			{
				repo.SunAwtWindow.ExtractData.ClickThis();
				Reports.ReportLog("Extract Data pop-up displayed", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonExtract : " + ex.Message);
			}
		}
		
		public static void EntertheFileName()
		{
			try
			{
				repo.ExtractDataWindow.FilePathTextBox.TextBoxText(TC_10556_PATH + "Sales Data.vize");
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : EntertheFileName : " + ex.Message);
			}
		}
		
		public static void SaveExtractFile()
		{
			try
			{
				repo.ExtractDataWindow.SaveInfo.WaitForItemExists(30000);
				repo.ExtractDataWindow.Save.ClickThis();
				//repo.ExtractDataWindow.Ok.ClickThis();
				Reports.ReportLog("VA-tests.vize file saved", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SaveExtractFile : " + ex.Message);
			}
		}
		
		public static void Ovverride()
		{
			try
			{
				if(repo.OverrideWindow.SelfInfo.Exists())
					repo.OverrideWindow.No.ClickThis();
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : Ovverride : " + ex.Message);
			}
		}
		
		public static void ClickonVAFileMenu()
		{
			try
			{
				repo.DataPaneWindow.FileMenuInfo.WaitForItemExists(new Duration(30000));
				repo.DataPaneWindow.FileMenu.EnsureVisible();
				repo.DataPaneWindow.FileMenu.ClickThis();
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonVAFileMenu : " + ex.Message);
			}
		}
		
		public static void SelectExportWorkBook()
		{
			try
			{
				repo.SunAwtWindow.ExportWorkBookInfo.WaitForItemExists(new Duration(500));
				repo.SunAwtWindow.ExportWorkBook.EnsureVisible();
				repo.SunAwtWindow.ExportWorkBook.ClickThis();
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : SelectExportWorkBook : " + ex.Message);
			}
		}
		
		public static void ConfirmContinue()
		{
			try
			{
				if(repo.ExportConfirmWindow.SelfInfo.Exists())
					repo.ExportConfirmWindow.Continue.ClickThis();
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ConfirmContinue : " + ex.Message);
			}
		}
		
		public static void ProvideFileName()
		{
			try
			{
				repo.ExportConfirmWindow.FileNameText.TextBoxText(TC_10556_PATH + "VA-tests.vizx");
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ProvideFileName : " + ex.Message);
			}
		}
		
		public static void ClickOnSaveButton()
		{
			try
			{
				repo.ExportConfirmWindow.SaveInfo.WaitForItemExists(30000);
				repo.ExportConfirmWindow.Save.ClickThis();
				Reports.ReportLog("VA-tests.vizx file saved", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickOnSaveButton : " + ex.Message);
			}
		}
	}
}

