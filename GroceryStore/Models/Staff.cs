using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroceryStore.Models
{
    public class Staff
    {
        public int staffID { get; set; }

        public string staffName { get; set; }

        public string position { get; set; }

        public string sex { get; set; }

        public string staffCity { get; set; }

        public string staffRegion { get; set; }

        public string staffCountry { get; set; }
    }
}