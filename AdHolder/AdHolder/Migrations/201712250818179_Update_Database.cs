namespace AdHolder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Database : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Area",
                c => new
                    {
                        AreaId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CityRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AreaId)
                .ForeignKey("dbo.City", t => t.CityRefId, cascadeDelete: true)
                .Index(t => t.CityRefId);
            
            CreateTable(
                "dbo.City",
                c => new
                    {
                        CityId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CityId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductTitle = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Image = c.String(nullable: false),
                        FarePerDay = c.Int(nullable: false),
                        PaymentOption = c.Int(nullable: false),
                        AreaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.Register",
                c => new
                    {
                        RegisterId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        MiddleName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Phone = c.String(nullable: false, maxLength: 10),
                        isAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RegisterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Area", "CityRefId", "dbo.City");
            DropIndex("dbo.Area", new[] { "CityRefId" });
            DropTable("dbo.Register");
            DropTable("dbo.Products");
            DropTable("dbo.City");
            DropTable("dbo.Area");
        }
    }
}
