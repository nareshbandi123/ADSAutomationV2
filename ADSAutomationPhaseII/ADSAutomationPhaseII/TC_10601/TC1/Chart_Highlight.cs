using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

using WinForms = System.Windows.Forms;
using ADSAutomationPhaseII.Base;
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.TC_10594;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace ADSAutomationPhaseII.TC_10601.TC1
{
	
	[TestModule("11730D99-8A60-4DC2-91C7-C7415896691C", ModuleType.UserCode, 1)]
	public class Chart_Highlight : BaseClass, ITestModule
	{
		public Chart_Highlight()
		{
			
		}
		void ITestModule.Run()
		{
			StartProcess();
		}
		
		
		bool StartProcess()
		{
			try
			{
				Steps.ClickonFileMenu();
				Steps.ClickonOpen();
				Steps.SelectNewFile();
				Steps.ClickonOpenButton();
				Steps.ClickMaximumWindow();
				Steps.ClickKeepOnlyFurniture();
				Steps.ValidateClickKeepOnlyFurniture();
				Steps.ClickUndo();
				Steps.ClickEastShapes();
				Steps.ValidateClickEastShapes();
				Steps.ClickToolTipExclude();
				Steps.ValidateClickToolTipExclude();
				Steps.ClickUndo();
				Steps.Clickon2012_2013Header();
				Steps.ClickKeepTooltip2012Header();
				Steps.ValidateClickKeepTooltip2012Header();
				
				Steps.CloseVAWindow();
				
			}
			catch (Exception ex)
			{
				Steps.CloseVAWindow();
				Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
			}
			return true;
		}
	}
}
