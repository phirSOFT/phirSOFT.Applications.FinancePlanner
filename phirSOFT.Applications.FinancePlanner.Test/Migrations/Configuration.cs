namespace phirSOFT.Test.Finanzplan.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<phirSOFT.Test.Finanzplan.DB.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "phirSOFT.Test.Finanzplan.DB.AppDbContext";
        }

        protected override void Seed(phirSOFT.Test.Finanzplan.DB.AppDbContext context)
        {
            context.Categories.AddOrUpdate(new DB.Category() { System = true, Signum = DB.Signum.Negative, Title = "Ausgaben" });

            context.Categories.AddOrUpdate(new DB.Category() { System = true, Signum = DB.Signum.Positiv, Title = "Erträge" });
        }
    }
}
