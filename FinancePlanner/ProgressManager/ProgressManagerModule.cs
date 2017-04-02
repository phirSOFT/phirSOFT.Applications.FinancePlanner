using Prism.Modularity;
using Prism.Regions;
using System;

namespace ProgressManager
{
    public class ProgressManagerModule : IModule
    {
        IRegionManager _regionManager;

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