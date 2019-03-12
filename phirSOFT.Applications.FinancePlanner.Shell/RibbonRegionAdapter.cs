using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Fluent;
using Prism.Regions;

namespace phirSOFT.Applications.FinancePlanner.Shell
{
    class RibbonRegionAdapter : RegionAdapterBase<Ribbon>
    {
        /// <inheritdoc />
        public RibbonRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory) : base(regionBehaviorFactory)
        {
        }

        protected override void Adapt(IRegion region, Ribbon regionTarget)
        {
            if (region == null) throw new ArgumentNullException(nameof(region));
            if (regionTarget == null) throw new ArgumentNullException(nameof(regionTarget));

            region.ActiveViews.CollectionChanged += (s, args) =>
            {
                switch (args.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                    {
                        foreach (var view in args.NewItems)
                        {
                            AddViewToRegion(view, regionTarget);
                        }
                        break;
                    }
                    case NotifyCollectionChangedAction.Remove:
                    {
                        foreach (var view in args.OldItems)
                        {
                            RemoveViewFromRegion(view, regionTarget);
                        }
                        break;
                    }
                    default:
                    {
                        // Do nothing.
                        break;
                    }
                }
            };
        }


        protected override IRegion CreateRegion()
        {
            return new AllActiveRegion();
        }


        static void AddViewToRegion(object view, Ribbon wpfRibbon)
        {
            if (view is RibbonTabItem ribbonTab)
                wpfRibbon.Tabs.Add(ribbonTab);
        }

        static void RemoveViewFromRegion(object view, Ribbon wpfRibbon)
        {
            if (view is RibbonTabItem ribbonTab)
                wpfRibbon.Tabs.Remove(ribbonTab);
        }

    }


    public class TabItemRegionAdapter : RegionAdapterBase<RibbonTabItem>
    {
        public TabItemRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory) : base(regionBehaviorFactory)
        {
        }

        protected override void Adapt(IRegion region, RibbonTabItem regionTarget)
        {
            region.Views.CollectionChanged += (sender, args) => ViewsOnCollectionChanged(regionTarget, args);
        }

        private static void ViewsOnCollectionChanged(RibbonTabItem regionTarget, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (var newItem in e.NewItems)
                    {
                        regionTarget.Groups.Add((RibbonGroupBox)newItem);
                    }
                    regionTarget.BringIntoView();
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (var oldItem in e.OldItems)
                    {
                        regionTarget.Groups.Remove((RibbonGroupBox)oldItem);
                    }
                    break;
            }
        }

        protected override IRegion CreateRegion()
        {
            return new AllActiveRegion();
        }
    }

}
