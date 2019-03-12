using System;
using System.Collections;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using Aga.Controls.Tree;
using JetBrains.Annotations;
using NLog;
using phirSOFT.Applications.FinancePlanner.Model;

namespace phirSOFT.Applications.FinancePlanner.Controller
{
    internal sealed class CategoryTreeController : ITreeModel
    {
        private readonly FinanceContext _context;
        private readonly Logger logger;

        public static CategoryTreeController Instance { get; private set; }

        public CategoryTreeController(FinanceContext context)
        {
            _context = context;
            logger = LogManager.GetLogger("Category Controller");
            Instance = this;
        }

        public IEnumerable GetChildren(TreePath treePath)
        {
            // Disable for performance reasons
            // ReSharper disable once PassStringInterpolation
            logger.Debug("Requested Chiddren for {0}",treePath);
            if (treePath.IsEmpty())
                return _context.Categories.OfType<SystemCategory>().Include(c => c.Children);

            var category = treePath.LastNode as Category;
            return category?.Children;
        }

        public bool IsLeaf(TreePath treePath)
        {
            // Disable for performance reasons
            // ReSharper disable once PassStringInterpolation
            logger.Debug("Requested IsLeaf for {0}", treePath);
            var category = treePath.LastNode as Category;
            if (category == null) return true;
            return category.Children.Count == 0;
        }

        public event EventHandler<TreeModelEventArgs> NodesChanged;
        public event EventHandler<TreeModelEventArgs> NodesInserted;
        public event EventHandler<TreeModelEventArgs> NodesRemoved;
        public event EventHandler<TreePathEventArgs> StructureChanged;

        public Category AddCategory(TreePath parent,[LocalizationRequired] string name)
        {
            var item = new UserCategory {Title = name, Parent = (Category) parent.LastNode};

            AddCategory(parent, item);

            return item;
        }

        public void AddCategory(TreePath parent, Category item)
        {
            var cat = parent.LastNode as Category;
            Debug.Assert(cat != null, "cat != null");
            cat.Children.Add(item);
            var e = new TreePathEventArgs(parent);
            OnStructureChanged(e);
        }

        public void DeleteCategory(TreePath category)
        {
            var cat = category.LastNode as Category;
            Debug.Assert(cat != null, "cat != null");

            if (cat.System)
            {
                logger.Warn("Tried to delete a system category!");
                return;
            }

            _context.Categories.Remove(cat);
            var fullPath = category.FullPath;
            var parent = new TreePath(fullPath.Take(fullPath.Length - 1).ToArray());
            var e = new TreeModelEventArgs(parent, new [] {cat} );
            OnNodesRemoved(e);
        }

        public void Move(TreePath value, TreePath target)
        {
            ((Category)value.LastNode).Parent.Children.Remove((Category)value.LastNode);
            ((Category) target.LastNode).Children.Add((Category)value.LastNode);
            ((Category) value.LastNode).Parent = (Category) target.LastNode;
            var fullPath = value.FullPath;
            var parent = new TreePath(fullPath.Take(fullPath.Length - 1).ToArray());
            var e = new TreeModelEventArgs(parent, new[] { value.LastNode });
            OnNodesRemoved(e);
            OnStructureChanged(new TreePathEventArgs(target));
        }

        private void OnNodesInserted(TreeModelEventArgs e)
        {
            NodesInserted?.Invoke(this, e);
        }

        private void OnStructureChanged(TreePathEventArgs e)
        {
            StructureChanged?.Invoke(this, e);
        }

        private void OnNodesRemoved(TreeModelEventArgs e)
        {
            NodesRemoved?.Invoke(this, e);
        }
    }
}
