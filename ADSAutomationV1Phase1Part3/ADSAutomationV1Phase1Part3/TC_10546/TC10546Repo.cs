﻿///////////////////////////////////////////////////////////////////////////////
//
// This file was automatically generated by RANOREX.
// DO NOT MODIFY THIS FILE! It is regenerated by the designer.
// All your modifications will be lost!
// http://www.ranorex.com
//
///////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Repository;
using Ranorex.Core.Testing;

namespace ADSAutomationV1Phase1Part3.TC_10546
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    /// The class representing the TC10546Repo element repository.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "8.2")]
    [RepositoryFolder("2583ae54-2abd-49c6-b6ed-ce27661d31e0")]
    public partial class TC10546Repo : RepoGenBaseFolder
    {
        static TC10546Repo instance = new TC10546Repo();
        TC10546RepoFolders.ApplicationAppFolder _application;
        TC10546RepoFolders.DatastudioAppFolder _datastudio;
        TC10546RepoFolders.SchemaSynchronizationAppFolder _schemasynchronization;
        TC10546RepoFolders.ChooseServerAppFolder _chooseserver;

        /// <summary>
        /// Gets the singleton class instance representing the TC10546Repo element repository.
        /// </summary>
        [RepositoryFolder("2583ae54-2abd-49c6-b6ed-ce27661d31e0")]
        public static TC10546Repo Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// Repository class constructor.
        /// </summary>
        public TC10546Repo() 
            : base("TC10546Repo", "/", null, 0, false, "2583ae54-2abd-49c6-b6ed-ce27661d31e0", ".\\RepositoryImages\\TC10546Repo2583ae54.rximgres")
        {
            _application = new TC10546RepoFolders.ApplicationAppFolder(this);
            _datastudio = new TC10546RepoFolders.DatastudioAppFolder(this);
            _schemasynchronization = new TC10546RepoFolders.SchemaSynchronizationAppFolder(this);
            _chooseserver = new TC10546RepoFolders.ChooseServerAppFolder(this);
        }

#region Variables

#endregion

        /// <summary>
        /// The Self item info.
        /// </summary>
        [RepositoryItemInfo("2583ae54-2abd-49c6-b6ed-ce27661d31e0")]
        public virtual RepoItemInfo SelfInfo
        {
            get
            {
                return _selfInfo;
            }
        }

        /// <summary>
        /// The Application folder.
        /// </summary>
        [RepositoryFolder("6329e560-0ad9-401f-a640-2cf940b48e2e")]
        public virtual TC10546RepoFolders.ApplicationAppFolder Application
        {
            get { return _application; }
        }

        /// <summary>
        /// The Datastudio folder.
        /// </summary>
        [RepositoryFolder("410638e4-bd48-4c9c-b9cd-aa828e1bf7ad")]
        public virtual TC10546RepoFolders.DatastudioAppFolder Datastudio
        {
            get { return _datastudio; }
        }

        /// <summary>
        /// The SchemaSynchronization folder.
        /// </summary>
        [RepositoryFolder("e41a53dc-f3c2-4cea-8aa6-21b67da9fb3f")]
        public virtual TC10546RepoFolders.SchemaSynchronizationAppFolder SchemaSynchronization
        {
            get { return _schemasynchronization; }
        }

        /// <summary>
        /// The ChooseServer folder.
        /// </summary>
        [RepositoryFolder("bc082b9e-32e6-4741-a754-c25659504eb0")]
        public virtual TC10546RepoFolders.ChooseServerAppFolder ChooseServer
        {
            get { return _chooseserver; }
        }
    }

    /// <summary>
    /// Inner folder classes.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "8.2")]
    public partial class TC10546RepoFolders
    {
        /// <summary>
        /// The ApplicationAppFolder folder.
        /// </summary>
        [RepositoryFolder("6329e560-0ad9-401f-a640-2cf940b48e2e")]
        public partial class ApplicationAppFolder : RepoGenBaseFolder
        {
            RepoItemInfo _toolsInfo;
            RepoItemInfo _schemasynchronizeInfo;
            RepoItemInfo _tableInfo;
            RepoItemInfo _nextbuttonInfo;
            RepoItemInfo _mapmissingcolumntabInfo;
            RepoItemInfo _configurescripttabInfo;
            RepoItemInfo _optionstabInfo;
            RepoItemInfo _reviewtabInfo;
            RepoItemInfo _reviewdependencytabInfo;
            RepoItemInfo _synccheckboxInfo;
            RepoItemInfo _previousbuttonInfo;

            /// <summary>
            /// Creates a new Application  folder.
            /// </summary>
            public ApplicationAppFolder(RepoGenBaseFolder parentFolder) :
                    base("Application", "/form[@title='Aqua Data Studio']", parentFolder, 30000, null, true, "6329e560-0ad9-401f-a640-2cf940b48e2e", "")
            {
                _toolsInfo = new RepoItemInfo(this, "Tools", ".//menuitem[@text='Tools']", 30000, null, "79c38260-bedf-448b-8231-2bcf7ff98268");
                _schemasynchronizeInfo = new RepoItemInfo(this, "SchemaSynchronize", ".//container[@type='ToolWindowsPane']/container[@name='myLayeredPane']/?/?/container[@type='ThreeComponentsSplitter']/container[@name='myInnerComponent']//button[@text='Synchronize Schema']", 30000, null, "d4f474ee-2cb7-45b3-b694-d281e77af944");
                _tableInfo = new RepoItemInfo(this, "Table", ".//container[@name='myLayeredPane']/?/?/container[@type='ThreeComponentsSplitter']/container[@name='myInnerComponent']//container[@name='_treeTableScrollPane']/container[1]/table[@name='a']", 30000, null, "a39f04a4-9651-4898-bc0b-ea4302df597f");
                _nextbuttonInfo = new RepoItemInfo(this, "NextButton", ".//container[@type='ToolWindowsPane']/container[@name='myLayeredPane']/?/?/container[@type='ThreeComponentsSplitter']/container[@name='myInnerComponent']//container[@type='SchemaSyncWizard$5']//button[@name='_nextButton']", 30000, null, "fbbcc980-de27-4806-992f-b109047a5d5e");
                _mapmissingcolumntabInfo = new RepoItemInfo(this, "MapMissingColumnTab", ".//container[@type='ToolWindowsPane']/container[@name='myLayeredPane']/?/?/container[@type='ThreeComponentsSplitter']/container[@name='myInnerComponent']//container[@type='SchemaSyncWizard$5']//container[@name='_tabbedPane']/tabpage[@title='Map Missing Columns   ']", 30000, null, "2ae098ce-c7dd-44e8-a708-57f0e77407a8");
                _configurescripttabInfo = new RepoItemInfo(this, "ConfigureScriptTab", ".//container[@type='ToolWindowsPane']/container[@name='myLayeredPane']/?/?/container[@type='ThreeComponentsSplitter']/container[@name='myInnerComponent']//container[@type='SchemaSyncWizard$5']//container[@name='_tabbedPane']/tabpage[@title='Configure Script   ']", 30000, null, "e4aee398-8e9c-4f1c-91d7-bbe0d3f6155d");
                _optionstabInfo = new RepoItemInfo(this, "OptionsTab", ".//container[@type='ToolWindowsPane']/container[@name='myLayeredPane']/?/?/container[@type='ThreeComponentsSplitter']/container[@name='myInnerComponent']//container[@type='SchemaSyncWizard$5']//container[@name='_tabbedPane']/tabpage[@title='Options   ']", 30000, null, "d63db6ae-5900-4104-99fb-3fd4e325499f");
                _reviewtabInfo = new RepoItemInfo(this, "ReviewTab", ".//container[@type='ToolWindowsPane']/container[@name='myLayeredPane']/?/?/container[@type='ThreeComponentsSplitter']/container[@name='myInnerComponent']//container[@type='SchemaSyncWizard$5']//container[@name='_tabbedPane']/tabpage[@title='Review   ']", 30000, null, "0cc7eb9f-0e6d-4faf-b833-39a7e0d48cb6");
                _reviewdependencytabInfo = new RepoItemInfo(this, "ReviewDependencyTab", ".//container[@type='ToolWindowsPane']/container[@name='myLayeredPane']/?/?/container[@type='ThreeComponentsSplitter']/container[@name='myInnerComponent']//container[@type='SchemaSyncWizard$5']//container[@name='_tabbedPane']/tabpage[@title='Review Dependencies   ']", 30000, null, "62e09665-0db9-4ccc-b5c6-23cdcc4ac37e");
                _synccheckboxInfo = new RepoItemInfo(this, "SyncCheckbox", ".//container[@name='myLayeredPane']/?/?/container[@type='ThreeComponentsSplitter']/container[@name='myInnerComponent']//container[@name='_treeTableScrollPane']/container[5]/table[@type='CJideSortableTable']/row[@index='1']/cell[3]", 30000, null, "171b9aa5-851c-4dfa-98cf-b71168357cd9");
                _previousbuttonInfo = new RepoItemInfo(this, "PreviousButton", ".//container[@type='ToolWindowsPane']/container[@name='myLayeredPane']/?/?/container[@type='ThreeComponentsSplitter']/container[@name='myInnerComponent']//container[@type='SchemaSyncWizard$5']//button[@name='_prevButton']", 30000, null, "21ecf66c-16aa-4674-ae32-e4906aebbf57");
            }

            /// <summary>
            /// The Self item.
            /// </summary>
            [RepositoryItem("6329e560-0ad9-401f-a640-2cf940b48e2e")]
            public virtual Ranorex.Form Self
            {
                get
                {
                    return _selfInfo.CreateAdapter<Ranorex.Form>(true);
                }
            }

            /// <summary>
            /// The Self item info.
            /// </summary>
            [RepositoryItemInfo("6329e560-0ad9-401f-a640-2cf940b48e2e")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }

            /// <summary>
            /// The Tools item.
            /// </summary>
            [RepositoryItem("79c38260-bedf-448b-8231-2bcf7ff98268")]
            public virtual Ranorex.MenuItem Tools
            {
                get
                {
                    return _toolsInfo.CreateAdapter<Ranorex.MenuItem>(true);
                }
            }

            /// <summary>
            /// The Tools item info.
            /// </summary>
            [RepositoryItemInfo("79c38260-bedf-448b-8231-2bcf7ff98268")]
            public virtual RepoItemInfo ToolsInfo
            {
                get
                {
                    return _toolsInfo;
                }
            }

            /// <summary>
            /// The SchemaSynchronize item.
            /// </summary>
            [RepositoryItem("d4f474ee-2cb7-45b3-b694-d281e77af944")]
            public virtual Ranorex.Button SchemaSynchronize
            {
                get
                {
                    return _schemasynchronizeInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The SchemaSynchronize item info.
            /// </summary>
            [RepositoryItemInfo("d4f474ee-2cb7-45b3-b694-d281e77af944")]
            public virtual RepoItemInfo SchemaSynchronizeInfo
            {
                get
                {
                    return _schemasynchronizeInfo;
                }
            }

            /// <summary>
            /// The Table item.
            /// </summary>
            [RepositoryItem("a39f04a4-9651-4898-bc0b-ea4302df597f")]
            public virtual Ranorex.Table Table
            {
                get
                {
                    return _tableInfo.CreateAdapter<Ranorex.Table>(true);
                }
            }

            /// <summary>
            /// The Table item info.
            /// </summary>
            [RepositoryItemInfo("a39f04a4-9651-4898-bc0b-ea4302df597f")]
            public virtual RepoItemInfo TableInfo
            {
                get
                {
                    return _tableInfo;
                }
            }

            /// <summary>
            /// The NextButton item.
            /// </summary>
            [RepositoryItem("fbbcc980-de27-4806-992f-b109047a5d5e")]
            public virtual Ranorex.Button NextButton
            {
                get
                {
                    return _nextbuttonInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The NextButton item info.
            /// </summary>
            [RepositoryItemInfo("fbbcc980-de27-4806-992f-b109047a5d5e")]
            public virtual RepoItemInfo NextButtonInfo
            {
                get
                {
                    return _nextbuttonInfo;
                }
            }

            /// <summary>
            /// The MapMissingColumnTab item.
            /// </summary>
            [RepositoryItem("2ae098ce-c7dd-44e8-a708-57f0e77407a8")]
            public virtual Ranorex.TabPage MapMissingColumnTab
            {
                get
                {
                    return _mapmissingcolumntabInfo.CreateAdapter<Ranorex.TabPage>(true);
                }
            }

            /// <summary>
            /// The MapMissingColumnTab item info.
            /// </summary>
            [RepositoryItemInfo("2ae098ce-c7dd-44e8-a708-57f0e77407a8")]
            public virtual RepoItemInfo MapMissingColumnTabInfo
            {
                get
                {
                    return _mapmissingcolumntabInfo;
                }
            }

            /// <summary>
            /// The ConfigureScriptTab item.
            /// </summary>
            [RepositoryItem("e4aee398-8e9c-4f1c-91d7-bbe0d3f6155d")]
            public virtual Ranorex.TabPage ConfigureScriptTab
            {
                get
                {
                    return _configurescripttabInfo.CreateAdapter<Ranorex.TabPage>(true);
                }
            }

            /// <summary>
            /// The ConfigureScriptTab item info.
            /// </summary>
            [RepositoryItemInfo("e4aee398-8e9c-4f1c-91d7-bbe0d3f6155d")]
            public virtual RepoItemInfo ConfigureScriptTabInfo
            {
                get
                {
                    return _configurescripttabInfo;
                }
            }

            /// <summary>
            /// The OptionsTab item.
            /// </summary>
            [RepositoryItem("d63db6ae-5900-4104-99fb-3fd4e325499f")]
            public virtual Ranorex.TabPage OptionsTab
            {
                get
                {
                    return _optionstabInfo.CreateAdapter<Ranorex.TabPage>(true);
                }
            }

            /// <summary>
            /// The OptionsTab item info.
            /// </summary>
            [RepositoryItemInfo("d63db6ae-5900-4104-99fb-3fd4e325499f")]
            public virtual RepoItemInfo OptionsTabInfo
            {
                get
                {
                    return _optionstabInfo;
                }
            }

            /// <summary>
            /// The ReviewTab item.
            /// </summary>
            [RepositoryItem("0cc7eb9f-0e6d-4faf-b833-39a7e0d48cb6")]
            public virtual Ranorex.TabPage ReviewTab
            {
                get
                {
                    return _reviewtabInfo.CreateAdapter<Ranorex.TabPage>(true);
                }
            }

            /// <summary>
            /// The ReviewTab item info.
            /// </summary>
            [RepositoryItemInfo("0cc7eb9f-0e6d-4faf-b833-39a7e0d48cb6")]
            public virtual RepoItemInfo ReviewTabInfo
            {
                get
                {
                    return _reviewtabInfo;
                }
            }

            /// <summary>
            /// The ReviewDependencyTab item.
            /// </summary>
            [RepositoryItem("62e09665-0db9-4ccc-b5c6-23cdcc4ac37e")]
            public virtual Ranorex.TabPage ReviewDependencyTab
            {
                get
                {
                    return _reviewdependencytabInfo.CreateAdapter<Ranorex.TabPage>(true);
                }
            }

            /// <summary>
            /// The ReviewDependencyTab item info.
            /// </summary>
            [RepositoryItemInfo("62e09665-0db9-4ccc-b5c6-23cdcc4ac37e")]
            public virtual RepoItemInfo ReviewDependencyTabInfo
            {
                get
                {
                    return _reviewdependencytabInfo;
                }
            }

            /// <summary>
            /// The SyncCheckbox item.
            /// </summary>
            [RepositoryItem("171b9aa5-851c-4dfa-98cf-b71168357cd9")]
            public virtual Ranorex.Cell SyncCheckbox
            {
                get
                {
                    return _synccheckboxInfo.CreateAdapter<Ranorex.Cell>(true);
                }
            }

            /// <summary>
            /// The SyncCheckbox item info.
            /// </summary>
            [RepositoryItemInfo("171b9aa5-851c-4dfa-98cf-b71168357cd9")]
            public virtual RepoItemInfo SyncCheckboxInfo
            {
                get
                {
                    return _synccheckboxInfo;
                }
            }

            /// <summary>
            /// The PreviousButton item.
            /// </summary>
            [RepositoryItem("21ecf66c-16aa-4674-ae32-e4906aebbf57")]
            public virtual Ranorex.Button PreviousButton
            {
                get
                {
                    return _previousbuttonInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The PreviousButton item info.
            /// </summary>
            [RepositoryItemInfo("21ecf66c-16aa-4674-ae32-e4906aebbf57")]
            public virtual RepoItemInfo PreviousButtonInfo
            {
                get
                {
                    return _previousbuttonInfo;
                }
            }
        }

        /// <summary>
        /// The DatastudioAppFolder folder.
        /// </summary>
        [RepositoryFolder("410638e4-bd48-4c9c-b9cd-aa828e1bf7ad")]
        public partial class DatastudioAppFolder : RepoGenBaseFolder
        {
            RepoItemInfo _comparetoolsInfo;
            RepoItemInfo _schemasynchonizationInfo;

            /// <summary>
            /// Creates a new Datastudio  folder.
            /// </summary>
            public DatastudioAppFolder(RepoGenBaseFolder parentFolder) :
                    base("Datastudio", "/form[@processname='datastudio']", parentFolder, 30000, null, true, "410638e4-bd48-4c9c-b9cd-aa828e1bf7ad", "")
            {
                _comparetoolsInfo = new RepoItemInfo(this, "CompareTools", ".//menuitem[@text='Compare Tools']", 30000, null, "e5777ca3-d77e-4173-9f53-a3ff9554588b");
                _schemasynchonizationInfo = new RepoItemInfo(this, "SchemaSynchonization", ".//menuitem[@text='Schema Synchronization']", 30000, null, "5589d930-9de4-419a-883b-b33634a46478");
            }

            /// <summary>
            /// The Self item.
            /// </summary>
            [RepositoryItem("410638e4-bd48-4c9c-b9cd-aa828e1bf7ad")]
            public virtual Ranorex.Form Self
            {
                get
                {
                    return _selfInfo.CreateAdapter<Ranorex.Form>(true);
                }
            }

            /// <summary>
            /// The Self item info.
            /// </summary>
            [RepositoryItemInfo("410638e4-bd48-4c9c-b9cd-aa828e1bf7ad")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }

            /// <summary>
            /// The CompareTools item.
            /// </summary>
            [RepositoryItem("e5777ca3-d77e-4173-9f53-a3ff9554588b")]
            public virtual Ranorex.MenuItem CompareTools
            {
                get
                {
                    return _comparetoolsInfo.CreateAdapter<Ranorex.MenuItem>(true);
                }
            }

            /// <summary>
            /// The CompareTools item info.
            /// </summary>
            [RepositoryItemInfo("e5777ca3-d77e-4173-9f53-a3ff9554588b")]
            public virtual RepoItemInfo CompareToolsInfo
            {
                get
                {
                    return _comparetoolsInfo;
                }
            }

            /// <summary>
            /// The SchemaSynchonization item.
            /// </summary>
            [RepositoryItem("5589d930-9de4-419a-883b-b33634a46478")]
            public virtual Ranorex.MenuItem SchemaSynchonization
            {
                get
                {
                    return _schemasynchonizationInfo.CreateAdapter<Ranorex.MenuItem>(true);
                }
            }

            /// <summary>
            /// The SchemaSynchonization item info.
            /// </summary>
            [RepositoryItemInfo("5589d930-9de4-419a-883b-b33634a46478")]
            public virtual RepoItemInfo SchemaSynchonizationInfo
            {
                get
                {
                    return _schemasynchonizationInfo;
                }
            }
        }

        /// <summary>
        /// The SchemaSynchronizationAppFolder folder.
        /// </summary>
        [RepositoryFolder("e41a53dc-f3c2-4cea-8aa6-21b67da9fb3f")]
        public partial class SchemaSynchronizationAppFolder : RepoGenBaseFolder
        {
            RepoItemInfo _choosesourceserverInfo;
            RepoItemInfo _choosetargetserverInfo;
            RepoItemInfo _sourceschemacomboboxInfo;
            RepoItemInfo _targetschemacomboboxInfo;
            RepoItemInfo _schemaobjectstableInfo;
            RepoItemInfo _unselectschemaobjectInfo;
            RepoItemInfo _unselectleftobjectsInfo;
            RepoItemInfo _unselectrightobjectsInfo;
            RepoItemInfo _comparebuttonInfo;
            RepoItemInfo _selectleftobjectsInfo;
            RepoItemInfo _selectrightobjectsInfo;

            /// <summary>
            /// Creates a new SchemaSynchronization  folder.
            /// </summary>
            public SchemaSynchronizationAppFolder(RepoGenBaseFolder parentFolder) :
                    base("SchemaSynchronization", "/form[@title~'^Schema\\ Synchronization\\ To']", parentFolder, 30000, null, true, "e41a53dc-f3c2-4cea-8aa6-21b67da9fb3f", "")
            {
                _choosesourceserverInfo = new RepoItemInfo(this, "ChooseSourceServer", ".//container[@type='JPanel']/container[@type='JPanel']//container[@name='Source']/?/?/button[@name='button']", 30000, null, "6e06d339-700b-4741-be98-6dda447b1ba4");
                _choosetargetserverInfo = new RepoItemInfo(this, "ChooseTargetServer", ".//container[@type='JPanel']/container[@type='JPanel']//container[@name='Target']/?/?/button[@name='button']", 30000, null, "9290b869-44f7-4d0d-a977-ffe4f436e8f9");
                _sourceschemacomboboxInfo = new RepoItemInfo(this, "SourceSchemaComboBox", ".//container[@type='JPanel']//container[@name='Source']/container[@name='panel']/?/?/container[@name='_objectHeaderPane']/combobox[@name='schemaField']/text[@type='BasicComboBoxEditor$BorderlessTextField']", 30000, null, "db652b00-efb4-4e50-b89c-ef8ae91ec59b");
                _targetschemacomboboxInfo = new RepoItemInfo(this, "TargetSchemaComboBox", ".//container[@type='JPanel']/container[2]//container[@name='Target']/container[@name='panel']//combobox[@name='schemaField']/text[@type='BasicComboBoxEditor$BorderlessTextField']", 30000, null, "52977c04-0727-4e92-a628-f3905686c09f");
                _schemaobjectstableInfo = new RepoItemInfo(this, "SchemaObjectsTable", ".//container[@name='typePanel']/?/?/container[@name='scroll']/container[5]/table[@name='table']", 30000, null, "3006e38a-0507-4d36-83a0-bf6e4be0ab28");
                _unselectschemaobjectInfo = new RepoItemInfo(this, "UnselectSchemaObject", ".//container[3]//container[@name='typePanel']/container[@name='typeSelector']/container[@name='buttonPanel']/button[@name='deselectButton']", 30000, null, "fccd9add-ccd5-4b1c-a431-6571ec596f38");
                _unselectleftobjectsInfo = new RepoItemInfo(this, "UnselectLeftObjects", ".//container[@type='JPanel']//container[@name='leftSelector']/container[@name='buttonPanel']/button[@name='deselectButton']", 30000, null, "f9c20b1b-0710-41a9-918b-8b81c91ca7ac");
                _unselectrightobjectsInfo = new RepoItemInfo(this, "UnselectRightObjects", ".//container[@type='JPanel']//container[@name='rightSelector']/container[@name='buttonPanel']/button[@name='deselectButton']", 30000, null, "2b63da80-4fd3-4a21-8f82-81d35de96137");
                _comparebuttonInfo = new RepoItemInfo(this, "CompareButton", ".//container[@type='JPanel']/?/?/button[@text='Compare']", 30000, null, "c4dfffe0-6a87-4173-8eaa-da6695b3446c");
                _selectleftobjectsInfo = new RepoItemInfo(this, "SelectLeftObjects", ".//container[@type='JPanel']//container[@name='leftSelector']/container[@name='buttonPanel']/button[@name='selectButton']", 30000, null, "4b714c3c-e2d0-4490-a8d9-ed3ba2619e1f");
                _selectrightobjectsInfo = new RepoItemInfo(this, "SelectRightObjects", ".//container[@type='JPanel']//container[@name='rightSelector']/container[@name='buttonPanel']/button[@name='selectButton']", 30000, null, "aaab43bd-fc04-4368-b6e8-432b7cd529a3");
            }

            /// <summary>
            /// The Self item.
            /// </summary>
            [RepositoryItem("e41a53dc-f3c2-4cea-8aa6-21b67da9fb3f")]
            public virtual Ranorex.Form Self
            {
                get
                {
                    return _selfInfo.CreateAdapter<Ranorex.Form>(true);
                }
            }

            /// <summary>
            /// The Self item info.
            /// </summary>
            [RepositoryItemInfo("e41a53dc-f3c2-4cea-8aa6-21b67da9fb3f")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }

            /// <summary>
            /// The ChooseSourceServer item.
            /// </summary>
            [RepositoryItem("6e06d339-700b-4741-be98-6dda447b1ba4")]
            public virtual Ranorex.Button ChooseSourceServer
            {
                get
                {
                    return _choosesourceserverInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The ChooseSourceServer item info.
            /// </summary>
            [RepositoryItemInfo("6e06d339-700b-4741-be98-6dda447b1ba4")]
            public virtual RepoItemInfo ChooseSourceServerInfo
            {
                get
                {
                    return _choosesourceserverInfo;
                }
            }

            /// <summary>
            /// The ChooseTargetServer item.
            /// </summary>
            [RepositoryItem("9290b869-44f7-4d0d-a977-ffe4f436e8f9")]
            public virtual Ranorex.Button ChooseTargetServer
            {
                get
                {
                    return _choosetargetserverInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The ChooseTargetServer item info.
            /// </summary>
            [RepositoryItemInfo("9290b869-44f7-4d0d-a977-ffe4f436e8f9")]
            public virtual RepoItemInfo ChooseTargetServerInfo
            {
                get
                {
                    return _choosetargetserverInfo;
                }
            }

            /// <summary>
            /// The SourceSchemaComboBox item.
            /// </summary>
            [RepositoryItem("db652b00-efb4-4e50-b89c-ef8ae91ec59b")]
            public virtual Ranorex.Text SourceSchemaComboBox
            {
                get
                {
                    return _sourceschemacomboboxInfo.CreateAdapter<Ranorex.Text>(true);
                }
            }

            /// <summary>
            /// The SourceSchemaComboBox item info.
            /// </summary>
            [RepositoryItemInfo("db652b00-efb4-4e50-b89c-ef8ae91ec59b")]
            public virtual RepoItemInfo SourceSchemaComboBoxInfo
            {
                get
                {
                    return _sourceschemacomboboxInfo;
                }
            }

            /// <summary>
            /// The TargetSchemaComboBox item.
            /// </summary>
            [RepositoryItem("52977c04-0727-4e92-a628-f3905686c09f")]
            public virtual Ranorex.Text TargetSchemaComboBox
            {
                get
                {
                    return _targetschemacomboboxInfo.CreateAdapter<Ranorex.Text>(true);
                }
            }

            /// <summary>
            /// The TargetSchemaComboBox item info.
            /// </summary>
            [RepositoryItemInfo("52977c04-0727-4e92-a628-f3905686c09f")]
            public virtual RepoItemInfo TargetSchemaComboBoxInfo
            {
                get
                {
                    return _targetschemacomboboxInfo;
                }
            }

            /// <summary>
            /// The SchemaObjectsTable item.
            /// </summary>
            [RepositoryItem("3006e38a-0507-4d36-83a0-bf6e4be0ab28")]
            public virtual Ranorex.Table SchemaObjectsTable
            {
                get
                {
                    return _schemaobjectstableInfo.CreateAdapter<Ranorex.Table>(true);
                }
            }

            /// <summary>
            /// The SchemaObjectsTable item info.
            /// </summary>
            [RepositoryItemInfo("3006e38a-0507-4d36-83a0-bf6e4be0ab28")]
            public virtual RepoItemInfo SchemaObjectsTableInfo
            {
                get
                {
                    return _schemaobjectstableInfo;
                }
            }

            /// <summary>
            /// The UnselectSchemaObject item.
            /// </summary>
            [RepositoryItem("fccd9add-ccd5-4b1c-a431-6571ec596f38")]
            public virtual Ranorex.Button UnselectSchemaObject
            {
                get
                {
                    return _unselectschemaobjectInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The UnselectSchemaObject item info.
            /// </summary>
            [RepositoryItemInfo("fccd9add-ccd5-4b1c-a431-6571ec596f38")]
            public virtual RepoItemInfo UnselectSchemaObjectInfo
            {
                get
                {
                    return _unselectschemaobjectInfo;
                }
            }

            /// <summary>
            /// The UnselectLeftObjects item.
            /// </summary>
            [RepositoryItem("f9c20b1b-0710-41a9-918b-8b81c91ca7ac")]
            public virtual Ranorex.Button UnselectLeftObjects
            {
                get
                {
                    return _unselectleftobjectsInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The UnselectLeftObjects item info.
            /// </summary>
            [RepositoryItemInfo("f9c20b1b-0710-41a9-918b-8b81c91ca7ac")]
            public virtual RepoItemInfo UnselectLeftObjectsInfo
            {
                get
                {
                    return _unselectleftobjectsInfo;
                }
            }

            /// <summary>
            /// The UnselectRightObjects item.
            /// </summary>
            [RepositoryItem("2b63da80-4fd3-4a21-8f82-81d35de96137")]
            public virtual Ranorex.Button UnselectRightObjects
            {
                get
                {
                    return _unselectrightobjectsInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The UnselectRightObjects item info.
            /// </summary>
            [RepositoryItemInfo("2b63da80-4fd3-4a21-8f82-81d35de96137")]
            public virtual RepoItemInfo UnselectRightObjectsInfo
            {
                get
                {
                    return _unselectrightobjectsInfo;
                }
            }

            /// <summary>
            /// The CompareButton item.
            /// </summary>
            [RepositoryItem("c4dfffe0-6a87-4173-8eaa-da6695b3446c")]
            public virtual Ranorex.Button CompareButton
            {
                get
                {
                    return _comparebuttonInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The CompareButton item info.
            /// </summary>
            [RepositoryItemInfo("c4dfffe0-6a87-4173-8eaa-da6695b3446c")]
            public virtual RepoItemInfo CompareButtonInfo
            {
                get
                {
                    return _comparebuttonInfo;
                }
            }

            /// <summary>
            /// The SelectLeftObjects item.
            /// </summary>
            [RepositoryItem("4b714c3c-e2d0-4490-a8d9-ed3ba2619e1f")]
            public virtual Ranorex.Button SelectLeftObjects
            {
                get
                {
                    return _selectleftobjectsInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The SelectLeftObjects item info.
            /// </summary>
            [RepositoryItemInfo("4b714c3c-e2d0-4490-a8d9-ed3ba2619e1f")]
            public virtual RepoItemInfo SelectLeftObjectsInfo
            {
                get
                {
                    return _selectleftobjectsInfo;
                }
            }

            /// <summary>
            /// The SelectRightObjects item.
            /// </summary>
            [RepositoryItem("aaab43bd-fc04-4368-b6e8-432b7cd529a3")]
            public virtual Ranorex.Button SelectRightObjects
            {
                get
                {
                    return _selectrightobjectsInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The SelectRightObjects item info.
            /// </summary>
            [RepositoryItemInfo("aaab43bd-fc04-4368-b6e8-432b7cd529a3")]
            public virtual RepoItemInfo SelectRightObjectsInfo
            {
                get
                {
                    return _selectrightobjectsInfo;
                }
            }
        }

        /// <summary>
        /// The ChooseServerAppFolder folder.
        /// </summary>
        [RepositoryFolder("bc082b9e-32e6-4741-a754-c25659504eb0")]
        public partial class ChooseServerAppFolder : RepoGenBaseFolder
        {
            RepoItemInfo _okbuttonInfo;
            RepoItemInfo _selectserverInfo;

            /// <summary>
            /// Creates a new ChooseServer  folder.
            /// </summary>
            public ChooseServerAppFolder(RepoGenBaseFolder parentFolder) :
                    base("ChooseServer", "/form[@title='Choose Server or Database']", parentFolder, 30000, null, true, "bc082b9e-32e6-4741-a754-c25659504eb0", "")
            {
                _okbuttonInfo = new RepoItemInfo(this, "OkButton", ".//button[@text='OK']", 30000, null, "7043b459-9408-4f08-b27b-f75e7b8ad03b");
                _selectserverInfo = new RepoItemInfo(this, "SelectServer", ".//container[@type='JScrollPane']/container[@name='viewport']/tree[@name='tree']", 30000, null, "0b74e676-b868-4952-a009-1067b73240e6");
            }

            /// <summary>
            /// The Self item.
            /// </summary>
            [RepositoryItem("bc082b9e-32e6-4741-a754-c25659504eb0")]
            public virtual Ranorex.Form Self
            {
                get
                {
                    return _selfInfo.CreateAdapter<Ranorex.Form>(true);
                }
            }

            /// <summary>
            /// The Self item info.
            /// </summary>
            [RepositoryItemInfo("bc082b9e-32e6-4741-a754-c25659504eb0")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }

            /// <summary>
            /// The OkButton item.
            /// </summary>
            [RepositoryItem("7043b459-9408-4f08-b27b-f75e7b8ad03b")]
            public virtual Ranorex.Button OkButton
            {
                get
                {
                    return _okbuttonInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The OkButton item info.
            /// </summary>
            [RepositoryItemInfo("7043b459-9408-4f08-b27b-f75e7b8ad03b")]
            public virtual RepoItemInfo OkButtonInfo
            {
                get
                {
                    return _okbuttonInfo;
                }
            }

            /// <summary>
            /// The SelectServer item.
            /// </summary>
            [RepositoryItem("0b74e676-b868-4952-a009-1067b73240e6")]
            public virtual Ranorex.Tree SelectServer
            {
                get
                {
                    return _selectserverInfo.CreateAdapter<Ranorex.Tree>(true);
                }
            }

            /// <summary>
            /// The SelectServer item info.
            /// </summary>
            [RepositoryItemInfo("0b74e676-b868-4952-a009-1067b73240e6")]
            public virtual RepoItemInfo SelectServerInfo
            {
                get
                {
                    return _selectserverInfo;
                }
            }
        }

    }
#pragma warning restore 0436
}