using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

using WinForms = System.Windows.Forms;
using ADSAutomationPhaseII.Base;
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Configuration;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Preconditions;
using ADSAutomationPhaseII.TC_10610;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Repository;
using Ranorex.Core.Testing;

namespace ADSAutomationPhaseII.TC_10610
{
	public class Steps
	{
		public static TC_10610Repo repo = TC_10610Repo.Instance;
		public static string TC_10610_Path = System.Configuration.ConfigurationManager.AppSettings["TC_10610_Path"].ToString();
		
		public static void ExplicitWait()
		{
			System.Threading.Thread.Sleep(3000);
		}
		
		public static void ClickOnFileAndOpenMenus()
		{
			try
			{
				repo.AquaDataStudio.FileMenuInfo.WaitForItemExists(20000);
				if(repo.AquaDataStudio.FileMenuInfo.Exists()){
					repo.AquaDataStudio.FileMenu.ClickThis();
					Reports.ReportLog("ClickOnFileAndOpenMenus", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
					if(repo.SubMenuItems.OpenInfo.Exists()){
						repo.SubMenuItems.Open.ClickThis();
						Reports.ReportLog("ClickOnFileAndOpenMenus", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
					}else{
						repo.AquaDataStudio.FileMenu.ClickThis();
						if(repo.SubMenuItems.OpenInfo.Exists()){
							repo.SubMenuItems.Open.ClickThis();
							Reports.ReportLog("ClickOnFileAndOpenMenus", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
						}else{
							throw new Exception("Failed : ClickOnFileAndOpenMenus - 'Open' Sub Menu not Found ");
						}
					}
				}else{
					throw new Exception("Failed : ClickOnFileAndOpenMenus - 'File' Sub Menu not Found ");
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnFileAndOpenMenus : " + ex.Message);
			}
		}
		
		public static void EnterFilePathAndClickOpenButton()
		{
			try
			{
				repo.Open.OpenTextInfo.WaitForItemExists(20000);
				repo.Open.OpenText.TextBoxText(TC_10610_Path + "test-combo.vizx");
				repo.Open.OpenButton.ClickThis();
				Reports.ReportLog("EnterFilePathAndClickOpenButton", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : EnterFilePathAndClickOpenButton :" + ex.Message);
			}
		}
		
		public static void MaximizeVisualAnalyticsWindow()
		{
			try
			{
				Thread.Sleep(16000);
				repo.VisualAnalyticsDailog.SelfInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsDailog.Self.Maximize();
				Reports.ReportLog("MaximizeVisualAnalyticsWindow", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : MaximizeVisualAnalyticsWindow" +ex.Message);
			}
		}
		
		public static void SelectEntireWindow()
		{
			try
			{
				repo.VisualAnalyticsDailog.StdViewInfo.WaitForItemExists(20000);
				repo.VisualAnalyticsDailog.StdView.Click();
				if(!repo.SubMenuItems.EntireViewInfo.Exists(100000))
				{
					repo.VisualAnalyticsDailog.StdViewInfo.WaitForItemExists(20000);
					repo.VisualAnalyticsDailog.StdView.Click();
				}
				repo.SubMenuItems.EntireViewInfo.WaitForItemExists(10000);
				repo.SubMenuItems.EntireView.ClickThis();
				Reports.ReportLog("SelectEntireWindow", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectEntireWindow : " + ex.Message);
			}
		}
		public static void DragOrderdateToColumnsDeck()
		{
			try
			{
				repo.VisualAnalyticsDailog.OrderDateInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsDailog.OrderDate.ClickThis();
				repo.VisualAnalyticsDailog.OrderDate.RightClickThis();
				if(!repo.SubMenuItems.AddToColumnsDeckInfo.Exists(30000))
				{
					repo.VisualAnalyticsDailog.OrderDateInfo.WaitForItemExists(30000);
					repo.VisualAnalyticsDailog.OrderDate.ClickThis();
					repo.VisualAnalyticsDailog.OrderDate.RightClickThis();
				}
				repo.SubMenuItems.AddToColumnsDeckInfo.WaitForItemExists(30000);
				repo.SubMenuItems.AddToColumnsDeck.ClickThis();
				Reports.ReportLog("DragOrderdateToColumnsDeck", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragOrderdateToColumnsDeck" +ex.Message);
			}
		}
		
		public static void DragProfitToRowsDeck()
		{
			try
			{
				repo.VisualAnalyticsDailog.ProfitInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsDailog.Profit.RightClickThis();
				repo.SubMenuItems.AddToRowsDeckInfo.WaitForItemExists(30000);
				repo.SubMenuItems.AddToRowsDeck.ClickThis();
				Reports.ReportLog("DragProfitToRowsDeck", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("DragProfitToRowsDeck" +ex.Message);
			}
		}
		
		public static void DragSalesToRowsDeck()
		{
			try
			{
				ExplicitWait();
				repo.VisualAnalyticsDailog.ContainerLeftPanel.SUMSalesInfo.WaitForItemExists(10000);
				repo.VisualAnalyticsDailog.ContainerLeftPanel.SUMSales.ClickThis();
				repo.VisualAnalyticsDailog.ContainerLeftPanel.SUMSales.RightClickThis();
				repo.SubMenuItems.AddToRowsDeckInfo.WaitForItemExists(10000);
				repo.SubMenuItems.AddToRowsDeck.ClickThis();
				Reports.ReportLog("DragSalesToRowsDeck", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("DragSalesToRowsDeck" +ex.Message);
			}
		}
		
		public static void DragUnitPriceToRowsDeck()
		{
			try
			{
				repo.VisualAnalyticsDailog.ContainerLeftPanel.SUMUnitPriceInfo.WaitForItemExists(20000);
				repo.VisualAnalyticsDailog.ContainerLeftPanel.SUMUnitPrice.ClickThis();
				repo.VisualAnalyticsDailog.ContainerLeftPanel.SUMUnitPrice.RightClickThis();
				repo.SubMenuItems.AddToRowsDeckInfo.WaitForItemExists(10000);
				repo.SubMenuItems.AddToRowsDeck.ClickThis();
				Reports.ReportLog("DragUnitPriceToRowsDeck", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("DragUnitPriceToRowsDeck" +ex.Message);
			}
		}
		
		public static void SelectBarChartTypeProfitRowsDeck()
		{
			try{
				repo.VisualAnalyticsDailog.DeckItems.SUMProfitInfo.WaitForItemExists(10000);
				repo.VisualAnalyticsDailog.DeckItems.SUMProfit.RightClick();
				repo.SubMenuItems.ChartTypeInfo.WaitForItemExists(10000);
				repo.SubMenuItems.ChartType.ClickThis();
				repo.SubMenuItems.MenuItemBarInfo.WaitForItemExists(10000);
				repo.SubMenuItems.MenuItemBar.ClickThis();				
				Reports.ReportLog("SelectBarChartTypeProfitRowsDeck", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("SelectBarChartTypeProfitRowsDeck" +ex.Message);
			}
		}
		
		public static void SelectShapeChartTypeSalesRowsDeck()
		{
			try
			{
				repo.VisualAnalyticsDailog.DeckItems.SUMSalesInfo.WaitForItemExists(10000);
				repo.VisualAnalyticsDailog.DeckItems.SUMSales.RightClick();
				repo.SubMenuItems.ChartTypeInfo.WaitForItemExists(10000);
				repo.SubMenuItems.ChartType.ClickThis();
				repo.SubMenuItems.ShapeInfo.WaitForItemExists(10000);
				repo.SubMenuItems.Shape.ClickThis();				
				Reports.ReportLog("SelectShapeChartTypeSalesRowsDeck", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("SelectShapeChartTypeSalesRowsDeck" +ex.Message);
			}
		}
		
		public static void SelectLineChartTypeUnitPriceRowsDeck()
		{
		   try
		      {
				repo.VisualAnalyticsDailog.DeckItems.SUMUnitPriceInfo.WaitForItemExists(10000);
				repo.VisualAnalyticsDailog.DeckItems.SUMUnitPrice.RightClick();
				repo.SubMenuItems.ChartTypeInfo.WaitForItemExists(10000);
				repo.SubMenuItems.ChartType.ClickThis();
				repo.SubMenuItems.LineInfo.WaitForItemExists(10000);
				
				repo.SubMenuItems.Line.ClickThis();				
				Reports.ReportLog("SelectLineChartTypeUnitPriceRowsDeck", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			   }
			catch (Exception ex)
			{
				throw new Exception("SelectLineChartTypeUnitPriceRowsDeck" +ex.Message);
			}
		}
		
		public static void CloseVisualAnalyticsDailog()
		{
			try
			{				
				if(repo.VisualAnalyticsDailog.SelfInfo.Exists(new Duration(5000)))
				{
					repo.VisualAnalyticsDailog.Self.Close();
					Reports.ReportLog("CloseVisualAnalyticsDailog", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				if(repo.SaveChanges.DiscardButtonInfo.Exists(new Duration(2000)))
				{	
					repo.SaveChanges.DiscardButton.ClickThis();
				}else{
					repo.VisualAnalyticsDailog.Self.Close();
					repo.SaveChanges.DiscardButtonInfo.WaitForItemExists(30000);
					repo.SaveChanges.DiscardButton.ClickThis();
				}				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CloseVisualAnalyticsDailog" +ex.Message);
			}
		}
		
		public static void ValidateChart1_11()
		{
			try
			{
				CompressedImage VAFiltering = repo.VisualAnalyticsDailog.ContainerCanvas1Info.GetBarLineShape();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.50f;
				RepoItemInfo info = repo.VisualAnalyticsDailog.ContainerCanvas1Info;
				Validate.ContainsImage(info, VAFiltering, options, "BarLineShape", false);

			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateChart1_11" +ex.Message);
			}
		}
		
		public static void ClickSortIconSUMAxis()
		{
			try
			{
				repo.VisualAnalyticsDailog.ContainerCanvas1.MoveTo("20;450");  //DeckItems.BIChartOverlayPanel2
				repo.VisualAnalyticsDailog.ContainerCanvas1.Click("13;426");
				Reports.ReportLog("ClickSortIconSUMAxis", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickSortIconSUMAxis" +ex.Message);
			}
		}
		
		public static void ValidateSortIconSUMAxis()
		{
			try
			{
				CompressedImage VAFiltering = repo.VisualAnalyticsDailog.ContainerCanvas1Info.GetSortIconSUMAxis();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalyticsDailog.ContainerCanvas1Info;
				Validate.ContainsImage(info, VAFiltering, options, "ValidateChart1_11", false);
				Reports.ReportLog("ValidateSortIconSUMAxis", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateSortIconSUMAxis" +ex.Message);
			}
		}
		
		public static void ClickOnUndoButton()
		{
			try
			{
				repo.VisualAnalyticsDailog.UndoButtonInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsDailog.UndoButton.ClickThis();
				Reports.ReportLog("ClickOnUndoButton", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnUndoButton" +ex.Message);
			}
		}
		
		public static void ValidateUndoButtSortIconSUMAxis()
		{
			try
			{
				CompressedImage VAFiltering = repo.VisualAnalyticsDailog.ContainerCanvas1Info.GetUndoButt();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalyticsDailog.ContainerCanvas1Info;
				Validate.ContainsImage(info, VAFiltering, options, "ValidateChart1_11", false);
				
				Reports.ReportLog("ValidateUndoButtSortIconSUMAxis", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateUndoButtSortIconSUMAxis" +ex.Message);
			}
		}
		
		public static void ClickTwoBars()
		{
			try
			{
				repo.VisualAnalyticsDailog.DeckItems.BIChartOverlayPanel2.PressKeys("{LControlKey down}");
				repo.VisualAnalyticsDailog.DeckItems.BIChartOverlayPanel2.Click("169;151");
				repo.VisualAnalyticsDailog.ContainerCanvas1.Click("248;143");
				Keyboard.Press("{LControlKey up}");
				Reports.ReportLog("ClickSortIconSUMAxis", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickSortIconSUMAxis" +ex.Message);
			}
		}
		
		
		public static void ValidateTwoBarselected()
		{
			try
			{
				CompressedImage VAFiltering = repo.VisualAnalyticsDailog.ContainerCanvas1Info.GetTwoBarLineSlection();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.50f;
				RepoItemInfo info = repo.VisualAnalyticsDailog.ContainerCanvas1Info;
				Validate.ContainsImage(info, VAFiltering, options, "TwoBarLineSlection", false);
				
				Reports.ReportLog("ValidateTwoBarselected", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateTwoBarselected" +ex.Message);
			}
		}
		
		public static void ClickOnBlankPart()
		{
			try
			{
				repo.VisualAnalyticsDailog.DeckItems.Panel.ClickThis();
				Reports.ReportLog("ClickOnBlankPart", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnBlankPart" +ex.Message);
			}
		}
		
		public static void ClickOnAxesAndMergedAxesSharedScale()
		{
			try
			{
				repo.VisualAnalyticsDailog.DeckItems.Axes.ClickThis();
				repo.Datastudio.MergedAxesSharedScaleInfo.WaitForItemExists(30000);
				repo.Datastudio.MergedAxesSharedScale.ClickThis();
				Thread.Sleep(1000);
				Keyboard.Press("{ESCAPE}");
				Reports.ReportLog("ClickOnAxesAndMergedAxesSharedScale", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnAxesAndMergedAxesSharedScale" +ex.Message);
			}
		}
		
		public static void ValidateAxesAndMergedAxesSharedScale()
		{
			try
			{
				CompressedImage VAFiltering = repo.VisualAnalyticsDailog.ContainerCanvas1Info.GetAxesAndMergedAxesSharedScale();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalyticsDailog.ContainerCanvas1Info;
				Validate.ContainsImage(info, VAFiltering, options, "AxesAndMergedAxesSharedScale", false);
				
				Reports.ReportLog("ValidateAxesAndMergedAxesSharedScale", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAxesAndMergedAxesSharedScale" +ex.Message);
			}
		}
		
		
		public static void SelectTwoCircles()
		{
			try
			{
				Keyboard.Press("{LControlKey down}");
				repo.VisualAnalyticsDailog.DeckItems.BIChartOverlayPanel2.MoveTo("184;225");
				repo.VisualAnalyticsDailog.DeckItems.BIChartOverlayPanel2.MoveTo("192;217");
				repo.VisualAnalyticsDailog.DeckItems.BIChartOverlayPanel2.Click("268;220");
				Keyboard.Press("{LControlKey up}");
				Reports.ReportLog("SelectTwoCircles", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectTwoCircles" +ex.Message);
			}
		}
		
		public static void ValidateTwoCirclesSelection()
		{
			try
			{
				CompressedImage VAFiltering = repo.VisualAnalyticsDailog.ContainerCanvas1Info.GetTwoCiclesSelection();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.50f;
				RepoItemInfo info = repo.VisualAnalyticsDailog.ContainerCanvas1Info;
				Validate.ContainsImage(info, VAFiltering, options, "TwoCiclesSelection", false);
				Reports.ReportLog("ValidateTwoCirclesSelection", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateTwoCirclesSelection" +ex.Message);
			}
		}
		
		public static void DragRegionToColorDeck()
		{
			try
			{
				ExplicitWait();
				repo.VisualAnalyticsDailog.ContainerLeftPanel.RegionInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsDailog.ContainerLeftPanel.Region.DragThisTo(repo.VisualAnalyticsDailog.DeckItems.ColorDeck);
				Reports.ReportLog("DragRegionToColorDeck", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragRegionToColorDeck" +ex.Message);
			}
		}
		
		public static void ValidateDragRegionToColorRegion()
		{
			try
			{
				CompressedImage VAFiltering = repo.VisualAnalyticsDailog.ContainerCanvas1Info.GetDragRegionToColorDeck();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.50f;
				RepoItemInfo info = repo.VisualAnalyticsDailog.ContainerCanvas1Info;
				Validate.ContainsImage(info, VAFiltering, options, "TwoCiclesSelection", false);
				
				Reports.ReportLog("DragRegionToColorDeck", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragRegionToColorDeck" +ex.Message);
			}
		}
		
		public static void ClickOnEast()
		{
			try
			{
				repo.VisualAnalyticsDailog.DeckItems.EastInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsDailog.DeckItems.East.ClickThis();
				Reports.ReportLog("ClickOnEast", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnEast" +ex.Message);
			}
		}
		
		public static void ValidateAfterClickOnEast()
		{
			try
			{
				CompressedImage VAFiltering = repo.VisualAnalyticsDailog.ContainerCanvas1Info.GetEastClcik();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalyticsDailog.ContainerCanvas1Info;
				Validate.ContainsImage(info, VAFiltering, options, "EastClcik", false);
				
				Reports.ReportLog("ValidateAfterClickOnEast", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterClickOnEast" +ex.Message);
			}
		}
		
		public static void ClickOnColorDeckAndEditColors()
		{
			try
			{
				repo.VisualAnalyticsDailog.DeckItems.ColorDeckInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsDailog.DeckItems.ColorDeck.ClickThis();
				repo.Datastudio.EditColorsInfo.WaitForItemExists(30000);
				repo.Datastudio.EditColors.ClickThis();
				Reports.ReportLog("ClickOnColorDeckAndEditColors", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnColorDeckAndEditColors" +ex.Message);
			}
		}
		
		public static void SelectMetroTheme()
		{
			try
			{
				repo.EditColorsRegion.SelectThemeInfo.WaitForItemExists(30000);
				repo.EditColorsRegion.SelectTheme.ClickThis();
				repo.SubMenuItems.MetroThemeInfo.WaitForItemExists(30000);
				repo.SubMenuItems.MetroTheme.ClickThis();
				Reports.ReportLog("SelectMetroTheme", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectMetroTheme" +ex.Message);
			}
		}
		
		public static void ClickOnAssignPalette()
		{
			try
			{
				repo.EditColorsRegion.AssignPalette.ClickThis();
				Reports.ReportLog("ClickOnAssignPalette", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnAssignPalette" +ex.Message);
			}
		}
		
		public static void ClickOnSaveButtonEditColorsRegion()
		{
			try
			{
				repo.EditColorsRegion.ButtonOK.ClickThis();
				Reports.ReportLog("ClickOnSaveButtonEditColorsRegion", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnSaveButtonEditColorsRegion" +ex.Message);
			}
		}
		
		public static void ValidateEditTheme()
		{
			try
			{
				CompressedImage VAFiltering = repo.VisualAnalyticsDailog.ContainerCanvas1Info.GetEditTheme();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalyticsDailog.ContainerCanvas1Info;
				Validate.ContainsImage(info, VAFiltering, options, "EditTheme", false);
				
				Reports.ReportLog("ValidateEditTheme", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateEditTheme" +ex.Message);
			}
		}
		
		public static void ClickOnSUMSalesChartPropertiesPanel()
		{
			try
			{
				if(repo.VisualAnalyticsDailog.DeckItems.SUMSales1Info.Exists(5000))
				{
					repo.VisualAnalyticsDailog.DeckItems.SUMSales1.ClickThis();
				}				
				Reports.ReportLog("ClickOnSUMSalesChartPropertiesPanel", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnSUMSalesChartPropertiesPanel" +ex.Message);
			}
		}		
		
		
		public static void DragRegionToShapeDeck()
		{
			try
			{
				repo.VisualAnalyticsDailog.ContainerLeftPanel.RegionInfo.WaitForItemExists(10000);
				if(repo.VisualAnalyticsDailog.DeckItems.ShapeDeckInfo.Exists(3000))
				{
					repo.VisualAnalyticsDailog.ContainerLeftPanel.Region.DragThisTo(repo.VisualAnalyticsDailog.DeckItems.ShapeDeck);
				}
				Reports.ReportLog("DragRegionToShapeDeck", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragRegionToShapeDeck" +ex.Message);
			}
		}
		
		public static void ValidateAfterDragRegionToShapeDeck()
		{
			try
			{
				CompressedImage VAFiltering = repo.VisualAnalyticsDailog.ContainerCanvas1Info.GetAfterDragRegionToShapeDeck();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalyticsDailog.ContainerCanvas1Info;
				Validate.ContainsImage(info, VAFiltering, options, "AfterDragRegionToShapeDeck", false);
				Reports.ReportLog("ValidateAfterDragRegionToShapeDeck", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterDragRegionToShapeDeck" +ex.Message);
			}
		}
		
		public static void ClickOnSouthEntry()
		{
			try
			{
				repo.VisualAnalyticsDailog.DeckItems.SouthInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsDailog.DeckItems.South.ClickThis();
				Reports.ReportLog("ClickOnSouthEntry", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnSouthEntry" +ex.Message);
			}
		}
		
		public static void ValidateSouthEntry()
		{
			try
			{
				CompressedImage VAFiltering = repo.VisualAnalyticsDailog.ContainerCanvas1Info.GetSouthEntry();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalyticsDailog.ContainerCanvas1Info;
				Validate.ContainsImage(info, VAFiltering, options, "SouthEntry", false);
				Reports.ReportLog("ValidateSouthEntry", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateSouthEntry" +ex.Message);
			}
		}
		
		public static void ClickOnAll()
		{
			try
			{
				if(repo.VisualAnalyticsDailog.DeckItems.TabPageAllInfo.Exists(2000)){
					repo.VisualAnalyticsDailog.DeckItems.TabPageAll.ClickThis();
				}
				Reports.ReportLog("ClickOnAll", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnAll" +ex.Message);
			}
		}
		
		public static void ClickOnAxesAndSelectMergedAxesSeparateScale()
		{
			try
			{
				if(repo.VisualAnalyticsDailog.DeckItems.AxesInfo.Exists(2000))
				{
					repo.VisualAnalyticsDailog.DeckItems.AxesInfo.WaitForItemExists(30000);
					repo.VisualAnalyticsDailog.DeckItems.Axes.ClickThis();
					repo.Datastudio.MergedAxesSeparateScaleInfo.WaitForItemExists(30000);
					repo.Datastudio.MergedAxesSeparateScale.ClickThis();
					Keyboard.Press("{ESCAPE}");
				}				
				Reports.ReportLog("ClickOnAxesAndSelectMergedAxesSeparateScale", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnAxesAndSelectMergedAxesSeparateScale" +ex.Message);
			}
		}
		
		public static void ValidateSeparateScale()
		{
			try
			{
				CompressedImage VAFiltering = repo.VisualAnalyticsDailog.ContainerCanvas1Info.GetSeparateScale();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalyticsDailog.ContainerCanvas1Info;
				Validate.ContainsImage(info, VAFiltering, options, "SeparateScale", false);
				Reports.ReportLog("ValidateSeparateScale", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateSeparateScale" +ex.Message);
			}
		}
		
		public static void RightClickOnSUMProfit()
		{
			try
			{
				ExplicitWait();
				repo.VisualAnalyticsDailog.DeckItems.SUMProfitInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsDailog.DeckItems.SUMProfit.MoveTo();
				repo.VisualAnalyticsDailog.DeckItems.SUMProfit.RightClick();
				Reports.ReportLog("RightClickOnSUMProfit", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : RightClickOnSUMProfit" +ex.Message);
			}
		}
		
		public static void ClickOnFormat()
		{
			try
			{
				repo.SubMenuItems.FormatInfo.WaitForItemExists(30000);
				repo.SubMenuItems.Format.ClickThis();
				Reports.ReportLog("ClickOnFormat", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnFormat" +ex.Message);
			}
		}
		
		public static void ClickOnCurrencyStandardAndOK()
		{
			try
			{
				repo.NumberFormatProfit.CurrencyStandardInfo.WaitForItemExists(30000);
				repo.NumberFormatProfit.CurrencyStandard.ClickThis();
				repo.NumberFormatProfit.ButtonOK.ClickThis();
				Reports.ReportLog("ClickOnCurrencyStandardAndOK", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnCurrencyStandardAndOK" +ex.Message);
			}
		}
		
		public static void ValidateCurrencyStd()
		{
			try
			{
				CompressedImage VAFiltering = repo.VisualAnalyticsDailog.ContainerCanvas1Info.GetCurrencyStd();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalyticsDailog.ContainerCanvas1Info;
				Validate.ContainsImage(info, VAFiltering, options, "CurrencyStd", false);
				Reports.ReportLog("ValidateCurrencyStd", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateCurrencyStd" +ex.Message);
			}
		}
		
		public static void RightClickOnSUMSales()
		{
			try
			{
				repo.VisualAnalyticsDailog.DeckItems.SUMSalesInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsDailog.DeckItems.SUMSales.RightClick();
				Reports.ReportLog("RightClickOnSUMSales", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : RightClickOnSUMSales" +ex.Message);
			}
		}
		
		public static void ClickOnShowAxisAndRightOnly()
		{
			try
			{
				repo.SubMenuItems.ShowAxisInfo.WaitForItemExists(30000);
				repo.SubMenuItems.ShowAxis.ClickThis();
				repo.SubMenuItems.RightOnlyInfo.WaitForItemExists(30000);
				repo.SubMenuItems.RightOnly.ClickThis();
				Reports.ReportLog("RightClickOnSUMSales", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : RightClickOnSUMSales" +ex.Message);
			}
		}
		
		public static void ValidateRightOnly()
		{
			try
			{
				CompressedImage VAFiltering = repo.VisualAnalyticsDailog.ContainerCanvas1Info.GetRightOnly();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalyticsDailog.ContainerCanvas1Info;
				Validate.ContainsImage(info, VAFiltering, options, "RightOnly", false);
				Reports.ReportLog("ValidateRightOnly", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateRightOnly" +ex.Message);
			}
		}
		
		public static void ShowTrendLines()
		{
			try{
				repo.VisualAnalyticsDailog.AnalysisInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsDailog.Analysis.ClickThis();
				repo.SubMenuItems.TrendLines.ClickThis();
				if(repo.SubMenuItems.ShowTrendLines.Element.GetAttributeValue("checked").ToString().Trim().ToUpper() == "FALSE"){
					repo.SubMenuItems.ShowTrendLines.MoveTo();
					repo.SubMenuItems.ShowTrendLines.ClickThis();
				}				
				Reports.ReportLog("ShowTrendLines" , Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}catch (Exception ex)
			{
				throw new Exception("Failed : ShowTrendLines" +ex.Message);
			}
		}
		
		public static void ValidateShowTrendLine()
		{
			try
			{
				CompressedImage VAFiltering = repo.VisualAnalyticsDailog.ContainerCanvas1Info.GetShowTrendLines();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalyticsDailog.ContainerCanvas1Info;
				Validate.ContainsImage(info, VAFiltering, options, "ShowTrendLines", false);
				Reports.ReportLog("ValidateShowTrendLine", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateShowTrendLine" +ex.Message);
			}
		}
		
		public static void RightClickOnSUMSalesAxis()
		{
			try
			{
				repo.VisualAnalyticsDailog.ContainerCanvas1Info.WaitForItemExists(30000);
				repo.VisualAnalyticsDailog.ContainerCanvas1.MoveTo("902;321");
				repo.VisualAnalyticsDailog.ContainerCanvas1.Click(System.Windows.Forms.MouseButtons.Right, "902;321");				
				Reports.ReportLog("RightClickOnSUMSalesAxis" , Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}catch (Exception ex)
			{
				throw new Exception("Failed : RightClickOnSUMSalesAxis" +ex.Message);
			}
		}
		
		public static void ClickOnEditAxisAndSetTitle(string strTitle)
		{
			try{
				if(repo.SubMenuItems.EditAxisInfo.Exists(20000)){
					repo.SubMenuItems.EditAxis.ClickThis();
					repo.EditAxisSUMSales.TitleTxtInfo.WaitForItemExists(30000);
					repo.EditAxisSUMSales.TitleTxt.TextBoxText(strTitle);
					repo.EditAxisSUMSales.ButtonOKInfo.WaitForItemExists(30000);
					repo.EditAxisSUMSales.ButtonOK.ClickThis();
				}
				Reports.ReportLog("ClickOnEditAxisAndSetTitle" , Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnEditAxisAndSetTitle" +ex.Message);
			}
		}
		
		public static void ValidateRenameToAnnualSales()
		{
			try
			{
				CompressedImage VAFiltering = repo.VisualAnalyticsDailog.ContainerCanvas1Info.GetAnnualSalestitle();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalyticsDailog.ContainerCanvas1Info;
				Validate.ContainsImage(info, VAFiltering, options, "AnnualSalestitle", false);
				Reports.ReportLog("ValidateRenameToAnnualSales", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateRenameToAnnualSales" +ex.Message);
			}
		}
		
		public static void VerifyToolTipExists()
		{
			try
			{
				repo.VisualAnalyticsDailog.DeckItems.BIChartOverlayPanel2.MoveTo("418;265");
				if(repo.SubMenuItems.ViewDataInfo.Exists(30000)){
					Report.Success("Tooltip is displayed after mouse hover over a highlighted chart segment");
				}else{
					Report.Success("Tooltip is not displayed after mouse hover over a highlighted chart segment");
				}
				Reports.ReportLog("VerifyToolTipExists" , Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : VerifyToolTipExists" +ex.Message);
			}
		}
		
		
	}
    
}
