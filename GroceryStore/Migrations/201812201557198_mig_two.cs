namespace GroceryStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_two : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "productCost", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "productCost");
        }
    }
}
