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

namespace ADSAutomationPhaseII.TC_10608
{
	public class Steps
	{
		public static TC10589 TC10589Repo = TC10589.Instance;
		public static TC10608 repo = TC10608.Instance;
		public static string TC_10608_PATH = System.Configuration.ConfigurationManager.AppSettings["TC_10608_Path"].ToString();
		
		public static void EnterFilePath()
		{
			try
			{
				TC10589Repo.Open.OpenTextInfo.WaitForItemExists(30000);
				TC10589Repo.Open.OpenText.TextBoxText(TC_10608_PATH + "test-undo.vizx");
				Reports.ReportLog("EnterFilePath", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : EnterFilePath" + ex.Message);
			}
		}
		
		public static void DragProfitToRowPanel()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.Profit.EnsureVisible();
				repo.VisualAnalyticsTestUndo.ProfitInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.Profit.MoveTo("67;9");
				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
				Delay.Milliseconds(200);
				
				repo.VisualAnalyticsTestUndo.Profit.MoveTo("75;1");
				Delay.Milliseconds(200);
				
				repo.VisualAnalyticsTestUndo.RowPanel.MoveTo("249;6");
				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				Reports.ReportLog("DragProfitToRowPanel", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragProfitToRowPanel" + ex.Message);
			}
		}
		
		public static void SelectAverage()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.SUMProfitInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.SUMProfit.RightClickThis();
				repo.SunAwtWindow.MeasureInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.Measure.ClickThis();
				if(repo.SunAwtWindow1.AverageInfo.Exists(5000))
				{
					repo.SunAwtWindow1.Average.ClickThis();
					Reports.ReportLog("Average selected", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Select Average failed", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectAverage" + ex.Message);
			}
		}
		
