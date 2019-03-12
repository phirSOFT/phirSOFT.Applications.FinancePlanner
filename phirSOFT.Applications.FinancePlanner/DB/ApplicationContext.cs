using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phirSOFT.Finanzplan.DB
{
    class ApplicationContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
    }
}
