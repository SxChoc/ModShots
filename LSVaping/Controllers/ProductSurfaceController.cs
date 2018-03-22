using LSVaping.Models;
using LSVaping.services.adapters;
using LSVaping.services.interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace LSVaping.Controllers
{
    public class ProductSurfaceController : SurfaceController
    {
        // GET: ProductSurface
        public ActionResult Index()
        {
            IUmbracoAdapter uAD = new UmbracoAdapter();
            var title = uAD.replaceHyphensWithSpaces(Request.QueryString["p"].ToString().ToLower());
            var pNode = uAD.getNodeByNodeName(Convert.ToInt32(ConfigurationManager.AppSettings["productsNode"]), title);

            ProductViewModel m = new ProductViewModel();

            m.productTitle = pNode.Name;
            m.nodeID = pNode.Id;
            m.productDescription = uAD.getNodeProperty(pNode.Id, "productDescription");
            m.mainImage = uAD.getImageURLFromUDI(uAD.getNodeProperty(pNode.Id, "mainProductImage"));

            return PartialView("Product", m);
        }
    }
}