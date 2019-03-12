// --------------------------------------------------------------------------------------------------------------------
// <copyright company="phirSOFT" file="JoinCategoriesDialog.cs">
// Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
// <summary>
// phirSOFT Package phirSOFT.Applications.FinancePlanner
// 
// Created by:    Philemon Eichin
// Created:       19.11.2016 21:24
// Last Modified: 19.11.2016 21:24
// </summary>
//  
// --------------------------------------------------------------------------------------------------------------------

using Microsoft.WindowsAPICodePack.Dialogs;

namespace phirSOFT.Applications.FinancePlanner.Dialogs
{
    internal class JoinCategoriesDialog
    {

        public static  Model.Category GetJoinedCategorie(params Model.Category[] categories)
        {
            var dlg = new TaskDialog
            {
                Cancelable = true,
                Caption = "Join Categories",
                Text = "You are going to join categories. Please select the category, which will contain the joined categories",
                InstructionText = "Joining categories",
                StartupLocation = TaskDialogStartupLocation.CenterOwner,
                StandardButtons = TaskDialogStandardButtons.Ok | TaskDialogStandardButtons.Cancel
            };

            foreach (var cat in categories)
            {
                dlg.Controls.Add(new TaskDialogRadioButton(cat.Title, cat.Title));
            }
            dlg.Show();
            return null;
        }

      
    }
}