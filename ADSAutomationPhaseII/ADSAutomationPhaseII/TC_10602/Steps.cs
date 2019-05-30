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

namespace ADSAutomationPhaseII.TC_10602
{
	public static class Steps
	{
		public static TC10602Repo repo = TC10602Repo.Instance;
		public static PreconditionRepo preRepo = PreconditionRepo.Instance;
		public static string TC_10602_PATH = System.Configuration.ConfigurationManager.AppSettings["TC_10602"].ToString();
		
		public static void SelectNewFile()
		{
			try
			{
				repo.OpenWindow.FilePathTextbox.TextBoxText(TC_10602_PATH + "test-formatting.vizx");
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
				repo.TestWindow.Self.Maximize();
				Reports.ReportLog("ClickonOpenButton", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonOpenButton : " + ex.Message);
			}
		}
		
		public static void SelectEntireWindow()
		{
			try
			{
				repo.TestWindow.ComboBoxButtonInfo.WaitForItemExists(30000);
				repo.TestWindow.ComboBoxButton.ClickThis();
				repo.SunAwtWindow.EntireViewInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.EntireView.ClickThis();
				Reports.ReportLog("SelectEntireWindow", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectEntireWindow : " + ex.Message);
			}
		}
		
		public static void SelectEntireWindow1()
		{
			try
			{
				repo.VATestWindow.ComboBoxInfo.WaitForItemExists(30000);
				repo.VATestWindow.ComboBox.ClickThis();
				repo.SunAwtWindow.EntireViewInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.EntireView.ClickThis();
				Reports.ReportLog("SelectEntireWindow1", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectEntireWindow1 : " + ex.Message);
			}
		}
		
		public static void ClickonWorkSheet3()
		{
			try
			{
				repo.TestWindow.WorkSheet3Info.WaitForItemExists(30000);
				repo.TestWindow.WorkSheet3.ClickThis();
				Reports.ReportLog("ClickonWorkSheet3", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonWorkSheet3 : " + ex.Message);
			}
		}
		
		public static void ClickonDropDownBox()
		{
			try
			{
				repo.TestWindow.DropDownBoxInfo.WaitForItemExists(30000);
				repo.TestWindow.DropDownBox.ClickThis();
				Reports.ReportLog("ClickonDropDownBox", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonDropDownBox : " + ex.Message);
			}
		}
		
		public static void SelectPie()
		{
			try
			{
				repo.SunAwtWindow.PieChartInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.PieChart.ClickThis();
				Reports.ReportLog("SelectPie", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectPie : " + ex.Message);
			}
		}
		
		public static void ClickonColorWindow3()
		{
			try
			{
				repo.TestWindow.ColorWindow3Info.WaitForItemExists(30000);
				repo.TestWindow.ColorWindow3.ClickThis();
				Reports.ReportLog("ClickonColorWindow3", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonColorWindow3 : " + ex.Message);
			}
		}
		
		public static void ClickonColorWindow2()
		{
			try
			{
				repo.TestWindow.ColorWindow2Info.WaitForItemExists(30000);
				repo.TestWindow.ColorWindow2.ClickThis();
				Reports.ReportLog("ClickonColorWindow2", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonColorWindow2 : " + ex.Message);
			}
		}
		
		public static void ClickonColorWindow7()
		{
			try
			{
				repo.TestWindow.ColorWindow7Info.WaitForItemExists(30000);
				repo.TestWindow.ColorWindow7.ClickThis();
				Reports.ReportLog("ClickonColorWindow7", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonColorWindow7 : " + ex.Message);
			}
		}
		
		public static void SelectEditColors()
		{
			try
			{
				repo.Datastudio.EditColorsInfo.WaitForItemExists(30000);
				repo.Datastudio.EditColors.ClickThis();
				Reports.ReportLog("SelectEditColors", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectEditColors : " + ex.Message);
			}
		}
		
		public static void SelectThemeColor()
		{
			try
			{
				repo.EditColorsWindow.ThemeDropDownInfo.WaitForItemExists(1000);
				repo.EditColorsWindow.ThemeDropDown.Click();
				repo.SunAwtWindow.Flow.ClickThis();
				Reports.ReportLog("SelectThemeColor", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectThemeColor : " + ex.Message);
			}
		}
		
		public static void ClickonAssignPalette()
		{
			try
			{
				repo.EditColorsWindow.AssignPaletteInfo.WaitForItemExists(1000);
				repo.EditColorsWindow.AssignPalette.ClickThis();
				Reports.ReportLog("ClickonAssignPalette", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonAssignPalette : " + ex.Message);
			}
		}
		
		public static void ClickonApply()
		{
			try
			{
				repo.EditColorsWindow.ApplyInfo.WaitForItemExists(1000);
				repo.EditColorsWindow.Apply.ClickThis();
				Reports.ReportLog("ClickonApply", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonApply : " + ex.Message);
			}
		}
		
		public static void ClickonOkayButton()
		{
			try
			{
				repo.EditColorsWindow.OkayInfo.WaitForItemExists(1000);
				repo.EditColorsWindow.Okay.ClickThis();
				Reports.ReportLog("ClickonOkayButton", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonOkayButton : " + ex.Message);
			}
		}
		
		public static void ClickonUndoIcon()
		{
			try
			{
				repo.TestWindow.UndoButtonInfo.WaitForItemExists(1000);
				repo.TestWindow.UndoButton.ClickThis();
				Reports.ReportLog("ClickonUndoIcon", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonUndoIcon : " + ex.Message);
			}
		}
		
		public static void ClickonWorkSheet2()
		{
			try
			{
				repo.TestWindow.WorkSheet2Info.WaitForItemExists(1000);
				repo.TestWindow.WorkSheet2.ClickThis();
				Reports.ReportLog("ClickonWorkSheet2", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonWorkSheet2 : " + ex.Message);
			}
		}
		
		public static void ClickonCentralButton()
		{
			try
			{
				repo.EditColorsWindow.CentralInfo.WaitForItemExists(1000);
				repo.EditColorsWindow.Central.Click("33;6");
				Reports.ReportLog("ClickonCentralBuuton", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonCentralBuuton : " + ex.Message);
			}
		}
		
		public static void ClickonMeasureValue()
		{
			try
			{
				repo.EditColorWindow3.MeasureValueInfo.WaitForItemExists(1000);
				repo.EditColorWindow3.MeasureValue.ClickThis();
				Reports.ReportLog("ClickonMeasureValue", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonMeasureValue : " + ex.Message);
			}
		}
		
		public static void SelectThemeColor1()
		{
			try
			{
				repo.EditColorWindow3.ThemeDropdown1Info.WaitForItemExists(30000);
				repo.EditColorWindow3.ThemeDropdown1.Click();
				repo.SunAwtWindow.Flow.ClickThis();
				Reports.ReportLog("SelectThemeColor1", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectThemeColor1 : " + ex.Message);
			}
		}
		
		public static void CloseEditPopup1()
		{
			try
			{
				repo.EditColorWindow3.CloseInfo.WaitForItemExists(1000);
				repo.EditColorWindow3.Close.ClickThis();
				Reports.ReportLog("CloseEditPopup1", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CloseEditPopup1 : " + ex.Message);
			}
		}
		
		public static void CloseEditPopup()
		{
			try
			{
				repo.EditColorsWindow.CloseInfo.WaitForItemExists(1000);
				repo.EditColorsWindow.Close.ClickThis();
				Reports.ReportLog("CloseEditPopup", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CloseEditPopup : " + ex.Message);
			}
		}
		
		public static void CloseWorkSheet3()
		{
			try
			{
				repo.TestWindow.CloseInfo.WaitForItemExists(1000);
				repo.TestWindow.Close.ClickThis();
				Reports.ReportLog("CloseEditPopup", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CloseEditPopup : " + ex.Message);
			}
		}
		
		public static void ClickonPickScreenColor()
		{
			try
			{
				repo.EditColorsWindow.PickScreenInfo.WaitForItemExists(1000);
				repo.EditColorsWindow.PickScreen.ClickThis();
				Reports.ReportLog("ClickonPickScreenColor", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonPickScreenColor : " + ex.Message);
			}
		}
		
		public static void ValidateTestFormattingData()
		{
			try
			{
				repo.TestWindow.Self.Maximize();
				CompressedImage AssignPalette = repo.TestWindow.PivotWindowInfo.GetTestFormattingData();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.TestWindow.PivotWindowInfo;
				Validate.ContainsImage(info, AssignPalette, options, "After open test formatting data validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateTestFormattingData : " + ex.Message);
			}
		}
		
		public static void ValidateWorkSheet2()
		{
			try
			{
				CompressedImage AssignPalette = repo.TestWindow.PivotWindow2Info.GetWorkSheet2();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.TestWindow.PivotWindow2Info;
				Validate.ContainsImage(info, AssignPalette, options, "WorkSheet2 data validation", false);
				Reports.ReportLog("ValidateWorkSheet2", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateWorkSheet2 : " + ex.Message);
			}
		}
		
		public static void ValidateWorkSheet3()
		{
			try
			{
				CompressedImage AssignPalette = repo.TestWindow.PivotWindow3Info.GetWorkSheet3();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.TestWindow.PivotWindow3Info;
				Validate.ContainsImage(info, AssignPalette, options, "WorkSheet3 data validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateWorkSheet3 : " + ex.Message);
			}
		}
		
		public static void ValidateChangeColorTheme()
		{
			try
			{
				CompressedImage AssignPalette = repo.TestWindow.PivotWindow3Info.GetChangeSelectColorTheme();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.TestWindow.PivotWindow3Info;
				Validate.ContainsImage(info, AssignPalette, options, "After change the theme image validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateChangeColorTheme : " + ex.Message);
			}
		}
		
		public static void ValidateChangeColorTheme1()
		{
			try
			{
				CompressedImage AssignPalette = repo.TestWindow.PivotWindow2Info.GetChangeSelectColorTheme1();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.TestWindow.PivotWindow2Info;
				Validate.ContainsImage(info, AssignPalette, options, "After change the theme image validation", false);
				Reports.ReportLog("ValidateChangeColorTheme1", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateChangeColorTheme1 : " + ex.Message);
			}
		}
		
		public static void ValidateChangetoPieChart()
		{
			try
			{
				CompressedImage AssignPalette = repo.TestWindow.PivotWindow3Info.GetChangedtoPieChart();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.TestWindow.PivotWindow3Info;
				Validate.ContainsImage(info, AssignPalette, options, "After change to pie chart image validation", false);
				Reports.ReportLog("ValidateChangetoPieChart", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateChangetoPieChart : " + ex.Message);
			}
		}
		
		#region "TC6"
		
		public static void ValidateWorkSheet7()
		{
			try
			{
				CompressedImage AssignPalette = repo.TestWindow.PivotWindow7Info.GetWorkSheet7();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.TestWindow.PivotWindow7Info;
				Validate.ContainsImage(info, AssignPalette, options, "Check the worksheet7 image validation", false);
				Reports.ReportLog("ValidateWorkSheet7", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateWorkSheet7 : " + ex.Message);
			}
		}
		
		public static void ValidateSteppedValueChanges()
		{
			try
			{
				CompressedImage AssignPalette = repo.TestWindow.PivotWindow7Info.GetSteppedValueChanges();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.TestWindow.PivotWindow7Info;
				Validate.ContainsImage(info, AssignPalette, options, "After changes of stepped values image validation", false);
				Reports.ReportLog("ValidateSteppedValueChanges", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateSteppedValueChanges : " + ex.Message);
			}
		}
		
		public static void ValidateReversedCheckBox()
		{
			try
			{
				CompressedImage AssignPalette = repo.TestWindow.PivotWindow7Info.GetReversedCheckbox();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.TestWindow.PivotWindow7Info;
				Validate.ContainsImage(info, AssignPalette, options, "After click on Reversed Checkbox image validation", false);
				Reports.ReportLog("ValidateSteppedValueChanges", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateSteppedValueChanges : " + ex.Message);
			}
		}
		
		public static void ValidateRedGreenDivergingOption()
		{
			try
			{
				CompressedImage AssignPalette = repo.TestWindow.PivotWindow7Info.GetRedGreenDivergingOption();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.TestWindow.PivotWindow7Info;
				Validate.ContainsImage(info, AssignPalette, options, "After click on RedGreen Diverging Option image validation", false);
				Reports.ReportLog("ValidateRedGreenDivergingOption", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateRedGreenDivergingOption : " + ex.Message);
			}
		}
		
		public static void ClickonWorkSheet7()
		{
			try
			{
				repo.TestWindow.WorkSheet7Info.WaitForItemExists(3000);
				repo.TestWindow.WorkSheet7.ClickThis();
				Reports.ReportLog("ClickonWorkSheet7", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonWorkSheet7 : " + ex.Message);
			}
		}
		
		public static void CheckSteppedColor()
		{
			try
			{
				repo.EditColorWindow1.SteppedColorInfo.WaitForItemExists(30000);
				repo.EditColorWindow1.SteppedColor.ClickThis();
				Reports.ReportLog("CheckSteppedColor", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CheckSteppedColor : " + ex.Message);
			}
		}
		
		public static void SettheSteppedValue()
		{
			try
			{
				repo.EditColorWindow1.TextValue.PressKeys("{LControlKey down}{Akey}{LControlKey up}");
				repo.EditColorWindow1.TextValue.PressKeys("{NumPad0}");
				Reports.ReportLog("SettheSteppedValue", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SettheSteppedValue : " + ex.Message);
			}
		}
		
		public static void SelectYellowColor()
		{
			try
			{
				repo.EditColorWindow1.ColorThemeComboBox.ClickThis();
				repo.SunAwtWindow.Yellow.Click("22;9");
				Reports.ReportLog("SelectYellowColor", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectYellowColor : " + ex.Message);
			}
		}
		
		public static void ClickonOkayforSaleWindow()
		{
			try
			{
				repo.EditColorWindow1.OkInfo.WaitForItemExists(1000);
				repo.EditColorWindow1.Ok.ClickThis();
				Reports.ReportLog("ClickonOkayforSaleWindow", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonOkayforSaleWindow : " + ex.Message);
			}
		}
		
		public static void UnCheckSteppedColor()
		{
			try
			{
				repo.EditColorWindow1.SteppedColorInfo.WaitForItemExists(30000);
				repo.EditColorWindow1.SteppedColor.ClickThis();
				Reports.ReportLog("UnCheckSteppedColor", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : UnCheckSteppedColor : " + ex.Message);
			}
		}
		
		public static void CheckReversedBox()
		{
			try
			{
				repo.EditColorWindow1.ReversedInfo.WaitForItemExists(30000);
				repo.EditColorWindow1.Reversed.ClickThis();
				Reports.ReportLog("CheckReversedBox", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CheckReversedBox : " + ex.Message);
			}
		}
		
		public static void SelectRedGreenDiverging()
		{
			try
			{
				repo.EditColorWindow1.ColorThemeComboBoxInfo.WaitForItemExists(30000);
				repo.EditColorWindow1.ColorThemeComboBox.ClickThis();
				repo.SunAwtWindow.RedGreenDivergingInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.RedGreenDiverging.ClickThis();
				Reports.ReportLog("SelectRedGreenDiverging", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectRedGreenDiverging : " + ex.Message);
			}
		}
		
		public static void CheckFullColorRange()
		{
			try
			{
				repo.EditColorWindow1.UseFullColorRangeInfo.WaitForItemExists(30000);
				repo.EditColorWindow1.UseFullColorRange.ClickThis();
				Reports.ReportLog("CheckFullColorRange", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CheckFullColorRange : " + ex.Message);
			}
		}
		
		public static void CloseWindow()
		{
			try
			{
				if(repo.TestWindow.CloseInfo.Exists(30000))
				{
					repo.TestWindow.Close.ClickThis();
					Reports.ReportLog("CloseVAWindow", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CloseVAWindow : " + ex.Message);
			}
		}
		
		public static void CloseWindow1()
		{
			try
			{
				if(repo.TestWindow.CloseInfo.Exists(30000))
				{
					repo.TestWindow.Close.ClickThis();
					Reports.ReportLog("CloseWindow1", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}

				if(repo.SaveChanges.SelfInfo.Exists(new Duration(10000)))
					repo.SaveChanges.DiscardButton.ClickThis();
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CloseWindow1 : " + ex.Message);
			}
		}
		
		#endregion
		
		public static void ValidateShowDataLabelOption()
		{
			try
			{
				CompressedImage AssignPalette = repo.TestWindow.PivotWindow2Info.GetShowDataLabel();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.TestWindow.PivotWindow2Info;
				Validate.ContainsImage(info, AssignPalette, options, "Show data label image validation", false);
				Reports.ReportLog("ValidateShowDataLabelOption", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateShowDataLabelOption : " + ex.Message);
			}
		}
		
		public static void ValidateWorkSheet4()
		{
			try
			{
				CompressedImage AssignPalette = repo.TestWindow.PivotWindow4Info.GetWorkSheet4();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.TestWindow.PivotWindow4Info;
				Validate.ContainsImage(info, AssignPalette, options, "Show data label image validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateShowDataLabelOption : " + ex.Message);
			}
		}
		
		public static void ValidateResetOption()
		{
			try
			{
				CompressedImage AssignPalette = repo.TestWindow.PivotWindow4Info.GetResetPosition();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.TestWindow.PivotWindow4Info;
				Validate.ContainsImage(info, AssignPalette, options, "Reset Option data label image validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateShowDataLabelOption : " + ex.Message);
			}
		}
		
		public static void ValidateNeverShow()
		{
			try
			{
				CompressedImage AssignPalette = repo.TestWindow.PivotWindow4Info.GetNeverShow();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.TestWindow.PivotWindow4Info;
				Validate.ContainsImage(info, AssignPalette, options, "Never show data image validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateShowDataLabelOption : " + ex.Message);
			}
		}
		
		public static void ValidateShowLeaderLine()
		{
			try
			{
				CompressedImage AssignPalette = repo.TestWindow.PivotWindow4Info.GetShowLeaderLine();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.TestWindow.PivotWindow4Info;
				Validate.ContainsImage(info, AssignPalette, options, "Show Leader data image validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateShowLeaderLine : " + ex.Message);
			}
		}
		
		public static void ValidateHideLeaderLine()
		{
			try
			{
				CompressedImage AssignPalette = repo.TestWindow.PivotWindow4Info.GetHideLeaderLine();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.TestWindow.PivotWindow4Info;
				Validate.ContainsImage(info, AssignPalette, options, "Hide Leader data image validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateShowLeaderLine : " + ex.Message);
			}
		}
		
		public static void SelectShowVertical()
		{
			try
			{
				repo.TestWindow.JLabelInfo.WaitForItemExists(30000);
				repo.TestWindow.JLabel.ClickThis();
				repo.SunAwtWindow.ShowVertical.ClickThis();
				Reports.ReportLog("SelectShowVertical", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectShowVertical : " + ex.Message);
			}
		}
		
		public static void SelectResetPosition()
		{
			try
			{
				repo.TestWindow.ContainerCanvas.Click(System.Windows.Forms.MouseButtons.Right, "343;119");
				repo.SunAwtWindow.ResetPosition.Click("62;12");
				Reports.ReportLog("SelectResetPosition", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonCentralBuuton : " + ex.Message);
			}
		}
		
		public static void ClickonShowLeaderLine()
		{
			try
			{
				repo.TestWindow.ContainerCanvasInfo.WaitForItemExists(30000);
				repo.TestWindow.ContainerCanvas.MoveTo("271;73");
				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
				repo.TestWindow.ContainerCanvasInfo.WaitForItemExists(30000);
				repo.TestWindow.ContainerCanvas.MoveTo("324;116");
				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				repo.TestWindow.ContainerCanvasInfo.WaitForItemExists(1000);
				repo.TestWindow.ContainerCanvas.Click(System.Windows.Forms.MouseButtons.Right, "325;120");
				repo.SunAwtWindow.ShowLeaderLineInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.ShowLeaderLine.Click("46;11");
				repo.TestWindow.ContainerCanvasInfo.WaitForItemExists(30000);
				repo.TestWindow.ContainerCanvas.Click(System.Windows.Forms.MouseButtons.Right, "325;120");
				repo.SunAwtWindow.ShowLeaderLineInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.ShowLeaderLine.Click("52;13");
				Reports.ReportLog("ClickonShowLeaderLine", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonShowLeaderLine : " + ex.Message);
			}
		}
		
		public static void ClickonWorkSheet4()
		{
			try
			{
				repo.TestWindow.WorkSheet4Info.WaitForItemExists(1000);
				repo.TestWindow.WorkSheet4.ClickThis();
				Reports.ReportLog("ClickonWorkSheet4", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonWorkSheet4 : " + ex.Message);
			}
		}
		
		public static void ClickonNeverShowLabel()
		{
			try
			{
				//repo.TestWindow.BIChartOverlayPanelInfo.WaitForItemExists(30000);
				//repo.TestWindow.BIChartOverlayPanel.Click("284;75");
				repo.TestWindow.ContainerCanvas.Click(System.Windows.Forms.MouseButtons.Right, "284;75");
				repo.Datastudio2.ShowDataLabel.MoveTo("55;9");
				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
				repo.Datastudio2.ShowDataLabel.MoveTo("82;10");
				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				repo.Datastudio1.NeverShowInfo.WaitForItemExists(30000);
				repo.Datastudio1.NeverShow.ClickThis();
				Reports.ReportLog("ClickonNeverShowLabel", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonNeverShowLabel : " + ex.Message);
			}
		}
		
		public static void CLickonLabel()
		{
			try
			{
				repo.TestWindow.LabelWindow2Info.WaitForItemExists(30000);
				repo.TestWindow.LabelWindow2.ClickThis();
				Reports.ReportLog("ClickonNeverShowLabel", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonWorkSheet2 : " + ex.Message);
			}
		}
		
		public static void ShowDataLabel()
		{
			try
			{
				repo.Datastudio.ShowDataLabelsInfo.WaitForItemExists(30000);
				repo.Datastudio.ShowDataLabels.ClickThis();
				Reports.ReportLog("ShowDataLabel", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ShowDataLabel : " + ex.Message);
			}
		}
		
		
		#region "TC1"
		
		public static void ClickonWorkSheet()
		{
			try
			{
				repo.VATestWindow.WorksheetInfo.WaitForItemExists(30000);
				repo.VATestWindow.Worksheet.ClickThis();
				Reports.ReportLog("ClickonWorkSheet", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonWorkSheet : " + ex.Message);
			}
		}
		
		public static void CreateNewWorkSheet()
		{
			try
			{
				repo.SunAwtWindow.NewWorksheetInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.NewWorksheet.ClickThis();
				Reports.ReportLog("CreateNewWorkSheet", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CreateNewWorkSheet : " + ex.Message);
			}
		}
		
		public static void SelectShowTitleOption()
		{
			try
			{
				repo.SunAwtWindow.ShowTitleInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.ShowTitle.ClickThis();
				Reports.ReportLog("SelectShowTitleOption", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectShowTitleOption : " + ex.Message);
			}
		}
		
		public static void ClickonWorkSheet1()
		{
			try
			{
				repo.VATestWindow.Worksheet1Info.WaitForItemExists(30000);
				repo.VATestWindow.Worksheet1.Click();
				Reports.ReportLog("ClickonWorkSheet1", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonWorkSheet1 : " + ex.Message);
			}
		}
		
		public static void ClickonEditTitle()
		{
			try
			{
				repo.VATestWindow.Worksheet1.Click(System.Windows.Forms.MouseButtons.Right, "39;9");
				repo.SunAwtWindow.EditTitleInfo.WaitForItemExists(3000);
				repo.SunAwtWindow.EditTitle.ClickThis();
				Reports.ReportLog("ClickonEditTitle", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonEditTitle : " + ex.Message);
			}
		}
		
		public static void ModifytheName()
		{
			try
			{
				repo.EditChartTitle.CPanel.TextPane.Click("97;18");
				repo.EditChartTitle.CPanel.TextPane.PressKeys("{LControlKey down}{Akey}{LControlKey up}");
				repo.EditChartTitle.CPanel.TextPane.PressKeys("TEST{LControlKey down}{Akey}{LControlKey up}");
				repo.EditChartTitle.CPanel.ColorComboBoxButton.Click("8;13");
				repo.SunAwtWindow.AQColorChooserPanelDollarColorButton.Click("10;7");
				repo.EditChartTitle.CPanel.ButtonOK.Click("23;9");
				Reports.ReportLog("ModifytheName", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ModifytheName : " + ex.Message);
			}
		}
		
		public static void SelectResetTitleOption()
		{
			try
			{
				repo.VATestWindow.TEST.Click(System.Windows.Forms.MouseButtons.Right, "17;9");
				repo.SunAwtWindow.ResetTitle.ClickThis();
				Reports.ReportLog("SelectResetTitleOption", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectResetTitleOption : " + ex.Message);
			}
		}
		
		public static void SelectHideTitleOption()
		{
			try
			{
				repo.VATestWindow.Worksheet1.Click(System.Windows.Forms.MouseButtons.Right, "32;6");
				repo.SunAwtWindow.HideTitle.ClickThis();
				Reports.ReportLog("SelectHideTitleOption", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectHideTitleOption : " + ex.Message);
			}
		}
		
		public static void DiscardButton()
		{
			try
			{
				if(preRepo.QueryAnalyzer.TabInfo.Exists(new Duration(30000)))
				{
					Ranorex.TabPage tabPage = preRepo.QueryAnalyzer.Tab;
					Mouse.Click(tabPage,System.Windows.Forms.MouseButtons.Right, new Point(40, 10));
					
					if(preRepo.SunAwtWindow.CloseAllTabsInfo.Exists(new Duration(1000)))
					{
						preRepo.SunAwtWindow.CloseAllTabs.ClickThis();
					}
					else
					{
						preRepo.SunAwtWindow.CloseTab.ClickThis();
					}
				}
				
				if(repo.FileModified.SelfInfo.Exists(new Duration(10000)))
					repo.FileModified.Discard.ClickThis();
				
				Reports.ReportLog("DiscardButton", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DiscardButton : " + ex.Message);
			}
		}
		
		#endregion
		
		#region "TC2"
		
		
		public static void DragCardTypetoColumn()
		{
			try
			{
				repo.VATestWindow.CardTypeInfo.WaitForItemExists(30000);
				repo.VATestWindow.CardType.ClickThis();
				repo.VATestWindow.CardType.RightClick();
				repo.SunAwtWindow.AddToColumnsDeckInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.AddToColumnsDeck.ClickThis();
				Reports.ReportLog("DragCardTypetoColumn", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragCardTypetoColumn : " + ex.Message);
			}
			
		}
		
		public static void ValidateAfterDragCardtypetoColumn()
		{
			try
			{
				CompressedImage VAFiltering = repo.VATestWindow.VisulizationWindowInfo.GetDragCardtypetoColumn();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VATestWindow.VisulizationWindowInfo;
				Validate.ContainsImage(info, VAFiltering, options, "After drag Cardtype to to Column Image validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterDragCardtypetoColumn : " + ex.Message);
			}
		}
		
		public static void DragProfittoRow()
		{
			try
			{
				repo.VATestWindow.SUMProfitInfo.WaitForItemExists(30000);
				repo.VATestWindow.SUMProfit.ClickThis();
				repo.VATestWindow.SUMProfitInfo.WaitForItemExists(30000);
				repo.VATestWindow.SUMProfit.RightClick();
				repo.SunAwtWindow.AddToRowsDeckInfo.WaitForItemExists(30000);
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
				CompressedImage VAFiltering = repo.VATestWindow.VisulizationWindowInfo.GetDragProfittoRow();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VATestWindow.VisulizationWindowInfo;
				Validate.ContainsImage(info, VAFiltering, options, "After Drag Profit to Row Image validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateNewColorChart : " + ex.Message);
			}
		}
		
		public static void ClickonColorDeck()
		{
			try
			{
				System.Threading.Thread.Sleep(30000);
				repo.VATestWindow.ColorWindow2Info.WaitForItemExists(30000);
				repo.VATestWindow.ColorWindow2.ClickThis();
				repo.Datastudio.MoreColorsInfo.WaitForItemExists(30000);
				repo.Datastudio.MoreColors.ClickThis();
				Reports.ReportLog("ClickonColorDeck", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonColorDeck : " + ex.Message);
			}
			
		}
		
		public static void SelectNewColor()
		{
			try
			{
				repo.ColorStyle.SwatchPanel.MoveTo("234;38");
				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
				repo.ColorStyle.SwatchPanel.MoveTo("237;46");
				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				repo.ColorStyle.ButtonOKInfo.WaitForItemExists(30000);
				repo.ColorStyle.ButtonOK.ClickThis();
				Reports.ReportLog("ClickonColorDeck", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DiscardButton : " + ex.Message);
			}
			
		}
		
		public static void ValidateNewColorChart()
		{
			try
			{
				CompressedImage VAFiltering = repo.VATestWindow.VisulizationWindowInfo.GetNewColor();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VATestWindow.VisulizationWindowInfo;
				Validate.ContainsImage(info, VAFiltering, options, "After change to new color Image validation", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateNewColorChart : " + ex.Message);
			}
		}
		
		#endregion
	}
}
