using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroceryStore.Models
{
    public class Purchase
    {
        public int PurchaseId { get; set; }

        public int purchaseAmt { get; set; }

        public int ProductsID { get; set; }

        public virtual Products products { get; set; }

        public int CustomersID { get; set; }

        public virtual Customers customers { get; set; }

        public int StaffID { get; set; }

        public virtual Staff staff { get; set; }
    }
}