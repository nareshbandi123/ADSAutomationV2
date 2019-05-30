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

namespace ADSAutomationPhaseII.TC_10600
{
	public static class Steps
	{
		public static TC10600Repo repo = TC10600Repo.Instance;
		public static string TC_10600_PATH = System.Configuration.ConfigurationManager.AppSettings["TC_10600"].ToString();
		
		#region "TC1"
		
		public static void SelectEntireWindow()
		{
			try
			{
				repo.VATestWindow.ComboBoxInfo.WaitForItemExists(30000);
				repo.VATestWindow.ComboBox.Click();
				repo.SunAwtWindow.EntireViewInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.EntireView.ClickThis();
				Reports.ReportLog("SelectEntireWindow", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectEntireWindow : " + ex.Message);
			}
		}
		
		public static void DragPCtoColumn()
		{
			try
			{
				repo.VATestWindow.ProductCategoryInfo.WaitForItemExists(5000);
				repo.VATestWindow.ProductCategory.ClickThis();
				repo.VATestWindow.ProductCategory.Click(System.Windows.Forms.MouseButtons.Right, "79;6");
				repo.SunAwtWindow.AddToColumnsDeck.Click("91;12");
				Reports.ReportLog("DragPCtoColumn", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragPCtoColumn : " + ex.Message);
			}
		}
		
		public static void ValidateAfterDragPCtoColumn()
		{
			try
			{
				CompressedImage VAFiltering = repo.VATestWindow.PivotWindowInfo.GetPCtoColumn();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VATestWindow.PivotWindowInfo;
				Validate.ContainsImage(info, VAFiltering, options, "After drag PC to Column graph validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterDragPCtoColumn : " + ex.Message);
			}
		}
		
		public static void DragPCtoRow()
		{
			try
			{
				repo.VATestWindow.ProductCategoryInfo.WaitForItemExists(5000);
				repo.VATestWindow.ProductCategory.ClickThis();
				repo.VATestWindow.ProductCategory.Click(System.Windows.Forms.MouseButtons.Right, "79;4");
				repo.SunAwtWindow.AddToRowsDeck.Click("69;13");
				Reports.ReportLog("DragPCtoRow", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragPCtoRow : " + ex.Message);
			}
		}
		
		public static void ValidateAfterDragPCtoRow()
		{
			try
			{
				CompressedImage VAFiltering = repo.VATestWindow.PivotWindowInfo.GetPCtoRow();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VATestWindow.PivotWindowInfo;
				Validate.ContainsImage(info, VAFiltering, options, "After drag PC to Row graph validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterDragPCtoRow : " + ex.Message);
			}
		}
		
		public static void DragCurrencycodetoFilters()
		{
			try
			{
				System.Threading.Thread.Sleep(2000);
				repo.VATestWindow.Self.Activate();
				repo.VATestWindow.BIDraggableList.CurrencyCode.DragThisTo(repo.VATestWindow.ContainerContentPanel.JDropHint);
				
//				repo.VATestWindow.BIDraggableList.CurrencyCodeInfo.WaitForItemExists(10000);
//				repo.VATestWindow.BIDraggableList.CurrencyCode.ClickThis();
//				
//				repo.VATestWindow.BIDraggableList.CurrencyCode.MoveTo("68;9");
//				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
//				
//				repo.VATestWindow.BIDraggableList.CurrencyCode.MoveTo("76;1");
//				
//				repo.VATestWindow.ContainerContentPanel.JDropHint.MoveTo("70;5");
//				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				Reports.ReportLog("DragCurrencycodetoFilters", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragCurrencycodetoFilters : " + ex.Message);
			}
		}
		
		public static void ValidateAfterDragCurrencycodetoFilterDeck()
		{
			try
			{
				CompressedImage VAFiltering = repo.VATestWindow.PivotWindowInfo.GetCurrencyCodetoFilter();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VATestWindow.PivotWindowInfo;
				Validate.ContainsImage(info, VAFiltering, options, "After Drag Currency code to Filter Deck graph validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterDragCurrencycodetoFilterDeck : " + ex.Message);
			}
		}
		
		public static void ClickonUncheckAll()
		{
			try
			{
				repo.VATestWindow.ContainerMainPanel.ListItemAllInfo.WaitForItemExists(10000);
				repo.VATestWindow.ContainerMainPanel.ListItemAll.Click("10;9");
				Reports.ReportLog("ClickonUncheckAll", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonUncheckAll : " + ex.Message);
			}
		}
		
		public static void ValidateAfterUncheckAll()
		{
			try
			{
				CompressedImage VAFiltering = repo.VATestWindow.PivotWindowInfo.GetDisappearGraph();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VATestWindow.PivotWindowInfo;
				Validate.ContainsImage(info, VAFiltering, options, "After UncheckAll graph validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterUncheckAll : " + ex.Message);
			}
		}
		
		public static void GBPOption()
		{
			try
			{
				repo.VATestWindow.ContainerMainPanel.ListItemGBPInfo.WaitForItemExists(5000);
				repo.VATestWindow.ContainerMainPanel.ListItemGBP.Click("10;10");
				Reports.ReportLog("GBPOption", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : GBPOption : " + ex.Message);
			}
		}
		
		public static void ValidateAfterClickGBPCurrency()
		{
			try
			{
				CompressedImage VAFiltering = repo.VATestWindow.PivotWindowInfo.GetGBPCurrency();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VATestWindow.PivotWindowInfo;
				Validate.ContainsImage(info, VAFiltering, options, "After Click GBP Currency graph validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterClickGBPCurrency : " + ex.Message);
			}
		}
		
		public static void SelectAvailableCurrencyCodes()
		{
			try
			{
				repo.VATestWindow.ContainerMainPanel.ListItemAUDInfo.WaitForItemExists(5000);
				repo.VATestWindow.ContainerMainPanel.ListItemAUD.Click("10;11");
				repo.VATestWindow.ContainerMainPanel.ListItemCADInfo.WaitForItemExists(5000);
				repo.VATestWindow.ContainerMainPanel.ListItemCAD.Click("10;7");
				repo.VATestWindow.ContainerMainPanel.ListItemDEMInfo.WaitForItemExists(5000);
				repo.VATestWindow.ContainerMainPanel.ListItemDEM.Click("12;9");
				repo.VATestWindow.ContainerMainPanel.ListItemFRFInfo.WaitForItemExists(5000);
				repo.VATestWindow.ContainerMainPanel.ListItemFRF.Click("8;6");
				Reports.ReportLog("SelectAvailableCurrencyCodes", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectAvailableCurrencyCodes : " + ex.Message);
			}
		}
		
		public static void ClickonTrinagleIcon()
		{
			try
			{
				repo.VATestWindow.TriangleIconCDInfo.WaitForItemExists(5000);
				repo.VATestWindow.TriangleIconCD.ClickThis();
				Reports.ReportLog("ClickonTrinagleIcon", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonTrinagleIcon : " + ex.Message);
			}
		}
		
		public static void ClickonTopNWindow()
		{
			try
			{
				repo.SunAwtWindow.TopNInfo.WaitForItemExists(10000);
				repo.SunAwtWindow.TopN.ClickThis();
				Reports.ReportLog("ClickonTopNWindow", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonTopNWindow : " + ex.Message);
			}
		}
		
		public static void ClickonFieldOption()
		{
			try
			{
				repo.TopNCurrencyCode.CPanel.ByFieldInfo.WaitForItemExists(10000);
				repo.TopNCurrencyCode.CPanel.ByField.Click();
				Reports.ReportLog("ClickonFieldOption", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonFieldOption : " + ex.Message);
			}
		}
		
		public static void SelectTopandBottom()
		{
			try
			{
				repo.TopNCurrencyCode.CPanel.FiledDropDownInfo.WaitForItemExists(10000);
				repo.TopNCurrencyCode.CPanel.FiledDropDown.ClickThis();
				repo.SunAwtWindow.TopAndBottom.ClickThis();
				Reports.ReportLog("SelectTopandBottom", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectTopandBottom : " + ex.Message);
			}
		}
		
		public static void SelectEnterValues()
		{
			try
			{
				repo.TopNCurrencyCode.CPanel.ValuesDropDownInfo.WaitForItemExists(5000);
				repo.TopNCurrencyCode.CPanel.ValuesDropDown.ClickThis();
				repo.SunAwtWindow.EnterAValue.ClickThis();
				Reports.ReportLog("SelectEnterValues", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectEnterValues : " + ex.Message);
			}
		}
		
		public static void ClickonOkButton()
		{
			try
			{
				repo.TopNCurrencyCode.OkayInfo.WaitForItemExists(5000);
				repo.TopNCurrencyCode.Okay.ClickThis();
				Reports.ReportLog("ClickonOkButton", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonOkButton : " + ex.Message);
			}
		}
		
		public static void ValidateTOPNWindowOptions()
		{
			try
			{
				CompressedImage VAFiltering = repo.VATestWindow.PivotWindowInfo.GetTopNChanges();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VATestWindow.PivotWindowInfo;
				Validate.ContainsImage(info, VAFiltering, options, "After change TOPN values graph validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateTOPNWindowOptions : " + ex.Message);
			}
		}
		
		#endregion
		
		#region "TC2"
		
		public static void DragProfitToFilterDeck()
		{
			try
			{
				
				repo.VATestWindow.ContainerMainPanel.SUMProfit.DragThisTo(repo.VATestWindow.ContainerMainPanel.JDropHint);
				ChooseSumOption();
				Reports.ReportLog("DragProfitToFilterDeck", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragProfitToFilterDeck : " + ex.Message);
			}
		}
		
		
		public static void ValidateAfterDragProfittoFilterDeck()
		{
			try
			{
				CompressedImage VAFiltering = repo.VATestWindow.PivotWindowInfo.GetProfittoFilterDeck();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VATestWindow.PivotWindowInfo;
				Validate.ContainsImage(info, VAFiltering, options, "After drag profit to filter graph validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterDragProfittoFilterDeck : " + ex.Message);
			}
		}
		
		public static void ChooseSumOption()
		{
			try
			{
				if(repo.FilterFieldProfit.ListItem11Info.Exists(5000))
				{
					repo.FilterFieldProfit.ListItem11.ClickThis();
					
					repo.FilterFieldProfit.ChooseInfo.WaitForItemExists(5000);
					repo.FilterFieldProfit.Choose.ClickThis();
					
					Reports.ReportLog("ChooseSumOption", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ChooseSumOption : " + ex.Message);
			}
		}
		
		public static void IncreasetheSUMValue()
		{
			try
			{
				repo.VATestWindow.Worksheet1.RangeSliderInfo.WaitForItemExists(10000);
				repo.VATestWindow.Worksheet1.RangeSlider.MoveTo("126;11");
				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
				
				repo.VATestWindow.Worksheet1.RangeSlider.MoveTo("176;11");
				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				Reports.ReportLog("IncreasetheSUMValue", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : IncreasetheSUMValue : " + ex.Message);
			}
		}
		
		public static void ValidateAfterAtleastIncrease()
		{
			try
			{
				CompressedImage VAFiltering = repo.VATestWindow.PivotWindowInfo.GetAtleastIncrease();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VATestWindow.PivotWindowInfo;
				Validate.ContainsImage(info, VAFiltering, options, "After Atleast value increase graph validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterDragProfittoFilterDeck : " + ex.Message);
			}
		}
		
		public static void DecreasetheSUMValue()
		{
			try
			{
				repo.VATestWindow.Worksheet1.RangeSliderInfo.WaitForItemExists(10000);
				repo.VATestWindow.Worksheet1.RangeSlider.MoveTo("194;11");
				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
				
				repo.VATestWindow.Worksheet1.RangeSlider.MoveTo("127;10");
				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				Reports.ReportLog("DecreasetheSUMValue", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DecreasetheSUMValue : " + ex.Message);
			}
		}
		
		public static void ClickonTriangleIcon()
		{
			try
			{
				repo.VATestWindow.Worksheet1.JLabelInfo.WaitForItemExists(10000);
				repo.VATestWindow.Worksheet1.JLabel.ClickThis();
				Reports.ReportLog("ClickonTriangleIcon", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonTriangleIcon : " + ex.Message);
			}
		}
		
		public static void ClickonAtleast()
		{
			try
			{
				repo.SunAwtWindow.AtLeastInfo.WaitForItemExists(5000);
				repo.SunAwtWindow.AtLeast.ClickThis();
				Reports.ReportLog("ClickonAtleast", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonAtleast : " + ex.Message);
			}
		}
		
		public static void InceaseAtleastValue()
		{
			try
			{
				repo.VATestWindow.Worksheet1.JSliderInfo.WaitForItemExists(10000);
				repo.VATestWindow.Worksheet1.JSlider.MoveTo("4;12");
				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
				repo.VATestWindow.Worksheet1.JSlider.MoveTo("111;13");
				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				
				Reports.ReportLog("InceaseAtleastValue", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : InceaseAtleastValue : " + ex.Message);
			}
		}
		
		public static void ValidateAfterIncreaseAtleastOption()
		{
			try
			{
				CompressedImage VAFiltering = repo.VATestWindow.PivotWindowInfo.GetAtleastIncrease();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VATestWindow.PivotWindowInfo;
				Validate.ContainsImage(info, VAFiltering, options, "After increase atleast Option graph validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterDecreaseAtmostOption : " + ex.Message);
			}
		}
		
		public static void ClickonAtMost()
		{
			try
			{
				repo.SunAwtWindow.AtMostInfo.WaitForItemExists(5000);
				repo.SunAwtWindow.AtMost.ClickThis();
				Reports.ReportLog("ClickonAtMost", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonAtMost : " + ex.Message);
			}
		}
		
		public static void DecreaseAtmostValue()
		{
			try
			{
				repo.VATestWindow.Worksheet1.JSliderInfo.WaitForItemExists(10000);
				repo.VATestWindow.Worksheet1.JSlider.MoveTo("194;9");
				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
				repo.VATestWindow.Worksheet1.JSlider.MoveTo("61;11");
				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				Reports.ReportLog("DecreaseAtmostValue", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DecreaseAtmostValue : " + ex.Message);
			}
		}
		
		public static void ValidateAfterDecreaseAtmostOption()
		{
			try
			{
				CompressedImage VAFiltering = repo.VATestWindow.PivotWindowInfo.GetAtMostDecrease();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VATestWindow.PivotWindowInfo;
				Validate.ContainsImage(info, VAFiltering, options, "After Decrease Atmost Option graph validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterDecreaseAtmostOption : " + ex.Message);
			}
		}
		
		#endregion
		
		#region "TC3"
		
		public static void DragPCtoColumn1()
		{
			try
			{
				repo.VATestWindow.ProductCategoryInfo.WaitForItemExists(5000);
				repo.VATestWindow.ProductCategory.RightClickThis();
				System.Threading.Thread.Sleep(300);
				
				repo.SunAwtWindow.AddToColumnsDeckInfo.WaitForItemExists(5000);
				repo.SunAwtWindow.AddToColumnsDeck.ClickThis();
				
				Reports.ReportLog("DragPCtoColumn1", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragPCtoColumn1 : " + ex.Message);
			}
		}
		
		public static void DragProfittoRow()
		{
			try
			{
				repo.VATestWindow.ContainerMainPanel.SUMProfitInfo.WaitForItemExists(5000);
				repo.VATestWindow.ContainerMainPanel.SUMProfit.RightClickThis();
				
				System.Threading.Thread.Sleep(300);
				
				repo.SunAwtWindow.AddToRowsDeckInfo.WaitForItemExists(5000);
				repo.SunAwtWindow.AddToRowsDeck.ClickThis();
				
				Reports.ReportLog("DragProfittoRow", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragProfittoRow : " + ex.Message);
			}
		}
		
		public static void ValidateAfterDragProfittoRow()
		{
			try
			{
				CompressedImage VAFiltering = repo.VATestWindow.PivotWindowInfo.GetProfittoRow();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VATestWindow.PivotWindowInfo;
				Validate.ContainsImage(info, VAFiltering, options, "After Drag Profit to row graph validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterDragProfittoRow : " + ex.Message);
			}
		}
		
		public static void DragPCtoFilterDeck()
		{
			try
			{
				repo.VATestWindow.Self.Activate();
				repo.VATestWindow.ProductCategory.DragThisTo(repo.VATestWindow.ContainerContentPanel.JDropHint);
//				repo.VATestWindow.ProductCategoryInfo.WaitForItemExists(50000);
//				repo.VATestWindow.ProductCategory.ClickThis();
//
//				repo.VATestWindow.ProductCategoryInfo.WaitForItemExists(5000);
//	            repo.VATestWindow.ProductCategory.MoveTo();
//	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
//
//	            repo.VATestWindow.ProductCategoryInfo.WaitForItemExists(25000);
//	            repo.VATestWindow.ProductCategory.MoveTo();
//
//	            repo.VATestWindow.ContainerContentPanel.JDropHintInfo.WaitForItemExists(50000);
//	            repo.VATestWindow.ContainerContentPanel.JDropHint.MoveTo();
//	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				
				Reports.ReportLog("DragPCtoFilterDeck", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragPCtoFilterDeck : " + ex.Message);
			}
		}
		
		public static void ClickonHideDeck()
		{
			try
			{
				repo.SunAwtWindow.HideDeckInfo.WaitForItemExists(5000);
				repo.SunAwtWindow.HideDeck.ClickThis();
				Reports.ReportLog("ClickonHideDeck", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonHideDeck : " + ex.Message);
			}
		}
		
		public static void ClickonTriangleIconPC()
		{
			try
			{
				repo.VATestWindow.TriangleIconPCInfo.WaitForItemExists(5000);
				
				
				repo.VATestWindow.TriangleIconPC.ClickThis();
				Reports.ReportLog("ClickonTriangleIconPC", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonTriangleIconPC : " + ex.Message);
			}
		}
		
		public static void ClickonTriangleIconProfit()
		{
			try
			{
				repo.VATestWindow.TriangleIconProfitInfo.WaitForItemExists(5000);
				repo.VATestWindow.TriangleIconProfit.ClickThis();
				Reports.ReportLog("ClickonTriangleIconProfit", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonTriangleIconProfit : " + ex.Message);
			}
		}
		
		public static void DecreaseProfitValue()
		{
			try
			{
				repo.VATestWindow.RangeSliderInfo.WaitForItemExists(10000);
				repo.VATestWindow.RangeSlider.MoveTo("195;11");
				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
				
				repo.VATestWindow.RangeSlider.MoveTo("59;12");
				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				
				repo.VATestWindow.RangeSliderInfo.WaitForItemExists(10000);
				repo.VATestWindow.RangeSlider.MoveTo("57;11");
				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
				
				repo.VATestWindow.RangeSlider.MoveTo("198;11");
				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				Reports.ReportLog("DecreaseProfitValue", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DecreaseProfitValue : " + ex.Message);
			}
		}
		
		public static void ValidateAfterDecreaseProfitValue()
		{
			try
			{
				CompressedImage VAFiltering = repo.VATestWindow.PivotWindowInfo.GetDecreaseProfit();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VATestWindow.PivotWindowInfo;
				Validate.ContainsImage(info, VAFiltering, options, "After decrease profit value graph validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterDecreaseProfitValue : " + ex.Message);
			}
		}
		
		public static void IncreaseProfitValue()
		{
			try
			{
				repo.VATestWindow.RangeSliderInfo.WaitForItemExists(10000);
				repo.VATestWindow.RangeSlider.MoveTo("3;9");
				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
				
				repo.VATestWindow.RangeSlider.MoveTo("80;9");
				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				
				repo.VATestWindow.RangeSliderInfo.WaitForItemExists(10000);
				repo.VATestWindow.RangeSlider.MoveTo("81;12");
				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
				
				repo.VATestWindow.RangeSlider.MoveTo("5;7");
				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				Reports.ReportLog("IncreaseProfitValue", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : IncreaseProfitValue : " + ex.Message);
			}
		}
		
		public static void ValidateAfterIncreaseProfitValue()
		{
			try
			{
				CompressedImage VAFiltering = repo.VATestWindow.PivotWindowInfo.GetIncreaseProfit();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VATestWindow.PivotWindowInfo;
				Validate.ContainsImage(info, VAFiltering, options, "After increase profit value graph validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterIncreaseProfitValue : " + ex.Message);
			}
		}
		
		public static void IncreaseAtleastValue()
		{
			try
			{
				repo.VATestWindow.JSliderInfo.WaitForItemExists(10000);
				repo.VATestWindow.JSlider.MoveTo("2;14");
				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
				repo.VATestWindow.JSlider.MoveTo("136;13");
				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				Reports.ReportLog("IncreaseAtleastValue", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : IncreaseAtleastValue : " + ex.Message);
			}
		}
		
		public static void ValidateIncreaseAtleastValue()
		{
			try
			{
				CompressedImage VAFiltering = repo.VATestWindow.PivotWindow1Info.GetAtleastIncrease();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VATestWindow.PivotWindow1Info;
				Validate.ContainsImage(info, VAFiltering, options, "After increase AT LEAST value graph validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterIncreaseProfitValue : " + ex.Message);
			}
		}
		
		public static void DecreaseAtmostValue1()
		{
			try
			{
				repo.VATestWindow.JSliderInfo.WaitForItemExists(5000);
				repo.VATestWindow.JSlider.MoveTo("195;13");
				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
				
				repo.VATestWindow.JSlider.MoveTo("88;12");
				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				Reports.ReportLog("DecreaseAtmostVlaue", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DecreaseAtmostValue1 : " + ex.Message);
			}
		}
		
		public static void ValidateDecreaseAtmostValue()
		{
			try
			{
				CompressedImage VAFiltering = repo.VATestWindow.PivotWindow1Info.GetAtmostDecrease();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VATestWindow.PivotWindow1Info;
				Validate.ContainsImage(info, VAFiltering, options, "After decrease AT MOST value graph validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateDecreaseAtmostValue : " + ex.Message);
			}
		}
		
		#endregion
		
		#region "TC5"
		
		public static void SelectNewFile()
		{
			try
			{
				repo.OpenWindow.FilePathTextbox.TextBoxText(TC_10600_PATH + "test-filter.vizx");
				Reports.ReportLog("SelectNewFile", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectNewFile : " + ex.Message);
			}
		}
		
		public static void ValidateTestFilteringData()
		{
			try
			{
				CompressedImage Filter = repo.TestWindow.PivotWindow4Info.GetTestFilteringData();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.TestWindow.PivotWindow4Info;
				Validate.ContainsImage(info, Filter, options, "Test filtering data graph validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateTestFilteringData : " + ex.Message);
			}
		}
		
		public static void SelectTwoColors()
		{
			try
			{
				repo.TestWindow.ContainerChartPanel.ContainerCanvas.Click("264;149");
				System.Threading.Thread.Sleep(10000);
				Keyboard.Press("{LControlKey down}");
				repo.TestWindow.ContainerChartPanel.ContainerCanvas.Click("256;204"); 
				Keyboard.Press("{LControlKey up}");
				repo.SunAwtWindow.Exclude.Click("34;8");
				Reports.ReportLog("SelectTwoColors", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectTwoColors : " + ex.Message);
			}
		}
		
		public static void SelectTwoYears()
		{
			try
			{
				repo.TestWindow.ContainerChartPanel.BIChartOverlayPanel.Click("41;83");
				Keyboard.Press("{LControlKey down}");
				System.Threading.Thread.Sleep(10000);
				repo.TestWindow.ContainerChartPanel.BIChartOverlayPanel.MoveTo("33;204");
				repo.TestWindow.ContainerChartPanel.BIChartOverlayPanel.Click("33;204");
				Keyboard.Press("{LControlKey up}");
				repo.SunAwtWindow.KeepOnly.Click("46;8");
				Reports.ReportLog("SelectTwoYears", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectTwoYears : " + ex.Message);
			}
		}
		
		public static void ValidateAfterSelectTwoyears()
		{
			try
			{
				CompressedImage Filter = repo.TestWindow.PivotWindow4Info.GetSelectTwoYears();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.TestWindow.PivotWindow4Info;
				Validate.ContainsImage(info, Filter, options, "After selection of two years data validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterSelectTwoyears : " + ex.Message);
			}
		}
		
		public static void ValidateAfterSelectTwoColors()
		{
			try
			{
				CompressedImage Filter = repo.TestWindow.PivotWindow4Info.GetSelectTwoClors();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.TestWindow.PivotWindow4Info;
				Validate.ContainsImage(info, Filter, options, "After selection of two colors data validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterSelectTwoColors : " + ex.Message);
			}
		}
		
		public static void ClickonKeeponly()
		{
			try
			{
				repo.SunAwtWindow.KeepOnlyInfo.WaitForItemExists(10000);
				repo.SunAwtWindow.KeepOnly.ClickThis();
				Reports.ReportLog("ClickonKeeponly", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonKeeponly : " + ex.Message);
			}
		}
		
		public static void ClickonExclude()
		{
			try
			{
				repo.SunAwtWindow.ExcludeInfo.WaitForItemExists(10000);
				repo.SunAwtWindow.Exclude.ClickThis();
				Reports.ReportLog("ClickonExclude", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonExclude : " + ex.Message);
			}
		}
		
		#endregion
		
		#region "TC4"
		
		public static void ValidateWorkSheet3forFilter()
		{
			try
			{
				CompressedImage Filter = repo.TestWindow.PivotWindow3Info.GetSheet3();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.TestWindow.PivotWindow3Info;
				Validate.ContainsImage(info, Filter, options, "WorkSheet3 validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateWorkSheet3 : " + ex.Message);
			}
		}
		
		public static void ClickonShipDate()
		{
			try
			{
				repo.TestWindow.ShipdateInfo.WaitForItemExists(5000);
				repo.TestWindow.Shipdate.Click("128;9");
				Reports.ReportLog("ClickonShipDate", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonShipDate : " + ex.Message);
			}
		}
		
		public static void ClickonPC()
		{
			try
			{
				repo.TestWindow.ProductCategoryInfo.WaitForItemExists(5000);
				repo.TestWindow.ProductCategory.Click("129;9");
				Reports.ReportLog("ClickonPC", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonPC : " + ex.Message);
			}
		}
		
		public static void ClickonPC4()
		{
			try
			{
				repo.TestWindow.PC4Info.WaitForItemExists(5000);
				repo.TestWindow.PC4.Click("129;9");
				Reports.ReportLog("ClickonPC4", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonPC4 : " + ex.Message);
			}
		}
		
		public static void ClickonAutomatic()
		{
			try
			{
				repo.DataFormatWindow.AutomaticInfo.WaitForItemExists(5000);
				repo.DataFormatWindow.Automatic.ClickThis();
				Reports.ReportLog("ClickonAutomatic", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonAutomatic : " + ex.Message);
			}
		}
		
		public static void ClickonOkayButton()
		{
			try
			{
				repo.DataFormatWindow.OkayInfo.WaitForItemExists(5000);
				repo.DataFormatWindow.Okay.ClickThis();
				Reports.ReportLog("ClickonOkayButton", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonOkayButton : " + ex.Message);
			}
		}
		
		public static void ClickonStandardDate()
		{
			try
			{
				repo.DataFormatWindow.StandardDateInfo.WaitForItemExists(5000);
				repo.DataFormatWindow.StandardDate.ClickThis();
				Reports.ReportLog("ClickonStandardDate", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonStandardDate : " + ex.Message);
			}
		}
		
		public static void CLickon2004Option()
		{
			try
			{
				repo.SunAwtWindow.N2004OptionInfo.WaitForItemExists(5000);
				repo.SunAwtWindow.N2004Option.ClickThis();
				Reports.ReportLog("CLickon2004Option", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CLickon2004Option : " + ex.Message);
			}
		}
		
		public static void SelectFormat()
		{
			try
			{
				repo.SunAwtWindow.FormatInfo.WaitForItemExists(5000);
				repo.SunAwtWindow.Format.ClickThis();
				Reports.ReportLog("SelectFormat", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectFormat : " + ex.Message);
			}
		}
		
		public static void DecreaseDateFilter()
		{
			try
			{
				repo.TestWindow.RangeSliderInfo.WaitForItemExists(5000);
				repo.TestWindow.RangeSlider.MoveTo("194;13");
				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
				repo.TestWindow.RangeSlider.MoveTo("35;15");
				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				Reports.ReportLog("DecreaseDateFilter", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DecreaseDateFilter : " + ex.Message);
			}
		}
		
		public static void ValidateAfterDecreaseDataFilter()
		{
			try
			{
				CompressedImage VAFiltering = repo.TestWindow.PivotWindow3Info.GetDecreaseDateFilter();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.TestWindow.PivotWindow3Info;
				Validate.ContainsImage(info, VAFiltering, options, "After Decrease date filter Option graph validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterDecreaseDataFilter : " + ex.Message);
			}
		}
		
		public static void IncreaseDateFilter()
		{
			try
			{
				repo.TestWindow.RangeSliderInfo.WaitForItemExists(5000);
				repo.TestWindow.RangeSlider.MoveTo("32;16");
				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
				repo.TestWindow.RangeSlider.MoveTo("40;8");
				repo.TestWindow.CPanel.MoveTo("209;43");
				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				Reports.ReportLog("IncreaseDateFilter", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : IncreaseDateFilter : " + ex.Message);
			}
		}
		
		public static void IncreaseLongDateValue()
		{
			try
			{
				repo.TestWindow.RangeSliderInfo.WaitForItemExists(5000);
				repo.TestWindow.RangeSlider.MoveTo("3;11");
				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
				repo.TestWindow.RangeSlider.MoveTo("160;9");
				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				Reports.ReportLog("IncreaseLongDateValue", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : IncreaseLongDateValue : " + ex.Message);
			}
		}
		
		public static void ValidateAfterIncreaseLongDate()
		{
			try
			{
				CompressedImage VAFiltering = repo.TestWindow.PivotWindow3Info.GetIncreaseLongDate();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.TestWindow.PivotWindow3Info;
				Validate.ContainsImage(info, VAFiltering, options, "After Increase LongDate Option graph validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterDecreaseDataFilter : " + ex.Message);
			}
		}
		
		public static void DecreaseLongDateValue()
		{
			try
			{
				repo.TestWindow.RangeSliderInfo.WaitForItemExists(5000);
				repo.TestWindow.RangeSlider.MoveTo("161;13");
				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
				repo.TestWindow.RangeSlider.MoveTo("169;5");
				repo.TestWindow.WorksheetPanel.MoveTo("886;148");
				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				Reports.ReportLog("DecreaseLongDateValue", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : IncreaseLongDateValue : " + ex.Message);
			}
		}
		
		public static void UncheckAlloption()
		{
			try
			{
				repo.TestWindow.ContainerContentPanel.ListItemAllInfo.WaitForItemExists(5000);
				repo.TestWindow.ContainerContentPanel.ListItemAll.Click("11;9");
				Reports.ReportLog("UncheckAlloption", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : UncheckAlloption : " + ex.Message);
			}
		}
		
		public static void Checkon2004()
		{
			try
			{
				repo.TestWindow.ContainerContentPanel.ListItem2004Info.WaitForItemExists(5000);
				repo.TestWindow.ContainerContentPanel.ListItem2004.Click("9;8");
				Reports.ReportLog("Checkon2004", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : Checkon2004 : " + ex.Message);
			}
		}
		
		public static void ValidateAfterCheck2004()
		{
			try
			{
				CompressedImage VAFiltering = repo.TestWindow.PivotWindow3Info.GetAfterCheck2004();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.TestWindow.PivotWindow3Info;
				Validate.ContainsImage(info, VAFiltering, options, "After check 2004 Option graph validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterCheck2004 : " + ex.Message);
			}
		}
		
		public static void UnCheckon2004()
		{
			try
			{
				repo.TestWindow.ContainerContentPanel.ListItem2004Info.WaitForItemExists(5000);
				repo.TestWindow.ContainerContentPanel.ListItem2004.Click("11;8");
				Reports.ReportLog("UnCheckon2004", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : UnCheckon2004 : " + ex.Message);
			}
		}
		
		public static void Check2006()
		{
			try
			{
				repo.TestWindow.ContainerContentPanel.ListItem2006Info.WaitForItemExists(5000);
				repo.TestWindow.ContainerContentPanel.ListItem2006.Click("7;7");
				Reports.ReportLog("Check2006", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : Check2006 : " + ex.Message);
			}
		}
		
		public static void ValidateAfterCheck2006()
		{
			try
			{
				CompressedImage VAFiltering = repo.TestWindow.PivotWindow3Info.GetAfterCheck2006();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.TestWindow.PivotWindow3Info;
				Validate.ContainsImage(info, VAFiltering, options, "After check 2006 Option graph validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterCheck2004 : " + ex.Message);
			}
		}
		
		public static void ClickonFile()
		{
			try
			{
				repo.TestWindow.FileInfo.WaitForItemExists(5000);
				repo.TestWindow.File.ClickThis();
				Reports.ReportLog("ClickonFile", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonFile : " + ex.Message);
			}
		}
		
		public static void ClickonReverttoSave()
		{
			try
			{
				repo.SunAwtWindow.RevertToSavedInfo.WaitForItemExists(5000);
				repo.SunAwtWindow.RevertToSaved.ClickThis();
				Reports.ReportLog("ClickonReverttoSave", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonReverttoSave : " + ex.Message);
			}
		}
		
		public static void ClickOnRevertOption()
		{
			try
			{
				repo.RevertToSavedWindow.RevertInfo.WaitForItemExists(5000);
				repo.RevertToSavedWindow.Revert.ClickThis();
				System.Threading.Thread.Sleep(10000);
				Reports.ReportLog("ClickOnRevertOption", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnRevertOption : " + ex.Message);
			}
		}
		
		public static void MaximizetheWindow()
		{
			try
			{
				repo.TestWindow.Self.Maximize();
				Reports.ReportLog("ClickOnRevertOption", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnRevertOption : " + ex.Message);
			}
		}
		
		
		public static void RightClickonShipDate()
		{
			try
			{
				Ranorex.Mouse.Click(repo.TestWindow.YearsShipdate, System.Windows.Forms.MouseButtons.Right, new Point(30, 10));
				Reports.ReportLog("RightClickonShipDate", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : RightClickonShipDate : " + ex.Message);
			}
		}
		
		public static void RemoveShipdate()
		{
			try
			{
				repo.SunAwtWindow.RemoveInfo.WaitForItemExists(5000);
				repo.SunAwtWindow.Remove.ClickThis();
				Reports.ReportLog("RemoveShipdate", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : RemoveShipdate : " + ex.Message);
			}
		}
		
		public static void DragShipdatetoFilterDeck()
		{
			try
			{
				repo.TestWindow.ContainerContentPanel.ShipDateInfo.WaitForItemExists(10000);
				repo.TestWindow.ContainerContentPanel.ShipDate.Click("50;10");
				
				repo.TestWindow.ContainerContentPanel.ShipDate.MoveTo("50;10");
				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
				
				repo.TestWindow.ContainerContentPanel.ShipDate.MoveTo("58;2");
				
				repo.TestWindow.ContainerContentPanel.Panel.MoveTo("62;17");
				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				
				
				Reports.ReportLog("DragShipdatetoFilterDeck", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragShipdatetoFilterDeck : " + ex.Message);
			}
		}
		
		public static void SelectRelativeDateOption()
		{
			try
			{
				repo.FilterFieldShipDate.ListItem1.MoveTo("50;6");
				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
				repo.FilterFieldShipDate.ListItem1.MoveTo("59;8");
				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				repo.FilterFieldShipDate.ChooseInfo.WaitForItemExists(1000);
				repo.FilterFieldShipDate.Choose.ClickThis();
				Reports.ReportLog("SelectRelativeDateOption", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectRelativeDateOption : " + ex.Message);
			}
		}
		
		public static void ClickOnThisYearIcon()
		{
			try
			{
				repo.TestWindow.TriangleIconThisYearInfo.WaitForItemExists(5000);
				repo.TestWindow.TriangleIconThisYear.ClickThis();
				Reports.ReportLog("ClickOnThisYearIcon", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnThisYearIcon : " + ex.Message);
			}
		}
		
		public static void Select2006Year()
		{
			try
			{
				repo.SunAwtWindow.ContentPanel.AnchorRelativeTo.Click("33;10");
				repo.SunAwtWindow.ContentPanel.AbstractComboBoxDollarComboBoxTextField.Click("28;8");
				Keyboard.PrepareFocus(repo.SunAwtWindow.ContentPanel.AbstractComboBoxDollarComboBoxTextField);
				Keyboard.Press(System.Windows.Forms.Keys.A | System.Windows.Forms.Keys.Control, 30, Keyboard.DefaultKeyPressTime, 1, true);
				repo.SunAwtWindow.ContentPanel.AbstractComboBoxDollarComboBoxTextField.PressKeys("{NumPad1}{Divide}{NumPad1}{Divide}{NumPad2}{NumPad0}{NumPad0}{NumPad6}{Return}");
				Reports.ReportLog("Select2006Year", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : Select2006Year : " + ex.Message);
			}
		}
		
		public static void ValidateAfterSelec2006()
		{
			try
			{
				CompressedImage VAFiltering = repo.TestWindow.PivotWindow4Info.GetN2006Data();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.TestWindow.PivotWindow4Info;
				Validate.ContainsImage(info, VAFiltering, options, "After select 2006 year Option graph validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterSelec2006 : " + ex.Message);
			}
		}
		
		public static void SelectNextTwoYears()
		{
			try
			{
				repo.SunAwtWindow.ContentPanel.NextInfo.WaitForItemExists(5000);
				repo.SunAwtWindow.ContentPanel.Next.Click();
				Keyboard.PrepareFocus(repo.SunAwtWindow.ContentPanel.SpinnerFormattedTextField);
				Keyboard.Press(System.Windows.Forms.Keys.A | System.Windows.Forms.Keys.Control, 30, Keyboard.DefaultKeyPressTime, 1, true);
				repo.SunAwtWindow.ContentPanel.SpinnerFormattedTextField.PressKeys("{NumPad2}");
				repo.SunAwtWindow.ContentPanel.SpinnerFormattedTextField.PressKeys("{Return}");
				Reports.ReportLog("SelectNextTwoYears", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectNextTwoYears : " + ex.Message);
			}
		}
		
		public static void ValidateNextTwoYears()
		{
			try
			{
				CompressedImage VAFiltering = repo.TestWindow.PivotWindow4Info.GetNextTwoYears();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.TestWindow.PivotWindow4Info;
				Validate.ContainsImage(info, VAFiltering, options, "After select next two years Option graph validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateNextTwoYears : " + ex.Message);
			}
		}
		
		public static void Select2004Year()
		{
			try
			{
				repo.SunAwtWindow.ContentPanel.AbstractComboBoxDollarComboBoxTextField1.Click("28;10");
				Keyboard.PrepareFocus(repo.SunAwtWindow.ContentPanel.AbstractComboBoxDollarComboBoxTextField1);
				Keyboard.Press(System.Windows.Forms.Keys.A | System.Windows.Forms.Keys.Control, 30, Keyboard.DefaultKeyPressTime, 1, true);
				repo.SunAwtWindow.ContentPanel.AbstractComboBoxDollarComboBoxTextField1.PressKeys("{NumPad1}{Divide}{NumPad1}{Divide}{NumPad2}{NumPad0}{NumPad0}{NumPad4}{Return}");
				Reports.ReportLog("Select2004Year", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : Select2004Year : " + ex.Message);
			}
		}
		
		public static void ValidateSelect2004()
		{
			try
			{
				CompressedImage VAFiltering = repo.TestWindow.PivotWindow4Info.GetN2004Data();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.TestWindow.PivotWindow4Info;
				Validate.ContainsImage(info, VAFiltering, options, "After select 2004 graph validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : Validateselect2004 : " + ex.Message);
			}
		}
		
		public static void SelectLastTwoYears()
		{
			try
			{
				repo.SunAwtWindow.ContentPanel.Last.Click("14;12");
				repo.SunAwtWindow.ContentPanel.SpinnerFormattedTextField1.Click("31;6");
				Keyboard.PrepareFocus(repo.SunAwtWindow.ContentPanel.SpinnerFormattedTextField1);
				Keyboard.Press(System.Windows.Forms.Keys.A | System.Windows.Forms.Keys.Control, 30, Keyboard.DefaultKeyPressTime, 1, true);
				repo.SunAwtWindow.ContentPanel.SpinnerFormattedTextField1.PressKeys("{NumPad2}");
				repo.SunAwtWindow.ContentPanel.SpinnerFormattedTextField1.PressKeys("{Return}");
				Reports.ReportLog("SelectLastTwoYears", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectLastTwoYears : " + ex.Message);
			}
		}
		
		public static void ValidateLastTwoYears()
		{
			try
			{
				CompressedImage VAFiltering = repo.TestWindow.PivotWindow4Info.GetLastTwoYears();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.TestWindow.PivotWindow4Info;
				Validate.ContainsImage(info, VAFiltering, options, "After select last two years Option graph validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateLastTwoYears : " + ex.Message);
			}
		}
		
		#endregion
		
		#region "TC6"
		
		public static void DragProductCategorytoFilterDeck()
		{
			try
			{
				repo.TestWindow.ProductCategory1Info.WaitForItemExists(30000);
				repo.TestWindow.ProductCategory1.ClickThis();
				repo.TestWindow.ProductCategory1.MoveTo("56;8");
				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
				repo.TestWindow.ProductCategory1Info.WaitForItemExists(30000);
				repo.TestWindow.ProductCategory1.MoveTo("64;0");
				repo.TestWindow.ProductCategory1Info.WaitForItemExists(30000);
				repo.TestWindow.Panel.MoveTo("75;39");
				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				Reports.ReportLog("SelectWorkSheets", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectWorkSheets : " + ex.Message);
			}
		}
		
		public static void ClickonTriangleIconPC1()
		{
			try
			{
				repo.TestWindow.TriangleIconPCInfo.WaitForItemExists(5000);
				repo.TestWindow.TriangleIconPC.ClickThis();
				Reports.ReportLog("ClickonTriangleIconPC", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonTriangleIconPC : " + ex.Message);
			}
		}
		
		public static void SelectWorkSheets()
		{
			try
			{
				repo.Datastudio1.WorksheetsInfo.WaitForItemExists(5000);
				repo.Datastudio1.Worksheets.ClickThis();
				Reports.ReportLog("SelectWorkSheets", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectWorkSheets : " + ex.Message);
			}
		}
		
		public static void CLickonSelectedWorkSheets()
		{
			try
			{
				repo.Datastudio2.SelectedWorksheetsInfo.WaitForItemExists(5000);
				repo.Datastudio2.SelectedWorksheets.ClickThis();
				Reports.ReportLog("CLickonSelectedWorkSheets", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CLickonSelectedWorkSheets : " + ex.Message);
			}
		}
		
		public static void CheckAllWorksheets()
		{
			try
			{
				repo.SelectedWorksheets.Table.WorkSheet1Info.WaitForItemExists(5000);
				repo.SelectedWorksheets.Table.WorkSheet1.ClickThis();
				repo.SelectedWorksheets.Table.WorkSheet2.ClickThis();
				repo.SelectedWorksheets.Table.WorkSheet4.ClickThis();
				Reports.ReportLog("CheckAllWorksheets", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CheckAllWorksheets : " + ex.Message);
			}
		}
		
		public static void ClickonShare()
		{
			try
			{
				repo.SelectedWorksheets.ShareInfo.WaitForItemExists(5000);
				repo.SelectedWorksheets.Share.ClickThis();
				Reports.ReportLog("ClickonShare", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonShare : " + ex.Message);
			}
		}
		
		public static void ClickonShipdateTriangleIcon()
		{
			try
			{
				repo.TestWindow.TriangleIconShipdateInfo.WaitForItemExists(5000);
				repo.TestWindow.TriangleIconShipdate.ClickThis();
				Reports.ReportLog("ClickonShipdateTriangleIcon", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonShipdateTriangleIcon : " + ex.Message);
			}
		}
		
		public static void SelectShowApplyOption()
		{
			try
			{
				repo.SunAwtWindow.ShowApplyButtonInfo.WaitForItemExists(5000);
				repo.SunAwtWindow.ShowApplyButton.ClickThis();
				Reports.ReportLog("SelectShowApplyOption", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectShowApplyOption : " + ex.Message);
			}
		}
		
		public static void UncheckAll()
		{
			try
			{
				repo.TestWindow.UncheckAllInfo.WaitForItemExists(5000);
				repo.TestWindow.UncheckAll.Click("10;9");
				Reports.ReportLog("UncheckAll", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : UncheckAll : " + ex.Message);
			}
		}
		
		public static void CheckBibShorts()
		{
			try
			{
				repo.TestWindow.BibShortsInfo.WaitForItemExists(5000);
				repo.TestWindow.BibShorts.Click("11;9");
				Reports.ReportLog("CheckBibShorts", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CheckBibShorts : " + ex.Message);
			}
		}
		
		public static void CheckBrakes()
		{
			try
			{
				repo.TestWindow.BrakesInfo.WaitForItemExists(5000);
				repo.TestWindow.Brakes.Click("10;7");
				Reports.ReportLog("CheckBrakes", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CheckBrakes : " + ex.Message);
			}
		}
		
		public static void ClickonApply()
		{
			try
			{
				repo.TestWindow.ApplyInfo.WaitForItemExists(5000);
				repo.TestWindow.Apply.ClickThis();
				Reports.ReportLog("ClickonApply", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonApply : " + ex.Message);
			}
		}
		
		public static void ClickonWorkSheet1()
		{
			try
			{
				repo.TestWindow.WorkSheet1Info.WaitForItemExists(5000);
				repo.TestWindow.WorkSheet1.ClickThis();
				Reports.ReportLog("ClickonWorkSheet1", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonWorkSheet1 : " + ex.Message);
			}
		}
		
		public static void ValidateWorkSheet1Options()
		{
			try
			{
				CompressedImage FilterSharing = repo.TestWindow.PivotWindow1Info.GetSelectedItems();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.TestWindow.PivotWindow1Info;
				Validate.ContainsImage(info, FilterSharing, options, "After select options data validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateWorkSheet1Options : " + ex.Message);
			}
		}
		
		public static void ValidateWorkSheet2Options()
		{
			try
			{
				CompressedImage FilterSharing = repo.TestWindow.PivotWindow2Info.GetSelectedItems();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.TestWindow.PivotWindow2Info;
				Validate.ContainsImage(info, FilterSharing, options, "After select options data validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateWorkSheet2Options : " + ex.Message);
			}
		}
		
		public static void ValidateWorkSheet4Options()
		{
			try
			{
				CompressedImage FilterSharing = repo.TestWindow.PivotWindow4Info.GetSelectedItems();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.TestWindow.PivotWindow4Info;
				Validate.ContainsImage(info, FilterSharing, options, "After select options data validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateWorkSheet2Options : " + ex.Message);
			}
		}
		
		public static void ClickonUndo()
		{
			try
			{
				repo.TestWindow.UndoInfo.WaitForItemExists(5000);
				repo.TestWindow.Undo.ClickThis();
				Reports.ReportLog("ClickonUndo", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonUndo : " + ex.Message);
			}
		}
		
		public static void ValidateWorkSheet1Undo()
		{
			try
			{
				CompressedImage FilterSharing = repo.TestWindow.PivotWindow1Info.GetAfterUndo();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.TestWindow.PivotWindow1Info;
				Validate.ContainsImage(info, FilterSharing, options, "After undo data validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateWorkSheet1Options : " + ex.Message);
			}
		}
		
		public static void ValidateWorkSheet2Undo()
		{
			try
			{
				CompressedImage FilterSharing = repo.TestWindow.PivotWindow2Info.GetAfterUndo();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.TestWindow.PivotWindow2Info;
				Validate.ContainsImage(info, FilterSharing, options, "After undo data validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateWorkSheet2Options : " + ex.Message);
			}
		}
		
		public static void ValidateWorkSheet4Undo()
		{
			try
			{
				CompressedImage FilterSharing = repo.TestWindow.PivotWindow4Info.GetAfterUndo();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.TestWindow.PivotWindow4Info;
				Validate.ContainsImage(info, FilterSharing, options, "After undo data validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateWorkSheet2Options : " + ex.Message);
			}
		}
		
		public static void ClickonRedo()
		{
			try
			{
				repo.TestWindow.RedoInfo.WaitForItemExists(5000);
				repo.TestWindow.Redo.ClickThis();
				Reports.ReportLog("ClickonRedo", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonRedo : " + ex.Message);
			}
		}
		
		public static void ValidateWorkSheet1BrakesOption()
		{
			try
			{
				CompressedImage FilterSharing = repo.TestWindow.PivotWindow1Info.GetSelectBrakes();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.TestWindow.PivotWindow1Info;
				Validate.ContainsImage(info, FilterSharing, options, "After select brakes data validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateWorkSheet1Options : " + ex.Message);
			}
		}
		
		public static void ValidateWorkSheet2BrakesOption()
		{
			try
			{
				CompressedImage FilterSharing = repo.TestWindow.PivotWindow2Info.GetSelectBrakes();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.TestWindow.PivotWindow2Info;
				Validate.ContainsImage(info, FilterSharing, options, "After select brakes data validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateWorkSheet2Options : " + ex.Message);
			}
		}
		
		public static void ValidateWorkSheet4BrakesOption()
		{
			try
			{
				CompressedImage FilterSharing = repo.TestWindow.PivotWindow4Info.GetSelectBrakes();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.TestWindow.PivotWindow4Info;
				Validate.ContainsImage(info, FilterSharing, options, "After select brakes data validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateWorkSheet2Options : " + ex.Message);
			}
		}
		
		public static void ClickonAllTriangleWindow()
		{
			try
			{
				repo.TestWindow.TriangleIconAllInfo.WaitForItemExists(5000);
				repo.TestWindow.TriangleIconAll.ClickThis();
				Reports.ReportLog("ClickonAllTriangleWindow", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonAllTriangleWindow : " + ex.Message);
			}
		}
		
		public static void SelectSingleValueDropDown()
		{
			try
			{
				repo.SunAwtWindow.SingleValueDropDownInfo.WaitForItemExists(5000);
				repo.SunAwtWindow.SingleValueDropDown.ClickThis();
				Reports.ReportLog("SelectSingleValueDropDown", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectSingleValueDropDown : " + ex.Message);
			}
		}
		
		public static void SelectBrakesOption()
		{
			try
			{
				repo.SunAwtWindow.BrakesInfo.WaitForItemExists(5000);
				repo.SunAwtWindow.Brakes.ClickThis();
				Reports.ReportLog("SelectBrakesOption", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectBrakesOption : " + ex.Message);
			}
		}
		
		public static void ClickonNotSharedOption()
		{
			try
			{
				repo.Datastudio2.NotSharedInfo.WaitForItemExists(5000);
				repo.Datastudio2.NotShared.ClickThis();
				Reports.ReportLog("ClickonNotSharedOption", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonNotSharedOption : " + ex.Message);
			}
		}
		
		public static void SelectMultipleValues()
		{
			try
			{
				repo.SunAwtWindow.MultipleValuesInfo.WaitForItemExists(5000);
				repo.SunAwtWindow.MultipleValues.ClickThis();
				Reports.ReportLog("SelectMultipleValues", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectMultipleValues : " + ex.Message);
			}
		}
		
		public static void SelectAllDataSource()
		{
			try
			{
				repo.Datastudio2.WorksheetsUsingThisDataInfo.WaitForItemExists(5000);
				repo.Datastudio2.WorksheetsUsingThisData.ClickThis();
				Reports.ReportLog("SelectAllDataSource", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectAllDataSource : " + ex.Message);
			}
		}
		
		public static void RemoveSharedWorkSheet()
		{
			try
			{
				repo.SunAwtWindow.RemoveSharedWorksheetsInfo.WaitForItemExists(5000);
				repo.SunAwtWindow.RemoveSharedWorksheets.ClickThis();
				Reports.ReportLog("RemoveSharedWorkSheet", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : RemoveSharedWorkSheet : " + ex.Message);
			}
		}
		
		public static void ValidateAfterRemoveWorksheet()
		{
			try
			{
				CompressedImage FilterSharing = repo.TestWindow.PivotWindow4Info.GetRemovedSharedWorksheet();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.TestWindow.PivotWindow2Info;
				Validate.ContainsImage(info, FilterSharing, options, "After remove shared worksheet data validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterRemoveWorksheet : " + ex.Message);
			}
		}
		
		public static void ValidateWorkSheet2AfterCheckAll()
		{
			try
			{
				CompressedImage FilterSharing = repo.TestWindow.PivotWindow2Info.GetCheckAll();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.TestWindow.PivotWindow2Info;
				Validate.ContainsImage(info, FilterSharing, options, "After CheckAll data validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateWorkSheet2AfterCheckAll : " + ex.Message);
			}
		}
		
		public static void ValidateWorkSheet4AfterCheckAll()
		{
			try
			{
				CompressedImage FilterSharing = repo.TestWindow.PivotWindow4Info.GetCheckAll();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.TestWindow.PivotWindow4Info;
				Validate.ContainsImage(info, FilterSharing, options, "After CheckAll data validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateWorkSheet4AfterCheckAll : " + ex.Message);
			}
		}
		
		#endregion
	}
	
}
