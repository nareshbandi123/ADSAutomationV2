using System;
using Ranorex;

using ADSAutomationPhaseII.TC_10538;
using ADSAutomationPhaseII.TC_10547;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Preconditions;
using ADSAutomationPhaseII.Configuration;
using ADSAutomationPhaseII.Commons;

namespace ADSAutomationPhaseII.TC_10597
{
	public static class Steps
	{
		public static TC10597Repo repo = TC10597Repo.Instance;
		public static TC10538 tc10538Repo = TC10538.Instance;
		public static PreconditionRepo preRepo = PreconditionRepo.Instance;
		public static string MSEXCEL_PATH = System.Configuration.ConfigurationManager.AppSettings["MSEXCEL_PATH"].ToString();
		
		public static void Connect_MSExcel_Server()
		{
			try 
			{
				TreeItem server = Preconditions.Steps.GetServerTreeFromTCName(ServerListConstants.Excel);
        		Preconditions.Steps.CloseTab(server.Text);  
	      		Preconditions.Steps.SelectedServerTreeItem = server;
	      		Preconditions.Steps.SelectedServerName = server.Text;
        		//Preconditions.Steps.ConnectServer();
        		Reports.ReportLog("Connect_MSExcel_Server", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			} 
			catch (Exception ex) 
			{
				throw new Exception("Failed : Connect_MSExcel_Server : " + ex.Message);
			}
		}
		
		public static void ExecuteQuery()
		{
			try 
			{
        		Preconditions.Steps.QueryAnalyser();
        		Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
        		
				tc10538Repo.UntitledApplication.QATextEditorInfo.WaitForItemExists(10000);
				tc10538Repo.UntitledApplication.QATextEditor.Click();
				string query = "select * from stockprices";
				tc10538Repo.UntitledApplication.QATextEditor.PressKeys(query);
				Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);	
				Preconditions.Steps.ClickQARun();
				Reports.ReportLog("ExecuteQuery", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			} 
			catch (Exception ex) 
			{
				throw new Exception("Failed : ExecuteQuery : " + ex.Message);
			}
		}
		
		public static void ConnectServerstock()
		{
			try
			{
				preRepo.ServersList.LocalDBServersTreeItemInfo.WaitForItemExists(30000);
				TreeItem MsExcelTree = null;
				
				foreach (var item in preRepo.ServersList.LocalDBServersTreeItem.Items)
				{
					if(item.Text == "MS Excel")
					{
						MsExcelTree = item;
						break;
					}
				}
				
				if(MsExcelTree != null)
				{
					MsExcelTree.EnsureVisible();
					MsExcelTree.RightClickThis();
					Keyboard.Press(Keyboard.ToKey("Ctrl+Insert"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
					System.Threading.Thread.Sleep(1000);
					Keyboard.Press(Keyboard.ToKey("Ctrl+Q"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				}
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ConnectServer : " + ex.Message);
			}
		}
		
		public static void ClickQARun()
		{
			try
			{
				repo.QuaryAnalyzerWindow.QueryBoxInfo.WaitForItemExists(30000);
				repo.QuaryAnalyzerWindow.QueryBox.Click();
				repo.QuaryAnalyzerWindow.QueryBox.PressKeys("select * from stockprices");
				Keyboard.Press(Keyboard.ToKey("Ctrl+E"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Reports.ReportLog("results Displayed", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickQARun : " + ex.Message);
			}
		}
		
		public static void ClickNewVA()
		{
			try 
			{
				repo.Application.NewVAMenuInfo.WaitForItemExists(Common.ApplicationOpenWaitTime);
				repo.Application.NewVAMenu.ClickThis();
				Reports.ReportLog("ClickNewVA", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			} 
			catch (Exception ex) 
			{
				throw new Exception("Failed : ClickNewVA : " + ex.Message);
			}
		}
        		
		public static void CloseTab()
		{
			try 
			{
				repo.Application.Self.Focus();
        		Preconditions.Steps.CloseTab(Config.TestCaseName);	
        		TC_10547.Steps.ClickDiscard();
        		Reports.ReportLog("CloseTab", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			} 
			catch (Exception ex) 
			{
				throw new Exception("Failed : CloseTab : " + ex.Message);
			}
		}
		
		public static void WaitForVAExists()
		{
			try 
			{
				repo.VisualAnalyticsBook1Asterisk.Self.Focus();
				repo.VisualAnalyticsBook1Asterisk.SelfInfo.WaitForItemExists(Common.ApplicationOpenWaitTime);
				Reports.ReportLog("WaitForVAExists", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			} 
			catch (Exception ex) 
			{
				throw new Exception("Failed : WaitForVAExists : " + ex.Message);
			}
		}
		
		public static void DragStockDateToColumn()
		{
			try 
			{	
				repo.VisualAnalyticsBook1Asterisk.ContainerMainPanel.StockDateInfo.WaitForItemExists(Common.ApplicationOpenWaitTime);
	            repo.VisualAnalyticsBook1Asterisk.ContainerMainPanel.StockDate.MoveTo("50;8");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            
	            repo.VisualAnalyticsBook1Asterisk.ContainerMainPanel.StockDateInfo.WaitForItemExists(Common.ApplicationOpenWaitTime);
	            repo.VisualAnalyticsBook1Asterisk.ContainerMainPanel.StockDate.MoveTo("58;0");
	            
	            repo.VisualAnalyticsBook1Asterisk.ContainerMainPanel.PanelInfo.WaitForItemExists(Common.ApplicationOpenWaitTime);
	            repo.VisualAnalyticsBook1Asterisk.ContainerMainPanel.Panel.MoveTo("65;16");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            
				Reports.ReportLog("DragStockDateToColumn", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			} 
			catch (Exception ex) 
			{
				throw new Exception("Failed : DragStockDateToColumn : " + ex.Message);
			}
		}
		
		public static void DragStockCloseToRow()
		{
			try 
			{	
				repo.VisualAnalyticsBook1Asterisk.ContainerMainPanel.SUMStockCloseInfo.WaitForItemExists(Common.ApplicationOpenWaitTime);
	            repo.VisualAnalyticsBook1Asterisk.ContainerMainPanel.SUMStockClose.MoveTo("65;13");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            
	            repo.VisualAnalyticsBook1Asterisk.ContainerMainPanel.SUMStockCloseInfo.WaitForItemExists(Common.ApplicationOpenWaitTime);
	            repo.VisualAnalyticsBook1Asterisk.ContainerMainPanel.SUMStockClose.MoveTo("73;5");
	            
	            repo.VisualAnalyticsBook1Asterisk.ContainerMainPanel.Panel1Info.WaitForItemExists(Common.ApplicationOpenWaitTime);
	            repo.VisualAnalyticsBook1Asterisk.ContainerMainPanel.Panel1.MoveTo("82;7");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            
	            Reports.ReportLog("DragStockCloseToRow", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			} 
			catch (Exception ex) 
			{
				throw new Exception("Failed : DragStockCloseToRow : " + ex.Message);
			}
		}
		
		public static void RightClickStockClose()
		{
			try 
			{	
				repo.VisualAnalyticsBook1Asterisk.ContainerMainPanel.SUMStockClose1Info.WaitForItemExists(10000);
				repo.VisualAnalyticsBook1Asterisk.ContainerMainPanel.SUMStockClose1.RightClick();
	            Reports.ReportLog("RightClickStockClose", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
	            
			} 
			catch (Exception ex) 
			{
				throw new Exception("Failed : RightClickStockClose : " + ex.Message);
			}
		}
		
		public static void SetStockCloseToLeft()
		{
			try 
			{	
				RightClickStockClose();
	            
	            try 
	            {
	            	repo.Datastudio.MeasureTypeSumInfo.WaitForItemExists(10000);
	            	repo.Datastudio.MeasureTypeSum.ClickThis();
	            } 
	            catch 
	            {
	            	RightClickStockClose();
	            	repo.Datastudio.MeasureTypeSumInfo.WaitForItemExists(10000);
	            	repo.Datastudio.MeasureTypeSum.ClickThis();
	            }
	            
	            repo.Datastudio1.LastInfo.WaitForItemExists(Common.ApplicationOpenWaitTime);
	            repo.Datastudio1.Last.ClickThis();
	            
	            Reports.ReportLog("SetStockCloseToLeft", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
            	ExplicitWait();
			} 
			catch (Exception ex) 
			{
				throw new Exception("Failed : SetStockCloseToLeft : " + ex.Message);
			}
		}
		
		public static void SelectPrice()
		{
			try 
			{	
				try 
				{
					repo.VisualAnalyticsBook1Asterisk.ContainerMainPanel.WindowsComboBoxUIDollarXPComboBoxButtonInfo.WaitForItemExists(10000);
	            	repo.VisualAnalyticsBook1Asterisk.ContainerMainPanel.WindowsComboBoxUIDollarXPComboBoxButton.ClickThis();
				} 
				catch
				{
					repo.VisualAnalyticsBook1Asterisk.ContainerMainPanel.WindowsComboBoxUIDollarXPComboBoxButtonInfo.WaitForItemExists(10000);
	            	repo.VisualAnalyticsBook1Asterisk.ContainerMainPanel.WindowsComboBoxUIDollarXPComboBoxButton.ClickThis();
				}
	            
	            repo.Datastudio.PriceInfo.WaitForItemExists(Common.ApplicationOpenWaitTime);
	            repo.Datastudio.Price.ClickThis();
	            
	            Reports.ReportLog("SelectPrice", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
            	ExplicitWait();
			} 
			catch (Exception ex) 
			{
				throw new Exception("Failed : SelectPrice : " + ex.Message);
			}
		}
		
		public static void DragStockHighToHigh()
		{
			try 
			{	
				repo.VisualAnalyticsBook1Asterisk.ContainerMainPanel.SUMStockHighInfo.WaitForItemExists(Common.ApplicationOpenWaitTime);
	            repo.VisualAnalyticsBook1Asterisk.ContainerMainPanel.SUMStockHigh.MoveTo("68;6");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            
	            repo.VisualAnalyticsBook1Asterisk.ContainerMainPanel.SUMStockHighInfo.WaitForItemExists(Common.ApplicationOpenWaitTime);
	            repo.VisualAnalyticsBook1Asterisk.ContainerMainPanel.SUMStockHigh.MoveTo("76;-2");
	            
	            repo.VisualAnalyticsBook1Asterisk.ContainerMainPanel.HighInfo.WaitForItemExists(Common.ApplicationOpenWaitTime);
	            repo.VisualAnalyticsBook1Asterisk.ContainerMainPanel.High.MoveTo("35;38");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            
	            Reports.ReportLog("DragStockHighToHigh", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			} 
			catch (Exception ex) 
			{
				throw new Exception("Failed : DragStockHighToHigh : " + ex.Message);
			}
		}
		
		public static void DragStockLowToLow()
		{
			try 
			{	
				repo.VisualAnalyticsBook1Asterisk.ContainerMainPanel.SUMStockLowInfo.WaitForItemExists(Common.ApplicationOpenWaitTime);
	            repo.VisualAnalyticsBook1Asterisk.ContainerMainPanel.SUMStockLow.MoveTo("64;10");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            
	            repo.VisualAnalyticsBook1Asterisk.ContainerMainPanel.SUMStockLowInfo.WaitForItemExists(Common.ApplicationOpenWaitTime);
	            repo.VisualAnalyticsBook1Asterisk.ContainerMainPanel.SUMStockLow.MoveTo("72;2");
	            
	            repo.VisualAnalyticsBook1Asterisk.ContainerMainPanel.TextLowInfo.WaitForItemExists(Common.ApplicationOpenWaitTime);
	            repo.VisualAnalyticsBook1Asterisk.ContainerMainPanel.TextLow.MoveTo("20;25");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            
	            Reports.ReportLog("DragStockLowToLow", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			} 
			catch (Exception ex) 
			{
				throw new Exception("Failed : DragStockLowToLow : " + ex.Message);
			}
		}
		
		public static void DragStockSymbolToFilters()
		{
			try 
			{	
	            repo.VisualAnalyticsBook1Asterisk.ContainerMainPanel.StockSymbolInfo.WaitForItemExists(Common.ApplicationOpenWaitTime);
	            repo.VisualAnalyticsBook1Asterisk.ContainerMainPanel.StockSymbol.MoveTo("87;5");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            
	            repo.VisualAnalyticsBook1Asterisk.ContainerMainPanel.StockSymbolInfo.WaitForItemExists(Common.ApplicationOpenWaitTime);
	            repo.VisualAnalyticsBook1Asterisk.ContainerMainPanel.StockSymbol.MoveTo("95;-3");
	            
	            repo.VisualAnalyticsBook1Asterisk.ContainerMainPanel.Panel2Info.WaitForItemExists(Common.ApplicationOpenWaitTime);
	            repo.VisualAnalyticsBook1Asterisk.ContainerMainPanel.Panel2.MoveTo("48;16");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            
	            Reports.ReportLog("DragStockSymbolToFilters", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			} 
			catch (Exception ex) 
			{
				throw new Exception("Failed : DragStockSymbolToFilters : " + ex.Message);
			}
		}
		
		public static void UnselectAll()
		{
			try 
			{   
	            repo.VisualAnalyticsBook1Asterisk.ContainerMainPanel.ListItemAllInfo.WaitForItemExists(Common.ApplicationOpenWaitTime);
	            repo.VisualAnalyticsBook1Asterisk.ContainerMainPanel.ListItemAll.Click("9;9");
	            
	            Reports.ReportLog("UnselectAll", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			} 
			catch (Exception ex) 
			{
				throw new Exception("Failed : UnselectAll : " + ex.Message);
			}
		}
		
		public static void SelectAPPL()
		{
			try 
			{   
	            repo.VisualAnalyticsBook1Asterisk.ContainerMainPanel.AAPLInfo.WaitForItemExists(Common.ApplicationOpenWaitTime);
	            repo.VisualAnalyticsBook1Asterisk.ContainerMainPanel.AAPL.Click("10;10");
	            
	            Reports.ReportLog("SelectAPPL", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			} 
			catch (Exception ex) 
			{
				throw new Exception("Failed : SelectAPPL : " + ex.Message);
			}
		}
		
		public static void ValidateBeforeStockOpen()
		{
			try 
			{   
	            //string templatePath = @"C:\Users\Admin\Documents\Ranorex\RanorexStudio Projects\ADSAutomationPhaseII\ADSAutomationPhaseII\TestData\TC_10597\Before.JPG";
	            //repo.VisualAnalyticsBook1Asterisk.ContainerMainPanel.BIChartOverlayPanel1.ValidateChart(templatePath, "ValidateBeforeStockOpen");
			} 
			catch (Exception ex) 
			{
				throw new Exception("Failed : ValidateBeforeStockOpen : " + ex.Message);
			}
		}
		
		public static void DragStockOpenToOpen()
		{
			try 
			{   
	            repo.VisualAnalyticsBook1Asterisk.ContainerMainPanel.SUMStockOpenInfo.WaitForItemExists(Common.ApplicationOpenWaitTime);
	            repo.VisualAnalyticsBook1Asterisk.ContainerMainPanel.SUMStockOpen.MoveTo("85;14");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            
	            repo.VisualAnalyticsBook1Asterisk.ContainerMainPanel.SUMStockOpenInfo.WaitForItemExists(Common.ApplicationOpenWaitTime);
	            repo.VisualAnalyticsBook1Asterisk.ContainerMainPanel.SUMStockOpen.MoveTo("93;6");
	            
	            repo.VisualAnalyticsBook1Asterisk.ContainerMainPanel.OpenInfo.WaitForItemExists(Common.ApplicationOpenWaitTime);
	            repo.VisualAnalyticsBook1Asterisk.ContainerMainPanel.Open.MoveTo("16;30");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            
	            Reports.ReportLog("DragStockOpenToOpen", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			} 
			catch (Exception ex) 
			{
				throw new Exception("Failed : DragStockOpenToOpen : " + ex.Message);
			}
		}
		
		public static void ValidateAfterStockOpen()
		{
			try 
			{   
	           //string templatePath = @"C:\Users\Admin\Documents\Ranorex\RanorexStudio Projects\ADSAutomationPhaseII\ADSAutomationPhaseII\TestData\TC_10597\After.JPG";
	           //repo.VisualAnalyticsBook1Asterisk.ContainerMainPanel.BIChartOverlayPanel1.ValidateChart(templatePath, "ValidateAfterStockOpen");
			} 
			catch (Exception ex) 
			{
				throw new Exception("Failed : ValidateAfterStockOpen : " + ex.Message);
			}
		}
		
		public static void EditAxis()
		{
			try 
			{ 

				try 
				{
					repo.VisualAnalyticsBook1Asterisk.ContainerMainPanel.BIChartOverlayPanel1Info.WaitForItemExists(10000);
		            repo.VisualAnalyticsBook1Asterisk.ContainerMainPanel.BIChartOverlayPanel1.Click("17;254");
		            repo.VisualAnalyticsBook1Asterisk.ContainerMainPanel.BIChartOverlayPanel1.RightClickContainer();
		            ExplicitWait();
				} 
				catch 
				{
					repo.VisualAnalyticsBook1Asterisk.ContainerMainPanel.BIChartOverlayPanel1Info.WaitForItemExists(10000);
		            repo.VisualAnalyticsBook1Asterisk.ContainerMainPanel.BIChartOverlayPanel1.Click("17;254");
		            repo.VisualAnalyticsBook1Asterisk.ContainerMainPanel.BIChartOverlayPanel1.RightClickContainer();
				}
				Reports.ReportLog("RightClick on Axis", Reports.ADSReportLevel.Success, null, Config.TestCaseName);				
				
				repo.Datastudio.EditAxisInfo.WaitForItemExists(Common.ApplicationOpenWaitTime);
				repo.Datastudio.EditAxis.ClickThis();
				Reports.ReportLog("Select Edit Axis", Reports.ADSReportLevel.Success, null, Config.TestCaseName);				
				
				repo.EditAxisLASTStockClose.SelfInfo.WaitForItemExists(Common.ApplicationOpenWaitTime);
	            
	            repo.EditAxisLASTStockClose.CPanel.IncludeZeroInfo.WaitForItemExists(Common.ApplicationOpenWaitTime);
	            if(repo.EditAxisLASTStockClose.CPanel.IncludeZero.Checked) repo.EditAxisLASTStockClose.CPanel.IncludeZero.ClickThis();
	            Reports.ReportLog("Checked Include Zero", Reports.ADSReportLevel.Success, null, Config.TestCaseName);				
	            
	            repo.EditAxisLASTStockClose.CPanel.ApplyInfo.WaitForItemExists(Common.ApplicationOpenWaitTime);
	            repo.EditAxisLASTStockClose.CPanel.Apply.ClickThis();
	            Reports.ReportLog("Click on Apply", Reports.ADSReportLevel.Success, null, Config.TestCaseName);				
	            
	            repo.EditAxisLASTStockClose.CPanel.ButtonOKInfo.WaitForItemExists(Common.ApplicationOpenWaitTime);
	            repo.EditAxisLASTStockClose.CPanel.ButtonOK.ClickThis();
	            Reports.ReportLog("Click on Close", Reports.ADSReportLevel.Success, null, Config.TestCaseName);				
	            
	            Reports.ReportLog("EditAxis", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
	            ExplicitWait();
			} 
			catch (Exception ex) 
			{
				throw new Exception("Failed : EditAxis : " + ex.Message);
			}
		}
		
		public static void CloseVA()
		{
			try 
			{   
				repo.VisualAnalyticsBook1Asterisk.Self.Close();
	            if(repo.SaveChanges.SelfInfo.Exists(new Duration(25000))) repo.SaveChanges.DiscardButton.ClickThis();
	            
	            Reports.ReportLog("CloseVA", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			} 
			catch (Exception ex) 
			{
				throw new Exception("Failed : CloseVA : " + ex.Message);
			}
		}
		
		public static void ExplicitWait()
		{
			//System.Threading.Thread.Sleep(2000);
		}
	}
}
