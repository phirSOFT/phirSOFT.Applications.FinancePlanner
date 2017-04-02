// --------------------------------------------------------------------------------------------------------------------
// <copyright company="phirSOFT" file="ProgressState.cs">
// Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
// <summary>
// phirSOFT Package Shared
// 
// Created by:    Philemon Eichin
// Created:       02.04.2017 20:49
// Last Modified: 02.04.2017 20:49
// </summary>
//  
// --------------------------------------------------------------------------------------------------------------------
namespace phirSOFT.Applications.FinancePlanner
{
    /// <summary>
    /// Indicates the state of a progress
    /// </summary>
    public enum ProgressStates
    {
        /// <summary>
        /// The progress is running and has a known percentage of completion.
        /// </summary>
        Running,

        /// <summary>
        /// The progress is paused.
        /// </summary>
        Paused,

        /// <summary>
        /// The progress is running, but has no knowledge about its progress percentage.
        /// </summary>
        Intermediate,

        /// <summary>
        /// The progress finished with an error.
        /// </summary>
        Faultet,

        /// <summary>
        /// The progress run sucessfull to end.
        /// </summary>
        Finished
    }
}