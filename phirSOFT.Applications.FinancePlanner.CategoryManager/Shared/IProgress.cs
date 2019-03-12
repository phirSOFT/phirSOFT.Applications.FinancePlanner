// --------------------------------------------------------------------------------------------------------------------
// <copyright company="phirSOFT" file="IProgress.cs">
// Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
// <summary>
// phirSOFT Package Shared
// 
// Created by:    Philemon Eichin
// Created:       01.04.2017 20:58
// Last Modified: 01.04.2017 20:58
// </summary>
//  
// --------------------------------------------------------------------------------------------------------------------

using System.ComponentModel;

namespace Shared
{
    public interface IProgress : INotifyPropertyChanged
    {
        void Pause();

        void Resume();

        bool CanPause { get; }

        string Title { get; }

        string Description { get; }

        ProgressState.States State { get; }

        double Progress { get; }
    }
}