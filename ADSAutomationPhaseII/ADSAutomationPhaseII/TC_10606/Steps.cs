using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Repository;
using Ranorex.Core.Testing;
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Preconditions;

namespace ADSAutomationPhaseII.TC_10606
{ 
	
	public static class Steps
    {
   	    public static TC10606Repo repo = TC10606Repo.Instance;
   	    public static string TC_10606_PATH = System.Configuration.ConfigurationManager.AppSettings["TC_10606"].ToString();
   	    
   	    public static void SelectNewFile()
		{
			try 
			{
				repo.OpenWindow.FilePathTextbox.TextBoxText(TC_10606_PATH + "test-visualization.vizx");
				Reports.ReportLog("SelectNewFile", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectNewFile : " + ex.Message);
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
   	    
   	    public static void ClickonUndoIcon()
		{
			try 
			{
				repo.VAWindow.UndoButtonInfo.WaitForItemExists(10000);
				repo.VAWindow.UndoButton.ClickThis();
				Reports.ReportLog("ClickonUndoIcon", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonUndoIcon : " + ex.Message);
			}
		}
   	    
   	    public static void SelectPivotGrid()
		{
			try 
			{
				Keyboard.Press("{LControlKey down}");
				repo.VAWindow.ContainerLeftPanel.ProductSubCategoryInfo.WaitForItemExists(30000);
				repo.VAWindow.ContainerLeftPanel.ProductSubCategory.ClickThis();
				repo.VAWindow.SUMProfit.ClickThis();
				repo.VAWindow.Button.ClickThis();
				Reports.ReportLog("SelectPivotGrid", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectPivotGrid : " + ex.Message);
			}
    	}
   	    
   	    public static void ValidatePivotGrid()
		{
            try 
            {
            	CompressedImage LineDistribution = repo.VAWindow.PivotWindow1Info.GetPivotGrid1();
                Imaging.FindOptions options = Imaging.FindOptions.Default;
                options.Similarity = 0.50f;
                RepoItemInfo info = repo.VAWindow.PivotWindowInfo;
                Validate.ContainsImage(info, LineDistribution, options, "After Select pivot data validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidatePivotGrid : " + ex.Message);
			}
		}
   	    
   	    public static void SelectHighlightTable()
		{
			try 
			{
				Keyboard.Press("{LControlKey down}");
				repo.VAWindow.ContainerLeftPanel.ProductSubCategoryInfo.WaitForItemExists(30000);
				repo.VAWindow.ContainerLeftPanel.ProductSubCategory.ClickThis();
				repo.VAWindow.ContainerLeftPanel.SUMProfitInfo.WaitForItemExists(30000);
	            repo.VAWindow.ContainerLeftPanel.SUMProfit.ClickThis();
	            repo.VAWindow.JPanel.ButtonInfo.WaitForItemExists(30000);
	            repo.VAWindow.JPanel.Button.ClickThis();
				Reports.ReportLog("SelectHighlightTable", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectBrakesOption : " + ex.Message);
			}
    	}
   	    
   	    public static void ValidateHighlightTable()
		{
            try 
            {
            	CompressedImage LineDistribution = repo.VAWindow.PivotWindow1Info.GetHighlightTable();
                Imaging.FindOptions options = Imaging.FindOptions.Default;
                options.Similarity = 0.75f;
                RepoItemInfo info = repo.VAWindow.PivotWindowInfo;
                Validate.ContainsImage(info, LineDistribution, options, "After Select highlight table data validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonUncheckAll : " + ex.Message);
			}
		}
   	    
   	    public static void SelectHeatMap()
		{
			try 
			{
				Keyboard.Press("{LControlKey down}");
				repo.VAWindow.ContainerLeftPanel.ProductSubCategoryInfo.WaitForItemExists(30000);
				repo.VAWindow.ContainerLeftPanel.ProductSubCategory.ClickThis();
	            repo.VAWindow.ContainerLeftPanel.SUMProfit.ClickThis();
	            repo.VAWindow.JPanel.Button1.ClickThis();
				Reports.ReportLog("SelectHeatMap", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectHeatMap : " + ex.Message);
			}
    	}
   	    
   	    public static void ValidateSelectHeatMap()
		{
            try 
            {
            	CompressedImage LineDistribution = repo.VAWindow.PivotWindowInfo.GetHeatMap();
                Imaging.FindOptions options = Imaging.FindOptions.Default;
                options.Similarity = 0.75f;
                RepoItemInfo info = repo.VAWindow.PivotWindowInfo;
                Validate.ContainsImage(info, LineDistribution, options, "After Select heat map data validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateSelectHeatMap : " + ex.Message);
			}
		}
   	    
   	    public static void SelectBar()
		{
			try 
			{
				Keyboard.Press("{LControlKey down}");
				repo.VAWindow.ContainerLeftPanel.ProductNameInfo.WaitForItemExists(30000);
				repo.VAWindow.ContainerLeftPanel.ProductName.ClickThis();
				repo.VAWindow.ContainerLeftPanel.SUMCustomerID.ClickThis();
				repo.VAWindow.JPanel.CSplitButtonInfo.WaitForItemExists(30000);
				repo.VAWindow.JPanel.CSplitButton.ClickThis();
				Reports.ReportLog("SelectBar", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectBar : " + ex.Message);
			}
    	}
   	    
   	    public static void ValidateBarChart()
		{
            try 
            {
            	CompressedImage LineDistribution = repo.VAWindow.PivotWindowInfo.GetBarChart1();
                Imaging.FindOptions options = Imaging.FindOptions.Default;
                options.Similarity = 0.75f;
                RepoItemInfo info = repo.VAWindow.PivotWindowInfo;
                Validate.ContainsImage(info, LineDistribution, options, "After Select bar chart data validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateBarChart : " + ex.Message);
			}
		}
   	    
   	    public static void SelectSideSidebyBars()
		{
			try 
			{
				Keyboard.Press("{LControlKey down}");
				repo.VAWindow.ContainerLeftPanel.ProductNameInfo.WaitForItemExists(30000);
				repo.VAWindow.ContainerLeftPanel.ProductName.ClickThis();
	            repo.VAWindow.ContainerLeftPanel.SUMCustomerID.ClickThis();
	            repo.VAWindow.JPanel.CSplitButton1Info.WaitForItemExists(30000);
	            repo.VAWindow.JPanel.CSplitButton1.ClickThis();
				Reports.ReportLog("SelectSideSidebyBars", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectSideSidebyBars : " + ex.Message);
			}
    	}
   	    
   	    public static void ValidateSidebySideBar()
		{
            try 
            {
            	CompressedImage LineDistribution = repo.VAWindow.PivotWindowInfo.GetSidebySideBar();
                Imaging.FindOptions options = Imaging.FindOptions.Default;
                options.Similarity = 0.75f;
                RepoItemInfo info = repo.VAWindow.PivotWindowInfo;
                Validate.ContainsImage(info, LineDistribution, options, "After Select side by side bar data validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateSidebySideBar : " + ex.Message);
			}
		}
   	    
   	    public static void SelectStackedBars()
		{
			try 
			{
				Keyboard.Press("{LControlKey down}");
				repo.VAWindow.ContainerLeftPanel.ProductNameInfo.WaitForItemExists(30000);
				repo.VAWindow.ContainerLeftPanel.ProductName.ClickThis();
	            repo.VAWindow.ContainerLeftPanel.SUMCustomerID.ClickThis();
	            repo.VAWindow.JPanel.CSplitButton2Info.WaitForItemExists(30000);
	            repo.VAWindow.JPanel.CSplitButton2.ClickThis();
				Reports.ReportLog("SelectStackedBars", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectStackedBars : " + ex.Message);
			}
    	}
   	    
   	    public static void ValidateStackedBars()
		{
            try 
            {
            	CompressedImage LineDistribution = repo.VAWindow.PivotWindowInfo.GetStackedBar();
                Imaging.FindOptions options = Imaging.FindOptions.Default;
                options.Similarity = 0.75f;
                RepoItemInfo info = repo.VAWindow.PivotWindowInfo;
                Validate.ContainsImage(info, LineDistribution, options, "After Select stacked bar bar data validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateStackedBars : " + ex.Message);
			}
		}
   	    
   	    public static void SelectLineContinues()
		{
			try 
			{
				Keyboard.Press("{LControlKey down}");
				repo.VAWindow.ContainerLeftPanel.OrderDateInfo.WaitForItemExists(30000);
				repo.VAWindow.ContainerLeftPanel.OrderDate.ClickThis();
	            repo.VAWindow.ContainerLeftPanel.SUMOrderID.ClickThis();
	            repo.VAWindow.JPanel.CSplitButton3Info.WaitForItemExists(30000);
	            repo.VAWindow.JPanel.CSplitButton3.ClickThis();
				Reports.ReportLog("SelectLineContinues", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectLineContinues : " + ex.Message);
			}
    	}
   	    
   	    public static void ValidateLineContinues()
		{
            try 
            {
            	CompressedImage LineDistribution = repo.VAWindow.PivotWindowInfo.GetLineContiues();
                Imaging.FindOptions options = Imaging.FindOptions.Default;
                options.Similarity = 0.75f;
                RepoItemInfo info = repo.VAWindow.PivotWindowInfo;
                Validate.ContainsImage(info, LineDistribution, options, "After Select Line continues data validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateLineContinues : " + ex.Message);
			}
		}
   	    
   	    public static void SelectLineDescrete()
		{
			try 
			{
				Keyboard.Press("{LControlKey down}");
				repo.VAWindow.ContainerLeftPanel.OrderDateInfo.WaitForItemExists(30000);
				repo.VAWindow.ContainerLeftPanel.OrderDate.ClickThis();
	            repo.VAWindow.ContainerLeftPanel.SUMOrderID.ClickThis();
	            repo.VAWindow.JPanel.CSplitButton4Info.WaitForItemExists(30000);
	            repo.VAWindow.JPanel.CSplitButton4.ClickThis();
				Reports.ReportLog("SelectLineDescrete", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectLineDescrete : " + ex.Message);
			}
    	}
   	    
   	    public static void ValidateLineDescrete()
		{
            try 
            {
            	CompressedImage LineDistribution = repo.VAWindow.PivotWindowInfo.GetLineDescrete();
                Imaging.FindOptions options = Imaging.FindOptions.Default;
                options.Similarity = 0.75f;
                RepoItemInfo info = repo.VAWindow.PivotWindowInfo;
                Validate.ContainsImage(info, LineDistribution, options, "After Select Line descrete data validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateLineDescrete : " + ex.Message);
			}
		}
   	    
   	    public static void SelectDualLine()
		{
			try 
			{
				Keyboard.Press("{LControlKey down}");
				repo.VAWindow.ContainerLeftPanel.ShipDateInfo.WaitForItemExists(30000);
				repo.VAWindow.ContainerLeftPanel.ShipDate.ClickThis();
	            repo.VAWindow.ContainerLeftPanel.SUMOrderID.ClickThis();
	            repo.VAWindow.ContainerLeftPanel.SUMPostalCode.ClickThis();
	            repo.VAWindow.JPanel.CSplitButton5Info.WaitForItemExists(30000);
	            repo.VAWindow.JPanel.CSplitButton5.ClickThis();
				Reports.ReportLog("SelectDualLine", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectDualLine : " + ex.Message);
			}
    	}
   	    
   	    public static void ValidateDualLines()
		{
            try 
            {
            	CompressedImage LineDistribution = repo.VAWindow.PivotWindowInfo.GetDualLines();
                Imaging.FindOptions options = Imaging.FindOptions.Default;
                options.Similarity = 0.75f;
                RepoItemInfo info = repo.VAWindow.PivotWindowInfo;
                Validate.ContainsImage(info, LineDistribution, options, "After Select dual lines data validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateDualLines : " + ex.Message);
			}
		}
   	    
   	    public static void SelectAreaContinues()
		{
			try 
			{
				Keyboard.Press("{LControlKey down}");
				repo.VAWindow.ContainerLeftPanel.ShipDateInfo.WaitForItemExists(30000);
				repo.VAWindow.ContainerLeftPanel.ShipDate.ClickThis();
	            repo.VAWindow.ContainerLeftPanel.SUMOrderID.ClickThis();
	            repo.VAWindow.JPanel.CSplitButton6Info.WaitForItemExists(30000);
	            repo.VAWindow.JPanel.CSplitButton6.ClickThis();
				Reports.ReportLog("SelectAreaContinues", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectAreaContinues : " + ex.Message);
			}
    	}
   	    
   	    public static void ValidateSelectAreaContinues()
		{
            try 
            {
            	CompressedImage LineDistribution = repo.VAWindow.PivotWindowInfo.GetAreaContinues();
                Imaging.FindOptions options = Imaging.FindOptions.Default;
                options.Similarity = 0.50f;
                RepoItemInfo info = repo.VAWindow.PivotWindowInfo;
                Validate.ContainsImage(info, LineDistribution, options, "After Select Area Continues data validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateSelectAreaContinues : " + ex.Message);
			}
		}
   	    
   	    public static void SelectAreaDescrete()
		{
			try 
			{
				Keyboard.Press("{LControlKey down}");
				repo.VAWindow.ContainerLeftPanel.ShipDateInfo.WaitForItemExists(30000);
				repo.VAWindow.ContainerLeftPanel.ShipDate.ClickThis();
	            repo.VAWindow.ContainerLeftPanel.SUMOrderID.ClickThis();
	            repo.VAWindow.JPanel.CSplitButton7.ClickThis();
				Reports.ReportLog("SelectAreaDescrete", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectBrakesOption : " + ex.Message);
			}
    	}
   	    
   	    public static void ValidateAreaDescrete()
		{
            try 
            {
            	CompressedImage LineDistribution = repo.VAWindow.PivotWindowInfo.GetAreaDescrete();
                Imaging.FindOptions options = Imaging.FindOptions.Default;
                options.Similarity = 0.75f;
                RepoItemInfo info = repo.VAWindow.PivotWindowInfo;
                Validate.ContainsImage(info, LineDistribution, options, "After select Area Descrete data validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAreaDescrete : " + ex.Message);
			}
		}

		public static void SelectSidebySideArea()
		{
			try 
			{
				Keyboard.Press("{LControlKey down}");
				repo.VAWindow.ContainerLeftPanel.ShipDateInfo.WaitForItemExists(30000);
				repo.VAWindow.ContainerLeftPanel.ShipDate.ClickThis();
	            repo.VAWindow.ContainerLeftPanel.SUMOrderID.ClickThis();
	            repo.VAWindow.JPanel.CSplitButton8Info.WaitForItemExists(30000);
	            repo.VAWindow.JPanel.CSplitButton8.ClickThis();
				Reports.ReportLog("SelectSidebySideArea", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectSidebySideArea : " + ex.Message);
			}
    	}
		
		public static void ValidateSidebySideArea()
		{
            try 
            {
            	CompressedImage LineDistribution = repo.VAWindow.PivotWindowInfo.GetSisebysideArea();
                Imaging.FindOptions options = Imaging.FindOptions.Default;
                options.Similarity = 0.75f;
                RepoItemInfo info = repo.VAWindow.PivotWindowInfo;
                Validate.ContainsImage(info, LineDistribution, options, "After select Side by Side Area data validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateSidebySideArea : " + ex.Message);
			}
		}

		public static void SelectStackedArea()
		{
			try 
			{
				Keyboard.Press("{LControlKey down}");
				repo.VAWindow.ContainerLeftPanel.ShipDateInfo.WaitForItemExists(30000);
				repo.VAWindow.ContainerLeftPanel.ShipDate.ClickThis();
	            repo.VAWindow.ContainerLeftPanel.SUMCustomerID.ClickThis();
	            repo.VAWindow.JPanel.CSplitButton9Info.WaitForItemExists(30000);
	            repo.VAWindow.JPanel.CSplitButton9.ClickThis();
				Reports.ReportLog("SelectStackedArea", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectStackedArea : " + ex.Message);
			}
    	}
		
		public static void ValidateStackedArea()
		{
            try 
            {
            	CompressedImage LineDistribution = repo.VAWindow.PivotWindowInfo.GetStackedArea();
                Imaging.FindOptions options = Imaging.FindOptions.Default;
                options.Similarity = 0.75f;
                RepoItemInfo info = repo.VAWindow.PivotWindowInfo;
                Validate.ContainsImage(info, LineDistribution, options, "After select Stacked area data validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateStackedArea : " + ex.Message);
			}
		}
		
		public static void SelectDualCombination()
		{
			try 
			{
				Keyboard.Press("{LControlKey down}");
				repo.VAWindow.ContainerLeftPanel.ShipDateInfo.WaitForItemExists(30000);
				repo.VAWindow.ContainerLeftPanel.ShipDate.ClickThis();
            	repo.VAWindow.ContainerLeftPanel.SUMPostalCode.ClickThis();
            	repo.VAWindow.ContainerLeftPanel.SUMShippingCost.ClickThis();
            	repo.VAWindow.JPanel.Button8Info.WaitForItemExists(30000);
           		repo.VAWindow.JPanel.Button8.ClickThis();
				Reports.ReportLog("SelectDualCombination", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectDualCombination : " + ex.Message);
			}
    	}
		
		public static void ValidateDualCombination()
		{
            try 
            {
            	CompressedImage LineDistribution = repo.VAWindow.PivotWindowInfo.GetDualCombination();
                Imaging.FindOptions options = Imaging.FindOptions.Default;
                options.Similarity = 0.75f;
                RepoItemInfo info = repo.VAWindow.PivotWindowInfo;
                Validate.ContainsImage(info, LineDistribution, options, "After select dual combination data validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateDualCombination : " + ex.Message);
			}
		}
	
		public static void SelectScotterPlot()
		{
			try 
			{
				Keyboard.Press("{LControlKey down}");
				repo.VAWindow.ContainerLeftPanel.SUMOrderIDInfo.WaitForItemExists(30000);
				repo.VAWindow.ContainerLeftPanel.SUMOrderID.ClickThis();
	            repo.VAWindow.ContainerLeftPanel.SUMCustomerID.ClickThis();
	            repo.VAWindow.JPanel.Button9Info.WaitForItemExists(30000);
	            repo.VAWindow.JPanel.Button9.ClickThis();
				Reports.ReportLog("SelectScotterPlot", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectScotterPlot : " + ex.Message);
			}
    	}
		
		public static void ValidateScotterPlot()
		{
            try 
            {
            	CompressedImage LineDistribution = repo.VAWindow.PivotWindowInfo.GetScotterPlot();
                Imaging.FindOptions options = Imaging.FindOptions.Default;
                options.Similarity = 0.75f;
                RepoItemInfo info = repo.VAWindow.PivotWindowInfo;
                Validate.ContainsImage(info, LineDistribution, options, "After select Scotter Plot data validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateScotterPlot : " + ex.Message);
			}
		}
		
		public static void SelectBubble()
		{
			try 
			{
				Keyboard.Press("{LControlKey down}");
				repo.VAWindow.ContainerLeftPanel.CustomerName.ClickThis();
	            repo.VAWindow.ContainerLeftPanel.SUMCustomerID.ClickThis();
	            repo.VAWindow.ContainerLeftPanel.SUMOrderID.ClickThis();
	            repo.VAWindow.ContainerLeftPanel.SUMRowID.ClickThis();
	            repo.VAWindow.JPanel.Button20Info.WaitForItemExists(30000);
	            repo.VAWindow.JPanel.Button20.ClickThis();
				Reports.ReportLog("SelectBubble", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectBubble : " + ex.Message);
			}
    	}
		
		public static void ValidateBubble()
		{
            try 
            {
            	CompressedImage LineDistribution = repo.VAWindow.PivotWindowInfo.GetBubbleChart();
                Imaging.FindOptions options = Imaging.FindOptions.Default;
                options.Similarity = 0.75f;
                RepoItemInfo info = repo.VAWindow.PivotWindowInfo;
                Validate.ContainsImage(info, LineDistribution, options, "After select bubble chart data validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateBubble : " + ex.Message);
			}
		}
		
		public static void SelectFilledMap()
		{
			try 
			{
				Keyboard.Press("{LControlKey down}");
				repo.VAWindow.ContainerLeftPanel.RegionInfo.WaitForItemExists(30000);
				repo.VAWindow.ContainerLeftPanel.Region.ClickThis();
	            repo.VAWindow.ContainerLeftPanel.StateOrProvince.ClickThis();
	            repo.VAWindow.ContainerLeftPanel.SUMShippingCost.ClickThis();
	            repo.VAWindow.JPanel.Button3.ClickThis();
				Reports.ReportLog("SelectFilledMap", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectFilledMap : " + ex.Message);
			}
    	}
		
		public static void ValidateFilledMap()
		{
            try 
            {
            	CompressedImage LineDistribution = repo.VAWindow.PivotWindowInfo.GetFilledMap();
                Imaging.FindOptions options = Imaging.FindOptions.Default;
                options.Similarity = 0.75f;
                RepoItemInfo info = repo.VAWindow.PivotWindowInfo;
                Validate.ContainsImage(info, LineDistribution, options, "After select Filled Map data validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateFilledMap : " + ex.Message);
			}
		}
   	   
		public static void SelectSymbolMap()
		{
			try 
			{
				Keyboard.Press("{LControlKey down}");
				repo.VAWindow.ContainerLeftPanel.City.ClickThis();
				repo.VAWindow.ContainerLeftPanel.SUMShippingCost.ClickThis();
				repo.VAWindow.JPanel.Button19.ClickThis();
				Reports.ReportLog("SelectSymbolMap", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectSymbolMap : " + ex.Message);
			}
    	}
		
		public static void ValidateSymbolMap()
		{
            try 
            {
            	CompressedImage LineDistribution = repo.VAWindow.PivotWindowInfo.GetSymbolMap();
                Imaging.FindOptions options = Imaging.FindOptions.Default;
                options.Similarity = 0.75f;
                RepoItemInfo info = repo.VAWindow.PivotWindowInfo;
                Validate.ContainsImage(info, LineDistribution, options, "After select Symbol Map data validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateSymbolMap : " + ex.Message);
			}
		}
		
		public static void SelectPieChart()
		{
			try 
			{
				Keyboard.Press("{LControlKey down}");
				repo.VAWindow.ContainerLeftPanel.ProductNameInfo.WaitForItemExists(30000);
				repo.VAWindow.ContainerLeftPanel.ProductName.ClickThis();
	            repo.VAWindow.ContainerLeftPanel.SUMCustomerID.ClickThis();
	            repo.VAWindow.JPanel.Button4.ClickThis();
				Reports.ReportLog("SelectPieChart", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectPieChart : " + ex.Message);
			}
    	}
		
		public static void ValidatePieChart()
		{
            try 
            {
            	CompressedImage LineDistribution = repo.VAWindow.PivotWindowInfo.GetPieChart();
                Imaging.FindOptions options = Imaging.FindOptions.Default;
                options.Similarity = 0.75f;
                RepoItemInfo info = repo.VAWindow.PivotWindowInfo;
                Validate.ContainsImage(info, LineDistribution, options, "After select Pie chart data validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidatePieChart : " + ex.Message);
			}
		}
		
		public static void SelectSunBurst()
		{
			try 
			{
				Keyboard.Press("{LControlKey down}");
				repo.VAWindow.ContainerLeftPanel.CustomerNameInfo.WaitForItemExists(30000);
				repo.VAWindow.ContainerLeftPanel.CustomerName.ClickThis();
	            repo.VAWindow.ContainerLeftPanel.Region.ClickThis();
	            repo.VAWindow.ContainerLeftPanel.SUMOrderID.ClickThis();
	            repo.VAWindow.JPanel.Button5.ClickThis();
				Reports.ReportLog("SelectSunBurst", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectSunBurst : " + ex.Message);
			}
    	}
		
		public static void ValidateSunBurst()
		{
            try 
            {
            	CompressedImage LineDistribution = repo.VAWindow.PivotWindowInfo.GetSunBurst();
                Imaging.FindOptions options = Imaging.FindOptions.Default;
                options.Similarity = 0.75f;
                RepoItemInfo info = repo.VAWindow.PivotWindowInfo;
                Validate.ContainsImage(info, LineDistribution, options, "After select Sunburst data validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateSunBurst : " + ex.Message);
			}
		}
		
		public static void SelectTreeMap()
		{
			try 
			{
				Keyboard.Press("{LControlKey down}");
				repo.VAWindow.ContainerLeftPanel.CustomerNameInfo.WaitForItemExists(30000);
	            repo.VAWindow.ContainerLeftPanel.CustomerName.ClickThis();
	            repo.VAWindow.ContainerLeftPanel.SUMOrderID.ClickThis();
	            repo.VAWindow.ContainerLeftPanel.SUMPostalCode.ClickThis();
	            repo.VAWindow.JPanel.Button6Info.WaitForItemExists(30000);
	            repo.VAWindow.JPanel.Button6.ClickThis();
				Reports.ReportLog("SelectPivotGrid", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectTreeMap : " + ex.Message);
			}
    	}
		
		public static void ValidateTreemap()
		{
            try 
            {
            	CompressedImage LineDistribution = repo.VAWindow.PivotWindowInfo.GetTreeMap();
                Imaging.FindOptions options = Imaging.FindOptions.Default;
                options.Similarity = 0.75f;
                RepoItemInfo info = repo.VAWindow.PivotWindowInfo;
                Validate.ContainsImage(info, LineDistribution, options, "After select tree map data validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateTreemap : " + ex.Message);
			}
		}
		
		public static void SelectCandleStick()
		{
			try 
			{
				Keyboard.Press("{LControlKey down}");
				repo.VAWindow.ContainerLeftPanel.OrderDateInfo.WaitForItemExists(30000);
				repo.VAWindow.ContainerLeftPanel.OrderDate.ClickThis();
	            repo.VAWindow.ContainerLeftPanel.SUMCustomerID.ClickThis();
	            repo.VAWindow.ContainerLeftPanel.SUMOrderID.ClickThis();
	            repo.VAWindow.ContainerLeftPanel.SUMPostalCode.ClickThis();
	            repo.VAWindow.ContainerLeftPanel.SUMProfit.ClickThis();
	            repo.VAWindow.JPanel.Button7Info.WaitForItemExists(30000);
	            repo.VAWindow.JPanel.Button7.ClickThis();
				Reports.ReportLog("SelectCandleStick", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectCandleStick : " + ex.Message);
			}
    	}
		
		public static void ValidateCandleStick()
		{
            try 
            {
            	CompressedImage LineDistribution = repo.VAWindow.PivotWindowInfo.GetCandleStick();
                Imaging.FindOptions options = Imaging.FindOptions.Default;
                options.Similarity = 0.75f;
                RepoItemInfo info = repo.VAWindow.PivotWindowInfo;
                Validate.ContainsImage(info, LineDistribution, options, "After select Candle stick data validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateCandleStick : " + ex.Message);
			}
		}
		
		public static void SelectCandlestickConfiguration()
		{
			try 
			{
				Keyboard.Press("{LControlKey down}");
				repo.ConfigureCandlestickChart.ConfigureInfo.WaitForItemExists(30000);
	            repo.ConfigureCandlestickChart.Configure.ClickThis();
				Reports.ReportLog("SelectCandlestickConfiguration", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectCandlestickConfiguration : " + ex.Message);
			}
    	}
		
		public static void SelectHLCConfiguration()
		{
			try 
			{
				repo.HLCChart.ConfigureInfo.WaitForItemExists(30000);
	            repo.HLCChart.Configure.ClickThis();
				Reports.ReportLog("SelectHLCConfiguration", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectHLCConfiguration : " + ex.Message);
			}
    	}
		
		public static void SelectFunnelMap()
		{
			try 
			{
				Keyboard.Press("{LControlKey down}");
				repo.VAWindow.ContainerLeftPanel.ProductNameInfo.WaitForItemExists(30000);
	            repo.VAWindow.ContainerLeftPanel.ProductName.ClickThis();
	            repo.VAWindow.ContainerLeftPanel.SUMCustomerID.ClickThis();
	            repo.VAWindow.ContainerLeftPanel.SUMOrderID.ClickThis();
	            repo.VAWindow.JPanel.Button11Info.WaitForItemExists(30000);
	            repo.VAWindow.JPanel.Button11.ClickThis();
				Reports.ReportLog("SelectFunnelMap", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectFunnelMap : " + ex.Message);
			}
    	}
		
		public static void ValidateFunnelMap()
		{
            try 
            {
            	CompressedImage LineDistribution = repo.VAWindow.PivotWindowInfo.GetFunnelMap();
                Imaging.FindOptions options = Imaging.FindOptions.Default;
                options.Similarity = 0.75f;
                RepoItemInfo info = repo.VAWindow.PivotWindowInfo;
                Validate.ContainsImage(info, LineDistribution, options, "After select funnel map data validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateFunnelMap : " + ex.Message);
			}
		}
		
		public static void SelectHighLowClose()
		{
			try 
			{
				Keyboard.Press("{LControlKey down}");
				repo.VAWindow.ContainerLeftPanel.OrderDateInfo.WaitForItemExists(30000);
	            repo.VAWindow.ContainerLeftPanel.OrderDate.ClickThis();
	            repo.VAWindow.ContainerLeftPanel.SUMCustomerID.ClickThis();
	            repo.VAWindow.ContainerLeftPanel.SUMOrderID.ClickThis();
	            repo.VAWindow.ContainerLeftPanel.SUMPostalCode.ClickThis();
	            repo.VAWindow.JPanel.Button10Info.WaitForItemExists(30000);
	            repo.VAWindow.JPanel.Button10.ClickThis();
				Reports.ReportLog("SelectHighLowClose", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectHighLowClose : " + ex.Message);
			}
    	}
		
		public static void ValidateHighLowClose()
		{
            try 
            {
            	CompressedImage LineDistribution = repo.VAWindow.PivotWindowInfo.GetHighLowClose();
                Imaging.FindOptions options = Imaging.FindOptions.Default;
                options.Similarity = 0.75f;
                RepoItemInfo info = repo.VAWindow.PivotWindowInfo;
                Validate.ContainsImage(info, LineDistribution, options, "After select high low close data validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateHighLowClose : " + ex.Message);
			}
		}
		
		public static void SelectGuageChart()
		{
			try 
			{
				Keyboard.Press("{LControlKey down}");
				repo.VAWindow.ContainerLeftPanel.CustomerNameInfo.WaitForItemExists(30000);
	           	repo.VAWindow.ContainerLeftPanel.CustomerName.ClickThis();
	            repo.VAWindow.ContainerLeftPanel.SUMOrderID.ClickThis();
	            repo.VAWindow.JPanel.Button12Info.WaitForItemExists(30000);
	            repo.VAWindow.JPanel.Button12.ClickThis();
				Reports.ReportLog("SelectGuageChart", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectGuageChart : " + ex.Message);
			}
    	}
		
		public static void ValidateGuageChart()
		{
            try 
            {
            	CompressedImage LineDistribution = repo.VAWindow.PivotWindowInfo.GetGuageChart();
                Imaging.FindOptions options = Imaging.FindOptions.Default;
                options.Similarity = 0.75f;
                RepoItemInfo info = repo.VAWindow.PivotWindowInfo;
                Validate.ContainsImage(info, LineDistribution, options, "After select guage chart data validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateGuageChart : " + ex.Message);
			}
		}
   	    
		public static void SelectMekko()
		{
			try 
			{
				Keyboard.Press("{LControlKey down}");
				repo.VAWindow.ContainerLeftPanel.CustomerNameInfo.WaitForItemExists(30000);
	           	repo.VAWindow.ContainerLeftPanel.CustomerName.ClickThis();
	            repo.VAWindow.ContainerLeftPanel.ProductName.ClickThis();
	            repo.VAWindow.ContainerLeftPanel.SUMOrderID.ClickThis();
	            repo.VAWindow.JPanel.Button14Info.WaitForItemExists(30000);
	            repo.VAWindow.JPanel.Button14.ClickThis();
				Reports.ReportLog("SelectMekko", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectMekko : " + ex.Message);
			}
    	}
		
		public static void ValidateMekkoChart()
		{
            try 
            {
            	CompressedImage LineDistribution = repo.VAWindow.PivotWindowInfo.GetMekko();
                Imaging.FindOptions options = Imaging.FindOptions.Default;
                options.Similarity = 0.75f;
                RepoItemInfo info = repo.VAWindow.PivotWindowInfo;
                Validate.ContainsImage(info, LineDistribution, options, "After select mekko chart data validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateMekkoChart : " + ex.Message);
			}
		}
		
		public static void SelectRadar()
		{
			try 
			{
				Keyboard.Press("{LControlKey down}");
				repo.VAWindow.ContainerLeftPanel.ProductCategoryInfo.WaitForItemExists(30000);
	           	repo.VAWindow.ContainerLeftPanel.ProductCategory.ClickThis();
	            repo.VAWindow.ContainerLeftPanel.SUMOrderID.ClickThis();
	            repo.VAWindow.JPanel.Button15.ClickThis();
				Reports.ReportLog("SelectRadar", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectRadar : " + ex.Message);
			}
    	}
		
		public static void ValidateRadarChart()
		{
            try 
            {
            	CompressedImage LineDistribution = repo.VAWindow.PivotWindowInfo.GetRadar();
                Imaging.FindOptions options = Imaging.FindOptions.Default;
                options.Similarity = 0.75f;
                RepoItemInfo info = repo.VAWindow.PivotWindowInfo;
                Validate.ContainsImage(info, LineDistribution, options, "After select radar chart data validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateRadarChart : " + ex.Message);
			}
		}
		
		public static void SelectBoxPlot()
		{
			try 
			{
				Keyboard.Press("{LControlKey down}");
				repo.VAWindow.ContainerLeftPanel.ProductNameInfo.WaitForItemExists(30000);
	           	repo.VAWindow.ContainerLeftPanel.ProductName.ClickThis();
	            repo.VAWindow.ContainerLeftPanel.SUMCustomerID.ClickThis();
	            repo.VAWindow.ContainerLeftPanel.SUMOrderID.ClickThis();
	            repo.VAWindow.JPanel.Button17Info.WaitForItemExists(30000);
	            repo.VAWindow.JPanel.Button18.ClickThis();
				Reports.ReportLog("SelectBoxPlot", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectBoxPlot : " + ex.Message);
			}
    	}
		
		public static void ValidateBoxPlot()
		{
            try 
            {
            	CompressedImage LineDistribution = repo.VAWindow.PivotWindowInfo.GetBoxPlot();
                Imaging.FindOptions options = Imaging.FindOptions.Default;
                options.Similarity = 0.75f;
                RepoItemInfo info = repo.VAWindow.PivotWindowInfo;
                Validate.ContainsImage(info, LineDistribution, options, "After select boxplot chart data validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateBoxPlot : " + ex.Message);
			}
		}
		
		public static void SelectHorizon()
		{
			try 
			{
				Keyboard.Press("{LControlKey down}");
				repo.VAWindow.ContainerLeftPanel.OrderDateInfo.WaitForItemExists(30000);
	           	repo.VAWindow.ContainerLeftPanel.OrderDate.ClickThis();
	            repo.VAWindow.ContainerLeftPanel.ProductName.ClickThis();
	            repo.VAWindow.ContainerLeftPanel.SUMCustomerID.ClickThis();
	            repo.VAWindow.JPanel.Button13Info.WaitForItemExists(30000);
	            repo.VAWindow.JPanel.Button13.ClickThis();
				Reports.ReportLog("SelectHorizon", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectHorizon : " + ex.Message);
			}
    	}
		
		public static void ValidateHorizon()
		{
            try 
            {
            	CompressedImage LineDistribution = repo.VAWindow.PivotWindowInfo.GetHorizon();
                Imaging.FindOptions options = Imaging.FindOptions.Default;
                options.Similarity = 0.75f;
                RepoItemInfo info = repo.VAWindow.PivotWindowInfo;
                Validate.ContainsImage(info, LineDistribution, options, "After select Horizon chart data validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateHorizon : " + ex.Message);
			}
		}
		
		public static void SelectBullet()
		{
			try 
			{
				Keyboard.Press("{LControlKey down}");
				repo.VAWindow.ContainerLeftPanel.SUMOrderIDInfo.WaitForItemExists(30000);
	           	repo.VAWindow.ContainerLeftPanel.SUMOrderID.ClickThis();
	            repo.VAWindow.ContainerLeftPanel.SUMCustomerID.ClickThis();
	            repo.VAWindow.JPanel.Button18Info.WaitForItemExists(30000);
	            repo.VAWindow.JPanel.Button17.ClickThis();
				Reports.ReportLog("SelectBullet", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectBullet : " + ex.Message);
			}
    	}
		
		public static void ValidateBulletChart()
		{
            try 
            {
            	CompressedImage LineDistribution = repo.VAWindow.PivotWindowInfo.GetBulletMap();
                Imaging.FindOptions options = Imaging.FindOptions.Default;
                options.Similarity = 0.75f;
                RepoItemInfo info = repo.VAWindow.PivotWindowInfo;
                Validate.ContainsImage(info, LineDistribution, options, "After select bullet chart data validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateBulletChart : " + ex.Message);
			}
		}
		
		public static void DeselectVisualization()
		{
			try 
			{
				System.Threading.Thread.Sleep(5000);
				repo.VAWindow.Visualization1Info.WaitForItemExists(10000);
				repo.VAWindow.Visualization1.ClickThis();
				Reports.ReportLog("DeselectVisualization", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : DeselectVisualization : " + ex.Message);
			}
    	}
		
		
    }
	
}
