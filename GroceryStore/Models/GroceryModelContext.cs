using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace GroceryStore.Models
{
    public class GroceryModelContext : DbContext
    {

        public GroceryModelContext() : base("GroceryModelContext")
    {

    }

    public DbSet<Products> Products { get; set; }

    public DbSet<Branch> Branch { get; set; }

    public DbSet<Customers> Customers { get; set; }

    public DbSet<Staff> Staff { get; set; }

    public DbSet<Purchase> Purchase { get; set; }
    }
}