using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace phirSOFT.Applications.FinancePlanner.Model
{
    internal abstract class Category
    {
        [Key]
        public int Index { get; set; }

        protected Category()
        {
            Children = new Collection<Category>();
        }

        public virtual Category Parent { get; set; }

        public virtual ICollection<Category> Children { get; }

        public virtual string Title { get; set; }

        public abstract CategoryType CategoryType { get; }
        public abstract bool System { get; }
    }
}