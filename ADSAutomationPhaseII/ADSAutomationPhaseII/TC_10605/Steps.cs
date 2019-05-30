using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using WinForms = System.Windows.Forms;
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Configuration;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Preconditions;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Repository;
using Ranorex.Core.Testing;

namespace ADSAutomationPhaseII.TC_10605
{
	public class Steps
	{
		public static TC10605Repo repo = TC10605Repo.Instance;
		public static string TC1_10605_Path = System.Configuration.ConfigurationManager.AppSettings["TC1_10605_Path"].ToString();
		public static int waittime = 30000;
		
		public static void ClickonFileMenu()
		{
			try
			{
				repo.Application.FileMenuInfo.WaitForItemExists(waittime);
				repo.Application.FileMenu.ClickThis();
				repo.DataStudio.OpenFileInfo.WaitForItemExists(waittime);
				Reports.ReportLog("ClickonFileMenu", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonFileMenu : " + ex.Message);
			}
		}
		
		public static void ClickonOpen()
		{
			try
			{
				repo.DataStudio.OpenFileInfo.WaitForItemExists(waittime);
				repo.DataStudio.OpenFile.ClickThis();
				Reports.ReportLog("ClickonOpen", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonOpen : " + ex.Message);
			}
		}
		
		public static void SelectNewFile()
		{
			try
			{
				repo.OpenWindow.FilePathTextboxInfo.WaitForItemExists(waittime);
				repo.OpenWindow.FilePathTextbox.TextBoxText(TC1_10605_Path + "test-export.vizx");
				Reports.ReportLog("SelectNewFile", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectNewFile : " + ex.Message);
			}
		}
		
		public static void ClickonOpenButton()
		{
			try
			{
				repo.OpenWindow.OpenButtonInfo.WaitForItemExists(waittime);
				repo.OpenWindow.OpenButton.ClickThis();
				Reports.ReportLog("ClickonOpenButton", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonOpenButton : " + ex.Message);
			}
		}
		
		public static void ClickMaximizebutton()
		{
			try
			{
				repo.VisualAnalytics.SelfInfo.WaitForItemExists(30000);
				repo.VisualAnalytics.Self.Maximize();
				Reports.ReportLog("ClickMaximizebutton", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickMaximizebutton : " + ex.Message);
			}
		}
		
		public static void ClickCloseHTML()
		{
			try
			{
				repo.HTMLImages.CloseIconInfo.WaitForItemExists(waittime);
				repo.HTMLImages.CloseIcon.ClickThis();
				
				if (repo.Edge_Window.CloseAlltabsInfo.Exists(5000))
					repo.Edge_Window.CloseAlltabs.ClickThis();
				
				Reports.ReportLog("ClickCloseHTML", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickCloseHTML : " + ex.Message);
			}
		}
		
		public static void ClickonImage(string filename)
		{
			try
			{
				
				repo.VisualAnalytics.FileMenu_WorksheetInfo.WaitForItemExists(waittime);
				repo.VisualAnalytics.FileMenu_Worksheet.ClickThis();
				
				repo.FileMenu_VisualAnalystic.ExportToInfo.WaitForItemExists(waittime);
				repo.FileMenu_VisualAnalystic.ExportTo.ClickThis();
				
				repo.SunAwtWindow.ImageIcon_WorksheetMenuInfo.WaitForItemExists(waittime);
				repo.SunAwtWindow.ImageIcon_WorksheetMenu.ClickThis();
				
				
				if (!repo.ExportToImage.CPanel.Title.Checked)
					repo.ExportToImage.CPanel.Title.ClickThis();
				
				if (!repo.ExportToImage.CPanel.ColorLegend.Checked)
					repo.ExportToImage.CPanel.ColorLegend.ClickThis();
				
				if (!repo.ExportToImage.CPanel.ShapeLegend.Checked)
					repo.ExportToImage.CPanel.ShapeLegend.ClickThis();
				
				if (!repo.ExportToImage.CPanel.SizeLegend.Checked)
					repo.ExportToImage.CPanel.SizeLegend.ClickThis();
				
				if (!repo.ExportToImage.CPanel.ShowSelections.Checked)
					repo.ExportToImage.CPanel.ShowSelections.ClickThis();
				
				repo.ExportToImage.CPanel.LegendPosition_RadioButtonInfo.WaitForItemExists(waittime);
				repo.ExportToImage.CPanel.LegendPosition_RadioButton.Click();
				
				if (!repo.ExportToImage.CPanel.OpenInImageViewerAfterExport.Checked)
					repo.ExportToImage.CPanel.OpenInImageViewerAfterExport.ClickThis();
				
				repo.ExportToImage.CPanel.NextInfo.WaitForItemExists(waittime);
				repo.ExportToImage.CPanel.Next.ClickThis();
				
				repo.Export.FileText.TextBoxText(TC1_10605_Path+filename+".png");				
				repo.Export.Export.ClickThis();
				
				if(repo.DataStudio.ButtonYesInfo.Exists(5000))
				{
					repo.DataStudio.ButtonYes.ClickThis();
				}
				
				Reports.ReportLog("ClickonImage", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonImage : " + ex.Message);
			}
		}
		
		public static void ValidateSavedImageICon()
		{
			try
			{
				CompressedImage chart = repo.WidowsImages.ValidationScreenshotsInfo.GetValidate_TC1();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.WidowsImages.ValidationScreenshotsInfo;
				Validate.ContainsImage(info, chart, options, "Saved Images", false);
				
				Reports.ReportLog("ValidateSavedImageICon", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateSavedImageICon  : " + ex.Message);
			}
		}
		
		public static void CloseImagePNG()
		{
			try
			{
				if(repo.WidowsImages.CloseWindowInfo.Exists(waittime))
				{
					repo.WidowsImages.CloseWindow.ClickThis();
					Reports.ReportLog("CloseImagePNG", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CloseImagePNG  : " + ex.Message);
			}
		}
		
		public static void ClickonHTMLIcon(string filename)
		{
			try
			{
				repo.VisualAnalytics.FileMenu_WorksheetInfo.WaitForItemExists(waittime);
				repo.VisualAnalytics.FileMenu_Worksheet.ClickThis();
				
				repo.FileMenu_VisualAnalystic.ExportToInfo.WaitForItemExists(waittime);
				repo.FileMenu_VisualAnalystic.ExportTo.ClickThis();
				
				repo.SunAwtWindow.HTMLIconInfo.WaitForItemExists(waittime);
				repo.SunAwtWindow.HTMLIcon.ClickThis();

				if (!repo.ExportToHTML.CPanel.Title.Checked)
					repo.ExportToHTML.CPanel.Title.ClickThis();

				if (!repo.ExportToHTML.CPanel.ColorLegend.Checked)
					repo.ExportToHTML.CPanel.ColorLegend.ClickThis();
				
				if (!repo.ExportToHTML.CPanel.ShapeLegend.Checked)
					repo.ExportToHTML.CPanel.ShapeLegend.ClickThis();
				
				if (!repo.ExportToHTML.CPanel.SizeLegend.Checked)
					repo.ExportToHTML.CPanel.SizeLegend.ClickThis();
				
				if (!repo.ExportToHTML.CPanel.ShowSelections.Checked)
					repo.ExportToHTML.CPanel.ShowSelections.ClickThis();
				
				if (!repo.ExportToHTML.CPanel.OpenInBrowserAfterExport.Checked)
					repo.ExportToHTML.CPanel.OpenInBrowserAfterExport.ClickThis();
				
				repo.ExportToHTML.CPanel.NextInfo.WaitForItemExists(waittime);
				repo.ExportToHTML.CPanel.Next.ClickThis();

				repo.Export.FileTextInfo.WaitForItemExists(waittime);
				repo.Export.FileText.TextBoxText(TC1_10605_Path+filename+".html");
				
				repo.Export.ExportInfo.WaitForItemExists(waittime);
				repo.Export.Export.ClickThis();
				
				if(repo.DataStudio.ButtonYesInfo.Exists(10000))
				{
					repo.DataStudio.ButtonYes.ClickThis();
				}
				
				Reports.ReportLog("ClickonHTMLIcon", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonHTMLIcon : " + ex.Message);
			}
		}
		
		public static void ValidateSavedHTMLIcon()
		{
			try
			{
				CompressedImage chart = repo.HTMLImages.HTMLScrenshotsInfo.GetValidationScreen_TC2();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.HTMLImages.HTMLScrenshotsInfo;
				Validate.ContainsImage(info, chart, options, "Saved Images", false);
				
				Reports.ReportLog("ValidateSavedHTMLIcon", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateSavedHTMLIcon  : " + ex.Message);
			}
		}
		
		public static void ClickonImageIcon_LegendThirdOption(string filename)
		{
			try
			{
				repo.VisualAnalytics.FileMenu_WorksheetInfo.WaitForItemExists(waittime);
				repo.VisualAnalytics.FileMenu_Worksheet.ClickThis();
				repo.FileMenu_VisualAnalystic.ExportToInfo.WaitForItemExists(waittime);
				repo.FileMenu_VisualAnalystic.ExportTo.ClickThis();
				
				repo.SunAwtWindow.ImageIcon_WorksheetMenuInfo.WaitForItemExists(waittime);
				repo.SunAwtWindow.ImageIcon_WorksheetMenu.ClickThis();
				
				if (!repo.ExportToImage.CPanel.Title.Checked)
					repo.ExportToImage.CPanel.Title.ClickThis();

				if (!repo.ExportToImage.CPanel.ColorLegend.Checked)
					repo.ExportToImage.CPanel.ColorLegend.ClickThis();
				
				if (!repo.ExportToImage.CPanel.SizeLegend.Checked)
					repo.ExportToImage.CPanel.SizeLegend.ClickThis();
				
				repo.ExportToImage.CPanel.Legend_ThirdOptionInfo.WaitForItemExists(waittime);
				repo.ExportToImage.CPanel.Legend_ThirdOption.ClickThis();
				
				if (!repo.ExportToImage.CPanel.ShowSelections.Checked)
					repo.ExportToImage.CPanel.ShowSelections.ClickThis();
				
				if (!repo.ExportToImage.CPanel.OpenInImageViewerAfterExport.Checked)
					repo.ExportToImage.CPanel.OpenInImageViewerAfterExport.ClickThis();
				
				repo.ExportToImage.CPanel.NextInfo.WaitForItemExists(waittime);
				repo.ExportToImage.CPanel.Next.ClickThis();
				
				repo.Export.FileText.TextBoxText(TC1_10605_Path+filename+".png");
				
				repo.Export.ExportInfo.WaitForItemExists(waittime);
				repo.Export.Export.ClickThis();
				
				if(repo.DataStudio.ButtonYesInfo.Exists(20000))
				{
					repo.DataStudio.ButtonYes.ClickThis();
				}
				
				Reports.ReportLog("ClickonImageIcon_LegendThirdOption", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonImageIcon_LegendThirdOption : " + ex.Message);
			}
		}

		public static void ValidateSavedImageICon_LegendThirdOption()
		{
			try
			{
				CompressedImage chart = repo.WidowsImages.ValidationScreenshotsInfo.GetValidate_TC3();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.WidowsImages.ValidationScreenshotsInfo;
				Validate.ContainsImage(info, chart, options, "Saved Images", false);
				
				Reports.ReportLog("ValidateSavedImageICon_LegendThirdOption", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateSavedImageICon_LegendThirdOption  : " + ex.Message);
			}
		}
		
		public static void CloseWindowThirdOption()
		{
			try
			{
				repo.WidowsImages.CloseWindowInfo.WaitForItemExists(15000);
				repo.WidowsImages.CloseWindow.ClickThis();
				
				Reports.ReportLog("CloseWindowThirdOption", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CloseWindowThirdOption  : " + ex.Message);
			}
		}
		
		public static void NavigatetoWorsheet3()
		{
			try
			{
				repo.VisualAnalytics.WorkSheet3Info.WaitForItemExists(waittime);
				repo.VisualAnalytics.WorkSheet3.ClickThis();
				Reports.ReportLog("NavigatetoWorsheet3", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : NavigatetoWorsheet3 : " + ex.Message);
			}
		}
		
		public static void ClickonImageWorksheet3(string filename)
		{
			try
			{
				
				repo.VisualAnalytics.FileMenu_WorksheetInfo.WaitForItemExists(waittime);
				repo.VisualAnalytics.FileMenu_Worksheet.ClickThis();
				
				repo.SunAwtWindow_Popup.ExportToInfo.WaitForItemExists(waittime);
				repo.SunAwtWindow_Popup.ExportTo.ClickThis();
				
				repo.SunAwtWindow.ImageIcon_WorksheetMenuInfo.WaitForItemExists(waittime);
				repo.SunAwtWindow.ImageIcon_WorksheetMenu.ClickThis();
				
				if (repo.Image_Export.CPanel.Title.Checked)
					repo.Image_Export.CPanel.Title.ClickThis();
				
				if (repo.Image_Export.CPanel.ShowSelections.Checked)
					repo.Image_Export.CPanel.ShowSelections.ClickThis();
				
				if (repo.Image_Export.CPanel.OpenInImageViewerAfterExport.Checked)
					repo.Image_Export.CPanel.OpenInImageViewerAfterExport.ClickThis();
				
				repo.Image_Export.CPanel.NextInfo.WaitForItemExists(waittime);
				repo.Image_Export.CPanel.Next.ClickThis();
				
				repo.Export.FileText.TextBoxText(TC1_10605_Path+filename+".png");
				
				repo.Export.ExportInfo.WaitForItemExists(waittime);
				repo.Export.Export.ClickThis();
				
				if(repo.DataStudio.ButtonYesInfo.Exists(20000))
				{
					repo.DataStudio.ButtonYes.ClickThis();
				}
				
				Reports.ReportLog("ClickonImageWorksheet3", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonImageWorksheet3 : " + ex.Message);
			}
		}
		
		public static void ValidateImageIconWorksheet3()
		{
			try
			{
				CompressedImage chart = repo.WidowsImages.ValidationScreenshotsInfo.GetValidate_TC4();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.WidowsImages.ValidationScreenshotsInfo;
				Validate.ContainsImage(info, chart, options, "Saved Images", false);
				
				Reports.ReportLog("ValidateImageIconWorksheet3", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateImageIconWorksheet3  : " + ex.Message);
			}
		}
		
		public static void ClickonHTMLWorksheet3(string filename)
		{
			try
			{
				repo.VisualAnalytics.FileMenu_WorksheetInfo.WaitForItemExists(waittime);
				repo.VisualAnalytics.FileMenu_Worksheet.ClickThis();
				
				repo.SunAwtWindow_Popup.ExportToInfo.WaitForItemExists(waittime);
				repo.SunAwtWindow_Popup.ExportTo.ClickThis();
				
				repo.SunAwtWindow.HTMLIconInfo.WaitForItemExists(waittime);
				repo.SunAwtWindow.HTMLIcon.ClickThis();
				
				if (!repo.ExportToHTML.CPanel.Title.Checked)
					repo.ExportToHTML.CPanel.Title.ClickThis();
				
				if (!repo.ExportToHTML.CPanel.ShowSelections.Checked)
					repo.ExportToHTML.CPanel.ShowSelections.ClickThis();
				
				if (!repo.ExportToHTML.CPanel.OpenInBrowserAfterExport.Checked)
					repo.ExportToHTML.CPanel.OpenInBrowserAfterExport.ClickThis();
				
				repo.ExportToHTML.CPanel.NextInfo.WaitForItemExists(waittime);
				repo.ExportToHTML.CPanel.Next.ClickThis();
				
				repo.Export.FileText.TextBoxText(TC1_10605_Path+filename+".html");
				
				repo.Export.ExportInfo.WaitForItemExists(1000);
				repo.Export.Export.ClickThis();
				
				if(repo.DataStudio.ButtonYesInfo.Exists(20000))
				{
					repo.DataStudio.ButtonYes.ClickThis();
				}
				
				Reports.ReportLog("ClickonImageWorksheet3", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonImageWorksheet3 : " + ex.Message);
			}
		}
		
		public static void ValidateHTMLIconWorksheet3()
		{
			try
			{
				CompressedImage chart = repo.HTMLImages.HTMLScrenshotsInfo.GetValidationScreen_TC5();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.HTMLImages.HTMLScrenshotsInfo;
				Validate.ContainsImage(info, chart, options, "Saved Images", false);
				
				Reports.ReportLog("ValidateImageIconWorksheet3", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateImageIconWorksheet3  : " + ex.Message);
			}
		}
		
		public static void ClickonExcelWorksheet3(string filename)
		{
			try
			{
				repo.VisualAnalytics.FileMenu_WorksheetInfo.WaitForItemExists(waittime);
				repo.VisualAnalytics.FileMenu_Worksheet.ClickThis();
				
				repo.FileMenu_VisualAnalystic.ExportToInfo.WaitForItemExists(waittime);
				repo.FileMenu_VisualAnalystic.ExportTo.ClickThis();
				repo.SunAwtWindow.ExcelTableInfo.WaitForItemExists(waittime);
				repo.SunAwtWindow.ExcelTable.ClickThis();
				
				if (!repo.ExportTableToExcel.CPanel.OpenInSpreadsheetViewerAfterExport.Checked)
					repo.ExportTableToExcel.CPanel.OpenInSpreadsheetViewerAfterExport.ClickThis();
				
				repo.ExportTableToExcel.CPanel.NextInfo.WaitForItemExists(waittime);
				repo.ExportTableToExcel.CPanel.Next.ClickThis();
				
				repo.Export.FileText.TextBoxText(TC1_10605_Path+filename+".xlsx");
				
				repo.Export.ExportInfo.WaitForItemExists(waittime);
				repo.Export.Export.ClickThis();
				
				if(repo.DataStudio.ButtonYesInfo.Exists(20000))
				{
					repo.DataStudio.ButtonYes.ClickThis();
				}
				
				Reports.ReportLog("ClickonExcelWorksheet3", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonExcelWorksheet3 : " + ex.Message);
			}
		}		
		
		public static void CloseDownloadexcelWindow()
		{
			try
			{
				repo.Dowloadexcel.CloseExcelInfo.WaitForItemExists(waittime);
				repo.Dowloadexcel.CloseExcel.ClickThis();
				Reports.ReportLog("CloseDownloadexcelWindow", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CloseDownloadexcelWindow : " + ex.Message);
			}
		}
		
		public static void ClickonPDF_FileMenu()
		{
			try
			{
				repo.VisualAnalytics.FileMenu_WorksheetInfo.WaitForItemExists(waittime);
				repo.VisualAnalytics.FileMenu_Worksheet.ClickThis();
				
				repo.SunAwtWindow_Popup.ExportToInfo.WaitForItemExists(waittime);
				repo.SunAwtWindow_Popup.ExportTo.ClickThis();
				
				repo.SunAwtWindow.PDFInfo.WaitForItemExists(waittime);
				repo.SunAwtWindow.PDF.ClickThis();
				
				Reports.ReportLog("ClickonPDF_FileMenu", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonPDF_FileMenu : " + ex.Message);
			}
		}
		
		public static void ClickonPDF_Dashboard()
		{
			try
			{
				repo.TabPage.TabContainerInfo.WaitForItemExists(30000);
				repo.TabPage.TabContainer.SelectTab("Dashboard 1");
				
				repo.VisualAnalytics.Dashboard_FileMenuInfo.WaitForItemExists(waittime);
				repo.VisualAnalytics.Dashboard_FileMenu.ClickThis();
				
				repo.FileMenu_VisualAnalystic.ExportToInfo.WaitForItemExists(waittime);
				repo.FileMenu_VisualAnalystic.ExportTo.ClickThis();
				
				repo.SunAwtWindow.PDFInfo.WaitForItemExists(waittime);
				repo.SunAwtWindow.PDF.ClickThis();
				
				Reports.ReportLog("ClickonPDF_Dashboard", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonPDF_Dashboard : " + ex.Message);
			}
		}
		
		public static void General_Range_Select(int index)
		{
			try
			{
				if(index == 0)
				{
					if(!repo.ExportToPDF.General.Range0.Checked)
						repo.ExportToPDF.General.Range0.ClickThis();
				}
				
				if(index==1)
				{
					if(!repo.ExportToPDF.General.Range1.Checked)
						repo.ExportToPDF.General.Range1.ClickThis();
				}
				
				if(index==2)
				{
					if(!repo.ExportToPDF.General.Range2.Checked)
						repo.ExportToPDF.General.Range2.ClickThis();
				}
				Reports.ReportLog("General_Range_Select", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : General_Range_Select : " + ex.Message);
			}
		}
		
		public static void SelectGeneralWorsheets()
		{
			try
			{
			repo.ExportToPDF.CPanel.Worksheet11Info.WaitForItemExists(waittime);
			repo.ExportToPDF.CPanel.Worksheet11.Click();
			repo.ExportToPDF.CPanel.Worksheet13Info.WaitForItemExists(waittime);
			repo.ExportToPDF.CPanel.Worksheet13.ClickThis();
			
			Reports.ReportLog("SelectGeneralWorsheets", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
		    }
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectGeneralWorsheets : " + ex.Message);
			}
		}
	
		public static void General_Range_Select_Dashboard(int index)
		{
			try
			{
				if(index == 0)
				{
					if(!repo.ExportToPDF.CPanel.ActiveDashboard.Checked)
						repo.ExportToPDF.General.Range0.ClickThis();
				}
				
				if(index == 1)
				{
					if(!repo.ExportToPDF.General.Range1.Checked)
						repo.ExportToPDF.General.Range1.Select();
				}
				
				if(index == 2)
				{
					if(!repo.ExportToPDF.General.Range2.Checked)
						repo.ExportToPDF.General.Range2.ClickThis();
				}
				
				Reports.ReportLog("General_Range_Select_Dashboard", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : General_Range_Select_Dashboard : " + ex.Message);
			}
		}
		
		public static void General_PaperSize_Select(string text)
		{
			try
			{
				repo.ExportToPDF.General.PaperSizeComboBoxInfo.WaitForItemExists(waittime);
				repo.ExportToPDF.General.PaperSizeComboBox.ClickThis();
				repo.varItemVal = text;
				repo.SunAwtWindow_Popup.listItemInfo.WaitForItemExists(waittime);
				repo.SunAwtWindow_Popup.listItem.ClickThis();
				Reports.ReportLog("General_PaperSize_Select", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : General_PaperSize_Select : " + ex.Message);
			}
		}
		
		public static void General_Orientation_Select(int index)
		{
			try
			{
				if(index == 0)
				{
					if(!repo.ExportToPDF.General.Orientation0.Checked)
						repo.ExportToPDF.General.Orientation0.ClickThis();
				}
				
				if(index == 1)
				{
					if(!repo.ExportToPDF.General.Orientation1.Checked)
						repo.ExportToPDF.General.Orientation1.ClickThis();
				}
				Reports.ReportLog("General_Orientation_Select", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : General_Orientation_Select : " + ex.Message);
			}
		}
		
		public static void General_Show_Select(bool index1, bool index2, bool index3, bool index4)
		{
			try
			{
				repo.ExportToPDF.General.Show1.Click();
				
				if(!repo.ExportToPDF.General.Show0.Checked)
					repo.ExportToPDF.General.Show0.Checked = index1;
				
				if(!repo.ExportToPDF.General.Show1.Checked)
					repo.ExportToPDF.General.Show1.Checked = index2;
				
				if(!repo.ExportToPDF.General.Show2.Checked)
					repo.ExportToPDF.General.Show2.Checked = index3;
				
				if(!repo.ExportToPDF.General.Show3.Checked)
					repo.ExportToPDF.General.Show3.Checked = index4;
				
				Reports.ReportLog("General_Show_Select", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : General_Show_Select : " + ex.Message);
			}
		}
		
		public static void General_Show_Selectworksheet()
		{
			try
			{
				repo.ExportToPDF.General.Show1.ClickThis();
				
								
				Reports.ReportLog("General_Show_Selectworksheet", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : General_Show_Selectworksheet : " + ex.Message);
			}
		}
		
		public static void General_Legent_Select(int index)
		{
			try
			{
				if(index == 0)
				{
					repo.ExportToPDF.General.LegendPosition0Info.WaitForItemExists(waittime);
					
					if(!repo.ExportToPDF.General.LegendPosition0.Checked)
						repo.ExportToPDF.General.LegendPosition0.ClickThis();
				}
				
				if(index == 1)
				{
					repo.ExportToPDF.General.LegendPosition1Info.WaitForItemExists(waittime);
					
					if(!repo.ExportToPDF.General.LegendPosition1.Checked)
						repo.ExportToPDF.General.LegendPosition1.ClickThis();
				}
				
				if(index == 2)
				{
					repo.ExportToPDF.General.LegendPosition2Info.WaitForItemExists(waittime);
					if(!repo.ExportToPDF.General.LegendPosition2.Checked)
						repo.ExportToPDF.General.LegendPosition2.ClickThis();
				}
				
				if(index == 3)
				{
					repo.ExportToPDF.General.LegendPosition3Info.WaitForItemExists(waittime);
					if(!repo.ExportToPDF.General.LegendPosition3.Checked)
						repo.ExportToPDF.General.LegendPosition3.ClickThis();
				}
				Reports.ReportLog("General_Legent_Select", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : General_Legent_Select : " + ex.Message);
			}
		}
		
		public static void General_Addons_Select(bool index1, bool index2, bool index3)
		{
			try
			{
				if (!repo.ExportToPDF.General.Addon0.Checked)
					repo.ExportToPDF.General.Addon0.Checked = index1;
				
				if (!repo.ExportToPDF.General.Addon1.Checked)
					repo.ExportToPDF.General.Addon1.Checked = index2;
				
				if (!repo.ExportToPDF.General.Addon2.Checked)
					repo.ExportToPDF.General.Addon2.Checked = index3;
				
				
				Reports.ReportLog("General_Addons_Select", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : General_Addons_Select : " + ex.Message);
			}
		}
		
		public static void Layout_PageOrder_Select(int index)
		{
			try
			{
				if(index == 0)
				{
					if(!repo.ExportToPDF.Layout.PageOrder0.Checked)
						repo.ExportToPDF.Layout.PageOrder0.ClickThis();
				}
				
				if(index == 1)
				{
					if(!repo.ExportToPDF.Layout.PageOrder1.Checked)
						repo.ExportToPDF.Layout.PageOrder1.ClickThis();
				}
				
				Reports.ReportLog("Layout_PageOrder_Select", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : Layout_PageOrder_Select : " + ex.Message);
			}
		}
		
		public static void Layout_Margin_Select(string index1, string index2, string index3, string index4)
		{
			try
			{
				repo.ExportToPDF.CPanel.cmbMarginInfo.WaitForItemExists(waittime);
				repo.ExportToPDF.CPanel.cmbMargin.ClickThis();
				repo.DataStudio.MarginsPanel.TopField.TextBoxText(index1);
				repo.DataStudio.MarginsPanel.RightField.TextBoxText(index2);
				repo.DataStudio.MarginsPanel.BottomField.TextBoxText(index3);
				repo.DataStudio.MarginsPanel.LeftField.TextBoxText(index4);
				repo.DataStudio.ButtonOKInfo.WaitForItemExists(waittime);
				repo.DataStudio.ButtonOK.ClickThis();
				
				Reports.ReportLog("Layout_Margin_Select", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : Layout_Margin_Select : " + ex.Message);
			}
		}
		
		public static void PrintScaling_Select(bool index)
		{
			try
			{
				if(!repo.ExportToPDF.PrintScaling.Scaling0.Checked)
					repo.ExportToPDF.PrintScaling.Scaling0.Checked = index;
				
				Reports.ReportLog("Layout_Margin_Select", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : Layout_Margin_Select : " + ex.Message);
			}
		}
		
		public static void Click_LayoutTab()
		{
			try
			{
				repo.ExportToPDF.Layout.TabInfo.WaitForItemExists(waittime);
				repo.ExportToPDF.Layout.Tab.Click();
				
				Reports.ReportLog("Click_LayoutTab", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : Click_LayoutTab : " + ex.Message);
			}
		}
		
		public static void Click_PrintScaling()
		{
			try
			{   repo.ExportToPDF.PrintScaling.TabInfo.WaitForItemExists(waittime);
				repo.ExportToPDF.PrintScaling.Tab.Click();
				
				Reports.ReportLog("Click_PrintScaling", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : Click_PrintScaling : " + ex.Message);
			}
		}
		
		public static void ClickonNextAndSaveFile(string filename)
		{
			try
			{   
				repo.ExportToPDF.NextButtonInfo.WaitForItemExists(waittime);
				repo.ExportToPDF.NextButton.ClickThis();
				
				try 
				{
					repo.Export.FileTextInfo.WaitForItemExists(5000);
					repo.Export.FileText.TextBoxText(TC1_10605_Path+filename+".pdf");
					repo.Export.Export.ClickThis();
					
				if(repo.DataStudio.ButtonYesInfo.Exists(10000))
				{
					repo.DataStudio.ButtonYes.ClickThis();
				}
					
				} 
				catch
				{
					if(repo.ExportToPDF.SelfInfo.Exists(5000))repo.ExportToPDF.Self.Close();
				}
				
				Reports.ReportLog("ClickonNextAndSaveFile", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				if(repo.ExportToPDF.SelfInfo.Exists(5000))repo.ExportToPDF.Self.Close();
				throw new Exception("Failed : ClickonNextAndSaveFile : " + ex.Message);
			}
		}
		
		public static void ValidatePDFTC7()
		{
			try
			{
				CompressedImage chart = repo.Edge_Window.ScreenshotsInfo.GetWorksheet_TC7();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.Edge_Window.ScreenshotsInfo;
				Validate.ContainsImage(info, chart, options, "Saved Images", false);
				
				Reports.ReportLog("ValidatePDFTC7", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidatePDFTC7  : " + ex.Message);
			}
		}
		
		public static void ValidatePDFTC8()
		{
			try
			{
				CompressedImage chart = repo.Edge_Window.ScreenshotsInfo.GetWorksheet_TC8();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.Edge_Window.ScreenshotsInfo;
				Validate.ContainsImage(info, chart, options, "Saved Images", false);
				
				Reports.ReportLog("ValidatePDFTC8", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidatePDFTC8  : " + ex.Message);
			}
		}
		
		public static void ValidatePDFTC9()
		{
			try
			{
				CompressedImage chart = repo.Edge_Window.ScreenshotsInfo.GetWorksheet_TC9();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.Edge_Window.ScreenshotsInfo;
				Validate.ContainsImage(info, chart, options, "Saved Images", false);
				
				Reports.ReportLog("ValidatePDFTC9", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidatePDFTC9  : " + ex.Message);
			}
		}
		
		public static void ValidatePDFTC10()
		{
			try
			{
				CompressedImage chart = repo.Edge_Window.ScreenshotsInfo.GetWorksheet_TC10();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.Edge_Window.ScreenshotsInfo;
				Validate.ContainsImage(info, chart, options, "Saved Images", false);
				
				Reports.ReportLog("ValidatePDFTC10", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidatePDFTC10  : " + ex.Message);
			}
		}
		
		public static void ValidatePDFTC11()
		{
			try
			{
				CompressedImage chart = repo.Edge_Window.ScreenshotsInfo.GetWorsheet_TC11();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.Edge_Window.ScreenshotsInfo;
				Validate.ContainsImage(info, chart, options, "Saved Images", false);
				
				Reports.ReportLog("ValidatePDFTC11", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidatePDFTC11  : " + ex.Message);
			}
		}
		
		public static void ValidatePDFTC12()
		{
			try
			{
				CompressedImage chart = repo.Edge_Window.ScreenshotsInfo.GetWorksheet_TC12();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.Edge_Window.ScreenshotsInfo;
				Validate.ContainsImage(info, chart, options, "Saved Images", false);
				
				Reports.ReportLog("ValidatePDFTC12", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidatePDFTC12  : " + ex.Message);
			}
		}
		
		public static void ValidatePDFTC13()
		{
			try
			{
				CompressedImage chart = repo.Edge_Window.ScreenshotsInfo.GetWorksheet_TC13();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.Edge_Window.ScreenshotsInfo;
				Validate.ContainsImage(info, chart, options, "Saved Images", false);
				
				Reports.ReportLog("ValidatePDFTC13", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidatePDFTC13  : " + ex.Message);
			}
		}
		
		public static void ValidatePDFTC14()
		{
			try
			{
				CompressedImage chart = repo.Edge_Window.ScreenshotsInfo.GetDashboard_TC14();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.Edge_Window.ScreenshotsInfo;
				Validate.ContainsImage(info, chart, options, "Saved Images", false);
				
				Reports.ReportLog("ValidatePDFTC14", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidatePDFTC14  : " + ex.Message);
			}
		}
		
		public static void ValidatePDFTC15()
		{
			try
			{
				CompressedImage chart = repo.Edge_Window.ScreenshotsInfo.GetWorksheet_TC15();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.Edge_Window.ScreenshotsInfo;
				Validate.ContainsImage(info, chart, options, "Saved Images", false);
				
				Reports.ReportLog("ValidatePDFTC15", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidatePDFTC15  : " + ex.Message);
			}
		}
		
		public static void ValidatePDFTC16()
		{
			try
			{
				CompressedImage chart = repo.Edge_Window.ScreenshotsInfo.GetWorsheet_TC16();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.Edge_Window.ScreenshotsInfo;
				Validate.ContainsImage(info, chart, options, "Saved Images", false);
				
				Reports.ReportLog("ValidatePDFTC16", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidatePDFTC16  : " + ex.Message);
			}
		}
		
		public static void ValidatePDFTC17()
		{
			try
			{
				CompressedImage chart = repo.Edge_Window.ScreenshotsInfo.GetWorsheet_TC17();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.Edge_Window.ScreenshotsInfo;
				Validate.ContainsImage(info, chart, options, "Saved Images", false);
				Reports.ReportLog("ValidatePDFTC17", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidatePDFTC17  : " + ex.Message);
			}
		}
		
		public static void ValidatePDFTC18()
		{
			try
			{
				CompressedImage chart = repo.Edge_Window.ScreenshotsInfo.GetWorksheet_TC18();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.Edge_Window.ScreenshotsInfo;
				Validate.ContainsImage(info, chart, options, "Saved Images", false);
				Reports.ReportLog("ValidatePDFTC18", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidatePDFTC18  : " + ex.Message);
			}
		}
		
		public static void ValidatePDFTC19()
		{
			try
			{
				CompressedImage chart = repo.Edge_Window.ScreenshotsInfo.GetWorksheet_TC19();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.Edge_Window.ScreenshotsInfo;
				Validate.ContainsImage(info, chart, options, "Saved Images", false);
				Reports.ReportLog("ValidatePDFTC19", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidatePDFTC19  : " + ex.Message);
			}
		}
		
		public static void ValidatePDFTC20()
		{
			try
			{
				CompressedImage chart = repo.Edge_Window.ScreenshotsInfo.GetWorksheet_TC20();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.Edge_Window.ScreenshotsInfo;
				Validate.ContainsImage(info, chart, options, "Saved Images", false);
				Reports.ReportLog("ValidatePDFTC20", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidatePDFTC20  : " + ex.Message);
			}
		}
		
		public static void ValidatePDFTC21()
		{
			try
			{
				CompressedImage chart = repo.Edge_Window.ScreenshotsInfo.GetWorksheet_TC21();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.Edge_Window.ScreenshotsInfo;
				Validate.ContainsImage(info, chart, options, "Saved Images", false);
				Reports.ReportLog("ValidatePDFTC21", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidatePDFTC21  : " + ex.Message);
			}
		}
		
		public static void ValidatePDFTC22()
		{
			try
			{
				CompressedImage chart = repo.Edge_Window.ScreenshotsInfo.GetWorsheet_TC22();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.Edge_Window.ScreenshotsInfo;
				Validate.ContainsImage(info, chart, options, "Saved Images", false);
				Reports.ReportLog("ValidatePDFTC22", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidatePDFTC22  : " + ex.Message);
			}
		}
		
		public static void ClickonClosePDFFile()
		{
			try
			{   
				Thread.Sleep(6000);
				repo.Edge_Window.CloseWindowInfo.WaitForItemExists(waittime);
				repo.Edge_Window.CloseWindow.ClickThis();
				
				if (repo.HTMLImages.CloseAlltabsPDFInfo.Exists(10000))
					repo.HTMLImages.CloseAlltabsPDF.ClickThis();
				
				Reports.ReportLog("ClickonClosePDFFile", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonClosePDFFile  : " + ex.Message);
			}
		}
		
		public static void CloseVisualizationwindow()
		{
			try
			{   repo.VisualAnalytics.CloseVisualization_WindowInfo.WaitForItemExists(30000);
				repo.VisualAnalytics.CloseVisualization_Window.ClickThis();
				
				if(repo.SaveChanges.DiscardInfo.Exists(5000))
					repo.SaveChanges.Discard.ClickThis();	
				
				Reports.ReportLog("CloseVisualizationwindow", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CloseVisualizationwindow  : " + ex.Message);
			}
		}
		
		public static void Cleanup(string filename, string extension = ".pdf")
		{
			try
			{
				Common.DeleteFile(TC1_10605_Path+filename+extension);
				Reports.ReportLog("Cleanup", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : Cleanup  : " + ex.Message);
			}
		}
		
		public static void Cleanupfolder(string filename)
		{
			try
			{
				Common.DeleteFolder(TC1_10605_Path+filename);
				Reports.ReportLog("Cleanup", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : Cleanup  : " + ex.Message);
			}
		}
		
		public static void Click_Worksheet4()
		{
			try
			{   repo.VisualAnalytics.Worksheet4Info.WaitForItemExists(waittime);
				repo.VisualAnalytics.Worksheet4.ClickThis();
				
				Reports.ReportLog("Click_Worksheet4", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : Click_Worksheet4  : " + ex.Message);
			}
		}
		
		public static void Click_Worksheet5()
		{
			try
			{   repo.VisualAnalytics.Worksheet5Info.WaitForItemExists(waittime);
				repo.VisualAnalytics.Worksheet5.ClickThis();
				
				Reports.ReportLog("Click_Worksheet5", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : Click_Worksheet5  : " + ex.Message);
			}
		}
		
		public static void Click_Worksheet6()
		{
			try
			{   repo.VisualAnalytics.Worksheet6Info.WaitForItemExists(waittime);
				repo.VisualAnalytics.Worksheet6.ClickThis();
				
				Reports.ReportLog("Click_Worksheet6", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : Click_Worksheet6  : " + ex.Message);
			}
		}
		
		public static void Click_Worksheet7()
		{
			try
			{   repo.VisualAnalytics.Worksheet7Info.WaitForItemExists(waittime);
				repo.VisualAnalytics.Worksheet7.ClickThis();
				
				Reports.ReportLog("Click_Worksheet7", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : Click_Worksheet7  : " + ex.Message);
			}
		}
		
		public static void Click_Worksheet8()
		{
			try
			{   repo.VisualAnalytics.Worksheet8Info.WaitForItemExists(waittime);
				repo.VisualAnalytics.Worksheet8.ClickThis();
				
				Reports.ReportLog("Click_Worksheet8", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : Click_Worksheet8  : " + ex.Message);
			}
		}
		
		public static void Click_Worksheet9()
		{
			try
			{   repo.VisualAnalytics.Worksheet4Info.WaitForItemExists(waittime);
				repo.VisualAnalytics.Worksheet4.ClickThis();
				
				Reports.ReportLog("Click_Worksheet9", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : Click_Worksheet9  : " + ex.Message);
			}
		}
		
		public static void Click_Worksheet10()
		{
			try
			{   repo.VisualAnalytics.Worksheet10Info.WaitForItemExists(waittime);
				repo.VisualAnalytics.Worksheet10.ClickThis();
				
				Reports.ReportLog("Click_Worksheet10", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : Click_Worksheet10  : " + ex.Message);
			}
		}
		
		public static void Click_Worksheet3()
		{
			try
			{   repo.VisualAnalytics.WorkSheet3Info.WaitForItemExists(waittime);
				repo.VisualAnalytics.WorkSheet3.ClickThis();
				
				Reports.ReportLog("Click_Worksheet3", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : Click_Worksheet3  : " + ex.Message);
			}
		}
		
		public static void Click_Worksheet2()
		{
			try
			{   
				repo.TabPage.TabContainerInfo.WaitForItemExists(30000);
				repo.TabPage.TabContainer.SelectTab("Worksheet 2");
				
				repo.VisualAnalytics.Worksheet2Info.WaitForItemExists(waittime);
				repo.VisualAnalytics.Worksheet2.ClickThis();
				
				Reports.ReportLog("Click_Worksheet2", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : Click_Worksheet2  : " + ex.Message);
			}
		}
		
				
	}
}
