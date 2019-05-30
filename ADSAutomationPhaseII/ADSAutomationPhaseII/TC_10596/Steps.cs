﻿using System;
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

namespace ADSAutomationPhaseII.TC_10596
{
	public class Steps
	{
		
		public static TC10596 repo = TC10596.Instance;
		public static TC10589 TC10589Repo = TC10589.Instance;
		public static string TC_10596_PATH = System.Configuration.ConfigurationManager.AppSettings["TC_10596_Path"].ToString();
		
		public static void EnterFilePath()
		{
			try 
			{
				TC10589Repo.Open.OpenTextInfo.WaitForItemExists(20000);
				TC10589Repo.Open.OpenText.TextBoxText(TC_10596_PATH + "Sample_Data_Source_Mekko_Chart.vizx");
				Reports.ReportLog("EnterFilePath", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : EnterFilePath" + ex.Message);
			}			
		}
		
		public static void DragCoffeeAndGeographyToColumns()
		{
			try 
			{
				repo.VisualAnalytics.ContainerLeftPanel.CoffeeInfo.WaitForItemExists(30000);
	            repo.VisualAnalytics.ContainerLeftPanel.Coffee.MoveTo("53;7");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	            repo.VisualAnalytics.ContainerLeftPanel.Coffee.MoveTo("61;-1");
	            Delay.Milliseconds(200);
	            
	            repo.VisualAnalytics.ColumnsPanel.MoveTo("66;9");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);

	            repo.VisualAnalytics.ContainerLeftPanel.GeographyInfo.WaitForItemExists(30000);
	            repo.VisualAnalytics.ContainerLeftPanel.Geography.MoveTo("79;10");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	            repo.VisualAnalytics.ContainerLeftPanel.Geography.MoveTo("87;2");
	            Delay.Milliseconds(200);
	            
	            repo.VisualAnalytics.ColumnsPanel.MoveTo("248;6");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);	            
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragCoffeeAndGeographyToColumns" + ex.Message);
			}			
		}
		
