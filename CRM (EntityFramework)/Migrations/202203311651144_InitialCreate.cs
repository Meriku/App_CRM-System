namespace CRM__EntityFramework_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        lastName = c.String(),
                        firstName = c.String(),
                        patronymicName = c.String(),
                        birthDate = c.DateTime(),
                        phoneNumber = c.String(),
                        email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sells",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        clientId = c.Int(nullable: false),
                        productId = c.Int(nullable: false),
                        count = c.Int(nullable: false),
                        productPrice = c.Int(nullable: false),
                        price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.clientId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.productId, cascadeDelete: true)
                .Index(t => t.clientId)
                .Index(t => t.productId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        art = c.Int(nullable: false),
                        type = c.String(),
                        name = c.String(),
                        cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        package = c.Single(nullable: false),
                        unitOfMeasure = c.String(),
                        balance = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sells", "productId", "dbo.Products");
            DropForeignKey("dbo.Sells", "clientId", "dbo.Clients");
            DropIndex("dbo.Sells", new[] { "productId" });
            DropIndex("dbo.Sells", new[] { "clientId" });
            DropTable("dbo.Products");
            DropTable("dbo.Sells");
            DropTable("dbo.Clients");
        }
    }
}
