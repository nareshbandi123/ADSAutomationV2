using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using Ranorex;
using Ranorex.Core.Repository;
using WinForms = System.Windows.Forms;

using Ranorex.Core;
using Ranorex.Core.Testing;
using ADSAutomationPhaseII.Base;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Preconditions;
using ADSAutomationPhaseII.Configuration;
using ADSAutomationPhaseII.TC_10589;

namespace ADSAutomationPhaseII.TC_10595
{
	public class Steps
	{
		public static TC10589 TC10589Repo = TC10589.Instance;
		public static TC10595 repo = TC10595.Instance;
		public static string TC_10595_PATH = System.Configuration.ConfigurationManager.AppSettings["TC_10595_Path"].ToString();
		
		public static void EnterFilePath()
		{
			try 
			{
				TC10589Repo.Open.OpenTextInfo.WaitForItemExists(20000);
				TC10589Repo.Open.OpenText.TextBoxText(TC_10595_PATH + "Sample_Data_Source_Horizon_Chart.vizx");
				Reports.ReportLog("EnterFilePath", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : EnterFilePath" + ex.Message);
			}			
		}
		
		public static void DragStockDateToColumn()
		{
			try 
			{
				repo.VisualAnalytics.ContainerContentPanel.StockDateInfo.WaitForItemExists(30000);
				repo.VisualAnalytics.ContainerContentPanel.StockDate.RightClickThis();
				repo.SunAwtWindow.AddToColumnsDeckInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.AddToColumnsDeck.ClickThis();
	           
				Reports.ReportLog("DragStockDateToColumn", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragStockDateToColumn" + ex.Message);
			}			
		}
		
		public static void DragStockSymbolToColumn()
		{
			try 
			{
				repo.VisualAnalytics.ContainerContentPanel.StockSymbolInfo.WaitForItemExists(30000);
				repo.VisualAnalytics.ContainerContentPanel.StockSymbol.RightClickThis();
				repo.SunAwtWindow.AddToColumnsDeckInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.AddToColumnsDeck.ClickThis();
	            
				Reports.ReportLog("DragStockSymbolToColumn", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragStockSymbolToColumn" + ex.Message);
			}			
		}
		
		public static void SelectWeekNumber()
		{
			try 
			{
				repo.VisualAnalytics.ContainerContentPanel.QUARTERStockDateInfo.WaitForItemExists(20000);
				repo.VisualAnalytics.ContainerContentPanel.QUARTERStockDate.RightClick();
				
				repo.SunAwtWindow.WeekNumberWeek12013Info.WaitForItemExists(20000);
	            repo.SunAwtWindow.WeekNumberWeek12013.ClickThis();
	            
				Reports.ReportLog("SelectWeekNumber", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectWeekNumber" + ex.Message);
			}			
		}
		
		public static void DragStockCloseToRows()
		{
			try 
			{
				repo.VisualAnalytics.ContainerContentPanel.SUMStockCloseInfo.WaitForItemExists(30000);
				repo.VisualAnalytics.ContainerContentPanel.SUMStockClose.RightClickThis();
	            repo.SunAwtWindow.AddToRowsDeckInfo.WaitForItemExists(30000);
	            repo.SunAwtWindow.AddToRowsDeck.ClickThis();
	            
				Reports.ReportLog("DragStockCloseToRows", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragStockCloseToRows" + ex.Message);
			}			
		}
		
		public static void SelectHorizonMap()
		{
			try 
			{
				TC10589Repo.VisualAnalytics.VisualizationInfo.WaitForItemExists(20000);
				TC10589Repo.VisualAnalytics.Visualization.ClickThis();
				
				repo.VisualAnalytics.HorizonMapInfo.WaitForItemExists(200000);
				repo.VisualAnalytics.HorizonMap.ClickThis();
				
				TC10589Repo.VisualAnalytics.Visualization1Info.WaitForItemExists(20000);
	            TC10589Repo.VisualAnalytics.Visualization1.ClickThis();
	            
				Reports.ReportLog("SelectHorizonMap", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectHorizonMap" + ex.Message);
			}			
		}
		
		public static void ValidateFullChart()
		{
			try 
			{
				if(repo.VisualAnalytics.FullChartInfo.Exists())
    			{
	    			CompressedImage tableChart = repo.VisualAnalytics.FullChartInfo.GetFullChart();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = Configuration.Config.SIMILARITY;
	    			RepoItemInfo info = repo.VisualAnalytics.FullChartInfo;
	    			System.Threading.Thread.Sleep(5000);
	    			Validate.ContainsImage(info, tableChart, options, "ValidateFullChart data image comparision", false);
    			}
				else
				{
					Reports.ReportLog("Validation : ValidateFullChart : ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			} 
			catch (Exception ex) 
			{
				
				throw new Exception("ValidateFullChart :" +ex.Message);
			}			
		}
		
		public static void ValidateBand2Chart()
		{
			try 
			{
				if(repo.VisualAnalytics.Band2Info.Exists())
    			{
	    			CompressedImage tableChart = repo.VisualAnalytics.Band2Info.GetBand2();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = Configuration.Config.SIMILARITY;
	    			RepoItemInfo info = repo.VisualAnalytics.Band2Info;
	    			System.Threading.Thread.Sleep(5000);
	    			Validate.ContainsImage(info, tableChart, options, "ValidateBand2Chart data image comparision", false);
    			}
				
				else
				{
					Reports.ReportLog("Validation : ValidateBand2Chart : ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
				
			} 
			catch (Exception ex) 
			{
				
				throw new Exception("ValidateBand2Chart :" +ex.Message);
			}			
		}
		
		public static void ValidateBand3Chart()
		{
			try 
			{
				if(repo.VisualAnalytics.Band3Info.Exists())
    			{
	    			CompressedImage tableChart = repo.VisualAnalytics.Band3Info.GetBand3();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = Configuration.Config.SIMILARITY;
	    			RepoItemInfo info = repo.VisualAnalytics.Band3Info;
	    			System.Threading.Thread.Sleep(5000);
	    			Validate.ContainsImage(info, tableChart, options, "ValidateBand2Chart data image comparision", false);
    			}
				else
				{
					Reports.ReportLog("Validation : ValidateBand3Chart : ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
				
			} 
			catch (Exception ex) 
			{
				
				throw new Exception("ValidateBand2Chart :" +ex.Message);
			}			
		}
		
		public static void SelectBand2()
		{
			try 
			{
				repo.VisualAnalytics.ContainerContentPanel.OptionsInfo.WaitForItemExists(30000);
				repo.VisualAnalytics.ContainerContentPanel.Options.ClickThis();
	            
				repo.Datastudio.RadioButton2BandsInfo.WaitForItemExists(30000);
	            repo.Datastudio.RadioButton2Bands.ClickThis();
	            
				Reports.ReportLog("SelectBand2", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectBand2" + ex.Message);
			}			
		}
		
		public static void SelectBand3()
		{
			try 
			{
				repo.VisualAnalytics.ContainerContentPanel.OptionsInfo.WaitForItemExists(20000);
				repo.VisualAnalytics.ContainerContentPanel.Options.ClickThis();
				
				repo.Datastudio.RadioButton3BandsInfo.WaitForItemExists(200000);
				repo.Datastudio.RadioButton3Bands.ClickThis();
					
				Reports.ReportLog("SelectBand3", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectBand3" + ex.Message);
			}			
		}
		
		public static void EditColors()
		{
			try 
			{
				repo.VisualAnalytics.ContainerContentPanel.ColorInfo.WaitForItemExists(200000);
				repo.VisualAnalytics.ContainerContentPanel.Color.ClickThis();
	            
				repo.EditColor.WindowsComboBoxUIDollarXPComboBoxButtonInfo.WaitForItemExists(200000);
				repo.EditColor.WindowsComboBoxUIDollarXPComboBoxButton.ClickThis();
	            
				repo.SunAwtWindow.RedGreenDivergingInfo.WaitForItemExists(200000);
				repo.SunAwtWindow.RedGreenDiverging.ClickThis();
	            
				repo.EditColor.ButtonOKInfo.WaitForItemExists(200000);
				repo.EditColor.ButtonOK.ClickThis();
					
				Reports.ReportLog("EditColors", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : EditColors" + ex.Message);
			}			
		}
		
		public static void CloseOnVisualAnanlyticsError()
		{
			if(repo.VisualAnalytics.SelfInfo.Exists(5000))
				repo.VisualAnalytics.Self.Close();
		}
		
		public static void CloseOnOpenFileError()
		{
			if(TC10589Repo.Open.SelfInfo.Exists(5000))
				TC10589Repo.Open.Self.Close();
		}
	}
}
		
		
		
