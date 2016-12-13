using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Script.Serialization;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Json;



namespace BookLibrary_Client.Models
{
    public class ProductServiceClient
    {
        private string BASE_URL = "http://localhost:50026/productService.svc/";
        //method for findAll
        public List<Product> findAll()
        {
            try
            {
                var webclient = new WebClient();
                var json = webclient.DownloadString(BASE_URL + "findall");
                var javascriptJson = new JavaScriptSerializer();
                return javascriptJson.Deserialize<List<Product>>(json);
            }
            catch
            {
                return null;
            }
        }

        //the method for find
        public Product find(string book_ID)
        {
            try
            {
                var webclient = new WebClient();
                string url = string.Format(BASE_URL + "find/{0}", book_ID);
                var json = webclient.DownloadString(url);
                var javascriptJson = new JavaScriptSerializer();
                return javascriptJson.Deserialize<Product>(json);
            }
            catch
            {
                return null;
            }
        }

        //the method for create
        public bool create(Product product)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Product));
                MemoryStream memory = new MemoryStream();
                ser.WriteObject(memory, product);
                string data = Encoding.UTF8.GetString(memory.ToArray(), 0, (int)memory.Length);
                WebClient webclient = new WebClient();
                webclient.Headers["Content-Type"] = "application/json";
                webclient.Encoding = Encoding.UTF8;
                webclient.UploadString(BASE_URL + "create", "POST", data);            
                return true;
            }
            catch
            {
                return false;
            }
        }

        //the method for edit
        public bool edit(Product product)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Product));
                MemoryStream memory = new MemoryStream();
                ser.WriteObject(memory, product);
                string data = Encoding.UTF8.GetString(memory.ToArray(), 0, (int)memory.Length);
                WebClient webclient = new WebClient();
                webclient.Headers["Content-Type"] = "application/json";
                webclient.Encoding = Encoding.UTF8;
                webclient.UploadString(BASE_URL + "edit", "PUT", data);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //the method for delete
        public bool delete(Product product)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Product));
                MemoryStream memory = new MemoryStream();
                ser.WriteObject(memory, product);
                string data = Encoding.UTF8.GetString(memory.ToArray(), 0, (int)memory.Length);
                WebClient webclient = new WebClient();
                webclient.Headers["Content-Type"] = "application/json";
                webclient.Encoding = Encoding.UTF8;
                webclient.UploadString(BASE_URL + "delete", "DELETE", data);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}