		public static void DragProfitToRows()
		{
			try 
			{
				repo.VisualAnalytics.ProfitInfo.WaitForItemExists(30000);
				repo.VisualAnalytics.Profit.RightClickThis();
				repo.Forms.AddToRowInfo.WaitForItemExists(30000);
				repo.Forms.AddToRow.ClickThis();
				
            	Reports.ReportLog("DragProfitToRows", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragProfitToRows" + ex.Message);
			}			
		}
		
		public static void SelectMekkoMapVisualization()
		{
			try 
			{
				TC10589Repo.VisualAnalytics.VisualizationInfo.WaitForItemExists(20000);
				TC10589Repo.VisualAnalytics.Visualization.ClickThis();
				
				repo.VisualAnalytics.MekkoMapInfo.WaitForItemExists(200000);
				repo.VisualAnalytics.MekkoMap.ClickThis();
				
				TC10589Repo.VisualAnalytics.Visualization1Info.WaitForItemExists(20000);
	            TC10589Repo.VisualAnalytics.Visualization1.ClickThis();
	            
				Reports.ReportLog("SelectMekkoMapVisualization", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectMekkoMapVisualization" +ex.Message);
			}			
		}
		
		public static void ValidateMekkoChart()
		{
			try 
			{
				if(repo.VisualAnalytics.MekkoMapChartInfo.Exists())
    			{
	    			CompressedImage tableChart = repo.VisualAnalytics.MekkoMapChartInfo.GetMekkoMapChart();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = Configuration.Config.SIMILARITY;
	    			RepoItemInfo info = repo.VisualAnalytics.MekkoMapChartInfo;
	    			System.Threading.Thread.Sleep(5000);
	    			Validate.ContainsImage(info, tableChart, options, "ValidateMekkoChart data image comparision", false);
    			}
				else
				{
					Reports.ReportLog("ValidateMekkoChart", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				
			} 
			catch (Exception ex) 
			{
				
				throw new Exception("ValidateMekkoChart :" +ex.Message);
			}			
		}
		
		public static void SelectShowColumnTotal()
		{
			try 
			{
				repo.VisualAnalytics.LabelInfo.WaitForItemExists(20000);
				repo.VisualAnalytics.Label.ClickThis();
	            
				repo.Datastudio.ShowColumnTotalInfo.WaitForItemExists(20000);
	            repo.Datastudio.ShowColumnTotal.ClickThis();
	            
				Reports.ReportLog("SelectShowColumnTotal", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectShowColumnTotal" +ex.Message);
			}			
		}
		
		public static void ValidateMekkoShowColumn()
		{
			try 
			{
				if(repo.VisualAnalytics.MekkoMapColumnInfo.Exists())
    			{
	    			CompressedImage tableChart = repo.VisualAnalytics.MekkoMapColumnInfo.GetMekkoMapShowColumn();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = Configuration.Config.SIMILARITY;
	    			RepoItemInfo info = repo.VisualAnalytics.MekkoMapColumnInfo;
	    			System.Threading.Thread.Sleep(5000);
	    			Validate.ContainsImage(info, tableChart, options, "ValidateMekkoShowColumn data image comparision", false);
    			}
				else
				{
					Reports.ReportLog("ValidateMekkoShowColumn", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
			} 
			catch (Exception ex) 
			{
				
				throw new Exception("ValidateMekkoShowColumn :" +ex.Message);
			}			
		}
		
		public static void SelectShowColumnPercent()
		{
			try 
			{
				repo.VisualAnalytics.LabelInfo.WaitForItemExists(20000);
				repo.VisualAnalytics.Label.ClickThis();
	            
				repo.Datastudio.ShowColumnPercentageInfo.WaitForItemExists(20000);
				repo.Datastudio.ShowColumnPercentage.ClickThis();
	            
				Reports.ReportLog("SelectShowColumnPercent", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectShowColumnPercent" +ex.Message);
			}			
		}
		
		public static void ValidateMekkoShowPercent()
		{
			try 
			{
				if(repo.VisualAnalytics.MekkoMapPercentageInfo.Exists())
    			{
	    			CompressedImage tableChart = repo.VisualAnalytics.MekkoMapPercentageInfo.GetMekkoMapPercent();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = Configuration.Config.SIMILARITY;
	    			RepoItemInfo info = repo.VisualAnalytics.MekkoMapPercentageInfo;
	    			System.Threading.Thread.Sleep(5000);
	    			Validate.ContainsImage(info, tableChart, options, "ValidateMekkoShowPercent data image comparision", false);
    			}
				else
				{
					Reports.ReportLog("ValidateMekkoShowPercent", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
			}
				
			catch (Exception ex) 
			{
				
				throw new Exception("ValidateMekkoShowPercent :" +ex.Message);
			}
		}
		
		
		public static void SelectMeasurePercent()
		{
			try 
			{
				repo.VisualAnalytics.LabelInfo.WaitForItemExists(20000);
				repo.VisualAnalytics.Label.ClickThis();
	            
				repo.Datastudio.ShowMeasurePercentageInfo.WaitForItemExists(20000);
				repo.Datastudio.ShowMeasurePercentage.ClickThis();
				
				Reports.ReportLog("SelectMeasurePercent", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectMeasurePercent" +ex.Message);
			}			
		}
		
		public static void ValidateMeasurePercent()
		{
			try 
			{
				if(repo.VisualAnalytics.MekkoMeasurePercentageInfo.Exists())
    			{
	    			CompressedImage tableChart = repo.VisualAnalytics.MekkoMeasurePercentageInfo.GetMekkoMeasurePercent();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = Configuration.Config.SIMILARITY;
	    			RepoItemInfo info = repo.VisualAnalytics.MekkoMeasurePercentageInfo;
	    			System.Threading.Thread.Sleep(5000);
	    			Validate.ContainsImage(info, tableChart, options, "ValidateMeasurePercent data image comparision", false);
    			}
				else
				{
					Reports.ReportLog("ValidateMeasurePercent", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
			} 
			catch (Exception ex) 
			{
				
				throw new Exception("ValidateMeasurePercent :" +ex.Message);
			}			
		}
		
		public static void SelectAbsoluteValues()
		{
			try 
			{
				repo.VisualAnalytics.OptionsInfo.WaitForItemExists(20000);
				repo.VisualAnalytics.Options.ClickThis();
	            
				repo.Datastudio.UseAbsoluteValuesInfo.WaitForItemExists(20000);
	            repo.Datastudio.UseAbsoluteValues.ClickThis();
				
				Reports.ReportLog("SelectAbsoluteValues", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectAbsoluteValues" +ex.Message);
			}			
		}
		
		public static void ValidateAbsoluteValueChart()
		{
			try 
			{
				if(Validate.ContainsImage(repo.VisualAnalytics.AbsoluteValuesChartInfo, repo.VisualAnalytics.AbsoluteValuesChartInfo.GetAbsoluteValues(), Imaging.FindOptions.Default, "Validate Mekko absolute values", false))
				{
					Reports.ReportLog("Validation : ValidateAbsoluteValueChart", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
			} 
			catch (Exception ex) 
			{
				
				throw new Exception("ValidateAbsoluteValueChart :" +ex.Message);
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