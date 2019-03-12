using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzplan.DB
{
    class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool System { get; set; }
        public Collection<Category> SubCategories { get; set; }
        public Category Parent { get; set; }
        public Signum Signum { get; set; }
    }
}
