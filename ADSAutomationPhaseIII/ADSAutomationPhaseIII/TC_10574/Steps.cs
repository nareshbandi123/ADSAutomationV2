
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

using ADSAutomationPhaseIII.Commons;
using ADSAutomationPhaseIII.Extensions;
using ADSAutomationPhaseIII.Preconditions;
using ADSAutomationPhaseIII.Configuration;

namespace ADSAutomationPhaseIII.TC_10574
{
    
    public static class Steps
    {
    	
    	public static TC10574Repo repo = TC10574Repo.Instance;
    	public static PreconditionRepo preRepo = PreconditionRepo.Instance;
    	
    	#region "TC1"
    	
    	public static void ClickOnDiscard()
		{
		
			try
			{
				repo.FileModified.DiscardInfo.WaitForItemExists(30000);
				repo.FileModified.Discard.ClickThis();
				Reports.ReportLog("ClickOnDiscard", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("ClickOnDiscard failed : " + ex.Message);
			}
		}
    	
    	public static void SelectOptions()
		{
			try 
			{
				repo.SunAwtWindow.OptionsInfo.WaitForItemExists(3000);
				repo.SunAwtWindow.Options.ClickThis();
				Reports.ReportLog("SelectOptions", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectOptions : " + ex.Message);
			}
		}
    	
    	public static void ExpandSQLEditor()
		{
			try 
			{
				repo.OptionsWindow.SQLEditorInfo.WaitForItemExists(3000);
				repo.OptionsWindow.SQLEditor.Expand();
				Reports.ReportLog("ExpandSQLEditor", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ExpandSQLEditor : " + ex.Message);
			}
		}
    	
    	public static void CollapseSQLEditor()
		{
			try 
			{
				repo.OptionsWindow.SQLEditorInfo.WaitForItemExists(3000);
				repo.OptionsWindow.SQLEditor.Collapse();
				Reports.ReportLog("ExpandSQLEditor", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ExpandSQLEditor : " + ex.Message);
			}
		}
    	
    	public static void ClickonFileMenu()
		{
			try 
			{
				repo.ServersList.FileMenuInfo.WaitForItemExists(30000);
				repo.ServersList.FileMenu.ClickThis();
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonFileMenu : " + ex.Message);	
			}
		}
    	
    	public static void ClickAbbrevations()
		{
			try 
			{
				repo.OptionsWindow.AbbrevationInfo.WaitForItemExists(3000);
				repo.OptionsWindow.Abbrevation.ClickThis();
				Reports.ReportLog("ClickAbbrevations", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickAbbrevations : " + ex.Message);
			}
		}
    	
    	public static void ClickExpandSymbol()
		{
			try 
			{
				repo.OptionsWindow.ExpandSymbolInfo.WaitForItemExists(3000);
				repo.OptionsWindow.ExpandSymbol.Click();
				Reports.ReportLog("ClickExpandSymbol", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickExpandSymbol : " + ex.Message);
			}
		}
    	
    	public static void ClickonOkayButton()
		{
			try 
			{
				repo.AbbrevationWindow.OkayButtonInfo.WaitForItemExists(3000);
				repo.AbbrevationWindow.OkayButton.ClickThis();
				Reports.ReportLog("WriteText", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonOkayButton : " + ex.Message);
			}
		}
        
    	public static void WriteSelectText()
		{
			try 
			{
				repo.AbbrevationWindow.TextBoxInfo.WaitForItemExists(3000);
				repo.AbbrevationWindow.TextBox.PressKeys("select");
				ClickonOkayButton();
				Reports.ReportLog("WriteSelectText", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : WriteSelectText : " + ex.Message);
			}
		}
    	
    	public static void WriteCreateText()
		{
			try 
			{
				repo.AbbrevationWindow.TextBoxInfo.WaitForItemExists(3000);
				repo.AbbrevationWindow.TextBox.PressKeys("create");
				ClickonOkayButton();
				Reports.ReportLog("WriteCreateText", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : WriteCreateText : " + ex.Message);
			}
		}
    	
    	public static void WriteInsertText()
		{
			try 
			{
				repo.AbbrevationWindow.TextBoxInfo.WaitForItemExists(3000);
				repo.AbbrevationWindow.TextBox.PressKeys("insert");
				ClickonOkayButton();
				Reports.ReportLog("WriteInsertText", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : WriteInsertText : " + ex.Message);
			}
		}
    	
    	public static void ClickonSelectOption()
		{
			try 
			{
				repo.OptionsWindow.SelectInfo.WaitForItemExists(3000);
				repo.OptionsWindow.Select.ClickThis();
				Reports.ReportLog("ClickonSelectOption", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonSelectOption : " + ex.Message);
			}
		}
    	
    	public static void ClickonCreateOption()
		{
			try 
			{
				repo.OptionsWindow.CreateInfo.WaitForItemExists(3000);
				repo.OptionsWindow.Create.ClickThis();
				Reports.ReportLog("ClickonCreateOption", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonCreateOption : " + ex.Message);
			}
		}
    	
    	public static void ClickonInsertOption()
		{
			try 
			{
				repo.OptionsWindow.InsertInfo.WaitForItemExists(3000);
				repo.OptionsWindow.Insert.ClickThis();
				Reports.ReportLog("ClickonCreateOption", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonCreateOption : " + ex.Message);
			}
		}
    	
    	public static void EnterSelectExpandedText()
		{
			try 
			{
				repo.OptionsWindow.ExpandedTextBoxInfo.WaitForItemExists(3000);
				repo.OptionsWindow.ExpandedTextBox.PressKeys("select * from  ads_table");
				Reports.ReportLog("EnterSelectExpandedText", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : EnterSelectExpandedText : " + ex.Message);
			}
		}
    	
    	public static void EnterCreateExpandedText()
		{
			try 
			{
				repo.OptionsWindow.ExpandedTextBoxInfo.WaitForItemExists(3000);
				repo.OptionsWindow.ExpandedTextBox.PressKeys("create table ads_table (id int, name varchar, project varchar)");
				Reports.ReportLog("EnterCreateExpandedText", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : EnterCreateExpandedText : " + ex.Message);
			}
		}
    	
    	public static void EnterInsertExpandedText()
		{
			try 
			{
				repo.OptionsWindow.ExpandedTextBoxInfo.WaitForItemExists(3000);
				repo.OptionsWindow.ExpandedTextBox.PressKeys("insert into ads_table values (4563, 'meenakshi', 'ads')");
				Reports.ReportLog("EnterInsertExpandedText", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : EnterInsertExpandedText : " + ex.Message);
			}
		}
    	
    	public static void SelectEnterinDropDown()
		{
			try 
			{
				repo.OptionsWindow.TriangleIconInfo.WaitForItemExists(3000);
				repo.OptionsWindow.TriangleIcon.ClickThis();
				repo.SunAwtWindow.EnterInfo.WaitForItemExists(3000);
				repo.SunAwtWindow.Enter.ClickThis();
				Reports.ReportLog("SelectEnterinDropDown", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectEnterinDropDown : " + ex.Message);
			}
		}
    	
    	public static void SelectTabinDropDown()
		{
			try 
			{
				repo.OptionsWindow.TriangleIconInfo.WaitForItemExists(3000);
				repo.OptionsWindow.TriangleIcon.ClickThis();
				repo.SunAwtWindow.TabInfo.WaitForItemExists(3000);
				repo.SunAwtWindow.Tab.ClickThis();
				Reports.ReportLog("SelectTabinDropDown", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : EnterExpandedText : " + ex.Message);
			}
		}
    	
    	public static void SelectSpaceinDropDown()
		{
			try 
			{
				repo.OptionsWindow.TriangleIconInfo.WaitForItemExists(3000);
				repo.OptionsWindow.TriangleIcon.ClickThis();
				repo.SunAwtWindow.SpaceInfo.WaitForItemExists(3000);
				repo.SunAwtWindow.Space.ClickThis();
				Reports.ReportLog("SelectTabinDropDown", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectTabinDropDown : " + ex.Message);
			}
		}
    	
    	public static void OkayButton()
		{
			try 
			{
				repo.OptionsWindow.OkayInfo.WaitForItemExists(3000);
				repo.OptionsWindow.Okay.ClickThis();
				Reports.ReportLog("OkayButton", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : OkayButton : " + ex.Message);
			}
		}
    	
    	public static bool ConnectServer()
		{
			try 
			{
				preRepo.ServersList.LocalDBServersTreeItemInfo.WaitForItemExists(3000);
				foreach (var item in preRepo.ServersList.LocalDBServersTreeItem.Items) 
				{	
					if(item.Text == "Amazon Redshift")
					{ 
						item.EnsureVisible();
						item.RightClick();
						Preconditions.Steps.ConnectServer();
						Preconditions.Steps.QueryAnalyser();
						break;
					}
				}
			} 
			catch (Exception) 
			{
				ConnectServer();
			}
			return true;
		}
    	
    	public static void ProvideSelectAbbreviation( string strQueryBox)
		{
			try 
			{
				repo.QuaryAnalyzerWindow.QueryBox.Click();
				repo.QuaryAnalyzerWindow.QueryBox.PressKeys(strQueryBox);
				Keyboard.Press(" ");
				Reports.ReportLog("ProvideAbbreviation", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ProvideAbbreviation : " + ex.Message);
			}
		}
    	
    	public static void ProvideInsertAbbreviation( string strQueryBox)
		{
			try 
			{
				repo.QuaryAnalyzerWindow.QueryBox.Click();
				repo.QuaryAnalyzerWindow.QueryBox.PressKeys(strQueryBox);
				Keyboard.Press("{Tab}");
				Reports.ReportLog("ProvideAbbreviation", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ProvideAbbreviation : " + ex.Message);
			}
		}
    	
    	public static void ProvideCreateAbbreviation( string strQueryBox)
		{
			try 
			{
				repo.QuaryAnalyzerWindow.QueryBox.Click();
				repo.QuaryAnalyzerWindow.QueryBox.PressKeys(strQueryBox);
				Keyboard.Press("{Return}");
				Reports.ReportLog("ProvideAbbreviation", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ProvideAbbreviation : " + ex.Message);
			}
		}
    	
    	public static void CloseOptionsWindow()
		{
			try 
			{
				repo.OptionsWindow.CloseInfo.WaitForItemExists(30000);
				repo.OptionsWindow.Close.ClickThis();
				Reports.ReportLog("CloseOptionsWindow", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CloseOptionsWindow : " + ex.Message);
			}
		}
    	
    	#endregion
    	
    	#region "TC2"
    	
    	
    	public static void ClickonRemoveIcon()
		{
			try 
			{
				repo.OptionsWindow.RemoveSymbolInfo.WaitForItemExists(3000);
				repo.OptionsWindow.RemoveSymbol.Click();
				Reports.ReportLog("ClickonRemoveIcon", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonRemoveIcon : " + ex.Message);
			}
		}
    	
    	public static void ClickonUPIcon()
		{
			try 
			{
				repo.OptionsWindow.UPIconInfo.WaitForItemExists(3000);
				repo.OptionsWindow.UPIcon.Click();
				Reports.ReportLog("ClickonUPIcon", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonUPIcon : " + ex.Message);
			}
		}
    	
    	public static void ClickonDownIcon()
		{
			try 
			{
				repo.OptionsWindow.DownIconInfo.WaitForItemExists(3000);
				repo.OptionsWindow.DownIcon.Click();
				Reports.ReportLog("ClickonDowncon", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonDowncon : " + ex.Message);
			}
		}
    	
    	#endregion
    }
}
