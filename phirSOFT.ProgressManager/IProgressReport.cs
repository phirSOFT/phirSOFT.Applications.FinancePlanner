﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright company="phirSOFT" file="IProgressReport.cs">
// Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
// <summary>
// phirSOFT Package Shared
// 
// Created by:    Philemon Eichin
// Created:       02.04.2017 20:53
// Last Modified: 02.04.2017 20:53
// </summary>
//  
// --------------------------------------------------------------------------------------------------------------------

namespace phirSOFT.Applications.FinancePlanner
{
    /// <summary>
    ///     This type is used to report the progress of an operation to the ProgressManager.
    /// </summary>
    public struct ProgressReport
    {
        /// <summary>
        ///     Gets the current state of the progress.
        /// </summary>
        public ProgressStates State { get; set; }

        /// <summary>
        ///     Gets the current percentage of the progress. (Between 0 and 1)
        /// </summary>
        public double Progress { get; set; }

        /// <summary>
        ///     Gets the title of the operation
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///     Gets the description of the operation.
        /// </summary>
        public string Description { get; set; }
    }
}