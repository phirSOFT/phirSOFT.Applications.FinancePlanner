namespace phirSOFT.Test.Finanzplan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountingEntries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        System = c.Boolean(nullable: false),
                        Signum = c.Int(nullable: false),
                        Parent_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Parent_Id)
                .Index(t => t.Parent_Id);
            
            CreateTable(
                "dbo.AccountingEntryParts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        AmountGuessed = c.Boolean(nullable: false),
                        Title = c.String(),
                        Interval = c.Int(),
                        Renewable = c.Boolean(),
                        LastDate = c.DateTime(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        AccountingEntry_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccountingEntries", t => t.AccountingEntry_Id)
                .Index(t => t.AccountingEntry_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AccountingEntryParts", "AccountingEntry_Id", "dbo.AccountingEntries");
            DropForeignKey("dbo.AccountingEntries", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Categories", "Parent_Id", "dbo.Categories");
            DropIndex("dbo.AccountingEntryParts", new[] { "AccountingEntry_Id" });
            DropIndex("dbo.Categories", new[] { "Parent_Id" });
            DropIndex("dbo.AccountingEntries", new[] { "Category_Id" });
            DropTable("dbo.AccountingEntryParts");
            DropTable("dbo.Categories");
            DropTable("dbo.AccountingEntries");
        }
    }
}
