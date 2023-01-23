namespace managecfshop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ABCs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Status = c.String(),
                        Time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BillInfors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Food = c.String(),
                        Price = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        SelectedNameTable = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateCheckIn = c.DateTime(nullable: false),
                        DateCheckOut = c.DateTime(),
                        IdTable = c.String(),
                        TotalPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameCategory = c.String(),
                        UploadFile = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SelectMenus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameFood = c.String(),
                        CountFood = c.Int(nullable: false),
                        PriceFood = c.Single(nullable: false),
                        Category = c.String(),
                        UploadFile = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameTable = c.String(),
                        StatusTable = c.String(),
                        UploadFile = c.String(),
                        SelectedNameTable = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tables");
            DropTable("dbo.SelectMenus");
            DropTable("dbo.Categories");
            DropTable("dbo.Bills");
            DropTable("dbo.BillInfors");
            DropTable("dbo.Accounts");
            DropTable("dbo.ABCs");
        }
    }
}
