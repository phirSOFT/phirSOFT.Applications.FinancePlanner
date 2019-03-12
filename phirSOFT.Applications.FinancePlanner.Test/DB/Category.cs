using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace phirSOFT.Test.Finanzplan.DB
{
    class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool System { get; set; }
        public virtual Collection<Category> SubCategories { get; set; } = new Collection<Category>();
        public Category Parent { get; set; }
        public Signum Signum { get; set; }
    }
}
