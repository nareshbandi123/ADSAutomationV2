using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

using WinForms = System.Windows.Forms;
using System.Windows.Forms;
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Preconditions;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Repository;
using Ranorex.Core.Testing;

namespace ADSAutomationPhaseII.TC_10591
{
    public static class Steps
    {
   	    public static TC10591Repo repo = TC10591Repo.Instance;
        public static string TC_10591_PATH = System.Configuration.ConfigurationManager.AppSettings["TC_10591"].ToString(); 
        
        #region "TC1"
        
		public static void SelectNewFile()
		{
			try 
			{
				repo.OpenWindow.FilePathTextbox.TextBoxText(TC_10591_PATH + "Sample_Data_Source_Maps.vizx");
				Reports.ReportLog("SelectNewFile", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectNewFile : " + ex.Message);
			}
		}
		
		public static void DragStatetoColumn()
		{
			try 
			{
				repo.VAWindow.ContainerLeftPanel.StateInfo.WaitForItemExists(5000);
				repo.VAWindow.ContainerLeftPanel.State.ClickThis();
	            repo.VAWindow.ContainerLeftPanel.State.Click(System.Windows.Forms.MouseButtons.Right, "42;6");	            
	            repo.SunAwtWindow.AddToColumnsDeck.Click("68;6");
	            Reports.ReportLog("DragStatetoColumn", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragStatetoColumn : " + ex.Message);
			}
		}
		
		public static void DragProductCategorytoColumn()
		{
			try 
			{
				repo.VAWindow.ContainerLeftPanel.ProductCategory.Click("71;7");
	            repo.VAWindow.ContainerLeftPanel.ProductCategory.Click(System.Windows.Forms.MouseButtons.Right, "71;7");
	            repo.SunAwtWindow.AddToColumnsDeck.Click("63;13");
	            Reports.ReportLog("DragProductCategorytoColumn", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragProductCategorytoColumn : " + ex.Message);
			}
		}
		
		public static void DragProfittoRow()
		{
			try 
			{
				repo.VAWindow.ContainerLeftPanel.SUMProfit.Click("51;5");
	            repo.VAWindow.ContainerLeftPanel.SUMProfit.Click(System.Windows.Forms.MouseButtons.Right, "51;5");
	            repo.SunAwtWindow.AddToRowsDeck.Click("58;12");
	            Reports.ReportLog("DragProfittoRow", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);	
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragProfittoRow : " + ex.Message);
			}
		}
		
		public static void ClickonAutomatic()
		{
			try 
			{
				repo.VAWindow.AutomaticInfo.WaitForItemExists(30000);
				repo.VAWindow.Automatic.Click();
				Reports.ReportLog("ClickonAutomatic", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonAutomatic : " + ex.Message);
			}
		}
		
		public static void ChangeChartTypetoPie()
		{
			try 
			{
				repo.SunAwtWindow.PieChartInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.PieChart.ClickThis();
				Reports.ReportLog("ChangeChartTypetoPie", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ChangeChartTypetoPie : " + ex.Message);
			}
		}
		
		public static void ValidateAfterChangedtoPieChart()
		{
    		try 
    		{
    			if(repo.VAWindow.VisualizationWindowInfo.Exists())
    			{
	    			CompressedImage SymboMapShape = repo.VAWindow.VisualizationWindow11Info.GetPieChart();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = 0.75f;
	    			RepoItemInfo info = repo.VAWindow.VisualizationWindow11Info;
	    			Validate.ContainsImage(info, SymboMapShape, options, "After Changed to Pie Chart image data validation", false);
	    		}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterChangedtoPieChart : " + ex.Message);
			}
    	}
		
		public static void DragPCtoColorDeck()
		{
			try 
			{
				repo.VAWindow.ContainerMainPanel.ProductCategory.Click("35;7");
	           
	            repo.VAWindow.ContainerMainPanel.ProductCategory.MoveTo("44;7");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            
	            repo.VAWindow.ContainerMainPanel.ProductCategory.MoveTo("52;-1");
	           
	            repo.VAWindow.ContainerMainPanel.Color.MoveTo("30;26");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            Reports.ReportLog("DragPCtoColorDeck", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragPCtoColorDeck : " + ex.Message);
			}
		}
		
		public static void ValidateAfterChangedPCtoColorDeck()
		{
    		try 
    		{
    			if(repo.VAWindow.VisualizationWindowInfo.Exists())
    			{
	    			CompressedImage SymboMapShape = repo.VAWindow.VisualizationWindowInfo.GetPCtoColorDeck();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = 0.75f;
	    			RepoItemInfo info = repo.VAWindow.VisualizationWindowInfo;
	    			Validate.ContainsImage(info, SymboMapShape, options, "After Changed Product category to ColorDeck image data validation", false);    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterChangedtoPieChart : " + ex.Message);
			}
    	}
		
		public static void ClickonAnyPCIteminChart()
		{
			try 
			{
				repo.VAWindow.ContainerMainPanel.ContainerCanvasInfo.WaitForItemExists(1000);
				repo.VAWindow.ContainerMainPanel.ContainerCanvas.Click("510;296");
				System.Threading.Thread.Sleep(3000);
				Reports.ReportLog("ClickonAnyPCIteminChart", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonAnyPCIteminChart : " + ex.Message);
			}
		}
		
		#endregion
		
		#region "TC2"
		
	
		public static void DragLongitudetoColumn()
		{
			try 
			{
				repo.VAWindow.ContainerLeftPanel.LongitudeInfo.WaitForItemExists(10000);
				repo.VAWindow.ContainerLeftPanel.Longitude.Click("50;6");
	            repo.VAWindow.ContainerLeftPanel.Longitude.Click(System.Windows.Forms.MouseButtons.Right, "51;6");
	            repo.SunAwtWindow.AddToColumnsDeck.Click("65;7");
	            Reports.ReportLog("DragLongitudetoColumn", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);	
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragLongitudetoColumn : " + ex.Message);
			}
		}
		
		public static void ValidateAfterDrgDimenstionstoColumn()
		{
    		try 
    		{
    			if(repo.VAWindow.VisualizationWindowInfo.Exists())
    			{
	    			CompressedImage SymboMapShape = repo.VAWindow.VisualizationWindowInfo.GetDragLongandLattoColumn();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = 0.75f;
	    			RepoItemInfo info = repo.VAWindow.VisualizationWindowInfo;
	    			Validate.ContainsImage(info, SymboMapShape, options, "After Drg Dimenstions to Column image data validation", false);	
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterDrgaDimenstionstoColumn : " + ex.Message);
			}
    	}
		
		public static void DragLatitudetoColumn()
		{
			try 
			{
				repo.VAWindow.ContainerLeftPanel.LatitudeInfo.WaitForItemExists(5000);
				repo.VAWindow.ContainerLeftPanel.Latitude.Click("51;7");
	            repo.VAWindow.ContainerLeftPanel.Latitude.Click(System.Windows.Forms.MouseButtons.Right, "51;7");
	            repo.SunAwtWindow.AddToColumnsDeck.Click("74;11");
	            Reports.ReportLog("DragLatitudetoColumn", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragLatitudetoColumn : " + ex.Message);
			}
		}
		
		public static void DragProfittoRow1()
		{
			try 
			{
				repo.VAWindow.ContainerLeftPanel.SUMProfitInfo.WaitForItemExists(5000);
				repo.VAWindow.ContainerLeftPanel.SUMProfit.Click("51;5");
	            repo.VAWindow.ContainerLeftPanel.SUMProfit.Click(System.Windows.Forms.MouseButtons.Right, "51;5");
	            repo.SunAwtWindow.AddToRowsDeck.Click("58;12");
	            Reports.ReportLog("DragProfittoRow1", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragProfittoRow1 : " + ex.Message);
			}
		}
		
		public static void ValidateAfterDrgaProfittoRow1()
		{
    		try 
    		{
    			if(repo.VAWindow.VisualizationWindowInfo.Exists())
    			{
	    			CompressedImage SymboMapShape = repo.VAWindow.VisualizationWindowInfo.GetProfitoRow1();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = 0.75f;
	    			RepoItemInfo info = repo.VAWindow.VisualizationWindowInfo;
	    			Validate.ContainsImage(info, SymboMapShape, options, "After dragprofi to row image data validation", false);	
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterChangedtoPieChart : " + ex.Message);
			}
    	}
		
		public static void ValidateAfterChangetopieChart()
		{
    		try 
    		{
    			if(repo.VAWindow.VisualizationWindowInfo.Exists())
    			{
	    			CompressedImage SymboMapShape = repo.VAWindow.VisualizationWindowInfo.GetChangetoPieChart1();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = 0.75f;
	    			RepoItemInfo info = repo.VAWindow.VisualizationWindowInfo;
	    			Validate.ContainsImage(info, SymboMapShape, options, "After Changed to Pie Chart image data validation", false);	
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterChangedtoPieChart : " + ex.Message);
			}
    	}
		#endregion
    }
    
}
