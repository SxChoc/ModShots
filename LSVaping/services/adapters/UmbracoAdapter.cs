//using LSVaping.Models;
using LSVaping.Models;
using LSVaping.services.interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using umbraco.NodeFactory;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace LSVaping.services.adapters
{
    public class UmbracoAdapter : IUmbracoAdapter
    {

        #region productStuff
        public string replaceHyphensWithSpaces(string phrase)
        {
            var zString = phrase.Replace("-", " ");

            return zString;
        }

        public List<ProductViewModel> ProductList(string docAlias)
        {
            var pList = new List<ProductViewModel>();
            var myList = getNodesByAlias(Convert.ToInt32(ConfigurationManager.AppSettings["productsNode"]), docAlias);
            foreach (var p in myList)
            {
                bool myNew = false;
                bool mySale = false;
                if(Convert.ToString(getNodeProperty(p.Id, "newProduct")) == "1")
                {
                    myNew = true;
                }
                if (Convert.ToString(getNodeProperty(p.Id, "saleProduct")) == "1")
                {
                    mySale = true;
                }

                var myCategoriesTree = getMultiNodeItems(p.Id, "productCategories");
                var myCategorys = new List<productCategory>();
                var myCategoryString = "";
                foreach(var category in myCategoriesTree)
                {
                    myCategorys.Add(new productCategory { catID = category.Item1, category = category.Item2 });
                    myCategoryString += category.Item1.ToString() + ",";
                }   

                pList.Add(new ProductViewModel { nodeID = p.Id, productTitle = p.Name, productDescription = getNodeProperty(p.Id, "productDescription"), mainImage = getImageURLFromUDI(getNodeProperty(p.Id, "mainProductImage")), productCategories = myCategorys, categoriesString = myCategoryString, newItem = myNew, sale = mySale });
            }

            return pList;
        }

        public List<Tuple<int, string>> getMultiNodeItems(int nodeID, string alias)
        {
            var myNodes = new List<Tuple<int, string>>();

            var myPropertyValue = getNodeProperty(nodeID, alias);
            string[] UDIs = myPropertyValue.Split(',');
            foreach (string UDI in UDIs)
            {
                var treeNode = getNodeByUDI(UDI);
                myNodes.Add(new Tuple<int, string>(treeNode.Id, getNodeNameByUdi(UDI)));
            }

            return myNodes;

        }

        #endregion productStuff

        #region Get list of nodes by document alias
        public List<Node> NodesByType = new List<Node>();

        public List<Node> getNodesByAlias(int parentID, string docType)
        {
            var parent = new Node(parentID);

            List<Node> NodesByType = new List<Node>();

            foreach (Node dN in parent.Children)
            {
                if (dN.NodeTypeAlias == docType || docType == "")
                {
                    NodesByType.Add(dN);
                }
            }

            return NodesByType;
        }

        #endregion get list of nodes by document alias

        #region Get Properties from node

        public string getNodeNiceURL(int nodeID)
        {
            var node = new Node(nodeID);
            var URL = node.NiceUrl.ToString();

            return URL;
        }

        public string getNodeProperty(int nodeID, string alias)
        {
            string property = "";
            var node = new Node(nodeID);

            try
            {
                property = node.GetProperty(alias).Value;
            }
            catch
            { }

            return property;
        }

        #endregion Get Properties from node

        public Node getNodeByNodeName(int parentID, string nodeTitle)
        {
            List<Node> NodesByType = new List<Node>();
            Node returnNode = new Node();
            var parent = new Node(parentID);
            foreach(Node dN in parent.Children)
            {
                if (dN.Name.ToLower() == nodeTitle)
                {
                    returnNode = dN;
                    break;
                }
            }

            return returnNode;

        }

        #region get Node by UDI
        public Node getNodeByUDI(string nodeUDI)
        {
            var helper = new UmbracoHelper(UmbracoContext.Current);
            var node = new Node(helper.GetIdForUdi(Udi.Parse(nodeUDI)));
            return node;
        }

        public string getNodeNameByUdi(string UDI)
        {
            var zProp = "";

            Node node = getNodeByUDI(UDI);
            zProp = node.Name;

            return zProp;
        }

        #endregion get Node by UDI

        public string getImageURL(int nodeID, string zProperty)
        {
            var umbracoHelper = new Umbraco.Web.UmbracoHelper(Umbraco.Web.UmbracoContext.Current);
            var node = umbracoHelper.TypedContent(nodeID);
            string myURL = node.GetPropertyValue<IPublishedContent>(zProperty).Url;
            return myURL;
        }

        public string getImageURLFromUDI(string imageUDI)
        {
            try { 
            var umbracoHelper = new Umbraco.Web.UmbracoHelper(Umbraco.Web.UmbracoContext.Current);

            var imageGuidUdi = GuidUdi.Parse(imageUDI);
            var imageNodeID = ApplicationContext.Current.Services.EntityService.GetIdForKey(imageGuidUdi.Guid, (UmbracoObjectTypes)Enum.Parse(typeof(UmbracoObjectTypes), imageGuidUdi.EntityType, true));
            var imageNode = umbracoHelper.TypedMedia(imageNodeID.Result);

            return imageNode.Url;
            }
            catch { return ""; }
        }

    }
}