		public static void SelectAreaChartType()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.AvgProfitInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.AvgProfit.RightClickThis();
				repo.SunAwtWindow.ChartTypeInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.ChartType.ClickThis();
				repo.SunAwtWindow1.AreaChartInfo.WaitForItemExists(30000);
				repo.SunAwtWindow1.AreaChart.ClickThis();
				Reports.ReportLog("SelectAreaChartType", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectAreaChartType" + ex.Message);
			}
		}
		
		public static void ClickUndo()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.UndoButtonInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.UndoButton.ClickThis();
				Reports.ReportLog("ClickUndo", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickUndo" + ex.Message);
			}
		}
		
		public static void ValidateRevertToAvgProfit()
		{
			try
			{
				if(repo.VisualAnalyticsTestUndo.AvgProfitChartInfo.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestUndo.AvgProfitChartInfo.GetAvgProfit();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestUndo.AvgProfitChartInfo;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateRevertToAvgProfit data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateRevertToAvgProfit", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateRevertToAvgProfit :" +ex.Message);
			}
		}
		
		public static void ValidateRevertToSUMProfit()
		{
			try
			{
				if(repo.VisualAnalyticsTestUndo.SumProfitChartInfo.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestUndo.SumProfitChartInfo.GetSUMProfit();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestUndo.SumProfitChartInfo;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateRevertToSUMProfit data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateRevertToSUMProfit", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateRevertToSUMProfit :" +ex.Message);
			}
		}
		
		public static void ValidateRevertToNoProfitInRowPanel()
		{
			try
			{
				if(repo.VisualAnalyticsTestUndo.DefaultChartInfo.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestUndo.DefaultChartInfo.GetDefaultChart();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestUndo.DefaultChartInfo;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateRevertToNoProfitInRowPanel data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateRevertToNoProfitInRowPanel", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateRevertToNoProfitInRowPanel :" +ex.Message);
			}
		}
		
		public static void ValidateRevertToSUMProfitRedo()
		{
			try
			{
				if(repo.VisualAnalyticsTestUndo.SUMProfitChartRedoInfo.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestUndo.SUMProfitChartRedoInfo.GetSUMProfitChart();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestUndo.SUMProfitChartRedoInfo;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateRevertToSUMProfitRedo data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateRevertToSUMProfitRedo", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateRevertToSUMProfitRedo :" +ex.Message);
			}
		}
		
		public static void ValidateRevertToAvgProfitRedo()
		{
			try
			{
				if(repo.VisualAnalyticsTestUndo.AvgProfitChartRedoInfo.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestUndo.AvgProfitChartRedoInfo.GetAvgProfitChart();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestUndo.AvgProfitChartRedoInfo;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateRevertToAvgProfitRedo data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateRevertToAvgProfitRedo", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateRevertToAvgProfitRedo :" +ex.Message);
			}
		}
		
		public static void ClickRedo()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.RedoButtonInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.RedoButton.ClickThis();
				Reports.ReportLog("ClickRedo", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickRedo" + ex.Message);
			}
		}
		
		public static void ValidateRevertToAreaChart()
		{
			try
			{
				if(repo.VisualAnalyticsTestUndo.AreaChartInfo.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestUndo.AreaChartInfo.GetAreaChart();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestUndo.AreaChartInfo;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateRevertToAreaChart data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateRevertToAreaChart", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateRevertToAreaChart :" +ex.Message);
			}
		}
		
		public static void SelectDualAxes()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.AxesButtonInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.AxesButton.ClickThis();
				
				if(repo.Datastudio.DualAxesInfo.Exists(30000))
				{
					repo.Datastudio.DualAxes.ClickThis();
					Reports.ReportLog("SelectDualAxes", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("SelectDualAxes", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectDualAxes" + ex.Message);
			}
		}
		
		public static void ValidateDualAxesChart()
		{
			try
			{
				if(repo.VisualAnalyticsTestUndo.DualAxesChartInfo.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestUndo.DualAxesChartInfo.GetDualAxes();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestUndo.DualAxesChartInfo;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateDualAxesChart data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateDualAxesChart", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateDualAxesChart :" +ex.Message);
			}
		}
		
		public static void DeleteWorksheet1()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.Worksheet1Info.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.Worksheet1.RightClickThis();
				repo.SunAwtWindow.DeleteInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.Delete.ClickThis();
				Reports.ReportLog("DeleteWorksheet1", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DeleteWorksheet1" + ex.Message);
			}
		}
		
		public static void ValidateWorksheet2()
		{
			try
			{
				if(repo.VisualAnalyticsTestUndo.Worksheet2Info.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestUndo.Worksheet2Info.GetWorksheet2();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestUndo.Worksheet2Info;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateWorksheet2 data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateWorksheet2", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateWorksheet2 :" +ex.Message);
			}
		}
		
		public static void RemoveAvgProfit()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.AvgProfitInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.AvgProfit.RightClickThis();
				repo.SunAwtWindow.RemoveInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.Remove.ClickThis();
				
				Reports.ReportLog("RemoveAvgProfit", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				
				throw new Exception("RemoveAvgProfit :" +ex.Message);
			}
		}
		
		public static void DragRegionsToColors()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.Region.MoveTo("34;9");
				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
				Delay.Milliseconds(200);
				
				repo.VisualAnalyticsTestUndo.Region.MoveTo("42;1");
				Delay.Milliseconds(200);
				
				repo.VisualAnalyticsTestUndo.Color.MoveTo("21;28");
				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				Delay.Milliseconds(200);
				
				Reports.ReportLog("DragRegionsToColors", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				
				throw new Exception("DragRegionsToColors :" +ex.Message);
			}
		}
		
		public static void ClickOnAvgAccordion()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.StackTabbedPaneInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.StackTabbedPane.Click("80;234");
				
				Reports.ReportLog("ClickOnAvgAccordion", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				
				throw new Exception("ClickOnAvgAccordion :" +ex.Message);
			}
		}
		
		public static void DragDiscountToColors()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.SUMDiscountInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.SUMDiscount.MoveTo("66;7");
				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
				Delay.Milliseconds(200);
				
				repo.VisualAnalyticsTestUndo.SUMDiscount.MoveTo("74;-1");
				Delay.Milliseconds(200);
				
				repo.VisualAnalyticsTestUndo.Color1.MoveTo("11;26");
				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				Delay.Milliseconds(200);
				
				Reports.ReportLog("DragDiscountToColors", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				
				throw new Exception("DragDiscountToColors :" +ex.Message);
			}
		}
		
		public static void SortSUMSales()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.BIChartOverlayPanelSUMSalesInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.BIChartOverlayPanelSUMSales.Click("15;41");
				Reports.ReportLog("SortSUMSales", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				
				throw new Exception("SortSUMSales :" +ex.Message);
			}
		}
		
		public static void SortProfit()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.BIChartOverlayPanelAvgProfitInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.BIChartOverlayPanelAvgProfit.Click("11;194");
				Reports.ReportLog("SortProfit", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				
				throw new Exception("SortProfit :" +ex.Message);
			}
		}
		
		public static void NavigateToWorksheet2()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.WorksheetTab2Info.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.WorksheetTab2.ClickThis();
				Reports.ReportLog("NavigateToWorksheet2", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : NavigateToWorksheet2" + ex.Message);
			}
		}
		
		public static void SortEast()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.EastBIChartOverlayPanelInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.EastBIChartOverlayPanel.Click("78;158");
				Reports.ReportLog("SortEast", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SortEast" + ex.Message);
			}
		}
		
		public static void KeepOnly()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.EastBIChartOverlayPanelInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.EastBIChartOverlayPanel.Click("49;191");
				System.Threading.Thread.Sleep(1000);
				repo.SunAwtWindow.KeepOnlyInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.KeepOnly.ClickThis();
				Reports.ReportLog("KeepOnly", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : KeepOnly" + ex.Message);
			}
		}
		
		public static void RemoveRegion()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.RegionFilterInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.RegionFilter.RightClickThis();
				repo.SunAwtWindow.RemoveInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.Remove.ClickThis();
				Reports.ReportLog("RemoveRegion", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : RemoveRegion" + ex.Message);
			}
		}
		
		public static void RemoveProductCategory()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.ProductCategoryWorsheet2Info.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.ProductCategoryWorsheet2.RightClickThis();
				repo.SunAwtWindow.RemoveInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.Remove.ClickThis();
				Reports.ReportLog("RemoveProductCategory", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : RemoveProductCategory" + ex.Message);
			}
		}
		
		public static void RemoveRegionFromColumn()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.RegionWorksheet2Info.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.RegionWorksheet2.RightClickThis();
				repo.SunAwtWindow.RemoveInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.Remove.ClickThis();
				Reports.ReportLog("RemoveRegionFromColumn", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : RemoveRegionFromColumn" + ex.Message);
			}
		}
		
		public static void SelectShapeChart()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.MarkChartTypeSelectorDollar1Info.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.MarkChartTypeSelectorDollar1.ClickThis();
				repo.SunAwtWindow.ShapeInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.Shape.ClickThis();
				Reports.ReportLog("SelectShapeChart", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectShapeChart" + ex.Message);
			}
		}
		
		public static void DragStateOrProvinceToGeo()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.StateOrProvinceInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.StateOrProvince.MoveTo("62;9");
				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
				Delay.Milliseconds(200);
				
				repo.VisualAnalyticsTestUndo.StateOrProvince.MoveTo("70;1");
				Delay.Milliseconds(200);
				
				repo.VisualAnalyticsTestUndo.TextGeo.MoveTo("23;19");
				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				Reports.ReportLog("DragStateOrProvinceToGeo", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragStateOrProvinceToGeo" + ex.Message);
			}
		}
		
		public static void SelectSolidCircle()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.ShapeButtonInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.ShapeButton.ClickThis();
				repo.Datastudio.SolidCircleInfo.WaitForItemExists(30000);
				repo.Datastudio.SolidCircle.ClickThis();
				Reports.ReportLog("SelectSolidCircle", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectSolidCircle" + ex.Message);
			}
		}
		
		public static void SlideTo50Percent()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.Size.Click("12;28");
				Delay.Milliseconds(200);
				
				repo.Datastudio.JSlider.MoveTo("27;14");
				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
				Delay.Milliseconds(200);
				
				repo.Datastudio.JSlider.MoveTo("100;13");
				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				Delay.Milliseconds(200);
				
				Reports.ReportLog("SlideTo50Percent", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SlideTo50Percent" + ex.Message);
			}
		}
		
		public static void UnCheckShowStateBorders()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.TextGeoInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.TextGeo.ClickThis();
				repo.Datastudio.ShowStateBordersInfo.WaitForItemExists(30000);
				repo.Datastudio.ShowStateBorders.ClickThis();
				Reports.ReportLog("UnCheckShowStateBorders", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : UnCheckShowStateBorders" + ex.Message);
			}
		}
		
		public static void ClickOnColors()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.Worksheet2ColorsInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.Worksheet2Colors.ClickThis();
				Reports.ReportLog("ClickOnColors", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnColors" + ex.Message);
			}
		}
		
		public static void SelectColor()
		{
			try
			{
				ClickOnColors();
				repo.Datastudio.GreenColorInfo.WaitForItemExists(30000);
				repo.Datastudio.GreenColor.ClickThis();
				Reports.ReportLog("SelectColor", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectColor" + ex.Message);
			}
		}
		
		public static void SelectBorder()
		{
			try
			{
				ClickOnColors();
				repo.Datastudio.BorderComboboxInfo.WaitForItemExists(30000);
				repo.Datastudio.BorderCombobox.ClickThis();
				repo.SunAwtWindow.RedColorBorderInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.RedColorBorder.ClickThis();
				Reports.ReportLog("SelectBorder", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectBorder" + ex.Message);
			}
		}
		
		public static void SelectHalo()
		{
			try
			{
				ClickOnColors();
				repo.Datastudio.HaloComboboxInfo.WaitForItemExists(30000);
				repo.Datastudio.HaloCombobox.ClickThis();
				repo.SunAwtWindow.YellowColorHaloInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.YellowColorHalo.ClickThis();
				Reports.ReportLog("SelectHalo", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectHalo" + ex.Message);
			}
		}
		
		public static void SetOpacityTo70Percent()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.Worksheet2ColorsInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.Worksheet2Colors.ClickThis();
				repo.Datastudio.TextFieldInfo.WaitForItemExists(30000);
				repo.Datastudio.TextField.ClickThis();
				repo.Datastudio.TextFieldInfo.WaitForItemExists(30000);
				repo.Datastudio.TextField.TextBoxText("70");
				Reports.ReportLog("SetOpacityTo70Percent", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SetOpacityTo70Percent" + ex.Message);
			}
		}
		
		public static void ClickOnLabel()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.LabelButtonInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.LabelButton.ClickThis();
				Reports.ReportLog("ClickOnLabel", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnLabel" + ex.Message);
			}
		}
		
		public static void SelectShowDataLabels()
		{
			try
			{
				ClickOnLabel();
				repo.Datastudio.ShowDataLabelsInfo.WaitForItemExists(30000);
				repo.Datastudio.ShowDataLabels.ClickThis();
				Reports.ReportLog("SelectShowDataLabels", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectShowDataLabels" + ex.Message);
			}
		}
		
		public static void SelectAllowOverlap()
		{
			try
			{
				ClickOnLabel();
				repo.Datastudio.AllowOverlapInfo.WaitForItemExists(30000);
				repo.Datastudio.AllowOverlap.ClickThis();
				Reports.ReportLog("SelectAllowOverlap", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectAllowOverlap" + ex.Message);
			}
		}
		
		public static void NavigateToWorksheet3()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.Worksheet3TabInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.Worksheet3Tab.ClickThis();
				Reports.ReportLog("NavigateToWorksheet3", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : NavigateToWorksheet3" + ex.Message);
			}
		}
		
		public static void SelectTreeMap()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.VisualizationInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.Visualization.ClickThis();
				repo.VisualAnalyticsTestUndo.TreeMapInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.TreeMap.ClickThis();
				repo.VisualAnalyticsTestUndo.Visualization1Info.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.Visualization1.ClickThis();
				Reports.ReportLog("SelectTreeMap", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectTreeMap" + ex.Message);
			}
		}
		
		public static void ChooseColorTheme()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.Worksheet3ColorsInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.Worksheet3Colors.ClickThis();
				repo.Datastudio.EditColorsInfo.WaitForItemExists(30000);
				repo.Datastudio.EditColors.ClickThis();
				repo.EditColorsProfit.ThemeChooserComboBoxInfo.WaitForItemExists(30000);
				repo.EditColorsProfit.ThemeChooserComboBox.ClickThis();
				repo.SunAwtWindow.RedGreenDivergingInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.RedGreenDiverging.ClickThis();
				Reports.ReportLog("ChooseColorTheme", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ChooseColorTheme" + ex.Message);
			}
		}
		
		public static void SteppedColorAndReversed()
		{
			try
			{
				repo.EditColorsProfit.SteppedColorsCheckBoxInfo.WaitForItemExists(30000);
				repo.EditColorsProfit.SteppedColorsCheckBox.ClickThis();
				repo.EditColorsProfit.SpinnerFormattedTextFieldInfo.WaitForItemExists(30000);
				repo.EditColorsProfit.SpinnerFormattedTextField.PressKeys("{Delete}");
				repo.EditColorsProfit.SpinnerFormattedTextField.PressKeys("6");
				repo.EditColorsProfit.ReversedInfo.WaitForItemExists(30000);
				repo.EditColorsProfit.Reversed.ClickThis();
				Reports.ReportLog("SteppedColorAndReversed", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SteppedColorAndReversed" + ex.Message);
			}
		}
		
		public static void SelectOrangeForMaximum()
		{
			try
			{
				repo.EditColorsProfit.ColorGradientInfo.WaitForItemExists(30000);
				repo.EditColorsProfit.ColorGradient.ClickThis();
				repo.SunAwtWindow.MaxOrangeColorInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.MaxOrangeColor.ClickThis();
				Reports.ReportLog("SelectOrangeForMaximum", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectOrangeForMaximum" + ex.Message);
			}
		}
		
		public static void SetMinimumValue()
		{
			try
			{
				repo.EditColorsProfit.MinimumCheckBoxInfo.WaitForItemExists(30000);
				repo.EditColorsProfit.MinimumCheckBox.ClickThis();
				repo.EditColorsProfit.MinimumTextBoxInfo.WaitForItemExists(30000);
				repo.EditColorsProfit.MinimumTextBox.TextBoxText("0");
				Reports.ReportLog("SetMinimumValue", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SetMinimumValue" + ex.Message);
			}
		}
		
		public static void SetCentreValue()
		{
			try
			{
				repo.EditColorsProfit.CentreCheckBoxInfo.WaitForItemExists(30000);
				repo.EditColorsProfit.CentreCheckBox.ClickThis();
				repo.EditColorsProfit.CentreTextBoxInfo.WaitForItemExists(30000);
				repo.EditColorsProfit.CentreTextBox.TextBoxText("10000");
				Reports.ReportLog("SetCentreValue", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SetCentreValue" + ex.Message);
			}
		}
		
		public static void SetMaximumValue()
		{
			try
			{
				repo.EditColorsProfit.MaximumCheckBoxInfo.WaitForItemExists(30000);
				repo.EditColorsProfit.MaximumCheckBox.ClickThis();
				repo.EditColorsProfit.MaximumTextBoxInfo.WaitForItemExists(30000);
				repo.EditColorsProfit.MaximumTextBox.TextBoxText("50000");
				Reports.ReportLog("SetMaximumValue", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SetMaximumValue" + ex.Message);
			}
		}
		
		public static void ClickEditOk()
		{
			try
			{
				repo.EditColorsProfit.ButtonOKInfo.WaitForItemExists(30000);
				repo.EditColorsProfit.ButtonOK.ClickThis();
				
				Reports.ReportLog("ClickEditOk", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickEditOk" + ex.Message);
			}
		}
		
		public static void ResetEdit()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.Worksheet3ColorsInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.Worksheet3Colors.ClickThis();
				repo.Datastudio.EditColorsInfo.WaitForItemExists(30000);
				repo.Datastudio.EditColors.ClickThis();
				repo.EditColorsProfit.ResetButtonInfo.WaitForItemExists(30000);
				repo.EditColorsProfit.ResetButton.ClickThis();
				ClickEditOk();
				Reports.ReportLog("ResetEdit", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ResetEdit" + ex.Message);
			}
		}
		
		public static void SelectAbsoluteOption()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.OptionsInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.Options.ClickThis();
				repo.Datastudio.UseAbsoluteValuesInfo.WaitForItemExists(30000);
				repo.Datastudio.UseAbsoluteValues.ClickThis();
				Reports.ReportLog("SelectAbsoluteOption", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectAbsoluteOption" + ex.Message);
			}
		}
		
		public static void SelectShowMeasureValues()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.Worksheet3LabelInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.Worksheet3Label.ClickThis();
				repo.Datastudio.ShowMeasureValuesInfo.WaitForItemExists(30000);
				repo.Datastudio.ShowMeasureValues.ClickThis();
				Reports.ReportLog("SelectShowMeasureValues", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectShowMeasureValues" + ex.Message);
			}
		}
		
		public static void NavigateToWorksheet5()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.Worksheet5TabInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.Worksheet5Tab.ClickThis();
				Reports.ReportLog("NavigateToWorksheet5", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : NavigateToWorksheet5" + ex.Message);
			}
		}
		
		public static void SelectShipModeAndRegion()
		{
			try
			{
				Keyboard.Press("{LControlKey down}");
				Delay.Milliseconds(0);
				
				repo.VisualAnalyticsTestUndo.ShipModeInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.ShipMode.ClickThis();
				Delay.Milliseconds(200);
				
				repo.VisualAnalyticsTestUndo.Region1Info.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.Region1.ClickThis();
				Delay.Milliseconds(200);
				
				repo.VisualAnalyticsTestUndo.BIDraggableList.PressKeys("{LControlKey up}");
				Reports.ReportLog("SelectShipModeAndRegion", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectShipModeAndRegion" + ex.Message);
			}
		}
		
		public static void SelectCreateCombinedRegion()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.ShipModeInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.ShipMode.RightClickThis();
				repo.SunAwtWindow.CreateCombinedFieldInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.CreateCombinedField.ClickThis();
				Reports.ReportLog("SelectCreateCombinedRegion", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectCreateCombinedRegion" + ex.Message);
			}
		}
		
		public static void ChangeName()
		{
			try
			{
				repo.CreateCombinedTextField.NameTextInfo.WaitForItemExists(30000);
				repo.CreateCombinedTextField.NameText.TextBoxText("Combined1");
				Reports.ReportLog("ChangeName", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ChangeName" + ex.Message);
			}
		}
		
		public static void ClickOnSave()
		{
			try
			{
				repo.CreateCombinedTextField.SaveInfo.WaitForItemExists(30000);
				repo.CreateCombinedTextField.Save.ClickThis();
				Reports.ReportLog("ClickOnSave", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnSave" + ex.Message);
			}
		}
		
		public static void DragCombined1ToColumn()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.Combined1Info.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.Combined1.MoveTo("66;9");
				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
				Delay.Milliseconds(200);
				
				repo.VisualAnalyticsTestUndo.Combined1.MoveTo("74;1");
				Delay.Milliseconds(200);
				
				repo.VisualAnalyticsTestUndo.ColumnPanel.MoveTo("186;15");
				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				Delay.Milliseconds(200);
				Reports.ReportLog("DragCombined1ToColumn", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragCombined1ToColumn" + ex.Message);
			}
		}
		
		public static void EditSeparator()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.Combined1DimensionInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.Combined1Dimension.RightClickThis();
				repo.SunAwtWindow.EditInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.Edit.ClickThis();
				repo.EditCombinedField.SeparatorInfo.WaitForItemExists(30000);
				repo.EditCombinedField.Separator.TextBoxText("-");
				repo.EditCombinedField.SaveInfo.WaitForItemExists(30000);
				repo.EditCombinedField.Save.ClickThis();
				Reports.ReportLog("EditSeparator", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : EditSeparator" + ex.Message);
			}
		}
		
		public static void DeleteCombined()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.Combined1DimensionInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.Combined1Dimension.RightClickThis();
				repo.SunAwtWindow.DeleteCombined1Info.WaitForItemExists(30000);
				repo.SunAwtWindow.DeleteCombined1.ClickThis();
				repo.DeleteCombined.YesInfo.WaitForItemExists(30000);
				repo.DeleteCombined.Yes.ClickThis();
				
				Reports.ReportLog("DeleteCombined", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DeleteCombined" + ex.Message);
			}
		}
		
		public static void SelectCreateBin()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.SalesMeasure.EnsureVisible();
				repo.VisualAnalyticsTestUndo.SalesMeasureInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.SalesMeasure.RightClickThis();
				repo.SunAwtWindow.CreateBinsInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.CreateBins.ClickThis();
				
				Reports.ReportLog("SelectCreateBin", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectCreateBin" + ex.Message);
			}
		}
		
		public static void SelectNumberOfBins()
		{
			try
			{
				repo.CreateSalesBin.NumberOfBinsInfo.WaitForItemExists(30000);
				repo.CreateSalesBin.NumberOfBins.ClickThis();
				
				Reports.ReportLog("SelectNumberOfBins", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectNumberOfBins" + ex.Message);
			}
		}
		
		public static void ClickCreateBinOk()
		{
			try
			{
				repo.CreateSalesBin.OkButtonInfo.WaitForItemExists(30000);
				repo.CreateSalesBin.OkButton.ClickThis();
				
				Reports.ReportLog("ClickCreateBinOk", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickCreateBinOk" + ex.Message);
			}
		}
		
		public static void DragSalesBinToColumn()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.SalesBin.MoveTo("60;13");
				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
				Delay.Milliseconds(200);
				
				repo.VisualAnalyticsTestUndo.SalesBin.MoveTo("68;5");
				Delay.Milliseconds(200);
				
				repo.VisualAnalyticsTestUndo.ColumnPanel.MoveTo("194;15");
				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				Delay.Milliseconds(200);
				
				Reports.ReportLog("DragSalesBinToColumn", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragSalesBinToColumn" + ex.Message);
			}
		}
		
		public static void EditNumberOfCreateBins()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.SalesBinInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.SalesBin.RightClickThis();
				repo.SunAwtWindow.EditInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.Edit.ClickThis();
				repo.EditBinSales.NumberOfBinsInfo.WaitForItemExists(30000);
				repo.EditBinSales.NumberOfBins.TextBoxText("2");
				repo.EditBinSales.EditOkInfo.WaitForItemExists(30000);
				repo.EditBinSales.EditOk.ClickThis();
				Reports.ReportLog("EditNumberOfCreateBins", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : EditNumberOfCreateBins" + ex.Message);
			}
		}
		
		public static void DeleteSalesBin()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.SalesBinInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.SalesBin.RightClickThis();
				repo.SunAwtWindow.DeleteInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.Delete.ClickThis();
				repo.DeleteSalesBin.YesButtonInfo.WaitForItemExists(30000);
				repo.DeleteSalesBin.YesButton.ClickThis();
				Reports.ReportLog("DeleteSalesBin", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DeleteSalesBin" + ex.Message);
			}
		}
		
		public static void SelectNewDashboard()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.DashboardInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.Dashboard.ClickThis();
				repo.SunAwtWindow.NewDashboardInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.NewDashboard.ClickThis();
				Reports.ReportLog("SelectNewDashboard", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectNewDashboard" + ex.Message);
			}
		}
		
		public static void AddWorksheet1ToDashboard()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.Worksheet1PalletteInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.Worksheet1Pallette.RightClickThis();
				repo.SunAwtWindow.AddToDashboardInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.AddToDashboard.ClickThis();
				Reports.ReportLog("AddWorksheet1ToDashboard", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : AddWorksheet1ToDashboard" + ex.Message);
			}
		}
		
		public static void AddWorksheet2ToDashboard()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.Worksheet2PalletteInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.Worksheet2Pallette.RightClickThis();
				repo.SunAwtWindow.AddToDashboardInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.AddToDashboard.ClickThis();
				Reports.ReportLog("AddWorksheet2ToDashboard", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : AddWorksheet2ToDashboard" + ex.Message);
			}
		}
		
		public static void RemoveFromDashboard()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.Worksheet1PalletteInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.Worksheet1Pallette.RightClickThis();
				repo.SunAwtWindow.RemoveFromDashboardInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.RemoveFromDashboard.ClickThis();
				Reports.ReportLog("RemoveFromDashboard", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : RemoveFromDashboard" + ex.Message);
			}
		}
		
		public static void EditTextHelloWorld()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.TextInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.Text.DoubleClick();
				repo.EditText.EditTextInfo.WaitForItemExists(30000);
				repo.EditText.EditText.TextBoxText("Hello World");
				repo.EditText.OkInfo.WaitForItemExists(30000);
				repo.EditText.Ok.ClickThis();
				Reports.ReportLog("EditTextHelloWorld", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : EditTextHelloWorld" + ex.Message);
			}
		}
		
		public static void SelectImage()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.ImageInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.Image.DoubleClick();
				repo.ChooseImage.FileNameTextInfo.WaitForItemExists(30000);
				repo.ChooseImage.FileNameText.TextBoxText(TC_10608_PATH + "abc.png");
				Reports.ReportLog("SelectImage", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectImage" + ex.Message);
			}
		}
		
		public static void OpenImage()
		{
			try
			{
				repo.ChooseImage.FileOpenInfo.WaitForItemExists(30000);
				repo.ChooseImage.FileOpen.ClickThis();
				Reports.ReportLog("OpenImage", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : OpenImage" + ex.Message);
			}
		}
		
		public static void RemoveImage()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.ImageDashboardInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.ImageDashboard.RightClickThis();
				repo.SunAwtWindow.RemoveFromDashboardInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.RemoveFromDashboard.ClickThis();
				Reports.ReportLog("RemoveImage", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : RemoveImage" + ex.Message);
			}
		}
		
		public static void EditTextHiThere()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.TextInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.Text.DoubleClick();
				repo.EditText.EditTextInfo.WaitForItemExists(30000);
				repo.EditText.EditText.TextBoxText("Hi There");
				repo.EditText.OkInfo.WaitForItemExists(30000);
				repo.EditText.Ok.ClickThis();
				Reports.ReportLog("EditTextHiThere", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : EditTextHiThere" + ex.Message);
			}
		}
		
		public static void DeleteDashboard1()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.Dashboard1TabInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.Dashboard1Tab.RightClickThis();
				repo.SunAwtWindow.DeleteInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.Delete.ClickThis();
				Reports.ReportLog("DeleteDashboard1", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DeleteDashboard1" + ex.Message);
			}
		}
		
		public static void ShowTrendLines()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.SumSalesBIChartOverlayPanelInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.SumSalesBIChartOverlayPanel.Click(System.Windows.Forms.MouseButtons.Right, "10;136");
				repo.SunAwtWindow0.TrendLinesInfo.WaitForItemExists(30000);
				repo.SunAwtWindow0.TrendLines.ClickThis();
				repo.SunAwtWindow1.ShowTrendLinesInfo.WaitForItemExists(30000);
				repo.SunAwtWindow1.ShowTrendLines.ClickThis();
				Reports.ReportLog("ShowtrendLines", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ShowtrendLines" + ex.Message);
			}
		}
		
		public static void EditTrendLines()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.SumSalesBIChartOverlayPanelInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.SumSalesBIChartOverlayPanel.Click(System.Windows.Forms.MouseButtons.Right, "10;136");
				repo.SunAwtWindow0.TrendLinesInfo.WaitForItemExists(30000);
				repo.SunAwtWindow0.TrendLines.ClickThis();
				repo.SunAwtWindow1.EditTrendLinesInfo.WaitForItemExists(30000);
				repo.SunAwtWindow1.EditTrendLines.ClickThis();
				repo.TrendOptions.PolynomialTrendInfo.WaitForItemExists(30000);
				repo.TrendOptions.PolynomialTrend.ClickThis();
				repo.TrendOptions.OkButtonInfo.WaitForItemExists(30000);
				repo.TrendOptions.OkButton.ClickThis();
				Reports.ReportLog("EditTrendLines", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : EditTrendLines" + ex.Message);
			}
		}
		
		public static void AddReference()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.SumSalesBIChartOverlayPanelInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.SumSalesBIChartOverlayPanel.Click(System.Windows.Forms.MouseButtons.Right, "10;136");
				repo.SunAwtWindow.AddReferenceInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.AddReference.ClickThis();
				repo.AddReference.BandInfo.WaitForItemExists(30000);
				repo.AddReference.Band.ClickThis();
				repo.AddReference.OkButtonInfo.WaitForItemExists(30000);
				repo.AddReference.OkButton.ClickThis();
				Reports.ReportLog("AddReference", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : AddReference" + ex.Message);
			}
		}
		
		public static void EditReference()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.SumSalesBIChartOverlayPanelInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.SumSalesBIChartOverlayPanel.Click(System.Windows.Forms.MouseButtons.Right, "10;136");
				repo.SunAwtWindow.EditReferenceInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.EditReference.ClickThis();
				repo.EditReference.BoxPlotInfo.WaitForItemExists(30000);
				repo.EditReference.BoxPlot.ClickThis();
				repo.EditReference.OkButtonInfo.WaitForItemExists(30000);
				repo.EditReference.OkButton.ClickThis();
				Reports.ReportLog("EditReference", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : EditReference" + ex.Message);
			}
		}
		
		public static void RemoveReference()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.SumSalesBIChartOverlayPanelInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.SumSalesBIChartOverlayPanel.Click(System.Windows.Forms.MouseButtons.Right, "10;136");
				repo.SunAwtWindow.RemoveReferenceInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.RemoveReference.ClickThis();
				Reports.ReportLog("RemoveReference", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : RemoveReference" + ex.Message);
			}
		}
		
		public static void NavigateToWorksheet4()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.Worksheet4Info.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.Worksheet4.ClickThis();
				Reports.ReportLog("NavigateToWorksheet4", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : NavigateToWorksheet4" + ex.Message);
			}
		}
		
		public static void SelectDimension()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.SUMSalesInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.SUMSales.RightClickThis();
				repo.SunAwtWindow.DimensionInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.Dimension.ClickThis();
				Reports.ReportLog("SelectDimension", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectDimension" + ex.Message);
			}
		}
		
		public static void SelectMeasure()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.ProductSubCategoryInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.ProductSubCategory.RightClickThis();
				repo.SunAwtWindow.MeasureProductSubCategoryInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.MeasureProductSubCategory.ClickThis();
				Reports.ReportLog("SelectMeasure", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectMeasure" + ex.Message);
			}
		}
		
		public static void SelectAttribute()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.ProductSubCategoryInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.ProductSubCategory.RightClickThis();
				repo.SunAwtWindow.AttributeInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.Attribute.ClickThis();
				Reports.ReportLog("SelectAttribute", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectAttribute" + ex.Message);
			}
		}
		
		public static void ConvertToDimension()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.MeasureDiscountInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.MeasureDiscount.RightClickThis();
				repo.SunAwtWindow.ConvertToDimensionInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.ConvertToDimension.ClickThis();
				Reports.ReportLog("ConvertToDimension", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ConvertToDimension" + ex.Message);
			}
		}
		
		public static void DragDiscountToColumn()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.Discount.MoveTo("75;9");
				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
				Delay.Milliseconds(200);
				
				repo.VisualAnalyticsTestUndo.Discount.MoveTo("83;1");
				Delay.Milliseconds(200);
				
				repo.VisualAnalyticsTestUndo.ColumnPanelWorksheet4.MoveTo("211;9");
				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				Delay.Milliseconds(200);
				Reports.ReportLog("DragDiscountToColumn", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragDiscountToColumn" + ex.Message);
			}
		}
		
		public static void DragShipDateToColumn()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.ShipDate.MoveTo("62;11");
				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
				Delay.Milliseconds(200);
				
				repo.VisualAnalyticsTestUndo.ShipDate.MoveTo("70;3");
				Delay.Milliseconds(200);
				
				repo.VisualAnalyticsTestUndo.ColumnPanelWorksheet4.MoveTo("225;22");
				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				Delay.Milliseconds(200);
				Reports.ReportLog("DragShipDateToColumn", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragShipDateToColumn" + ex.Message);
			}
		}
		
		public static void SelectCountryFromGeoRole()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.RegionInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.Region.RightClickThis();
				repo.SunAwtWindow.GeographicRoleInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.GeographicRole.ClickThis();
				repo.SunAwtWindow1.CountryInfo.WaitForItemExists(30000);
				repo.SunAwtWindow1.Country.ClickThis();
				Reports.ReportLog("SelectCountryFromGeoRole", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectCountryFromGeoRole" + ex.Message);
			}
		}
		
		public static void DragMeasureContainer()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.Measures.MoveTo("149;14");
				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
				Delay.Milliseconds(200);
				
				repo.VisualAnalyticsTestUndo.Measures.MoveTo("157;6");
				Delay.Milliseconds(200);
				
				repo.VisualAnalyticsTestUndo.BIDraggableList.MoveTo("191;277");
				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				Delay.Milliseconds(200);
				
				repo.VisualAnalyticsTestUndo.Measures.MoveTo("135;17");
				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
				Delay.Milliseconds(200);
				
				repo.VisualAnalyticsTestUndo.Measures.MoveTo("143;9");
				Delay.Milliseconds(200);
				
				repo.VisualAnalyticsTestUndo.BIDraggableList.MoveTo("138;287");
				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				Delay.Milliseconds(200);
				
				repo.VisualAnalyticsTestUndo.Measures.MoveTo("121;19");
				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
				Delay.Milliseconds(200);
				
				repo.VisualAnalyticsTestUndo.Measures.MoveTo("144;-119");
				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				Delay.Milliseconds(200);
				Reports.ReportLog("DragMeasureContainer", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragMeasureContainer" + ex.Message);
			}
		}
		
		public static void CreateCalculatedField()
		{
			try
			{
				DragMeasureContainer();
				repo.VisualAnalyticsTestUndo.BIDraggableList1.Click(System.Windows.Forms.MouseButtons.Right, "22;283");
				repo.SunAwtWindow.CreateCalculatedFieldInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.CreateCalculatedField.ClickThis();
				Reports.ReportLog("CreateCalculatedField", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CreateCalculatedField" + ex.Message);
			}
		}
		
		public static void CreateCalculate1Field()
		{
			try
			{
				repo.CreateCalculatedField.Index.EnsureVisible();
				repo.CreateCalculatedField.IndexInfo.WaitForItemExists(30000);
				repo.CreateCalculatedField.Index.DoubleClick();
				repo.CreateCalculatedField.SaveInfo.WaitForItemExists(30000);
				repo.CreateCalculatedField.Save.ClickThis();
				Reports.ReportLog("CreateCalculate1Field", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CreateCalculate1Field" + ex.Message);
			}
		}
		
		public static void DragCalculation1ToColumn()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.Calculation1.MoveTo("60;5");
				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
				Delay.Milliseconds(200);
				
				repo.VisualAnalyticsTestUndo.Calculation1.MoveTo("68;-3");
				Delay.Milliseconds(200);
				
				repo.VisualAnalyticsTestUndo.SUMSales.MoveTo("52;10");
				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				Delay.Milliseconds(200);
				Reports.ReportLog("CreateCalculate1Field", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CreateCalculate1Field" + ex.Message);
			}
		}
		
		public static void EditCalculation1()
		{
			try
			{
				repo.VisualAnalyticsTestUndo.Calculation1Info.WaitForItemExists(30000);
				repo.VisualAnalyticsTestUndo.Calculation1.RightClickThis();
				repo.SunAwtWindow.EditInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.Edit.ClickThis();
				repo.EditCalculatedField.EditableFieldInfo.WaitForItemExists(30000);
				repo.EditCalculatedField.EditableField.Click();
				Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Keyboard.Press(Keyboard.ToKey("Delete"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				repo.EditCalculatedField.EditableField.PressKeys("[Sales] + [Profit]");
				repo.EditCalculatedField.SaveInfo.WaitForItemExists(30000);
				repo.EditCalculatedField.Save.ClickThis();
				Reports.ReportLog("EditCalculation1", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : EditCalculation1" + ex.Message);
			}
		}
		
		public static void ValidateUndo1Case2()
		{
			try
			{
				if(repo.VisualAnalyticsTestUndoValidation.Undo1Case2Info.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestUndoValidation.Undo1Case2Info.GetUndo1Case2();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestUndoValidation.Undo1Case2Info;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateUndo1Case2 data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateUndo1Case2", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateUndo1Case2 :" +ex.Message);
			}
		}
		
		public static void ValidateUndo2Case2()
		{
			try
			{
				if(repo.VisualAnalyticsTestUndoValidation.Undo2Case2Info.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestUndoValidation.Undo2Case2Info.GetUndo2Case2();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestUndoValidation.Undo2Case2Info;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateUndo2Case2 data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateUndo2Case2", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateUndo2Case2 :" +ex.Message);
			}
		}
		
		public static void ValidateRedo1Case2()
		{
			try
			{
				if(repo.VisualAnalyticsTestUndoValidation.Redo1Case2Info.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestUndoValidation.Redo1Case2Info.GetRedo1Case2();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestUndoValidation.Redo1Case2Info;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateRedo1Case2 data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateRedo1Case2", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateRedo1Case2 :" +ex.Message);
			}
		}
		
		public static void ValidateRedo2Case2()
		{
			try
			{
				if(repo.VisualAnalyticsTestUndoValidation.Redo2Case2Info.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestUndoValidation.Redo2Case2Info.GetRedo2Case2();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestUndoValidation.Redo2Case2Info;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateRedo2Case2 data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateRedo2Case2", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateRedo2Case2 :" +ex.Message);
			}
		}
		
		public static void ValidateUndo3Case2()
		{
			try
			{
				if(repo.VisualAnalyticsTestUndoValidation.Undo3Case2Info.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestUndoValidation.Undo3Case2Info.GetUndo3Case2();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestUndoValidation.Undo3Case2Info;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateUndo3Case2 data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateUndo3Case2", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateUndo3Case2 :" +ex.Message);
			}
		}
		
		public static void ValidalidateRedo3Case2()
		{
			try
			{
				if(repo.VisualAnalyticsTestUndoValidation.Redo3Case2Info.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestUndoValidation.Redo3Case2Info.GetRedo3Case2();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestUndoValidation.Redo3Case2Info;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidalidateRedo3Case2 data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidalidateRedo3Case2", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidalidateRedo3Case2 :" +ex.Message);
			}
		}
		
		public static void ValidateUndo1Case3()
		{
			try
			{
				if(repo.VisualAnalyticsTestUndoValidation.Undo1Case3Info.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestUndoValidation.Undo1Case3Info.GetUndo1Case3();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestUndoValidation.Undo1Case3Info;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateUndo1Case3 data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateUndo1Case3", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateUndo1Case3 :" +ex.Message);
			}
		}
		
		public static void ValidateUndo2Case3()
		{
			try
			{
				if(repo.VisualAnalyticsTestUndoValidation.Undo2Case3Info.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestUndoValidation.Undo2Case3Info.GetUndo2Case3();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestUndoValidation.Undo2Case3Info;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateUndo2Case3 data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateUndo2Case3", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateUndo2Case3 :" +ex.Message);
			}
		}
		
		public static void ValidateUndo3Case3()
		{
			try
			{
				if(repo.VisualAnalyticsTestUndoValidation.Undo3Case3Info.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestUndoValidation.Undo3Case3Info.GetUndo3Case3();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestUndoValidation.Undo3Case3Info;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateUndo3Case3 data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateUndo3Case3", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateUndo3Case3 :" +ex.Message);
			}
		}
		
		public static void ValidateUndo4Case3()
		{
			try
			{
				if(repo.VisualAnalyticsTestUndoValidation.Undo4Case3Info.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestUndoValidation.Undo4Case3Info.GetUndo4Case3();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestUndoValidation.Undo4Case3Info;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateUndo4Case3 data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateUndo4Case3", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateUndo4Case3 :" +ex.Message);
			}
		}
		
		public static void ValidateUndo5Case3()
		{
			try
			{
				if(repo.VisualAnalyticsTestUndoValidation.Undo5Case3Info.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestUndoValidation.Undo5Case3Info.GetUndo5Case3();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestUndoValidation.Undo5Case3Info;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateUndo5Case3 data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateUndo5Case3", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateUndo5Case3 :" +ex.Message);
			}
		}
		
		public static void ValidateRedo1Case3()
		{
			try
			{
				if(repo.VisualAnalyticsTestUndoValidation.Redo1Case3Info.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestUndoValidation.Redo1Case3Info.GetRedo1Case3();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestUndoValidation.Redo1Case3Info;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateRedo1Case3 data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateRedo1Case3", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateRedo1Case3 :" +ex.Message);
			}
		}
		
		public static void ValidateRedo2Case3()
		{
			try
			{
				if(repo.VisualAnalyticsTestUndoValidation.Redo2Case3Info.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestUndoValidation.Redo2Case3Info.GetRedo2Case3();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestUndoValidation.Redo2Case3Info;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateRedo2Case3 data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateRedo2Case3", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateRedo2Case3 :" +ex.Message);
			}
		}
		
		public static void ValidateRedo3Case3()
		{
			try
			{
				if(repo.VisualAnalyticsTestUndoValidation.Redo3Case3Info.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestUndoValidation.Redo3Case3Info.GetRedo3Case3();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestUndoValidation.Redo3Case3Info;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateRedo3Case3 data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateRedo3Case3", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateRedo3Case3 :" +ex.Message);
			}
		}
		
		public static void ValidateUndo1Case4()
		{
			try
			{
				if(repo.VisualAnalyticsTestUndoValidation.Undo1Case4Info.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestUndoValidation.Undo1Case4Info.GetUndo1Case4();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestUndoValidation.Undo1Case4Info;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateUndo1Case4 data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateUndo1Case4", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateUndo1Case4 :" +ex.Message);
			}
		}
		
		public static void ValidateUndo2Case4()
		{
			try
			{
				if(repo.VisualAnalyticsTestUndoValidation.Undo2Case4Info.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestUndoValidation.Undo2Case4Info.GetUndo2Case4();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestUndoValidation.Undo2Case4Info;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateUndo2Case4 data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateUndo2Case4", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateUndo2Case4 :" +ex.Message);
			}
		}
		
		public static void ValidateUndo3Case4()
		{
			try
			{
				if(repo.VisualAnalyticsTestUndoValidation.Undo3Case4Info.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestUndoValidation.Undo3Case4Info.GetUndo3Case4();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestUndoValidation.Undo3Case4Info;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateUndo3Case4 data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateUndo3Case4", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateUndo3Case4 :" +ex.Message);
			}
		}
		
		public static void ValidateUndo4Case4()
		{
			try
			{
				if(repo.VisualAnalyticsTestUndoValidation.Undo4Case4Info.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestUndoValidation.Undo4Case4Info.GetUndo4Case4();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestUndoValidation.Undo4Case4Info;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateUndo4Case4 data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateUndo4Case4", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateUndo4Case4 :" +ex.Message);
			}
		}
		
		public static void ValidateUndo5Case4()
		{
			try
			{
				if(repo.VisualAnalyticsTestUndoValidation.Undo5Case4Info.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestUndoValidation.Undo5Case4Info.GetUndo5Case4();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestUndoValidation.Undo5Case4Info;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateUndo5Case4 data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateUndo5Case4", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateUndo5Case4 :" +ex.Message);
			}
		}
		
		public static void ValidateUndo6Case4()
		{
			try
			{
				if(repo.VisualAnalyticsTestUndoValidation.Undo6Case4Info.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestUndoValidation.Undo6Case4Info.GetUndo6Case4();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestUndoValidation.Undo6Case4Info;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateUndo6Case4 data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateUndo6Case4", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateUndo6Case4 :" +ex.Message);
			}
		}
		
		public static void ValidateUndo1Case5()
		{
			try
			{
				if(repo.VisualAnalyticsTestUndoValidation.Undo1Case5Info.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestUndoValidation.Undo1Case5Info.GetUndo1Case5();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestUndoValidation.Undo1Case5Info;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateUndo1Case5 data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateUndo1Case5", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateUndo1Case5 :" +ex.Message);
			}
		}
		
		public static void ValidateUndo2Case5()
		{
			try
			{
				if(repo.VisualAnalyticsTestUndoValidation.Undo2Case5Info.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestUndoValidation.Undo2Case5Info.GetUndo2Case5();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestUndoValidation.Undo2Case5Info;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateUndo2Case5 data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateUndo2Case5", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateUndo2Case5 :" +ex.Message);
			}
		}
		
		public static void ValidateUndo3Case5()
		{
			try
			{
				if(repo.VisualAnalyticsTestUndoValidation.Undo3Case5Info.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestUndoValidation.Undo3Case5Info.GetUndo3Case5();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestUndoValidation.Undo3Case5Info;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateUndo3Case5 data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateUndo3Case5", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateUndo3Case5 :" +ex.Message);
			}
		}
		
		public static void ValidateUndo4Case5()
		{
			try
			{
				if(repo.VisualAnalyticsTestUndoValidation.Undo4Case5Info.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestUndoValidation.Undo4Case5Info.GetUndo4Case5();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestUndoValidation.Undo4Case5Info;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateUndo4Case5 data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateUndo4Case5", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateUndo4Case5 :" +ex.Message);
			}
		}
		
		public static void ValidateUndo5Case5()
		{
			try
			{
				if(repo.VisualAnalyticsTestUndoValidation.Undo5Case5Info.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestUndoValidation.Undo5Case5Info.GetUndo5Case5();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestUndoValidation.Undo5Case5Info;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateUndo5Case5 data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateUndo5Case5", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateUndo5Case5 :" +ex.Message);
			}
		}
		
		public static void ValidateUndo6Case5()
		{
			try
			{
				if(repo.VisualAnalyticsTestUndoValidation.Undo6Case5Info.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestUndoValidation.Undo6Case5Info.GetUndo6Case5();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestUndoValidation.Undo6Case5Info;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateUndo6Case5 data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateUndo6Case5", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateUndo6Case5 :" +ex.Message);
			}
		}
		
		public static void ValidateUndo7Case5()
		{
			try
			{
				if(repo.VisualAnalyticsTestUndoValidation.Undo7Case5Info.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestUndoValidation.Undo7Case5Info.GetUndo7Case5();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestUndoValidation.Undo7Case5Info;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateUndo7Case5 data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateUndo7Case5", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateUndo7Case5 :" +ex.Message);
			}
		}
		
		public static void ValidateUndo1Case6()
		{
			try
			{
				if(repo.VisualAnalyticsTestUndoValidation.Undo1Case6Info.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestUndoValidation.Undo1Case6Info.GetUndo1Case6();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestUndoValidation.Undo1Case6Info;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateUndo1Case6 data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateUndo1Case6", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateUndo1Case6 :" +ex.Message);
			}
		}
		
		public static void ValidateUndo2Case6()
		{
			try
			{
				if(repo.VisualAnalyticsTestUndoValidation.Undo2Case6Info.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestUndoValidation.Undo2Case6Info.GetUndo2Case6();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestUndoValidation.Undo2Case6Info;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateUndo2Case6 data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateUndo2Case6", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateUndo2Case6 :" +ex.Message);
			}
		}
		
		public static void ValidateUndo3Case6()
		{
			try
			{
				if(repo.VisualAnalyticsTestUndoValidation.Undo3Case6Info.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestUndoValidation.Undo3Case6Info.GetUndo3Case6();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestUndoValidation.Undo3Case6Info;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateUndo3Case6 data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateUndo3Case6", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateUndo3Case6 :" +ex.Message);
			}
		}
		
		public static void ValidateUndo4Case6()
		{
			try
			{
				if(repo.VisualAnalyticsTestUndoValidation.Undo4Case6Info.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestUndoValidation.Undo4Case6Info.GetUndo4Case6();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestUndoValidation.Undo4Case6Info;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateUndo4Case6 data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateUndo4Case6", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateUndo4Case6 :" +ex.Message);
			}
		}
		
		public static void ValidateUndo5Case6()
		{
			try
			{
				if(repo.VisualAnalyticsTestUndoValidation.Undo5Case6Info.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestUndoValidation.Undo5Case6Info.GetUndo5Case6();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestUndoValidation.Undo5Case6Info;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateUndo5Case6 data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateUndo5Case6", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateUndo5Case6 :" +ex.Message);
			}
		}
		
		public static void ValidateUndo1Case7()
		{
			try
			{
				if(repo.VisualAnalyticsTestUndoValidation.Undo1Case7Info.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestUndoValidation.Undo1Case7Info.GetUndo1Case7();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestUndoValidation.Undo1Case7Info;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateUndo1Case7 data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateUndo1Case7", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateUndo1Case7 :" +ex.Message);
			}
		}
		
		public static void ValidateUndo2Case7()
		{
			try
			{
				if(repo.VisualAnalyticsTestUndoValidation.Undo2Case7Info.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestUndoValidation.Undo2Case7Info.GetUndo2Case7();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestUndoValidation.Undo2Case7Info;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateUndo2Case7 data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateUndo2Case7", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateUndo2Case7 :" +ex.Message);
			}
		}
		
		public static void ValidateUndo3Case7()
		{
			try
			{
				if(repo.VisualAnalyticsTestUndoValidation.Undo3Case7Info.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestUndoValidation.Undo3Case7Info.GetUndo3Case7();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestUndoValidation.Undo3Case7Info;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateUndo3Case7 data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateUndo3Case7", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateUndo3Case7 :" +ex.Message);
			}
		}
		
		public static void ValidateRedo1Case7()
		{
			try
			{
				if(repo.VisualAnalyticsTestUndoValidation.Redo1Case7Info.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestUndoValidation.Redo1Case7Info.GetRedo1Case7();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestUndoValidation.Redo1Case7Info;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateRedo1Case7 data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateRedo1Case7", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateRedo1Case7 :" +ex.Message);
			}
		}
		
		public static void ValidateRedo2Case7()
		{
			try
			{
				if(repo.VisualAnalyticsTestUndoValidation.Redo2Case7Info.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestUndoValidation.Redo2Case7Info.GetRedo2Case7();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestUndoValidation.Redo2Case7Info;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateRedo2Case7 data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateRedo2Case7", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateRedo2Case7 :" +ex.Message);
			}
		}
		
		public static void ValidateRedo3Case7()
		{
			try
			{
				if(repo.VisualAnalyticsTestUndoValidation.Redo3Case7Info.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestUndoValidation.Redo3Case7Info.GetRedo3Case7();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestUndoValidation.Redo3Case7Info;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateRedo3Case7 data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateRedo3Case7", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateRedo3Case7 :" +ex.Message);
			}
		}
		
		public static void CloseOnVisualAnalyticsError()
		{
			if(repo.VisualAnalyticsTestUndo.SelfInfo.Exists(5000))
				repo.VisualAnalyticsTestUndo.Self.Close();
		}
		
		public static void CloseOnOpenFileError()
		{
			if(TC10589Repo.Open.SelfInfo.Exists(5000))
				TC10589Repo.Open.Self.Close();
		}
	}
}
