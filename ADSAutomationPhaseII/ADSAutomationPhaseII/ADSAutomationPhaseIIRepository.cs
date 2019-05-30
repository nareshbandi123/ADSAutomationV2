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

namespace ADSAutomationPhaseII
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    /// The class representing the ADSAutomationPhaseIIRepository element repository.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "8.2")]
    [RepositoryFolder("8909ef0f-20d8-4dc4-9244-61c3b1217d2d")]
    public partial class ADSAutomationPhaseIIRepository : RepoGenBaseFolder
    {
        static ADSAutomationPhaseIIRepository instance = new ADSAutomationPhaseIIRepository();
        ADSAutomationPhaseIIRepositoryFolders.VisualAnalyticsTestFilterVizxAstAppFolder _visualanalyticstestfiltervizxast;
        ADSAutomationPhaseIIRepositoryFolders.DatastudioAppFolder _datastudio;

        /// <summary>
        /// Gets the singleton class instance representing the ADSAutomationPhaseIIRepository element repository.
        /// </summary>
        [RepositoryFolder("8909ef0f-20d8-4dc4-9244-61c3b1217d2d")]
        public static ADSAutomationPhaseIIRepository Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// Repository class constructor.
        /// </summary>
        public ADSAutomationPhaseIIRepository() 
            : base("ADSAutomationPhaseIIRepository", "/", null, 0, false, "8909ef0f-20d8-4dc4-9244-61c3b1217d2d", ".\\RepositoryImages\\ADSAutomationPhaseIIRepository8909ef0f.rximgres")
        {
            _visualanalyticstestfiltervizxast = new ADSAutomationPhaseIIRepositoryFolders.VisualAnalyticsTestFilterVizxAstAppFolder(this);
            _datastudio = new ADSAutomationPhaseIIRepositoryFolders.DatastudioAppFolder(this);
        }

#region Variables

#endregion

        /// <summary>
        /// The Self item info.
        /// </summary>
        [RepositoryItemInfo("8909ef0f-20d8-4dc4-9244-61c3b1217d2d")]
        public virtual RepoItemInfo SelfInfo
        {
            get
            {
                return _selfInfo;
            }
        }

        /// <summary>
        /// The VisualAnalyticsTestFilterVizxAst folder.
        /// </summary>
        [RepositoryFolder("cba1ae00-c8c2-4f11-ae70-ce407ea89a34")]
        public virtual ADSAutomationPhaseIIRepositoryFolders.VisualAnalyticsTestFilterVizxAstAppFolder VisualAnalyticsTestFilterVizxAst
        {
            get { return _visualanalyticstestfiltervizxast; }
        }

        /// <summary>
        /// The Datastudio folder.
        /// </summary>
        [RepositoryFolder("eef83530-0e85-4758-ae9a-2a6e4dcb37ce")]
        public virtual ADSAutomationPhaseIIRepositoryFolders.DatastudioAppFolder Datastudio
        {
            get { return _datastudio; }
        }
    }

    /// <summary>
    /// Inner folder classes.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "8.2")]
    public partial class ADSAutomationPhaseIIRepositoryFolders
    {
        /// <summary>
        /// The VisualAnalyticsTestFilterVizxAstAppFolder folder.
        /// </summary>
        [RepositoryFolder("cba1ae00-c8c2-4f11-ae70-ce407ea89a34")]
        public partial class VisualAnalyticsTestFilterVizxAstAppFolder : RepoGenBaseFolder
        {
            RepoItemInfo _bichartoverlaypanelInfo;

            /// <summary>
            /// Creates a new VisualAnalyticsTestFilterVizxAst  folder.
            /// </summary>
            public VisualAnalyticsTestFilterVizxAstAppFolder(RepoGenBaseFolder parentFolder) :
                    base("VisualAnalyticsTestFilterVizxAst", "/form[@title~'^Visual\\ Analytics\\ -\\ \\[test-']", parentFolder, 30000, null, false, "cba1ae00-c8c2-4f11-ae70-ce407ea89a34", "")
            {
                _bichartoverlaypanelInfo = new RepoItemInfo(this, "BIChartOverlayPanel", "container[@name='_mainPanel']//container[@name='_sheetsPane']/container[@name='Worksheet 4']//container[@name='main']/container[@name='_cardPanel']/container[@name='_chartPanel']/container/container[89]", 30000, null, "aab215c0-32c2-483a-a227-585102b11960");
            }

            /// <summary>
            /// The Self item.
            /// </summary>
            [RepositoryItem("cba1ae00-c8c2-4f11-ae70-ce407ea89a34")]
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
            [RepositoryItemInfo("cba1ae00-c8c2-4f11-ae70-ce407ea89a34")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }

            /// <summary>
            /// The BIChartOverlayPanel item.
            /// </summary>
            [RepositoryItem("aab215c0-32c2-483a-a227-585102b11960")]
            public virtual Ranorex.Container BIChartOverlayPanel
            {
                get
                {
                    return _bichartoverlaypanelInfo.CreateAdapter<Ranorex.Container>(true);
                }
            }

            /// <summary>
            /// The BIChartOverlayPanel item info.
            /// </summary>
            [RepositoryItemInfo("aab215c0-32c2-483a-a227-585102b11960")]
            public virtual RepoItemInfo BIChartOverlayPanelInfo
            {
                get
                {
                    return _bichartoverlaypanelInfo;
                }
            }
        }

        /// <summary>
        /// The DatastudioAppFolder folder.
        /// </summary>
        [RepositoryFolder("eef83530-0e85-4758-ae9a-2a6e4dcb37ce")]
        public partial class DatastudioAppFolder : RepoGenBaseFolder
        {
            RepoItemInfo _excludeInfo;

            /// <summary>
            /// Creates a new Datastudio  folder.
            /// </summary>
            public DatastudioAppFolder(RepoGenBaseFolder parentFolder) :
                    base("Datastudio", "/form[@class='SunAwtWindow']", parentFolder, 30000, null, false, "eef83530-0e85-4758-ae9a-2a6e4dcb37ce", "")
            {
                _excludeInfo = new RepoItemInfo(this, "Exclude", "contextmenu[@type='TooltipContainer']//button[@text='Exclude']", 30000, null, "a2b9d850-e585-4d35-9d78-1e1403219e6c");
            }

            /// <summary>
            /// The Self item.
            /// </summary>
            [RepositoryItem("eef83530-0e85-4758-ae9a-2a6e4dcb37ce")]
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
            [RepositoryItemInfo("eef83530-0e85-4758-ae9a-2a6e4dcb37ce")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }

            /// <summary>
            /// The Exclude item.
            /// </summary>
            [RepositoryItem("a2b9d850-e585-4d35-9d78-1e1403219e6c")]
            public virtual Ranorex.Button Exclude
            {
                get
                {
                    return _excludeInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The Exclude item info.
            /// </summary>
            [RepositoryItemInfo("a2b9d850-e585-4d35-9d78-1e1403219e6c")]
            public virtual RepoItemInfo ExcludeInfo
            {
                get
                {
                    return _excludeInfo;
                }
            }
        }

    }
#pragma warning restore 0436
}