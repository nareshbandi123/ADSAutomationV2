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
using ADSAutomationPhaseII.Base;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Preconditions;
using ADSAutomationPhaseII.Configuration;
using ADSAutomationPhaseII.TC_10589;
using ADSAutomationPhaseII.TC_10599;

namespace ADSAutomationPhaseII.TC_10604.TC2
{
    [TestModule("E061DEA3-859C-46EA-A40C-B6492193B08C", ModuleType.UserCode, 1)]
    public class Text_Object_And_Image_Object : BaseClass,ITestModule
    {
        public Text_Object_And_Image_Object()
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
        		TC_10589.Steps.ClickOnFileMenu();
        		TC_10589.Steps.ClickOnOpenMenu();
        		Steps.EnterFilePath();
        		TC_10589.Steps.ClickOnOpenButton();
        		TC_10599.Steps.Maximize();
        		Steps.OpenTextEditor();
        		Steps.EditText();
        		Steps.OpenFormatTextObjects();
        		Steps.TestAlignment();
        		Steps.TestShading();
        		Steps.TestBorder();
        		Steps.ClickOnFormatObjectOk();
        		Steps.SetTextAsLink();
        		Steps.ClickOnInsertOk();
        		Steps.OpenLink();
        		Steps.ClosePage();
        		Steps.EditSheet();
        		Steps.NavigateToDashboard1();
        		Steps.ClickOnImageButton();
        		Steps.OpenImageFromLocal();
        		Steps.ClickOnOpen();
        		Steps.OpenImageFromWeb();
        		Steps.ClickOnOpen();
        		Steps.ChangeImage();
        		Steps.OpenImage();
        		Steps.FitImage();
        		Steps.CenterImage();
        		Steps.InsertImageLink();
        		TC_10599.Steps.CloseViz();
        		TC_10589.Steps.ClickOnDiscard();
        	}
        	catch(Exception e)
        	{
        		Steps.CloseOnOpenFileError();
        		Steps.CloseOnVisualAnalyticsError();
        		Reports.ReportLog(e.Message, Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
        	}
        	
        	return true;        	
        }
        
    }
}
