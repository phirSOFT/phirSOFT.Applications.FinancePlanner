using Aga.Controls.Tree;

namespace phirSOFT.Applications.FinancePlanner.Forms
{
    partial class CategoryEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CategoryEditor));
            this.CategoryTree = new Aga.Controls.Tree.TreeViewAdv();
            this.nodeStateIcon2 = new Aga.Controls.Tree.NodeControls.NodeStateIcon();
            this.nodeTextBox1 = new Aga.Controls.Tree.NodeControls.NodeTextBox();
            this.SuspendLayout();
            // 
            // CategoryTree
            // 
            this.CategoryTree.AllowDrop = true;
            this.CategoryTree.AsyncExpanding = true;
            this.CategoryTree.BackColor = System.Drawing.SystemColors.Window;
            this.CategoryTree.ColumnHeaderHeight = 0;
            this.CategoryTree.DefaultToolTipProvider = null;
            this.CategoryTree.DisplayDraggingNodes = true;
            this.CategoryTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CategoryTree.DragDropMarkColor = System.Drawing.Color.Black;
            this.CategoryTree.FullRowSelect = true;
            this.CategoryTree.FullRowSelectActiveColor = System.Drawing.SystemColors.ActiveCaption;
            this.CategoryTree.FullRowSelectInactiveColor = System.Drawing.SystemColors.InactiveCaption;
            this.CategoryTree.LineColor = System.Drawing.SystemColors.ControlDark;
            this.CategoryTree.LoadOnDemand = true;
            this.CategoryTree.Location = new System.Drawing.Point(0, 0);
            this.CategoryTree.Model = null;
            this.CategoryTree.Name = "CategoryTree";
            this.CategoryTree.NodeControls.Add(this.nodeStateIcon2);
            this.CategoryTree.NodeControls.Add(this.nodeTextBox1);
            this.CategoryTree.NodeFilter = null;
            this.CategoryTree.SelectedNode = null;
            this.CategoryTree.SelectionMode = Aga.Controls.Tree.TreeSelectionMode.MultiSameParent;
            this.CategoryTree.ShowNodeToolTips = true;
            this.CategoryTree.Size = new System.Drawing.Size(555, 386);
            this.CategoryTree.TabIndex = 0;
            this.CategoryTree.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.CategoryTree_ItemDrag);
            this.CategoryTree.SelectionChanged += new System.EventHandler(this.CategoryTree_SelectionChanged);
            this.CategoryTree.Click += new System.EventHandler(this.CategoryTree_Click);
            this.CategoryTree.DragDrop += new System.Windows.Forms.DragEventHandler(this.CategoryTree_DragDrop);
            this.CategoryTree.DragOver += new System.Windows.Forms.DragEventHandler(this.CategoryTree_DragOver);
            this.CategoryTree.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CategoryTree_KeyDown);
            this.CategoryTree.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CategoryTree_MouseClick);
            // 
            // nodeStateIcon2
            // 
            this.nodeStateIcon2.LeftMargin = 1;
            this.nodeStateIcon2.ParentColumn = null;
            this.nodeStateIcon2.ScaleMode = Aga.Controls.Tree.ImageScaleMode.ScaleUp;
            this.nodeStateIcon2.VerticalAlign = Aga.Controls.Tree.VerticalAlignment.Bottom;
            this.nodeStateIcon2.VirtualMode = true;
            // 
            // nodeTextBox1
            // 
            this.nodeTextBox1.DataPropertyName = "Title";
            this.nodeTextBox1.EditEnabled = true;
            this.nodeTextBox1.EditOnClick = true;
            this.nodeTextBox1.IncrementalSearchEnabled = true;
            this.nodeTextBox1.LeftMargin = 3;
            this.nodeTextBox1.ParentColumn = null;
            this.nodeTextBox1.Trimming = System.Drawing.StringTrimming.EllipsisWord;
            // 
            // CategoryEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 386);
            this.Controls.Add(this.CategoryTree);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((((WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.Document)));
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CategoryEditor";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.Document;
            this.Text = "CategoryEditor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CategoryEditor_FormClosed);
            this.Load += new System.EventHandler(this.CategoryEditor_Load);
            this.Shown += new System.EventHandler(this.CategoryEditor_Shown);
            this.ResumeLayout(false);

        }

        private TreeViewAdv CategoryTree;

        #endregion

        private Aga.Controls.Tree.NodeControls.NodeTextBox nodeTextBox1;
        private Aga.Controls.Tree.NodeControls.NodeStateIcon nodeStateIcon2;
    }
}