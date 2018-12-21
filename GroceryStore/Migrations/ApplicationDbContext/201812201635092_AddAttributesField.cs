namespace GroceryStore.Migrations.ApplicationDbContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAttributesField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Attributes", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Attributes");
        }
    }
}
