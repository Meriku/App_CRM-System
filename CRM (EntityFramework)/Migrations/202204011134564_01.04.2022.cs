namespace CRM__EntityFramework_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _01042022 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Sells", "productPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Sells", "price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sells", "price", c => c.Int(nullable: false));
            AlterColumn("dbo.Sells", "productPrice", c => c.Int(nullable: false));
        }
    }
}
