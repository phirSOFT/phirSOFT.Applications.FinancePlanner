using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phirSOFT.Controls.TreeView
{
    class TreeViewItemClickedEventArgs : EventArgs
    {
        public object ClickedItem { get; set; }
        public bool IsHandled { get; set; }
    }
}
