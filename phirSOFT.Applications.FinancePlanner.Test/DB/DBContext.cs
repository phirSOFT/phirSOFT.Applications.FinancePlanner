using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using Finanzplan.DB;

namespace phirSOFT.Test.Finanzplan.DB
{
    class AppDbContext : DbContext
    {
        public AppDbContext() : base("Data Source=DESKTOP-22TENUS;Initial Catalog=TestDb;Integrated Security=True") {}
        public DbSet<Category> Categories { get; set; }
        public DbSet<AccountingEntry> AccountingEntries { get; set; }
    }
}
