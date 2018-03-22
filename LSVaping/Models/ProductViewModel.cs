using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LSVaping.Models
{
    public class ProductViewModel
    {
        public int nodeID { get; set; }
        public string productTitle { get; set; }
        public string productDescription { get; set; }
        public string mainImage { get; set; }
        public List<productCategory> productCategories { get; set; }
        public string categoriesString { get; set; }
        public bool sale { get; set; }
        public bool newItem { get; set; }
    }

    public class productCategory {
        public int catID { get; set; }
        public string category { get; set; }
    }
}