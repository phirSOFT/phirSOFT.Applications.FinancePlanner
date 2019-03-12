using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace phirSOFT.Applications.FinancePlanner.Forms
{
    public partial class Console : DockContent
    {

        private static readonly Lazy<Console> _instance = new Lazy<Console>(() => new Console());

        public static Console Instance => _instance.Value;

        private Console()
        {
            InitializeComponent();
        }

        private void Console_Load(object sender, EventArgs e)
        {

        }

        private void consoleTextBox1_LineRead(object sender, Controls.LineReadEventArgs e)
        {
            consoleTextBox1.WriteLine(">>>" + e.Line);
        }

        private void consoleTextBox1_Load(object sender, EventArgs e)
        {

        }

        private void Console_Shown(object sender, EventArgs e)
        {
            consoleTextBox1.WriteLink("Click here for help", () => MessageBox.Show("Help"));
        }
    }
}
