using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Finanzplan
{
    public partial class Form2 : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public Form2()
        {
            InitializeComponent();
            var bmp = new Bitmap(16, 16);
            var rnd = new Random(DateTime.Now.Second);
            var start = rnd.Next() % 255;
            var step = rnd.Next() % 255;
            for (int x = 0; x < 16; x++)
            {
                for (int y = 0; y < 16; y++)
                {                     
                    var r = start = (start + rnd.Next()) % step; ;
                    var g = start = (start + rnd.Next()) % step; ;
                    var b = start = (start + rnd.Next()) % step; ;

                    bmp.SetPixel(x, y, Color.FromArgb(r, g, b));

                }
            }
            toolStripButton1.Image = bmp;

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void Form2_Activated(object sender, EventArgs e)
        {
            if ((MdiParent as Main)?.toolStrip1!=null && DockState==WeifenLuo.WinFormsUI.Docking.DockState.Document)
                ToolStripManager.Merge(this.toolStrip1, (MdiParent as Main)?.toolStrip1);
        }

        private void Form2_DockStateChanged(object sender, EventArgs e)
        {
            if ((MdiParent as Main)?.toolStrip1 != null && DockState == WeifenLuo.WinFormsUI.Docking.DockState.Document)
                ToolStripManager.Merge(this.toolStrip1, (MdiParent as Main)?.toolStrip1);
            else if ((MdiParent as Main)?.toolStrip1 != null)
                ToolStripManager.RevertMerge((MdiParent as Main)?.toolStrip1);
        }

        private void Form2_Deactivate(object sender, EventArgs e)
        {
            if ((MdiParent as Main)?.toolStrip1 != null)
                ToolStripManager.RevertMerge((MdiParent as Main)?.toolStrip1);          
        }
    }
}
