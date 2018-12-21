namespace GroceryStore.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using GroceryStore.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<GroceryStore.Models.GroceryModelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "GroceryStore.Models.GroceryModelContext";
        }

        protected override void Seed(GroceryStore.Models.GroceryModelContext context)
        {
            var branch = new List<Branch>
            {
                new Branch { brnachName="GroceryStore_1",branchCity="Dublin",branchRegion="Leinster",branchCountry="Ireland"},
                new Branch { brnachName="GroceryStore_2",branchCity="Cork",branchRegion="Munster",branchCountry="Ireland"},
                new Branch { brnachName="GroceryStore_3",branchCity="Wicklow",branchRegion="Leinster",branchCountry="Ireland"},
                new Branch { brnachName="GroceryStore_4",branchCity="Wicklow",branchRegion="Leinster",branchCountry="Ireland"},
                new Branch { brnachName="GroceryStore_5",branchCity="Wicklow",branchRegion="Leinster",branchCountry="Ireland"},
            };
            branch.ForEach(b => context.Branch.AddOrUpdate(Branch => Branch.brnachName, b));
            context.SaveChanges();

            var customers = new List<Customers>
            {
                new Customers { customerName="John",customerNO=0892014576,customerCity="Dublin",customerRegion="Leinster",customerCountry="Ireland"},
                new Customers { customerName="Mark",customerNO=0892014576,customerCity="Dublin",customerRegion="Leinster",customerCountry="Ireland"},
                new Customers { customerName="Hitchcock",customerNO=0892014576,customerCity="Dublin",customerRegion="Leinster",customerCountry="Ireland"},
                new Customers { customerName="Sam",customerNO=0892014576,customerCity="Dublin",customerRegion="Leinster",customerCountry="Ireland"},
                new Customers { customerName="Leonard",customerNO=0892014576,customerCity="Dublin",customerRegion="Leinster",customerCountry="Ireland"},
            };
            customers.ForEach(c => context.Customers.AddOrUpdate(Customers => Customers.customerName, c));
            context.SaveChanges();
        }
    }
}
