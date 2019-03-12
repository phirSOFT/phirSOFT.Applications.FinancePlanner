// --------------------------------------------------------------------------------------------------------------------
// <copyright company="phirSOFT" file="TreeViewItem.cs">
// Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
// <summary>
// phirSOFT Package phirSOFT.Controls.TreeView
// 
// Created by:    Philemon Eichin
// Created:       05.08.2017 22:25
// Last Modified: 05.08.2017 22:25
// </summary>
//  
// --------------------------------------------------------------------------------------------------------------------

using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Media;


namespace phirSOFT.Controls.TreeView
{
    public class TreeViewItem : ListViewItem
    {
   


        private ListView GetAncestorListView(TreeViewItem targetItem)
        {
            var treeViewItemAncestor = this as DependencyObject;
            ListView ancestorListView = null;
            while (treeViewItemAncestor != null && ancestorListView == null)
            {
                treeViewItemAncestor = VisualTreeHelper.GetParent(treeViewItemAncestor);
                ancestorListView = treeViewItemAncestor as ListView;
            }

            return ancestorListView;
        }





        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return base.OnCreateAutomationPeer();
        }

    }
}