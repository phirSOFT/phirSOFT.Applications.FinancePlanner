using System;
using System.Linq;
using System.Windows.Forms;
using Aga.Controls.Tree;
using NLog;
using phirSOFT.Applications.FinancePlanner.Controller;
using phirSOFT.Applications.FinancePlanner.Dialogs;
using phirSOFT.Applications.FinancePlanner.Model;
using RibbonLib.Interop;
using WeifenLuo.WinFormsUI.Docking;

namespace phirSOFT.Applications.FinancePlanner.Forms
{
    public partial class CategoryEditor : DockContent
    {
        // ReSharper disable once InconsistentNaming
        private static readonly Lazy<CategoryEditor> _Instance = new Lazy<CategoryEditor>(() => new CategoryEditor());
        private readonly NLog.Logger _log = LogManager.GetLogger("Category Editor");

        private CategoryTreeController controller;
        private CategoryEditor()
        {
            InitializeComponent();
            controller = new CategoryTreeController(Program.CurrentContext);
            CategoryTree.Model = controller;
            nodeStateIcon2.ValueNeeded += NodeStateIcon2_ValueNeeded;
            nodeTextBox1.EditorShown += NodeTextBox1_EditorShowing;
            nodeTextBox1.EditorHided += NodeTextBox1OnEditorHided;

            Ribbon.EditButton.Enabled = false;

            Ribbon.EditButton.OnExecute += EditButton_OnExecute;
            Ribbon.AcceptButton.OnExecute += AcceptChangesButtonOnOnExecute;
            Ribbon.DeleteButton.OnExecute += DeleteButtonOnOnExecute;
            Ribbon.DiscardButton.OnExecute += DiscardChangesButtonOnOnExecute;
            Ribbon.JoinButton.OnExecute += JoinButtonOnOnExecute;
            Ribbon.AddButton.OnExecute += AddButton_OnExecute;

        }

        private void AddButton_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            Add();
        }

        private void Add()
        {
            var path = CategoryTree.GetPath(CategoryTree.SelectedNode);
            AddNewCategory(path);
        }

        private void AddNewCategory(TreePath path)
        {
            var item = controller.AddCategory(path, SR.CategoryEditor_AddNewCategory_Unnamed_Category);
            CategoryTree.SelectedNode.IsExpanded = true;
            CategoryTree.SelectedNode = CategoryTree.FindNode(new TreePath(path, item));
            nodeTextBox1.BeginEdit();
        }

        public static CategoryEditor Instance => _Instance.Value;


