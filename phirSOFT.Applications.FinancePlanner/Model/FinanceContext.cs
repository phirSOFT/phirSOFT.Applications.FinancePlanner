using System.Data.Entity;

namespace phirSOFT.Applications.FinancePlanner.Model
{
    internal class FinanceContext : DbContext
    {
       /* public FinanceContext(string connectionString):base(connectionString)
        {
            
        }*/

        public DbSet<Category> Categories { get; set; }

       
    }
}
