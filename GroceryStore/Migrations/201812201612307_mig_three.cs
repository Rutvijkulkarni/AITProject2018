namespace GroceryStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_three : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "productCost");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "productCost", c => c.Int(nullable: false));
        }
    }
}
