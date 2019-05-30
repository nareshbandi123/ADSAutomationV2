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

namespace ADSAutomationPhaseII.TC_10599
{
	public class Steps
	{
		public static TC10589 TC10589Repo = TC10589.Instance;
		public static TC10599 repo = TC10599.Instance;
		public static string TC_10599_PATH = System.Configuration.ConfigurationManager.AppSettings["TC_10599_Path"].ToString();
		
		public static void EnterFilePath()
		{
			try
			{
				TC10589Repo.Open.OpenTextInfo.WaitForItemExists(20000);
				TC10589Repo.Open.OpenText.TextBoxText(TC_10599_PATH + "test-sort.vizx");
				Reports.ReportLog("EnterFilePath", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : EnterFilePath" + ex.Message);
			}
		}
		
		public static void Maximize()
		{
			try
			{
				if(repo.VisualAnalyticsTestSort.MaximizeInfo.Exists(5000))
				{
					repo.VisualAnalyticsTestSort.MaximizeInfo.WaitForItemExists(200000);
					repo.VisualAnalyticsTestSort.Maximize.ClickThis();
					Reports.ReportLog("Maximize", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : Maximize" + ex.Message);
			}
		}
		
		public static void HoverDescending()
		{
			try
			{
				repo.VisualAnalyticsTestSort.BIChartOverlayPanelMain.Click("28;194");
				repo.VisualAnalyticsTestSort.BIChartOverlayPanelDescending.Click("78;157");
				Reports.ReportLog("HoverDescending", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : HoverDescending" + ex.Message);
			}
		}
		
		public static void HoverAscending()
		{
			try
			{
				repo.VisualAnalyticsTestSort.ContainerCanvas.BIChartOverlayPanelAscending.MoveTo("75;161");
				repo.VisualAnalyticsTestSort.ContainerCanvas.BIChartOverlayPanelAscending.Click("75;161");
				Reports.ReportLog("HoverAscending", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : HoverAscending" + ex.Message);
			}
		}
		
		public static void HoverDefault()
		{
			try
			{
				Mouse.MoveTo("75:161");
				repo.VisualAnalyticsTestSort.ContainerCanvas.BIChartOverlayPanelDefault.Click("75;161");
				Reports.ReportLog("HoverDefault", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : HoverDefault" + ex.Message);
			}
		}
		
		public static void SortEastInDescendingOrder()
		{
			try
			{
				repo.VisualAnalyticsTestSort.EastBIChartOverlayPanelInfo.WaitForItemExists(200000);
				repo.VisualAnalyticsTestSort.EastBIChartOverlayPanel.Click("73;157");
				Reports.ReportLog("SortEastInDescendingOrder", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SortEastInDescendingOrder" + ex.Message);
			}
		}
		
		public static void SortEastInAscendingOrder()
		{
			try
			{
				repo.VisualAnalyticsTestSort.EastContainerCanvasInfo.WaitForItemExists(200000);
				repo.VisualAnalyticsTestSort.EastContainerCanvas.Click("73;157");
				Reports.ReportLog("SortEastInAscendingOrder", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SortEastInAscendingOrder" + ex.Message);
			}
		}
		
		public static void SortBookCasesInDescendingOrder()
		{
			try
			{
				repo.VisualAnalyticsTestSort.BookCasesBIChartOverlayPanelInfo.WaitForItemExists(200000);
				repo.VisualAnalyticsTestSort.BookCasesBIChartOverlayPanel.Click("418;394");
				Reports.ReportLog("SortBookCasesInDescendingOrder", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SortBookCasesInDescendingOrder" + ex.Message);
			}
		}
		
		public static void SortBookCasesInAscendingOrder()
		{
			try
			{
				repo.VisualAnalyticsTestSort.BookCasesContainerCanvasInfo.WaitForItemExists(200000);
				repo.VisualAnalyticsTestSort.BookCasesContainerCanvas.Click("418;394");
				Reports.ReportLog("SortBookCasesInAscendingOrder", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SortBookCasesInAscendingOrder" + ex.Message);
			}
		}
		
		public static void SortBookCasesInDefaultOrder()
		{
			try
			{
				repo.VisualAnalyticsTestSort.BookCasesContainerCanvasInfo.WaitForItemExists(200000);
				repo.VisualAnalyticsTestSort.BookCasesContainerCanvas.Click("418;394");
				Reports.ReportLog("SortBookCasesInDefaultOrder", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SortBookCasesInDefaultOrder" + ex.Message);
			}
		}
		
		public static void ChangeChartToTable()
		{
			try
			{
				repo.VisualAnalyticsTestSort.WindowsComboBoxUIDollarXPComboBoxButtonInfo.WaitForItemExists(200000);
				repo.VisualAnalyticsTestSort.WindowsComboBoxUIDollarXPComboBoxButton.ClickThis();
				repo.SunAwtWindow.TableInfo.WaitForItemExists(200000);
				repo.SunAwtWindow.Table.ClickThis();
				Reports.ReportLog("ChangeChartToTable", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ChangeChartToTable" + ex.Message);
			}
		}
		
		public static void SortEastTableInDescendingOrder()
		{
			try
			{
				repo.VisualAnalyticsTestSort.PivotTableOverlayPanelInfo.WaitForItemExists(200000);
				repo.VisualAnalyticsTestSort.PivotTableOverlayPanel.Click("36;124");
				Reports.ReportLog("SortEastTableInDescendingOrder", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SortEastTableInDescendingOrder" + ex.Message);
			}
		}
		
		public static void SortEastTableInAscendingOrder()
		{
			try
			{
				repo.VisualAnalyticsTestSort.PivotTableOverlayPanelInfo.WaitForItemExists(200000);
				repo.VisualAnalyticsTestSort.PivotTableOverlayPanel.Click("32;122");
				Reports.ReportLog("SortEastTableInAscendingOrder", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SortEastTableInAscendingOrder" + ex.Message);
			}
		}
		
		public static void SortEastTableInDefaultOrder()
		{
			try
			{
				repo.VisualAnalyticsTestSort.PivotTableOverlayPanelInfo.WaitForItemExists(200000);
				repo.VisualAnalyticsTestSort.PivotTableOverlayPanel.Click("32;121");
				Reports.ReportLog("SortEastTableInDefaultOrder", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SortEastTableInDefaultOrder" + ex.Message);
			}
		}
		
		public static void SortBookCasesTableInDescendingOrder()
		{
			try
			{
				repo.VisualAnalyticsTestSort.PivotTableOverlayPanelInfo.WaitForItemExists(200000);
				repo.VisualAnalyticsTestSort.PivotTableOverlayPanel.Click("452;62");
				Reports.ReportLog("SortBookCasesTableInDescendingOrder", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SortBookCasesTableInDescendingOrder" + ex.Message);
			}
		}
		
		public static void SortBookCasesTableInAscendingOrder()
		{
			try
			{
				repo.VisualAnalyticsTestSort.PivotTableOverlayPanelInfo.WaitForItemExists(200000);
				repo.VisualAnalyticsTestSort.PivotTableOverlayPanel.Click("450;67");
				Reports.ReportLog("SortBookCasesTableInAscendingOrder", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SortBookCasesTableInAscendingOrder" + ex.Message);
			}
		}
		
		public static void SortBookCasesTableInDefaultOrder()
		{
			try
			{
				repo.VisualAnalyticsTestSort.PivotTableOverlayPanelInfo.WaitForItemExists(200000);
				repo.VisualAnalyticsTestSort.PivotTableOverlayPanel.Click("450;63");
				Reports.ReportLog("SortBookCasesTableInDefaultOrder", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SortBookCasesTableInDefaultOrder" + ex.Message);
			}
		}
		
		public static void RemoveProductCategoryFromColumn()
		{
			try
			{
				repo.VisualAnalyticsTestSort.ProductSubCategoryInfo.WaitForItemExists(200000);
				repo.VisualAnalyticsTestSort.ProductSubCategory.MoveTo("51;9");
				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
				
				repo.VisualAnalyticsTestSort.ProductSubCategory.MoveTo("59;1");
				
				repo.VisualAnalyticsTestSort.WorksheetPanelInfo.WaitForItemExists(200000);
				repo.VisualAnalyticsTestSort.WorksheetPanel.MoveTo("81;336");
				
				Reports.ReportLog("RemoveProductCategoryFromColumn", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : RemoveProductCategoryFromColumn" + ex.Message);
			}
		}
		
		public static void SortSumSalesInAscendingOrder()
		{
			try
			{
				repo.VisualAnalyticsTestSort.SortAscendingInfo.WaitForItemExists(200000);
				repo.VisualAnalyticsTestSort.SortAscending.ClickThis();
				Reports.ReportLog("SortSumSalesInAscendingOrder", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SortSumSalesInAscendingOrder" + ex.Message);
			}
		}
		
		public static void ValidateEastDescendingChart()
		{
			try
			{
				if(repo.VisualAnalyticsTestSort.EastDescendingInfo.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestSort.EastDescendingInfo.GetEastDescending();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestSort.EastDescendingInfo;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateEastDescendingChart data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateEastDescendingChart", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateEastDescendingChart :" +ex.Message);
			}
		}
		
		public static void ValidateAscendingChart()
		{
			try
			{
				if(repo.VisualAnalyticsTestSort.AscendingInfo.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestSort.AscendingInfo.GetAscending();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestSort.AscendingInfo;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateAscendingChart data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateAscendingChart", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateAscendingChart :" +ex.Message);
			}
		}
		
		public static void ValidateFieldAscendingChart()
		{
			try
			{
				if(repo.VisualAnalyticsTestSort.FieldAscendingInfo.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestSort.FieldAscendingInfo.GetAscending();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestSort.FieldAscendingInfo;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateFieldAscendingChart data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateFieldAscendingChart", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateFieldAscendingChart :" +ex.Message);
			}
		}
		
		public static void ValidatePerCellMeasureChart()
		{
			try
			{
				if(repo.VisualAnalyticsTestSort.PerCellMeasureInfo.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestSort.PerCellMeasureInfo.GetPerCellMeasure();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestSort.PerCellMeasureInfo;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidatePerCellMeasureChart data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidatePerCellMeasureChart", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidatePerCellMeasureChart :" +ex.Message);
			}
		}
		
		public static void ValidateDescendingAdvanceChart()
		{
			try
			{
				if(repo.VisualAnalyticsTestSort.DescendingAdvanceInfo.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestSort.DescendingAdvanceInfo.GetDescendingAdvance();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestSort.DescendingAdvanceInfo;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateDescendingAdvanceChart data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateDescendingAdvanceChart", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateDescendingAdvanceChart :" +ex.Message);
			}
		}
		
		public static void SortSumSalesInDescendingOrder()
		{
			try
			{
				repo.VisualAnalyticsTestSort.SortDescendingInfo.WaitForItemExists(200000);
				repo.VisualAnalyticsTestSort.SortDescending.ClickThis();
				Reports.ReportLog("SortSumSalesInDescendingOrder", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SortSumSalesInDescendingOrder" + ex.Message);
			}
		}
		
		public static void ValidateDescendingChart()
		{
			try
			{
				if(repo.VisualAnalyticsTestSort.DescendingInfo.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestSort.DescendingInfo.GetDescending();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestSort.DescendingInfo;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateDescendingChart data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateDescendingChart", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateDescendingChart :" +ex.Message);
			}
		}
		
		public static void NavigateToWorksheet2()
		{
			try
			{
				repo.VisualAnalyticsTestSort.Worksheet2Info.WaitForItemExists(30000);
				repo.VisualAnalyticsTestSort.Worksheet2.ClickThis();
				Reports.ReportLog("NavigateToWorksheet2", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : NavigateToWorksheet2" + ex.Message);
			}
		}
		
		public static void ValidateAscendingWorksheet4Chart()
		{
			try
			{
				if(repo.VisualAnalyticsTestSort.AscendingWorksheetInfo.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestSort.AscendingWorksheetInfo.GetAscending();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestSort.AscendingWorksheetInfo;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateAscendingWorksheet4Chart data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateAscendingWorksheet4Chart", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateAscendingWorksheet4Chart :" +ex.Message);
			}
		}
		
		public static void ValidateArrowSheetChart()
		{
			try
			{
				if(repo.VisualAnalyticsTestSort.CheckArrowTestInfo.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestSort.CheckArrowTestInfo.GetArrowSheet();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestSort.CheckArrowTestInfo;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateArrowSheetChart data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateArrowSheetChart", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateArrowSheetChart :" +ex.Message);
			}
		}
		
		public static void NavigateToWorksheet4()
		{
			try
			{
				repo.VisualAnalyticsTestSort.Worksheet4Info.WaitForItemExists(30000);
				repo.VisualAnalyticsTestSort.Worksheet4.ClickThis();
				Reports.ReportLog("NavigateToWorksheet4", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : NavigateToWorksheet4" + ex.Message);
			}
		}
		
		public static void ClearSorts()
		{
			try
			{
				repo.VisualAnalyticsTestSort.WorksheetInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestSort.Worksheet.ClickThis();
				System.Threading.Thread.Sleep(1000);
				repo.SunAwtWindow0.ClearInfo.WaitForItemExists(30000);
				repo.SunAwtWindow0.Clear.ClickThis();
				repo.SunAwtWindow1.SortsInfo.WaitForItemExists(30000);
				repo.SunAwtWindow1.Sorts.ClickThis();
				Reports.ReportLog("ClearSorts", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClearSorts" + ex.Message);
			}
		}
		
		public static void SelectPie()
		{
			try
			{
				repo.VisualAnalyticsTestSort.MarkChartTypeSelectorDollar1Info.WaitForItemExists(200000);
				repo.VisualAnalyticsTestSort.MarkChartTypeSelectorDollar1.ClickThis();
				
				repo.SunAwtWindow0.ListItemPieInfo.WaitForItemExists(200000);
				repo.SunAwtWindow0.ListItemPie.ClickThis();
				Reports.ReportLog("SelectPie", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectPie" + ex.Message);
			}
		}
		
		public static void DragProductCategoryToColor()
		{
			try
			{
				repo.VisualAnalyticsTestSort.ProductSubCategory.MoveTo("83;11");
				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
				
				repo.VisualAnalyticsTestSort.ProductSubCategory.MoveTo("91;3");
				
				repo.VisualAnalyticsTestSort.Color.MoveTo("21;13");
				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				
				Reports.ReportLog("DragProductCategoryToColor", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragProductCategoryToColor" + ex.Message);
			}
		}
		
		public static void CloseViz()
		{
			try
			{
				repo.VisualAnalyticsTestSort.CloseVizInfo.WaitForItemExists(200000);
				repo.VisualAnalyticsTestSort.CloseViz.ClickThis();
				Reports.ReportLog("CloseViz", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CloseViz" + ex.Message);
			}
		}
		
		public static void OpenAdvanceProperties()
		{
			try
			{
				repo.VisualAnalyticsTestSort.ProductSubCategoryInfo.WaitForItemExists(200000);
				repo.VisualAnalyticsTestSort.ProductSubCategory.Click("105;10");
				
				repo.VisualAnalyticsTestSort.ProductSubCategory.Click(System.Windows.Forms.MouseButtons.Right, "105;10");
				
				repo.SunAwtWindow0.SortInfo.WaitForItemExists(200000);
				repo.SunAwtWindow0.Sort.ClickThis();
				
				repo.SunAwtWindow1.AdvancedInfo.WaitForItemExists(200000);
				repo.SunAwtWindow1.Advanced.ClickThis();
				Reports.ReportLog("OpenAdvanceProperties", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : OpenAdvanceProperties" + ex.Message);
			}
		}
		
		public static void SelectFieldOptions()
		{
			try
			{
				repo.SortProductSubCategory.FieldInfo.WaitForItemExists(200000);
				repo.SortProductSubCategory.Field.ClickThis();
				
				repo.SortProductSubCategory.ButtonOKInfo.WaitForItemExists(200000);
				repo.SortProductSubCategory.ButtonOK.ClickThis();
				Reports.ReportLog("SelectFieldOptions", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectFieldOptions" + ex.Message);
			}
		}
		
		public static void SelectPerCellByMeasureValues()
		{
			try
			{
				repo.VisualAnalyticsTestSort.CustomerSegmentInfo.WaitForItemExists(200000);
				repo.VisualAnalyticsTestSort.CustomerSegment.Click(System.Windows.Forms.MouseButtons.Right, "89;11");
				
				repo.SunAwtWindow0.SortInfo.WaitForItemExists(2000000);
				repo.SunAwtWindow0.Sort.ClickThis();
				
				repo.SunAwtWindow1.AdvancedInfo.WaitForItemExists(2000000);
				repo.SunAwtWindow1.Advanced.ClickThis();
				
				repo.SortCustomerSegment.CPanel.PerCellByMeasureValuesInfo.WaitForItemExists(200000);
				repo.SortCustomerSegment.CPanel.PerCellByMeasureValues.ClickThis();
				
				repo.SortCustomerSegment.CPanel.ButtonOKInfo.WaitForItemExists(200000);
				repo.SortCustomerSegment.CPanel.ButtonOK.ClickThis();

				Reports.ReportLog("SelectPerCellByMeasureValues", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectPerCellByMeasureValues" + ex.Message);
			}
		}
		
		public static void SelectDescendingFromAdvanced()
		{
			try
			{
				repo.VisualAnalyticsTestSort.CustomerSegmentInfo.WaitForItemExists(200000);
				repo.VisualAnalyticsTestSort.CustomerSegment.Click(System.Windows.Forms.MouseButtons.Right, "67;7");
				
				repo.SunAwtWindow0.SortInfo.WaitForItemExists(200000);
				repo.SunAwtWindow0.Sort.ClickThis();
				
				repo.SunAwtWindow1.AdvancedInfo.WaitForItemExists(2000000);
				repo.SunAwtWindow1.Advanced.Click("49;10");
				
				repo.SortCustomerSegment.CPanel.DescendingInfo.WaitForItemExists(200000);
				repo.SortCustomerSegment.CPanel.Descending.ClickThis();
				
				repo.SortCustomerSegment.CPanel.ButtonOKInfo.WaitForItemExists(200000);
				repo.SortCustomerSegment.CPanel.ButtonOK.Click("44;11");
				Reports.ReportLog("SelectDescendingFromAdvanced", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectDescendingFromAdvanced" + ex.Message);
			}
		}
		
		public static void CheckArrowTest()
		{
			try
			{
				repo.VisualAnalyticsTestSort.RegionInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestSort.Region.Click(System.Windows.Forms.MouseButtons.Right, "72;6");
				
				repo.SunAwtWindow0.SortInfo.WaitForItemExists(30000);
				repo.SunAwtWindow0.Sort.ClickThis();
				
				repo.SunAwtWindow1.AdvancedInfo.WaitForItemExists(30000);
				repo.SunAwtWindow1.Advanced.ClickThis();
				
				repo.SortRegion.CPanel.ManualInfo.WaitForItemExists(30000);
				repo.SortRegion.CPanel.Manual.ClickThis();
				
				repo.SortRegion.CPanel.DownButtonInfo.WaitForItemExists(30000);
				repo.SortRegion.CPanel.DownButton.ClickThis();
				repo.SortRegion.CPanel.DefaultButtonInfo.WaitForItemExists(30000);
				repo.SortRegion.CPanel.DefaultButton.ClickThis();
				repo.SortRegion.CPanel.DefaultButton.ClickThis();
				repo.SortRegion.CPanel.DefaultButton.ClickThis();
				
				repo.SortRegion.CPanel.ButtonOKInfo.WaitForItemExists(30000);
				repo.SortRegion.CPanel.ButtonOK.ClickThis();
				Reports.ReportLog("CheckArrowTest", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CheckArrowTest" + ex.Message);
			}
		}
		
		public static void SortEastWorksheet2Descending()
		{
			try
			{
				repo.VisualAnalyticsTestSort.Worksheet2BIChartOverlayPanelInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestSort.Worksheet2BIChartOverlayPanel.Click("76;163");
				Reports.ReportLog("SortEastWorksheet2Descending", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SortEastWorksheet2Descending" + ex.Message);
			}
		}
		
		public static void SortEast()
		{
			try
			{
				repo.VisualAnalyticsTestSort.BIChartOverlayPanelInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestSort.BIChartOverlayPanel.Click("75;161");
				Reports.ReportLog("SortEastAscending", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SortEastAscending" + ex.Message);
			}
		}
		
		public static void ClearSortTestCase4()
		{
			try
			{
				repo.VisualAnalyticsTestSort.WorksheetInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestSort.Worksheet.ClickThis();
				repo.SunAwtWindow2.ClearInfo.WaitForItemExists(30000);
				repo.SunAwtWindow2.Clear.ClickThis();
				repo.SunAwtWindow1.SortsInfo.WaitForItemExists(30000);
				repo.SunAwtWindow1.Sorts.ClickThis();
				Reports.ReportLog("ClearSort", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClearSort" + ex.Message);
			}
		}
		
		public static void ClearSort()
		{
			try
			{
				repo.VisualAnalyticsTestSort.WorksheetInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestSort.Worksheet.ClickThis();
				repo.SunAwtWindow0.ClearInfo.WaitForItemExists(30000);
				repo.SunAwtWindow0.Clear.ClickThis();
				repo.SunAwtWindow1.SortsInfo.WaitForItemExists(30000);
				repo.SunAwtWindow1.Sorts.ClickThis();
				Reports.ReportLog("ClearSortTestCase4", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClearSortTestCase4" + ex.Message);
			}
		}
		
		public static void SortBookCases()
		{
			try
			{
				repo.VisualAnalyticsTestSort.Worksheet2BIChartOverlayPanelInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestSort.Worksheet2BIChartOverlayPanel.Click("255;350");
				Reports.ReportLog("SortBookCases", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SortBookCases" + ex.Message);
			}
		}
		
		public static void DragProfitToRow()
		{
			try
			{
				repo.VisualAnalyticsTestSort.SUMProfitInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestSort.SUMProfit.RightClickThis();
				repo.SunAwtWindow.AddToRowsDeckInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.AddToRowsDeck.ClickThis();
				Reports.ReportLog("DragProfitToRow", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragProfitToRow" + ex.Message);
			}
		}
		
		public static void SortSUMProfitDescending()
		{
			try
			{
				repo.VisualAnalyticsTestSort.SUMProfitChartOverlayPanelInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestSort.SUMProfitChartOverlayPanel.Click("97;161");
				Reports.ReportLog("SortSUMProfitDescending", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SortSUMProfitDescending" + ex.Message);
			}
		}
		
		public static void SelectTable()
		{
			try
			{
				repo.VisualAnalyticsTestSort.ChartComboInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestSort.ChartCombo.ClickThis();
				repo.SunAwtWindow.TableInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.Table.ClickThis();
				Reports.ReportLog("SelectTable", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectTable" + ex.Message);
			}
		}
		
		public static void SortTableDescending()
		{
			try
			{
				repo.VisualAnalyticsTestSort.PivotTableOverlayPanelInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestSort.PivotTableOverlayPanel.Click("99;163");
				Reports.ReportLog("SortTableDescending", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SortTableDescending" + ex.Message);
			}
		}
		
		public static void SelectSumSalesDifference()
		{
			try
			{
				repo.VisualAnalyticsTestSort.SUMSalesRowsInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestSort.SUMSalesRows.RightClickThis();
				
				repo.SunAwtWindow0.TableCalculationTemplatesInfo.WaitForItemExists(30000);
				repo.SunAwtWindow0.TableCalculationTemplates.ClickThis();
				
				repo.SunAwtWindow1.DifferenceInfo.WaitForItemExists(30000);
				repo.SunAwtWindow1.Difference.ClickThis();
				Reports.ReportLog("SelectSumSalesDifference", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectSumSalesDifference" + ex.Message);
			}
		}
		
		public static void SortBookCasesForTestCases4()
		{
			try
			{
				repo.VisualAnalyticsTestSort.Worksheet1PanelInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestSort.Worksheet1Panel.Click("251;349");
				repo.VisualAnalyticsTestSort.WorksheetPanel1.Click("76;358");
				Reports.ReportLog("SortBookCasesForTestCases4", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SortBookCasesForTestCases4" + ex.Message);
			}
		}
		
		public static void SelectSUMSalesTableDown()
		{
			try
			{
				repo.VisualAnalyticsTestSort.SUMSalesRowsInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestSort.SUMSalesRows.RightClickThis();
				
				repo.SunAwtWindow0.CalculateDifferenceAlongInfo.WaitForItemExists(30000);
				repo.SunAwtWindow0.CalculateDifferenceAlong.ClickThis();
				
				repo.SunAwtWindow1.TableDownInfo.WaitForItemExists(30000);
				repo.SunAwtWindow1.TableDown.ClickThis();
				Reports.ReportLog("SelectSUMSalesTableDown", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectSUMSalesTableDown" + ex.Message);
			}
		}
		
		public static void SortEastDescendingForTestCase4()
		{
			try
			{
				repo.VisualAnalyticsTestSort.Worksheet1PanelInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestSort.Worksheet1Panel.Click("74;160");
				Reports.ReportLog("SortEastDescendingForTestCase4", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SortEastDescendingForTestCase4" + ex.Message);
			}
		}
		
		public static void SortSUMSalesMeasure()
		{
			try
			{
				repo.VisualAnalyticsTestSort.Worksheet4BIChartOverlayPanelInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestSort.Worksheet4BIChartOverlayPanel.Click("917;456");
				Reports.ReportLog("SortSUMSalesMeasure", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SortSUMSalesMeasure" + ex.Message);
			}
		}
		
		public static void NavigateToWorksheet3()
		{
			try
			{
				repo.VisualAnalyticsTestSort.Worksheet3TabInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestSort.Worksheet3Tab.ClickThis();
				Reports.ReportLog("NavigateToWorksheet3", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : NavigateToWorksheet3" + ex.Message);
			}
		}
		
		public static void SortAscendingFurniture()
		{
			try
			{
				repo.VisualAnalyticsTestSort.Worksheet3BIChartOverlayPanelInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestSort.Worksheet3BIChartOverlayPanel.MoveTo("196;32");
				repo.SunAwtWindow.AscendingButtonInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.AscendingButton.ClickThis();
				Reports.ReportLog("SortAscendingFurniture", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SortAscendingFurniture" + ex.Message);
			}
		}
		
		public static void SelectColsAdvancedSort()
		{
			try
			{
				repo.VisualAnalyticsTestSort.ProductSubCategoryWorksheet3Info.WaitForItemExists(30000);
				repo.VisualAnalyticsTestSort.ProductSubCategoryWorksheet3.RightClickThis();
				repo.SunAwtWindow.SortInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.Sort.ClickThis();
				repo.SunAwtWindow.AdvancedInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.Advanced.ClickThis();
				repo.SortProductSubCategory1.ButtonOKInfo.WaitForItemExists(30000);
				repo.SortProductSubCategory1.ButtonOK.ClickThis();
				Reports.ReportLog("SelectColsAdvancedSort", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectColsAdvancedSort" + ex.Message);
			}
		}
		
		public static void SwapRowsAndColumns()
		{
			try
			{
				repo.VisualAnalyticsTestSort.SwapButtonInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestSort.SwapButton.ClickThis();
				Reports.ReportLog("SwapRowsAndColumns", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SwapRowsAndColumns" + ex.Message);
			}
		}
		
		public static void SelectRowsAdvancedSort()
		{
			try
			{
				repo.VisualAnalyticsTestSort.RowProductSubCategoryInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsTestSort.RowProductSubCategory.RightClickThis();
				repo.SunAwtWindow.SortInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.Sort.ClickThis();
				repo.SunAwtWindow.AdvancedInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.Advanced.ClickThis();
				repo.SortProductSubCategory1.ButtonOKInfo.WaitForItemExists(30000);
				repo.SortProductSubCategory1.ButtonOK.ClickThis();
				Reports.ReportLog("SelectRowsAdvancedSort", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectRowsAdvancedSort" + ex.Message);
			}
		}
		
		public static void ValidateEastAscendingChart()
		{
			try
			{
				if(repo.VisualAnalyticsTestSort.EastAscendingInfo.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestSort.EastAscendingInfo.GetEastAscending();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestSort.EastAscendingInfo;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateEastAscendingChart data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateEastAscendingChart", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateEastAscendingChart :" +ex.Message);
			}
		}
		
		public static void ValidateEastDefaultChart()
		{
			try
			{
				if(repo.VisualAnalyticsTestSort.EastDefaultInfo.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestSort.EastDefaultInfo.GetEastDefault();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestSort.EastDefaultInfo;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateEastDefaultChart data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateEastDefaultChart", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateEastDefaultChart :" +ex.Message);
			}
		}
		
		public static void SortBookCasesVeritical()
		{
			try
			{
				repo.VisualAnalyticsTestSort.BookCasesBIChartOverlayPanel.Click("253;352");
				Reports.ReportLog("SortBookCases", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SortBookCases" + ex.Message);
			}
		}
		
		public static void ValidateBookCasesDescending()
		{
			try
			{
				if(repo.VisualAnalyticsTestSortValidation.BookCasesDescendingInfo.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestSortValidation.BookCasesDescendingInfo.GetBookCasesDescending();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestSortValidation.BookCasesDescendingInfo;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateEastDefaultChart data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateBookCasesDescending", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateBookCasesDescending :" +ex.Message);
			}
		}
		
		public static void ValidateBookCasesAscending()
		{
			try
			{
				if(repo.VisualAnalyticsTestSortValidation.BookCasesAscendingInfo.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestSortValidation.BookCasesAscendingInfo.GetBookCasesAscending();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestSortValidation.BookCasesAscendingInfo;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateBookCasesAscending data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateBookCasesAscending", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateBookCasesAscending :" +ex.Message);
			}
		}
		
		public static void ValidateBookCasesDefault()
		{
			try
			{
				if(repo.VisualAnalyticsTestSortValidation.BookCasesDefaultInfo.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestSortValidation.BookCasesDefaultInfo.GetBookCaseDefault();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestSortValidation.BookCasesDefaultInfo;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateBookCasesDefault data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateBookCasesDefault", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateBookCasesDefault :" +ex.Message);
			}
		}
		
		public static void ValidateEastWorssheet2Descending()
		{
			try
			{
				if(repo.VisualAnalyticsTestSortValidation.EastWorsheet2DescendingInfo.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestSortValidation.EastWorsheet2DescendingInfo.GetEastWorksheet2Descending();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestSortValidation.EastWorsheet2DescendingInfo;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateEastWorssheet2Descending data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateEastWorssheet2Descending", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateEastWorssheet2Descending :" +ex.Message);
			}
		}
		
		public static void ValidateBookCasesWorssheet2Descending()
		{
			try
			{
				if(repo.VisualAnalyticsTestSortValidation.BookCasesWorksheet2DescendingInfo.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestSortValidation.BookCasesWorksheet2DescendingInfo.GetBookCasesWorksheet2Descending();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestSortValidation.BookCasesWorksheet2DescendingInfo;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateBookCasesWorssheet2Descending data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateBookCasesWorssheet2Descending", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateBookCasesWorssheet2Descending :" +ex.Message);
			}
		}
		
		public static void ValidateSUMSalesDescending()
		{
			try
			{
				if(repo.VisualAnalyticsTestSortValidation.SUMSalesDescendingInfo.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestSortValidation.SUMSalesDescendingInfo.GetSUMSalesDescending();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestSortValidation.SUMSalesDescendingInfo;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateSUMSalesDescending data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateSUMSalesDescending", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateSUMSalesDescending :" +ex.Message);
			}
		}
		
		public static void ValidateTableDescending()
		{
			try
			{
				if(repo.VisualAnalyticsTestSortValidation.TableDescendingInfo.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestSortValidation.TableDescendingInfo.GetTableDescending();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestSortValidation.TableDescendingInfo;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateTableDescending data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateTableDescending", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateTableDescending :" +ex.Message);
			}
		}
		
		public static void ValidateDifferenceChart()
		{
			try
			{
				if(repo.VisualAnalyticsTestSortValidation.DifferenceChartInfo.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestSortValidation.DifferenceChartInfo.GetDifferenceChart();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestSortValidation.DifferenceChartInfo;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateDifferenceChart data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateDifferenceChart", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateDifferenceChart :" +ex.Message);
			}
		}
		
		public static void ValidateBookCasesTestCase4()
		{
			try
			{
				if(repo.VisualAnalyticsTestSortValidation.BookCasesTestCase4Info.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestSortValidation.BookCasesTestCase4Info.GetBookCasesTestCase4();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestSortValidation.BookCasesTestCase4Info;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateBookCasesTestCase4 data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateBookCasesTestCase4", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateBookCasesTestCase4 :" +ex.Message);
			}
		}
		
		public static void ValidateTableDown()
		{
			try
			{
				if(repo.VisualAnalyticsTestSortValidation.TableDownInfo.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestSortValidation.TableDownInfo.GetTableDown();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestSortValidation.TableDownInfo;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateTableDown data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateTableDown", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateTableDown :" +ex.Message);
			}
		}
		
		public static void ValidateEastSortTestCase4()
		{
			try
			{
				if(repo.VisualAnalyticsTestSortValidation.EastSortTestCases4Info.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestSortValidation.EastSortTestCases4Info.GetEastSortTestCases4();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestSortValidation.EastSortTestCases4Info;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateEastSortTestCase4 data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateEastSortTestCase4", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateEastSortTestCase4 :" +ex.Message);
			}
		}
		
		public static void ValidateSumSalesDescendingWorksheet4()
		{
			try
			{
				if(repo.VisualAnalyticsTestSortValidation.SumSalesDescendingWorksheet4Info.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestSortValidation.SumSalesDescendingWorksheet4Info.GetSumSalesDescensingWorksheet4();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestSortValidation.SumSalesDescendingWorksheet4Info;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateSumSalesDescendingWorksheet4 data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateSumSalesDescendingWorksheet4", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateSumSalesDescendingWorksheet4 :" +ex.Message);
			}
		}
		
		public static void ValidateSumSalesAscendingWorksheet4()
		{
			try
			{
				if(repo.VisualAnalyticsTestSortValidation.SumSalesAscendingWorksheet4Info.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestSortValidation.SumSalesAscendingWorksheet4Info.GetSumSalesAscendingWorksheet4();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestSortValidation.SumSalesAscendingWorksheet4Info;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateSumSalesAscendingWorksheet4 data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateSumSalesAscendingWorksheet4", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateSumSalesAscendingWorksheet4 :" +ex.Message);
			}
		}
		
		public static void ValidateSumSalesDefaultWorksheet4()
		{
			try
			{
				if(repo.VisualAnalyticsTestSortValidation.SumSalesDefaultWorksheet4Info.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestSortValidation.SumSalesDefaultWorksheet4Info.GetSumSalesDefaultWorksheet4();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestSortValidation.SumSalesDefaultWorksheet4Info;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateSumSalesDefaultWorksheet4 data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateSumSalesDefaultWorksheet4", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateSumSalesDefaultWorksheet4 :" +ex.Message);
			}
		}
		
		public static void ValidateFurnitureAscending()
		{
			try
			{
				if(repo.VisualAnalyticsTestSortValidation.SortAscendingFurnitureInfo.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestSortValidation.SortAscendingFurnitureInfo.GetSortAscendingFurniture();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestSortValidation.SortAscendingFurnitureInfo;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateFurnitureAscending data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateFurnitureAscending", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateFurnitureAscending :" +ex.Message);
			}
		}
		
		public static void ValidateSwapRowsAndColumn()
		{
			try
			{
				if(repo.VisualAnalyticsTestSortValidation.SwapRowsAndColumnInfo.Exists())
				{
					CompressedImage tableChart = repo.VisualAnalyticsTestSortValidation.SwapRowsAndColumnInfo.GetSwapRowsAndColumn();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = Configuration.Config.SIMILARITY;
					RepoItemInfo info = repo.VisualAnalyticsTestSortValidation.SwapRowsAndColumnInfo;
					System.Threading.Thread.Sleep(5000);
					Validate.ContainsImage(info, tableChart, options, "ValidateSwapRowsAndColumn data image comparision", false);
				}
				else
				{
					Reports.ReportLog("ValidateSwapRowsAndColumn", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ValidateSwapRowsAndColumn :" +ex.Message);
			}
		}
		
		public static void CloseOnVisualAnalyticsError()
		{
			if(repo.VisualAnalyticsTestSort.SelfInfo.Exists(5000))
				repo.VisualAnalyticsTestSort.Self.Close();
		}
		
		public static void CloseOnOpenFileError()
		{
			if(TC10589Repo.Open.SelfInfo.Exists(5000))
				TC10589Repo.Open.Self.Close();
		}
	}
}
