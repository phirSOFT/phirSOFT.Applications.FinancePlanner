// --------------------------------------------------------------------------------------------------------------------
// <copyright company="phirSOFT" file="Ribbon.cs">
// Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
// <summary>
// phirSOFT Package phirSOFT.Applications.FinancePlanner
// 
// Created by:    Philemon Eichin
// Created:       19.11.2016 15:44
// Last Modified: 19.11.2016 15:44
// </summary>
//  
// --------------------------------------------------------------------------------------------------------------------

using System;
using RibbonLib.Controls;

namespace phirSOFT.Applications.FinancePlanner
{
    public partial class Ribbon : RibbonLib.Ribbon
    {
        private const uint Main = 1000;
        private const uint Categories = 2000;
        private const uint CategoriesTools = 2500;
        private const uint Windows = 3000;
        private const uint Connection = 1100;
        private const uint Connect = 1101;
        private const uint Disconnect = 1102;
        private const uint ConnectTo = 1103;
        private const uint Reconnect = 1104;
        private const uint EditCategory = 2100;
        private const uint ChangeCategory = 2200;
        private const uint Delete = 2101;
        private const uint Join = 2102;
        private const uint Add = 2103;
        private const uint Edit = 2104;
        private const uint Move = 2105;
        private const uint Accept = 2201;
        private const uint Discard = 2202;
        private const uint WindowsGroup = 3100;
        private const uint CategoryEditor = 3001;
        private const uint Log = 3002;
        private const uint TransactionOverview = 3003;
        private const uint Reminder = 3004;
        private const uint Search = 3005;
        private const uint TransactionEditor = 3006;
        private const uint AnnualReport = 3007;
        private const uint ApplicationMenu = 10000;
        private const uint QuickAccessToolbar = 20000;
        private const uint Help = 30000;
        private const uint ChangesToolbar = 40001;
        private const uint EditCategoriesContext = 50001;
        public RibbonQuickAccessToolbar QuickAccessToolbarQuickAccessToolbar { get; }
        public RibbonHelpButton HelpHelpButton{get;}
        public RibbonApplicationMenu ApplicationMenuApplicationMenu{get;}
        public RibbonButton ConnectButton{get;}
        public RibbonDropDownButton ConnectToDropDownButton{get;}
        public RibbonTab MainTab{get;}
        public RibbonGroup ConnectionGroup{get;}
        public RibbonButton DisconnectButton{get;}
        public RibbonButton ReconnectButton{get;}
        public RibbonTab WindowsTab{get;}
        public RibbonGroup WindowsGroupGroup{get;}
        public RibbonButton CategoryEditorButton{get;}
        public RibbonButton LogButton{get;}
        public RibbonButton TransactionOverviewButton{get;}
        public RibbonButton ReminderButton{get;}
        public RibbonButton SearchButton{get;}
        public RibbonButton TransactionEditorButton{get;}
        public RibbonButton AnnualReportButton{get;}
        public RibbonTabGroup CategoriesToolsTabGroup{get;}
        public RibbonTab CategoriesTab{get;}
        public RibbonGroup EditCategoryGroup{get;}
        public RibbonButton AddButton{get;}
        public RibbonButton DeleteButton{get;}
        public RibbonButton EditButton{get;}
        public RibbonButton MoveButton{get;}
        public RibbonButton JoinButton{get;}
        public RibbonGroup ChangeCategoryGroup{get;}
        public RibbonButton AcceptButton{get;}
        public RibbonButton DiscardButton{get;}

        public static readonly Lazy<Ribbon> Instance = new Lazy<Ribbon>(() => new Ribbon());
        

        private Ribbon()
        {
            QuickAccessToolbarQuickAccessToolbar = new RibbonQuickAccessToolbar(this, QuickAccessToolbar);
            HelpHelpButton = new RibbonHelpButton(this, Help);
            ApplicationMenuApplicationMenu = new RibbonApplicationMenu(this, ApplicationMenu);
            ConnectButton = new RibbonButton(this, Connect);
            ConnectToDropDownButton = new RibbonDropDownButton(this, ConnectTo);
            MainTab = new RibbonTab(this, Main);
            ConnectionGroup = new RibbonGroup(this, Connection);
            DisconnectButton = new RibbonButton(this, Disconnect);
            ReconnectButton = new RibbonButton(this, Reconnect);
            WindowsTab = new RibbonTab(this, Windows);
            WindowsGroupGroup = new RibbonGroup(this, WindowsGroup);
            CategoryEditorButton = new RibbonButton(this, CategoryEditor);
            LogButton = new RibbonButton(this, Log);
            TransactionOverviewButton = new RibbonButton(this, TransactionOverview);
            ReminderButton = new RibbonButton(this, Reminder);
            SearchButton = new RibbonButton(this, Search);
            TransactionEditorButton = new RibbonButton(this, TransactionEditor);
            AnnualReportButton = new RibbonButton(this, AnnualReport);
            CategoriesToolsTabGroup = new RibbonTabGroup(this, CategoriesTools);
            CategoriesTab = new RibbonTab(this, Categories);
            EditCategoryGroup = new RibbonGroup(this, EditCategory);
            AddButton = new RibbonButton(this, Add);
            DeleteButton = new RibbonButton(this, Delete);
            EditButton = new RibbonButton(this, Edit);
            MoveButton = new RibbonButton(this, Move);
            JoinButton = new RibbonButton(this, Join);
            ChangeCategoryGroup = new RibbonGroup(this, ChangeCategory);
            AcceptButton = new RibbonButton(this, Accept);
            DiscardButton = new RibbonButton(this, Discard);
        }
    }
}