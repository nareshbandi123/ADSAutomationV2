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
using ADSAutomationPhaseII.Base;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Preconditions;
using ADSAutomationPhaseII.Configuration;
using ADSAutomationPhaseII.TC_10589;

namespace ADSAutomationPhaseII.TC_10604
{
	public class Steps
	{
		public static TC10589 TC10589Repo = TC10589.Instance;
		public static TC10604 repo = TC10604.Instance;
		public static string TC_10604_PATH = System.Configuration.ConfigurationManager.AppSettings["TC_10604_Path"].ToString();
		
		public static void EnterFilePath()
		{
			try
			{
				TC10589Repo.Open.OpenTextInfo.WaitForItemExists(20000);
				TC10589Repo.Open.OpenText.TextBoxText(TC_10604_PATH + "test-dashboard.vizx");
				Reports.ReportLog("EnterFilePath", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : EnterFilePath" + ex.Message);
			}
		}
		
		public static void OpenTextEditor()
		{
			try
			{
				repo.VisualAnalyticsTestDashboard.Dashboard1Info.WaitForExists(30000);
				repo.VisualAnalyticsTestDashboard.Dashboard1.ClickThis();
				
				repo.VisualAnalyticsTestDashboard.TextInfo.WaitForItemExists(300000);
				repo.VisualAnalyticsTestDashboard.Text.DoubleClick();
				
				Reports.ReportLog("OpenTextEditor", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : OpenTextEditor" + ex.Message);
			}
		}
		
		public static void EditText()
		{
			try
			{
				Keyboard.Press("Albama");
				
				Keyboard.Press(System.Windows.Forms.Keys.A | System.Windows.Forms.Keys.Control, 30, Keyboard.DefaultKeyPressTime, 1, true);
				
				repo.EditText.TextPanel.WindowsComboBoxUIDollarXPComboBoxButtonInfo.WaitForItemExists(30000);
				repo.EditText.TextPanel.WindowsComboBoxUIDollarXPComboBoxButton.ClickThis();
				
				repo.SunAwtWindow.WindowsScrollBarUIDollarWindowsArrowButtInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.WindowsScrollBarUIDollarWindowsArrowButt.DoubleClickThis();
				
				repo.SunAwtWindow.WindowsScrollBarUIDollarWindowsArrowButtInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.WindowsScrollBarUIDollarWindowsArrowButt.ClickThis();
				
				repo.SunAwtWindow.WindowsScrollBarUIDollarWindowsArrowButt.MoveTo("7;5");
				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
				
				repo.SunAwtWindow.WindowsScrollBarUIDollarWindowsArrowButt.MoveTo("7;5");
				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				
				repo.SunAwtWindow.WindowsScrollBarUIDollarWindowsArrowButtInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.WindowsScrollBarUIDollarWindowsArrowButt.DoubleClickThis();
				
				repo.SunAwtWindow.WindowsScrollBarUIDollarWindowsArrowButtInfo.WaitForItemExists(300000);
				repo.SunAwtWindow.WindowsScrollBarUIDollarWindowsArrowButt.DoubleClickThis();
				
				repo.SunAwtWindow.WindowsScrollBarUIDollarWindowsArrowButt.MoveTo("7;5");
				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
				
				repo.SunAwtWindow.WindowsScrollBarUIDollarWindowsArrowButt.MoveTo("7;5");
				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				
				repo.SunAwtWindow.WindowsScrollBarUIDollarWindowsArrowButtInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.WindowsScrollBarUIDollarWindowsArrowButt.DoubleClickThis();
				
				repo.SunAwtWindow.InkFreeInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.InkFree.ClickThis();
				
				repo.EditText.TextPanel.WindowsComboBoxUIDollarXPComboBoxButton1Info.WaitForItemExists(30000);
				repo.EditText.TextPanel.WindowsComboBoxUIDollarXPComboBoxButton1.ClickThis();
				
				repo.SunAwtWindow.ListItem24Info.WaitForItemExists(30000);
				repo.SunAwtWindow.ListItem24.ClickThis();
				
				repo.EditText.TextPanel.WindowsComboBoxUIDollarXPComboBoxButton2.ClickThis();
				
				repo.SunAwtWindow.AQColorChooserPanelDollarColorButton.ClickThis();
				
				repo.EditText.TextPanel.TextPane.ClickThis();
				
				Keyboard.PrepareFocus(repo.EditText.TextPanel.TextPane);
				Keyboard.Press(System.Windows.Forms.Keys.A | System.Windows.Forms.Keys.Control, 30, Keyboard.DefaultKeyPressTime, 1, true);
				
				repo.EditText.TextPanel.WindowsComboBoxUIDollarXPComboBoxButton3.ClickThis();
				
				repo.SunAwtWindow.AQColorChooserPanelDollarColorButton1.ClickThis();
				
				repo.EditText.TextPanel.TextPane.ClickThis();
				
				Keyboard.PrepareFocus(repo.EditText.TextPanel.TextPane);
				Keyboard.Press(System.Windows.Forms.Keys.A | System.Windows.Forms.Keys.Control, 30, Keyboard.DefaultKeyPressTime, 1, true);
				
				repo.EditText.TextPanel.BoldInfo.WaitForItemExists(30000);
				repo.EditText.TextPanel.Bold.ClickThis();
				
				repo.EditText.TextPanel.ItalicInfo.WaitForItemExists(30000);
				repo.EditText.TextPanel.Italic.ClickThis();
				
				repo.EditText.MyContentInfo.WaitForItemExists(30000);
				repo.EditText.MyContent.ClickThis();
				
				repo.EditText.TextPanel.LeftAlignInfo.WaitForItemExists(30000);
				repo.EditText.TextPanel.LeftAlign.ClickThis();
				
				repo.EditText.TextPanel.CenterAlignInfo.WaitForItemExists(30000);
				repo.EditText.TextPanel.CenterAlign.ClickThis();
				
				repo.EditText.TextPanel.RightAlignInfo.WaitForItemExists(30000);
				repo.EditText.TextPanel.RightAlign.ClickThis();
				
				repo.EditText.ClearInfo.WaitForItemExists(30000);
				repo.EditText.Clear.ClickThis();
				
				repo.EditText.OkButtonInfo.WaitForItemExists(30000);
				repo.EditText.OkButton.ClickThis();
				
				Reports.ReportLog("EditText", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : EditText" + ex.Message);
			}
		}
		
		public static void OpenFormatTextObjects()
		{
			try
			{
				repo.VisualAnalyticsTestDashboard.BIDashboardTextDollar1Info.WaitForItemExists(20000);
				repo.VisualAnalyticsTestDashboard.BIDashboardTextDollar1.Click(System.Windows.Forms.MouseButtons.Right, "124;40");
				
				repo.SunAwtWindow.FormatTextObjectInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.FormatTextObject.ClickThis();
				Reports.ReportLog("OpenFormatTextObjects", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : OpenFormatTextObjects" + ex.Message);
			}
		}
		
		public static void TestAlignment()
		{
			try
			{
				repo.FormatTextObject.WindowsComboBoxUIDollarXPComboBoxButtonInfo.WaitForItemExists(30000);
				repo.FormatTextObject.WindowsComboBoxUIDollarXPComboBoxButton.ClickThis();
				
				repo.SunAwtWindow.JPanel.SectionHeaderInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.JPanel.SectionHeader.ClickThis();
				
				repo.SunAwtWindow.JPanel.SectionHeader1Info.WaitForItemExists(30000);
				repo.SunAwtWindow.JPanel.SectionHeader1.ClickThis();
				
				repo.SunAwtWindow.JPanel.SectionHeader2Info.WaitForItemExists(30000);
				repo.SunAwtWindow.JPanel.SectionHeader2.ClickThis();
				
				repo.SunAwtWindow.JPanel1.SectionHeader3Info.WaitForItemExists(30000);
				repo.SunAwtWindow.JPanel1.SectionHeader3.ClickThis();
				
				repo.SunAwtWindow.JPanel1.SectionHeader4Info.WaitForItemExists(30000);
				repo.SunAwtWindow.JPanel1.SectionHeader4.ClickThis();
				
				repo.SunAwtWindow.JPanel1.SectionHeader5Info.WaitForItemExists(30000);
				repo.SunAwtWindow.JPanel1.SectionHeader5.ClickThis();
				
				repo.SunAwtWindow.JPanel1.SectionHeader6Info.WaitForItemExists(30000);
				repo.SunAwtWindow.JPanel1.SectionHeader6.ClickThis();
				
				repo.SunAwtWindow.AHeaderInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.AHeader.ClickThis();
				
				repo.SunAwtWindow.VerticalHeaderInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.VerticalHeader.ClickThis();
				
				repo.SunAwtWindow.HorizontalHeaderInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.HorizontalHeader.ClickThis();
				
				repo.FormatTextObject.ShadingInfo.WaitForItemExists(30000);
				repo.FormatTextObject.Shading.ClickThis();
				
				Reports.ReportLog("TestAlignment", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : TestAlignment" + ex.Message);
			}
		}
		
		public static void TestShading()
		{
			try
			{
				repo.FormatTextObject.BICustomComboBoxInfo.WaitForItemExists(30000);
				repo.FormatTextObject.BICustomComboBox.ClickThis();
				
				repo.SunAwtWindow.NullContentPane.AQColorChooserPanelDollarColorButtonInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.NullContentPane.AQColorChooserPanelDollarColorButton.ClickThis();
				
				repo.FormatTextObject.BorderInfo.WaitForItemExists(30000);
				repo.FormatTextObject.Border.ClickThis();
				
				Reports.ReportLog("TestShading", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : TestShading" + ex.Message);
			}
		}
		
		public static void TestBorder()
		{
			try
			{
				repo.FormatTextObject.BICustomComboBox1Info.WaitForItemExists(30000);
				repo.FormatTextObject.BICustomComboBox1.ClickThis();
				
				repo.SunAwtWindow.NullContentPane.SectionHeaderInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.NullContentPane.SectionHeader.ClickThis();
				
				repo.SunAwtWindow.NullContentPane.SectionHeader1Info.WaitForItemExists(30000);
				repo.SunAwtWindow.NullContentPane.SectionHeader1.ClickThis();
				
				repo.SunAwtWindow.NullContentPane.SectionHeader2Info.WaitForItemExists(300000);
				repo.SunAwtWindow.NullContentPane.SectionHeader2.ClickThis();
				
				repo.FormatTextObject.JPanelInfo.WaitForItemExists(30000);
				repo.FormatTextObject.JPanel.ClickThis();
				Reports.ReportLog("TestBorder", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : TestBorder" + ex.Message);
			}
		}
		
		public static void ClickOnFormatObjectOk()
		{
			try
			{
				repo.FormatTextObject.OkButtonInfo.WaitForItemExists(30000);
				repo.FormatTextObject.OkButton.ClickThis();
				Reports.ReportLog("ClickOnFormatObjectOk", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnFormatObjectOk" + ex.Message);
			}
		}
		
		public static void SetTextAsLink()
		{
			try
			{
				repo.VisualAnalyticsTestDashboard.AlbamaInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestDashboard.Albama.Click(System.Windows.Forms.MouseButtons.Right, "25;4");
				
				repo.SunAwtWindow.InsertLinkInfo.WaitForItemExists(300000);
				repo.SunAwtWindow.InsertLink.ClickThis();
				
				Keyboard.Press("www.google.com");
				
				Reports.ReportLog("SetTextAsLink", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SetTextAsLink" + ex.Message);
			}
		}
		
		public static void ClickOnInsertOk()
		{
			try
			{
				repo.InsertLink.ButtonOKInfo.WaitForItemExists(30000);
				repo.InsertLink.ButtonOK.ClickThis();
				Reports.ReportLog("ClickOnInsertOk", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnInsertOk" + ex.Message);
			}
		}
		
		public static void OpenLink()
		{
			try
			{
				repo.VisualAnalyticsTestDashboard.AlbamaInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestDashboard.Albama.ClickThis();
				Reports.ReportLog("OpenLink", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : OpenLink" + ex.Message);
			}
		}
		
		public static void ClosePage()
		{
			try
			{
				repo.MicrosoftEdge.CloseInfo.WaitForItemExists(30000);
				repo.MicrosoftEdge.Close.ClickThis();
				if(repo.CloseAll.SelfInfo.Exists(5000))
					repo.CloseAll.CloseAllButton.ClickThis();
				Reports.ReportLog("ClosePage", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClosePage" + ex.Message);
			}
		}
		
		public static void EditSheet()
		{
			try
			{
				repo.VisualAnalyticsTestDashboard.BIDashboardTextDollar1Info.WaitForItemExists(30000);
				repo.VisualAnalyticsTestDashboard.BIDashboardTextDollar1.Click(System.Windows.Forms.MouseButtons.Right, "96;32");
				
				repo.SunAwtWindow.EditLinkInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.EditLink.ClickThis();
				
				repo.EditLink.SheetInfo.WaitForItemExists(30000);
				repo.EditLink.Sheet.ClickThis();
				
				repo.EditLink.Worksheet2Info.WaitForItemExists(30000);
				repo.EditLink.Worksheet2.ClickThis();
				
				repo.EditLink.ButtonOKInfo.WaitForItemExists(30000);
				repo.EditLink.ButtonOK.ClickThis();
				
				repo.VisualAnalyticsTestDashboard.BIDashboardTextDollar1Info.WaitForItemExists(30000);
				repo.VisualAnalyticsTestDashboard.BIDashboardTextDollar1.ClickThis();
				Reports.ReportLog("EditSheet", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : EditSheet" + ex.Message);
			}
		}
		
		public static void NavigateToDashboard1()
		{
			try
			{
				repo.VisualAnalyticsTestDashboard.Dashboard1Info.WaitForItemExists(30000);
				repo.VisualAnalyticsTestDashboard.Dashboard1.ClickThis();
				Reports.ReportLog("NavigateToDashboard1", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : NavigateToDashboard1" + ex.Message);
			}
		}
		
		public static void ClickOnImageButton()
		{
			try
			{
				repo.VisualAnalyticsTestDashboard.ImageInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestDashboard.Image.DoubleClick();
				Reports.ReportLog("ClickOnImageButton", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnImageButton" + ex.Message);
			}
		}
		
		public static void OpenImageFromLocal()
		{
			try
			{
				repo.ChooseImage.ImageTextInfo.WaitForItemExists(30000);
				repo.ChooseImage.ImageText.TextBoxText(TC_10604_PATH + "abc.png");
				
				Reports.ReportLog("OpenImageFromLocal", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : OpenImageFromLocal" + ex.Message);
			}
		}
		
		public static void OpenImageFromWeb()
		{
			try
			{
				repo.VisualAnalyticsTestDashboard.BIDashboardImageDollar4Info.WaitForItemExists(30000);
				repo.VisualAnalyticsTestDashboard.BIDashboardImageDollar4.DoubleClick();
				
				repo.ChooseImage.FromWebInfo.WaitForItemExists(30000);
				repo.ChooseImage.FromWeb.ClickThis();
				
				repo.ChooseImage.WebImageTextInfo.WaitForItemExists(30000);
				repo.ChooseImage.WebImageText.TextBoxText("https://img.freepik.com/free-vector/abstract-dynamic-pattern-wallpaper-vector_53876-59131.jpg");
				Reports.ReportLog("OpenImageFromWeb", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : OpenImageFromWeb" + ex.Message);
			}
		}
		
		public static void ClickOnOpen()
		{
			try
			{
				repo.ChooseImage.CPanel.OpenInfo.WaitForItemExists(30000);
				repo.ChooseImage.CPanel.Open.ClickThis();
				Reports.ReportLog("ClickOnOpen", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnOpen" + ex.Message);
			}
		}
		
		public static void ChangeImage()
		{
			try
			{
				repo.VisualAnalyticsTestDashboard.BIDashboardImageDollar4Info.WaitForItemExists(30000);
				repo.VisualAnalyticsTestDashboard.BIDashboardImageDollar4.RightClickThis();
				
				repo.SunAwtWindow.ChangeImageInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.ChangeImage.ClickThis();
				
				repo.ChooseImage.FromLocalInfo.WaitForItemExists(30000);
				repo.ChooseImage.FromLocal.ClickThis();
				
				repo.ChooseImage.ImageTextInfo.WaitForItemExists(30000);
				repo.ChooseImage.ImageText.TextBoxText(TC_10604_PATH + "abc.png");
				Reports.ReportLog("ChangeImage", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ChangeImage" + ex.Message);
			}
		}
		
		public static void OpenImage()
		{
			try
			{
				repo.ChooseImage.OpenButtonInfo.WaitForItemExists(30000);
				repo.ChooseImage.OpenButton.ClickThis();
				Reports.ReportLog("OpenImage", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : OpenImage" + ex.Message);
			}
		}
		
		public static void FitImage()
		{
			try
			{
				repo.VisualAnalyticsTestDashboard.BIDashboardImageDollar4Info.WaitForItemExists(30000);
				repo.VisualAnalyticsTestDashboard.BIDashboardImageDollar4.RightClick();
				
				repo.SunAwtWindow.FitImageInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.FitImage.ClickThis();
				Reports.ReportLog("FitImage", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : FitImage" + ex.Message);
			}
		}
		
		public static void CenterImage()
		{
			try
			{
				repo.VisualAnalyticsTestDashboard.BIDashboardImageDollar4Info.WaitForItemExists(30000);
				repo.VisualAnalyticsTestDashboard.BIDashboardImageDollar4.RightClick();
				
				repo.SunAwtWindow.CenterImageInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.CenterImage.ClickThis();
				Reports.ReportLog("CenterImage", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CenterImage" + ex.Message);
			}
		}
		
		public static void InsertImageLink()
		{
			try
			{
				repo.VisualAnalyticsTestDashboard.BIDashboardImageDollar4Info.WaitForItemExists(30000);
				repo.VisualAnalyticsTestDashboard.BIDashboardImageDollar4.RightClick();
				
				repo.SunAwtWindow.InsertLinkInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.InsertLink.ClickThis();
				
				repo.InsertLink.TextActualComponentInfo.WaitForItemExists(30000);
				repo.InsertLink.TextActualComponent.ClickThis();
				
				repo.InsertLink.TextActualComponent.PressKeys("www.google.com");
				
				repo.InsertLink.ButtonOKInfo.WaitForItemExists(30000);
				repo.InsertLink.ButtonOK.ClickThis();
				
				repo.VisualAnalyticsTestDashboard.BIDashboardImageDollar4Info.WaitForItemExists(30000);
				repo.VisualAnalyticsTestDashboard.BIDashboardImageDollar4.ClickThis();
				
				repo.MicrosoftEdge.CloseInfo.WaitForItemExists(30000);
				repo.MicrosoftEdge.Close.ClickThis();
				Reports.ReportLog("InsertImageLink", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : InsertImageLink" + ex.Message);
			}
		}
		
		public static void ActionSetting()
		{
			try
			{
				repo.VisualAnalyticsTestDashboard.DashboardInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestDashboard.Dashboard.ClickThis();
				
				repo.SunAwtWindow.ActionsInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.Actions.ClickThis();
				
				repo.AddFilterAction.SourceWorksheet2Info.WaitForItemExists(30000);
				repo.AddFilterAction.SourceWorksheet2.ClickThis();
				
				repo.AddFilterAction.TargetWorksheet1Info.WaitForItemExists(30000);
				repo.AddFilterAction.TargetWorksheet1.ClickThis();
				
//				repo.AddFilterAction.CPanel.ListListInfo.WaitForItemExists(30000);
//				repo.AddFilterAction.CPanel.ListList.ClickThis();
				
//				repo.AddFilterAction.CPanel.ListList1Info.WaitForItemExists(30000);
//				repo.AddFilterAction.CPanel.ListList1.ClickThis();
				
				repo.AddFilterAction.CPanel.ButtonOKInfo.WaitForItemExists(30000);
				repo.AddFilterAction.CPanel.ButtonOK.ClickThis();
				Reports.ReportLog("ActionSetting", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ActionSetting" + ex.Message);
			}
		}
		
		public static void SelectCalifornia()
		{
			try
			{
				repo.VisualAnalyticsTestDashboard.ContainerMainPanel.CaliforniaInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestDashboard.ContainerMainPanel.California.ClickThis();
				
				repo.VisualAnalyticsTestDashboard.ContainerMainPanel.ContainerCanvas.MoveTo("518;42");
				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
				
				repo.VisualAnalyticsTestDashboard.ContainerMainPanel.ContainerCanvas.MoveTo("518;61");
				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				
				repo.VisualAnalyticsTestDashboard.ContainerMainPanel.ContainerCanvas.MoveTo("518;60");
				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
				
				repo.VisualAnalyticsTestDashboard.ContainerMainPanel.ContainerCanvas.MoveTo("520;87");
				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				Reports.ReportLog("SelectCalifornia", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectCalifornia" + ex.Message);
			}
		}
		
		public static void ValidateCaliforniaChart()
		{
			try
			{
				repo.VisualAnalyticsTestDashboard.ContainerMainPanel.ContainerCanvas.MoveTo("518;42");
				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
				
				repo.VisualAnalyticsTestDashboard.ContainerMainPanel.ContainerCanvas.MoveTo("518;61");
				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				
				repo.VisualAnalyticsTestDashboard.ContainerMainPanel.ContainerCanvas.MoveTo("518;60");
				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
				
				repo.VisualAnalyticsTestDashboard.ContainerMainPanel.ContainerCanvas.MoveTo("520;87");
				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				
				Reports.ReportLog("ValidateCaliforniaChart", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateCaliforniaChart" + ex.Message);
			}
		}
		
		public static void ValidateMapChart()
		{
			try
			{
				if(repo.VisualAnalyticsTestDashboard.CaliforniaMapInfo.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestDashboard.CaliforniaMapInfo.GetCaliforniaMap();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestDashboard.CaliforniaMapInfo;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateMapChart data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateMapChart", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateMapChart :" +ex.Message);
			}
		}
		
		public static void UnSelectCalifornia()
		{
			try
			{
				Keyboard.Press("{LControlKey down}");
				
				repo.VisualAnalyticsTestDashboard.ContainerMainPanel.CaliforniaInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestDashboard.ContainerMainPanel.California.ClickThis();
				
				Keyboard.Press("{LControlKey up}");
				Reports.ReportLog("UnSelectCalifornia", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : UnSelectCalifornia" + ex.Message);
			}
		}
		public static void ValidateUnselectMapChart()
		{
			try
			{
				if(repo.VisualAnalyticsTestDashboard.UnselectCaliforniaMapInfo.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestDashboard.UnselectCaliforniaMapInfo.GetUnselectCaliforniaMap();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestDashboard.UnselectCaliforniaMapInfo;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateUnselectMapChart data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateUnselectMapChart", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateUnselectMapChart :" +ex.Message);
			}
		}
		
		public static void SelectCaliforniaAndNevadaFromMap()
		{
			try
			{
				repo.VisualAnalyticsTestDashboard.ContainerMainPanel.ContainerCanvas1Info.WaitForItemExists(30000);
				repo.VisualAnalyticsTestDashboard.ContainerMainPanel.ContainerCanvas1.Click("86;229");
				
				Keyboard.Press("{LControlKey down}");
				
				repo.VisualAnalyticsTestDashboard.ContainerMainPanel.ContainerCanvas1Info.WaitForItemExists(30000);
				repo.VisualAnalyticsTestDashboard.ContainerMainPanel.ContainerCanvas1.Click("102;193");
				
				Keyboard.Press("{LControlKey up}");
				Reports.ReportLog("SelectCaliforniaAndNevadaFromMap", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectCaliforniaAndNevadaFromMap" + ex.Message);
			}
		}
		
		public static void UnSelectCaliforniaAndNevadaFromMap()
		{
			try
			{
				repo.VisualAnalyticsTestDashboard.ContainerMainPanel.ContainerCanvas1Info.WaitForItemExists(30000);
				repo.VisualAnalyticsTestDashboard.ContainerMainPanel.ContainerCanvas1.ClickThis();
				Reports.ReportLog("UnSelectCaliforniaAndNevadaFromMap", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : UnSelectCaliforniaAndNevadaFromMap" + ex.Message);
			}
		}
		
		public static void RemoveActionSetting()
		{
			try
			{
				repo.VisualAnalyticsTestDashboard.DashboardInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestDashboard.Dashboard.ClickThis();
				
				repo.SunAwtWindow.ActionsInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.Actions.ClickThis();
				
				repo.EditFilterAction.RemoveInfo.WaitForItemExists(30000);
				repo.EditFilterAction.Remove.ClickThis();
				Reports.ReportLog("RemoveActionSetting", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : RemoveActionSetting" + ex.Message);
			}
		}
		
		public static void ShowTitle()
		{
			try
			{
				repo.VisualAnalyticsTestDashboard.DashboardInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestDashboard.Dashboard.ClickThis();
				
				repo.SunAwtWindow.ShowTitleInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.ShowTitle.ClickThis();
				
				Reports.ReportLog("ShowTitle", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ShowTitle" + ex.Message);
			}
		}
		
		public static void ValidateDashboardTitle()
		{
			try
			{
				repo.VisualAnalyticsTestDashboard.DashboardTextInfo.WaitForItemExists(30000);
				if(repo.VisualAnalyticsTestDashboard.DashboardText.TextValue == "Dashboard 1")
				{
					Reports.ReportLog("Validation : Dashboard Title : ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : Dashboard Title", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateDashboardTitle" + ex.Message);
			}
		}
		
		public static void RenameDashboardName()
		{
			try
			{
				repo.VisualAnalyticsTestDashboard.Dashboard1Info.WaitForItemExists(30000);
				repo.VisualAnalyticsTestDashboard.Dashboard1.RightClickThis();
				
				repo.SunAwtWindow.RenameInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.Rename.ClickThis();
				
				Keyboard.Press("Dashboard2");
				repo.VisualAnalyticsTestDashboard.ContainerSheetsPaneInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestDashboard.ContainerSheetsPane.ClickThis();
				
				Reports.ReportLog("RenameDashboardName", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : RenameDashboardName" + ex.Message);
			}
		}
		
		public static void ValidateRenamedDashboardTitle()
		{
			try
			{
				repo.VisualAnalyticsTestDashboard.DashboardTextInfo.WaitForItemExists(30000);
				if(repo.VisualAnalyticsTestDashboard.DashboardText.TextValue == "Dashboard2")
				{
					Reports.ReportLog("Validation : Renamed Dashboard Title : Dashboard2", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : Rename Dashboard Title", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateRenamedDashboardTitle" + ex.Message);
			}
		}
		
		public static void HideWorksheet1Title()
		{
			try
			{
				repo.VisualAnalyticsTestDashboard.Worksheet1RenameInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestDashboard.Worksheet1Rename.RightClickThis();
				
				repo.SunAwtWindow.HideTitleInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.HideTitle.ClickThis();
				
				Reports.ReportLog("HideWorksheet1Title", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : HideWorksheet1Title" + ex.Message);
			}
		}
		
		public static void ValidateHiddenWorksheet1()
		{
			try
			{
				if(repo.VisualAnalyticsTestDashboard.HideWorksheet1Info.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestDashboard.HideWorksheet1Info.GetHideworksheet1();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestDashboard.HideWorksheet1Info;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateHiddenWorksheet1 data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateHiddenWorksheet1", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateHiddenWorksheet1 :" +ex.Message);
			}
		}
		
		public static void ShowWorksheet1Title()
		{
			try
			{
				System.Threading.Thread.Sleep(1000);
				if(repo.VisualAnalyticsTestDashboard.WorksheetTabInfo.Exists(5000))
				{
					repo.VisualAnalyticsTestDashboard.WorksheetTab.ClickThis();
					System.Threading.Thread.Sleep(500);
					repo.SunAwtWindow.ShowTitleInfo.WaitForItemExists(30000);
					repo.SunAwtWindow.ShowTitle.ClickThis();
					
					Reports.ReportLog("ShowWorksheet1Title", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("WorksheetTab not exists", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ShowWorksheet1Title" + ex.Message);
			}
		}
		
		public static void ValidateShowWorksheetTitle()
		{
			try
			{
				repo.VisualAnalyticsTestDashboard.WorksheetTextInfo.WaitForItemExists(30000);
				if(repo.VisualAnalyticsTestDashboard.WorksheetText.InnerText.Contains("Worksheet 1"))
				{
					Reports.ReportLog("Validation : Worksheet Title : Worksheet 1", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : Worksheet Title", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateShowWorksheetTitle" + ex.Message);
			}
		}
		
		public static void CloseOnVisualAnalyticsError()
		{
			if(repo.VisualAnalyticsTestDashboard.SelfInfo.Exists(5000))
				repo.VisualAnalyticsTestDashboard.Self.Close();
		}
		
		public static void CloseOnOpenFileError()
		{
			if(TC10589Repo.Open.SelfInfo.Exists(5000))
				TC10589Repo.Open.Self.Close();
		}
		
	}
}
