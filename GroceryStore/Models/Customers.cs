using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroceryStore.Models
{
    public class Customers
    {
        public int CustomersId { get; set; }

        public string customerName { get; set; }

        public int customerNO { get; set; }

        public string customerCity { get; set; }

        public string customerRegion { get; set; }

        public string customerCountry { get; set; }
    }
}