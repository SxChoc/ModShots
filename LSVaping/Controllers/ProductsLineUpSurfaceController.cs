using LSVaping.services.adapters;
using LSVaping.services.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace LSVaping.Controllers
{
    public class ProductsLineUpSurfaceController : SurfaceController
    {
        // GET: ProductsLineUpSurface
        public ActionResult Index()
        {
            IUmbracoAdapter uAD = new UmbracoAdapter();
            var m = uAD.ProductList("oneShot");


            return PartialView("ProductLineUp", m);
        }
    }
}