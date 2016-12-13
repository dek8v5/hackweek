using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BookLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IproductService" in both code and config file together.
    [ServiceContract]
    public interface IproductService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "findall", ResponseFormat = WebMessageFormat.Json)]

        List<Product> findAll();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "find/{bookID}", ResponseFormat = WebMessageFormat.Json)]
        Product find(string bookID);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "create", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool create(Product product);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "edit", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool edit(Product product);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "delete", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool delete(Product product);
    }
}
