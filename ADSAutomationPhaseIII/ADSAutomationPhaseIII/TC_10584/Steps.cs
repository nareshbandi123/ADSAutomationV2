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
using Ranorex.Core.Repository;
using Ranorex.Core.Testing;

namespace ADSAutomationPhaseIII.TC_10584
{
	
	public static class Steps
	{
		public static TC10584_Repo repo = TC10584_Repo.Instance;
		public static int waittime = 10000;
		
		public static void RightClickLocalDatabaseConnect()
		{
			try
			{
				repo.AquaDataStudio.LocalServersList.AmazonRedshiftInfo.WaitForItemExists(waittime);
				repo.AquaDataStudio.LocalServersList.AmazonRedshift.RightClickThis();
				repo.Datastudio.ConnectInfo.WaitForItemExists(waittime);
				repo.Datastudio.Connect.ClickThis();
				Thread.Sleep(5000);
				
				Reports.ReportLog("RightClickLocalDatabase", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : RightClickLocalDatabase : " + ex.Message);
			}
		}
		
		public static void RightClickLocalDatabasefailed()
		{
			try
			{
				repo.AquaDataStudio.LocalServersList.HiveClouderaHiveServerInfo.WaitForItemExists(waittime);
				repo.AquaDataStudio.LocalServersList.HiveClouderaHiveServer.RightClickThis();
				repo.Datastudio.ConnectInfo.WaitForItemExists(waittime);
				repo.Datastudio.Connect.ClickThis();
				
				Reports.ReportLog("RightClickLocalDatabasefailed", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : RightClickLocalDatabasefailed : " + ex.Message);
			}
		}
		
		public static void VerifyFailedDatabase()
		{
			try
			{
				repo.AquaDataStudio.LocalServersList.ErrorHiveCloudServerInfo.WaitForItemExists(30000);
				repo.AquaDataStudio.LocalServersList.ErrorHiveCloudServer.EnsureVisible();
				
				Reports.ReportLog("VerifyFailedDatabase", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : VerifyFailedDatabase : " + ex.Message);
			}
		}
		
		public static void VerifyItemsSchemaBrowserTitlePanelBar()
		{
			try
			{
				repo.AquaDataStudio.LocalServersList.SchemaBrowserTitlePanelBar.RightClick();
				Validate.Exists(repo.Datastudio.PinnedMode);
				Validate.Exists(repo.Datastudio.DockedMode);
				Validate.Exists(repo.Datastudio.FloatingMode);
				Validate.Exists(repo.Datastudio.Hide);
				Validate.Exists(repo.Datastudio.MoveTo);
				Validate.Exists(repo.Datastudio.MaximizePanel);
				Validate.Exists(repo.Datastudio.SplitMode);
				Reports.ReportLog("VerifyItemsSchemaBrowserTitlePanelBar", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : VerifyItemsSchemaBrowserTitlePanelBar : " + ex.Message);
			}
		}
		
		public static void ClickonMaximizePanel()
		{
			try
			{
				repo.AquaDataStudio.LocalServersList.SchemaBrowserTitlePanelBar.RightClick();
				repo.Datastudio.MaximizePanelInfo.WaitForItemExists(waittime);
				repo.Datastudio.MaximizePanel.ClickThis();
				
				repo.AquaDataStudio.LocalServersList.SchemaBrowserTitlePanelBar.RightClick();
				repo.Datastudio.RestorePanelSizeInfo.WaitForItemExists(waittime);
				repo.Datastudio.RestorePanelSize.ClickThis();
				
				Reports.ReportLog("ClickonMaximizePanel", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonMaximizePanel : " + ex.Message);
			}
		}
		
		public static void OpenServerQueryAnalyzer()
		{
			try
			{
				repo.AquaDataStudio.LocalServersList.AmazonRedshiftInfo.WaitForItemExists(waittime);
				repo.AquaDataStudio.LocalServersList.AmazonRedshift.RightClickThis();
				repo.Datastudio.AmazonServerQueryAnalyzerInfo.WaitForItemExists(waittime);
				repo.Datastudio.AmazonServerQueryAnalyzer.ClickThis();
				repo.AquaDataStudio_Additional.MyLayeredPane.AutoCompleteButtonInfo.WaitForItemExists(10000);
				
				Reports.ReportLog("OpenServerQueryAnalyzer", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : OpenServerQueryAnalyzer : " + ex.Message);
			}
		}
		
		public static void RightclickunselectPinnedmodeoption()
		{
			try
			{
				repo.AquaDataStudio_Additional.MyLayeredPane.SchemaBrowserTitlePanelQueryanalyserInfo.WaitForItemExists(waittime);
				repo.AquaDataStudio_Additional.MyLayeredPane.SchemaBrowserTitlePanelQueryanalyser.RightClick();
				repo.Datastudio.PinnedModeInfo.WaitForItemExists(waittime);
				repo.Datastudio.PinnedMode.ClickThis();
				
				Reports.ReportLog("RightclickunselectPinnedmodeoption", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : RightclickunselectPinnedmodeoption : " + ex.Message);
			}
		}
		
		public static void ClickonAnalyzertwice()
		{
			try
			{
				repo.AquaDataStudio_Additional.MyLayeredPane.QueryAnalyserNameInfo.WaitForItemExists(waittime);
				repo.AquaDataStudio_Additional.MyLayeredPane.QueryAnalyserName.ClickThis();
				//double click to default screen
				repo.AquaDataStudio_Additional.MyLayeredPane.QueryAnalyserNameInfo.WaitForItemExists(waittime);
				repo.AquaDataStudio_Additional.MyLayeredPane.QueryAnalyserName.DoubleClick();
				
				Reports.ReportLog("ClickonAnalyzertwice", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonAnalyzertwice : " + ex.Message);
			}
		}
		
		public static void RightclickSelectFloatingoption()
		{
			try
			{
				repo.AquaDataStudio_Additional.MyLayeredPane.SchemaBrowserDockedModeInfo.WaitForItemExists(waittime);
				repo.AquaDataStudio_Additional.MyLayeredPane.SchemaBrowserDockedMode.RightClick();
				
				repo.Datastudio.FloatingModeInfo.WaitForItemExists(waittime);
				repo.Datastudio.FloatingMode.ClickThis();
				
				repo.Servers.ServersToolbarPanelInfo.WaitForItemExists(waittime);
				repo.Servers.ServersToolbarPanel.RightClick();
				
				repo.Datastudio.FloatingModeInfo.WaitForItemExists(waittime);
				repo.Datastudio.FloatingMode.ClickThis();
				
				Reports.ReportLog("RightclickSelectFloatingoption", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : RightclickSelectFloatingoption : " + ex.Message);
			}
		}
		
		public static void RightclickSelectDockedModeoption()
		{
			try
			{
				repo.AquaDataStudio_Additional.MyLayeredPane.SchemaBrowserDockedModeInfo.WaitForItemExists(waittime);
				repo.AquaDataStudio_Additional.MyLayeredPane.SchemaBrowserDockedMode.RightClick();
				
				repo.Datastudio.DockedModeInfo.WaitForItemExists(waittime);
				repo.Datastudio.DockedMode.ClickThis();
				
				repo.AquaDataStudio_Additional.MyLayeredPane.SchemaBrowserDockedModeInfo.WaitForItemExists(waittime);
				repo.AquaDataStudio_Additional.MyLayeredPane.SchemaBrowserDockedMode.RightClick();
				
				repo.Datastudio.FloatingModeInfo.WaitForItemExists(waittime);
				repo.Datastudio.FloatingMode.ClickThis();
				
				repo.Servers.ServersToolbarPanelInfo.WaitForItemExists(waittime);
				repo.Servers.ServersToolbarPanel.RightClick();
				
				repo.Datastudio.FloatingModeInfo.WaitForItemExists(waittime);
				repo.Datastudio.FloatingMode.ClickThis();
				
				
				Reports.ReportLog("RightclickSelectDockedModeoption", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : RightclickSelectDockedModeoption : " + ex.Message);
			}
		}
		
		public static void RightclickSelectSplitmode()
		{
			try
			{
				repo.AquaDataStudio_Additional.MyLayeredPane.SchemaBrowserDockedModeInfo.WaitForItemExists(waittime);
				repo.AquaDataStudio_Additional.MyLayeredPane.SchemaBrowserDockedMode.RightClick();
				
				repo.Datastudio.DockedModeInfo.WaitForItemExists(waittime);
				repo.Datastudio.DockedMode.ClickThis();
				
				repo.AquaDataStudio_Additional.MyLayeredPane.SchemaBrowserTitlePanelQueryanalyserInfo.WaitForItemExists(waittime);
				repo.AquaDataStudio_Additional.MyLayeredPane.SchemaBrowserTitlePanelQueryanalyser.RightClick();
				
				repo.Datastudio.SplitModeInfo.WaitForItemExists(waittime);
				repo.Datastudio.SplitMode.ClickThis();
				
				Reports.ReportLog("RightclickSelectDockedModeoption", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : RightclickSelectDockedModeoption : " + ex.Message);
			}
		}
		
		public static void RightclickSelectandclickonMoveTo()
		{
			try
			{
				repo.AquaDataStudio_Additional.MyLayeredPane.SchemaBrowserDockedMode.RightClick();
				repo.Datastudio.DockedModeInfo.WaitForItemExists(waittime);
				repo.Datastudio.DockedMode.ClickThis();
				
				repo.AquaDataStudio_Additional.MyLayeredPane.SchemaBrowserDockedMode.RightClick();
				repo.Datastudio.MoveToInfo.WaitForItemExists(waittime);
				repo.Datastudio.MoveTo.ClickThis();
				repo.Datastudio.TopInfo.WaitForItemExists(waittime);
				repo.Datastudio.Top.ClickThis();
				
				repo.AquaDataStudio_Additional.MyLayeredPane.SchemaBrowserDockedMode.RightClick();
				repo.Datastudio.MoveToInfo.WaitForItemExists(waittime);
				repo.Datastudio.MoveTo.ClickThis();
				repo.Datastudio.BottomInfo.WaitForItemExists(waittime);
				repo.Datastudio.Bottom.ClickThis();
				
				repo.AquaDataStudio_Additional.MyLayeredPane.SchemaBrowserDockedMode.RightClick();
				repo.Datastudio.MoveToInfo.WaitForItemExists(waittime);
				repo.Datastudio.MoveTo.ClickThis();
				repo.Datastudio.RightInfo.WaitForItemExists(waittime);
				repo.Datastudio.Right.ClickThis();
				
				
				repo.AquaDataStudio_Additional.MyLayeredPane.SchemaBrowserDockedMode.RightClick();
				repo.Datastudio.MoveToInfo.WaitForItemExists(waittime);
				repo.Datastudio.MoveTo.ClickThis();
				repo.Datastudio.LeftInfo.WaitForItemExists(waittime);
				repo.Datastudio.Left.ClickThis();
				
				Reports.ReportLog("RightclickSelectandclickonMoveTo", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : RightclickSelectandclickonMoveTo : " + ex.Message);
			}
			
		}
		
		public static void RightclickSelectHideOptionAndF1()
		{
			try
			{
				repo.AquaDataStudio_Additional.MyLayeredPane.SchemaBrowserDockedMode.RightClick();
				repo.Datastudio.HideInfo.WaitForItemExists(waittime);
				repo.Datastudio.Hide.ClickThis();
				
				repo.AquaDataStudio_Additional.F1ServersInfo.WaitForItemExists(waittime);
				repo.AquaDataStudio_Additional.F1Servers.ClickThis();
				
				repo.AquaDataStudio_Additional.MyLayeredPane.SchemaBrowserDockedMode.RightClick();
				repo.Datastudio.DockedMode.ClickThis();
				
				Reports.ReportLog("RightclickSelectHideOptionAndF1", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : RightclickSelectHideOptionAndF1 : " + ex.Message);
			}
		}
		
		public static void ClickonHorizontalAndVerticalScrollbar()
		{
			try
			{
				repo.AquaDataStudio_Additional.MyLayeredPane.HorizontalScrollBar.Click();
				repo.AquaDataStudio_Additional.MyLayeredPane.VerticalScrollBar.Click();
				
				Reports.ReportLog("ClickonHorizontalAndVerticalScrollbar", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonHorizontalAndVerticalScrollbar : " + ex.Message);
			}
		}
		
		public static void ClickonF5Details()
		{
			try
			{
				repo.AquaDataStudio_Additional.F5DetailInfo.WaitForItemExists(waittime);
				repo.AquaDataStudio_Additional.F5Detail.ClickThis();
				repo.AquaDataStudio_Additional.F5DetailInfo.WaitForItemExists(waittime);
				repo.AquaDataStudio_Additional.F5Detail.ClickThis();
				
				repo.AquaDataStudio_Additional.F1ServersInfo.WaitForItemExists(30000);
				repo.AquaDataStudio_Additional.F1Servers.Click();
				
				repo.AquaDataStudio_Additional.MyLayeredPane.SchemaBrowserTitlePanelQueryanalyserInfo.WaitForItemExists(waittime);
				repo.AquaDataStudio_Additional.MyLayeredPane.SchemaBrowserTitlePanelQueryanalyser.RightClick();
				
				repo.Datastudio.SplitModeInfo.WaitForItemExists(waittime);
				repo.Datastudio.SplitMode.ClickThis();
				
				repo.AquaDataStudio_Additional.MyLayeredPane.SchemaBrowserTitlePanelQueryanalyserInfo.WaitForItemExists(waittime);
				repo.AquaDataStudio_Additional.MyLayeredPane.SchemaBrowserTitlePanelQueryanalyser.RightClick();
				
				repo.Datastudio.PinnedModeInfo.WaitForItemExists(waittime);
				repo.Datastudio.PinnedMode.ClickThis();
					
				Reports.ReportLog("ClickonF5Details", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonF5Details : " + ex.Message);
			}
		}
		
		public static void CreatenewServerGroup()
		{
			try
			{
				//repo.AquaDataStudio_Additional.MyLayeredPane.VerticalScrollBar.Click();
				repo.AquaDataStudio_Additional.MyLayeredPane.LocalDatabaseServers.RightClickThis();
				repo.Datastudio.NewServerGroupInfo.WaitForItemExists(waittime);
				repo.Datastudio.NewServerGroup.ClickThis();
				repo.NewServerGroup.OptionPaneTextField.PressKeys("NewGroup");
				repo.NewServerGroup.ButtonOK.ClickThis();
				
				Reports.ReportLog("CreatenewServerGroup", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CreatenewServerGroup : " + ex.Message);
			}
		}
		
		public static void DragdropServerServergroup()
		{
			try
			{
				
				repo.AquaDataStudio_Additional.MyFirstComponent.HiveClouderaImpala10901163513.Click("81;4");
				repo.AquaDataStudio_Additional.MyFirstComponent.HiveClouderaImpala10901163513.MoveTo("79;5");
				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
				repo.AquaDataStudio_Additional.MyFirstComponent.HiveClouderaImpala10901163513.MoveTo("87;-3");
				repo.AquaDataStudio_Additional.MyFirstComponent.NewGroup.MoveTo("61;8");
				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				repo.AquaDataStudio_Additional.MyFirstComponent.SchemaTree.Click("46;41");
				repo.AquaDataStudio_Additional.MyFirstComponent.DB2ZOS1928633139V12.MoveTo("29;6");
				Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
				repo.AquaDataStudio_Additional.MyFirstComponent.DB2ZOS1928633139V12.MoveTo("37;-2");
				repo.AquaDataStudio_Additional.MyFirstComponent.LocalDatabaseServers.MoveTo("71;10");
				Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				
				Reports.ReportLog("DragdropServerServergroup", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragdropServerServergroup : " + ex.Message);
			}
		}
		
		public static void DeleteWorkgroup()
		{
			try
			{
				repo.AquaDataStudio_Additional.MyFirstComponent.NewGroup.RightClickThis();
				repo.Datastudio.DeleteServerGroupInfo.WaitForItemExists(waittime);
				repo.Datastudio.DeleteServerGroup.ClickThis();
				repo.RemoveServerGroup.DeleteworkgroupYesbuttonInfo.WaitForItemExists(waittime);
				repo.RemoveServerGroup.DeleteworkgroupYesbutton.ClickThis();
				
				Reports.ReportLog("DeleteWorkgroup", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DeleteWorkgroup : " + ex.Message);
			}
		}
		
		public static void 	ClickInformixServer()
		{
			try
			{
				repo.AquaDataStudio_Additional.MyFirstComponent.InformixServer12_5.EnsureVisible();
				repo.AquaDataStudio_Additional.MyFirstComponent.InformixServer12_5.RightClickThis();
				repo.Datastudio.ConnectInfo.WaitForItemExists(waittime);
				repo.Datastudio.Connect.ClickThis();
				//repo.AquaDataStudio_Additional.MyFirstComponent.Informix_DatabasesInfo.WaitForItemExists(waittime);
				
					Validate.Exists(repo.AquaDataStudio_Additional.MyFirstComponent.Informix_Databases);
					Validate.Exists(repo.AquaDataStudio_Additional.MyFirstComponent.Informix_Storage);
					Validate.Exists(repo.AquaDataStudio_Additional.MyFirstComponent.Informix_Management);
				
				Reports.ReportLog("ClickInformixServer", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickInformixServer : " + ex.Message);
			}
		}
		
		public static void 	ClickOracleServer()
		{
			try
			{
				repo.AquaDataStudio_Additional.MyFirstComponent.OracleServer199.EnsureVisible();
				repo.AquaDataStudio_Additional.MyFirstComponent.OracleServer199.RightClickThis();
				repo.Datastudio.ConnectInfo.WaitForItemExists(waittime);
				repo.Datastudio.Connect.ClickThis();
				
				repo.AquaDataStudio_Additional.MyFirstComponent.MySchemaInfo.WaitForItemExists(waittime);
				
				Validate.Exists(repo.AquaDataStudio_Additional.MyFirstComponent.MySchema);
				Validate.Exists(repo.AquaDataStudio_Additional.MyFirstComponent.Storage);
				Validate.Exists(repo.AquaDataStudio_Additional.MyFirstComponent.Management);
				
				Reports.ReportLog("ClickOracleServer", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOracleServer : " + ex.Message);
			}
		}
		
		public static void ClickonSQLServer()
		{
			try
			{
				repo.AquaDataStudio_Additional.MyFirstComponent.SQLServer1722411542017.EnsureVisible();
				repo.AquaDataStudio_Additional.MyFirstComponent.SQLServer1722411542017.RightClickThis();
				repo.Datastudio.Connect.ClickThis();
				Validate.Exists(repo.AquaDataStudio_Additional.MyFirstComponent.SQLServerManagement);
				repo.AquaDataStudio_Additional.MyFirstComponent.ToolWindowHeaderDollar1.RightClick();
				
				repo.Datastudio.PinnedModeInfo.WaitForItemExists(waittime);
				repo.Datastudio.PinnedMode.ClickThis();
				
				Reports.ReportLog("ClickonSQLServer", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonSQLServer : " + ex.Message);
			}
		}
		
		public static void CloseAnalyserwindow()
		{
			try
			{
				repo.AquaDataStudio_Additional.MyLayeredPane.QueryAnalyserNameInfo.WaitForItemExists(waittime);
				repo.AquaDataStudio_Additional.MyLayeredPane.QueryAnalyserName.RightClickThis();
				repo.Datastudio.Close.ClickThis();
				
				Reports.ReportLog("CloseAnalyserwindow", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CloseAnalyserwindow : " + ex.Message);
			}
		}
		
		public static void ClickOnF1Servers()
		{
			try
			{
				repo.AquaDataStudio_Additional.F1ServersInfo.WaitForItemExists(30000);
				repo.AquaDataStudio_Additional.F1Servers.Click();
				
				Reports.ReportLog("ClickOnF1Servers", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnF1Servers : " + ex.Message);
			}
		}
		
		public static void ClickOnF1ServersOpen()
		{
			try
			{
				repo.AquaDataStudio.F1ServersInfo.WaitForItemExists(30000);
				repo.AquaDataStudio.F1Servers.ClickThis();
				
				Reports.ReportLog("ClickOnF1ServersOpen", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnF1ServersOpen : " + ex.Message);
			}
		}
	}
}
