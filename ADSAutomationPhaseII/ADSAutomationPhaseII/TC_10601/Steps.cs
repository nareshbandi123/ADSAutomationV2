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

namespace ADSAutomationPhaseII.TC_10601
{
	
	public static class Steps
	{
		public static TC10601Repo repo = TC10601Repo.Instance;
		public static string TC1_10601_Path = System.Configuration.ConfigurationManager.AppSettings["TC1_10601_Path"].ToString();
		public static int waittime = 30000;
		
		public static void Explicitewait()
		{
			Thread.Sleep(1000);
		}
		
		public static void ClickonFileMenu()
		{
			try
			{
				repo.Application.FileMenuInfo.WaitForItemExists(waittime);
				repo.Application.FileMenu.ClickThis();
				System.Threading.Thread.Sleep(500);
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
				repo.OpenWindow.FilePathTextbox.TextBoxText(TC1_10601_Path + "test-highlighting.vizx");
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
		
		public static void ClickMaximumWindow()
		{
			
			try
			{
				repo.VisualAnalytics.Self.Maximize();
				Reports.ReportLog("ClickMaximumWindow", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickMaximumWindow  : " + ex.Message);
			}
		}
		
		public static void ClickonWorkSheet()
		{
			try
			{
				
				repo.VAWindow.Self.Maximize();
				repo.VAWindow.WorkSheetInfo.WaitForItemExists(waittime);
				repo.VAWindow.WorkSheet.ClickThis();
				Reports.ReportLog("ClickonWorkSheet", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonWorkSheet : " + ex.Message);
			}
		}
		
		public static void ValidateWorksheet1overlay()
		{
			try
			{
				CompressedImage chart = repo.VisualAnalytics.PivotOverlaysInfo.GetInitialOverlay();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalytics.PivotOverlaysInfo;
				Validate.ContainsImage(info, chart, options, "validate worksheet initial overlay", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateWorksheet1overlay  : " + ex.Message);
			}
		}
		
		public static void ValidateFurnitureoverlayClick()
		{
			try
			{
				CompressedImage chart = repo.VisualAnalytics.PivotOverlaysInfo.GetFurnitureClick();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalytics.PivotOverlaysInfo;
				Validate.ContainsImage(info, chart, options, "validate worksheet click on Furniture overlay", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateFurnitureoverlayClick  : " + ex.Message);
			}
		}
		
		public static void ClickKeepOnlyFurniture()
		{
			try
			{
				repo.VisualAnalytics.FurnitureIconInfo.WaitForItemExists(waittime);
				repo.VisualAnalytics.FurnitureIcon.ClickThis();
				
				repo.SunAwtWindow.KeepOnlyButtonInfo.WaitForItemExists(waittime);
				repo.SunAwtWindow.KeepOnlyButton.ClickThis();
				
				Reports.ReportLog("ClickKeepOnlyFurniture", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickKeepOnlyFurniture : " + ex.Message);
			}
		}
		
		public static void ValidateClickKeepOnlyFurniture()
		{
			try
			{
				
				CompressedImage chart = repo.VisualAnalytics.PivotOverlaysInfo.GetFurniture_Keep_Only();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalytics.PivotOverlaysInfo;
				
				Validate.ContainsImage(info, chart, options, "validate worksheet click on Furniture overlay Keep Only overlay", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateClickKeepOnlyFurniture  : " + ex.Message);
			}
		}
		
		public static void ClickUndo()
		{
			try
			{
				repo.VisualAnalytics.AquaUndoButtonInfo.WaitForItemExists(waittime);
				repo.VisualAnalytics.AquaUndoButton.ClickThis();
				
				Reports.ReportLog("ClickUndo", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickUndo : " + ex.Message);
			}
			
		}
		
		public static void ClickEastShapes()
		{
			try
			{
				repo.VisualAnalytics.EastInfo.WaitForItemExists(waittime);
				repo.VisualAnalytics.East.ClickThis();
				
				Reports.ReportLog("ClickEastShapes", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickEastShapes : " + ex.Message);
			}
		}

		public static void ValidateClickEastShapes()
		{
			try
			{
				CompressedImage chart = repo.VisualAnalytics.PivotOverlaysInfo.GetEastClick();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalytics.PivotOverlaysInfo;
				Validate.ContainsImage(info, chart, options, "validate worksheet click on East overlay", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateClickEastShapes  : " + ex.Message);
			}
		}
		
		public static void ClickToolTipExclude()
		{
			try
			{
				repo.VisualAnalytics.EastInfo.WaitForItemExists(waittime);
				repo.VisualAnalytics.East.ClickThis();
				
				repo.SunAwtWindow.KeepOnlyButtonInfo.WaitForItemExists(waittime);
				repo.SunAwtWindow.KeepOnlyButton.ClickThis();
				
				Reports.ReportLog("ClickToolTipExclude", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickToolTipExclude : " + ex.Message);
			}
		}
		
		public static void ValidateClickToolTipExclude()
		{
			try
			{
				
				CompressedImage chart = repo.VisualAnalytics.PivotOverlaysInfo.GetEast_ExcludeClick();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalytics.PivotOverlaysInfo;
				Validate.ContainsImage(info, chart, options, "validate worksheet click on East Exclude", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateClickToolTipExclude  : " + ex.Message);
			}
		}
		
		public static void Clickon2012_2013Header()
		{
			try
			{
				
				Keyboard.Press("{LControlKey down}");
				repo.VisualAnalyticsWorksheet.BIChartOverlayPanel.Click("258;484");
				repo.VisualAnalyticsWorksheet.BIChartOverlayPanel1Info.WaitForItemExists(waittime);
				repo.VisualAnalyticsWorksheet.BIChartOverlayPanel1.Click("336;486");
				
				Keyboard.Press("{LControlKey up}");
				
				if(repo.SunAwtWindowWorksheet.ViewDataInfo.Exists(3000))
				{
					repo.SunAwtWindowWorksheet.ViewData.ClickThis();
					
					if(repo.ViewDataWorksheet.SummaryInfo.Exists(3000))
					{
						repo.ViewDataWorksheet.Summary.ClickThis();
						
						repo.ViewDataWorksheet.CloseInfo.WaitForItemExists(3000);
						repo.ViewDataWorksheet.Close.ClickThis();
					}
				}
				
				Reports.ReportLog("Clickon2012_2013Header", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			
			catch (Exception ex)
			{
				throw new Exception("Failed : Clickon2012_2013Header  : " + ex.Message);
			}
		}
		
		public static void ClickKeepTooltip2012Header()
		{
			try
			{
				
				repo.VisualAnalyticsTestHighlightingVinew.BIChartOverlayPanel.Click("178;490");
				if(repo.Datastudionew.KeepOnlyInfo.Exists(3000))
				{
					repo.Datastudionew.KeepOnly.ClickThis();
				}
				
				Reports.ReportLog("ClickKeepTooltip2012Header", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickKeepTooltip2012Header  : " + ex.Message);
			}
		}
		
		public static void ValidateClickKeepTooltip2012Header()
		{
			try
			{
				CompressedImage chart = repo.VisualAnalyticsTestHighlightingVinew.screeenshotsInfo.GetScreenshot1();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalyticsTestHighlightingVinew.screeenshotsInfo;
				Validate.ContainsImage(info, chart, options, "validate Click Keep Tooltip 2012 Header", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateClickKeepTooltip2012Header  : " + ex.Message);
			}
		}
		
		public static void ClickonViewdata()
		{
			try
			{
				repo.SunAwtWindow.ViewData_FromChartInfo.WaitForItemExists(waittime);
				repo.SunAwtWindow.ViewData_FromChart.Click("31;12");
				
				repo.ViewData.Text0Row.ClickThis();
				
				repo.ViewData.CloseInfo.WaitForItemExists(waittime);
				repo.ViewData.Close.ClickThis();
				
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : Clickon2011Column : " + ex.Message);
			}
		}
		
		public static void ClickonNewworksheet12()
		{
			try
			{
				repo.VisualAnalytics.Worksheet12Info.WaitForItemExists(waittime);
				repo.VisualAnalytics.Worksheet12.ClickThis();
				
				repo.SunAwtWindow.NewWorksheet12Info.WaitForItemExists(waittime);
				repo.SunAwtWindow.NewWorksheet12.ClickThis();
				
				Reports.ReportLog("ClickonNewworksheet12", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : Clickon2011Column : " + ex.Message);
			}
		}
		
		public static void DragRegionAndSales()
		{
			try
			{
				repo.VisualAnalytics.Worksheet_12.ProductSubCategoryInfo.WaitForItemExists(waittime);
				repo.VisualAnalytics.Worksheet_12.ProductSubCategory.ClickThis();
				repo.VisualAnalytics.Worksheet_12.ProductSubCategory.RightClickThis();
				
				repo.SunAwtWindow.AddToColumnsDeck_Worksheet12Info.WaitForItemExists(waittime);
				repo.SunAwtWindow.AddToColumnsDeck_Worksheet12.ClickThis();
				
				repo.VisualAnalytics.Worksheet_12.RegionInfo.WaitForItemExists(waittime);
				repo.VisualAnalytics.Worksheet_12.Region.ClickThis();
				
				repo.VisualAnalytics.Worksheet_12.Region.RightClickThis();
				repo.SunAwtWindow.AddToRowsDeck_Worksheet12Info.WaitForItemExists(waittime);
				repo.SunAwtWindow.AddToRowsDeck_Worksheet12.ClickThis();
				
				repo.VisualAnalytics.SUMSales_Worksheet12Info.WaitForItemExists(waittime);
				repo.VisualAnalytics.SUMSales_Worksheet12.ClickThis();
				repo.VisualAnalytics.SUMSales_Worksheet12.RightClickThis();
				
				repo.SunAwtWindow.AddToRowsDeck_Worksheet12Info.WaitForItemExists(waittime);
				repo.SunAwtWindow.AddToRowsDeck_Worksheet12.ClickThis();
				
				repo.VisualAnalytics.Worksheet_12.CustomerSegmentInfo.WaitForItemExists(waittime);
				repo.VisualAnalytics.Worksheet_12.CustomerSegment.Click("74;6");
				
				repo.VisualAnalytics.Worksheet_12.CustomerSegment.MoveTo("59;5");
				
				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
				repo.VisualAnalytics.Worksheet_12.CustomerSegment.MoveTo("67;-3");
				
				repo.VisualAnalytics.Color.MoveTo("18;19");
				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				
				Reports.ReportLog("DragRegionAndSales", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragRegionAndSales : " + ex.Message);
			}
		}
		
		public static void ClickCentralandEast()
		{
			try
			{
				Keyboard.Press("{LControlKey down}");
				repo.VisualAnalytics.Worsheet8.BIChartOverlayPanel.Click("23;77");
				repo.VisualAnalytics.Worsheet8.BIChartOverlayPanel1.Click("34;163");
				
				Keyboard.Press("{LControlKey up}");
				

				if(repo.SunAwtWindow.KeepOnly_newworksheetInfo.Exists(3000))
				{
					repo.SunAwtWindow.KeepOnly_newworksheet.Click("26;8");
				}

				Reports.ReportLog("ClickCentralandEast", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickCentralandEast : " + ex.Message);
			}
		}
		
		public static void ValidateSelectCentralandEast()
		{
			try
			{
				CompressedImage chart = repo.VisualAnalytics.EastCentralOverlay_Worksheet2Info.GetSelectCentralEast_KeepRows();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalytics.EastCentralOverlay_Worksheet2Info;
				Validate.ContainsImage(info, chart, options, "Validate map", false);
				
				Reports.ReportLog("ValidateSelectCentralandEast", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateSelectCentralandEast  : " + ex.Message);
			}
			
		}
		
		public static void ClickCopiersandEnvelopes()
		{
			try
			{
				Keyboard.Press("{LControlKey down}");
				repo.VisualAnalytics.Copiers_and_Fax.MoveTo("368;385");
				
				repo.VisualAnalytics.Copiers_and_Fax.MoveTo("398;374");
				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				
				repo.VisualAnalytics.EnvelopesInfo.WaitForItemExists(waittime);
				repo.VisualAnalytics.Envelopes.Click("371;375");
				Keyboard.Press("{LControlKey up}");
				
				if(repo.SunAwtWindow.KeepOnlyInfo.Exists(3000))
				{
					repo.SunAwtWindow.KeepOnly.ClickThis();
				}
				
				Reports.ReportLog("ClickCopiersandEnvelopes", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickCopiersandEnvelopes : " + ex.Message);
			}
		}
		
		public static void ValidateClickCopiersandEnvelopes()
		{
			try
			{
				CompressedImage chart = repo.VisualAnalytics.EastCentralOverlay_Worksheet2Info.GetSelectCopiersFaxAndEnvelopes_KeepRows();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalytics.EastCentralOverlay_Worksheet2Info;
				Validate.ContainsImage(info, chart, options, "Validate map", false);
				
				Reports.ReportLog("ValidateClickCopiersandEnvelopes", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateClickCopiersandEnvelopes  : " + ex.Message);
			}
		}
		
		public static void ClickExclude()
		{
			try
			{
				repo.VisualAnalytics.ContainerCanvas_NewworksheetInfo.WaitForItemExists(waittime);
				repo.VisualAnalytics.ContainerCanvas_Newworksheet.Click("183;121");
				
				if(repo.SunAwtWindow.ExcludeInfo.Exists(waittime))
				{
					repo.SunAwtWindow.Exclude.Click("37;13");
				}
				
				Reports.ReportLog("ClickExclude", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickExclude : " + ex.Message);
			}
		}
		
		public static void ValidateClickExclude()
		{
			try
			{
				CompressedImage chart = repo.VisualAnalytics.EastCentralOverlay_Worksheet2Info.GetSelectClickExclude();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalytics.EastCentralOverlay_Worksheet2Info;
				Validate.ContainsImage(info, chart, options, "Validate map", false);
				
				Reports.ReportLog("ValidateClickExclude", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateClickExclude  : " + ex.Message);
			}
		}
		
		public static void ClickSwapandKeeponlySelect()
		{
			
			try
			{
				repo.VisualAnalytics.Swap_Rows_Columns_iconInfo.WaitForItemExists(waittime);
				repo.VisualAnalytics.Swap_Rows_Columns_icon.ClickThis();
				
				repo.VisualAnalytics.ChartColorSelect.Click("203;58");
				if(repo.SunAwtWindow.KeepOnlyInfo.Exists(3000))
				{
					repo.SunAwtWindow.KeepOnly.Click("24;9");
				}
				
				
				Reports.ReportLog("ClickSwapandSelect", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickSwapandSelect  : " + ex.Message);
			}
		}
		
		public static void ValidateSelectSwapandKeeponly()
		{
			try
			{
				CompressedImage chart = repo.VisualAnalytics.EastCentralOverlay_Worksheet2Info.GetSelectSwap();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalytics.EastCentralOverlay_Worksheet2Info;
				Validate.ContainsImage(info, chart, options, "Validate map", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateSelectSwap  : " + ex.Message);
			}
		}		
		
		public static void Worksheet3Testdatapreparation()
		{
			
			try
			{
				
				repo.VisualAnalytics.Worksheet_Worksheet3Info.WaitForItemExists(20000);
				repo.VisualAnalytics.Worksheet_Worksheet3.ClickThis();
				
				repo.SunAwtWindow.NewWorksheet_Worksheet3Info.WaitForItemExists(waittime);
				repo.SunAwtWindow.NewWorksheet_Worksheet3.ClickThis();
				
				repo.VisualAnalytics.ContainerMainPanel_Worksheet3.ProductSubCategory.Click(System.Windows.Forms.MouseButtons.Right, "109;8");
				
				repo.SunAwtWindow.AddToColumnsDeck_Worksheet3Info.WaitForItemExists(waittime);
				repo.SunAwtWindow.AddToColumnsDeck_Worksheet3.Click("42;7");
				
				repo.VisualAnalytics.ContainerMainPanel_Worksheet3.StateOrProvince.Click("90;9");
				
				repo.VisualAnalytics.ContainerMainPanel_Worksheet3.StateOrProvince.Click(System.Windows.Forms.MouseButtons.Right, "90;9");
				
				repo.SunAwtWindow.AddToRowsDeck_Worksheet3Info.WaitForItemExists(waittime);
				repo.SunAwtWindow.AddToRowsDeck_Worksheet3.Click("33;6");
				
				repo.VisualAnalytics.ContainerMainPanel_Worksheet3.SUMProfitInfo.WaitForItemExists(waittime);
				repo.VisualAnalytics.ContainerMainPanel_Worksheet3.SUMProfit.Click("54;8");
				repo.VisualAnalytics.ContainerMainPanel_Worksheet3.SUMProfit.Click(System.Windows.Forms.MouseButtons.Right, "54;8");
				
				repo.SunAwtWindow.AddToRowsDeck_Worksheet3Info.WaitForItemExists(waittime);
				repo.SunAwtWindow.AddToRowsDeck_Worksheet3.Click("27;12");
				
				repo.VisualAnalytics.ContainerMainPanel_Worksheet3.WindowsComboBoxUIDollarXPComboBoxButton.Click("7;6");
				
				repo.SunAwtWindow.ListItemBar_Worksheet3.ClickThis();
				
				Reports.ReportLog("Worksheet3Testdatapreparation", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : Worksheet3Testdatapreparation  : " + ex.Message);
			}
		}
		
		public static void ClickOntheChartKeepOnly()
		{
			try
			{
				repo.VisualAnalytics.ChartOverlay13Info.WaitForItemExists(waittime);
				repo.VisualAnalytics.ChartOverlay13.Click("187;96");
				
				if (repo.SunAwtWindow.KeepOnly_Worksheet13Info.Exists(5000))
				{
					repo.SunAwtWindow.KeepOnly_Worksheet13Info.WaitForItemExists(waittime);
					repo.SunAwtWindow.KeepOnly_Worksheet13.ClickThis();
				}
				
				Reports.ReportLog("ClickOntheChartKeepOnly", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOntheChartKeepOnly : " + ex.Message);
			}
		}
		
		public static void ValidateKeepOnly_Worksheet3()
		{
			try
			{
				CompressedImage chart = repo.VisualAnalytics.ChartOverlay_Worksheet13Info.GetSelect_KeepOnly();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalytics.ChartOverlay_Worksheet13Info;
				Validate.ContainsImage(info, chart, options, "Validate map", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateKeepOnly_Worksheet3  : " + ex.Message);
			}
		}
		
		public static void ClickOntheChartExclude()
		{
			try
			{
				
				Keyboard.Press("{LControlKey down}");
				repo.VisualAnalytics.ContainerCanvas_Worksheet13Info.WaitForItemExists(waittime);
				repo.VisualAnalytics.ContainerCanvas_Worksheet13.Click("173;83");
				Keyboard.Press("{LControlKey up}");
				
				if(repo.SunAwtWindow.Exclude_Worksheet13Info.Exists(1000))
					repo.SunAwtWindow.Exclude_Worksheet13.Click("50;14");
				
				
				Reports.ReportLog("ClickOntheChartExclude", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOntheChartExclude : " + ex.Message);
			}
		}
		
		public static void ValidateExclude_Worksheet3()
		{
			try
			{
				CompressedImage chart = repo.VisualAnalytics.ChartOverlay_Worksheet13Info.GetSelect_Exclude();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalytics.ChartOverlay_Worksheet13Info;
				Validate.ContainsImage(info, chart, options, "Validate map", false);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateKeepOnly_Worksheet3  : " + ex.Message);
			}
		}
		
		public static void ClickKeeponlyAfterSwap()
		{
			try
			{
				repo.VisualAnalytics.PaletteButtonInfo.WaitForItemExists(waittime);
				repo.VisualAnalytics.PaletteButton.Click("27;20");
				
				repo.VisualAnalytics.Worksheet13Info.WaitForItemExists(waittime);
				repo.VisualAnalytics.Worksheet13.Click("75;75");
				
				if(repo.SunAwtWindow.KeepOnly_Worksheet13Info.Exists(3000))
				{
					repo.SunAwtWindow.KeepOnly_Worksheet13.ClickThis();
				}
				
				Reports.ReportLog("ClickKeeponlyAfterSwap", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickKeeponlyAfterSwap : " + ex.Message);
			}
		}
		
		public static void ValidateSwapKeeponly_Worksheet3()
		{
			try
			{
				CompressedImage chart = repo.VisualAnalytics.ChartOverlay_Worksheet13Info.GetSelect_AfterSwap_Keeponly();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalytics.ChartOverlay_Worksheet13Info;
				Validate.ContainsImage(info, chart, options, "Validate map", false);
				
				Reports.ReportLog("ValidateSwapKeeponly_Worksheet3", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateSwapKeeponly_Worksheet3  : " + ex.Message);
			}
		}
		
		public static void ValidateSelectFewColorsinLegend()
		{
			try
			{
				CompressedImage chart = repo.VisualAnalytics.ContainerCanvas_Worksheet4Info.GetSelectFewColorsinLegend();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalytics.ContainerCanvas_Worksheet4Info;
				Validate.ContainsImage(info, chart, options, "Validate map", false);
				
				Reports.ReportLog("ValidateSelectFewColorsinLegend", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateSelectFewColorsinLegend  : " + ex.Message);
			}
			
		}
		
		public static void ClickonWorkSheet4fewentrie()
		{
			try
			{
				repo.VisualAnalytics.Worksheet4_TabInfo.WaitForItemExists(waittime);
				repo.VisualAnalytics.Worksheet4_Tab.ClickThis();
				
				Keyboard.Press("{LControlKey down}");
				
				repo.VisualAnalytics.ContainerCanvas_Worksheet4Info.WaitForItemExists(waittime);
				repo.VisualAnalytics.ContainerCanvas_Worksheet4.Click("309;200");
				
				repo.VisualAnalytics.ContainerCanvas_Worksheet4Info.WaitForItemExists(waittime);
				repo.VisualAnalytics.ContainerCanvas_Worksheet4.Click("400;116");
				
				Keyboard.Press("{LControlKey up}");
				
				Reports.ReportLog("ClickonWorkSheet4fewentrie", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonWorkSheet4fewentrie : " + ex.Message);
			}
		}
		
		public static void ValidateSelectFewColorsinLegend1()
		{
			try
			{
				
				CompressedImage chart = repo.VisualAnalytics.ContainerCanvas_Worksheet4Info.GetSelectFewColorsinLegend();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalytics.ContainerCanvas_Worksheet4Info;
				Validate.ContainsImage(info, chart, options, "Validate map", false);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateSelectFewColorsinLegend  : " + ex.Message);
			}
			
		}
		
		public static void ClickonKeepOnlyTooltipFewEntiries()
		{
			try
			{
				Keyboard.Press("{LControlKey down}");
				
				repo.VisualAnalytics.ContainerCanvas_Worksheet4.MoveTo("306;175");
				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
				
				repo.VisualAnalytics.ContainerCanvas_Worksheet4.MoveTo("318;144");
				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				
				repo.VisualAnalytics.ContainerCanvas_Worksheet4Info.WaitForItemExists(waittime);
				repo.VisualAnalytics.ContainerCanvas_Worksheet4.Click("318;144");
				
				Keyboard.Press("{LControlKey up}");
				
				if (repo.SunAwtWindow.KeepOnly_Worksheet4Info.Exists(10000))
				{
					repo.SunAwtWindow.KeepOnly_Worksheet4Info.WaitForItemExists(waittime);
					repo.SunAwtWindow.KeepOnly_Worksheet4.Click("28;11");
				}
				
				
				Reports.ReportLog("ClickonKeepOnlyTooltipFewEntiries", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonKeepOnlyTooltipFewEntiries : " + ex.Message);
			}
		}
		
		public static void ValidateSelectfewKeepOnlyTooltip()
		{
			try
			{
				
				CompressedImage chart = repo.VisualAnalytics.ContainerCanvas_Worksheet4Info.GetSelectFewKeepOnlyTooltip();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalytics.ContainerCanvas_Worksheet4Info;
				Validate.ContainsImage(info, chart, options, "Validate map", false);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateSelectfewKeepOnlyTooltip  : " + ex.Message);
			}
			
		}
		
		public static void ClickonFewandExclude()
		{
			try
			{
				Keyboard.Press("{LControlKey down}");
				repo.VisualAnalytics.ContainerCanvas_Worksheet4Info.WaitForItemExists(waittime);
				repo.VisualAnalytics.ContainerCanvas_Worksheet4.Click("399;126");
				
				Keyboard.Press("{LControlKey up}");
				repo.SunAwtWindow.Exclude_Worksheet4Info.WaitForItemExists(waittime);
				repo.SunAwtWindow.Exclude_Worksheet4.Click("43;12");
				
				Reports.ReportLog("ClickonFewandExclude", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonFewandExclude : " + ex.Message);
			}
		}
		
		public static void ValidateSelectfewExcludeTooltip()
		{
			try
			{
				CompressedImage chart = repo.VisualAnalytics.ContainerCanvas_Worksheet4Info.GetSelectFewExclude();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalytics.ContainerCanvas_Worksheet4Info;
				Validate.ContainsImage(info, chart, options, "Validate map", false);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateSelectfewExcludeTooltip  : " + ex.Message);
			}
			
		}
		
		public static void DragRegiontoLabelClickOptions()
		{
			try
			{
				
				repo.VisualAnalytics.Region_Dimensions_Worksheet4.MoveTo("28;8");
				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
				
				repo.VisualAnalytics.Region_Dimensions_Worksheet4.MoveTo("36;0");
				
				repo.VisualAnalytics.Label_ChartOptions_Worksheet4.MoveTo("27;19");
				
				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				
				repo.VisualAnalytics.Options_Worksheet4Info.WaitForItemExists(waittime);
				repo.VisualAnalytics.Options_Worksheet4.Click("37;22");
				
				repo.ChartOptions.JSlider_Worksheet.MoveTo("4;17");
				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
				
				repo.ChartOptions.JSlider_Worksheet.MoveTo("72;18");
				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				
				Reports.ReportLog("DragRegiontoLabelClickOptions", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragRegiontoLabelClickOptions : " + ex.Message);
			}
		}
		
		public static void ValidateSelectSlideCenterHoleSize()
		{
			try
			{
				CompressedImage chart = repo.VisualAnalytics.ContainerCanvas_Worksheet4Info.GetSelectSlideCenterHoleSize();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalytics.ContainerCanvas_Worksheet4Info;
				Validate.ContainsImage(info, chart, options, "Validate map", false);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateSelectSlideCenterHoleSize  : " + ex.Message);
			}
			
		}
		
		public static void ClickSelectKeepOnly_CenterHolesize()
		{
			try
			{
				Keyboard.Press("{LControlKey up}");
				repo.VisualAnalytics.ContainerCanvas_Worksheet4Info.WaitForItemExists(waittime);
				repo.VisualAnalytics.ContainerCanvas_Worksheet4.Click("362;116");
				
				repo.VisualAnalytics.ContainerCanvas_Worksheet4Info.WaitForItemExists(waittime);
				repo.VisualAnalytics.ContainerCanvas_Worksheet4.Click("330;133");
				
				Keyboard.Press("{LControlKey down}");
				
				repo.SunAwtWindow.KeepOnlyInfo.WaitForItemExists(waittime);
				repo.SunAwtWindow.KeepOnly.Click("45;12");
				
				Reports.ReportLog("ClickSelectKeepOnly_CenterHolesize", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickSelectKeepOnly_CenterHolesize : " + ex.Message);
			}
		}
		
		public static void ValidateSelectKeepOnly_CenterHolesize()
		{
			try
			{
				CompressedImage chart = repo.VisualAnalytics.ContainerCanvas_Worksheet4Info.GetSelectKeepOnly_CenterHolesize();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalytics.ContainerCanvas_Worksheet4Info;
				Validate.ContainsImage(info, chart, options, "Validate map", false);
				
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateSelectKeepOnly_CenterHolesize  : " + ex.Message);
			}
			
		}
		
		public static void NavigatetoWorksheet5SelecttwoColors()
		{
			try
			{
				repo.VisualAnalytics.Worksheet5Info.WaitForItemExists(waittime);
				repo.VisualAnalytics.Worksheet5.Click("36;16");
				
				Keyboard.Press("{LControlKey down}");
				
				repo.VisualAnalytics.ContainerCanvas_Worksheet5Info.WaitForItemExists(waittime);
				repo.VisualAnalytics.ContainerCanvas_Worksheet5.Click("443;208");
				
				repo.VisualAnalytics.ContainerCanvas_Worksheet5Info.WaitForItemExists(waittime);
				repo.VisualAnalytics.ContainerCanvas_Worksheet5.Click("423;233");
				
				repo.VisualAnalytics.ContainerCanvas_Worksheet5Info.WaitForItemExists(waittime);
				repo.VisualAnalytics.ContainerCanvas_Worksheet5.Click("439;175");
				
				Keyboard.Press("{LControlKey up}");
				
				Reports.ReportLog("NavigatetoWorksheet5SelecttwoColors", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : NavigatetoWorksheet5SelecttwoColors : " + ex.Message);
			}
		}
		
		public static void ValidateSelect_Chartwith2_colors()
		{
			try
			{
				CompressedImage chart = repo.VisualAnalytics.ContainerCanvas_Worksheet5Info.GetSelect_Chartwith2_colors();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalytics.ContainerCanvas_Worksheet5Info;
				Validate.ContainsImage(info, chart, options, "Validate map", false);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateSelect_Chartwith2_colors  : " + ex.Message);
			}
			
		}
		
		public static void ClickonchartClickKeepOnly()
		{
			try
			{
				
				Keyboard.Press("{LControlKey down}");
				
				repo.VisualAnalytics.ContainerCanvas_Worksheet5Info.WaitForItemExists(waittime);
				repo.VisualAnalytics.ContainerCanvas_Worksheet5.Click("496;182");
				
				Keyboard.Press("{LControlKey up}{LControlKey down}");
				
				repo.VisualAnalytics.ContainerCanvas_Worksheet5Info.WaitForItemExists(waittime);
				repo.VisualAnalytics.ContainerCanvas_Worksheet5.Click("496;182");
				
				Keyboard.Press("{LControlKey up}");
				
				if(repo.SunAwtWindow.KeepOnly_WorkSheet5Info.Exists())
				{
					repo.SunAwtWindow.KeepOnly_WorkSheet5Info.WaitForItemExists(waittime);
					repo.SunAwtWindow.KeepOnly_WorkSheet5.ClickThis();
				}
					
				Reports.ReportLog("ClickonchartClickKeepOnly", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonchartClickKeepOnly  : " + ex.Message);
			}
			
		}
		
		public static void ValidateSelectedChartAndClickKeepOnly()
		{
			try
			{
				CompressedImage chart = repo.VisualAnalytics.ContainerCanvas_Worksheet5Info.GetSelectedChartAndClickKeepOnly();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalytics.ContainerCanvas_Worksheet5Info;
				Validate.ContainsImage(info, chart, options, "Validate map", false);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateSelectedChartAndClickKeepOnly  : " + ex.Message);
			}
			
		}
		
		public static void ClickonVisualization()
		{
			try
			{
				repo.VisualAnalytics.VisualizationInfo.WaitForItemExists(waittime);
				repo.VisualAnalytics.Visualization.ClickThis();
				Reports.ReportLog("ClickonVisualization", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonVisualization : " + ex.Message);
			}
		}
		
		public static void SelectMekkoClick2colors()
		{
			try
			{
				
				repo.VisualAnalytics.SelectMekkoButtonInfo.WaitForItemExists(waittime);
				repo.VisualAnalytics.SelectMekkoButton.Click("17;20");
				
				Keyboard.Press("{LControlKey down}");
				
				repo.VisualAnalytics.ContainerCanvas_Worksheet5Info.WaitForItemExists(waittime);
				repo.VisualAnalytics.ContainerCanvas_Worksheet5.Click("320;67");
				
				repo.VisualAnalytics.ContainerCanvas_Worksheet5Info.WaitForItemExists(waittime);
				repo.VisualAnalytics.ContainerCanvas_Worksheet5.Click("295;175");
				
				Keyboard.Press("{LControlKey up}");
				
				Reports.ReportLog("SelectMekkoClick2colors", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectMekkoClick2colors  : " + ex.Message);
			}
		}
		
		public static void ValidateSelectMekkoClick2colors()
		{
			try
			{
				
				CompressedImage chart = repo.VisualAnalytics.ContainerCanvas_Worksheet5Info.GetSelectMekkoClick2colors1();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalytics.ContainerCanvas_Worksheet5Info;
				Validate.ContainsImage(info, chart, options, "Validate map", false);
				
				Reports.ReportLog("ValidateSelectMekkoClick2colors", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateSelectMekkoClick2colors  : " + ex.Message);
			}
		}
		
		public static void MekkoclickExclude()
		{
			try
			{
				
				Keyboard.Press("{LControlKey down}");
				
				repo.VisualAnalytics.ContainerCanvas_Worksheet5Info.WaitForItemExists(waittime);
				repo.VisualAnalytics.ContainerCanvas_Worksheet5.Click("286;57");
				
				Keyboard.Press("{LControlKey up}{LControlKey down}");
				
				repo.VisualAnalytics.ContainerCanvas_Worksheet5.Click("284;58");
				
				Keyboard.Press("{LControlKey up}");
				
				repo.SunAwtWindow.Exclude_Worksheet5.Click("27;10");
				
				Reports.ReportLog("MekkoclickExclude", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : MekkoclickExclude  : " + ex.Message);
			}
		}
		
		public static void ValidateSelect_Mekkoclick_Exclude()
		{
			try
			{
				CompressedImage chart = repo.VisualAnalytics.ContainerCanvas_Worksheet5Info.GetSelect_Mekkoclick_Exclude();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalytics.ContainerCanvas_Worksheet5Info;
				Validate.ContainsImage(info, chart, options, "Validate map", false);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateSelect_Mekkoclick_Exclude  : " + ex.Message);
			}
		}
		
		public static void ClickonSwapRowsandColumnsicon()
		{
			try
			{
				repo.VisualAnalytics.Swap_Rows_Columns_iconInfo.WaitForItemExists(waittime);
				repo.VisualAnalytics.Swap_Rows_Columns_icon.ClickThis();
				Reports.ReportLog("ClickonSwapRowsandColumnsicon", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonSwapRowsandColumnsicon  : " + ex.Message);
			}
		}
		
		public static void ValidateSwapRowsColumnsicon()
		{
			try
			{
				
				CompressedImage chart = repo.VisualAnalytics.ContainerCanvas_Worksheet5Info.GetSwapRowsColumnsicon();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalytics.ContainerCanvas_Worksheet5Info;
				Validate.ContainsImage(info, chart, options, "Validate map", false);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateSwapRowsColumnsicon  : " + ex.Message);
			}
		}
		
		public static void ClickonSwapRowsandColumnsSelect2Colors()
		{
			try
			{
				
				Keyboard.Press("{LControlKey down}");
				repo.VisualAnalytics.ChartoverlayAfterSwap_Worksheet5Info.WaitForItemExists(waittime);
				repo.VisualAnalytics.ChartoverlayAfterSwap_Worksheet5.Click("186;89");
				
				repo.VisualAnalytics.ChartoverlayAfterSwap_Worksheet5Info.WaitForItemExists(waittime);
				repo.VisualAnalytics.ContainerCanvas_Worksheet5.Click("165;211");
				
				Keyboard.Press("{LControlKey up}");
				
				Reports.ReportLog("ClickonSwapRowsandColumnsSelect2Colors", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonSwapRowsandColumnsSelect2Colors  : " + ex.Message);
			}
		}
		
		public static void CloseVisualChart()
		{
			try
			{
				repo.VisualAnalytics.Visualization_OveralayInfo.WaitForItemExists(waittime);
				repo.VisualAnalytics.Visualization_Overalay.ClickThis();
				
				Reports.ReportLog("CloseVisualChart", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CloseVisualChart  : " + ex.Message);
			}
		}
		
		public static void ValidateAfterSwapRowsColorSelect2colors()
		{
			try
			{
				
				CompressedImage chart = repo.VisualAnalytics.ContainerCanvas_Worksheet5Info.GetAfterSwapRowsColorSelect2colors();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalytics.ContainerCanvas_Worksheet5Info;
				Validate.ContainsImage(info, chart, options, "Validate map", false);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterSwapRowsColorSelect2colors  : " + ex.Message);
			}
		}
		
		public static void  SelectedChartKeepOnly()
		{
			try
			{
				Keyboard.Press("{LControlKey down}");
				
				
				repo.VisualAnalytics.ContainerCanvas_Worksheet5Info.WaitForItemExists(waittime);
				repo.VisualAnalytics.ContainerCanvas_Worksheet5.Click("258;112");
				
				repo.VisualAnalytics.ContainerCanvas_Worksheet5Info.WaitForItemExists(waittime);
				repo.VisualAnalytics.ContainerCanvas_Worksheet5.Click("258;112");
				
				Keyboard.Press("{LControlKey up}");
				
				if(repo.SunAwtWindow.KeepOnly_WorkSheet5Info.Exists(6000))
				{
					repo.SunAwtWindow.KeepOnly_WorkSheet5Info.WaitForItemExists(waittime);
					repo.SunAwtWindow.KeepOnly_WorkSheet5.ClickThis();
				}
				Reports.ReportLog("SelectedChartKeepOnly", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectedChartKeepOnly  : " + ex.Message);
			}
		}
		
		public static void ValidateAfterclickon_SwapIcon_Keep_Only()
		{
			try
			{
				
				CompressedImage chart = repo.VisualAnalytics.ContainerCanvas_Worksheet5Info.GetAfterclickon_SwapIcon_Keep_Only();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalytics.ContainerCanvas_Worksheet5Info;
				Validate.ContainsImage(info, chart, options, "Validate map", false);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterclickon_SwapIcon_Keep_Only  : " + ex.Message);
			}
		}
		
		public static void  ClickonRadarExclude()
		{
			try
			{
				repo.VisualAnalytics.RadarButtonInfo.WaitForItemExists(waittime);
				repo.VisualAnalytics.RadarButton.Click("20;17");
				
				Keyboard.Press("{LControlKey down}");
				repo.VisualAnalytics.ContainerCanvas_Worksheet5Info.WaitForItemExists(waittime);
				repo.VisualAnalytics.ContainerCanvas_Worksheet5.Click("447;136");
				
				Keyboard.Press("{LControlKey up}");
				
				if (repo.SunAwtWindow.Exclude_Worksheet5Info.Exists(6000))
					repo.SunAwtWindow.Exclude_Worksheet5.ClickThis();
				
				Reports.ReportLog("ClickonRadarExclude", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonRadarExclude  : " + ex.Message);
			}
		}
		
		public static void ValidateRadarExcludeSelection()
			
		{
			try
			{
				
				CompressedImage chart = repo.VisualAnalytics.ContainerCanvas_Worksheet5Info.GetRadar_ExcludeSelection();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalytics.ContainerCanvas_Worksheet5Info;
				Validate.ContainsImage(info, chart, options, "Validate map", false);
				
				Reports.ReportLog("ValidateRadarExcludeSelection", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateRadarExcludeSelection  : " + ex.Message);
			}
			
		}
		
		public static void NavigatetoWorsheet6AndClickMultiple()
		{
			try
			{   repo.VisualAnalytics.Worksheet6Info.WaitForItemExists(waittime);
				repo.VisualAnalytics.Worksheet6.ClickThis();
				
				Keyboard.Press("{LControlKey down}");
				repo.VisualAnalytics.ContainerCanvas_Worksheet6Info.WaitForItemExists(waittime);
				repo.VisualAnalytics.ContainerCanvas_Worksheet6.Click("202;193");
				repo.VisualAnalytics.ContainerCanvas_Worksheet6Info.WaitForItemExists(waittime);
				repo.VisualAnalytics.ContainerCanvas_Worksheet6.Click("190;377");
				
				Keyboard.Press("{LControlKey up}");
				
				Reports.ReportLog("NavigatetoWorsheet6AndClickMultiple", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : NavigatetoWorsheet6AndClickMultiple  : " + ex.Message);
			}
		}
		
		public static void ValidateClickColorsfromMap1Worksheet6()
		{
			try
			{
				
				CompressedImage chart = repo.VisualAnalytics.Worsheet6OverlayChartsInfo.GetSelectedInitailfromChart();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalytics.Worsheet6OverlayChartsInfo;
				Validate.ContainsImage(info, chart, options, "Validate Click Colors from Map1 Worksheet6", false);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateClickColorsfromMap1Worksheet6  : " + ex.Message);
			}
		}
		
		public static void DragSelectSeveralChart()
		{
			try
			{

				Keyboard.Press("{LControlKey down}");
				repo.VisualAnalytics.ContainerCanvas_Worksheet6Info.WaitForItemExists(waittime);
				repo.VisualAnalytics.ContainerCanvas_Worksheet6.Click("183;145");
				repo.VisualAnalytics.ContainerCanvas_Worksheet6Info.WaitForItemExists(waittime);
				repo.VisualAnalytics.ContainerCanvas_Worksheet6.Click("163;144");
				Keyboard.Press("{LControlKey up}");
				repo.SunAwtWindow.KeepOnlyInfo.WaitForItemExists(waittime);
				repo.SunAwtWindow.KeepOnly.Click("34;8");
				
				Reports.ReportLog("DragSelectSeveralChart", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragSelectSeveralChart  : " + ex.Message);
			}
		}
		
		public static void ValidateSelectedChartSegmentsClickKeeponly()
		{
			try
			{
				CompressedImage chart = repo.VisualAnalytics.Worsheet6OverlayChartsInfo.GetSelectedChartSegmentsClickKeeponly_old();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalytics.Worsheet6OverlayChartsInfo;
				Validate.ContainsImage(info, chart, options, "Validate map", false);;
				
				Reports.ReportLog("ValidateSelectedChartSegmentsClickKeeponly", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateSelectedChartSegmentsClickKeeponly  : " + ex.Message);
			}
		}
		
		public static void NavigatetoWorsheet7AndClickMultiple()
		{
			try
			{
				repo.VisualAnalytics.Worksheet7Info.WaitForItemExists(waittime);
				repo.VisualAnalytics.Worksheet7.Click("41;14");
				
				Keyboard.Press("{LControlKey down}");
				repo.VisualAnalytics.ContainerCanvas_Worksheet7Info.WaitForItemExists(waittime);
				repo.VisualAnalytics.ContainerCanvas_Worksheet7.Click("116;145");
				repo.VisualAnalytics.ContainerCanvas_Worksheet7Info.WaitForItemExists(waittime);
				repo.VisualAnalytics.ContainerCanvas_Worksheet7.Click("113;237");
				
				Keyboard.Press("{LControlKey up}");
				
				Reports.ReportLog("NavigatetoWorsheet7AndClickMultiple", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : NavigatetoWorsheet7AndClickMultiple  : " + ex.Message);
			}
		}
		
		public static void ValidateClickColorsfromMap1()
		{
			try
			{
				
				CompressedImage chart = repo.VisualAnalytics.Worsheet7OverlayInfo.GetSelectInitalfromOverlay();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalytics.Worsheet7OverlayInfo;
				Validate.ContainsImage(info, chart, options, "Validate map", false);
				
				Reports.ReportLog("ValidateClickColorsfromMap1", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateClickColorsfromMap1  : " + ex.Message);
			}
		}
		
		public static void DragSelectSeveralChart_Worsheet7()
		{
			try
			{
				Keyboard.Press("{LControlKey down}");
				repo.VisualAnalytics.ContainerCanvas_Worksheet7Info.WaitForItemExists(waittime);
				repo.VisualAnalytics.ContainerCanvas_Worksheet7.Click("132;149");
				
				Keyboard.Press("{LControlKey up}");
				repo.SunAwtWindow.Exclude_Worksheet7Info.WaitForItemExists(waittime);
				repo.SunAwtWindow.Exclude_Worksheet7.Click("25;12");
				
				Reports.ReportLog("DragSelectSeveralChart_Worsheet7", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragSelectSeveralChart  : " + ex.Message);
			}
		}
		
		public static void ValidateSelectedChartSegmentsClickExlude7()
		{
			try
			{
				
				CompressedImage chart = repo.VisualAnalytics.Worsheet7OverlayInfo.GetSelectExclude();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalytics.Worsheet7OverlayInfo;
				Validate.ContainsImage(info, chart, options, "Validate map", false);
				
				Reports.ReportLog("ValidateSelectedChartSegmentsClickExlude7", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateSelectedChartSegmentsClickExlude7  : " + ex.Message);
			}
		}
		
		public static void NavigatetoSheet8andSelectmultiple()
		{
			try
			{
				repo.TabPage.TabContainerInfo.WaitForItemExists(30000);
				repo.TabPage.TabContainer.SelectTab("Worksheet 8");
				
				if (repo.VisualAnalytics.ContainerCanvas_Worksheet8Info.Exists(10000))
				{
					repo.VisualAnalytics.ContainerCanvas_Worksheet8Info.WaitForItemExists(waittime);
					repo.VisualAnalytics.ContainerCanvas_Worksheet8.Click("135;100");
				}
								
				if (repo.SunAwtWindow.KeepOnly_newworksheetInfo.Exists(6000))
				{
					repo.SunAwtWindow.KeepOnly_newworksheetInfo.WaitForItemExists(waittime);
					repo.SunAwtWindow.KeepOnly_newworksheet.ClickThis();
				}
				
				
				Reports.ReportLog("NavigatetoSheet8andSelectmultiple", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : NavigatetoSheet8andSelectmultiple  : " + ex.Message);
			}
		}
		
		public static void ValidateControlClick()
		{
			try
			{
				
				CompressedImage chart = repo.VisualAnalytics.Pivotoverlayworksheet8Info.GetControlClick();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalytics.Pivotoverlayworksheet8Info;
				Validate.ContainsImage(info, chart, options, "Validate Exclusion", false);
				
				Reports.ReportLog("ValidateControlClick", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateControlClick  : " + ex.Message);
			}
		}
		
		public static void selectseveralchartKeeptooltip()
		{
			try
			{
				
				Keyboard.Press("{LControlKey down}");
				
				repo.VisualAnalytics.ContainerCanvas_Worksheet8.MoveTo("139;102");
				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
				
				repo.VisualAnalytics.ContainerCanvas_Worksheet8Info.WaitForItemExists(waittime);
				repo.VisualAnalytics.ContainerCanvas_Worksheet8.Click("134;86");
				
				Keyboard.Press("{LControlKey up}");
				
				repo.SunAwtWindow.KeepOnly_Worksheet8Info.WaitForItemExists(waittime);
				repo.SunAwtWindow.KeepOnly_Worksheet8.Click("43;12");

				Reports.ReportLog("selectseveralchartKeeptooltip", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : NavigatetoSheet8andSelectmultiple  : " + ex.Message);
			}
		}
		
		public static void ValidateseveralchartKeeptooltip()
		{
			try
			{
				
				CompressedImage chart = repo.VisualAnalytics.Pivotoverlayworksheet8Info.GetDragfewSelectTooltip();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalytics.Pivotoverlayworksheet8Info;
				Validate.ContainsImage(info, chart, options, "Validate Exclusion", false);
				
				Reports.ReportLog("ValidateseveralchartKeeptooltip", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateseveralchartKeeptooltip  : " + ex.Message);
			}
		}
		
		public static void NavigatetoSheet9()
		{
			try
			{   
				repo.TabPage.TabContainerInfo.WaitForItemExists(30000);
				repo.TabPage.TabContainer.SelectTab("Worksheet 9");
				Reports.ReportLog("NavigatetoSheet9", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : NavigatetoSheet9  : " + ex.Message);
			}
		}
		
		public static void SelectmultipleWorsheet9()
		{
			try
			{
				Keyboard.Press("{LControlKey down}");
				repo.VisualAnalytics.ContainerCanvas_Worksheet9Info.WaitForItemExists(waittime);
				repo.VisualAnalytics.ContainerCanvas_Worksheet9.Click("129;158");
				
				repo.VisualAnalytics.ContainerCanvas_Worksheet9Info.WaitForItemExists(waittime);
				repo.VisualAnalytics.ContainerCanvas_Worksheet9.Click("219;129");
				Keyboard.Press("{LControlKey up}");
				
				Reports.ReportLog("SelectmultipleWorsheet9", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectmultipleWorsheet9  : " + ex.Message);
			}
		}
		
		public static void DragAndSelectExcludeTooltip()
		{
			try
			{
				Keyboard.Press("{LControlKey down}");
				repo.SunAwtWindow.Exclude_Worksheet9Info.WaitForItemExists(waittime);
				repo.SunAwtWindow.Exclude_Worksheet9.Click("26;10");
				Keyboard.Press("{LControlKey up}");
				
				if (repo.VisualAnalytics.Worsheet8.OfficeSuppliesIdahoInfo.Exists(8000))
				{
					repo.VisualAnalytics.ExclusionListItemInfo.WaitForItemExists(30000);
					repo.VisualAnalytics.Worsheet8.OfficeSuppliesIdaho.EnsureVisible();
					repo.VisualAnalytics.Worsheet8.OfficeSuppliesIdaho.ClickThis();
				}
				
				Reports.ReportLog("DragAndSelectExcludeTooltip", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragAndSelectExcludeTooltip  : " + ex.Message);
			}
		}		
			
		public static void CloseVAWindow()
		{
			try
			{
				if(repo.DataStudio.CloseInfo.Exists(5000))
				{
					repo.DataStudio.Close.ClickThis();
					Reports.ReportLog("CloseVAWindow", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
				DiscardButton();
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CloseVAWindow : " + ex.Message);
			}
		}
		
		public static void DiscardButton()
		{
			try
			{
				if(repo.SaveChanges.DiscardInfo.Exists(new Duration(5000)))
				{
					repo.SaveChanges.Discard.ClickThis();
					Reports.ReportLog("DiscardButton", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
					repo.VAWindow.CloseInfo.WaitForNotExists(Common.ApplicationOpenWaitTime);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DiscardButton : " + ex.Message);
			}
		}
	}
	
}