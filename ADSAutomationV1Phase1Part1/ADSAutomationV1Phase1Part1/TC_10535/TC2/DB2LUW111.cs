﻿/*
 * Created by Ranorex
 * User: Admin
 * Date: 2/27/2019
 * Time: 9:43 PM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
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
using ADSAutomationPhaseII.Commons;

namespace ADSAutomationPhaseII.TC_10535.TC2
{
    /// <summary>
    /// Description of DB2LUW111.
    /// </summary>
    [TestModule("D2500F74-742C-4A90-B0FF-C94124144FC9", ModuleType.UserCode, 1)]
    public class DB2LUW111 : BaseClass, ITestModule
    {
        public DB2LUW111()
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
        		Steps.ClickOnERModelerMenu();
        		Steps.SelectNew();
        		Steps.SelectDataTypeAndVersion(Steps.DatabaseTypes.DB2LUW, "111");
        		Steps.ValidateTree(false, true, true, true, true);
        		Steps.RightClickOnTables();
        		Steps.CreateNewTable();
        		Steps.RightClickOnTables();
        		Steps.CreateNewTable();
        		Steps.RightClickOnTable1();       		
        		Steps.SelectProperties();
        		Steps.EnterParentTableName();        		
        		Steps.CreateColumns();
        		Steps.EditColumns();
        		Steps.RightClickOnTable2();       		
        		Steps.SelectProperties();
        		Steps.EnterChildTableName();
        		Steps.CreateColumns();
        		Steps.CreateNewRelationship();
        		Steps.EnterRelationshipName();
        		Steps.SelectParentTableComboBox();
        		Steps.SelectChildTableComboBox();
        		Steps.CheckParentTableCheckbox();
        		Steps.CheckChildTableCheckbox();
        		Steps.ClickRelationshipOkButton();
        		Steps.SaveERD();
        		Steps.ClickOnERModelerMenu();
        		Steps.SelectOpen();
        		Steps.OpenERD();
        	} 
			catch (Exception ex) 
        	{
        		Reports.ReportLog(ex.ToString(), Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
        	}
        	return true;
        }
    }
}