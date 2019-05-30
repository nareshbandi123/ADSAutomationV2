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

namespace ADSAutomationPhaseII.TC_10595
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    /// The class representing the TC10595 element repository.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "8.2")]
    [RepositoryFolder("48cf942e-fcd5-4812-b716-277744c0d89d")]
    public partial class TC10595 : RepoGenBaseFolder
    {
        static TC10595 instance = new TC10595();
        TC10595Folders.VisualAnalyticsAppFolder _visualanalytics;
        TC10595Folders.SunAwtWindowAppFolder _sunawtwindow;
        TC10595Folders.DatastudioAppFolder _datastudio;
        TC10595Folders.EditColorAppFolder _editcolor;

        /// <summary>
        /// Gets the singleton class instance representing the TC10595 element repository.
        /// </summary>
        [RepositoryFolder("48cf942e-fcd5-4812-b716-277744c0d89d")]
        public static TC10595 Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// Repository class constructor.
        /// </summary>
        public TC10595() 
            : base("TC10595", "/", null, 0, false, "48cf942e-fcd5-4812-b716-277744c0d89d", ".\\RepositoryImages\\TC1059548cf942e.rximgres")
        {
            _visualanalytics = new TC10595Folders.VisualAnalyticsAppFolder(this);
            _sunawtwindow = new TC10595Folders.SunAwtWindowAppFolder(this);
            _datastudio = new TC10595Folders.DatastudioAppFolder(this);
            _editcolor = new TC10595Folders.EditColorAppFolder(this);
        }

#region Variables

#endregion

        /// <summary>
        /// The Self item info.
        /// </summary>
        [RepositoryItemInfo("48cf942e-fcd5-4812-b716-277744c0d89d")]
        public virtual RepoItemInfo SelfInfo
        {
            get
            {
                return _selfInfo;
            }
        }

        /// <summary>
        /// The VisualAnalytics folder.
        /// </summary>
        [RepositoryFolder("8745a962-587f-4e65-9182-ba36877e7d9c")]
        public virtual TC10595Folders.VisualAnalyticsAppFolder VisualAnalytics
        {
            get { return _visualanalytics; }
        }

        /// <summary>
        /// The SunAwtWindow folder.
        /// </summary>
        [RepositoryFolder("93ab8c12-bf4c-4885-8d3f-8d2b3c8d3ba7")]
        public virtual TC10595Folders.SunAwtWindowAppFolder SunAwtWindow
        {
            get { return _sunawtwindow; }
        }

        /// <summary>
        /// The Datastudio folder.
        /// </summary>
        [RepositoryFolder("4711d9c2-e000-49bb-b47d-a14752fe4159")]
        public virtual TC10595Folders.DatastudioAppFolder Datastudio
        {
            get { return _datastudio; }
        }

        /// <summary>
        /// The EditColor folder.
        /// </summary>
        [RepositoryFolder("086a8cb2-8cba-4544-b61e-fd0b9b5d721d")]
        public virtual TC10595Folders.EditColorAppFolder EditColor
        {
            get { return _editcolor; }
        }
    }

    /// <summary>
    /// Inner folder classes.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "8.2")]
    public partial class TC10595Folders
    {
        /// <summary>
        /// The VisualAnalyticsAppFolder folder.
        /// </summary>
        [RepositoryFolder("8745a962-587f-4e65-9182-ba36877e7d9c")]
        public partial class VisualAnalyticsAppFolder : RepoGenBaseFolder
        {
            TC10595Folders.ContainerContentPanelFolder _containercontentpanel;
            RepoItemInfo _horizonmapInfo;
            FullChartInfoClass _fullchartInfo;
            Band2InfoClass _band2Info;
            Band3InfoClass _band3Info;

            /// <summary>
            /// Creates a new VisualAnalytics  folder.
            /// </summary>
            public VisualAnalyticsAppFolder(RepoGenBaseFolder parentFolder) :
                    base("VisualAnalytics", "/form[@title~'^Visual\\ Analytics\\ -\\ \\[Sampl']", parentFolder, 30000, null, false, "8745a962-587f-4e65-9182-ba36877e7d9c", "")
            {
                _containercontentpanel = new TC10595Folders.ContainerContentPanelFolder(this);
                _horizonmapInfo = new RepoItemInfo(this, "HorizonMap", ".//container[@type='PaletteState$4']/container[1]/button[16]", 30000, null, "96f977b0-a729-414e-a602-3bf7266d5f2f");
                _fullchartInfo = new FullChartInfoClass(this);
                _band2Info = new Band2InfoClass(this);
                _band3Info = new Band3InfoClass(this);
            }

            /// <summary>
            /// The FullChartInfoClass folder.
            /// </summary>
            [RepositoryItemInfo("43233f2e-502d-4cc7-9c0e-53c784c8a895")]
            public class FullChartInfoClass : RepoItemInfo
            {
                /// <summary>
                /// FullChartInfoClass class constructor.
                /// </summary>
                public FullChartInfoClass(RepoGenBaseFolder parentFolder)
                    : base(parentFolder, "FullChart", ".//container[@name='_mainPanel']//container[@name='_sheetsPane']/container[@name='Worksheet 6']//container[@name='main']/container[@name='_cardPanel']/container[@name='_chartPanel']", 30000, null, "43233f2e-502d-4cc7-9c0e-53c784c8a895")
                { }

                /// <summary>
                /// Gets the FullChart item image.
                /// </summary>
                /// <returns>The FullChart image.</returns>
                [RepositoryImage("8ea672e7-ef55-4ca8-8926-9c9e2f065647")]
                public CompressedImage GetFullChart()
                {
                    return GetImage("8ea672e7-ef55-4ca8-8926-9c9e2f065647");
                }

                /// <summary>
                /// Gets the FullChart item image.
                /// </summary>
                /// <param name="cropRect">The bounds of the sub-image to return.</param>
                /// <returns>The cropped image.</returns>
                [RepositoryImage("8ea672e7-ef55-4ca8-8926-9c9e2f065647")]
                public CompressedImage GetFullChart(System.Drawing.Rectangle cropRect)
                {
                    return GetImage("8ea672e7-ef55-4ca8-8926-9c9e2f065647", cropRect);
                }
            }

            /// <summary>
            /// The Band2InfoClass folder.
            /// </summary>
            [RepositoryItemInfo("9cd02934-17e3-4b37-979c-f22cbbe993bf")]
            public class Band2InfoClass : RepoItemInfo
            {
                /// <summary>
                /// Band2InfoClass class constructor.
                /// </summary>
                public Band2InfoClass(RepoGenBaseFolder parentFolder)
                    : base(parentFolder, "Band2", ".//container[@name='_mainPanel']//container[@name='_sheetsPane']/container[@name='Worksheet 6']//container[@name='main']/container[@name='_cardPanel']/container[@name='_chartPanel']", 30000, null, "9cd02934-17e3-4b37-979c-f22cbbe993bf")
                { }

                /// <summary>
                /// Gets the Band2 item image.
                /// </summary>
                /// <returns>The Band2 image.</returns>
                [RepositoryImage("443b0a8a-baa3-4997-991e-50da88aba302")]
                public CompressedImage GetBand2()
                {
                    return GetImage("443b0a8a-baa3-4997-991e-50da88aba302");
                }

                /// <summary>
                /// Gets the Band2 item image.
                /// </summary>
                /// <param name="cropRect">The bounds of the sub-image to return.</param>
                /// <returns>The cropped image.</returns>
                [RepositoryImage("443b0a8a-baa3-4997-991e-50da88aba302")]
                public CompressedImage GetBand2(System.Drawing.Rectangle cropRect)
                {
                    return GetImage("443b0a8a-baa3-4997-991e-50da88aba302", cropRect);
                }
            }

            /// <summary>
            /// The Band3InfoClass folder.
            /// </summary>
            [RepositoryItemInfo("d4b1e110-f55b-4ad9-8e7d-824e804554ad")]
            public class Band3InfoClass : RepoItemInfo
            {
                /// <summary>
                /// Band3InfoClass class constructor.
                /// </summary>
                public Band3InfoClass(RepoGenBaseFolder parentFolder)
                    : base(parentFolder, "Band3", ".//container[@name='_mainPanel']//container[@name='_sheetsPane']/container[@name='Worksheet 6']//container[@name='main']/container[@name='_cardPanel']/container[@name='_chartPanel']", 30000, null, "d4b1e110-f55b-4ad9-8e7d-824e804554ad")
                { }

                /// <summary>
                /// Gets the Band3 item image.
                /// </summary>
                /// <returns>The Band3 image.</returns>
                [RepositoryImage("f1c5b4d3-df2b-4e90-a2cf-3a8ce3404877")]
                public CompressedImage GetBand3()
                {
                    return GetImage("f1c5b4d3-df2b-4e90-a2cf-3a8ce3404877");
                }

                /// <summary>
                /// Gets the Band3 item image.
                /// </summary>
                /// <param name="cropRect">The bounds of the sub-image to return.</param>
                /// <returns>The cropped image.</returns>
                [RepositoryImage("f1c5b4d3-df2b-4e90-a2cf-3a8ce3404877")]
                public CompressedImage GetBand3(System.Drawing.Rectangle cropRect)
                {
                    return GetImage("f1c5b4d3-df2b-4e90-a2cf-3a8ce3404877", cropRect);
                }
            }

            /// <summary>
            /// The Self item.
            /// </summary>
            [RepositoryItem("8745a962-587f-4e65-9182-ba36877e7d9c")]
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
            [RepositoryItemInfo("8745a962-587f-4e65-9182-ba36877e7d9c")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }

            /// <summary>
            /// The HorizonMap item.
            /// </summary>
            [RepositoryItem("96f977b0-a729-414e-a602-3bf7266d5f2f")]
            public virtual Ranorex.Button HorizonMap
            {
                get
                {
                    return _horizonmapInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The HorizonMap item info.
            /// </summary>
            [RepositoryItemInfo("96f977b0-a729-414e-a602-3bf7266d5f2f")]
            public virtual RepoItemInfo HorizonMapInfo
            {
                get
                {
                    return _horizonmapInfo;
                }
            }

            /// <summary>
            /// The FullChart item.
            /// </summary>
            [RepositoryItem("43233f2e-502d-4cc7-9c0e-53c784c8a895")]
            public virtual Ranorex.Container FullChart
            {
                get
                {
                    return _fullchartInfo.CreateAdapter<Ranorex.Container>(true);
                }
            }

            /// <summary>
            /// The FullChart item info.
            /// </summary>
            [RepositoryItemInfo("43233f2e-502d-4cc7-9c0e-53c784c8a895")]
            public virtual FullChartInfoClass FullChartInfo
            {
                get
                {
                    return _fullchartInfo;
                }
            }

            /// <summary>
            /// The Band2 item.
            /// </summary>
            [RepositoryItem("9cd02934-17e3-4b37-979c-f22cbbe993bf")]
            public virtual Ranorex.Container Band2
            {
                get
                {
                    return _band2Info.CreateAdapter<Ranorex.Container>(true);
                }
            }

            /// <summary>
            /// The Band2 item info.
            /// </summary>
            [RepositoryItemInfo("9cd02934-17e3-4b37-979c-f22cbbe993bf")]
            public virtual Band2InfoClass Band2Info
            {
                get
                {
                    return _band2Info;
                }
            }

            /// <summary>
            /// The Band3 item.
            /// </summary>
            [RepositoryItem("d4b1e110-f55b-4ad9-8e7d-824e804554ad")]
            public virtual Ranorex.Container Band3
            {
                get
                {
                    return _band3Info.CreateAdapter<Ranorex.Container>(true);
                }
            }

            /// <summary>
            /// The Band3 item info.
            /// </summary>
            [RepositoryItemInfo("d4b1e110-f55b-4ad9-8e7d-824e804554ad")]
            public virtual Band3InfoClass Band3Info
            {
                get
                {
                    return _band3Info;
                }
            }

            /// <summary>
            /// The ContainerContentPanel folder.
            /// </summary>
            [RepositoryFolder("72d324b0-5c84-4b6b-9fee-deb7e8cc836a")]
            public virtual TC10595Folders.ContainerContentPanelFolder ContainerContentPanel
            {
                get { return _containercontentpanel; }
            }
        }

        /// <summary>
        /// The ContainerContentPanelFolder folder.
        /// </summary>
        [RepositoryFolder("72d324b0-5c84-4b6b-9fee-deb7e8cc836a")]
        public partial class ContainerContentPanelFolder : RepoGenBaseFolder
        {
            RepoItemInfo _stockdateInfo;
            RepoItemInfo _stocksymbolInfo;
            RepoItemInfo _columnpanelInfo;
            RepoItemInfo _quarterstockdateInfo;
            RepoItemInfo _sumstockcloseInfo;
            RepoItemInfo _rowpanelInfo;
            RepoItemInfo _optionsInfo;
            RepoItemInfo _colorInfo;

            /// <summary>
            /// Creates a new ContainerContentPanel  folder.
            /// </summary>
            public ContainerContentPanelFolder(RepoGenBaseFolder parentFolder) :
                    base("ContainerContentPanel", "container[@name='_mainPanel']/container[@name='_contentPanel']", parentFolder, 30000, null, false, "72d324b0-5c84-4b6b-9fee-deb7e8cc836a", "")
            {
                _stockdateInfo = new RepoItemInfo(this, "StockDate", "?/?/container[@name='_leftPanel']//container[@type='BIDimensionDataPane']//container[@name='viewport']/list[@type='BIDraggableList']/listitem[@text='stock_date']", 30000, null, "2d1e2676-3db4-4938-94bd-400c899fc25f");
                _stocksymbolInfo = new RepoItemInfo(this, "StockSymbol", "?/?/container[@name='_leftPanel']//container[@type='BIDimensionDataPane']//container[@name='viewport']/list[@type='BIDraggableList']/listitem[@text='stock_symbol']", 30000, null, "0b2d65c2-84fd-4832-91d5-2b5bd0314405");
                _columnpanelInfo = new RepoItemInfo(this, "ColumnPanel", "container[@name='_splitPane']/container[@name='_sheetsPane']/container[@name='Worksheet 6']/container[@name='_worksheetPanel']//container[@name='cols']//container[@name='panel']", 30000, null, "54c2c514-661b-4c74-bb3a-9c021a3bf1c0");
                _quarterstockdateInfo = new RepoItemInfo(this, "QUARTERStockDate", "container[@name='_splitPane']/container[@name='_sheetsPane']/container[@name='Worksheet 6']/container[@name='_worksheetPanel']//container[@name='cols']//text[@caption='QUARTER(stock_date)']", 30000, null, "c69a86b4-ddaf-444f-9e54-9b5a4a357ffd");
                _sumstockcloseInfo = new RepoItemInfo(this, "SUMStockClose", "?/?/container[@name='_leftPanel']//container[@type='BIMeasureDataPane']//container[@name='viewport']/list[@type='BIDraggableList']/listitem[@text='SUM(stock_close)']", 30000, null, "2c829021-9103-4e7f-967b-46d1adc535af");
                _rowpanelInfo = new RepoItemInfo(this, "RowPanel", "container[@name='_splitPane']/container[@name='_sheetsPane']/container[@name='Worksheet 6']/container[@name='_worksheetPanel']//container[@name='rows']//container[@name='panel']", 30000, null, "282ba57b-4f6c-4c5d-8e60-b8f1120f89ae");
                _optionsInfo = new RepoItemInfo(this, "Options", "container[@name='_splitPane']/container[@name='_sheetsPane']/container[@name='Worksheet 6']/container[@name='_worksheetPanel']/container[@name='_contentPanel']//container[@name='marks']//text[@caption='Options']", 30000, null, "e57a8e09-13fb-4f32-bfb7-c1b61e0edabb");
                _colorInfo = new RepoItemInfo(this, "Color", "container[@name='_splitPane']/container[@name='_sheetsPane']/container[@name='Worksheet 6']/container[@name='_worksheetPanel']/container[@name='_contentPanel']//container[@name='marks']//text[@caption='Color']", 30000, null, "1e733da8-c5dc-439f-83ed-783eb21c7dc3");
            }

            /// <summary>
            /// The Self item.
            /// </summary>
            [RepositoryItem("72d324b0-5c84-4b6b-9fee-deb7e8cc836a")]
            public virtual Ranorex.Container Self
            {
                get
                {
                    return _selfInfo.CreateAdapter<Ranorex.Container>(true);
                }
            }

            /// <summary>
            /// The Self item info.
            /// </summary>
            [RepositoryItemInfo("72d324b0-5c84-4b6b-9fee-deb7e8cc836a")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }

            /// <summary>
            /// The StockDate item.
            /// </summary>
            [RepositoryItem("2d1e2676-3db4-4938-94bd-400c899fc25f")]
            public virtual Ranorex.ListItem StockDate
            {
                get
                {
                    return _stockdateInfo.CreateAdapter<Ranorex.ListItem>(true);
                }
            }

            /// <summary>
            /// The StockDate item info.
            /// </summary>
            [RepositoryItemInfo("2d1e2676-3db4-4938-94bd-400c899fc25f")]
            public virtual RepoItemInfo StockDateInfo
            {
                get
                {
                    return _stockdateInfo;
                }
            }

            /// <summary>
            /// The StockSymbol item.
            /// </summary>
            [RepositoryItem("0b2d65c2-84fd-4832-91d5-2b5bd0314405")]
            public virtual Ranorex.ListItem StockSymbol
            {
                get
                {
                    return _stocksymbolInfo.CreateAdapter<Ranorex.ListItem>(true);
                }
            }

            /// <summary>
            /// The StockSymbol item info.
            /// </summary>
            [RepositoryItemInfo("0b2d65c2-84fd-4832-91d5-2b5bd0314405")]
            public virtual RepoItemInfo StockSymbolInfo
            {
                get
                {
                    return _stocksymbolInfo;
                }
            }

            /// <summary>
            /// The ColumnPanel item.
            /// </summary>
            [RepositoryItem("54c2c514-661b-4c74-bb3a-9c021a3bf1c0")]
            public virtual Ranorex.Container ColumnPanel
            {
                get
                {
                    return _columnpanelInfo.CreateAdapter<Ranorex.Container>(true);
                }
            }

            /// <summary>
            /// The ColumnPanel item info.
            /// </summary>
            [RepositoryItemInfo("54c2c514-661b-4c74-bb3a-9c021a3bf1c0")]
            public virtual RepoItemInfo ColumnPanelInfo
            {
                get
                {
                    return _columnpanelInfo;
                }
            }

            /// <summary>
            /// The QUARTERStockDate item.
            /// </summary>
            [RepositoryItem("c69a86b4-ddaf-444f-9e54-9b5a4a357ffd")]
            public virtual Ranorex.Text QUARTERStockDate
            {
                get
                {
                    return _quarterstockdateInfo.CreateAdapter<Ranorex.Text>(true);
                }
            }

            /// <summary>
            /// The QUARTERStockDate item info.
            /// </summary>
            [RepositoryItemInfo("c69a86b4-ddaf-444f-9e54-9b5a4a357ffd")]
            public virtual RepoItemInfo QUARTERStockDateInfo
            {
                get
                {
                    return _quarterstockdateInfo;
                }
            }

            /// <summary>
            /// The SUMStockClose item.
            /// </summary>
            [RepositoryItem("2c829021-9103-4e7f-967b-46d1adc535af")]
            public virtual Ranorex.ListItem SUMStockClose
            {
                get
                {
                    return _sumstockcloseInfo.CreateAdapter<Ranorex.ListItem>(true);
                }
            }

            /// <summary>
            /// The SUMStockClose item info.
            /// </summary>
            [RepositoryItemInfo("2c829021-9103-4e7f-967b-46d1adc535af")]
            public virtual RepoItemInfo SUMStockCloseInfo
            {
                get
                {
                    return _sumstockcloseInfo;
                }
            }

            /// <summary>
            /// The RowPanel item.
            /// </summary>
            [RepositoryItem("282ba57b-4f6c-4c5d-8e60-b8f1120f89ae")]
            public virtual Ranorex.Container RowPanel
            {
                get
                {
                    return _rowpanelInfo.CreateAdapter<Ranorex.Container>(true);
                }
            }

            /// <summary>
            /// The RowPanel item info.
            /// </summary>
            [RepositoryItemInfo("282ba57b-4f6c-4c5d-8e60-b8f1120f89ae")]
            public virtual RepoItemInfo RowPanelInfo
            {
                get
                {
                    return _rowpanelInfo;
                }
            }

            /// <summary>
            /// The Options item.
            /// </summary>
            [RepositoryItem("e57a8e09-13fb-4f32-bfb7-c1b61e0edabb")]
            public virtual Ranorex.Text Options
            {
                get
                {
                    return _optionsInfo.CreateAdapter<Ranorex.Text>(true);
                }
            }

            /// <summary>
            /// The Options item info.
            /// </summary>
            [RepositoryItemInfo("e57a8e09-13fb-4f32-bfb7-c1b61e0edabb")]
            public virtual RepoItemInfo OptionsInfo
            {
                get
                {
                    return _optionsInfo;
                }
            }

            /// <summary>
            /// The Color item.
            /// </summary>
            [RepositoryItem("1e733da8-c5dc-439f-83ed-783eb21c7dc3")]
            public virtual Ranorex.Text Color
            {
                get
                {
                    return _colorInfo.CreateAdapter<Ranorex.Text>(true);
                }
            }

            /// <summary>
            /// The Color item info.
            /// </summary>
            [RepositoryItemInfo("1e733da8-c5dc-439f-83ed-783eb21c7dc3")]
            public virtual RepoItemInfo ColorInfo
            {
                get
                {
                    return _colorInfo;
                }
            }
        }

        /// <summary>
        /// The SunAwtWindowAppFolder folder.
        /// </summary>
        [RepositoryFolder("93ab8c12-bf4c-4885-8d3f-8d2b3c8d3ba7")]
        public partial class SunAwtWindowAppFolder : RepoGenBaseFolder
        {
            RepoItemInfo _weeknumberweek12013Info;
            RepoItemInfo _redgreendivergingInfo;
            RepoItemInfo _addtocolumnsdeckInfo;
            RepoItemInfo _addtorowsdeckInfo;

            /// <summary>
            /// Creates a new SunAwtWindow  folder.
            /// </summary>
            public SunAwtWindowAppFolder(RepoGenBaseFolder parentFolder) :
                    base("SunAwtWindow", "/form[@class='SunAwtWindow']", parentFolder, 30000, null, false, "93ab8c12-bf4c-4885-8d3f-8d2b3c8d3ba7", "")
            {
                _weeknumberweek12013Info = new RepoItemInfo(this, "WeekNumberWeek12013", "?/?/menuitem[@text~'^Week\\ Number\\ \\(Week\\ 1,\\ 2013']", 30000, null, "8b8f10b1-66ec-4cdc-9deb-96bc22038881");
                _redgreendivergingInfo = new RepoItemInfo(this, "RedGreenDiverging", ".//container[@name='viewport']/list[@name='ComboBox.list']/listitem[@text='Red-Green Diverging']", 30000, null, "b0d5082f-fa2c-458a-aed6-49731cd31adf");
                _addtocolumnsdeckInfo = new RepoItemInfo(this, "AddToColumnsDeck", ".//menuitem[@text='Add To Columns Deck']", 30000, null, "f4974b34-ecf9-45dc-94c1-f993e4e232f1");
                _addtorowsdeckInfo = new RepoItemInfo(this, "AddToRowsDeck", ".//menuitem[@text='Add To Rows Deck']", 30000, null, "9afb20f7-9f0a-4f00-ab8f-6dcb4841320d");
            }

            /// <summary>
            /// The Self item.
            /// </summary>
            [RepositoryItem("93ab8c12-bf4c-4885-8d3f-8d2b3c8d3ba7")]
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
            [RepositoryItemInfo("93ab8c12-bf4c-4885-8d3f-8d2b3c8d3ba7")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }

            /// <summary>
            /// The WeekNumberWeek12013 item.
            /// </summary>
            [RepositoryItem("8b8f10b1-66ec-4cdc-9deb-96bc22038881")]
            public virtual Ranorex.MenuItem WeekNumberWeek12013
            {
                get
                {
                    return _weeknumberweek12013Info.CreateAdapter<Ranorex.MenuItem>(true);
                }
            }

            /// <summary>
            /// The WeekNumberWeek12013 item info.
            /// </summary>
            [RepositoryItemInfo("8b8f10b1-66ec-4cdc-9deb-96bc22038881")]
            public virtual RepoItemInfo WeekNumberWeek12013Info
            {
                get
                {
                    return _weeknumberweek12013Info;
                }
            }

            /// <summary>
            /// The RedGreenDiverging item.
            /// </summary>
            [RepositoryItem("b0d5082f-fa2c-458a-aed6-49731cd31adf")]
            public virtual Ranorex.ListItem RedGreenDiverging
            {
                get
                {
                    return _redgreendivergingInfo.CreateAdapter<Ranorex.ListItem>(true);
                }
            }

            /// <summary>
            /// The RedGreenDiverging item info.
            /// </summary>
            [RepositoryItemInfo("b0d5082f-fa2c-458a-aed6-49731cd31adf")]
            public virtual RepoItemInfo RedGreenDivergingInfo
            {
                get
                {
                    return _redgreendivergingInfo;
                }
            }

            /// <summary>
            /// The AddToColumnsDeck item.
            /// </summary>
            [RepositoryItem("f4974b34-ecf9-45dc-94c1-f993e4e232f1")]
            public virtual Ranorex.MenuItem AddToColumnsDeck
            {
                get
                {
                    return _addtocolumnsdeckInfo.CreateAdapter<Ranorex.MenuItem>(true);
                }
            }

            /// <summary>
            /// The AddToColumnsDeck item info.
            /// </summary>
            [RepositoryItemInfo("f4974b34-ecf9-45dc-94c1-f993e4e232f1")]
            public virtual RepoItemInfo AddToColumnsDeckInfo
            {
                get
                {
                    return _addtocolumnsdeckInfo;
                }
            }

            /// <summary>
            /// The AddToRowsDeck item.
            /// </summary>
            [RepositoryItem("9afb20f7-9f0a-4f00-ab8f-6dcb4841320d")]
            public virtual Ranorex.MenuItem AddToRowsDeck
            {
                get
                {
                    return _addtorowsdeckInfo.CreateAdapter<Ranorex.MenuItem>(true);
                }
            }

            /// <summary>
            /// The AddToRowsDeck item info.
            /// </summary>
            [RepositoryItemInfo("9afb20f7-9f0a-4f00-ab8f-6dcb4841320d")]
            public virtual RepoItemInfo AddToRowsDeckInfo
            {
                get
                {
                    return _addtorowsdeckInfo;
                }
            }
        }

        /// <summary>
        /// The DatastudioAppFolder folder.
        /// </summary>
        [RepositoryFolder("4711d9c2-e000-49bb-b47d-a14752fe4159")]
        public partial class DatastudioAppFolder : RepoGenBaseFolder
        {
            RepoItemInfo _radiobutton2bandsInfo;
            RepoItemInfo _radiobutton3bandsInfo;

            /// <summary>
            /// Creates a new Datastudio  folder.
            /// </summary>
            public DatastudioAppFolder(RepoGenBaseFolder parentFolder) :
                    base("Datastudio", "/form[@title='' and @processname='datastudio']", parentFolder, 30000, null, false, "4711d9c2-e000-49bb-b47d-a14752fe4159", "")
            {
                _radiobutton2bandsInfo = new RepoItemInfo(this, "RadioButton2Bands", "?/?/container[@accessiblename='Bands']/?/?/radiobutton[@text='2 Bands']", 30000, null, "cdd6234d-e86f-471b-8784-d8139f92cc36");
                _radiobutton3bandsInfo = new RepoItemInfo(this, "RadioButton3Bands", "?/?/container[@accessiblename='Bands']/?/?/radiobutton[@text='3 Bands']", 30000, null, "9ce52f77-7026-4c93-96f9-253cbb2b0973");
            }

            /// <summary>
            /// The Self item.
            /// </summary>
            [RepositoryItem("4711d9c2-e000-49bb-b47d-a14752fe4159")]
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
            [RepositoryItemInfo("4711d9c2-e000-49bb-b47d-a14752fe4159")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }

            /// <summary>
            /// The RadioButton2Bands item.
            /// </summary>
            [RepositoryItem("cdd6234d-e86f-471b-8784-d8139f92cc36")]
            public virtual Ranorex.RadioButton RadioButton2Bands
            {
                get
                {
                    return _radiobutton2bandsInfo.CreateAdapter<Ranorex.RadioButton>(true);
                }
            }

            /// <summary>
            /// The RadioButton2Bands item info.
            /// </summary>
            [RepositoryItemInfo("cdd6234d-e86f-471b-8784-d8139f92cc36")]
            public virtual RepoItemInfo RadioButton2BandsInfo
            {
                get
                {
                    return _radiobutton2bandsInfo;
                }
            }

            /// <summary>
            /// The RadioButton3Bands item.
            /// </summary>
            [RepositoryItem("9ce52f77-7026-4c93-96f9-253cbb2b0973")]
            public virtual Ranorex.RadioButton RadioButton3Bands
            {
                get
                {
                    return _radiobutton3bandsInfo.CreateAdapter<Ranorex.RadioButton>(true);
                }
            }

            /// <summary>
            /// The RadioButton3Bands item info.
            /// </summary>
            [RepositoryItemInfo("9ce52f77-7026-4c93-96f9-253cbb2b0973")]
            public virtual RepoItemInfo RadioButton3BandsInfo
            {
                get
                {
                    return _radiobutton3bandsInfo;
                }
            }
        }

        /// <summary>
        /// The EditColorAppFolder folder.
        /// </summary>
        [RepositoryFolder("086a8cb2-8cba-4544-b61e-fd0b9b5d721d")]
        public partial class EditColorAppFolder : RepoGenBaseFolder
        {
            RepoItemInfo _windowscomboboxuidollarxpcomboboxbuttonInfo;
            RepoItemInfo _buttonokInfo;

            /// <summary>
            /// Creates a new EditColor  folder.
            /// </summary>
            public EditColorAppFolder(RepoGenBaseFolder parentFolder) :
                    base("EditColor", "/form[@title='Edit Color']", parentFolder, 30000, null, false, "086a8cb2-8cba-4544-b61e-fd0b9b5d721d", "")
            {
                _windowscomboboxuidollarxpcomboboxbuttonInfo = new RepoItemInfo(this, "WindowsComboBoxUIDollarXPComboBoxButton", "container[@type='CPanel']//combobox[@name='themeChooserComboBox']/button[@text='']", 30000, null, "d5659012-c6cc-4198-bd97-03feffc52dfb");
                _buttonokInfo = new RepoItemInfo(this, "ButtonOK", "container[@type='CPanel']//button[@name='defaultButton']", 30000, null, "50590dd8-f188-4724-be0a-0a6b8b450695");
            }

            /// <summary>
            /// The Self item.
            /// </summary>
            [RepositoryItem("086a8cb2-8cba-4544-b61e-fd0b9b5d721d")]
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
            [RepositoryItemInfo("086a8cb2-8cba-4544-b61e-fd0b9b5d721d")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }

            /// <summary>
            /// The WindowsComboBoxUIDollarXPComboBoxButton item.
            /// </summary>
            [RepositoryItem("d5659012-c6cc-4198-bd97-03feffc52dfb")]
            public virtual Ranorex.Button WindowsComboBoxUIDollarXPComboBoxButton
            {
                get
                {
                    return _windowscomboboxuidollarxpcomboboxbuttonInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The WindowsComboBoxUIDollarXPComboBoxButton item info.
            /// </summary>
            [RepositoryItemInfo("d5659012-c6cc-4198-bd97-03feffc52dfb")]
            public virtual RepoItemInfo WindowsComboBoxUIDollarXPComboBoxButtonInfo
            {
                get
                {
                    return _windowscomboboxuidollarxpcomboboxbuttonInfo;
                }
            }

            /// <summary>
            /// The ButtonOK item.
            /// </summary>
            [RepositoryItem("50590dd8-f188-4724-be0a-0a6b8b450695")]
            public virtual Ranorex.Button ButtonOK
            {
                get
                {
                    return _buttonokInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The ButtonOK item info.
            /// </summary>
            [RepositoryItemInfo("50590dd8-f188-4724-be0a-0a6b8b450695")]
            public virtual RepoItemInfo ButtonOKInfo
            {
                get
                {
                    return _buttonokInfo;
                }
            }
        }

    }
#pragma warning restore 0436
}