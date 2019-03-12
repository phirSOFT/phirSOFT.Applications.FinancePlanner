// --------------------------------------------------------------------------------------------------------------------
// <copyright company="phirSOFT" file="Bootstrapper.cs">
// Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
// <summary>
// phirSOFT Package phirSOFT.Applications.FinancePlanner.Shell
// 
// Created by:    Philemon Eichin
// Created:       03.08.2017 11:59
// Last Modified: 03.08.2017 11:59
// </summary>
//  
// --------------------------------------------------------------------------------------------------------------------

using System.Windows;
using Fluent;
using phirSOFT.Applications.FinancePlanner.Core;
using Prism.Regions;
using Prism.Unity;

namespace phirSOFT.Applications.FinancePlanner.Shell
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<Views.MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        protected override void InitializeModules()
        {
            var core = Container.TryResolve<CoreModule>();
            core.Initialize();
        }

        protected override void ConfigureModuleCatalog()
        {
            var progressReporter = typeof(ProgressModuleModule);

            ModuleCatalog.AddModule(
                new ModuleInfo()
                {
                    ModuleName = progressReporter.Name,
                    ModuleType = progressReporter.AssemblyQualifiedName,
                }
            );
            base.ConfigureModuleCatalog();

        }

        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            var mappings =  base.ConfigureRegionAdapterMappings();
            mappings.RegisterMapping(typeof(Ribbon), Container.TryResolve<RibbonRegionAdapter>());
            mappings.RegisterMapping(typeof(RibbonTabItem), Container.TryResolve<TabItemRegionAdapter>());
            return mappings;
        }
    }
}