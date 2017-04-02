// --------------------------------------------------------------------------------------------------------------------
// <copyright company="phirSOFT" file="IProgressManager.cs">
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

using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace phirSOFT.Applications.FinancePlanner
{

    /// <summary>
    /// Provides the contract for an ProgressManager
    /// </summary>
    public interface IProgressManager
    {
        /// <summary>
        /// Registers a progress.
        /// </summary>
        /// <param name="progress">The reporting progress interface.</param>
        /// <param name="cancel">The command to cancel the progress</param>
        void RegisterProgress(IProgress<IProgressReport> progress, ICommand cancel);

        /// <summary>
        /// Registers a progress.
        /// </summary>
        /// <param name="progress">The reporting progress interface.</param>
        /// <param name="cancel">The command to cancel the progress</param>
        /// <param name="pause">The command to pause the progress.</param>
        /// <param name="resume">The command to resume the progress.</param>
        void RegisterProgress(IProgress<IProgressReport> progress, ICommand cancel, ICommand pause, ICommand resume);

        /// <summary>
        /// Gets all registred progresses. If a progress finished it will be removed.
        /// </summary>
        ReadOnlyObservableCollection<IManagedProgress> Progresses { get; }
    }
}