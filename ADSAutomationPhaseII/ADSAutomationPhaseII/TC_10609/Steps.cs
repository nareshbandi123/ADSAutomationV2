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
using ADSAutomationPhaseII.Base;
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Configuration;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Preconditions;
using ADSAutomationPhaseII.TC_10609;

namespace ADSAutomationPhaseII.TC_10609
{
	public class Steps
	{
		public static TC_10609Repo repo = TC_10609Repo.Instance;
		public static string TC_10609_Path = System.Configuration.ConfigurationManager.AppSettings["TC_10609_Path"].ToString();
		
		public static void ExplicitWait()
		{
			System.Threading.Thread.Sleep(10000);
		}
		
		public static void ClickOnBistudioExample()
		{
			try
			{
				ExapandTree(repo.AquaDataStudio.MSExcel);
				ExapandTree(repo.AquaDataStudio.Databases);
				ExapandTree(repo.AquaDataStudio.MSExcel2);
				repo.AquaDataStudio.BistudioExampleInfo.WaitForItemExists(30000);
				repo.AquaDataStudio.BistudioExample.ClickThis();
				repo.AquaDataStudio.BistudioExample.RightClick();
				repo.SubMenuItems.SchemaPropertiesInfo.WaitForItemExists(30000);
				repo.SubMenuItems.QueryAnalyzerInfo.WaitForItemExists(30000);
				repo.SubMenuItems.QueryAnalyzer.ClickThis();
				Reports.ReportLog("ClickOnBistudioExample", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickOnBistudioExample : " + ex.Message);
			}
			
		}
		
		public static void ExapandTree(Ranorex.TreeItem objTreeItem)
		{
			try
			{
				objTreeItem.MoveTo();
				objTreeItem.Element.SetAttributeValue("expanded", true);
				if(objTreeItem.Element.GetAttributeValue("expanded").ToString().Trim().ToUpper() == "FALSE")
				{
					objTreeItem.DoubleClick();
				}
				Reports.ReportLog("ExapandTree", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ExapandTree : " + ex.Message);
			}
		}
		
		public static void SelectEntireWindow()
		{
			try
			{
				repo.StandardComboInfo.WaitForItemExists(10000);
				repo.StandardCombo.Click();
				if(!repo.SubMenuItems.EntireWindowInfo.Exists(10000))
				{
					repo.StandardComboInfo.WaitForItemExists(10000);
					repo.StandardCombo.Click();
				}
				repo.SubMenuItems.EntireWindowInfo.WaitForItemExists(10000);
				repo.SubMenuItems.EntireWindow.ClickThis();
				Reports.ReportLog("SelectEntireWindow", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectEntireWindow : " + ex.Message);
			}
		}
		
		public static void CreateNewWorksheet()
		{
			try
			{
				repo.VisualAnalyticsDailog.SelfInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsDailog.WorksheetInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsDailog.Worksheet.ClickThis();
				if(repo.SubMenuItems.NewWorksheetInfo.Exists(30000)){
					repo.SubMenuItems.NewWorksheet.ClickThis();
				}else{
					repo.VisualAnalyticsDailog.Worksheet.ClickThis();
					if(repo.SubMenuItems.NewWorksheetInfo.Exists(30000)){
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
		
		
		public static void EnterQueryandClickOnExecute(string strQuery)
		{
			try
			{
				repo.AquaDataStudio.QueryEditorInfo.WaitForItemExists(30000);
				repo.AquaDataStudio.QueryEditor.MoveTo();
				Keyboard.Press(strQuery);
				repo.AquaDataStudio.ExecuteButton.ClickThis();
				Reports.ReportLog("EnterQueryandClickOnExecute", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : EnterQueryandClickOnExecute : " + ex.Message);
			}
		}
		
		public static void ClickOnNewVisualAnalyticsWBIcon()
		{
			try
			{
				repo.AquaDataStudio.NewVisualAnalyticsWBIconInfo.WaitForItemExists(50000);
				repo.AquaDataStudio.NewVisualAnalyticsWBIcon.ClickThis();
				Reports.ReportLog("EnterQueryandClickOnExecute", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickOnNewVisualAnalyticsWBIcon : " + ex.Message);
			}
		}
		
		public static void CreateParameter()
		{
			try
			{
				repo.VisualAnalyticsDailog.ParameterContainerInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsDailog.ParameterContainer.ClickThis();
				repo.VisualAnalyticsDailog.ParameterContainer.RightClick();
				repo.SubMenuItems.CreateParameterInfo.WaitForItemExists(30000);
				repo.SubMenuItems.CreateParameter.ClickThis();
				Reports.ReportLog("CreateParameter", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : CreateParameter : " + ex.Message);
			}
		}
		
		public static void CreateCalculatedfield()
		{
			try
			{
				repo.VisualAnalyticsDailog.SelfInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsDailog.ParameterContainerInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsDailog.ParameterContainer.MoveTo();
				repo.VisualAnalyticsDailog.ParameterContainer.ClickThis();
				repo.VisualAnalyticsDailog.ParameterContainer.RightClick();
				repo.SubMenuItems.CreateCalculatedFieldInfo.WaitForItemExists(30000);
				repo.SubMenuItems.CreateCalculatedField.ClickThis();
				Reports.ReportLog("CreateCalculatedfield", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : CreateCalculatedfield : " + ex.Message);
			}
		}
		
		public static void SelectAggregateFun()
		{
			try
			{
				repo.CreateCalculatedFieldDailog.FunctionFilterIconInfo.WaitForItemExists(10000);
				repo.CreateCalculatedFieldDailog.FunctionFilterIcon.ClickThis();
				repo.SubMenuItems.AggregateInfo.WaitForItemExists(10000);
				repo.SubMenuItems.Aggregate.ClickThis();
				Reports.ReportLog("SelectAggregateFun", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : SelectAggregateFun : " + ex.Message);
			}
		}
		
		public static void PeformVariousActions()
		{
			try
			{
				repo.DataStudio.AGGCalculation2Info.WaitForItemExists(10000);
				repo.DataStudio.AGGCalculation2.ClickThis();
				repo.DataStudio.AGGCalculation2.RightClickThis();
				repo.SubMenuItems.EditInfo.WaitForItemExists(30000);
				repo.SubMenuItems.Edit.ClickThis();
				repo.EditCalculatedFieldDialog.CopyIconInfo.WaitForItemExists(30000);
				repo.EditCalculatedFieldDialog.CopyIcon.Click();
				repo.EditCalculatedFieldDialog.PasteIcon.Click();
				repo.EditCalculatedFieldDialog.UndoIconInfo.WaitForItemExists(10000);
				repo.EditCalculatedFieldDialog.UndoIcon.Click();
				repo.EditCalculatedFieldDialog.RedoIconInfo.WaitForItemExists(10000);
				repo.EditCalculatedFieldDialog.RedoIcon.Click();
				repo.EditCalculatedFieldDialog.ToLowerCaseIconInfo.WaitForItemExists(10000);
				repo.EditCalculatedFieldDialog.ToLowerCaseIcon.Click();
				repo.EditCalculatedFieldDialog.ToUpperCaseIcon.Click();
				Reports.ReportLog("PeformVariousActions", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : PeformVariousActions : " + ex.Message);
			}
		}
		
		public static void FindIcon()
		{
			try
			{
				
				repo.EditCalculatedFieldDialog.FindIcon.Click();
				repo.EditCalculatedFieldDialog.FindCloseIconInfo.WaitForItemExists(30000);
				repo.EditCalculatedFieldDialog.FindCloseIcon.ClickThis();
				Reports.ReportLog("FindIcon", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : FindIcon : " + ex.Message);
			}
		}
		
		public static void ReplaceIcon()
		{
			try
			{
				
				repo.EditCalculatedFieldDialog.Replace.Click();
				repo.EditCalculatedFieldDialog.FindCloseIconInfo.WaitForItemExists(30000);
				repo.EditCalculatedFieldDialog.FindCloseIcon.ClickThis();
				Reports.ReportLog("ReplaceIcon", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ReplaceIcon : " + ex.Message);
			}
		}
		
		public static void CloseEditCalculatedFieldDialog()
		{
			try
			{
				repo.EditCalculatedFieldDialog.SelfInfo.WaitForItemExists(30000);
				repo.EditCalculatedFieldDialog.Self.Close();
				Reports.ReportLog("CloseEditCalculatedFieldDialog", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : CloseEditCalculatedFieldDialog : " + ex.Message);
			}
		}
		
		public static void SelectAggregateFunEditCalcFieldDialog()
		{
			try
			{
				repo.EditCalculatedFieldDialog.CutIconInfo.WaitForItemExists(40000);
				repo.EditCalculatedFieldDialog.CutIcon.Click();
				repo.EditCalculatedFieldDialog.FunctionFilterInfo.WaitForItemExists(30000);
				repo.EditCalculatedFieldDialog.FunctionFilter.ClickThis();
				repo.SubMenuItems.AggregateInfo.WaitForItemExists(30000);
				repo.SubMenuItems.Aggregate.ClickThis();
				Reports.ReportLog("SelectAggregateFunEditCalcFieldDialog", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : SelectAggregateFunEditCalcFieldDialog : " + ex.Message);
			}
		}
		
		public static void DoubleClickSUM()
		{
			try
			{
				repo.CreateCalculatedFieldDailog.listItemSUMInfo.WaitForItemExists(30000);
				repo.CreateCalculatedFieldDailog.listItemSUM.DoubleClick();
				Reports.ReportLog("DoubleClickSUM", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : DoubleClickSUM: " + ex.Message);
			}
		}
		
		public static void DoubleClickCOUNTD()
		{
			try
			{
				repo.EditCalculatedFieldDialog.COUNTDInfo.WaitForItemExists(30000);
				repo.EditCalculatedFieldDialog.COUNTD.DoubleClick();
				Reports.ReportLog("DoubleClickCOUNTD", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : DoubleClickCOUNTD: " + ex.Message);
			}
		}
		
		public static void DoubleClickCardType()
		{
			try
			{
				repo.EditCalculatedFieldDialog.CardTypeInfo.WaitForItemExists(30000);
				repo.EditCalculatedFieldDialog.CardType.DoubleClick();
				Reports.ReportLog("DoubleClickCardType", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : DoubleClickCardType: " + ex.Message);
			}
		}
		
		public static void DoubleClickFreight()
		{
			try
			{
				repo.CreateCalculatedFieldDailog.FreightInfo.WaitForItemExists(30000);
				repo.CreateCalculatedFieldDailog.Freight.DoubleClick();
				Reports.ReportLog("DoubleClickFreight", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : DoubleClickFreight: " + ex.Message);
			}
		}
		
		public static void DoubleClickSave()
		{
			try
			{
				repo.CreateCalculatedFieldDailog.SaveInfo.WaitForItemExists(30000);
				repo.CreateCalculatedFieldDailog.Save.ClickThis();
				if(repo.CreateCalculatedFieldDailog.SaveInfo.Exists(5000))
				{
					repo.CreateCalculatedFieldDailog.Save.ClickThis();
				}
				Reports.ReportLog("DoubleClickSave", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : DoubleClickSave: " + ex.Message);
			}
		}
		
		public static void DoubleClickSaveEditCalcFieldDialog()
		{
			try
			{
				repo.EditCalculatedFieldDialog.SaveInfo.WaitForItemExists(30000);
				repo.EditCalculatedFieldDialog.Save.ClickThis();
				if(repo.EditCalculatedFieldDialog.SaveInfo.Exists(5000))
				{
					repo.EditCalculatedFieldDialog.Save.ClickThis();
				}
				Reports.ReportLog("DoubleClickSaveEditCalcFieldDialog", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : DoubleClickSaveEditCalcFieldDialog: " + ex.Message);
			}
		}
		
		public static void CreateParameterSetParam(string strParamName, string strTooolTipVal, string strDtType)
		{
			try
			{
				repo.CreateParameterDailog.SelfInfo.WaitForItemExists(30000);
				repo.CreateParameterDailog.ParamName.TextBoxText(strParamName);
				repo.CreateParameterDailog.Tooltip.ClickThis();
				repo.CreateParameterDailog.txtToolTip.TextBoxText(strTooolTipVal);
				repo.CreateParameterDailog.cmbDataType.SetElementSelectedItemTextProperty(strDtType);
				repo.CreateParameterDailog.rbAll.ClickThis();
				repo.CreateParameterDailog.Save.ClickThis();
				Reports.ReportLog("CreateParameterSetParam", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : CreateParameterSetParam : " + ex.Message);
			}
		}
		
		public static void DragCustomerNameToColumnsDeck()
		{
			try{
				repo.VisualAnalyticsDailog.ContainerContentPanel.CustomerNameInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsDailog.ContainerContentPanel.CustomerName.ClickThis();
				repo.VisualAnalyticsDailog.ContainerContentPanel.CustomerName.RightClickThis();
				repo.SubMenuItems.AddToColumnsDeckInfo.WaitForItemExists(30000);
				repo.SubMenuItems.AddToColumnsDeck.ClickThis();
				Reports.ReportLog("DragCustomerNameToColumnsDeck", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}catch (Exception ex)
			{
				throw new Exception("Failed : DragCustomerNameToColumnsDeck" +ex.Message);
			}
		}
		
		public static void DragCardTypeToColumnsDeck()
		{
			try{
				repo.VisualAnalyticsDailog.ContainerContentPanel.CardTypeInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsDailog.ContainerContentPanel.CardType.ClickThis();
				repo.VisualAnalyticsDailog.ContainerContentPanel.CardType.RightClickThis();
				repo.SubMenuItems.AddToColumnsDeckInfo.WaitForItemExists(30000);
				repo.SubMenuItems.AddToColumnsDeck.ClickThis();
				Reports.ReportLog("DragCardTypeToColumnsDeck", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}catch (Exception ex)
			{
				throw new Exception("Failed : DragCardTypeToColumnsDeck" +ex.Message);
			}
		}
		
		public static void DragProfitToRowsDeck()
		{
			try{
				repo.VisualAnalyticsDailog.ContainerContentPanel.SUMProfitInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsDailog.ContainerContentPanel.SUMProfit.ClickThis();
				repo.VisualAnalyticsDailog.ContainerContentPanel.SUMProfit.RightClickThis();
				repo.SubMenuItems.AddToRowsDeckInfo.WaitForItemExists(30000);
				repo.SubMenuItems.AddToRowsDeck.ClickThis();
				Reports.ReportLog("DragProfitToRowsDeck", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragProfitToRowsDeck" +ex.Message);
			}
		}
		
		public static void DragFreightToRowsDeck()
		{
			try{
				repo.VisualAnalyticsDailog.ContainerContentPanel.FreightInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsDailog.ContainerContentPanel.Freight.ClickThis();
				repo.VisualAnalyticsDailog.ContainerContentPanel.Freight.RightClickThis();
				repo.SubMenuItems.AddToRowsDeckInfo.WaitForItemExists(30000);
				repo.SubMenuItems.AddToRowsDeck.ClickThis();
				Reports.ReportLog("DragFreightToRowsDeck", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragFreightToRowsDeck" +ex.Message);
			}
		}
		
		public static void DragAggCalculator1ToRowsDeck()
		{
			try{
				Thread.Sleep(4000);
				repo.VisualAnalyticsDailog.ContainerContentPanel.AggCalculation1Info.WaitForItemExists(30000);
				repo.VisualAnalyticsDailog.ContainerContentPanel.AggCalculation1.ClickThis();
				repo.VisualAnalyticsDailog.ContainerContentPanel.AggCalculation1.RightClickThis();
				repo.SubMenuItems.AddToRowsDeckInfo.WaitForItemExists(30000);
				repo.SubMenuItems.AddToRowsDeck.ClickThis();
				Reports.ReportLog("DragCalculator1ToRowsDeck", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragCalculator1ToRowsDeck" +ex.Message);
			}
		}
		
		public static void AggCalculator1AndEdit()
		{
			try{
				repo.VisualAnalyticsDailog.ContainerContentPanel.AggCalculation1Info.WaitForItemExists(30000);
				repo.VisualAnalyticsDailog.ContainerContentPanel.AggCalculation1.ClickThis();
				repo.VisualAnalyticsDailog.ContainerContentPanel.AggCalculation1.RightClickThis();
				if(!repo.SubMenuItems.EditInfo.Exists(30000))
				{
					repo.VisualAnalyticsDailog.ContainerContentPanel.AggCalculation1.ClickThis();
					repo.VisualAnalyticsDailog.ContainerContentPanel.AggCalculation1.RightClickThis();
				}
				repo.SubMenuItems.EditInfo.WaitForItemExists(30000);
				repo.SubMenuItems.Edit.ClickThis();
				Reports.ReportLog("AggCalculator1AndEdit", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : AggCalculator1AndEdit" +ex.Message);
			}
		}
		
		public static void RenameAggCalculator1(string strRename)
		{
			try{
				repo.VisualAnalyticsDailog.ContainerContentPanel.AggCalculation1Info.WaitForItemExists(30000);
				repo.VisualAnalyticsDailog.ContainerContentPanel.AggCalculation1.RightClickThis();
				if(!repo.SubMenuItems.RenameInfo.Exists(30000))
				{
					repo.VisualAnalyticsDailog.ContainerContentPanel.AggCalculation1Info.WaitForItemExists(30000);
					repo.VisualAnalyticsDailog.ContainerContentPanel.AggCalculation1.RightClickThis();
				}
				repo.SubMenuItems.RenameInfo.WaitForItemExists(30000);
				repo.SubMenuItems.Rename.ClickThis();
				repo.RenameFieldDialog.txtReNameInfo.WaitForItemExists(30000);
				repo.RenameFieldDialog.txtReName.TextBoxText(strRename);
				repo.RenameFieldDialog.RenameButt.ClickThis();
				Reports.ReportLog("RenameAggCalculator1", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : RenameAggCalculator1" +ex.Message);
			}
		}
		
		public static void VerifyRenamedCalculator(string strRename)
		{
			try{
				repo.varRename = strRename;
				repo.VisualAnalyticsDailog.SelfInfo.WaitForItemExists(30000);
				if(repo.VisualAnalyticsDailog.ContainerContentPanel.RenameCalcInfo.Exists())
				{
					Report.Success("'"+strRename+"' is Added Successfully to Measures After Rename");
				}else{
					Report.Error("'"+strRename+"' is not Added to Measures After Rename");
				}
				
				Reports.ReportLog("VerifyRenamedCalculator", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : VerifyRenamedCalculator" +ex.Message);
			}
		}
		
		public static void DragParameterToRowsDeck()
		{
			try
			{
				ExplicitWait();
				repo.VisualAnalyticsDailog.ContainerContentPanel.Parameter1Info.WaitForItemExists(30000);
				repo.VisualAnalyticsDailog.ContainerContentPanel.Parameter1.ClickThis();
				repo.VisualAnalyticsDailog.ContainerContentPanel.Parameter1.RightClickThis();
				repo.SubMenuItems.AddToRowsDeckInfo.WaitForItemExists(30000);
				repo.SubMenuItems.AddToRowsDeck.ClickThis();
				Reports.ReportLog("DragParameterToRowsDeck", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragParameterToRowsDeck" +ex.Message);
			}
		}
		
		
		public static void EditParameter1SetParam(string strDtType, string strClickAddVal)
		{
			try
			{
				repo.VisualAnalyticsDailog.ContainerContentPanel.Parameter1Info.WaitForItemExists(10000);
				repo.VisualAnalyticsDailog.ContainerContentPanel.Parameter1.ClickThis();
				repo.VisualAnalyticsDailog.ContainerContentPanel.Parameter1.RightClickThis();
				repo.SubMenuItems.EditInfo.WaitForItemExists(10000);
				repo.SubMenuItems.Edit.ClickThis();
				repo.EditParameter.SelfInfo.WaitForItemExists(10000);
				repo.EditParameter.Tooltip.ClickThis();
				repo.EditParameter.cmbDataType.ClickThis();
				repo.SubMenuItems.IntegerInfo.WaitForItemExists(5000);
				repo.SubMenuItems.Integer.ClickThis();
				Thread.Sleep(3000);
				repo.EditParameter.ListInfo.WaitForItemExists(5000);
				repo.EditParameter.List.ClickThis();
				Thread.Sleep(2000);
				repo.EditParameter.clickToAdd.ClickThis();
				Keyboard.Press(strClickAddVal);
				Thread.Sleep(2000);
				repo.EditParameter.PasteFromClipboard.ClickThis();
				Reports.ReportLog("EditParameter1SetParam", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : EditParameter1SetParam" +ex.Message);
			}
		}
		
		public static void CloseEditParameterDialog()
		{
			try
			{				
				if(repo.EditParameter.SelfInfo.Exists(5000))
				{
					repo.EditParameter.Self.Close();
				}
				Reports.ReportLog("CloseEditParameterDialog", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CloseEditParameterDialog" +ex.Message);
			}
		}
		
		public static void DtTimeEditParameter1SetParam(string strDtType)
		{
			try
			{
				ExplicitWait();
				repo.VisualAnalyticsDailog.ContainerContentPanel.Parameter1Info.WaitForItemExists(30000);
				repo.VisualAnalyticsDailog.ContainerContentPanel.Parameter1.ClickThis();
				repo.VisualAnalyticsDailog.ContainerContentPanel.Parameter1.RightClickThis();
				repo.SubMenuItems.EditInfo.WaitForItemExists(30000);
				repo.SubMenuItems.Edit.ClickThis();
				repo.EditParameter.TooltipInfo.WaitForItemExists(30000);
				repo.EditParameter.Tooltip.ClickThis();
				repo.EditParameter.cmbDataType.ClickThis();  //SetElementSelectedItemTextProperty(strDtType);
				repo.SubMenuItems.DtTime.ClickThis();
				Thread.Sleep(1000);
				repo.EditParameter.ContentPanel.Range.ClickThis();
				Reports.ReportLog("DtTimeEditParameter1SetParam", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DtTimeEditParameter1SetParam" +ex.Message);
			}
		}
		
		public static void PasteDataSetParam()
		{
			try
			{
				if(repo.PasteDataDailog.DelimeterInfo.Exists(5000))
				{
					repo.PasteDataDailog.DelimeterInfo.WaitForItemExists(10000);
					repo.PasteDataDailog.Delimeter.ClickThis();
					repo.SubMenuItems.ListItemTabExcelInfo.WaitForItemExists(10000);
					repo.SubMenuItems.ListItemTabExcel.ClickThis();
					repo.PasteDataDailog.StringQuotedIdentifierInfo.WaitForItemExists(10000);
					repo.PasteDataDailog.StringQuotedIdentifier.ClickThis();
					repo.SubMenuItems.ListItemNoneInfo.WaitForItemExists(10000);
					repo.SubMenuItems.ListItemNone.ClickThis();
					repo.PasteDataDailog.EncodingInfo.WaitForItemExists(10000);
					repo.PasteDataDailog.Encoding.ClickThis();
					repo.SubMenuItems.ListItemDefaultInfo.WaitForItemExists(10000);
					repo.SubMenuItems.ListItemDefault.ClickThis();
					repo.PasteDataDailog.CbFirstRowInfo.WaitForItemExists(10000);
					repo.PasteDataDailog.CbFirstRow.CheckboxCheck();
					repo.PasteDataDailog.Paste.ClickThis();
				}
				else
				{
					Keyboard.Press("{Return}");
				}				
				Reports.ReportLog("PasteDataSetParam", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : PasteDataSetParam" +ex.Message);
			}
		}
		
		public static void ClickOnSaveButtEditParameter1Dailog()
		{
			try
			{
				repo.EditParameter.SaveInfo.WaitForItemExists(30000);
				repo.EditParameter.Save.ClickThis();
				Reports.ReportLog("ClickOnSaveButtEditParameter1Dailog", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnSaveButtEditParameter1Dailog" +ex.Message);
			}
		}
		
		public static void ValidateEditPaste18()
		{
			try
			{
				repo.VisualAnalyticsDailog.ContainerCanvasInfo.WaitForItemExists(30000);
				CompressedImage VAFiltering = repo.VisualAnalyticsDailog.ContainerCanvasInfo.GetGetScreenshot29();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.50f;
				RepoItemInfo info = repo.VisualAnalyticsDailog.ContainerCanvasInfo;
				Validate.ContainsImage(info, VAFiltering, options, "ValidateEditPaste18", false);

			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateEditPaste18" +ex.Message);
			}
		}
		
		public static void ValidateEditPaste29()
		{
			try
			{
				CompressedImage VAFiltering = repo.VisualAnalyticsDailog.ContainerCanvasInfo.GetGetScreenshot29();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.25f;
				RepoItemInfo info = repo.VisualAnalyticsDailog.ContainerCanvasInfo;
				Validate.ContainsImage(info, VAFiltering, options, "ValidateEditPaste29", false);

			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateEditPaste29" +ex.Message);
			}
		}
		
		public static void ValidateEditPaste24()
		{
			try
			{
				repo.VisualAnalyticsDailog.ContainerCanvasInfo.WaitForItemExists(30000);
				CompressedImage VAFiltering = repo.VisualAnalyticsDailog.ContainerCanvasInfo.GetScreen1_24();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalyticsDailog.ContainerCanvasInfo;
				Validate.ContainsImage(info, VAFiltering, options, "ValidateEditPaste24", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateEditPaste24" +ex.Message);
			}
		}
		
		public static void ValidateMyFields()
		{
			try
			{
				CompressedImage VAFiltering = repo.VisualAnalyticsDailog.PivotTableOverlayPanelInfo.GetScreenshot1();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalyticsDailog.PivotTableOverlayPanelInfo;
				Validate.ContainsImage(info, VAFiltering, options, "ValidateMyFields", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateMyFields" +ex.Message);
			}
		}
		
		public static void ValidateProductCategoryShipMethodCombined()
		{
			try
			{
				repo.VisualAnalyticsDailog.ContainerCanvasInfo.WaitForItemExists(30000);
				CompressedImage VAFiltering = repo.VisualAnalyticsDailog.ContainerCanvasInfo.GetProductCategoryShipMethodCombined();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.50f;
				RepoItemInfo info = repo.VisualAnalyticsDailog.ContainerCanvasInfo;
				Validate.ContainsImage(info, VAFiltering, options, "ValidateProductCategoryShipMethodCombined", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateProductCategoryShipMethodCombined" +ex.Message);
			}
		}
		
		public static void ValidateTC4_Step12()
		{
			try
			{
				repo.VisualAnalyticsDailog.ContainerCanvasInfo.WaitForItemExists(30000);
				CompressedImage VAFiltering = repo.VisualAnalyticsDailog.ContainerCanvasInfo.GetScreenshot_4_12();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalyticsDailog.ContainerCanvasInfo;
				Validate.ContainsImage(info, VAFiltering, options, "ValidateTC4_Step12", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateTC4_Step12" +ex.Message);
			}
		}
		
		public static void ValidateCalc1Drag()
		{
			try
			{
				Thread.Sleep(4000);
				CompressedImage VAFiltering = repo.VisualAnalyticsDailog.ContainerCanvasInfo.GetScreenshot2_12();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalyticsDailog.ContainerCanvasInfo;
				Validate.ContainsImage(info, VAFiltering, options, "ValidateCalc1Drag", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateCalc1Drag" +ex.Message);
			}
		}
		
		public static void ValidateCalc2_15()
		{
			try
			{
				Thread.Sleep(5000);
				CompressedImage VAFiltering = repo.VisualAnalyticsDailog.ContainerCanvasInfo.GetScreen2_15();
				Imaging.FindOptions options = Imaging.FindOptions.Default;
				options.Similarity = 0.75f;
				RepoItemInfo info = repo.VisualAnalyticsDailog.ContainerCanvasInfo;
				Validate.ContainsImage(info, VAFiltering, options, "ValidateCalc2_15", false);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateCalc2_15" +ex.Message);
			}
		}
		
		public static void VerifyTodayDate()
		{
			try
			{
				if(repo.EditParameter.ContentPanel.Minimum.Element.GetAttributeValue("caption").ToString().Trim().Contains(System.DateTime.Now.ToString("M/d/yyyy")) ||repo.EditParameter.ContentPanel.Minimum.Element.GetAttributeValue("caption").ToString().Trim().Contains(System.DateTime.Now.ToString("M/dd/yyyy")))
				{
					Report.Success("Minimum Filed Value "+repo.EditParameter.ContentPanel.Minimum.Element.GetAttributeValue("caption").ToString()+" is Matched with Today Date "+System.DateTime.Now.ToString("M/d/yyyy")+"");
				}
				if(repo.EditParameter.ContentPanel.Maximum.Element.GetAttributeValue("caption").ToString().Trim().Contains(System.DateTime.Now.ToString("M/d/yyyy")) || repo.EditParameter.ContentPanel.Maximum.Element.GetAttributeValue("caption").ToString().Trim().Contains(System.DateTime.Now.ToString("M/dd/yyyy")))
				{
					Report.Success("Maximum Filed Value is Matched with Today Date");
				}
				Reports.ReportLog("VerifyTodayDate", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : VerifyTodayDate" +ex.Message);
			}
		}
		
		public static void ClickonAnyOptionandSaveButton()
		{
			try
			{
				repo.EditParameter.ContentPanel.StepSizeInfo.WaitForItemExists(30000);
				repo.EditParameter.ContentPanel.StepSize.TextBoxText("1");
				repo.EditParameter.ContentPanel.UnitCombo.ClickThis();
				repo.SubMenuItems.Years.ClickThis();
				repo.EditParameter.Save.ClickThis();
				if(repo.EditParameter.SelfInfo.Exists(5000))
				{
					repo.EditParameter.Self.Close();
				}
				Reports.ReportLog("ClickonAnyOptionandSaveButton", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonAnyOptionandSaveButton" +ex.Message);
			}
		}
		
		public static void ShowParameterControl()
		{
			try
			{
				repo.VisualAnalyticsDailog.ContainerContentPanel.Parameter1Info.WaitForItemExists(30000);
				repo.VisualAnalyticsDailog.ContainerContentPanel.Parameter1.RightClickThis();
				repo.SubMenuItems.ShowParameterControlInfo.WaitForItemExists(30000);
				repo.SubMenuItems.ShowParameterControl.ClickThis();
				if(repo.VisualAnalyticsDailog.ContainerContentPanel.Param1TriangleInfo.Exists(30000)){
					repo.VisualAnalyticsDailog.ContainerContentPanel.Param1Triangle.Focus();
					repo.VisualAnalyticsDailog.ContainerContentPanel.Param1TriangleInfo.WaitForItemExists(30000);
					repo.VisualAnalyticsDailog.ContainerContentPanel.Param1Triangle.MoveTo();
					repo.VisualAnalyticsDailog.ContainerContentPanel.Param1Triangle.ClickThis();
					repo.SubMenuItems.EditInfo.WaitForItemExists(30000);
					repo.SubMenuItems.Edit.ClickThis();
					repo.EditParameter.cmbDataTypeInfo.WaitForItemExists(30000);
					repo.EditParameter.cmbDataType.ClickThis();
					repo.SubMenuItems.Integer.ClickThis();
					repo.EditParameter.ContentPanel.RadioButtonAll.ClickThis();
					repo.EditParameter.Save.ClickThis();
				}
				Reports.ReportLog("ShowParameterControl", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ShowParameterControl" +ex.Message);
			}
		}
		
		public static void ChangedToDtTime()
		{
			try
			{
				if(repo.VisualAnalyticsDailog.ContainerContentPanel.Param1TriangleInfo.Exists(5000))
				{
					repo.VisualAnalyticsDailog.ContainerContentPanel.Param1TriangleInfo.WaitForItemExists(30000);
					repo.VisualAnalyticsDailog.ContainerContentPanel.Param1Triangle.MoveTo();
					repo.VisualAnalyticsDailog.ContainerContentPanel.Param1Triangle.ClickThis();
					repo.SubMenuItems.EditInfo.WaitForItemExists(30000);
					repo.SubMenuItems.Edit.ClickThis();
					repo.EditParameter.cmbDataTypeInfo.WaitForItemExists(30000);
					repo.EditParameter.cmbDataType.ClickThis();
					repo.SubMenuItems.DtTime.ClickThis();
					repo.EditParameter.ContentPanel.RadioButtonAll.ClickThis();
					repo.EditParameter.Save.ClickThis();
				}
				Reports.ReportLog("ChangedToDtTime", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ChangedToDtTime" +ex.Message);
			}
		}
		
		public static void DuplicateParameter()
		{
			try
			{
				repo.VisualAnalyticsDailog.ContainerContentPanel.Parameter1Info.WaitForItemExists(30000);
				repo.VisualAnalyticsDailog.ContainerContentPanel.Parameter1.RightClickThis();
				repo.SubMenuItems.DuplicateInfo.WaitForItemExists(30000);
				repo.SubMenuItems.Duplicate.ClickThis();
				Reports.ReportLog("DuplicateParameter", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}catch (Exception ex)
			{
				throw new Exception("Failed : DuplicateParameter" +ex.Message);
			}
		}
		
		public static void RenameParameter(string strRename)
		{
			try
			{
				repo.VisualAnalyticsDailog.ContainerContentPanel.Parameter1Info.WaitForItemExists(30000);
				repo.VisualAnalyticsDailog.ContainerContentPanel.Parameter1.RightClickThis();
				repo.SubMenuItems.RenameInfo.WaitForItemExists(30000);
				repo.SubMenuItems.Rename.ClickThis();
				repo.RenameFieldDialog.txtReName.TextBoxText(strRename);
				repo.RenameFieldDialog.RenameButt.ClickThis();
				Reports.ReportLog("RenameParameter", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : RenameParameter" +ex.Message);
			}
		}
		
		public static void Deleteparameter23()
		{
			try
			{
				repo.VisualAnalyticsDailog.ContainerContentPanel.Parameter23Info.WaitForItemExists(30000);
				repo.VisualAnalyticsDailog.ContainerContentPanel.Parameter23.RightClickThis();
				repo.SubMenuItems.DeleteInfo.WaitForItemExists(30000);
				repo.SubMenuItems.Delete.MoveTo();
				repo.SubMenuItems.Delete.ClickThis();
				repo.DeleteField.ButtonYesInfo.WaitForItemExists(30000);
				repo.DeleteField.ButtonYes.ClickThis();
				Reports.ReportLog("Deleteparameter23", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : Deleteparameter23" +ex.Message);
			}
		}
		
		public static void CreateCalculatedFieldParameter()
		{
			try
			{
				repo.VisualAnalyticsDailog.ContainerContentPanel.CustomerNameInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsDailog.ContainerContentPanel.CustomerName.ClickThis();
				repo.VisualAnalyticsDailog.ContainerContentPanel.Parameter1Info.WaitForItemExists(30000);
				repo.VisualAnalyticsDailog.ContainerContentPanel.Parameter1.MoveTo();
				repo.VisualAnalyticsDailog.ContainerContentPanel.Parameter1.RightClickThis();
				repo.SubMenuItems.CreateCalculatedFieldInfo.WaitForItemExists(30000);
				repo.SubMenuItems.CreateCalculatedField.ClickThis();
				Reports.ReportLog("CreateCalculatedFieldParameter", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}catch (Exception ex)
			{
				throw new Exception("Failed : CreateCalculatedFieldParameter" +ex.Message);
			}
		}
		
		public static void GiveCalSaveCreateCalculatedFieldDailog(string strCalName)
		{
			try
			{
				repo.CreateCalculatedFieldDailog.NameTxtInfo.WaitForItemExists(30000);
				repo.CreateCalculatedFieldDailog.NameTxt.TextBoxText(strCalName);
				repo.CreateCalculatedFieldDailog.Save.ClickThis();
				Reports.ReportLog("GiveCalSaveCreateCalculatedFieldDailog", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}catch (Exception ex)
			{
				throw new Exception("Failed : GiveCalSaveCreateCalculatedFieldDailog" +ex.Message);
			}
		}
		
		public static void DeleteCalculator1FromMeasures()
		{
			try
			{
				repo.VisualAnalyticsDailog.ContainerContentPanel.Calculation1Info.WaitForItemExists(30000);
				repo.VisualAnalyticsDailog.ContainerContentPanel.Calculation1.MoveTo();
				repo.VisualAnalyticsDailog.ContainerContentPanel.Calculation1.ClickThis();
				repo.VisualAnalyticsDailog.ContainerContentPanel.Calculation1.RightClickThis();
				repo.SubMenuItems.DeleteInfo.WaitForItemExists(30000);
				repo.SubMenuItems.Delete.ClickThis();
				Reports.ReportLog("DeleteCalculator1FromMeasures", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DeleteCalculator1FromMeasures" +ex.Message);
			}
		}
		
		public static void CloseVisualAnalyticsDailog()
		{
			try{
				
				if(repo.VisualAnalyticsDailog.SelfInfo.Exists(new Duration(30000)))
				{
					repo.VisualAnalyticsDailog.Self.Close();
					if(repo.SaveChanges.SelfInfo.Exists(new Duration(30000)))
						repo.SaveChanges.DiscardButton.ClickThis();
					Reports.ReportLog("CloseVisualAnalyticsDailog", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CloseVisualAnalyticsDailog" +ex.Message);
			}
		}
		
		public static void CloseOpenedTabs()
		{
			try
			{
				if(repo.AquaDataStudio.TabPageMSExcelInfo.Exists(30000))
				{
					repo.AquaDataStudio.TabPageMSExcelInfo.WaitForItemExists(30000);
					repo.AquaDataStudio.TabPageMSExcel.RightClickThis();
					ExplicitWait();
					repo.SubMenuItems.CloseInfo.WaitForItemExists(30000);
					repo.SubMenuItems.Close.ClickThis();
					repo.DataStudio.DiscardInfo.WaitForItemExists(30000);
					repo.DataStudio.Discard.ClickThis();
					Reports.ReportLog("CloseOpenedTabs", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CloseOpenedTabs" +ex.Message);
			}
		}
		
		public static void ClickOnFileAndOpenMenus()
		{
			try
			{
				repo.AquaDataStudio.FileMenuInfo.WaitForItemExists(30000);
				if(repo.AquaDataStudio.FileMenuInfo.Exists(30000))
				{
					repo.AquaDataStudio.FileMenu.ClickThis();
					Reports.ReportLog("ClickOnFileAndOpenMenus", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
					if(repo.SubMenuItems.OpenInfo.Exists(30000))
					{
						repo.SubMenuItems.Open.ClickThis();
						Reports.ReportLog("ClickOnFileAndOpenMenus", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
					}
					else
					{
						repo.AquaDataStudio.FileMenu.ClickThis();
						if(repo.SubMenuItems.OpenInfo.Exists(30000))
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
				repo.Open.OpenTextInfo.WaitForItemExists(20000);
				repo.Open.OpenText.TextBoxText(TC_10609_Path + "test-split.vizx");
				repo.Open.OpenButton.ClickThis();
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
				ExplicitWait();
				repo.OpeningWbDialog.SelfInfo.WaitForNotExists(30000);
				repo.VisualAnalyticsDailog.SelfInfo.WaitForItemExists(20000);
				repo.VisualAnalyticsDailog.Self.Maximize();
				Reports.ReportLog("MaximizeVisualAnalyticsWindow", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : MaximizeVisualAnalyticsWindow" +ex.Message);
			}
		}
		
		public static void SplitMyField(string strSplitBy)
		{
			try
			{
				repo.VisualAnalyticsDailog.ContainerContentPanel.MyFieldInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsDailog.ContainerContentPanel.MyField.RightClickThis();
				MenuItem split = @"/form/?/?/menuitem[@text='Split...']";
				if(split!= null)
				{
//					repo.SubMenuItems.SplitInfo.WaitForNotExists(30000);
//					repo.SubMenuItems.Split.MoveTo();
//					repo.SubMenuItems.Split.ClickThis();
					split.ClickThis();
					repo.SplitMyFieldDialog.SeparatorInfo.WaitForItemExists(30000);
					repo.SplitMyFieldDialog.Separator.TextBoxText(strSplitBy);
					repo.SplitMyFieldDialog.SplitButt.ClickThis();
					repo.SplitMyFieldDialog.SelfInfo.WaitForNotExists(10000);
					Reports.ReportLog("SplitMyField", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					throw new Exception("Failed : SplitMyField Element not found");
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SplitMyField" +ex.Message);
			}
		}
		
		public static void VerifySplitMyField()
		{
			try
			{
				if(repo.VisualAnalyticsDailog.ContainerContentPanel.MyFieldSplit1Info.Exists(5000))
				{
					Report.Success("'MyField - Split 1' is Found in 'Dimensions' area After spliting 'MyField' by ';'");
				}
				else
				{
					Report.Error("'MyField - Split 1' is Not Found in 'Dimensions' area After spliting 'MyField' by ';'");
				}
				if(repo.VisualAnalyticsDailog.ContainerContentPanel.MyFieldSplit2Info.Exists(5000))
				{
					Report.Success("'MyField - Split 2' is Found in 'Dimensions' area After spliting 'MyField' by ';'");
				}
				else
				{
					Report.Error("'MyField - Split 2' is Not Found in 'Dimensions' area After spliting 'MyField' by ';'");
				}
				Reports.ReportLog("VerifySplitMyField", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : VerifySplitMyField" +ex.Message);
			}
		}
		
		public static void VerifyMyFieldAfrerUndo()
		{
			try
			{
				repo.VisualAnalyticsDailog.UndoButtInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsDailog.UndoButt.ClickThis();
				if(repo.VisualAnalyticsDailog.ContainerContentPanel.MyFieldSplit1Info.Exists(5000))
				{
					Report.Error("'MyField - Split 1' is should not present in 'Dimensions' Pane after 'Undo'");
				}
				else
				{
					Report.Success("'MyField - Split 1' is not Found in 'Dimensions' area after 'Undo' as per expectations");
				}
				if(repo.VisualAnalyticsDailog.ContainerContentPanel.MyFieldSplit2Info.Exists(5000))
				{
					Report.Error("'MyField - Split 2' is should not present in 'Dimensions' Pane after 'Undo'");
				}
				else
				{
					Report.Success("'MyField - Split 1' is not Found in 'Dimensions' Pane after 'Undo' as per expectations");
				}
				Reports.ReportLog("VerifyMyFieldAfrerUndo", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : VerifyMyFieldAfrerUndo" +ex.Message);
			}
		}
		
		public static void VerifyMyFieldAfrerRedo()
		{
			try
			{
				repo.VisualAnalyticsDailog.RedoButInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsDailog.RedoBut.ClickThis();
				if(repo.VisualAnalyticsDailog.ContainerContentPanel.MyFieldSplit1Info.Exists(5000))
				{
					Report.Success("'MyField - Split 1' is present in 'Dimensions' Pane after 'Redo'");
				}
				else
				{
					Report.Error("'MyField - Split 1' is should present in 'Dimensions' area after 'Redo' as per expectations");
				}
				if(repo.VisualAnalyticsDailog.ContainerContentPanel.MyFieldSplit2Info.Exists(5000))
				{
					Report.Success("'MyField - Split 2' is present in 'Dimensions' Pane after 'Redo'");
				}
				else
				{
					Report.Error("'MyField - Split 1' is present in 'Dimensions' Pane after 'Redo' as per expectations");
				}
				Reports.ReportLog("VerifyMyFieldAfrerRedo", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : VerifyMyFieldAfrerRedo" +ex.Message);
			}
		}
		
		public static void DragMyFieldSplit1ToColumnsDeck()
		{
			try
			{
				repo.VisualAnalyticsDailog.ContainerContentPanel.MyFieldSplit1Info.WaitForItemExists(30000);
				repo.VisualAnalyticsDailog.ContainerContentPanel.MyFieldSplit1.ClickThis();
				repo.VisualAnalyticsDailog.ContainerContentPanel.MyFieldSplit1.RightClickThis();
				repo.SubMenuItems.AddToColumnsDeck.ClickThis();
				Reports.ReportLog("DragMyFieldSplit1ToColumnsDeck", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragMyFieldSplit1ToColumnsDeck" +ex.Message);
			}
		}
		
		public static void DragProductCategoryShipMethodCombinedToColumnsDeck()
		{
			try
			{
				repo.VisualAnalyticsDailog.ContainerContentPanel.ProductCategoryShipMethodCombinedInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsDailog.ContainerContentPanel.ProductCategoryShipMethodCombined.ClickThis();
				repo.VisualAnalyticsDailog.ContainerContentPanel.ProductCategoryShipMethodCombined.RightClickThis();
				repo.SubMenuItems.AddToColumnsDeckInfo.WaitForItemExists(30000);
				repo.SubMenuItems.AddToColumnsDeck.ClickThis();
				Reports.ReportLog("DragProductCategoryShipMethodCombinedToColumnsDeck", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragProductCategoryShipMethodCombinedToColumnsDeck" +ex.Message);
			}
		}
		
		public static void DuplicateProductCategoryShipMethodCombined()
		{
			try
			{
				repo.VisualAnalyticsDailog.ContainerContentPanel.ProductCategoryShipMethodCombinedInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsDailog.ContainerContentPanel.ProductCategoryShipMethodCombined.ClickThis();
				repo.VisualAnalyticsDailog.ContainerContentPanel.ProductCategoryShipMethodCombined.RightClickThis();
				repo.SubMenuItems.DuplicateInfo.WaitForItemExists(30000);
				repo.SubMenuItems.Duplicate.ClickThis();
				Reports.ReportLog("DuplicateProductCategoryShipMethodCombined", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DuplicateProductCategoryShipMethodCombined" +ex.Message);
			}
		}
		
		public static void DragMyFieldSplit2ToRowsDeck()
		{
			try
			{
				repo.VisualAnalyticsDailog.ContainerContentPanel.MyFieldSplit2Info.WaitForItemExists(30000);
				repo.VisualAnalyticsDailog.ContainerContentPanel.MyFieldSplit2.ClickThis();
				repo.VisualAnalyticsDailog.ContainerContentPanel.MyFieldSplit2.RightClickThis();
				repo.SubMenuItems.AddToRowsDeck.ClickThis();
				Reports.ReportLog("DragMyFieldSplit2ToRowsDeck", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragMyFieldSplit2ToRowsDeck" +ex.Message);
			}
		}
		
		public static void DragTotalDueToRowsDeck()
		{
			try
			{
				repo.VisualAnalyticsDailog.ContainerContentPanel.SUMTotalDueInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsDailog.ContainerContentPanel.SUMTotalDue.ClickThis();
				repo.VisualAnalyticsDailog.ContainerContentPanel.SUMTotalDue.RightClickThis();
				repo.SubMenuItems.AddToRowsDeckInfo.WaitForItemExists(30000);
				repo.SubMenuItems.AddToRowsDeck.ClickThis();
				Reports.ReportLog("DragTotalDueToRowsDeck", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragTotalDueToRowsDeck" +ex.Message);
			}
		}
		
		public static void CombineProductCategoryAndShipMethod()
		{
			try
			{
				repo.DataStudio.BIDraggableList1.ProductCategoryInfo.WaitForItemExists(30000);
				repo.DataStudio.BIDraggableList1.ProductCategory.ClickThis();
				repo.DataStudio.BIDraggableList1.ProductCategory.PressKeys("{LControlKey down}");
				repo.DataStudio.BIDraggableList1.ShipMethod.ClickThis();
//				repo.DataStudio.BIDraggableList1.BIDraggableList.PressKeys("{LControlKey up}");
				repo.DataStudio.BIDraggableList1.ShipMethod.Click(System.Windows.Forms.MouseButtons.Right);
				repo.SubMenuItems.CreateCombinedFieldInfo.WaitForItemExists(30000);
				repo.SubMenuItems.CreateCombinedField.ClickThis();
				Keyboard.Press("{LControlKey up}");
				Reports.ReportLog("CombineProductCategoryAndShipMethod", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CombineProductCategoryAndShipMethod" +ex.Message);
			}
		}
		
		public static void SaveCreateConbinedFieldDialog()
		{
			try
			{
				repo.CreateCombinedField.SelfInfo.WaitForItemExists(30000);
				string strObjName = repo.CreateCombinedField.CPanel.NameTextField.Element.GetAttributeValue("text").ToString().Trim();
				if(strObjName.Contains("Product Category & Ship Method (Combined)"))
				{
					Report.Success("'Product Category & Ship Method (Combined)' is matched with '"+strObjName+"' on Create Conbined Field Dialog");
				}
				else
				{
					Report.Error("'Product Category & Ship Method (Combined)' is not matched with '"+strObjName+"' on Create Conbined Field Dialog");
				}
				repo.CreateCombinedField.CPanel.txtSeparator.TextBoxText(",");
				repo.CreateCombinedField.CPanel.Save.ClickThis();
				Reports.ReportLog("SaveCreateConbinedFieldDialog", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SaveCreateConbinedFieldDialog" +ex.Message);
			}
		}
		
		public static void EditProductCategoryShipMethodCombined()
		{
			try
			{
				repo.VisualAnalyticsDailog.ContainerContentPanel.ProductCategoryShipMethodCombinedInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsDailog.ContainerContentPanel.ProductCategoryShipMethodCombined.RightClickThis();
				repo.SubMenuItems.EditInfo.WaitForItemExists(30000);
				repo.SubMenuItems.Edit.ClickThis();
				repo.EditCombinedField.SelfInfo.WaitForItemExists(30000);
				repo.EditCombinedField.txtSepartor.TextBoxText(",");
				repo.EditCombinedField.Save.ClickThis();
				Reports.ReportLog("EditProductCategoryShipMethodCombined", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : EditProductCategoryShipMethodCombined" +ex.Message);
			}
		}
		
		public static void RenameDuplicateCombined(string strRename)
		{
			try
			{
				repo.VisualAnalyticsDailog.ContainerContentPanel.ProductCategoryShipMethodCombinedInfo.WaitForItemExists(30000);
				repo.VisualAnalyticsDailog.ContainerContentPanel.ProductCategoryShipMethodCombined.RightClickThis();
				repo.SubMenuItems.RenameInfo.WaitForItemExists(30000);
				repo.SubMenuItems.Rename.ClickThis();
				repo.RenameFieldDialog.txtReNameInfo.WaitForItemExists(30000);
				repo.RenameFieldDialog.txtReName.TextBoxText(strRename);
				repo.RenameFieldDialog.RenameButt.ClickThis();
				repo.VisualAnalyticsDailog.ContainerContentPanel.Combined23Info.WaitForItemExists(30000);
				if(repo.VisualAnalyticsDailog.ContainerContentPanel.Combined23Info.Exists())
				{
					Report.Success("Renamed 'Product category &  ship method (combined)23' Found");
				}
				else
				{
					Report.Error("Renamed 'Product category &  ship method (combined)23' not Found");
				}
				Reports.ReportLog("RenameDuplicateCombined", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : RenameDuplicateCombined" +ex.Message);
			}
		}
		
		public static void DeleteDuplicateCombined()
		{
			try
			{
				repo.VisualAnalyticsDailog.ContainerContentPanel.Combined23Info.WaitForItemExists(30000);
				repo.VisualAnalyticsDailog.ContainerContentPanel.Combined23.RightClickThis();
				repo.SubMenuItems.DeleteInfo.WaitForItemExists(30000);
				repo.SubMenuItems.Delete.ClickThis();
				repo.DeleteField.ButtonYesInfo.WaitForItemExists(3000);
				repo.DeleteField.ButtonYes.ClickThis();
				repo.VisualAnalyticsDailog.ContainerContentPanel.SelfInfo.WaitForItemExists(30000);
				if(repo.VisualAnalyticsDailog.ContainerContentPanel.Combined23Info.Exists(8000))
				{
					Report.Error("Renamed 'Product category &  ship method (combined)23' is should not be present after deleted");
				}
				else
				{
					Report.Success("Renamed 'Product category &  ship method (combined)23' not Found as per requirement");
				}
				Reports.ReportLog("DeleteDuplicateCombined", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DeleteDuplicateCombined" +ex.Message);
			}
		}
		
		
	}
}
