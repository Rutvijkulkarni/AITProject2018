namespace GroceryStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        BranchId = c.Int(nullable: false, identity: true),
                        brnachName = c.String(),
                        branchCity = c.String(),
                        branchRegion = c.String(),
                        branchCountry = c.String(),
                    })
                .PrimaryKey(t => t.BranchId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomersId = c.Int(nullable: false, identity: true),
                        customerName = c.String(),
                        customerNO = c.Int(nullable: false),
                        customerCity = c.String(),
                        customerRegion = c.String(),
                        customerCountry = c.String(),
                    })
                .PrimaryKey(t => t.CustomersId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductsId = c.Int(nullable: false, identity: true),
                        productName = c.String(),
                        productExpiry = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProductsId);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        PurchaseId = c.Int(nullable: false, identity: true),
                        purchaseAmt = c.Int(nullable: false),
                        ProductsID = c.Int(nullable: false),
                        CustomersID = c.Int(nullable: false),
                        StaffID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PurchaseId)
                .ForeignKey("dbo.Customers", t => t.CustomersID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductsID, cascadeDelete: true)
                .ForeignKey("dbo.Staffs", t => t.StaffID, cascadeDelete: true)
                .Index(t => t.ProductsID)
                .Index(t => t.CustomersID)
                .Index(t => t.StaffID);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        staffID = c.Int(nullable: false, identity: true),
                        staffName = c.String(),
                        position = c.String(),
                        sex = c.String(),
                        staffCity = c.String(),
                        staffRegion = c.String(),
                        staffCountry = c.String(),
                    })
                .PrimaryKey(t => t.staffID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Purchases", "StaffID", "dbo.Staffs");
            DropForeignKey("dbo.Purchases", "ProductsID", "dbo.Products");
            DropForeignKey("dbo.Purchases", "CustomersID", "dbo.Customers");
            DropIndex("dbo.Purchases", new[] { "StaffID" });
            DropIndex("dbo.Purchases", new[] { "CustomersID" });
            DropIndex("dbo.Purchases", new[] { "ProductsID" });
            DropTable("dbo.Staffs");
            DropTable("dbo.Purchases");
            DropTable("dbo.Products");
            DropTable("dbo.Customers");
            DropTable("dbo.Branches");
        }
    }
}
