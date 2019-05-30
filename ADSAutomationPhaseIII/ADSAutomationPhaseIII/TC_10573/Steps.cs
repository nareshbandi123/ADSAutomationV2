
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

using WinForms = System.Windows.Forms;
using ADSAutomationPhaseIII.Commons;
using ADSAutomationPhaseIII.Configuration;
using ADSAutomationPhaseIII.Extensions;
using ADSAutomationPhaseIII.Preconditions;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace ADSAutomationPhaseIII.TC_10573
{
   
    public static class Steps
    {
        public static TC10573Repo repo = TC10573Repo.Instance;
        public static PreconditionRepo preRepo = PreconditionRepo.Instance;
        
        public static bool ConnectServer()
		{
			try 
			{
				preRepo.ServersList.LocalDBServersTreeItemInfo.WaitForItemExists(3000);
				foreach (var item in preRepo.ServersList.LocalDBServersTreeItem.Items) 
				{	
					if(item.Text == "MongoDB 172.24.1.155 v3.4.1")
					{ 
						item.EnsureVisible();
						item.RightClick();
						Preconditions.Steps.ConnectServer();
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
        
        public static bool DisConnectServer()
		{
			try 
			{
				preRepo.ServersList.LocalDBServersTreeItemInfo.WaitForItemExists(3000);
				foreach (var item in preRepo.ServersList.LocalDBServersTreeItem.Items) 
				{	
					if(item.Text == "MongoDB 172.24.1.155 v3.4.1")
					{ 
						item.EnsureVisible();
						item.RightClick();
						Preconditions.Steps.DisconnectServer();
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
    	
    	public static void SelectMongoJS()
		{
			try 
			{
				repo.ServersList.MongoDBInfo.WaitForItemExists(5000);
				repo.ServersList.MongoDB.ClickThis();
				repo.ServersList.MongoDB.RightClickThis();
				System.Threading.Thread.Sleep(1000);
				repo.DataStudio.MongoJSInfo.WaitForItemExists(5000);
				repo.DataStudio.MongoJS.ClickThis();
				Reports.ReportLog("SelectMongoJS", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectMongoJS : " + ex.Message);
			}
		}
    	
    	public static void SelectMongoShell()
		{
			try 
			{
				repo.ServersList.MongoDBInfo.WaitForItemExists(5000);
				repo.ServersList.MongoDB.ClickThis();
				repo.ServersList.MongoDB.RightClickThis();
				repo.DataStudio.Self.EnsureVisible();
				repo.DataStudio.MongoShellInfo.WaitForItemExists(5000);
				repo.DataStudio.MongoShell.ClickThis();
				Reports.ReportLog("ClickonFileMenu", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonFileMenu : " + ex.Message);
			}
		}
    	
    	public static void ProvideCommands( string strQueryBox)
		{
			try 
			{
				repo.QueryWindow.QueryBoxInfo.WaitForItemExists(30000);
				repo.QueryWindow.QueryBox.Click();
				repo.QueryWindow.QueryBox.PressKeys(strQueryBox);
				Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Keyboard.Press(Keyboard.ToKey("Ctrl+E"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Reports.ReportLog("ProvideCommands", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ProvideCommands : " + ex.Message);
			}
		}
    	
    	public static void ProvideNewCommand()
		{
			try 
			{
				repo.QueryWindow.NewInfo.WaitForItemExists(5000);
				repo.QueryWindow.New.ClickThis();
				repo.FileModified.DiscardButtonInfo.WaitForItemExists(5000);
				repo.FileModified.DiscardButton.ClickThis();
				Reports.ReportLog("ProvideNewCommand", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ProvideNewCommand : " + ex.Message);
			}
		}
    	
    	public static void ProvideFluidShellCommands( string strQueryBox)
		{
			try 
			{
				ExplicitWait();
				repo.ServersList.FluidShellWindowInfo.WaitForItemExists(10000);
				repo.ServersList.FluidShellWindow.PressKeys(strQueryBox);
				Keyboard.Press("{ENTER}");
				Reports.ReportLog("ProvideFluidShellCommands", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ProvideCommands : " + ex.Message);
			}
		}
    	
    	public static void ExplicitWait()
    	{
    		System.Threading.Thread.Sleep(2000);
    	}
    	
    	public static void CloseQuaryAnalyzerTab()
		{
			try 
			{
				Preconditions.Steps.CloseTab("");
				if(repo.FileModified.SelfInfo.Exists())
				   repo.FileModified.DiscardButton.ClickThis();
				Reports.ReportLog("CloseQuaryAnalyzerTab", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CloseQuaryAnalyzerTab : " + ex.Message);
			}
		}
    }
    
}
