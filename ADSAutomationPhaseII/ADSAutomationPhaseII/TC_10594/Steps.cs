using System;
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

namespace ADSAutomationPhaseII.TC_10594
{
	
	public static class Steps
	{
		public static TC10594Repo repo = TC10594Repo.Instance;
		public static string TC_10594_PATH = System.Configuration.ConfigurationManager.AppSettings["TC1_10594_Path"].ToString();
		public static int waittime = 10000;
		public static void ExplicitWait_1000()
		{
			Thread.Sleep(1000);
		}
		
		public static void ClickonFileMenu()
		{
			try
			{
				repo.Application.FileMenuInfo.WaitForItemExists(waittime);
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
				repo.OpenWindow.FilePathTextbox.TextBoxText(TC_10594_PATH + "Sample_Data_Source_Gauge_Chart.vizx");
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
		
		public static void ClickonWorkSheet()
		{
			try
			{
				repo.VAWindow.SelfInfo.WaitForItemExists(Common.ApplicationOpenWaitTime);
				repo.VAWindow.WorkSheetInfo.WaitForItemExists(waittime);
				repo.VAWindow.Self.Maximize();
				repo.VAWindow.WorkSheet.ClickThis();
				Reports.ReportLog("ClickonWorkSheet", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonWorkSheet : " + ex.Message);
			}
		}
		
		public static void ValidateWorksheetInitialoverlay()
		{
			try
			{
				CompressedImage chart = repo.VisualAnalyticsSampleDataSourceG.PivotTableInitialOverlayInfo.GetWorsheetInitialOverlay();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.50f;
				RepoItemInfo info = repo.VisualAnalyticsSampleDataSourceG.PivotTableInitialOverlayInfo;
				Validate.ContainsImage(info, chart, options, "validate worksheet initial overlay", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateWorksheetInitialoverlay  : " + ex.Message);
			}
		}
		
		
		public static void SelectNewWorkSheet()
		{
			try
			{
				
				if(repo.SunAwtWindow.NewWorkSheetInfo.Exists(waittime))
				{
					repo.SunAwtWindow.NewWorkSheet.ClickThis();
				}
				else
				{
					repo.VAWindow.WorkSheetInfo.WaitForItemExists(Common.ApplicationOpenWaitTime);
					repo.VAWindow.WorkSheet.ClickThis();					
					repo.SunAwtWindow.NewWorkSheetInfo.WaitForItemExists(waittime);
					repo.SunAwtWindow.NewWorkSheet.ClickThis();					
				}					
				
				Reports.ReportLog("SelectNewWorkSheet", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectNewWorkSheet : " + ex.Message);
			}
		}
		
		public static void DragProductCategoryandState_DimentionstoColumns()
		{
			try
			{
				repo.VisualAnalyticsSampleDataSourceG.ContainerMainPanel.ProductCategoryInfo.WaitForItemExists(waittime);
//				repo.VisualAnalyticsSampleDataSourceG.ContainerMainPanel.ProductCategory.Click("58;7");
				repo.VisualAnalyticsSampleDataSourceG.ContainerMainPanel.ProductCategory.RightClickThis();
				repo.SunAwtWindow.AddToColumnsDeckInfo.WaitForItemExists(waittime);
				repo.SunAwtWindow.AddToColumnsDeck.ClickThis();
//				repo.VisualAnalyticsSampleDataSourceG.ContainerMainPanel.ProductCategory.MoveTo("39;7");
//				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
//				
//				repo.VisualAnalyticsSampleDataSourceG.ContainerMainPanel.ProductCategory.MoveTo("47;-1");
//				
//				repo.VisualAnalyticsSampleDataSourceG.ContainerMainPanel.Panel.MoveTo("79;11");
//				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
//				
				repo.VisualAnalyticsSampleDataSourceG.ContainerMainPanel.StateInfo.WaitForItemExists(15000);
				repo.VisualAnalyticsSampleDataSourceG.ContainerMainPanel.State.RightClickThis();
				repo.SunAwtWindow.AddToColumnsDeckInfo.WaitForItemExists(waittime);
				repo.SunAwtWindow.AddToColumnsDeck.ClickThis();
//				repo.VisualAnalyticsSampleDataSourceG.State.Click("49;7");
//				
//				repo.VisualAnalyticsSampleDataSourceG.State.MoveTo("41;8");
//				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
//				
//				repo.VisualAnalyticsSampleDataSourceG.State.MoveTo("49;0");
//				
//				repo.VisualAnalyticsSampleDataSourceG.Panel.MoveTo("210;15");
//				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				
				
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragProductCategoryandState_DimentionstoColumns : " + ex.Message);
			}
		}
		
		public static void ValidateProductCategoryandState_DimentionstoColumns()
		{
			try
			{
				ExplicitWait_1000();
				CompressedImage chart = repo.VisualAnalyticsSampleDataSourceG.PivotTableOverlayPanelInfo.GetDragPCandStatetoColumn11();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalyticsSampleDataSourceG.PivotTableOverlayPanelInfo;
				ExplicitWait_1000();
				Validate.ContainsImage(info, chart, options, "Change Product Category and State Dimentions to Columns", false);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateProductCategoryandState_DimentionstoColumns  : " + ex.Message);
			}
		}
		
		public static void DragProfitMeasuremet()
		{
			try
			{
				repo.VisualAnalyticsSampleDataSourceG.ContainerMainPanel.SUMProfitInfo.WaitForItemExists(waittime);
				repo.VisualAnalyticsSampleDataSourceG.ContainerMainPanel.SUMProfit.RightClickThis();
				repo.SunAwtWindow.AddToRowsDeckInfo.WaitForItemExists(waittime);
				repo.SunAwtWindow.AddToRowsDeck.ClickThis();
//				repo.VisualAnalyticsSampleDataSourceG.ContainerMainPanel.SUMProfit.Click("44;9");
				
//				repo.VisualAnalyticsSampleDataSourceG.ContainerMainPanel.SUMProfit.MoveTo("38;11");
//				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
//				
//				repo.VisualAnalyticsSampleDataSourceG.ContainerMainPanel.SUMProfit.MoveTo("46;3");
//				
//				repo.VisualAnalyticsSampleDataSourceG.ContainerMainPanel.Panel1.MoveTo("82;16");
//				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragProfitMeasuremet : " + ex.Message);
			}
		}
		
		public static void ClickonVisualization()
		{
			try
			{
				repo.VAWindow.VisualizationInfo.WaitForItemExists(waittime);
				repo.VAWindow.Visualization.ClickThis();
				Reports.ReportLog("ClickonVisualization", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonVisualization : " + ex.Message);
			}
		}
		
		public static void ClickonGaugeMapIcon()
		{
			try
			{
				repo.VisualAnalyticsSampleDataSourceG.ButtonInfo.WaitForItemExists(waittime);
				repo.VisualAnalyticsSampleDataSourceG.Button.ClickThis();
				Reports.ReportLog("ClickonGaugeMapIcon", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonGaugeMapIcon : " + ex.Message);
			}
		}
		
		public static void ValidateGaugeMapIcon()
		{
			try
			{
				ExplicitWait_1000();
				CompressedImage chart = repo.VisualAnalyticsSampleDataSourceG.PivotTableOverlayPanelInfo.GetClickonGauge();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalyticsSampleDataSourceG.PivotTableOverlayPanelInfo;
				ExplicitWait_1000();
				Validate.ContainsImage(info, chart, options, "Change PC to Label", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateGaugeMapIcon  : " + ex.Message);
			}
		}
		
		public static void DeselectVisualization()
		{
			try
			{
				repo.VAWindow.Visualization1Info.WaitForItemExists(waittime);
				repo.VAWindow.Visualization1.ClickThis();
				Reports.ReportLog("DeselectVisualization", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DeselectVisualization : " + ex.Message);
			}
		}
		
		public static void DragProductCategoryDimensionsLabel()
		{
			try
			{
				repo.VisualAnalyticsSampleDataSourceG.ProductCategoryInfo.WaitForItemExists(10000);
				repo.VisualAnalyticsSampleDataSourceG.LabelInfo.WaitForItemExists(10000);
				repo.VisualAnalyticsSampleDataSourceG.ProductCategory.DragThisTo(repo.VisualAnalyticsSampleDataSourceG.Label);
//				repo.VisualAnalyticsSampleDataSourceG.ProductCategory.Click("47;10");
				
//				repo.VisualAnalyticsSampleDataSourceG.ProductCategory.MoveTo("46;8");
//				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
//				
//				repo.VisualAnalyticsSampleDataSourceG.ProductCategory.MoveTo("54;0");
//				
//				repo.VisualAnalyticsSampleDataSourceG.Label.MoveTo("26;22");
//				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				

				Reports.ReportLog("DragProductCategoryDimensionsLabel", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragProductCategoryDimensionsLabel : " + ex.Message);
			}
			
		}
		
		public static void ValidateChangePCtoLabel()
		{
			try
			{
				CompressedImage chart = repo.VisualAnalyticsSampleDataSourceG.PivotTableOverlayPanelInfo.GetDragPCtoLabel();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalyticsSampleDataSourceG.PivotTableOverlayPanelInfo;
				ExplicitWait_1000();
				Validate.ContainsImage(info, chart, options, "Change PC to Label", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateChangePCtoLabel  : " + ex.Message);
			}
		}
		
		public static void SelectForegroundAndBackground()
		{
			try
			{
				repo.VisualAnalyticsSampleDataSourceG.LabelInfo.WaitForItemExists(waittime);
				repo.VisualAnalyticsSampleDataSourceG.Label.ClickThis();
				
				repo.DataLableCombobox.BICustomComboBox1Info.WaitForItemExists(waittime);
				repo.DataLableCombobox.BICustomComboBox1.Click();
				
//				repo.EmptyForm.MatchNeedleColorInfo.WaitForItemExists(waittime);
//				repo.EmptyForm.MatchNeedleColor.ClickThis();
				
				Reports.ReportLog("SelectForegroundAndBackground", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectForegroundAndBackground : " + ex.Message);
			}
			
		}
		
		public static void ValidateSelectForegroundAndBackground()
		{
			try
			{
				CompressedImage chart = repo.VisualAnalyticsSampleDataSourceG.PivotTableOverlayPanelInfo.GetSelect_foreground_as_Automatic__background_as_match_needle_colors();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalyticsSampleDataSourceG.PivotTableOverlayPanelInfo;
				ExplicitWait_1000();
				Validate.ContainsImage(info, chart, options, "ChangeSelect Foreground and Background", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateSelectForegroundAndBackground  : " + ex.Message);
			}
		}
		
		public static void ChartPropertiesOptionsRedtoBlue()
			
		{
			try
			{
				repo.VisualAnalyticsSampleDataSourceG.OptionsInfo.WaitForItemExists(waittime);
				repo.VisualAnalyticsSampleDataSourceG.Options.ClickThis();
				
				repo.DataLableCombobox.GaugeOptionsMarkDollar13Info.WaitForItemExists(waittime);
				repo.DataLableCombobox.GaugeOptionsMarkDollar13.ClickThis();
				
//				repo.EmptyForm.AQColorChooserPanelDollarColorButtonInfo.WaitForItemExists(waittime);
//				repo.EmptyForm.AQColorChooserPanelDollarColorButton.ClickThis();
				
				Reports.ReportLog("ChartPropertiesOptionsRedtoBlue", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ChartPropertiesOptionsRedtoBlue : " + ex.Message);
			}
		}
		
		public static void ValidateChartPropertiesOptionsRedtoBlue()
		{
			try
			{
				CompressedImage chart = repo.VisualAnalyticsSampleDataSourceG.PivotTableOverlayPanelInfo.GetChangingColorRedToBlue();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalyticsSampleDataSourceG.PivotTableOverlayPanelInfo;
				ExplicitWait_1000();
				Validate.ContainsImage(info, chart, options, "Change Chart Properties Options from Red to Blue", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateChartPropertiesOptionsRedtoBlue  : " + ex.Message);
			}
		}
		
		public static void ChartOptionValuesforGreenandBlue()
		{
			try
			{
				repo.VisualAnalyticsSampleDataSourceG.OptionsInfo.WaitForItemExists(waittime);
				repo.VisualAnalyticsSampleDataSourceG.Options.ClickThis();
				
				repo.DataLableCombobox.SUMProfit.GaugeOptionsMarkDollar17Info.WaitForItemExists(waittime);
				repo.DataLableCombobox.SUMProfit.GaugeOptionsMarkDollar17.ClickThis();
				
				repo.DataLableCombobox.SUMProfit.GaugeOptionsMarkDollar13Info.WaitForItemExists(waittime);
				repo.DataLableCombobox.SUMProfit.GaugeOptionsMarkDollar13.ClickThis();
				
				repo.DataLableCombobox.SUMProfit.EllipsizableHoverFormattedTextFieldInfo.WaitForItemExists(waittime);
				repo.DataLableCombobox.SUMProfit.EllipsizableHoverFormattedTextField.TextBoxText("10000");
				
				repo.DataLableCombobox.SUMProfit.EllipsizableHoverFormattedTextField1Info.WaitForItemExists(waittime);
				repo.DataLableCombobox.SUMProfit.EllipsizableHoverFormattedTextField1.TextBoxText("5000");
				
				repo.DataLableCombobox.Self.Close();
				
				Reports.ReportLog("ChartOptionValuesforGreenandRed", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			
			catch (Exception ex)
			{
				repo.DataLableCombobox.Self.Close();
				throw new Exception("Failed : ChartOptionValuesforGreenandRed : " + ex.Message);
			}
		}
		
		public static void Chartvalidation()
		{
			try
			{
				repo.VisualAnalyticsSampleDataSourceG.OptionsInfo.WaitForItemExists(waittime);
				repo.VisualAnalyticsSampleDataSourceG.Options.ClickThis();
				
				Validate.IsTrue(repo.Dialog94.BlueColorTextField.TextValue == "5000", "Validation Blue value is 5000", false);
				Validate.IsTrue(repo.Dialog94.GreencolorTextField.TextValue == "10000", "Validation Green value is 10000", false);
				
				Reports.ReportLog("Chartvalidation", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : Chartvalidation : " + ex.Message);
			}
		}
		
		public static void ValidateChartOptionValuesforGreenandBlue()
		{
			try
			{
				CompressedImage chart = repo.VisualAnalyticsSampleDataSourceG.PivotTableOverlayPanelInfo.GetChangecolorBlueandGreen();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalyticsSampleDataSourceG.PivotTableOverlayPanelInfo;
				ExplicitWait_1000();
				Validate.ContainsImage(info, chart, options, "Change Validate Chart Option Values for Green and Red", false);
				
				Reports.ReportLog("ValidateChartOptionValuesforGreenandBlue", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateChartOptionValuesforGreenandBlue  : " + ex.Message);
			}
		}
		public static void CloseVAWindow()
		{
			try
			{
				if(repo.VAWindow.CloseInfo.Exists(5000))
				{
					repo.VAWindow.CloseInfo.WaitForItemExists(waittime);
					repo.VAWindow.Close.ClickThis();
					Reports.ReportLog("CloseVAWindow", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
					DiscardButton();
				}
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
