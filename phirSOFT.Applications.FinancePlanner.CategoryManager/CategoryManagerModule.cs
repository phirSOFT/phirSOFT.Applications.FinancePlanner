using Prism.Modularity;
using Prism.Regions;
using System;

namespace CategoryManager
{
    public class CategoryManagerModule : IModule
    {
        IRegionManager _regionManager;

        public CategoryManagerModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }
    }
}