
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

using WinForms = System.Windows.Forms;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Repository;
using Ranorex.Core.Testing;

using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Preconditions;

namespace ADSAutomationPhaseII.TC_10590
{
	
	public static class Steps
	{
		public static TC10590Repo repo = TC10590Repo.Instance;
		public static string TC_10590_PATH = System.Configuration.ConfigurationManager.AppSettings["TC_10590"].ToString();
		
		#region "TC1"
		
		public static void ClickonFileMenu()
		{
			try
			{
				repo.Application.FileMenuInfo.WaitForItemExists(5000);
				repo.Application.FileMenu.ClickThis();
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
				if(repo.DataStudio.OpenFileInfo.Exists(5000))
				repo.DataStudio.OpenFile.ClickThis();
				else if(repo.OptionsWindow.SelfInfo.Exists(5000))
				{
					repo.OptionsWindow.Cancel.ClickThis();
					repo.Application.FileMenuInfo.WaitForItemExists(3000);
					repo.Application.FileMenu.ClickThis();
					repo.DataStudio.OpenFileInfo.WaitForItemExists(3000);
					repo.DataStudio.OpenFile.ClickThis();
				}
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
				repo.OpenWindow.FilePathTextbox.TextBoxText(TC_10590_PATH + "Sample_Data_Source_Maps.vizx");
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
				repo.OpenWindow.OpenButton.ClickThis();
				System.Threading.Thread.Sleep(500);
				Reports.ReportLog("ClickonOpenButton", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonOpenButton : " + ex.Message);
			}
		}
		
		public static void ValidateSymboMapShape()
		{
			try
			{
				repo.VAWindow.Self.Maximize();
				if(repo.VAWindow.VisualizationWindowInfo.Exists())
				{
					CompressedImage SymboMapShape = repo.VAWindow.VisualizationWindowInfo.GetSymbolMapShape();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = 0.75f;
					RepoItemInfo info = repo.VAWindow.VisualizationWindowInfo;
					bool isvalid = Validate.ContainsImage(info, SymboMapShape, options, "Symbol map shape image data validation", false);
					Reports.ReportLog("ValidateSymboMapShape", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateSymboMapShape : " + ex.Message);
			}
		}
		
		public static void ClickonWorkSheet()
		{
			try
			{
				repo.VAWindow.WorkSheetInfo.WaitForItemExists(30000);
				repo.VAWindow.Self.Maximize();
				repo.VAWindow.WorkSheet.ClickThis();
				Reports.ReportLog("ClickonWorkSheet", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonWorkSheet : " + ex.Message);
			}
		}
		
		public static void SelectNewWorkSheet()
		{
			try
			{
				repo.SunAwtWindow.NewWorkSheetInfo.WaitForItemExists(5000);
				repo.SunAwtWindow.NewWorkSheet.ClickThis();
				Reports.ReportLog("SelectNewWorkSheet", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectNewWorkSheet : " + ex.Message);
			}
		}
		
		public static void DragDimensionstoColumns()
		{
			try
			{
				repo.VAWindow.BIDraggableList1.StateInfo.WaitForItemExists(5000);
				repo.VAWindow.BIDraggableList1.State.ClickThis();
				repo.VAWindow.BIDraggableList1.BIDraggableList.PressKeys("{LControlKey down}");
				repo.VAWindow.BIDraggableList1.ProductCategory.ClickThis();
				repo.VAWindow.BIDraggableList1.ProductCategory.RightClickThis();
				repo.SunAwtWindow.AddToColumnsDeck.ClickThis();
				repo.VAWindow.BIDraggableList1.BIDraggableList.PressKeys("{LControlKey up}");
				Reports.ReportLog("DragDimensionstoColumns", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragDimensionstoColumns : " + ex.Message);
			}
		}
		
		public static void ValidateAfterDragStateandPCtoColumn()
		{
			try
			{
				if(repo.VAWindow.VisualizationWindowInfo.Exists())
				{
					CompressedImage SymboMapShape = repo.VAWindow.VisualizationWindowInfo.GetDragStateandPCtoColumn();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = 0.75f;
					RepoItemInfo info = repo.VAWindow.VisualizationWindowInfo;
					bool isvalid = Validate.ContainsImage(info, SymboMapShape, options, "AfterDragStateandPCtoColumn", false);
					Reports.ReportLog("ValidateAfterDragStateandPCtoColumn", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterDragStateandPCtoColumn : " + ex.Message);
			}
		}
		
		public static void DragMeasurestoRows()
		{
			try
			{
				repo.VAWindow.SUMProfit.ClickThis();
				repo.VAWindow.SUMProfit.RightClickThis();
				repo.SunAwtWindow.AddToRowsDeck.ClickThis();
				Reports.ReportLog("DragMeasurestoRows", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragMeasurestoRows : " + ex.Message);
			}
		}
		
		public static void ValidateAfterDragProfittoRow()
		{
			try
			{
				if(repo.VAWindow.VisualizationWindowInfo.Exists())
				{
					CompressedImage SymboMapShape = repo.VAWindow.VisualizationWindowInfo.GetDragProfittoRow();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = 0.75f;
					RepoItemInfo info = repo.VAWindow.VisualizationWindowInfo;
					bool isvalid = Validate.ContainsImage(info, SymboMapShape, options, "Tree map image data validation", false);
					Reports.ReportLog("ValidateAfterDragProfittoRow", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterDragProfittoRow : " + ex.Message);
			}
		}
		
		public static void ClickonVisualization()
		{
			try
			{
				repo.VAWindow.VisualizationInfo.WaitForItemExists(30000);
				repo.VAWindow.Visualization.ClickThis();
				Reports.ReportLog("ClickonVisualization", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonVisualization : " + ex.Message);
			}
		}
		
		public static void DeselectVisualization()
		{
			try
			{
				repo.VAWindow.Visualization1.ClickThis();
				Reports.ReportLog("DeselectVisualization", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DeselectVisualization : " + ex.Message);
			}
		}
		
		public static void ValidateAfterClickonSymbolMapIcon()
		{
			try
			{
				if(repo.VAWindow.VisualizationWindowInfo.Exists())
				{
					CompressedImage SymboMapShape = repo.VAWindow.VisualizationWindowInfo.GetSymbolMapIcon();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = 0.75f;
					RepoItemInfo info = repo.VAWindow.VisualizationWindowInfo;
					bool isvalid = Validate.ContainsImage(info, SymboMapShape, options, "Tree map image data validation", false);
					Reports.ReportLog("ValidateAfterClickonSymbolMapIcon", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterClickonSymbolMapIcon : " + ex.Message);
			}
		}
		
		public static void ClickonSymbolMapIcon()
		{
			try
			{
				repo.VAWindow.SymbolMapInfo.WaitForItemExists(5000);
				repo.VAWindow.SymbolMap.ClickThis();
				Reports.ReportLog("ClickonSymbolMapIcon", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonSymbolMapIcon : " + ex.Message);
			}
		}
		
		public static void DragProducttoColorDeck()
		{
			try
			{
				repo.VAWindow.ProductCategoryInfo.WaitForItemExists(30000);
				repo.VAWindow.ProductCategory.ClickThis();
				
				repo.VAWindow.ProductCategory.MoveTo("58;6");
				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
				
				repo.VAWindow.ProductCategory.MoveTo("66;-2");
				
				repo.VAWindow.Color.MoveTo("16;29");
				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				
				Reports.ReportLog("DragProducttoColorDeck", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragProducttoColorDeck : " + ex.Message);
			}
		}
		
		public static void ValidateAfterDragPCtoColor()
		{
			try
			{
				if(repo.VAWindow.VisualizationWindowInfo.Exists())
				{
					CompressedImage SymboMapShape = repo.VAWindow.VisualizationWindowInfo.GetDragPCtoColor();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = 0.75f;
					RepoItemInfo info = repo.VAWindow.VisualizationWindowInfo;
					bool isvalid = Validate.ContainsImage(info, SymboMapShape, options, "Tree map image data validation", false);
					Reports.ReportLog("ValidateAfterDragPCtoColor", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterDragPCtoColor : " + ex.Message);
			}
		}
		
		public static void ClickonShape()
		{
			try
			{
				repo.VAWindow.ShapeInfo.WaitForItemExists(30000);
				repo.VAWindow.Shape.ClickThis();
				Reports.ReportLog("ClickonShape", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonShape : " + ex.Message);
			}
		}
		
		public static void ChangetoTriangleShape()
		{
			try
			{
				repo.Datastudio1.TriangleShapeInfo.WaitForItemExists(30000);
				repo.Datastudio1.TriangleShape.ClickThis();
				Reports.ReportLog("ChangetoTriangleShape", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ChangetoTriangleShape : " + ex.Message);
			}
		}
		
		public static void ValidateAfterChangetoTriangeShape()
		{
			try
			{
				if(repo.VAWindow.VisualizationWindowInfo.Exists())
				{
					CompressedImage SymboMapShape = repo.VAWindow.VisualizationWindowInfo.GetChangetoTriangeShape();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = 0.75f;
					RepoItemInfo info = repo.VAWindow.VisualizationWindowInfo;
					bool isvalid = Validate.ContainsImage(info, SymboMapShape, options, "Tree map image data validation", false);
					Reports.ReportLog("ValidateAfterChangetoTriangeShape", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterChangetoTriangeShape : " + ex.Message);
			}
		}
		
		public static void ChangetoCircleShape()
		{
			try
			{
				repo.Datastudio1.CircleInfo.WaitForItemExists(30000);
				repo.Datastudio1.Circle.ClickThis();
				Reports.ReportLog("ChangetoCircleShape", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ChangetoCircleShape : " + ex.Message);
			}
		}
		
		public static void SizeDecrease()
		{
			try
			{
				repo.Datastudio1.JSlider.Click("28;9");
				repo.Datastudio1.JSlider.MoveTo("28;9");
				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
				
				repo.Datastudio1.JSlider.MoveTo("4;12");
				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				
				Reports.ReportLog("SizeDecrease", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SizeDecrease : " + ex.Message);
			}
		}
		
		public static void ValidateAfterDecreaseSize()
		{
			try
			{
				if(repo.VAWindow.VisualizationWindowInfo.Exists())
				{
					CompressedImage SymboMapShape = repo.VAWindow.VisualizationWindowInfo.GetSizeDecrease();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = 0.75f;
					RepoItemInfo info = repo.VAWindow.VisualizationWindowInfo;
					bool isvalid = Validate.ContainsImage(info, SymboMapShape, options, "Tree map image data validation", false);
					Reports.ReportLog("ValidateAfterDecreaseSize", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterDecreaseSize : " + ex.Message);
			}
		}
		
		public static void SizeIncrease()
		{
			try
			{
				repo.Datastudio1.JSliderInfo.WaitForItemExists(5000);
				repo.Datastudio1.JSlider.Click("3;11");
				
				repo.Datastudio1.JSlider.MoveTo("3;11");
				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
				
				repo.Datastudio1.JSlider.MoveTo("198;11");
				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				
//				repo.Datastudio1.JSliderInfo.WaitForItemExists(5000);
//				repo.Datastudio1.JSlider.MoveTo("2;10");
//	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
//
//	            repo.Datastudio1.JSlider.MoveTo("195;12");
//	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				
				Reports.ReportLog("SizeIncrease", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SizeIncrease : " + ex.Message);
			}
		}
		
		public static void ValidateAfterIncreaseSize()
		{
			try
			{
				if(repo.VAWindow.VisualizationWindowInfo.Exists())
				{
					CompressedImage SymboMapShape = repo.VAWindow.VisualizationWindowInfo.GetSizeIncrease();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = 0.75f;
					RepoItemInfo info = repo.VAWindow.VisualizationWindowInfo;
					bool isvalid = Validate.ContainsImage(info, SymboMapShape, options, "Tree map image data validation", false);
					Reports.ReportLog("ValidateAfterIncreaseSize", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterIncreaseSize : " + ex.Message);
			}
		}
		
		public static void ClickonSize()
		{
			try
			{
				repo.VAWindow.Size.ClickThis();
				Reports.ReportLog("ClickonSize", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonSize : " + ex.Message);
			}
		}
		
		public static void ClickonProductItem()
		{
			try
			{
				repo.VAWindow.ContainerCanvasInfo.WaitForItemExists(30000);
				repo.VAWindow.ContainerCanvas.Click("510;296");
				System.Threading.Thread.Sleep(30000);
				Reports.ReportLog("ClickonProductItem", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonProductItem : " + ex.Message);
			}
		}
		
		public static void CloseVAWindow()
		{
			try
			{
				repo.VAWindow.CloseInfo.WaitForItemExists(30000);
				repo.VAWindow.Close.ClickThis();
				Reports.ReportLog("CloseVAWindow", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
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
				if(repo.SaveChanges.DiscardInfo.Exists(5000))
				{
					repo.SaveChanges.Discard.ClickThis();
					Reports.ReportLog("DiscardButton", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DiscardButton : " + ex.Message);
			}
		}
		
		#endregion
		
		#region "TC2"
		
		public static void DragDimensionstoColumns1()
		{
			try
			{
				repo.VAWindow.BIDraggableList1.LongitudeInfo.WaitForItemExists(20000);
				repo.VAWindow.BIDraggableList1.Longitude.ClickThis();
				repo.VAWindow.BIDraggableList1.BIDraggableList.PressKeys("{LControlKey down}");
				repo.VAWindow.BIDraggableList1.Latitude.ClickThis();
				repo.VAWindow.BIDraggableList1.Latitude.RightClickThis();
				repo.SunAwtWindow.AddToColumnsDeckInfo.WaitForItemExists(5000);
				repo.SunAwtWindow.AddToColumnsDeck.ClickThis();
				repo.VAWindow.BIDraggableList1.BIDraggableList.PressKeys("{LControlKey up}");
				Reports.ReportLog("DragDimensionstoColumns1", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragDimensionstoColumns1 : " + ex.Message);
			}
		}
		
		public static void ValidateAfterDragDimensionstoColumns1()
		{
			try
			{
				if(repo.VAWindow.VisualizationWindowInfo.Exists())
				{
					CompressedImage SymboMapShape = repo.VAWindow.VisualizationWindowInfo.GetDragLongitudeandLatitudetoColumn();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = 0.75f;
					RepoItemInfo info = repo.VAWindow.VisualizationWindowInfo;
					bool isvalid = Validate.ContainsImage(info, SymboMapShape, options, "Tree map image data validation", false);
					Reports.ReportLog("ValidateAfterDragDimensionstoColumns1", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterDragDimensionstoColumns1 : " + ex.Message);
			}
		}
		
		public static void DragMeasurestoRows1()
		{
			try
			{
				repo.VAWindow.SUMProfitInfo.WaitForItemExists(5000);
				repo.VAWindow.SUMProfit.ClickThis();
				repo.VAWindow.SUMProfit.RightClickThis();
				repo.SunAwtWindow.AddToRowsDeckInfo.WaitForItemExists(5000);
				repo.SunAwtWindow.AddToRowsDeck.ClickThis();
				Reports.ReportLog("DragMeasurestoRows1", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragMeasurestoRows1 : " + ex.Message);
			}
		}
		
		public static void ValidateAfterDragMeasurestoRow1()
		{
			try
			{
				repo.VAWindow.Self.Maximize();
				if(repo.VAWindow.VisualizationWindowInfo.Exists())
				{
					CompressedImage SymboMapShape = repo.VAWindow.VisualizationWindowInfo.GetDragProfit1toRow();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = 0.75f;
					RepoItemInfo info = repo.VAWindow.VisualizationWindowInfo;
					bool isvalid = Validate.ContainsImage(info, SymboMapShape, options, "Tree map image data validation", false);
					Reports.ReportLog("ValidateAfterDragMeasurestoRow1", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterDragMeasurestoRow1 : " + ex.Message);
			}
		}
		
		public static void ValidateAfterClickonSymbolMap()
		{
			try
			{
				if(repo.VAWindow.VisualizationWindowInfo.Exists())
				{
					CompressedImage SymboMapShape = repo.VAWindow.VisualizationWindowInfo.GetSymbolMapShape();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = 0.75f;
					RepoItemInfo info = repo.VAWindow.VisualizationWindowInfo;
					bool isvalid = Validate.ContainsImage(info, SymboMapShape, options, "Tree map image data validation", false);
					Reports.ReportLog("ValidateAfterClickonSymbolMap", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterClickonSymbolMap : " + ex.Message);
			}
		}
		
		public static void ClickonLongitude()
		{
			try
			{
				repo.VAWindow.LongitudeInfo.WaitForItemExists(30000);
				repo.VAWindow.Longitude.Click("100;11");
				Reports.ReportLog("ClickonLongitude", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonLongitude : " + ex.Message);
			}
		}
		
		public static void ShowFilter()
		{
			try
			{
				repo.SunAwtWindow.ShowFilterInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.ShowFilter.ClickThis();
				Reports.ReportLog("ShowFilter", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ShowFilter : " + ex.Message);
			}
		}
		
		public static void ValidateAfterChangetoTriangle1()
		{
			try
			{
				if(repo.VAWindow.VisualizationWindowInfo.Exists())
				{
					CompressedImage SymboMapShape = repo.VAWindow.VisualizationWindowInfo.GetChangetoTriangleShape1();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = 0.75f;
					RepoItemInfo info = repo.VAWindow.VisualizationWindowInfo;
					bool isvalid = Validate.ContainsImage(info, SymboMapShape, options, "Tree map image data validation", false);
					Reports.ReportLog("ValidateAfterChangetoTriangle1", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterChangetoTriangle1 : " + ex.Message);
			}
		}
		
		public static void LatitudeSilderMoves()
		{
			try
			{
				repo.VAWindow.RangeSlider1Info.WaitForItemExists(30000);
				repo.VAWindow.RangeSlider1.Click("4;11");
				
				repo.VAWindow.RangeSlider1.MoveTo("3;12");
				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
				
				repo.VAWindow.RangeSlider1.MoveTo("114;6");
				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				
				repo.VAWindow.RangeSlider1Info.WaitForItemExists(Common.ApplicationOpenWaitTime);
				repo.VAWindow.RangeSlider1.Click("115;9");
				
				repo.VAWindow.RangeSlider1.MoveTo("115;9");
				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
				
				repo.VAWindow.RangeSlider1.MoveTo("10;10");
				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				Reports.ReportLog("LatitudeSilderMoves", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : LatitudeSilderMoves : " + ex.Message);
			}
		}
		
		public static void LongitudeSilderMoves()
		{
			try
			{
				repo.VAWindow.RangeSliderInfo.WaitForItemExists(30000);
				repo.VAWindow.RangeSlider.MoveTo("4;13");
				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
				
				repo.VAWindow.RangeSlider.MoveTo("40;10");
				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				
				repo.VAWindow.RangeSliderInfo.WaitForItemExists(30000);
				repo.VAWindow.RangeSlider.Click("40;10");
					
				repo.VAWindow.RangeSlider.MoveTo("41;11");
				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
				
				repo.VAWindow.RangeSlider.MoveTo("5;13");
				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				Reports.ReportLog("LongitudeSilderMoves", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : LongitudeSilderMoves : " + ex.Message);
			}
		}
		
		public static void ClickonLatitude()
		{
			try
			{
				repo.VAWindow.LatitudeInfo.WaitForItemExists(30000);
				repo.VAWindow.Latitude.Click("97;10");
				Reports.ReportLog("ClickonLatitude", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonLatitude : " + ex.Message);
			}
		}
		
		#endregion
		
		#region "TC3"
		
		public static void ClickonShowStateBorders()
		{
			try
			{
				repo.TabPage.TabContainerInfo.WaitForItemExists(30000);
				repo.TabPage.TabContainer.SelectTab("Map Customization - Show");
				Reports.ReportLog("ClickonShowStateBorders", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonShowStateBorders : " + ex.Message);
			}
		}
		
		public static void SelectCity()
		{
			try
			{
				repo.VAWindow.ContainerMainPanel.GeographyInfo.WaitForItemExists(30000);
				//repo.VAWindow.ContainerMainPanel.Geography.ClickThis();
				repo.VAWindow.ContainerMainPanel.Geography.RightClick();
				repo.AnalysisWindow.GeographicRoleInfo.WaitForItemExists(30000);
				repo.AnalysisWindow.GeographicRole.ClickThis();
				repo.DimensionWindow.CityInfo.WaitForItemExists(30000);
				repo.DimensionWindow.City.ClickThis();
				Reports.ReportLog("SelectCity", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectCity : " + ex.Message);
			}
		}
		
		public static void ClickonOverviewSymbolMap()
		{
			try
			{
				repo.TabPage.TabContainerInfo.WaitForItemExists(30000);
				repo.TabPage.TabContainer.SelectTab("Overview Symbol Map");
				
				Reports.ReportLog("ClickonOverviewSymbolMap", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonOverviewSymbolMap : " + ex.Message);
			}
		}
		
		public static void SelectLatitude()
		{
			try
			{
				repo.VAWindow.ContainerMainPanel.SUMLocationInfo.WaitForItemExists(5000);
				repo.VAWindow.ContainerMainPanel.SUMLocation.ClickThis();
				repo.VAWindow.ContainerMainPanel.SUMLocation.RightClick();
				repo.AnalysisWindow.GeographicRoleInfo.WaitForItemExists(5000);
				repo.AnalysisWindow.GeographicRole.ClickThis();
				repo.DimensionWindow.LatitudeInfo.WaitForItemExists(5000);
				repo.DimensionWindow.Latitude.ClickThis();
				Reports.ReportLog("SelectLatitude", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectLatitude : " + ex.Message);
			}
		}
		
		public static void ClickonCustomizeSymbolMap()
		{
			try
			{
				repo.TabPage.TabContainerInfo.WaitForItemExists(30000);
				repo.TabPage.TabContainer.SelectTab("Customize Symbol Map");
				Reports.ReportLog("ClickonCustomizeSymbolMap", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonCustomizeSymbolMap : " + ex.Message);
			}
		}
		
		public static void ClickonAnalysis()
		{
			try
			{
				repo.VAWindow.AnalysisInfo.WaitForItemExists(30000);
				repo.VAWindow.Analysis.ClickThis();
				Reports.ReportLog("ClickonAnalysis", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonAnalysis : " + ex.Message);
			}
		}
		
		public static void SelectEditlocations()
		{
			try
			{
				repo.AnalysisWindow.MenuItemMapInfo.WaitForItemExists(5000);
				repo.AnalysisWindow.MenuItemMap.ClickThis();
				repo.DimensionWindow.EditLocationsInfo.WaitForItemExists(5000);
				repo.DimensionWindow.EditLocations.ClickThis();
				Reports.ReportLog("SelectEditlocations", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectEditlocations : " + ex.Message);
			}
		}
		
		public static void CheckAmbiguousLocations()
		{
			try
			{
				repo.EditLocations.CPanel.ComboBoxInfo.WaitForItemExists(3000);
				repo.EditLocations.CPanel.ComboBox.ClickThis();
				repo.SunAwtWindow.NoneInfo.WaitForItemExists(3000);
				repo.SunAwtWindow.None.Click();
				repo.EditLocations.CPanel.ApplyInfo.WaitForItemExists(3000);
				repo.EditLocations.CPanel.Apply.ClickThis();
				repo.EditLocations.CPanel.CloseInfo.WaitForItemExists(5000);
				repo.EditLocations.CPanel.Close.ClickThis();
				Reports.ReportLog("CheckAmbiguousLocations", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CheckAmbiguousLocations : " + ex.Message);
			}
		}
		
		public static void ClickonAmbiguousLocations()
		{
			try
			{
				repo.TabPage.TabContainerInfo.WaitForItemExists(30000);
				repo.TabPage.TabContainer.SelectTab("Map Customization - Ambiguous Locations");
				Reports.ReportLog("ClickonAmbiguousLocations", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonAmbiguousLocations : " + ex.Message);
			}
		}
		
		public static void ResolveAmbiguousLocations()
		{
			try
			{
				repo.EditLocations.CPanel.ComboBoxInfo.WaitForItemExists(5000);
				repo.EditLocations.CPanel.ComboBox.ClickThis();
				repo.SunAwtWindow.FixedInfo.WaitForItemExists(5000);
				repo.SunAwtWindow.Fixed.ClickThis();
				repo.EditLocations.ButtonOKInfo.WaitForItemExists(5000);
				repo.EditLocations.ButtonOK.ClickThis();
				Reports.ReportLog("ResolveAmbiguousLocations", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ResolveAmbiguousLocations : " + ex.Message);
			}
		}
		
		public static void BuildSymbolMap()
		{
			try
			{
				repo.TabPage.TabContainerInfo.WaitForItemExists(30000);
				repo.TabPage.TabContainer.SelectTab("Build Symbol Map");
				Reports.ReportLog("BuildSymbolMap", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : BuildSymbolMap : " + ex.Message);
			}
		}
		
		public static void ClickonGeo()
		{
			try
			{
				repo.VAWindow.ContainerMainPanel.TextGeoInfo.WaitForItemExists(5000);
				repo.VAWindow.ContainerMainPanel.TextGeo.ClickThis();
				Reports.ReportLog("ClickonGeo", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonGeo : " + ex.Message);
			}
		}
		
		public static void UncheckShowStateBorder()
		{
			try
			{
				repo.Datastudio1.ShowStateBorderInfo.WaitForItemExists(5000);
				repo.Datastudio1.ShowStateBorder.ClickThis();
				Reports.ReportLog("UncheckShowStateBorder", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : UncheckShowStateBorder : " + ex.Message);
			}
		}
		
		public static void CheckShowStateBorder()
		{
			try
			{
				repo.Datastudio1.ShowStateBorderInfo.WaitForItemExists(5000);
				repo.Datastudio1.ShowStateBorder.ClickThis();
				Reports.ReportLog("CheckShowStateBorder", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CheckShowStateBorder : " + ex.Message);
			}
		}
		
		public static void ValidateAfterClickonShowBoarders()
		{
			try
			{
				if(repo.VAWindow.VisualizationWindowInfo.Exists())
				{
					CompressedImage SymboMapShape = repo.VAWindow.VisualizationWindowInfo.GetShowStateBoarders3();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = 0.75f;
					RepoItemInfo info = repo.VAWindow.VisualizationWindowInfo;
					Validate.ContainsImage(info, SymboMapShape, options, "Tree map image data validation", false);
					Reports.ReportLog("ValidateAfterClickonShowBoarders", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterClickonShowBoarders : " + ex.Message);
			}
		}
		
		public static void ValidateAfterClickonBuildSymbolMap()
		{
			try
			{
				if(repo.VAWindow.VisualizationWindowInfo.Exists())
				{
					CompressedImage SymboMapShape = repo.VAWindow.VisualizationWindowInfo.GetBuildSymbolMap();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = 0.75f;
					RepoItemInfo info = repo.VAWindow.VisualizationWindowInfo;
					bool isvalid = Validate.ContainsImage(info, SymboMapShape, options, "Tree map image data validation", false);
					Reports.ReportLog("ValidateAfterClickonBuildSymbolMap", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterClickonBuildSymbolMap : " + ex.Message);
			}
		}
		
		public static void ValidateAfterClickonCustomizeSymbolMap()
		{
			try
			{
				if(repo.VAWindow.VisualizationWindowInfo.Exists())
				{
					CompressedImage SymboMapShape = repo.VAWindow.VisualizationWindowInfo.GetCustomizeSymbolMap();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = 0.75f;
					RepoItemInfo info = repo.VAWindow.VisualizationWindowInfo;
					bool isvalid = Validate.ContainsImage(info, SymboMapShape, options, "Tree map image data validation", false);
					Reports.ReportLog("ValidateAfterClickonCustomizeSymbolMap", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterClickonCustomizeSymbolMap : " + ex.Message);
			}
		}
		
		public static void ValidateAfterClickonAmbiguousLocations()
		{
			try
			{
				if(repo.VAWindow.VisualizationWindowInfo.Exists())
				{
					CompressedImage SymboMapShape = repo.VAWindow.VisualizationWindowInfo.GetAmbiguousLocations();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = 0.75f;
					RepoItemInfo info = repo.VAWindow.VisualizationWindowInfo;
					bool isvalid = Validate.ContainsImage(info, SymboMapShape, options, "Tree map image data validation", false);
					Reports.ReportLog("ValidateAfterClickonAmbiguousLocations", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterClickonAmbiguousLocations : " + ex.Message);
			}
		}
		
		public static void ValidateAfterUncheckShowStateBorder()
		{
			try
			{
				if(repo.VAWindow.VisualizationWindowInfo.Exists())
				{
					CompressedImage SymboMapShape = repo.VAWindow.VisualizationWindowInfo.GetWithoutBoarders();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = 0.75f;
					RepoItemInfo info = repo.VAWindow.VisualizationWindowInfo;
					bool isvalid = Validate.ContainsImage(info, SymboMapShape, options, "Tree map image data validation", false);
					Reports.ReportLog("ValidateAfterUncheckShowStateBorder", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterUncheckShowStateBorder : " + ex.Message);
			}
		}
		
		#endregion
	}
	
}
