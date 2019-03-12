using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace phirSOFT.Controls.TreeView
{
    public class Table : ItemsControl
    {
        static Table()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Table),
                new FrameworkPropertyMetadata(typeof(Table)));
        }

    }
}
