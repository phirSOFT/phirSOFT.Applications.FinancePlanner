using System;
using System.Windows.Forms;
using NLog;
using phirSOFT.Applications.FinancePlanner.Forms;
using WeifenLuo.WinFormsUI.Docking;
using RibbonLib;
using RibbonLib.Interop;


namespace phirSOFT.Applications.FinancePlanner
{
    public partial class Form1 : Form, IRibbonForm
    {
        private NLog.Logger _guiLogger;

        private static Lazy<Form1> _instance = new Lazy<Form1>(()=> new Form1());
        public static Form1 Instance => _instance.Value;

        private Ribbon Ribbon => Ribbon.Instance.Value;


        private Form1()
        {
            _guiLogger = LogManager.GetLogger("UI");

            _guiLogger.Debug("Initializing Components");


            InitializeComponent();
            Ribbon.InitFramework(this, "APPLICATION_RIBBON", "RibbonMarkup.ribbon.dll");
            InitializeEvents();
            
            
            Ribbon.ConnectButton.Enabled = false;
            _guiLogger.Debug("Applying theme");
            dockContent.Theme = new VS2015BlueTheme();
            dockContent.BackColor = dockContent.Theme.Skin.DockPaneStripSkin.DocumentGradient.DockStripGradient.StartColor;
            

        }

        private void InitializeEvents()
        {
            Ribbon.CategoryEditorButton.OnExecute += (key,value, execution) => CategoryEditor.Instance.Show(dockContent);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _guiLogger.Debug("Creating LogWindow");
            Forms.Logger.Instance.Show(dockContent, DockState.DockBottomAutoHide);

            _guiLogger.Debug("Creating ConsoleWindow");
            Forms.Console.Instance.Show(dockContent, DockState.DockBottomAutoHide);


            _guiLogger.Debug("Creating Category Editor");
            CategoryEditor.Instance.Show(dockContent, DockState.Document);
        }

       

     
        private void dockContent_ActiveContentChanged(object sender, EventArgs e)
        {
            if (dockContent.ActiveContent == null) return;
            Ribbon.CategoriesToolsTabGroup.ContextAvailable = dockContent.ActiveContent == CategoryEditor.Instance ? ContextAvailability.Active : ContextAvailability.NotAvailable;

            LocalizeRibbon();
        }

        private int ribbonHeight;

        public void RibbonHeightUpdated(int newHeight)
        {
            splitContainer1.SplitterDistance = ribbonHeight = newHeight;

        }

        public IntPtr WindowHandle => Handle;

        private void splitContainer1_Resize(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = ribbonHeight;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Forms.Logger.Instance.Activate();
            LocalizeRibbon();
        }
    }
}
