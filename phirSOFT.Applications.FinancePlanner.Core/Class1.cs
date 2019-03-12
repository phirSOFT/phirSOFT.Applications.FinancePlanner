using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using phirSOFT.Applications.FinancePlanner.Core.Views;
using Prism.Modularity;
using Prism.Regions;

namespace phirSOFT.Applications.FinancePlanner.Core
{
    public class CoreModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public CoreModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        /// <inheritdoc />
        public void Initialize()
        {
            RegisterViews();
        }

        protected virtual void RegisterViews()
        {
            _regionManager.RegisterViewWithRegion(RegionNames.MenuRegion, typeof(RibbonView));
            _regionManager.RegisterViewWithRegion(RegionNames.StatusbarRegion, typeof(StatusbarView));
        }
    }
}
