﻿using System;
using Prism.Modularity;
using Prism.Regions;

namespace phirSOFT.Applications.FinancePlanner.ProgressManager
{
    public class ProgressManagerModule : IModule
    {
        private IRegionManager _regionManager;

        public ProgressManagerModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }
    }
}