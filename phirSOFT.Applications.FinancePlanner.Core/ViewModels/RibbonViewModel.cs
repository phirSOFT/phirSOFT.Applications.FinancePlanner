using System;
using System.Windows.Controls;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;

namespace phirSOFT.Applications.FinancePlanner.Core.ViewModels
{
    class RibbonViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        private readonly IUnityContainer _container;



        public RibbonViewModel(IRegionManager regionManager, IUnityContainer container)

        {

            _regionManager = regionManager;

            _container = container;

            LoadViewCommand = new DelegateCommand<string>(LoadView, CanLoad);
        }

        public DelegateCommand<string> LoadViewCommand { get; }

        public event EventHandler<DataEventArgs<string>> LoadedView;



        private bool CanLoad(string arg)

        {

            return true;

        }



        private void LoadView(string obj)

        {

            IRegion mainRegion = _regionManager.Regions[RegionNames.MainRegion];

            string viewName = obj + "View";

            var view = _container.Resolve<UserControl>(viewName);

            mainRegion.Add(view, viewName);

            mainRegion.Activate(view);

            this.OnLoadView(new DataEventArgs<string>(obj));

        }



        private void OnLoadView(DataEventArgs<string> e)

        {
            var onLoadedView = this.LoadedView;
            if (onLoadedView != null)
            {
                EventHandler<DataEventArgs<string>> loadHandler = onLoadedView;

                loadHandler?.Invoke(this, e);
            }
        }

    }
}
