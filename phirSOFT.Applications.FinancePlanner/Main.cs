using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using phirSOFT.Common.IO;
using WeifenLuo.WinFormsUI.Docking;

namespace Finanzplan
{
    public partial class Main : Form
    {
        Logger log;

        private void LogDB(string msg)
        {
            log.WriteLog($"[{DateTime.Now:hh:mm:ss}] [Database] {msg}");
        }
        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetupUniqueWindows();
        }

        private void SetupUniqueWindows()
        {
            //Logger

            log = new Logger();
            //log.MdiParent = this;
            log.HideOnClose = true;
            log.Show(DockPanel1, DockState.DockBottomAutoHide);

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

            DockPanel1.SaveAsXml(SpecialDirectories.ApplicationData + @"\phirSOFT\Finanzplan\layout.xml");
        }

        private void neuToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var page = new Form2();
            page.MdiParent = this;

            //page.Show();
            page.Show(DockPanel1, DockState.Document);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            using (var ctx = new DB.AppDBContext())
            {
                var einkommen = new DB.Category();
                einkommen.Signum = DB.Signum.positiv;
                einkommen.Title = "Einkommen";
                einkommen.System = true;

                Action<string> msg = (string obj) =>
                {
                    log.WriteLog(obj);
                };
                ctx.Database.Log = LogDB;
                msg(ctx.Database.Connection.ConnectionString);
                // ctx.Categories.Add(Einkommen);
                ctx.SaveChanges();
            }
        }

        private void loggerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loggerToolStripMenuItem.Checked = !loggerToolStripMenuItem.Checked;

        }

        private void loggerToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            if (loggerToolStripMenuItem.Checked)
            {
                log.Show();
            }
            else { log.Hide(); }
        }


    }
}
