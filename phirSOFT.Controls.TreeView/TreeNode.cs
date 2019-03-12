using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phirSOFT.Controls.TreeView
{

    class TreeNode : ObservableCollection<TreeNode>
    {
        private object _data;
        private TreeNode _parent;
        private bool _isExpanded;

        public object Data
        {
            get { return _data; }
            set
            {
                _data = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Data)));
            }
        }

        public bool IsExpanded
        {
            get { return _isExpanded; }
            set
            {
                _isExpanded = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(IsExpanded)));
            }
        }

        public bool HasItems => Count != 0;

        public int Depth => Parent?.Depth +1 ?? 0;

        protected override void InsertItem(int index, TreeNode item)
        {
            var willHasItemsChange = Count == 0;
            item.Parent = this;

            base.InsertItem(index, item);
            if (willHasItemsChange)
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(HasItems)));
        }

        protected override void SetItem(int index, TreeNode item)
        {
            var willHasItemsChange = Count == 0;
            item.Parent = this;
            this[index].Parent = null;


            base.SetItem(index, item);
            if (willHasItemsChange)
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(HasItems)));
        }

        protected override void RemoveItem(int index)
        {
            var willHasItemsChange = Count == 1;

            this[index].Parent = null;

            base.RemoveItem(index);

            if (willHasItemsChange)
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(HasItems)));
        }

        public TreeNode Parent
        {
            get { return _parent; }
            set
            {
                _parent = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Parent)));
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Depth)));
            }
        }
    }
}
