using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace Finanzplan.DB
{
    class AppDBContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<AccountingEntry> AccountingEntries { get; set; }
    }
}
