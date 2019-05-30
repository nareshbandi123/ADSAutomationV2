using System;
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

namespace ADSAutomationPhaseII.TC_10592
{ 
	public static class Steps
    {
   	    public static TC10592Repo repo = TC10592Repo.Instance;
        public static string TC_10592_PATH = System.Configuration.ConfigurationManager.AppSettings["TC_10592"].ToString();
        
        public static void ClickonFileMenu()
		{
			try 
			{
				repo.Application.FileMenuInfo.WaitForItemExists(3000);
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
				repo.DataStudio.OpenFileInfo.WaitForItemExists(10000);
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
				repo.OpenWindow.FilePathTextbox.TextBoxText(TC_10592_PATH + "Sample_Data_Source_Treemap_Chart.vizx");
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
				repo.OpenWindow.OpenButtonInfo.WaitForItemExists(10000);
				repo.OpenWindow.OpenButton.ClickThis();
				Reports.ReportLog("ClickonOpenButton", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonOpenButton : " + ex.Message);
			}
		}
		
		public static void MaximizeWindow()
		{
			try 
			{
				repo.VAWindow.SelfInfo.WaitForItemExists(10000);
				repo.VAWindow.Self.Maximize();
				Reports.ReportLog("MaximizeWindow", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonOpenButton : " + ex.Message);
			}
		}
		
		public static void ValidateTreeMapFile()
		{
    		try 
    		{
    			repo.VAWindow.Self.Maximize();
    			if(repo.VAWindow.VisulizationWindowInfo.Exists())
    			{
	    			CompressedImage TreeMap = repo.VAWindow.VisulizationWindowInfo.GetTreeMapData();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = 0.75f;
	    			RepoItemInfo info = repo.VAWindow.VisulizationWindowInfo;
	    			bool isvalid = Validate.ContainsImage(info, TreeMap, options, "Tree map image data validation", false);
	    			Reports.ReportLog("ValidateTreeMapFile", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateTreeMapFile : " + ex.Message);
			}
    	} 
		
		public static void ClickonWorkSheet()
		{
			try 
			{
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
				repo.SunAwtWindow.NewWorkSheetInfo.WaitForItemExists(10000);
				repo.SunAwtWindow.NewWorkSheet.ClickThis();
				Reports.ReportLog("SelectNewWorkSheet", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectNewWorkSheet : " + ex.Message);
			}
		}
		
		public static void DragCoffeetoColumn()
		{
			try 
			{
				repo.VAWindow.ContainerLeftPanel.CoffeeInfo.WaitForItemExists(10000);
				repo.VAWindow.ContainerLeftPanel.Coffee.ClickThis();
	            repo.VAWindow.ContainerLeftPanel.Coffee.Click(System.Windows.Forms.MouseButtons.Right, "47;9");
	            repo.SunAwtWindow.AddToColumnsDeck.Click("67;11");
	            Reports.ReportLog("DragCoffeetoColumn", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
	            
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : DragCoffeetoColumn : " + ex.Message);
			}
		}
		
		public static void ValidateAfterCoffeetoColumn()
		{
    		try 
    		{
    			repo.VAWindow.Self.Maximize();
    			if(repo.VAWindow.VisulizationWindowInfo.Exists())
    			{
	    			CompressedImage TreeMap = repo.VAWindow.VisulizationWindowInfo.GetDragCoffeetoColumn();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = 0.75f;
	    			RepoItemInfo info = repo.VAWindow.VisulizationWindowInfo;
	    			bool isvalid = Validate.ContainsImage(info, TreeMap, options, "After Drag Coffee to Column image comparision", false);
	    			Reports.ReportLog("ValidateAfterCoffeetoColumn", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterCoffeetoColumn : " + ex.Message);
			}
    	} 
	
		public static void DragGeographytoColumn()
		{
			try 
			{
				repo.VAWindow.ContainerLeftPanel.GeographyInfo.WaitForItemExists(10000);
				repo.VAWindow.ContainerLeftPanel.Geography.ClickThis();
	            repo.VAWindow.ContainerLeftPanel.Geography.Click(System.Windows.Forms.MouseButtons.Right, "58;11");
	            repo.SunAwtWindow.AddToColumnsDeck.Click("102;10");
	            Reports.ReportLog("DragGeographytoColumn", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : DragGeographytoColumn : " + ex.Message);
			}
		}
		
		public static void ValidateAfterGeographytoColumn()
		{
    		try 
    		{
    			if(repo.VAWindow.VisulizationWindowInfo.Exists())
    			{
	    			CompressedImage TreeMap = repo.VAWindow.VisulizationWindowInfo.GetDragGeographytoColumn();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = 0.75f;
	    			RepoItemInfo info = repo.VAWindow.VisulizationWindowInfo;
	    			bool isvalid = Validate.ContainsImage(info, TreeMap, options, "After Drag Geography to Column image comparision", false);
	    			Reports.ReportLog("ValidateAfterGeographytoColumn", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterGeographytoColumn : " + ex.Message);
			}
    	} 
		
		public static void DragprofittoRow()
		{
			try 
			{
				repo.VAWindow.ContainerLeftPanel.SUMProfitInfo.WaitForItemExists(10000);
				repo.VAWindow.ContainerLeftPanel.SUMProfit.Click("40;12");
	            repo.VAWindow.ContainerLeftPanel.SUMProfit.Click(System.Windows.Forms.MouseButtons.Right, "41;10");	            
	            repo.SunAwtWindow.AddToRowsDeck.Click("76;13");
	            Reports.ReportLog("DragprofittoRow", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
	            
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : DragprofittoRow : " + ex.Message);
			}
		}
		
		public static void ValidateAfterDragprofittoRow()
		{
    		try 
    		{
    			if(repo.VAWindow.VisulizationWindowInfo.Exists())
    			{
	    			CompressedImage TreeMap = repo.VAWindow.VisulizationWindowInfo.GetDragProfittoRow();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = 0.75f;
	    			RepoItemInfo info = repo.VAWindow.VisulizationWindowInfo;
	    			bool isvalid = Validate.ContainsImage(info, TreeMap, options, "After Drag Profit to Row image comparision", false);
	    			Reports.ReportLog("ValidateAfterDragprofittoRow", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterDragprofittoRow : " + ex.Message);
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
		
		public static void ValidateAfterClickonTreeMapIcon()
		{
    		try 
    		{
    			repo.VAWindow.Self.Maximize();
    			if(repo.VAWindow.VisulizationWindowInfo.Exists())
    			{
	    			CompressedImage TreeMap = repo.VAWindow.VisulizationWindowInfo.GetAfterClickonTreeMapIcon();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			RepoItemInfo info = repo.VAWindow.VisulizationWindowInfo;
	    			bool isvalid = Validate.ContainsImage(info, TreeMap, options, "After Click on TreeMap Icon image comparision", false);
	    			Reports.ReportLog("ValidateAfterClickonTreeMapIcon", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterClickonTreeMapIcon : " + ex.Message);
			}
    	} 
		
		public static void DeselectVisualization()
		{
			try 
			{
				repo.VAWindow.Visualization1Info.WaitForItemExists(10000);
				repo.VAWindow.Visualization1.ClickThis();
				Reports.ReportLog("DeselectVisualization", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : DeselectVisualization : " + ex.Message);
			}
		}
		
		public static void ClickonTreeMap()
		{
			try 
			{
				repo.VAWindow.TreeMapInfo.WaitForItemExists(10000);
				repo.VAWindow.TreeMap.ClickThis();
				Reports.ReportLog("ClickonTreeMap", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonTreeMap : " + ex.Message);
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
		
		public static void SelectShowMeasureValues()
		{
			try 
			{
				repo.Datastudio1.ShowMeasureValuesInfo.WaitForItemExists(10000);
				repo.Datastudio1.ShowMeasureValues.ClickThis();
				Reports.ReportLog("SelectShowMeasureValues", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectShowMeasureValues : " + ex.Message);
			}
		}
		
		public static void ValidateAfterClickonMeasuredValues()
		{
    		try 
    		{
    			if(repo.VAWindow.VisulizationWindowInfo.Exists())
    			{
	    			CompressedImage TreeMap = repo.VAWindow.VisulizationWindowInfo.GetMeasuredValues();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = 0.75f;
	    			RepoItemInfo info = repo.VAWindow.VisulizationWindowInfo;
	    			bool isvalid = Validate.ContainsImage(info, TreeMap, options, "After click on show measured values image comparision", false);
	    			Reports.ReportLog("ValidateAfterClickonMeasuredValues", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterClickonMeasuredValues : " + ex.Message);
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
		
		public static void SelectAbsoluteValues()
		{
			try 
			{
				repo.Datastudio1.AbsoluteValuesInfo.WaitForItemExists(10000);
				repo.Datastudio1.AbsoluteValues.Click();
				Reports.ReportLog("SelectAbsoluteValues", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectAbsoluteValues : " + ex.Message);
			}
		}
		
		public static void ValidateAfterClickonAbsoluteValues()
		{
    		try 
    		{
    			if(repo.VAWindow.VisulizationWindowInfo.Exists())
    			{
	    			CompressedImage TreeMap = repo.VAWindow.VisulizationWindowInfo.GetAbsoluteValues();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = 0.75f;
	    			RepoItemInfo info = repo.VAWindow.VisulizationWindowInfo;
	    			bool isvalid = Validate.ContainsImage(info, TreeMap, options, "After click on absolute values image comparision", false);
	    			Reports.ReportLog("ValidateAfterClickonAbsoluteValues", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterClickonAbsoluteValues : " + ex.Message);
			}
    	} 
		
		public static void CloseVAWindow()
		{
			try 
			{
				repo.VAWindow.CloseInfo.WaitForItemExists(10000);
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
				repo.SaveChanges.DiscardInfo.WaitForItemExists(5000);
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
