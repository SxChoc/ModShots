using LSVaping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using umbraco.NodeFactory;
using Umbraco.Core;

namespace  LSVaping.services.interfaces
{
    public interface IUmbracoAdapter
    {
        List<Node> getNodesByAlias(int parentID, string docType);

        #region Get Node Properties
        /// <summary> Description get the URL from the node ID </summary>
        /// <param name="disList"> An integer containing the node ID </param>
        /// <returns> The 'Nice' URL of the node. </returns>

        string getNodeNiceURL(int NodeID);

        string getNodeProperty(int nodeID, string alias);

        Node getNodeByUDI(string nodeUDI);

        string getNodeNameByUdi(string UDI);

        string getImageURL(int nodeID, string zProperty);

        string getImageURLFromUDI(string imageUDI);

        #endregion Get Node Properties

        #region ProductStuff

        Node getNodeByNodeName(int parentID, string nodeTitle);

        string replaceHyphensWithSpaces(string phrase);

        List<ProductViewModel> ProductList(string docAlias);

        #endregion ProductStuff
    }
}