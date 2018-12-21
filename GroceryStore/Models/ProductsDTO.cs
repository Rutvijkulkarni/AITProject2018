using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroceryStore.Models
{
    public class ProductsDTO
    {
        public int ProductsId { get; set; }

        public string productName { get; set; }

        public DateTime productExpiry { get; set; }
    }
}