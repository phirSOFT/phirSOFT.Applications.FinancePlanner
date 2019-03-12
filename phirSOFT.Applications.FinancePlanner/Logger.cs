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
    public partial class Logger : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public Logger()
        {
            InitializeComponent();
        }

        private void Logger_Load(object sender, EventArgs e)
        {

        }

        public void WriteLog(string msg)
        {
            textBox1.AppendText(msg);
            textBox1.ScrollToCaret();
            this.Show();
        }
    }
}
