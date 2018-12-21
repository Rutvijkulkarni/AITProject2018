using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroceryStore.Models
{
    public class Branch
    {
        public int BranchId { get; set; }

        public string brnachName { get; set; }

        public string branchCity { get; set; }

        public string branchRegion { get; set; }

        public string branchCountry { get; set; }
    }
}