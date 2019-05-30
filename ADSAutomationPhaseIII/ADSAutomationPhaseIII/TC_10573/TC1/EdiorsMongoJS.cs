
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

using ADSAutomationPhaseIII.Base;
using ADSAutomationPhaseIII.Commons;
using ADSAutomationPhaseIII.Extensions;
using ADSAutomationPhaseIII.Configuration;
using ADSAutomationPhaseIII.TC_10570;

namespace ADSAutomationPhaseIII.TC_10573.TC1
{
	
	[TestModule("E4CD48C2-6DE7-4BCE-97CC-D321DB9AB07A", ModuleType.UserCode, 1)]
	public class EdiorsMongoJS : BaseClass, ITestModule
	{
		
		public EdiorsMongoJS()
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
				TC_10570.Steps.CreateDatabase();
				Steps.ConnectServer();
				Steps.SelectMongoJS();
				TC_10570.Steps.SelectDatabase();
				Steps.ProvideCommands("use ads_db");
        		Steps.ProvideNewCommand();
        		Steps.ProvideCommands("show collections");
        		Steps.ProvideNewCommand();
        		Steps.ProvideCommands("db.help()");
        		Steps.ProvideNewCommand();
        		Steps.ProvideCommands("db.ads_collection.count()");
        		Steps.ProvideNewCommand();
				string result = string.Format("db.ads_collection.insert({{{{'isbn': '9780060859749', 'title': 'After Alice: A Novel', 'author': 'Gregory Maguire', 'category': 'Fiction', 'year':'2017'");
				Steps.ProvideCommands(result);
				Steps.ProvideNewCommand();
				string result1 = string.Format("db.ads_collection.insert({{{{'isbn': '9780060859746', 'title': 'After Alice: A Joke', 'author': 'Gregory Maguire', 'category': 'Fiction', 'year': '2018'");
				Steps.ProvideCommands(result1);
				Steps.ProvideNewCommand();
				String result2 = string.Format("db.ads_collection.insert({{{{'isbn': '9780060859745', 'title': 'After Alice', 'author': 'Gregory Maguire', 'category': 'Fiction', 'year': '2016'");
				Steps.ProvideCommands(result2);
				Steps.ProvideNewCommand();
				Steps.ProvideCommands("db.ads_collection.find()");
        		Steps.ProvideNewCommand();
        		Steps.ProvideCommands("db.ads_collection.remove({{})");
        		Steps.ProvideNewCommand();
        		Steps.ProvideCommands("db.ads_collection.find().limit(2)");
        		Steps.ProvideNewCommand();
        		Steps.ProvideCommands("db.ads_collection.getIndexes()");
        		Steps.ProvideNewCommand();
        		Steps.ProvideCommands("db.ads_collection.drop()");
        		Steps.CloseQuaryAnalyzerTab();
        		Steps.DisConnectServer();
       		
        		Steps.ConnectServer();
        		Steps.SelectMongoShell();
        		Steps.ProvideFluidShellCommands("show dbs");
        		Steps.ProvideFluidShellCommands("show users");
        		Steps.ProvideFluidShellCommands("show roles");
        		Steps.ProvideFluidShellCommands("show profile");
        		Steps.ProvideFluidShellCommands("show databases");
        		Steps.CloseQuaryAnalyzerTab();
        		Steps.DisConnectServer();
			}
			catch (Exception ex)
			{
				Steps.CloseQuaryAnalyzerTab();
				Steps.DisConnectServer();
				Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
			}
			return true;
		}
	}
}
