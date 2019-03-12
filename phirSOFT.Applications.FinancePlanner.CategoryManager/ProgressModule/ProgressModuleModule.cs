using Prism.Modularity;
using Prism.Regions;
using System;
using ProgressModule.Views;

namespace ProgressModule
{
    public class ProgressModuleModule : IModule
    {
        IRegionManager _regionManager;

        public ProgressModuleModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            
        }

        public void Initialize()
        {
            _regionManager.AddToRegion("StatusBar", new ProgressViewer());
        }
    }
}