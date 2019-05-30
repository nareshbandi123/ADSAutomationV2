using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core.Repository;
using Ranorex.Core;
using Ranorex.Core.Testing;
using ADSAutomationPhaseIII.Base;
using ADSAutomationPhaseIII.Extensions;
using ADSAutomationPhaseIII.Commons;
using ADSAutomationPhaseIII.Preconditions;
using ADSAutomationPhaseIII.Configuration;

namespace ADSAutomationPhaseIII.TC_Files
{
	public class Steps
	{
		public static TCFiles repo = TCFiles.Instance;
		public static string TC_Files_PATH = System.Configuration.ConfigurationManager.AppSettings["TC_Files_Path"].ToString();
		
		public static void SaveQuery()
		{
			try
			{
				repo.Application.SaveQueryInfo.WaitForItemExists(30000);
				repo.Application.SaveQuery.ClickThis();
				Reports.ReportLog("SaveQuery", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SaveQuery" + ex.Message);
			}
		}
		
		public static void EnterFileSaveText()
		{
			try
			{
				repo.SaveForm.FileTextInfo.WaitForItemExists(30000);
				repo.SaveForm.FileText.TextBoxText(TC_Files_PATH + "ADS.sql");
				Reports.ReportLog("EnterFileSaveText", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : EnterFileSaveText" + ex.Message);
			}
		}
		
		public static void SaveQueryFile()
		{
			try
			{
				repo.SaveForm.SaveButtonInfo.WaitForItemExists(30000);
				repo.SaveForm.SaveButton.ClickThis();
				Reports.ReportLog("SaveQueryFile", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SaveQueryFile" + ex.Message);
			}
		}
		
		public static void ClickOnFileMenu()
		{
			try
			{
				repo.Application.FileMenuInfo.WaitForItemExists(30000);
				repo.Application.FileMenu.ClickThis();
				Reports.ReportLog("ClickOnFileMenu", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnFileMenu" + ex.Message);
			}
		}
		
		public static void SelectSaveResult()
		{
			try
			{
				repo.Datastudio.SaveResultInfo.WaitForItemExists(30000);
				repo.Datastudio.SaveResult.ClickThis();
				Reports.ReportLog("SelectSaveResult", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectSaveResult" + ex.Message);
			}
		}
		
		public static void Browse()
		{
			try
			{
				repo.SaveResults.BrowseInfo.WaitForItemExists(30000);
				repo.SaveResults.Browse.ClickThis();
				Reports.ReportLog("Browse", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : Browse" + ex.Message);
			}
		}
		
		public static void SaveResult()
		{
			try
			{
				repo.SelectSaveResult.FilePathInfo.WaitForItemExists(30000);
				repo.SelectSaveResult.FilePath.TextBoxText(TC_Files_PATH + "ADS_Results.sql");
				Reports.ReportLog("SaveResult", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SaveResult" + ex.Message);
			}
		}
		
		public static void SaveToFile()
		{
			try
			{
				repo.SaveResults.SaveToFileInfo.WaitForItemExists(30000);
				repo.SaveResults.SaveToFile.ClickThis();
				Reports.ReportLog("SaveToFile", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SaveToFile" + ex.Message);
			}
		}
		
		public static void OpenRecent()
		{
			try
			{
				repo.Datastudio.OpenRecentInfo.WaitForItemExists(30000);
				repo.Datastudio.OpenRecent.ClickThis();
				Reports.ReportLog("OpenRecent", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : OpenRecent" + ex.Message);
			}
		}
		
		public static void OpenRecentADSFile()
		{
			try
			{
				repo.SunAwtWindow.ADSFileInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.ADSFile.ClickThis();
				Reports.ReportLog("OpenRecentADSFile", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : OpenRecentADSFile" + ex.Message);
			}
		}
		
		public static void OpenInCurrentWindow()
		{
			try
			{
				repo.Datastudio.OpenInCurrentWindowInfo.WaitForItemExists(30000);
				repo.Datastudio.OpenInCurrentWindow.ClickThis();
				Reports.ReportLog("OpenInCurrentWindow", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : OpenInCurrentWindow" + ex.Message);
			}
		}
		
		public static void EnterADSFilePath()
		{
			try
			{
				repo.OpenForm.FileTextInfo.WaitForItemExists(30000);
				repo.OpenForm.FileText.TextBoxText(TC_Files_PATH + "ADS.sql");
				Reports.ReportLog("EnterADSFilePath", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : EnterADSFilePath" + ex.Message);
			}
		}
		
		public static void OpenADSFile()
		{
			try
			{
				repo.OpenForm.OpenButtonInfo.WaitForItemExists(30000);
				repo.OpenForm.OpenButton.ClickThis();
				Reports.ReportLog("OpenADSFile", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : OpenADSFile" + ex.Message);
			}
		}
		
		public static void EditADS()
		{
			try
			{
				repo.Application.QATextEditor.Click();
				Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Keyboard.Press(Keyboard.ToKey("Delete"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				repo.Application.QATextEditor.PressKeys("Select * from ads_p2");
				repo.Application.QATextEditor.Click();
				Reports.ReportLog("EditADS", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : EditADS" + ex.Message);
			}
		}
		
		public static void Execute()
		{
			try
			{
				repo.Application.ExecuteInfo.WaitForItemExists(30000);
				repo.Application.Execute.ClickThis();
				Reports.ReportLog("Execute", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : Execute" + ex.Message);
			}
		}
		
		public static void NewCurrentWindow()
		{
			try
			{
				repo.Datastudio.NewCurrentWindowInfo.WaitForItemExists(30000);
				repo.Datastudio.NewCurrentWindow.ClickThis();
				Reports.ReportLog("NewCurrentWindow", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : NewCurrentWindow" + ex.Message);
			}
		}
		
		public static void CancelButton()
		{
			try
			{
				repo.FileModified.CancelInfo.WaitForItemExists(30000);
				repo.FileModified.Cancel.ClickThis();
				Reports.ReportLog("CancelButton", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CancelButton" + ex.Message);
			}
		}
		
		public static void SaveAs()
		{
			try
			{
				repo.Datastudio.SaveAsInfo.WaitForItemExists(30000);
				repo.Datastudio.SaveAs.ClickThis();
				Reports.ReportLog("SaveAs", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SaveAs" + ex.Message);
			}
		}
		
		public static void EnterSaveFilePath()
		{
			try
			{
				repo.SaveForm.FileTextInfo.WaitForItemExists(30000);
				repo.SaveForm.FileText.TextBoxText(TC_Files_PATH + "Test");
				Reports.ReportLog("EnterSaveFilePath", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : EnterSaveFilePath" + ex.Message);
			}
		}
		
		public static void ClickOnSave()
		{
			try
			{
				repo.SaveForm.SaveButtonInfo.WaitForItemExists(30000);
				repo.SaveForm.SaveButton.ClickThis();
				Reports.ReportLog("ClickOnSave", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnSave" + ex.Message);
			}
		}
		
		public static void ClickOnSelect()
		{
			try
			{
				repo.SelectSaveResult.SelectInfo.WaitForItemExists(30000);
				repo.SelectSaveResult.Select.ClickThis();
				Reports.ReportLog("ClickOnSelect", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnSelect" + ex.Message);
			}
		}
	}
}