        private Ribbon Ribbon => Ribbon.Instance.Value;
        private void AcceptChangesButtonOnOnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            nodeTextBox1.EndEdit(true);
        }

        private void CategoryEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            Ribbon.CategoriesToolsTabGroup.ContextAvailable = ContextAvailability.NotAvailable;
        }

        private void CategoryEditor_Load(object sender, EventArgs e)
        {
            Text = SR.CategoryEditor;
        }

        private void CategoryEditor_Shown(object sender, EventArgs e)
        {
            Ribbon.CategoriesToolsTabGroup.ContextAvailable = ContextAvailability.Available;
        }

        private void CategoryTree_Click(object sender, EventArgs e)
        {

        }

        private void CategoryTree_DragDrop(object sender, DragEventArgs e)
        {
            CategoryTree.BeginUpdate();
            var target = CategoryTree.GetPath(CategoryTree.GetNodeAt(CategoryTree.PointToClient(new System.Drawing.Point(e.X, e.Y))));

            var nodes = (TreeNodeAdv[]) e.Data.GetData(typeof(TreeNodeAdv[]));

            foreach (var node in nodes)
            {
                var path = CategoryTree.GetPath(node);
                controller.Move(path, target);
            }

            e.Effect = DragDropEffects.Copy;
           
            CategoryTree.EndUpdate();
        }

        private void CategoryTree_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        private void CategoryTree_ItemDrag(object sender, ItemDragEventArgs e)
        {
           
            CategoryTree.DoDragDropSelectedNodes(DragDropEffects.Move);

        }

        private void CategoryTree_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                Delete();
            if (e.KeyCode == Keys.N && e.Control)
                Add();
        }

      

        private void CategoryTree_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            var p = PointToScreen(e.Location);
            Ribbon.ShowContextPopup(50001, p.X, p.Y);
        }

        private void CategoryTree_SelectionChanged(object sender, EventArgs e)
        {
            Ribbon.EditButton.Enabled = CategoryTree.SelectedNodes.Count == 1;
            Ribbon.DeleteButton.Enabled = CategoryTree.SelectedNodes.Count > 0;
            Ribbon.JoinButton.Enabled = CategoryTree.SelectedNodes.Count > 1;
            CheckCanAdd();
        }

        private void CheckCanAdd()
        {
            Ribbon.AddButton.Enabled = CategoryTree.SelectedNodes.Count == 1;
        }

        private bool CheckNodeParent(TreeNodeAdv parent, TreeNodeAdv node)
        {
            return false;
        }

        private void Delete()
        {
            _log.Debug("Delete Command Called");
            CategoryTree.BeginUpdate();
            var nodes = CategoryTree.SelectedNodes.ToList();


            var dlg = new NestedCategoriesDialog();
            nodes.AsParallel().ForAll(node =>
            {
                var path = CategoryTree.GetPath(node);
                if (node.IsLeaf)
                    controller.DeleteCategory(path);
                //Delete Node
                else
                {


                    if (dlg.RequestBehaviour() == DeleteBehavior.KeepChildren)
                    {
                        var parentpath = CategoryTree.GetPath(node.Parent);
                        node.Children.AsParallel().ForAll(child =>
                                    controller.Move(CategoryTree.GetPath(child), parentpath)
                        );
                    }
                    controller.DeleteCategory(path);


                }
            });
           
            CategoryTree.EndUpdate();
        }

        private void DeleteButtonOnOnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            Delete();
        }

        private void DiscardChangesButtonOnOnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            nodeTextBox1.EndEdit(false);
        }
        private void Edit()
        {
            nodeTextBox1.BeginEdit();
        }

        private void EditButton_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            Edit();
        }

        private void Join()
        {
            JoinCategoriesDialog.GetJoinedCategorie(CategoryTree.SelectedNodes.Select(n => (Category) n.Tag).ToArray());
        }

        private void JoinButtonOnOnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            Join();
        }
        private void NodeStateIcon2_ValueNeeded(object sender, Aga.Controls.Tree.NodeControls.NodeControlValueEventArgs e)
        {
            var category = e.Node.Tag as Category;
            if (category == null) return;
            switch (category.CategoryType)
            {
                case CategoryType.Unknown:
                    e.Value = Icons.YellowCategorie.ToBitmap();
                    break;
                case CategoryType.Income:
                    e.Value = Icons.GreenCategorie.ToBitmap();
                    break;
                case CategoryType.Expenses:
                    e.Value = Icons.RedCategorie.ToBitmap();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void NodeTextBox1_EditorShowing(object sender, EventArgs e)
        {

            var location = CategoryTree.PointToScreen(CategoryTree.CurrentEditor.Location);
            Ribbon.AcceptButton.Enabled = true;
            Ribbon.DiscardButton.Enabled = true;
            Ribbon.ShowContextPopup(40001, location.X, location.Y);

        }

        private void NodeTextBox1OnEditorHided(object sender, EventArgs eventArgs)
        {
            Ribbon.ShowContextPopup(40001, -1, -1);
            Ribbon.AcceptButton.Enabled = false;
            Ribbon.DiscardButton.Enabled = false;

            var roots = controller.GetChildren(TreePath.Empty);
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            CheckCanAdd();
        }
    }
}
