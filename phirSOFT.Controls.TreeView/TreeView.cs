using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace phirSOFT.Controls.TreeView
{
    class TreeView : ListView
    {
        public static readonly DependencyProperty DragAdornerOpacityProperty =
            DependencyProperty.Register(nameof(DragAdornerOpacity), typeof(double), typeof(TreeView), new PropertyMetadata(0.7),
                value => (double) value <=1.0 && (double) value >= 0.0
            );

        public static readonly DependencyProperty ShowDragAdornerProperty =
            DependencyProperty.Register(nameof(ShowDragAdornerProperty), typeof(bool), typeof(TreeView), new PropertyMetadata(true));

        private ViewModel flatViewModel;
        private bool isDragInProgress;
        private bool _canInitiateDrag
            ;

        public double DragAdornerOpacity
        {
            get => (double) GetValue(DragAdornerOpacityProperty);
            set => SetValue(DragAdornerOpacityProperty, value);
        }

        public bool ShowDragAdorner
        {
            get => (bool)GetValue(ShowDragAdornerProperty);
            set => SetValue(ShowDragAdornerProperty, value);
        }

        public TreeView()
        {
            flatViewModel = new ViewModel();
            var rootNode = new TreeNode();

            flatViewModel.ExpandNode(rootNode);

           
            AllowDrop = true;
         
            //rootNode.CollectionChanged += flatViewModel.TreeNodeVectorChanged;
            //PreviewMouseLeftButtonUp += OnTreeViewItemClick;

            //DragItemsStarting += ref new Windows::UI::Xaml::Controls::DragItemsStartingEventHandler(this, &TreeView::TreeView_DragItemsStarting);
            //DragItemsCompleted += ref new Windows::Foundation::TypedEventHandler<Windows::UI::Xaml::Controls::ListViewBase ^, Windows::UI::Xaml::Controls::DragItemsCompletedEventArgs ^> (this, &TreeView::TreeView_DragItemsCompleted);
            ItemsSource = flatViewModel;
        }

        public event EventHandler<TreeViewItemClickedEventArgs> TreeViewItemClick;

        public TreeNode RootNode { get; }


        protected virtual void OnTreeViewItemClick(TreeViewItemClickedEventArgs e)
        {
            TreeViewItemClick?.Invoke(this, e);
        }

        protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            var pos = e.GetPosition(this);

            if (IsMouseOverScrollbar(pos))
            {
                _canInitiateDrag = false;
                return;
            }

            GetLis
        }

        private bool IsMouseOverScrollbar(Point location)
        {

              
                var res = VisualTreeHelper.HitTest(this, location);
                if (res == null)
                    return false;

                var depObj = res.VisualHit;
                while (depObj != null)
                {
                    if (depObj is ScrollBar)
                        return true;

                    // VisualTreeHelper works with objects of type Visual or Visual3D.
                    // If the current object is not derived from Visual or Visual3D,
                    // then use the LogicalTreeHelper to find the parent element.
                    if (depObj is Visual || depObj is Visual3D)
                        depObj = VisualTreeHelper.GetParent(depObj);
                    else
                        depObj = LogicalTreeHelper.GetParent(depObj);
                }

                return false;
            
        }

        protected override void OnDrop(DragEventArgs e)
        {
            base.OnDrop(e);
        }

        protected override void OnDragOver(DragEventArgs e)
        {
            base.OnDrop(e);
        }

       

        public void ExpandNode(TreeNode node)
        {
            
        }

        public void CollapseNode(TreeNode node)
        {

        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return base.GetContainerForItemOverride();
        }

        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            base.PrepareContainerForItemOverride(element, item);
        }


    }

    internal class ViewModel : ObservableCollection<TreeNode>
    {
        public void ExpandNode(TreeNode rootNode)
        {
            throw new NotImplementedException();
        }
    }
}
