using System;
using NLog;
using NLog.Targets;
using NLog.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace phirSOFT.Applications.FinancePlanner.Forms
{
    internal partial class Logger : DockContent
    {
        public static Logger Instance { get; } = new Logger();



        private Logger()
        {
            InitializeComponent();




        }

        private void Logger_Load(object sender, EventArgs e)
        {


            var target = new RichTextBoxTarget()
            {
                // ControlName = textBox1.Name,
                // FormName = Name,
                Name = "UILogger",

            };

            LogManager.Configuration.AddTarget(target);
            LogManager.Configuration.AddRuleForAllLevels(target);
            target.AutoScroll = true;
            target.FormName = this.Name;
            target.ControlName = textBox1.Name;
            LogManager.ReconfigExistingLoggers();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
