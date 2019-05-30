using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using ADSAutomationPhaseII.Configuration;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace ADSAutomationPhaseII.TC_10606
{
	[TestModule("D634C931-7D65-4DE0-A938-33FF362E46DE", ModuleType.UserCode, 1)]
	public class Retry : Base.BaseClass, ITestModule
	{
		public Retry()
		{
		}

		void ITestModule.Run()
		{
			string retryTestcaseName = Config.TestCaseName + "_Retry";
			
			if (((TestCaseNode)TestSuite.CurrentTestContainer).Status.Equals(Ranorex.Core.Reporting.ActivityStatus.Failed))
				TestSuite.Current.GetTestContainer(retryTestcaseName).Checked = true;
			else
				TestSuite.Current.GetTestContainer(retryTestcaseName).Checked = false;
		}
	}
}
