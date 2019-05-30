using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

using WinForms = System.Windows.Forms;
using System.Windows.Forms;
using ADSAutomationPhaseII.Base;
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Configuration;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Preconditions;
using ADSAutomationPhaseII.TC_10603;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Repository;
using Ranorex.Core.Testing;

namespace ADSAutomationPhaseII.TC_10603
{
	public class Steps
	{
		
		public static TC_10603Repo repo = TC_10603Repo.Instance;
		public static string TC_10603_Path = System.Configuration.ConfigurationManager.AppSettings["TC_10603_Path"].ToString();
		
		
		public static void ExplicitWait()
		{
			System.Threading.Thread.Sleep(500);
		}
		
		public static void ExplicitWait_1000()
		{
			System.Threading.Thread.Sleep(1000);
		}
		
		public static void ExplicitWait_5000()
		{
			System.Threading.Thread.Sleep(5000);
		}
		
		public static void ClickOnFileAndOpenMenus()
		{
			try
			{
				repo.AquaDataStudio.FileMenuInfo.WaitForItemExists(30000);
//				repo.AquaDataStudio.FileMenu.ClickThis();
//				ExplicitWait();
//				repo.SubMenuItems.OpenInfo.WaitForItemExists(30000);
//				repo.SubMenuItems.Open.ClickThis();
//				Reports.ReportLog("ClickOnFileAndOpenMenus", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
				if(repo.AquaDataStudio.FileMenuInfo.Exists(5000))
				{
					ExplicitWait_1000();
					repo.AquaDataStudio.FileMenu.ClickThis();
					ExplicitWait();
					repo.SubMenuItems.OpenInfo.WaitForItemExists(10000);
					if(repo.SubMenuItems.OpenInfo.Exists(5000))
					{
						repo.SubMenuItems.Open.ClickThis();
						Reports.ReportLog("ClickOnFileAndOpenMenus", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
					}
					else
					{
						repo.AquaDataStudio.FileMenuInfo.WaitForItemExists(30000);
						repo.AquaDataStudio.FileMenu.ClickThis();
						ExplicitWait();
						repo.SubMenuItems.OpenInfo.WaitForItemExists(30000);
						if(repo.SubMenuItems.OpenInfo.Exists(5000))
						{
							repo.SubMenuItems.Open.ClickThis();
							Reports.ReportLog("ClickOnFileAndOpenMenus", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
						}
						else
						{
							throw new Exception("Failed : ClickOnFileAndOpenMenus - 'Open' Sub Menu not Found ");
						}
					}
				}
				else
				{
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
				ExplicitWait_1000();
				repo.Open.OpenTextInfo.WaitForItemExists(30000);
				repo.Open.OpenText.TextBoxText(TC_10603_Path + "test-ref-lines.vizx");//Sample_Data_Source_Trend_Lines.vizx
				repo.Open.OpenButton.ClickThis();
				ExplicitWait_1000();
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
				repo.VisualAnalyticsDailog.SelfInfo.WaitForItemExists(30000);
				Thread.Sleep(12000);
				repo.VisualAnalyticsDailog.Self.Maximize();
				Reports.ReportLog("MaximizeVisualAnalyticsWindow", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : MaximizeVisualAnalyticsWindow" +ex.Message);
			}
		}
		
		public static void CreateNewWorksheet()
		{
			try
			{
				ExplicitWait_5000();
				repo.VisualAnalyticsDailog.WorksheetInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsDailog.Worksheet.ClickThis();
				
				if(repo.SubMenuItems.NewWorksheetInfo.Exists(15000)){
					repo.SubMenuItems.NewWorksheet.ClickThis();
				}else{
					repo.VisualAnalyticsDailog.Worksheet.ClickThis();
					if(repo.SubMenuItems.NewWorksheetInfo.Exists(15000)){
						repo.SubMenuItems.NewWorksheet.ClickThis();
					}else{
						Keyboard.Press(System.Windows.Forms.Keys.T | System.Windows.Forms.Keys.Control, Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
					}
				}
				Reports.ReportLog("CreateNewWorksheet", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CreateNewWorksheet" +ex.Message);
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
		
		public static void DragCityToColumnsDeck()
		{
			try
			{
				repo.VisualAnalyticsDailog.CityInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsDailog.City.ClickThis();
				repo.VisualAnalyticsDailog.City.RightClickThis();
				repo.SubMenuItems.AddToColumnsDeckInfo.WaitForItemExists(30000);
				repo.SubMenuItems.AddToColumnsDeck.ClickThis();
				Reports.ReportLog("DragCityToColumnsDeck", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragCityToColumnsDeck" +ex.Message);
			}
		}
		
		public static void DragFreightToRowsDeck()
		{
			try
			{
				repo.VisualAnalyticsDailog.FreightInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsDailog.Freight.ClickThis();
				repo.VisualAnalyticsDailog.Freight.RightClickThis();
				repo.SubMenuItems.AddToRowsDeckInfo.WaitForItemExists(30000);
				repo.SubMenuItems.AddToRowsDeck.ClickThis();
				Reports.ReportLog("DragFreightToRowsDeck", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragFreightToRowsDeck" +ex.Message);
			}
		}
		
		public static void DragProfitToRowsDeck()
		{
			try
			{
				repo.VisualAnalyticsDailog.ProfitInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsDailog.Profit.ClickThis();
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
		
		public static void DragSalesOrderIdToRowsDeck()
		{
			try
			{
				repo.VisualAnalyticsDailog.ContainerLeftPanel.SalesOrderIDInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsDailog.ContainerLeftPanel.SalesOrderID.RightClickThis();
				repo.SubMenuItems.AddToRowsDeckInfo.WaitForItemExists(30000);
				repo.SubMenuItems.AddToRowsDeck.ClickThis();
				Reports.ReportLog("DragSalesOrderIdToRowsDeck", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("DragSalesOrderIdToRowsDeck" +ex.Message);
			}
		}
		
		public static void ClickonVisualizationAndBoxPlotIcon()
		{
			try
			{
				repo.VisualAnalyticsDailog.VisualizationInfo.WaitForItemExists(10000);
				repo.VisualAnalyticsDailog.Visualization.ClickThis();
				if(repo.VisualAnalyticsDailog.BOXPlotIconInfo.Exists(30000))
				{
					repo.VisualAnalyticsDailog.BOXPlotIconInfo.WaitForItemExists(10000);
					repo.VisualAnalyticsDailog.BOXPlotIcon.ClickThis();
				}else{
					repo.VisualAnalyticsDailog.VisualizationInfo.WaitForItemExists(10000);
					repo.VisualAnalyticsDailog.Visualization.ClickThis();
					repo.VisualAnalyticsDailog.BOXPlotIconInfo.WaitForItemExists(10000);
					repo.VisualAnalyticsDailog.BOXPlotIcon.ClickThis();
				}
				repo.VisualAnalyticsDailog.VisualizationIconInfo.WaitForItemExists(10000);
				repo.VisualAnalyticsDailog.VisualizationIcon.ClickThis();
				Reports.ReportLog("ClickonVisualizationAndBoxPlotIcon", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("ClickonVisualizationAndBoxPlotIcon" +ex.Message);
			}
		}
		
		public static void SelectEntireWindow()
		{
			try
			{
				repo.VisualAnalyticsDailog.StandardComboInfo.WaitForItemExists(10000);
				repo.VisualAnalyticsDailog.StandardCombo.Click();
				if(!repo.SubMenuItems.EntireWindowInfo.Exists(10000)){
					repo.VisualAnalyticsDailog.StandardComboInfo.WaitForItemExists(15000);
					repo.VisualAnalyticsDailog.StandardCombo.Click();
				}
				repo.SubMenuItems.EntireWindowInfo.WaitForItemExists(15000);
				repo.SubMenuItems.EntireWindow.ClickThis();
				Reports.ReportLog("SelectEntireWindow", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectEntireWindow : " + ex.Message);
			}
		}
		
		public static void DragTaxAmountToRowsDeck()
		{
			try{
				repo.VisualAnalyticsDailog.TaxAmountInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsDailog.TaxAmount.ClickThis();
				repo.VisualAnalyticsDailog.TaxAmount.RightClickThis();
				repo.SubMenuItems.AddToRowsDeckInfo.WaitForItemExists(30000);
				repo.SubMenuItems.AddToRowsDeck.ClickThis();
				Reports.ReportLog("DragTaxAmountToRowsDeck", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}catch (Exception ex)
			{
				throw new Exception("Failed : DragTaxAmountToRowsDeck" +ex.Message);
			}
		}
		
		public static void ShowTrendLines()
		{
			try
			{
				ExplicitWait_1000();
				repo.VisualAnalyticsDailog.AnalysisInfo.WaitForItemExists(30000);
				
				repo.VisualAnalyticsDailog.Analysis.ClickThis();
				if(repo.SubMenuItems.TrendLinesInfo.Exists(5000)){
					repo.SubMenuItems.TrendLines.ClickThis();
					repo.SubMenuItems.ShowTrendLinesInfo.WaitForItemExists(10000);	
					repo.SubMenuItems.ShowTrendLines.ClickThis();
				}
				else
				{
					repo.VisualAnalyticsDailog.AnalysisInfo.WaitForItemExists(30000);
					repo.VisualAnalyticsDailog.Analysis.ClickThis();
					if(repo.SubMenuItems.TrendLinesInfo.Exists(5000)){
						repo.SubMenuItems.TrendLinesInfo.WaitForItemExists(30000);
						repo.SubMenuItems.TrendLines.ClickThis();
						repo.SubMenuItems.ShowTrendLinesInfo.WaitForItemExists(10000);
						repo.SubMenuItems.ShowTrendLines.ClickThis();						
					}					
				}
//				try{repo.SubMenuItems.TrendLines.ClickThis();} catch{if(repo.VisualAnalyticsDailog.AnalysisInfo.Exists(2000))repo.VisualAnalyticsDailog.Analysis.ClickThis();repo.SubMenuItems.TrendLines.ClickThis();}
				
				Reports.ReportLog("ShowTrendLines" , Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}catch (Exception ex)
			{
				throw new Exception("Failed : ShowTrendLines" +ex.Message);
			}
		}
		
		public static void EditTrendLines()
		{
			try{
//				repo.VisualAnalyticsDailog.AnalysisInfo.WaitForItemExists(30000);
//				repo.VisualAnalyticsDailog.Analysis.ClickThis();
//				ExplicitWait();
//				if(repo.SubMenuItems.TrendLinesInfo.Exists(5000))
//				{
//					repo.SubMenuItems.TrendLinesInfo.WaitForItemExists(30000);
//					repo.SubMenuItems.TrendLines.ClickThis();
//					ExplicitWait();
//					
//					repo.SubMenuItems.EditTrendLinesInfo.WaitForItemExists(30000);
//					repo.SubMenuItems.EditTrendLines.ClickThis();
//				}
//				else{
//					repo.VisualAnalyticsDailog.AnalysisInfo.WaitForItemExists(30000);
//					repo.VisualAnalyticsDailog.Analysis.ClickThis();
//					ExplicitWait();
//					repo.SubMenuItems.TrendLinesInfo.WaitForItemExists(30000);
//					repo.SubMenuItems.TrendLines.ClickThis();
//					ExplicitWait();					
//					
//					repo.SubMenuItems.EditTrendLinesInfo.WaitForItemExists(30000);
//					repo.SubMenuItems.EditTrendLines.ClickThis();
//					
//				}
				
				repo.VisualAnalyticsDailog.AnalysisInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsDailog.Analysis.ClickThis();
				ExplicitWait();
				
				if(!repo.SubMenuItems.TrendLinesInfo.Exists(12000))
				{
					repo.VisualAnalyticsDailog.AnalysisInfo.WaitForItemExists(30000);
					repo.VisualAnalyticsDailog.Analysis.ClickThis();
				}
				repo.SubMenuItems.TrendLines.ClickThis();
				ExplicitWait();
				
				if(!repo.SubMenuItems.EditTrendLines.Enabled)
				{
					repo.SubMenuItems.ShowTrendLinesInfo.WaitForItemExists(10000);
					repo.SubMenuItems.ShowTrendLines.ClickThis();	
					
					repo.VisualAnalyticsDailog.AnalysisInfo.WaitForItemExists(30000);
					repo.VisualAnalyticsDailog.Analysis.ClickThis();
					ExplicitWait();
					
					repo.SubMenuItems.TrendLinesInfo.WaitForItemExists(30000);
					repo.SubMenuItems.TrendLines.ClickThis();
					ExplicitWait();
						
				}
				
				repo.SubMenuItems.EditTrendLinesInfo.WaitForItemExists(30000);
				repo.SubMenuItems.EditTrendLines.ClickThis();
				
				Reports.ReportLog("EditTrendLines", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}catch (Exception ex)
			{
				throw new Exception("Failed : EditTrendLines" +ex.Message);
			}
		}
		
		public static void DescribeTrendModel()
		{
			try{
				repo.VisualAnalyticsDailog.AnalysisInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsDailog.Analysis.ClickThis();
				if(repo.SubMenuItems.TrendLinesInfo.Exists(30000)){
					repo.SubMenuItems.TrendLines.ClickThis();
					repo.SubMenuItems.DescribeTrendModelInfo.WaitForItemExists(30000);
					repo.SubMenuItems.DescribeTrendModel.ClickThis();
				}else{
					repo.VisualAnalyticsDailog.AnalysisInfo.WaitForItemExists(30000);
					repo.VisualAnalyticsDailog.Analysis.ClickThis();
					repo.SubMenuItems.TrendLinesInfo.WaitForItemExists(30000);
					repo.SubMenuItems.TrendLines.ClickThis();
					repo.SubMenuItems.DescribeTrendModelInfo.WaitForItemExists(30000);
					repo.SubMenuItems.DescribeTrendModel.ClickThis();
				}
				Reports.ReportLog("DescribeTrendModel", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}catch (Exception ex)
			{
				throw new Exception("Failed : DescribeTrendModel" +ex.Message);
			}
		}
		
		public static void LinearModelType()
		{
			try{
				repo.TrendOptions.SelfInfo.WaitForItemExists(30000);
				repo.TrendOptions.CPanel.Linear.ClickThis();
				Reports.ReportLog("LinearModelType", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}catch (Exception ex)
			{
				throw new Exception("Failed : LinearModelType" +ex.Message);
			}
		}
		
		public static void LogarithmicModelType(){
			try{
				repo.TrendOptions.SelfInfo.WaitForItemExists(30000);
				repo.TrendOptions.CPanel.Logarithmic.ClickThis();
				Reports.ReportLog("LogarithmicModelType", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}catch (Exception ex)
			{
				throw new Exception("Failed : LogarithmicModelType" +ex.Message);
			}
		}
		
		public static void ExponentialModelType(){
			try{
				repo.TrendOptions.SelfInfo.WaitForItemExists(30000);
				repo.TrendOptions.CPanel.Exponential.ClickThis();
				Reports.ReportLog("ExponentialModelType", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}catch (Exception ex)
			{
				throw new Exception("Failed : ExponentialModelType" +ex.Message);
			}
		}
		
		public static void PolynomialDegreeModelType(string strDegree)
		{
			try{
				repo.TrendOptions.CPanel.PolynomialDegreeInfo.WaitForItemExists(30000);
				repo.TrendOptions.CPanel.PolynomialDegree.ClickThis();
				repo.TrendOptions.CPanel.PolynomialDegreeTxtField.TextBoxText(strDegree);
				Reports.ReportLog("PolynomialDegreeModelType", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}catch (Exception ex)
			{
				throw new Exception("Failed : PolynomialDegreeModelType" +ex.Message);
			}
		}
		
		public static void RecalcTrendlinesBasedonDtSelection()
		{
			try{
				repo.TrendOptions.CPanel.RecalcTrendlinesBasedOnDtSel.CheckboxCheck();
				Reports.ReportLog("RecalcTrendlinesBasedonDtSelection", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}catch (Exception ex)
			{
				throw new Exception("Failed : RecalcTrendlinesBasedonDtSelection" +ex.Message);
			}
		}
		
		public static void ShowConfidenceBands(){
			try{
				repo.TrendOptions.CPanel.ShowConfidenceBandsInfo.WaitForItemExists(30000);
				repo.TrendOptions.CPanel.ShowConfidenceBands.CheckboxCheck();
				Reports.ReportLog("ShowConfidenceBands", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}catch (Exception ex)
			{
				throw new Exception("Failed : ShowConfidenceBands" +ex.Message);
			}
		}
		
		public static void ForceYIntercepttoZero(){
			try{
				repo.TrendOptions.CPanel.ShowConfidenceBandsInfo.WaitForItemExists(30000);
				repo.TrendOptions.CPanel.ShowConfidenceBands.CheckboxUnCheck();
				repo.TrendOptions.CPanel.ForceYInterceptToZero.CheckboxCheck();
				Reports.ReportLog("ForceYIntercepttoZero", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}catch (Exception ex)
			{
				throw new Exception("Failed : ForceYIntercepttoZero" +ex.Message);
			}
		}
		
		public static void BeginTrendatFirstDtPoint()
		{
			try{
				repo.TrendOptions.CPanel.BeginTrendAtFirstDtPoint.ClickThis();
				Reports.ReportLog("BeginTrendatFirstDtPoint", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}catch (Exception ex)
			{
				throw new Exception("Failed : BeginTrendatFirstDtPoint" +ex.Message);
			}
		}
		
		public static void OkButton()
		{
			try{
				repo.TrendOptions.ButtonOKInfo.WaitForItemExists(30000);
				repo.TrendOptions.ButtonOK.ClickThis();
				Reports.ReportLog("OkButton", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}catch (Exception ex)
			{
				throw new Exception("Failed : OkButton" +ex.Message);
			}
		}
		
		public static void DragDropElements(Ranorex.Adapter dragElement, Ranorex.Adapter destinationElement)
		{
			try
			{
				dragElement.DragThisTo(destinationElement);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragDropElements : " +ex.Message);
			}
		}
		
		public static void DragProductCategoryToColumnsDeck()
		{
			try{
				repo.VisualAnalyticsDailog.ProductCategoryInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsDailog.ProductCategory.ClickThis();
				repo.VisualAnalyticsDailog.ProductCategory.RightClickThis();
				repo.SubMenuItems.AddToColumnsDeckInfo.WaitForItemExists(30000);
				repo.SubMenuItems.AddToColumnsDeck.ClickThis();
				Reports.ReportLog("DragProductCategoryToColumnsDeck", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}catch (Exception ex)
			{
				throw new Exception("Failed : DragProductCategoryToColumnsDeck" +ex.Message);
			}
		}
		
		public static void DragTotalDueToRowsDeck()
		{
			try{
				repo.VisualAnalyticsDailog.TotalDueInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsDailog.TotalDue.ClickThis();
				repo.VisualAnalyticsDailog.TotalDue.RightClickThis();
				repo.SubMenuItems.AddToRowsDeckInfo.WaitForItemExists(30000);
				repo.SubMenuItems.AddToRowsDeck.ClickThis();
				Reports.ReportLog("DragTotalDueToRowsDeck", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}catch (Exception ex)
			{
				throw new Exception("Failed : DragTotalDueToRowsDeck" +ex.Message);
			}
		}
		
		public static void DragDueDateToColorDeck()
		{
			try{
				repo.VisualAnalyticsDailog.DueDateInfo.WaitForItemExists(30000);
				DragDropElements(repo.VisualAnalyticsDailog.DueDate, repo.VisualAnalyticsDailog.Color);
				Reports.ReportLog("DragDueDateToColorDeck", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}catch (Exception ex)
			{
				throw new Exception("Failed : DragDueDateToColorDeck" +ex.Message);
			}
		}
		
		public static void ValidateLinearModelType()
		{
			try
			{
				CompressedImage VAFiltering = repo.VisualAnalyticsDailog.ContainerCanvasInfo.GetscreenLinear();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalyticsDailog.ContainerCanvasInfo;
				Validate.ContainsImage(info, VAFiltering, options, "After change to Linear model type image validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateLinearModelType" +ex.Message);
			}
		}
		
		public static void ValidateLogarithmicModelType()
		{
			try
			{
				CompressedImage VAFiltering = repo.VisualAnalyticsDailog.ContainerCanvasInfo.GetscreenLogarithmic();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalyticsDailog.ContainerCanvasInfo;				
				Validate.ContainsImage(info, VAFiltering, options, "Compare For Logarithmic ModelType", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateLogarithmicModelType" +ex.Message);
			}
		}
		
		public static void ValidateExponentialModelType()
		{
			try
			{
				CompressedImage VAFiltering = repo.VisualAnalyticsDailog.ContainerCanvasInfo.GetscreenExponential();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalyticsDailog.ContainerCanvasInfo;
				
				Validate.ContainsImage(info, VAFiltering, options, "Compare For Exponential ModelType", false);

			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateExponentialModelType" +ex.Message);
			}
		}
		
		public static void ValidatePolynomialDegree2ModelType()
		{
			try
			{
				ExplicitWait_1000();
				CompressedImage VAFiltering = repo.VisualAnalyticsDailog.ContainerCanvasInfo.GetscreenPolynomialDegree2();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalyticsDailog.ContainerCanvasInfo;
				ExplicitWait_1000();
				Validate.ContainsImage(info, VAFiltering, options, "ValidatePolynomialDegree2ModelType", false);

			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidatePolynomialDegree2ModelType" +ex.Message);
			}
		}

		public static void ValidateShowConfidenceBandsPolynomialDegree3ModelType()
		{
			try
			{
				CompressedImage VAFiltering = repo.VisualAnalyticsDailog.ContainerCanvasInfo.GetscreenForceYIntercept();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalyticsDailog.ContainerCanvasInfo;
				Validate.ContainsImage(info, VAFiltering, options, "ValidateShowConfidenceBandsPolynomialDegree3ModelType", false);

			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateShowConfidenceBandsPolynomialDegree3ModelType" +ex.Message);
			}
		}

		public static void ValidateForceYInterceptPolynomialDegree3ModelType()
		{
			try
			{
				CompressedImage VAFiltering = repo.VisualAnalyticsDailog.ContainerCanvasInfo.GetscreenPolynomialDegree3ModelType();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalyticsDailog.ContainerCanvasInfo;
				Validate.ContainsImage(info, VAFiltering, options, "ValidateForceYInterceptPolynomialDegree3ModelType", false);

			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateForceYInterceptPolynomialDegree3ModelType" +ex.Message);
			}
		}
		
		public static void ValidateDueDtFromDimensionsToColorDeck()
		{
			try
			{
				CompressedImage VAFiltering = repo.VisualAnalyticsDailog.ContainerCanvasInfo.GetColorDeckDrag();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalyticsDailog.ContainerCanvasInfo;
				Validate.ContainsImage(info, VAFiltering, options, "ValidateDueDtFromDimensionsToColorDeck", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateDueDtFromDimensionsToColorDeck" +ex.Message);
			}
		}
		
		public static void ValidateLavenderBand()
		{
			try
			{
				CompressedImage VAFiltering = repo.VisualAnalyticsDailog.ContainerCanvasInfo.GetScreenLavenderBand();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalyticsDailog.ContainerCanvasInfo;
				Validate.ContainsImage(info, VAFiltering, options, "ValidateLavenderBand", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateLavenderBand" +ex.Message);
			}
		}
		
		public static void ValidateBoxIconTab1()
		{
			try
			{
				CompressedImage VAFiltering = repo.VisualAnalyticsDailog.ContainerCanvasInfo.GetBoxPlot1();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalyticsDailog.ContainerCanvasInfo;
				Validate.ContainsImage(info, VAFiltering, options, "ValidateBoxIconTab1", false);

			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateBoxIconTab1" +ex.Message);
			}
		}
		
		public static void ValidateBoxIconTab2()
		{
			try
			{
				CompressedImage VAFiltering = repo.VisualAnalyticsDailog.ContainerCanvasInfo.GetBoxplot2();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalyticsDailog.ContainerCanvasInfo;
				Validate.ContainsImage(info, VAFiltering, options, "ValidateBoxIconTab2", false);

			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateBoxIconTab2" +ex.Message);
			}
		}
		
		public static void ValidateBoxIconTab3()
		{
			try
			{
				CompressedImage VAFiltering = repo.VisualAnalyticsDailog.ContainerCanvasInfo.GetBoxPlot3();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalyticsDailog.ContainerCanvasInfo;
				Validate.ContainsImage(info, VAFiltering, options, "ValidateBoxIconTab3", false);

			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateBoxIconTab3" +ex.Message);
			}
		}
		
		public static void ValidateBoxIconTab4()
		{
			try
			{
				CompressedImage VAFiltering = repo.VisualAnalyticsDailog.ContainerCanvasInfo.GetBoxPlot4();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalyticsDailog.ContainerCanvasInfo;
				Validate.ContainsImage(info, VAFiltering, options, "ValidateBoxIconTab4", false);

			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateBoxIconTab4" +ex.Message);
			}
		}
		
		public static void ValidatePercentageDistribution()
		{
			try
			{
				CompressedImage VAFiltering = repo.VisualAnalyticsDailog.ContainerCanvasInfo.GetPerceDist();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalyticsDailog.ContainerCanvasInfo;
				Validate.ContainsImage(info, VAFiltering, options, "ValidatePercentageDistribution", false);

			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidatePercentageDistribution" +ex.Message);
			}
		}
		
		public static void ValidatePercentileDistribution()
		{
			try
			{
				ExplicitWait_1000();
				CompressedImage VAFiltering = repo.VisualAnalyticsDailog.ContainerCanvasInfo.GetPercentileDist();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalyticsDailog.ContainerCanvasInfo;
				ExplicitWait_1000();
				Validate.ContainsImage(info, VAFiltering, options, "ValidatePercentileDistribution", false);

			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidatePercentileDistribution" +ex.Message);
			}
		}
		
		public static void ValidateQuantileDistribution()
		{
			try
			{
				ExplicitWait_1000();
				CompressedImage VAFiltering = repo.VisualAnalyticsDailog.ContainerCanvasInfo.GetQuantileDist();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalyticsDailog.ContainerCanvasInfo;
				ExplicitWait_1000();
				Validate.ContainsImage(info, VAFiltering, options, "ValidateQuantileDistribution", false);

			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateQuantileDistribution" +ex.Message);
			}
		}
		
		public static void ValidateFirstLine()
		{
			try
			{
				CompressedImage VAFiltering = repo.VisualAnalyticsDailog.ContainerCanvasInfo.GetfirstLine2();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalyticsDailog.ContainerCanvasInfo;
				Validate.ContainsImage(info, VAFiltering, options, "ValidateFirstLine", false);

			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateFirstLine" +ex.Message);
			}
		}
		
		public static void ValidateFirstLineRepeat()
		{
			try
			{
				CompressedImage VAFiltering = repo.VisualAnalyticsDailog.ContainerCanvasInfo.GetFirstLineRepeat();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalyticsDailog.ContainerCanvasInfo;
				Validate.ContainsImage(info, VAFiltering, options, "ValidateFirstLineRepeat", false);

			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateFirstLineRepeat" +ex.Message);
			}
		}
		public static void ValidateSecLine()
		{
			try
			{
				ExplicitWait_1000();
				CompressedImage VAFiltering = repo.VisualAnalyticsDailog.ContainerCanvasInfo.GetSecLine();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalyticsDailog.ContainerCanvasInfo;
				ExplicitWait_1000();
				Validate.ContainsImage(info, VAFiltering, options, "ValidateSecLine", false);

			}catch (Exception ex)
			{
				throw new Exception("Failed : ValidateSecLine" +ex.Message);
			}
		}
		
		public static void ValidateThirdLine()
		{
			try
			{
				CompressedImage VAFiltering = repo.VisualAnalyticsDailog.ContainerCanvasInfo.GetThirdLine();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalyticsDailog.ContainerCanvasInfo;
				Validate.ContainsImage(info, VAFiltering, options, "ValidateThirdLine", false);

			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateThirdLine" +ex.Message);
			}
		}
		
		public static void ValidateLinear()
		{
			try{
				
				CompressedImage VAFiltering = repo.VisualAnalyticsDailog.ContainerCanvasInfo.GetscreenLinear();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalyticsDailog.ContainerCanvasInfo;
				Validate.ContainsImage(info, VAFiltering, options, "ValidateLinear", false);

			}catch (Exception ex)
			{
				throw new Exception("Failed : ValidateLinear" +ex.Message);
			}
		}
		
		public static void ValidateAquaBand()
		{
			try{
				CompressedImage VAFiltering = repo.VisualAnalyticsDailog.ContainerCanvasInfo.GetUnchkAqualBand();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalyticsDailog.ContainerCanvasInfo;
				Validate.ContainsImage(info, VAFiltering, options, "ValidateAquaBand", false);

			}catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAquaBand" +ex.Message);
			}
		}
		
		public static void ValidateRedBand()
		{
			try{
				CompressedImage VAFiltering = repo.VisualAnalyticsDailog.ContainerCanvasInfo.GetRedBand();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalyticsDailog.ContainerCanvasInfo;
				Validate.ContainsImage(info, VAFiltering, options, "ValidateRedBand", false);

			}catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAquaBand" +ex.Message);
			}
		}
		
		public static void DragProductCategorylToColumnsDeck()
		{
			try{
				repo.VisualAnalyticsDailog.ProductCategoryInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsDailog.ProductCategory.ClickThis();
				repo.VisualAnalyticsDailog.ProductCategory.RightClickThis();
				repo.SubMenuItems.AddToColumnsDeckInfo.WaitForItemExists(30000);
				repo.SubMenuItems.AddToColumnsDeck.ClickThis();
				Reports.ReportLog("DragProductCategorylToColumnsDeck", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}catch (Exception ex)
			{
				throw new Exception("Failed : DragProductCategorylToColumnsDeck" +ex.Message);
			}
		}
		
		public static void DragShipDateToColumnsDeck()
		{
			try{
				repo.VisualAnalyticsDailog.ContainerLeftPanel.ShipDateInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsDailog.ContainerLeftPanel.ShipDate.ClickThis();
				repo.VisualAnalyticsDailog.ContainerLeftPanel.ShipDate.RightClickThis();
				repo.SubMenuItems.AddToColumnsDeckInfo.WaitForItemExists(30000);
				repo.SubMenuItems.AddToColumnsDeck.ClickThis();
				Reports.ReportLog("DragShipDateToColumnsDeck", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}catch (Exception ex)
			{
				throw new Exception("Failed : DragShipDateToColumnsDeck" +ex.Message);
			}
		}
		
		public static void DragCardTypeToColumnsDeck()
		{
			try{
				repo.VisualAnalyticsDailog.ContainerLeftPanel.CardTypeInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsDailog.ContainerLeftPanel.CardType.RightClickThis();
				repo.SubMenuItems.AddToColumnsDeckInfo.WaitForItemExists(10000);
				repo.SubMenuItems.AddToColumnsDeck.ClickThis();
				Reports.ReportLog("DragCardTypeToColumnsDeck", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}catch (Exception ex)
			{
				throw new Exception("Failed : DragCardTypeToColumnsDeck" +ex.Message);
			}
		}
		
		public static void CloseTrendLineDetailsDialog()
		{
			try{
				if(repo.TrendLineDetailsDailog.CloseInfo.Exists(10000))
				{
					repo.TrendLineDetailsDailog.CloseInfo.WaitForItemExists(10000);
					repo.TrendLineDetailsDailog.Close.ClickThis();
					Reports.ReportLog("CloseTrendLineDetailsDialog", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
			}catch (Exception ex)
			{
				throw new Exception("Failed : CloseTrendLineDetailsDialog" +ex.Message);
			}
		}
		
		public static void CloseVisualAnalyticsDailog()
		{
			try{
				
				if(repo.VisualAnalyticsDailog.SelfInfo.Exists(new Duration(30000)))
				{
					repo.VisualAnalyticsDailog.Self.Close();
					Reports.ReportLog("CloseVisualAnalyticsDailog", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				if(repo.SaveChanges.DiscardButtonInfo.Exists(new Duration(30000)))
				{
					repo.SaveChanges.DiscardButtonInfo.WaitForItemExists(30000);
					repo.SaveChanges.DiscardButton.ClickThis();
				}else{
					
					repo.VisualAnalyticsDailog.Self.Close();
					repo.SaveChanges.DiscardButtonInfo.WaitForItemExists(30000);
					repo.SaveChanges.DiscardButton.ClickThis();
				}
			}catch (Exception ex)
			{
				throw new Exception("Failed : CloseVisualAnalyticsDailog" +ex.Message);
			}
		}
		
		public static void VerifyThe1stResultsInTrendLineDetailsDailog(string strValue){
			try
			{
				if(repo.TrendLineDetailsDailog.firstTrendModel.Element.GetAttributeValue("innertext").ToString().Trim().Contains(strValue))
				{
					Reports.ReportLog("VerifyTheResultsInTrendLineDetailsDailog", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}else{
					Report.Error("Error : VerifyThe1stResultsInTrendLineDetailsDailog " +strValue);
				}
			}catch (Exception ex)
			{
				throw new Exception("Failed : VerifyThe1stResultsInTrendLineDetailsDailog" +ex.Message);
			}
		}
		
		public static void VerifyThe2ndtResultsInTrendLineDetailsDailog(string strValue){
			try
			{
				if(repo.TrendLineDetailsDailog.SecTrendModel.Element.GetAttributeValue("innertext").ToString().Trim().Contains(strValue))
				{
					Reports.ReportLog("VerifyTheResultsInTrendLineDetailsDailog", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}else{
					Report.Error("Error : VerifyThe2ndtResultsInTrendLineDetailsDailog " +strValue);
				}
			}catch (Exception ex)
			{
				throw new Exception("Failed : VerifyThe2ndtResultsInTrendLineDetailsDailog" +ex.Message);
			}
		}
		
		public static void VerifyThe3rdtResultsInTrendLineDetailsDailog(string strValue){
			try
			{
				if(repo.TrendLineDetailsDailog.ThirdTrendModel.Element.GetAttributeValue("innertext").ToString().Trim().Contains(strValue))
				{
					Reports.ReportLog("VerifyTheResultsInTrendLineDetailsDailog", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}else{
					Report.Error("Error : VerifyThe3rdtResultsInTrendLineDetailsDailog " +strValue);
				}
			}catch (Exception ex)
			{
				throw new Exception("Failed : VerifyThe3rdtResultsInTrendLineDetailsDailog" +ex.Message);
			}
		}
		
		public static void ClickOnTrenLine(){
			try
			{
				repo.VisualAnalyticsDailog.ContainerCanvasInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsDailog.ContainerCanvas.Click("90;181");
				ExplicitWait();
				Reports.ReportLog("ClickOnTrenLine", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
			}catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnTrenLine" +ex.Message);
			}
		}
		
		public static void ValidateTrendLineDimmed()
		{
			try
			{
				CompressedImage VAFiltering = repo.VisualAnalyticsDailog.ContainerCanvasInfo.GetScreenshotTrendLineDimmed();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalyticsDailog.ContainerCanvasInfo;
				Validate.ContainsImage(info, VAFiltering, options, "ValidateTrendLineDimmed", false);

			}catch (Exception ex)
			{
				throw new Exception("Failed : ValidateTrendLineDimmed" +ex.Message);
			}
		}
				
		public static void AddRefLinesBandOrBox()
		{
			try
			{
				repo.VisualAnalyticsDailog.AnalysisInfo.WaitForItemExists(10000);
				repo.VisualAnalyticsDailog.Analysis.ClickThis();
				if(repo.SubMenuItems.ReferenceLinesInfo.Exists(10000))
				{
					repo.SubMenuItems.ReferenceLines.ClickThis();
					repo.SubMenuItems.AddRefLineBandOrBoxInfo.WaitForItemExists(10000);
					repo.SubMenuItems.AddRefLineBandOrBox.ClickThis();
				}else{
					repo.VisualAnalyticsDailog.AnalysisInfo.WaitForItemExists(10000);
					repo.VisualAnalyticsDailog.Analysis.ClickThis();
					repo.SubMenuItems.ReferenceLinesInfo.WaitForItemExists(10000);
					repo.SubMenuItems.ReferenceLines.ClickThis();
					repo.SubMenuItems.AddRefLineBandOrBoxInfo.WaitForItemExists(10000);
					repo.SubMenuItems.AddRefLineBandOrBox.ClickThis();
				}
				Reports.ReportLog("AddRefLinesBandOrBox", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : AddRefLinesBandOrBox" +ex.Message);
			}
		}
		
		public static void EditRefLinesBandOrBox()
		{
			try
			{
				repo.VisualAnalyticsDailog.AnalysisInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsDailog.Analysis.ClickThis();
				if(repo.SubMenuItems.ReferenceLinesInfo.Exists(30000))
				{
					repo.SubMenuItems.ReferenceLines.ClickThis();
					repo.SubMenuItems.EditRefLineBandOrBoxInfo.WaitForItemExists(30000);
					repo.SubMenuItems.EditRefLineBandOrBox.ClickThis();
				}else{
					repo.VisualAnalyticsDailog.Analysis.ClickThis();
					repo.SubMenuItems.ReferenceLinesInfo.WaitForItemExists(30000);
					repo.SubMenuItems.ReferenceLines.ClickThis();
					repo.SubMenuItems.EditRefLineBandOrBoxInfo.WaitForItemExists(30000);
					repo.SubMenuItems.EditRefLineBandOrBox.ClickThis();
				}
				Reports.ReportLog("EditRefLinesBandOrBox", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : EditRefLinesBandOrBox" +ex.Message);
			}
		}
		
		public static void SelectLineAndEntireTableActiononAddRefLineBandOrBoxDialog()
		{
			try{
				if(repo.AddRefLineBandOrBoxDialog.HeaderPanel.LineInfo.Exists(30000)){
					repo.AddRefLineBandOrBoxDialog.HeaderPanel.Line.ClickThis();
					repo.AddRefLineBandOrBoxDialog.ScopePanel.EntireTableInfo.WaitForItemExists(30000);
					repo.AddRefLineBandOrBoxDialog.ScopePanel.EntireTable.ClickThis();
					Reports.ReportLog("SelectLineonAddRefLineBandOrBoxDialog", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}else{
					throw new Exception("SelectLineAndEntireTableActiononAddRefLineBandOrBoxDialog - Add Reference Line Band Or Box Dialog Not Found");
				}
			}catch (Exception ex)
			{
				throw new Exception("Failed : SelectLineAndEntireTableActiononAddRefLineBandOrBoxDialog" +ex.Message);
			}
		}
		
		public static void SelectBandAndPerPaneActions()
		{
			try{
				if(repo.AddRefLineBandOrBoxDialog.HeaderPanel.BandInfo.Exists(10000)){
					repo.AddRefLineBandOrBoxDialog.HeaderPanel.Band.ClickThis();
					repo.AddRefLineBandOrBoxDialog.ScopePanel.PerPaneInfo.WaitForItemExists(10000);
					repo.AddRefLineBandOrBoxDialog.ScopePanel.PerPane.ClickThis();
					Reports.ReportLog("SelectBandAndPerPaneActions", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}else{
					throw new Exception("SelectBandAndPerPaneActions");
				}
			}catch (Exception ex)
			{
				throw new Exception("Failed : SelectBandAndPerPaneActions" +ex.Message);
			}
		}
		
		public static void SelectBoxPlotAndWhiskersExtend(string strwhiskersVal)
		{
			try{
				if(repo.AddRefLineBandOrBoxDialog.BoxPlotInfo.Exists(30000)){
					repo.AddRefLineBandOrBoxDialog.BoxPlot.ClickThis();
					repo.AddRefLineBandOrBoxDialog.WhiskerExtendsToCmbInfo.WaitForItemExists(30000);
					repo.AddRefLineBandOrBoxDialog.WhiskerExtendsToCmb.ClickThis();
					repo.itemVal = strwhiskersVal;
					repo.SubMenuItems.listItem.MoveTo();
					repo.SubMenuItems.listItem.ClickThis();
					Reports.ReportLog("SelectBoxPlotAndWhiskersExtend", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}else{
					throw new Exception("SelectBoxPlotAndWhiskersExtend - Edit Reference Line Band Or Box Dialog Not Found");
				}
			}catch (Exception ex)
			{
				throw new Exception("Failed : SelectBoxPlotAndWhiskersExtend" +ex.Message);
			}
		}
		
		public static void SelectStyle(string strStyleVal)
		{
			try{
				repo.EditReferenceLineBandOrBox.ContentPanel.StyleComboBoxInfo.WaitForItemExists(30000);
				repo.EditReferenceLineBandOrBox.ContentPanel.StyleComboBox.ClickThis();
				repo.itemVal = strStyleVal;
				repo.SubMenuItems.listItem.MoveTo();
				repo.SubMenuItems.listItem.ClickThis();
				Reports.ReportLog("SelectStyle", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
			}catch (Exception ex)
			{
				throw new Exception("Failed : SelectStyle" +ex.Message);
			}
		}
		
		public static void SelectDistributionAndPerCellActionons()
		{
			try{
				if(repo.AddRefLineBandOrBoxDialog.HeaderPanel.DistributionInfo.Exists()){
					repo.AddRefLineBandOrBoxDialog.HeaderPanel.Distribution.ClickThis();
					repo.AddRefLineBandOrBoxDialog.ScopePanel.PerCellInfo.WaitForItemExists(30000);
					repo.AddRefLineBandOrBoxDialog.ScopePanel.PerCell.ClickThis();
					Reports.ReportLog("SelectDistributionAndPerCellActiononAddRefLineBandOrBoxDialog", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}else{
					throw new Exception("SelectDistributionAndPerCellActiononAddRefLineBandOrBoxDialog - Add Reference Line Band Or Box Dialog Not Found");
				}
			}catch (Exception ex)
			{
				throw new Exception("Failed : SelectDistributionAndPerCellActiononAddRefLineBandOrBoxDialog" +ex.Message);
			}
		}
		
		public static void PercentageValueFieldLinePanelDistributionSetParam(string strPercVal, string strPerCmb2Val)
		{
			try{
				repo.AddRefLineBandOrBoxDialog.LinePanel.ValueCmb1Info.WaitForItemExists(30000);
				repo.AddRefLineBandOrBoxDialog.LinePanel.ValueCmb1.ClickThis();
				repo.SubMenuItems.NullContentPane.Percentages.ClickThis();
				repo.SubMenuItems.NullContentPane.txtPerentages.TextBoxText(strPercVal);
				repo.SubMenuItems.NullContentPane.cmb2PercentageOfInfo.WaitForItemExists(30000);
				repo.SubMenuItems.NullContentPane.cmb2PercentageOf.ClickThis();
				repo.itemVal = strPerCmb2Val;
				repo.SubMenuItems.listItem.ClickThis();
				Keyboard.Press("{ESCAPE}");
				Reports.ReportLog("PercentageValueFieldLinePanelDistributionSetParam", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}catch (Exception ex)
			{
				throw new Exception("Failed : PercentageValueFieldLinePanelDistributionSetParam" +ex.Message);
			}
		}
		
		public static void PercentilesValueFieldLinePanelDistributionSetParam(string strPerCmb1Val)
		{
			try{
				repo.AddRefLineBandOrBoxDialog.LinePanel.ValueCmb1Info.WaitForItemExists(30000);
				repo.AddRefLineBandOrBoxDialog.LinePanel.ValueCmb1.ClickThis();
				repo.SubMenuItems.NullContentPane.Percentiles.ClickThis();
				repo.SubMenuItems.NullContentPane.cmbPercentileInfo.WaitForItemExists(30000);
				repo.SubMenuItems.NullContentPane.cmbPercentile.ClickThis();
				repo.itemVal = strPerCmb1Val;
				repo.SubMenuItems.listItem.ClickThis();
				Keyboard.Press("{ESCAPE}");
				Reports.ReportLog("PercentilesValueFieldLinePanelDistributionSetParam", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}catch (Exception ex)
			{
				throw new Exception("Failed : PercentilesValueFieldLinePanelDistributionSetParam" +ex.Message);
			}
		}
		
		public static void QuantilesValueFieldLinePanelDistributionSetParam(string strNoOfTiles)
		{
			try{
				repo.AddRefLineBandOrBoxDialog.LinePanel.ValueCmb1Info.WaitForItemExists(30000);
				repo.AddRefLineBandOrBoxDialog.LinePanel.ValueCmb1.ClickThis();
				repo.SubMenuItems.NullContentPane.Quantiles.ClickThis();
				repo.SubMenuItems.NullContentPane.cmbNoOfTilesInfo.WaitForItemExists(30000);
				repo.SubMenuItems.NullContentPane.cmbNoOfTiles.ClickThis();
				repo.itemVal = strNoOfTiles;
				repo.SubMenuItems.listItem.ClickThis();
				Keyboard.Press("{ESCAPE}");
				Reports.ReportLog("QuantilesValueFieldLinePanelDistributionSetParam", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}catch (Exception ex)
			{
				throw new Exception("Failed : QuantilesValueFieldLinePanelDistributionSetParam" +ex.Message);
			}
		}
		
		public static void LabelFieldLinePanelDistributionSetParam(string strLabelCmb1Val)
		{
			try{
				repo.AddRefLineBandOrBoxDialog.LinePanel.ValueCmb2Info.WaitForItemExists(30000);
				repo.AddRefLineBandOrBoxDialog.LinePanel.ValueCmb2.ClickThis();
				repo.itemVal = strLabelCmb1Val;
				repo.SubMenuItems.listItem.ClickThis();
				Reports.ReportLog("LabelFieldLinePanelDistributionSetParam", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}catch (Exception ex)
			{
				throw new Exception("Failed : LabelFieldLinePanelDistributionSetParam" +ex.Message);
			}
		}
		
		public static void BrandFromSetParam(string strCmbVal2, string strCmbVal1, string strLabelVal, string strLabelTxtVal){
			try{
				if(strCmbVal1 == "SUM(Profit)"){
					repo.AddRefLineBandOrBoxDialog.Val1BandFromInfo.WaitForItemExists(30000);
					repo.AddRefLineBandOrBoxDialog.Val1BandFrom.ClickThis();
					repo.itemVal = strCmbVal1;
					repo.SubMenuItems.listItem.ClickThis();
					
					repo.AddRefLineBandOrBoxDialog.Val2BandFromInfo.WaitForItemExists(30000);
					repo.AddRefLineBandOrBoxDialog.Val2BandFrom.ClickThis();
					repo.itemVal = strCmbVal2;
					repo.SubMenuItems.listItem.ClickThis();
				}else{
					repo.AddRefLineBandOrBoxDialog.Val2BandFromInfo.WaitForItemExists(30000);
					repo.AddRefLineBandOrBoxDialog.Val2BandFrom.ClickThis();
					repo.itemVal = strCmbVal2;
					repo.SubMenuItems.listItem.ClickThis();
					
					repo.AddRefLineBandOrBoxDialog.Val1txtBandFromInfo.WaitForItemExists(30000);
					repo.AddRefLineBandOrBoxDialog.Val1txtBandFrom.ClickThis();
					repo.AddRefLineBandOrBoxDialog.Val1txtBandFrom.TextBoxText(strCmbVal1);
				}
				
				ExplicitWait_1000();
				
				if(repo.AddRefLineBandOrBoxDialog.LabelBandFromInfo.Exists(30000)){
					//repo.AddRefLineBandOrBoxDialog.LabelBandFromInfo.WaitForItemExists(30000);
					repo.AddRefLineBandOrBoxDialog.LabelBandFrom.ClickThis();
					repo.itemVal = strLabelVal;
					try
					{
						repo.SubMenuItems.listItemInfo.WaitForItemExists(30000);
						repo.SubMenuItems.listItem.ClickThis();
						repo.AddRefLineBandOrBoxDialog.LabelTxtBandFrom.TextBoxText(strLabelTxtVal);
					}
					catch
					{
						
					}
				}
				Reports.ReportLog("BrandFromSetParam", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}catch (Exception ex)
			{
				throw new Exception("Failed : BrandFromSetParam" +ex.Message);
			}
			
		}
		
		public static void BrandToSetParam(string strCmbVal1, string strCmbVal2, string strLabelVal, string strLabelTxtVal){
			try{
				if(strCmbVal1 == "SUM(Profit)"){
					repo.AddRefLineBandOrBoxDialog.Val1BandToInfo.WaitForItemExists(30000);
					repo.AddRefLineBandOrBoxDialog.Val1BandTo.ClickThis();
					repo.itemVal = strCmbVal1;
					repo.SubMenuItems.listItem.MoveTo();
					repo.SubMenuItems.listItem.ClickThis();
					
					repo.AddRefLineBandOrBoxDialog.Val2BandToInfo.WaitForItemExists(30000);
					repo.AddRefLineBandOrBoxDialog.Val2BandTo.ClickThis();
					repo.itemVal = strCmbVal2;
					repo.SubMenuItems.listItem.MoveTo();
					repo.SubMenuItems.listItem.ClickThis();
				}else{
					repo.AddRefLineBandOrBoxDialog.Val2BandToInfo.WaitForItemExists(30000);
					repo.AddRefLineBandOrBoxDialog.Val2BandTo.ClickThis();
					repo.itemVal = strCmbVal2;
					repo.SubMenuItems.listItem.MoveTo();
					repo.SubMenuItems.listItem.ClickThis();
					Keyboard.Press("{ControlKey down}{Home}{ControlKey up}");
					repo.AddRefLineBandOrBoxDialog.Val1TxtBandTo.TextBoxText(strCmbVal1);
				}
				
				repo.AddRefLineBandOrBoxDialog.LabelBandToInfo.WaitForItemExists(30000);
				repo.AddRefLineBandOrBoxDialog.LabelBandTo.ClickThis();
				repo.itemVal = strLabelVal;
				repo.SubMenuItems.listItem.MoveTo();
				repo.SubMenuItems.listItem.ClickThis();
				repo.AddRefLineBandOrBoxDialog.LabelTxtBandTo.TextBoxText(strLabelTxtVal);
				Reports.ReportLog("BrandToSetParam", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}catch (Exception ex)
			{
				throw new Exception("Failed : BrandToSetParam" +ex.Message);
			}
			
		}
		
		public static void LinePanelAddRefLineBandOrBoxDialogSetParam(string strCmbVal1, string strCmbVal2, string strLabelVal)
		{
			try
			{
				repo.AddRefLineBandOrBoxDialog.LinePanel.ValueCmb1Info.WaitForItemExists(30000);
				repo.AddRefLineBandOrBoxDialog.LinePanel.ValueCmb1.ClickThis();
				repo.itemVal = strCmbVal1;
				repo.SubMenuItems.listItem.ClickThis();
				repo.AddRefLineBandOrBoxDialog.LinePanel.ValueCmb2Info.WaitForItemExists(30000);
				repo.AddRefLineBandOrBoxDialog.LinePanel.ValueCmb2.ClickThis();
				repo.itemVal = strCmbVal2;
				repo.SubMenuItems.listItem.ClickThis();
				repo.AddRefLineBandOrBoxDialog.LinePanel.LableCmbInfo.WaitForItemExists(30000);
				repo.AddRefLineBandOrBoxDialog.LinePanel.LableCmb.ClickThis();
				repo.itemVal = strLabelVal;
				repo.SubMenuItems.listItem.MoveTo();
				repo.SubMenuItems.listItem.ClickThis();
				Reports.ReportLog("LinePanelAddRefLineBandOrBoxDialogSetParam", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : LinePanelAddRefLineBandOrBoxDialogSetParam" +ex.Message);
			}
		}
		
		public static void BandFromPanelAddRefLineBandOrBoxDialogSetParam(string strCmbVal1, string strCmbVal2, string strLabelVal)
		{
			try
			{
				repo.AddRefLineBandOrBoxDialog.Val1BandFromInfo.WaitForItemExists(30000);
				repo.AddRefLineBandOrBoxDialog.Val1BandFrom.ClickThis();
				repo.itemVal = strCmbVal1;
				repo.SubMenuItems.listItem.ClickThis();
				repo.AddRefLineBandOrBoxDialog.Val2BandFromInfo.WaitForItemExists(30000);
				repo.AddRefLineBandOrBoxDialog.Val2BandFrom.ClickThis();
				repo.itemVal = strCmbVal2;
				repo.SubMenuItems.listItem.ClickThis();
				repo.AddRefLineBandOrBoxDialog.LabelBandFromInfo.WaitForItemExists(30000);
				repo.AddRefLineBandOrBoxDialog.LabelBandFrom.ClickThis();
				repo.itemVal = strLabelVal;
				repo.SubMenuItems.listItem.MoveTo();
				repo.SubMenuItems.listItem.ClickThis();
				Reports.ReportLog("BandFromPanelAddRefLineBandOrBoxDialogSetParam", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : BandFromPanelAddRefLineBandOrBoxDialogSetParam" +ex.Message);
			}
		}
		
		public static void BandToPanelAddRefLineBandOrBoxDialogSetParam(string strCmbVal1, string strCmbVal2, string strLabelVal)
		{
			try
			{
				repo.AddRefLineBandOrBoxDialog.Val1BandToInfo.WaitForItemExists(30000);
				repo.AddRefLineBandOrBoxDialog.Val1BandTo.ClickThis();
				repo.itemVal = strCmbVal1;
				repo.SubMenuItems.listItem.ClickThis();
				repo.AddRefLineBandOrBoxDialog.Val2BandToInfo.WaitForItemExists(30000);
				repo.AddRefLineBandOrBoxDialog.Val2BandTo.ClickThis();
				repo.itemVal = strCmbVal2;
				repo.SubMenuItems.listItem.ClickThis();
				repo.AddRefLineBandOrBoxDialog.LabelBandToInfo.WaitForItemExists(30000);
				repo.AddRefLineBandOrBoxDialog.LabelBandTo.ClickThis();
				repo.itemVal = strLabelVal;
				repo.SubMenuItems.listItem.MoveTo();
				repo.SubMenuItems.listItem.ClickThis();
				Reports.ReportLog("BandToPanelAddRefLineBandOrBoxDialogSetParam", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : BandToPanelAddRefLineBandOrBoxDialogSetParam" +ex.Message);
			}
		}
		
		public static void firstLineFormattingPanelAddRefLineBandOrBoxDialog(){
			try
			{
				repo.AddRefLineBandOrBoxDialog.LineCmbInfo.WaitForItemExists(30000);
				repo.AddRefLineBandOrBoxDialog.LineCmb.ClickThis();
				repo.SubMenuItems.FirstHeaderInfo.WaitForItemExists(30000);
				repo.SubMenuItems.FirstHeader.ClickThis();
				Keyboard.Press("{ESCAPE}");
				Reports.ReportLog("firstLineFormattingPanelAddRefLineBandOrBoxDialog", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}catch (Exception ex)
			{
				throw new Exception("Failed : firstLineFormattingPanelAddRefLineBandOrBoxDialog" +ex.Message);
			}
		}
		
		public static void firstLineFormattingPanelLineTab(){
			try
			{
				repo.AddReferenceLineBandOrBox2.LineFrmgLineTabInfo.WaitForItemExists(30000);
				repo.AddReferenceLineBandOrBox2.LineFrmgLineTab.ClickThis();
				repo.SubMenuItems.FirstHeaderInfo.WaitForItemExists(30000);
				repo.SubMenuItems.FirstHeader.ClickThis();
				Keyboard.Press("{ESCAPE}");
				Reports.ReportLog("firstLineFormattingPanelLineTab", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}catch (Exception ex)
			{
				throw new Exception("Failed : firstLineFormattingPanelLineTab" +ex.Message);
			}
		}
		
		public static void HoriLineFormattingPanelAddRefLineBandOrBoxDialog()
		{
			try
			{
				repo.AddReferenceLineBandOrBox2.LineAlignmentFormatInfo.WaitForItemExists(30000);
				repo.AddReferenceLineBandOrBox2.LineAlignmentFormat.ClickThis();
				repo.SubMenuItems.HoriAutomaticInfo.WaitForItemExists(30000);
				repo.SubMenuItems.HoriAutomatic.ClickThis();
				Thread.Sleep(500);
				Keyboard.Press("{ESCAPE}");
				Reports.ReportLog("HoriLineFormattingPanelAddRefLineBandOrBoxDialog", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : HoriLineFormattingPanelAddRefLineBandOrBoxDialog" +ex.Message);
			}
		}
		
		public static void RightHoriLineFormattingPanel()
		{
			try
			{
				repo.AddRefLineBandOrBoxDialog.AllignmentCmbInfo.WaitForItemExists(30000);
				repo.AddRefLineBandOrBoxDialog.AllignmentCmb.ClickThis();
				repo.SubMenuItems.RightHoriInfo.WaitForItemExists(30000);
				repo.SubMenuItems.RightHori.ClickThis();
				Thread.Sleep(500);
				Keyboard.Press("{ESCAPE}");
				Reports.ReportLog("RightHoriLineFormattingPanel", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : RightHoriLineFormattingPanel" +ex.Message);
			}
		}
		
		public static void CenterHoriLineFormattingPanel()
		{
			try
			{
				repo.AddRefLineBandOrBoxDialog.formattingPanel.AllignmentCmbInfo.WaitForItemExists(30000);
				repo.AddRefLineBandOrBoxDialog.formattingPanel.AllignmentCmb.ClickThis();
				repo.SubMenuItems.SecHeaderInfo.WaitForItemExists(30000);
				repo.SubMenuItems.SecHeader.ClickThis();
				Thread.Sleep(500);
				Keyboard.Press("{ESCAPE}");
				Reports.ReportLog("CenterHoriLineFormattingPanel", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CenterHoriLineFormattingPanel" +ex.Message);
			}
		}
		
		public static void CenterHoriLineFormattingPanelDistribution()
		{
			try
			{
				repo.AddReferenceLineBandOrBox2.AllignmentDistrbutionInfo.WaitForItemExists(30000);
				repo.AddReferenceLineBandOrBox2.AllignmentDistrbution.ClickThis();
				repo.SubMenuItems.SecHeaderInfo.WaitForItemExists(30000);
				repo.SubMenuItems.SecHeader.ClickThis();
				Thread.Sleep(500);
				Keyboard.Press("{ESCAPE}");
				Reports.ReportLog("CenterHoriLineFormattingPanel", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CenterHoriLineFormattingPanel" +ex.Message);
			}
		}
				
		public static void DirAllignmentFormattingPanelAddRefLineBandOrBoxDialog()
		{
			try
			{
				repo.AddReferenceLineBandOrBox2.LineAlignmentFormatInfo.WaitForItemExists(30000);
				repo.AddReferenceLineBandOrBox2.LineAlignmentFormat.ClickThis();
				repo.SubMenuItems.DirectionAutomaticInfo.WaitForItemExists(30000);
				repo.SubMenuItems.DirectionAutomatic.ClickThis();
				Keyboard.Press("{ESCAPE}");
				Reports.ReportLog("DirAllignmentFormattingPanelAddRefLineBandOrBoxDialog", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DirAllignmentFormattingPanelAddRefLineBandOrBoxDialog" +ex.Message);
			}
		}
		
		public static void VerticleAllignmentFormattingPanelAddRefLineBandOrBoxDialog()
		{
			try
			{
				repo.AddReferenceLineBandOrBox2.LineAlignmentFormatInfo.WaitForItemExists(30000);
				repo.AddReferenceLineBandOrBox2.LineAlignmentFormat.ClickThis();
				repo.SubMenuItems.VerticleAutomaticInfo.WaitForItemExists(30000);
				repo.SubMenuItems.VerticleAutomatic.ClickThis();
				Keyboard.Press("{ESCAPE}");
				Reports.ReportLog("VerticleAllignmentFormattingPanelAddRefLineBandOrBoxDialog", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : VerticleAllignmentFormattingPanelAddRefLineBandOrBoxDialog" +ex.Message);
			}
		}
		
		public static void BottomVerticleAllignmentFormattingPanel()
		{
			try
			{
				repo.AddRefLineBandOrBoxDialog.formattingPanel.AllignmentCmbInfo.WaitForItemExists(30000);
				repo.AddRefLineBandOrBoxDialog.formattingPanel.AllignmentCmb.ClickThis();
				repo.SubMenuItems.BottomVerticleInfo.WaitForItemExists(30000);
				repo.SubMenuItems.BottomVerticle.ClickThis();
				Keyboard.Press("{ESCAPE}");
				Reports.ReportLog("BottomVerticleAllignmentFormattingPanel", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : VerticleAllignmentFormattingPanelAddRefLineBandOrBoxDialog" +ex.Message);
			}
		}
		
		public static void BottomVerticleAllignmentFormattingPanelBand()
		{
			try
			{
				repo.AddReferenceLineBandOrBox2.AllignmentCmbBandInfo.WaitForItemExists(30000);
				repo.AddReferenceLineBandOrBox2.AllignmentCmbBand.ClickThis();
				repo.SubMenuItems.BottomVerticleInfo.WaitForItemExists(30000);
				repo.SubMenuItems.BottomVerticle.ClickThis();
				Keyboard.Press("{ESCAPE}");
				Reports.ReportLog("BottomVerticleAllignmentFormattingPanelBand", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : BottomVerticleAllignmentFormattingPanelBand" +ex.Message);
			}
		}
		
		public static void BottomVerticleAllignmentFormattingPanelDistribution()
		{
			try
			{
				repo.AddReferenceLineBandOrBox2.AllignmentDistrbutionInfo.WaitForItemExists(30000);
				repo.AddReferenceLineBandOrBox2.AllignmentDistrbution.ClickThis();
				repo.SubMenuItems.BottomVerticleInfo.WaitForItemExists(30000);
				repo.SubMenuItems.BottomVerticle.ClickThis();
				Keyboard.Press("{ESCAPE}");
				Reports.ReportLog("BottomVerticleAllignmentFormattingPanelDistribution", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : BottomVerticleAllignmentFormattingPanelDistribution" +ex.Message);
			}
		}
		
		public static void TopVerticleAllignmentFormattingPanel()
		{
			try
			{
				repo.AddRefLineBandOrBoxDialog.formattingPanel.AllignmentCmbInfo.WaitForItemExists(30000);
				repo.AddRefLineBandOrBoxDialog.formattingPanel.AllignmentCmb.ClickThis();
				repo.SubMenuItems.TopVerticle.ClickThis();
				Keyboard.Press("{ESCAPE}");
				Reports.ReportLog("TopVerticleAllignmentFormattingPanel", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : VerticleAllignmentFormattingPanelAddRefLineBandOrBoxDialog" +ex.Message);
			}
		}
		
		public static void TopVerticleAllignmentFormattingPanelBand()
		{
			try
			{
				repo.AddReferenceLineBandOrBox2.AllignmentCmbBandInfo.WaitForItemExists(30000);
				repo.AddReferenceLineBandOrBox2.AllignmentCmbBand.ClickThis();
				repo.SubMenuItems.TopVerticle.ClickThis();
				Keyboard.Press("{ESCAPE}");
				Reports.ReportLog("TopVerticleAllignmentFormattingPanel", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : VerticleAllignmentFormattingPanelAddRefLineBandOrBoxDialog" +ex.Message);
			}
		}
		
		public static void TopVerticleAllignmentFormattingPanelDistribution()
		{
			try
			{
				repo.AddReferenceLineBandOrBox2.AllignmentDistrbutionInfo.WaitForItemExists(30000);
				repo.AddReferenceLineBandOrBox2.AllignmentDistrbution.ClickThis();
				repo.SubMenuItems.TopVerticle.ClickThis();
				Keyboard.Press("{ESCAPE}");
				Reports.ReportLog("TopVerticleAllignmentFormattingPanelDistribution", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : TopVerticleAllignmentFormattingPanelDistribution" +ex.Message);
			}
		}
		
		public static void FillAboveFormattingPanelAddRefLineBandOrBoxDialog(string strColor)
		{
			try
			{
				repo.AddRefLineBandOrBoxDialog.FillInfo.WaitForItemExists(30000);
				repo.AddRefLineBandOrBoxDialog.Fill.ClickThis();
				Thread.Sleep(500);
				if(strColor.Trim() == "Olive Green")
				{
					repo.SubMenuItems.OliveGreenColorIconInfo.WaitForItemExists(30000);
					repo.SubMenuItems.OliveGreenColorIcon.ClickThis();
				}else if(strColor.Trim() == "Dark Blue")
				{
					repo.SubMenuItems.DarkBlueColorIconInfo.WaitForItemExists(30000);
					repo.SubMenuItems.DarkBlueColorIcon.ClickThis();
				}
				else if(strColor.Trim() == "Lime")
				{
					repo.SubMenuItems.LimeColorIconInfo.WaitForItemExists(30000);
					repo.SubMenuItems.LimeColorIcon.ClickThis();
				}
				else if(strColor.Trim() == "Dark Yellow")
				{
					repo.SubMenuItems.DarkYelloColorIconInfo.WaitForItemExists(30000);
					repo.SubMenuItems.DarkYelloColorIcon.ClickThis();
				}
				else if(strColor.Trim() == "Lavender")
				{
					repo.SubMenuItems.LavenderColoeIconInfo.WaitForItemExists(30000);
					repo.SubMenuItems.LavenderColoeIcon.ClickThis();
				}
				else if(strColor.Trim() == "Aqua")
				{
					repo.SubMenuItems.AquaColorIconInfo.WaitForItemExists(30000);
					repo.SubMenuItems.AquaColorIcon.ClickThis();
				}
				else if(strColor.Trim() == "Red")
				{
					repo.SubMenuItems.RedColorIconInfo.WaitForItemExists(30000);
					repo.SubMenuItems.RedColorIcon.ClickThis();
				}
				else
				{
					Report.Error("Provide Matching Color for Fill Above Element -- FillAboveFormattingPanelAddRefLineBandOrBoxDialog");
				}
				Keyboard.Press("{ESCAPE}");
				Reports.ReportLog("FillAboveFormattingPanelAddRefLineBandOrBoxDialog", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : FillAboveFormattingPanelAddRefLineBandOrBoxDialog" +ex.Message);
			}
		}
		
		public static void FillFormattingPanelAddRefLineBandOrBoxDialog(string strColor)
		{
			try
			{
				repo.AddRefLineBandOrBoxDialog.cmbFillInfo.WaitForItemExists(30000);
				repo.AddRefLineBandOrBoxDialog.cmbFill.ClickThis();
				SelectColor(strColor);
				Reports.ReportLog("FillFormattingPanelAddRefLineBandOrBoxDialog", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : FillFormattingPanelAddRefLineBandOrBoxDialog" +ex.Message);
			}
		}
		
		public static void FillBoxPlotTab(string strColor)
		{
			try
			{
				repo.EditReferenceLineBandOrBox.ContentPanel.FillComboBoxInfo.WaitForItemExists(30000);
				repo.EditReferenceLineBandOrBox.ContentPanel.FillComboBox.ClickThis();
				SelectColor(strColor);
				Reports.ReportLog("FillBoxPlotTab", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : FillBoxPlotTab" +ex.Message);
			}
		}
		
		public static void FillRedColorBoxPlotTab()
		{
			try
			{
				repo.EditReferenceLineBandOrBox.ContentPanel.FillComboBoxInfo.WaitForItemExists(30000);
				repo.EditReferenceLineBandOrBox.ContentPanel.FillComboBox.ClickThis();
				repo.SubMenuItems.RedColorIconInfo.WaitForItemExists(30000);
				repo.SubMenuItems.RedColorIcon.ClickThis();
				Keyboard.Press("{ESCAPE}");
				Reports.ReportLog("FillRedColorBoxPlotTab", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : FillRedColorBoxPlotTab" +ex.Message);
			}
		}
		
		public static void FillPinkColorBoxPlotTab()
		{
			try
			{
				repo.EditReferenceLineBandOrBox.ContentPanel.FillComboBoxInfo.WaitForItemExists(30000);
				repo.EditReferenceLineBandOrBox.ContentPanel.FillComboBox.ClickThis();
				repo.SubMenuItems.NullContentPane.PinkColorIcon.ClickThis();
				Keyboard.Press("{ESCAPE}");
				Reports.ReportLog("FillPinkColorBoxPlotTab", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : FillPinkColorBoxPlotTab" +ex.Message);
			}
		}
		
		public static void SelectColor(string strColor)
		{
			try
			{
				switch(strColor)
				{
					case "Blue":
						repo.SubMenuItems.NullContentPane.blueColorIcon.ClickThis();
						break;
						
					case "Green":
						repo.SubMenuItems.GreenColorIcon.ClickThis();
						break;
						
					case "Dark Green":
						repo.SubMenuItems.NullContentPane.DarkGreenColorIcon.ClickThis();
						break;
						
					case "Orange":
						repo.SubMenuItems.NullContentPane.OrangecolorIcon.ClickThis();
						break;
					default:
						throw new ApplicationException("Invalid Color Provided "+strColor+"");
				}
				Keyboard.Press("{ESCAPE}");
				Reports.ReportLog("SelectColor", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectColor" +ex.Message);
			}
		}
		
		public static void SelectFirstLineAndColorBorderBoxPlotTab(string strColor)
		{
			try
			{
				repo.EditReferenceLineBandOrBox.ContentPanel.BorderComboBox.ClickThis();
				repo.SubMenuItems.NullContentPane.SectionHeader.ClickThis();
				SelectColor(strColor);
				Reports.ReportLog("SelectFirstLineAndColorBorderBoxPlotTab", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectFirstLineAndColorBorderBoxPlotTab" +ex.Message);
			}
		}
		
		public static void SelectSecLineAndBlueColorBorderBoxPlotTab()
		{
			try
			{
				repo.EditReferenceLineBandOrBox.ContentPanel.BorderComboBox.ClickThis();
				repo.SubMenuItems.FirstHeader.ClickThis();
				repo.SubMenuItems.NullContentPane.BlueColorIcon2.ClickThis();
				Keyboard.Press("{ESCAPE}");
				Reports.ReportLog("SelectSecLineAndBlueColorBorderBoxPlotTab", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectSecLineAndBlueColorBorderBoxPlotTab" +ex.Message);
			}
		}
		
		public static void SelectThirdineAndLimeColorBorderBoxPlotTab()
		{
			try
			{
				repo.EditReferenceLineBandOrBox.ContentPanel.BorderComboBox.ClickThis();
				repo.SubMenuItems.SecHeader.ClickThis();
				repo.SubMenuItems.NullContentPane.Lime.ClickThis();
				Keyboard.Press("{ESCAPE}");
				Reports.ReportLog("SelectThirdineAndLimeColorBorderBoxPlotTab", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectThirdineAndLimeColorBorderBoxPlotTab" +ex.Message);
			}
		}
		
		public static void SelectFourthlineAndSkyBlueColorBorderBoxPlotTab()
		{
			try
			{
				repo.EditReferenceLineBandOrBox.ContentPanel.BorderComboBox.ClickThis();
				repo.SubMenuItems.RightHori.ClickThis();
				repo.SubMenuItems.NullContentPane.SkyBlueColorIcon.ClickThis();
				Keyboard.Press("{ESCAPE}");
				Reports.ReportLog("SelectFourthlineAndSkyBlueColorBorderBoxPlotTab", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectFourthlineAndSkyBlueColorBorderBoxPlotTab" +ex.Message);
			}
		}
		
		public static void SelectFirstLineAndGreenColorWhiskerBoxPlotTab()
		{
			try
			{
				repo.EditReferenceLineBandOrBox.ContentPanel.Whiskers.ClickThis();
				repo.SubMenuItems.NullContentPane.SectionHeader1.ClickThis();
				repo.SubMenuItems.NullContentPane.GreenColorIcon.ClickThis();
				Keyboard.Press("{ESCAPE}");
				Reports.ReportLog("SelectFirstLineAndColorWhiskerBoxPlotTab", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectFirstLineAndColorWhiskerBoxPlotTab" +ex.Message);
			}
		}
		
		public static void SelectSecLineAndYelloColorWhiskerBoxPlotTab()
		{
			try
			{
				repo.EditReferenceLineBandOrBox.ContentPanel.Whiskers.ClickThis();
				repo.SubMenuItems.FirstHeader.ClickThis();
				repo.SubMenuItems.NullContentPane.YelloColorIcon.ClickThis();
				Keyboard.Press("{ESCAPE}");
				Reports.ReportLog("SelectSecLineAndYelloColorWhiskerBoxPlotTab", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectSecLineAndYelloColorWhiskerBoxPlotTab" +ex.Message);
			}
		}
		
		public static void SelectThirdLineAndLavanderColorWhiskerBoxPlotTab()
		{
			try
			{
				repo.EditReferenceLineBandOrBox.ContentPanel.Whiskers.ClickThis();
				repo.SubMenuItems.SecHeader.ClickThis();
				repo.SubMenuItems.NullContentPane.lavander.ClickThis();
				Keyboard.Press("{ESCAPE}");
				Reports.ReportLog("SelectThirdLineAndLavanderColorWhiskerBoxPlotTab", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectThirdLineAndLavanderColorWhiskerBoxPlotTab" +ex.Message);
			}
		}
		
		public static void SelectThirdLineAndVioletColorWhiskerBoxPlotTab()
		{
			try
			{
				repo.EditReferenceLineBandOrBox.ContentPanel.Whiskers.ClickThis();
				repo.SubMenuItems.SecHeader.ClickThis();
				repo.SubMenuItems.NullContentPane.Violate.ClickThis();
				Keyboard.Press("{ESCAPE}");
				Reports.ReportLog("SelectThirdLineAndVioletColorWhiskerBoxPlotTab", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectThirdLineAndVioletColorWhiskerBoxPlotTab" +ex.Message);
			}
		}
		
		public static void SelectFillAboveCmb()
		{
			try
			{
				repo.AddRefLineBandOrBoxDialog.cmbFillAbove.CheckboxCheck();
				Reports.ReportLog("SelectFillAboveCmb", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectFillAboveCmb" +ex.Message);
			}
		}
		
		public static void SelectFillBelowCmb()
		{
			try
			{
				repo.AddRefLineBandOrBoxDialog.cmbFillBelow.CheckboxCheck();
				Reports.ReportLog("SelectFillBelowCmb", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectFillBelowCmb" +ex.Message);
			}
		}
		
		public static void SelectSymmetricCmb()
		{
			try
			{
				repo.AddRefLineBandOrBoxDialog.cmbSymmetric.CheckboxCheck();
				Reports.ReportLog("SelectSymmetricCmb", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectSymmetricCmb" +ex.Message);
			}
		}
		
		public static void FillBelowFormattingPanelAddRefLineBandOrBoxDialog(string strColor)
		{
			try
			{
				repo.AddRefLineBandOrBoxDialog.formattingPanel.FillBelowCmbInfo.WaitForItemExists(30000);
				repo.AddRefLineBandOrBoxDialog.formattingPanel.FillBelowCmb.ClickThis();
				Thread.Sleep(500);
				if(strColor.Trim() == "Brown")
				{
					repo.SubMenuItems.BrownColorIcon.ClickThis();
				}else if(strColor.Trim() == "Light Orange")
				{
					repo.SubMenuItems.LightOrangeColorIcon.ClickThis();
				}
				else if(strColor.Trim() == "Green")
				{
					repo.SubMenuItems.GreenColorIcon.ClickThis();
				}
				else if(strColor.Trim() == "Plum")
				{
					repo.SubMenuItems.PlumColorIcon.ClickThis();
				}else{
					Report.Error("Provide Matching Color for Fill Below Element -- FillAboveFormattingPanelAddRefLineBandOrBoxDialog");
				}
				Keyboard.Press("{ESCAPE}");
				Reports.ReportLog("FillBelowFormattingPanelAddRefLineBandOrBoxDialog", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : FillBelowFormattingPanelAddRefLineBandOrBoxDialog" +ex.Message);
			}
		}
		
		public static void CheckRecalculateLineAddRefLineBandOrBoxDialog()
		{
			try
			{
				repo.AddRefLineBandOrBoxDialog.RecalLineBasedOnDtSelection.CheckboxCheck();
				Reports.ReportLog("RecalculateLineAddRefLineBandOrBoxDialog", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : RecalculateLineAddRefLineBandOrBoxDialog" +ex.Message);
			}
		}
		
		public static void CheckRecalculateBandAddRefLineBandOrBoxDialog()
		{
			try
			{
				repo.AddRefLineBandOrBoxDialog.CRecalBandBasedOnDtSelection.CheckboxCheck();
				Reports.ReportLog("CheckRecalculateBandAddRefLineBandOrBoxDialog", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CheckRecalculateBandAddRefLineBandOrBoxDialog" +ex.Message);
			}
		}
		
		public static void UnCheckRecalculateBandAddRefLineBandOrBoxDialog()
		{
			try
			{
				repo.AddRefLineBandOrBoxDialog.CRecalBandBasedOnDtSelection.CheckboxUnCheck();
				Reports.ReportLog("CheckRecalculateBandAddRefLineBandOrBoxDialog", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CheckRecalculateBandAddRefLineBandOrBoxDialog" +ex.Message);
			}
		}
		
		public static void UnCheckRecalculateLineAddRefLineBandOrBoxDialog()
		{
			try
			{
				repo.AddRefLineBandOrBoxDialog.RecalLineBasedOnDtSelection.CheckboxUnCheck();
				Reports.ReportLog("UnCheckRecalculateLineAddRefLineBandOrBoxDialog", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : UnCheckRecalculateLineAddRefLineBandOrBoxDialog" +ex.Message);
			}
		}
		
		public static void CheckHideUnderlyingMarks()
		{
			try
			{
				repo.EditReferenceLineBandOrBox.ContentPanel.HideUnderlyingMarksExceptOutliers.CheckboxCheck();
				Reports.ReportLog("CheckHideUnderlyingMarks", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CheckHideUnderlyingMarks" +ex.Message);
			}
		}
		
		public static void UnCheckHideUnderlyingMarks()
		{
			try
			{
				repo.EditReferenceLineBandOrBox.ContentPanel.HideUnderlyingMarksExceptOutliers.Uncheck();
				Reports.ReportLog("UnCheckHideUnderlyingMarks", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : UnCheckHideUnderlyingMarks" +ex.Message);
			}
		}
		
		public static void CheckRecalculDistributionCmb()
		{
			try
			{
				repo.AddRefLineBandOrBoxDialog.CPanel.RecalDistributionBasedOnDt.CheckboxCheck();
				Reports.ReportLog("CheckRecalculDistributionCmb", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CheckRecalculDistributionCmb" +ex.Message);
			}
		}
		
		public static void UnCheckRecalculDistributionCmb()
		{
			try
			{
				repo.AddRefLineBandOrBoxDialog.CPanel.RecalDistributionBasedOnDt.CheckboxUnCheck();
				Reports.ReportLog("UnCheckRecalculDistributionCmb", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : UnCheckRecalculDistributionCmb" +ex.Message);
			}
		}
		
		public static void UncheckRecalculateLineAddRefLineBandOrBoxDialog()
		{
			try
			{
				repo.AddRefLineBandOrBoxDialog.RecalBandBasedOnDtSelection.CheckboxUnCheck();
				Reports.ReportLog("UncheckRecalculateLineAddRefLineBandOrBoxDialog", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : UncheckRecalculateLineAddRefLineBandOrBoxDialog" +ex.Message);
			}
		}
		
		public static void ClickonApplyOkAdd()
		{
			try
			{
				repo.AddRefLineBandOrBoxDialog.CPanel.ApplyInfo.WaitForItemExists(30000);
				repo.AddRefLineBandOrBoxDialog.CPanel.Apply.ClickThis();
				repo.AddRefLineBandOrBoxDialog.CPanel.ButtonOKInfo.WaitForItemExists(30000);
				repo.AddRefLineBandOrBoxDialog.CPanel.ButtonOK.ClickThis();
				if(repo.AddRefLineBandOrBoxDialog.CPanel.ButtonOKInfo.Exists(3000))
				{
					repo.AddRefLineBandOrBoxDialog.CPanel.ButtonOKInfo.WaitForItemExists(30000);
					repo.AddRefLineBandOrBoxDialog.CPanel.ButtonOK.ClickThis();
				}
				Thread.Sleep(1000);
				Reports.ReportLog("ClickonApplyOkAdd", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonApplyOkAdd" +ex.Message);
			}
		}
		
		public static void SecLineFormattingPanelAddRefLineBandOrBoxDialog()
		{
			try
			{
				repo.AddRefLineBandOrBoxDialog.formattingPanel.LineCmbInfo.WaitForItemExists(30000);
				repo.AddRefLineBandOrBoxDialog.formattingPanel.LineCmb.ClickThis();
				repo.SubMenuItems.SecHeaderInfo.WaitForItemExists(30000);
				repo.SubMenuItems.SecHeader.ClickThis();
				Keyboard.Press("{ESCAPE}");
				Reports.ReportLog("SecLineFormattingPanelAddRefLineBandOrBoxDialog", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SecLineFormattingPanelAddRefLineBandOrBoxDialog" +ex.Message);
			}
		}
		
		public static void SecLineFormattingPanelLineTab()
		{
			try
			{
				repo.AddReferenceLineBandOrBox2.LineFrmgLineTabInfo.WaitForItemExists(30000);
				repo.AddReferenceLineBandOrBox2.LineFrmgLineTab.ClickThis();
				repo.SubMenuItems.SecHeaderInfo.WaitForItemExists(30000);
				repo.SubMenuItems.SecHeader.ClickThis();
				Keyboard.Press("{ESCAPE}");
				Reports.ReportLog("SecLineFormattingPanelLineTab", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SecLineFormattingPanelLineTab" +ex.Message);
			}
		}
		
		public static void SecLineFormattingPanelBand()
		{
			try
			{
				repo.AddReferenceLineBandOrBox2.LineCMbBandInfo.WaitForItemExists(30000);
				repo.AddReferenceLineBandOrBox2.LineCMbBand.ClickThis();
				repo.SubMenuItems.SecHeaderInfo.WaitForItemExists(30000);
				repo.SubMenuItems.SecHeader.ClickThis();
				Keyboard.Press("{ESCAPE}");
				Reports.ReportLog("SecLineFormattingPanelBand", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SecLineFormattingPanelBand" +ex.Message);
			}
		}
		
		public static void SecLineFormattingPanelDistribution()
		{
			try
			{
				repo.AddRefLineBandOrBoxDialog.LineCmbInfo.WaitForItemExists(30000);
				repo.AddRefLineBandOrBoxDialog.LineCmb.ClickThis();
				repo.SubMenuItems.SecHeaderInfo.WaitForItemExists(30000);
				repo.SubMenuItems.SecHeader.ClickThis();
				Keyboard.Press("{ESCAPE}");
				Reports.ReportLog("SecLineFormattingPanelDistribution", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SecLineFormattingPanelDistribution" +ex.Message);
			}
		}
		
		public static void ThirdLineFormattingPanelAddRefLineBandOrBoxDialog()
		{
			try
			{
				repo.AddReferenceLineBandOrBox2.LineCMbBandInfo.WaitForItemExists(30000);
				repo.AddReferenceLineBandOrBox2.LineCMbBand.ClickThis();
				repo.SubMenuItems.RightHoriInfo.WaitForItemExists(30000);
				repo.SubMenuItems.RightHori.ClickThis();
				Keyboard.Press("{ESCAPE}");
				Reports.ReportLog("ThirdLineFormattingPanelAddRefLineBandOrBoxDialog", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ThirdLineFormattingPanelAddRefLineBandOrBoxDialog" +ex.Message);
			}
		}
		
		
		public static void ThirdLineFormattingPanelBand()
		{
			try
			{
				repo.AddReferenceLineBandOrBox2.LineCMbBandInfo.WaitForItemExists(30000);
				repo.AddReferenceLineBandOrBox2.LineCMbBand.ClickThis();
				repo.SubMenuItems.RightHoriInfo.WaitForItemExists(30000);
				repo.SubMenuItems.RightHori.ClickThis();
				Keyboard.Press("{ESCAPE}");
				Reports.ReportLog("ThirdLineFormattingPanelAddRefLineBandOrBoxDialog", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ThirdLineFormattingPanelAddRefLineBandOrBoxDialog" +ex.Message);
			}
		}
		public static void ThirdLineFormattingPanelDistribution()
		{
			try
			{
				repo.AddRefLineBandOrBoxDialog.LineCmbInfo.WaitForItemExists(30000);
				repo.AddRefLineBandOrBoxDialog.LineCmb.ClickThis();
				repo.SubMenuItems.RightHoriInfo.WaitForItemExists(30000);
				repo.SubMenuItems.RightHori.ClickThis();
				Keyboard.Press("{ESCAPE}");
				Reports.ReportLog("ThirdLineFormattingPanelDistribution", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ThirdLineFormattingPanelDistribution" +ex.Message);
			}
		}
		
		
		
	}
}
