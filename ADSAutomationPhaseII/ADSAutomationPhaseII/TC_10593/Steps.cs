﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

using WinForms = System.Windows.Forms;
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Preconditions;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Repository;
using Ranorex.Core.Testing;

namespace ADSAutomationPhaseII.TC_10593
{
	public static class Steps
	{
		public static TC10593Repo repo = TC10593Repo.Instance;
		public static string TC_10593_PATH = System.Configuration.ConfigurationManager.AppSettings["TC_10593"].ToString();
		
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
				repo.DataStudio.OpenFileInfo.WaitForItemExists(1000);
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
				repo.OpenWindow.FilePathTextbox.TextBoxText(TC_10593_PATH + "Sample_Data_Source_Funnel_Chart.vizx");
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
				repo.OpenWindow.OpenButtonInfo.WaitForItemExists(30000);
				repo.OpenWindow.OpenButton.ClickThis();
				System.Threading.Thread.Sleep(500);
				repo.VAWindow.Self.Maximize();
				Reports.ReportLog("ClickonOpenButton", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonOpenButton : " + ex.Message);
			}
		}
		
		public static void ValidateFunnelMapFile()
		{
			try
			{
				repo.VAWindow.Self.Maximize();
				if(repo.VAWindow.VisualizationWindowInfo.Exists())
				{
					CompressedImage FunnelMap = repo.VAWindow.VisualizationWindowInfo.GetFunnelMap();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					RepoItemInfo info = repo.VAWindow.VisualizationWindowInfo;
					options.Similarity = 0.75f;
					System.Threading.Thread.Sleep(1000);
					Validate.ContainsImage(info, FunnelMap, options, "Tree map image data validation", false);	
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateFunnelMapFile : " + ex.Message);
			}
		}
		
		public static void ClickonWorkSheet()
		{
			try
			{
				//repo.VAWindow.Self.Maximize();
				repo.VAWindow.WorkSheetInfo.WaitForItemExists(10000);
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
		
		public static void SelectEntireWindow()
		{
			try
			{
				repo.VAWindow.StandardComboInfo.WaitForItemExists(30000);
				repo.VAWindow.StandardCombo.Click();
				repo.SunAwtWindow.EntireWindowInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.EntireWindow.ClickThis();
				Reports.ReportLog("SelectEntireWindow", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectEntireWindow : " + ex.Message);
			}
		}
		
		public static void DragStagetoColumn()
		{
			try
			{
				repo.VAWindow.ContainerContentPanel.StageInfo.WaitForItemExists(5000);
				repo.VAWindow.ContainerContentPanel.Stage.ClickThis();
				repo.VAWindow.ContainerContentPanel.Stage.RightClick();
				repo.SunAwtWindow.AddToColumnsDeckInfo.WaitForItemExists(5000);
				repo.SunAwtWindow.AddToColumnsDeck.ClickThis();
				Reports.ReportLog("DragStagetoColumn", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragStagetoColumn : " + ex.Message);
			}
		}
		
		public static void ValidationAfterDragStagetoColumn()
		{
			try
			{
				repo.VAWindow.Self.Maximize();
				if(repo.VAWindow.VisualizationWindowInfo.Exists())
				{
					CompressedImage FunnelMap = repo.VAWindow.VisualizationWindowInfo.GetDragStagetoColumn();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = 0.75f;
					RepoItemInfo info = repo.VAWindow.VisualizationWindowInfo;
					Validate.ContainsImage(info, FunnelMap, options, "After Drag Stage to Column image data validation", false);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidationAfterDragStagetoColumn : " + ex.Message);
			}
		}
		
		public static void DragAPACtoRow()
		{
			try
			{
				repo.VAWindow.ContainerContentPanel.SUMAPACInfo.WaitForItemExists(5000);
				repo.VAWindow.ContainerContentPanel.SUMAPAC.ClickThis();
				repo.VAWindow.ContainerContentPanel.SUMAPAC.RightClick();
				repo.SunAwtWindow.AddToRowsDeck.ClickThis();
				Reports.ReportLog("DragAPACtoRow", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragAPACtoRow : " + ex.Message);
			}
		}
		
		public static void ValidationAfterDragAPACtoColumn()
		{
			try
			{
				if(repo.VAWindow.VisualizationWindowInfo.Exists())
				{
					CompressedImage FunnelMap = repo.VAWindow.VisualizationWindowInfo.GetDragAPACtoRow();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = 0.75f;
					RepoItemInfo info = repo.VAWindow.VisualizationWindowInfo;
					bool isvalid = Validate.ContainsImage(info, FunnelMap, options, "After drag APAC to row image data validation", false);
					Reports.ReportLog("ValidationAfterDragAPACtoColumn", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidationAfterDragAPACtoColumn : " + ex.Message);
			}
		}
		
		public static void ClickonVisualization()
		{
			try
			{
				repo.VAWindow.VisualizationInfo.WaitForItemExists(10000);
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
				repo.VAWindow.Visualization1Info.WaitForItemExists(30000);
				repo.VAWindow.Visualization1.ClickThis();
				Reports.ReportLog("DeselectVisualization", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DeselectVisualization : " + ex.Message);
			}
		}
		
		public static void ClickonFunnelIcon()
		{
			try
			{
				repo.VAWindow.FunnelInfo.WaitForItemExists(10000);
				repo.VAWindow.Funnel.ClickThis();
				Reports.ReportLog("ClickonFunnelIcon", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonFunnelIcon : " + ex.Message);
			}
		}
		
		public static void ValidationAfterClickonFunnelIcon()
		{
			try
			{
				if(repo.VAWindow.VisualizationWindowInfo.Exists())
				{
					CompressedImage FunnelMap = repo.VAWindow.VisualizationWindowInfo.GetFunnelIcon();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = 0.75f;
					RepoItemInfo info = repo.VAWindow.VisualizationWindowInfo;
					bool isvalid = Validate.ContainsImage(info, FunnelMap, options, "After Click on Funnel Icon image data validation", false);
					Reports.ReportLog("ValidationAfterClickonFunnelIcon", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidationAfterClickonFunnelIcon : " + ex.Message);
			}
		}
		
		public static void ClickonLabel()
		{
			try
			{
				repo.VAWindow.LabelInfo.WaitForItemExists(10000);
				repo.VAWindow.Label.ClickThis();
				Reports.ReportLog("ClickonLabel", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonLabel : " + ex.Message);
			}
		}
		
		public static void SelectShowMeasurePercentage()
		{
			try
			{
				repo.Datastudio1.ShowMeasurePercentageInfo.WaitForItemExists(10000);
				repo.Datastudio1.ShowMeasurePercentage.ClickThis();
				Reports.ReportLog("SelectShowMeasurePercentage", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectShowMeasurePercentage : " + ex.Message);
			}
		}
		
		public static void ValidationAfterClickonMeasurePercentage()
		{
			try
			{
				if(repo.VAWindow.VisualizationWindowInfo.Exists())
				{
					CompressedImage FunnelMap = repo.VAWindow.VisualizationWindowInfo.GetShowMeasurePercentage();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = 0.75f;
					RepoItemInfo info = repo.VAWindow.VisualizationWindowInfo;
					bool isvalid = Validate.ContainsImage(info, FunnelMap, options, "After Click on Measure Percentage image data validation", false);
					Reports.ReportLog("ValidationAfterClickonMeasurePercentage", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidationAfterClickonMeasurePercentage : " + ex.Message);
			}
		}
		
		public static void ClickonOptions()
		{
			try
			{
				repo.VAWindow.OptionsInfo.WaitForItemExists(10000);
				repo.VAWindow.Options.ClickThis();
				Reports.ReportLog("ClickonOptions", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonOptions : " + ex.Message);
			}
		}
		
		public static void SelectPyramid()
		{
			try
			{
				repo.Datastudio1.PyramidInfo.WaitForItemExists(10000);
				repo.Datastudio1.Pyramid.Click();
				Reports.ReportLog("SelectPyramid", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectPyramid : " + ex.Message);
			}
		}
		
		public static void ValidationAfterClickonPyramidOption()
		{
			try
			{
				if(repo.VAWindow.VisualizationWindowInfo.Exists())
				{
					CompressedImage FunnelMap = repo.VAWindow.VisualizationWindowInfo.GetPyramidOption();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = 0.75f;
					RepoItemInfo info = repo.VAWindow.VisualizationWindowInfo;
					bool isvalid = Validate.ContainsImage(info, FunnelMap, options, "After Click on Pyramid Option image data validation", false);
					Reports.ReportLog("ValidationAfterClickonPyramidOption", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidationAfterClickonPyramidOption : " + ex.Message);
			}
		}
		
		public static void SelectUniformHeight()
		{
			try
			{
				repo.Datastudio1.UniformHeightInfo.WaitForItemExists(10000);
				repo.Datastudio1.UniformHeight.Click();
				Reports.ReportLog("SelectUniformHeight", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectUniformHeight : " + ex.Message);
			}
		}
		
		public static void ValidationAfterClickonUniformHeight()
		{
			try
			{
				if(repo.VAWindow.VisualizationWindowInfo.Exists())
				{
					CompressedImage FunnelMap = repo.VAWindow.VisualizationWindowInfo.GetUniformHeightOption();
					Imaging.FindOptions options = Imaging.FindOptions.Default;
					options.Similarity = 0.75f;
					RepoItemInfo info = repo.VAWindow.VisualizationWindowInfo;
					bool isvalid = Validate.ContainsImage(info, FunnelMap, options, "After Click on Uniform Height image data validation", false);
					Reports.ReportLog("ValidationAfterClickonUniformHeight", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidationAfterClickonUniformHeight : " + ex.Message);
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
					repo.SaveChanges.Discard.ClickThis();
				Reports.ReportLog("DiscardButton", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DiscardButton : " + ex.Message);
			}
		}
		
	}
}
