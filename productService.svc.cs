using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BookLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "productService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select productService.svc or productService.svc.cs at the Solution Explorer and start debugging.
    public class productService : IproductService
    {
        public bool create(Product product)
        {
            using (hackEntities mybook = new hackEntities())
            {

                try
                {
                    bookEntity be = new bookEntity();
                    be.title = product.title;
                    be.author = product.author;
                    be.price = product.price;
                    be.quantity = product.quantity;
                    mybook.bookEntities.Add(be);
                    mybook.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
                
            };
        }

        public bool delete(Product product)
        {
            using (hackEntities mybook = new hackEntities())
            {

                try
                {
                    int bookid = Convert.ToInt32(product.bookID);
                    bookEntity be = mybook.bookEntities.Single(p => p.bookID == bookid);
                    mybook.bookEntities.Remove(be);
                    mybook.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }

            };
        }

        public bool edit(Product product)
        {
            using (hackEntities mybook = new hackEntities())
            {

                try
                {
                    int bookid = Convert.ToInt32(product.bookID);
                    bookEntity be = mybook.bookEntities.Single(p => p.bookID == bookid);
                    be.title = product.title;
                    be.author = product.author;
                    be.price = product.price;
                    be.quantity = product.quantity;
                    mybook.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }

            };
        }

        public Product find(string book_ID)
        {
            using (hackEntities mybook = new hackEntities())
            {
                int bookid = Convert.ToInt32(book_ID);
                return mybook.bookEntities.Where(be => be.bookID == bookid).Select(be => new Product
                {
                    bookID = be.bookID,
                    title = be.title,
                    author = be.author,
                    price = be.price.Value,
                    quantity = be.quantity.Value
                    //creationDate = be.creationDate
                }).First();
            };
        }

        public List<Product> findAll()
        {
            using (hackEntities mybook = new hackEntities()) {
                return mybook.bookEntities.Select(be => new Product {
                    bookID = be.bookID,
                    title = be.title,
                    author = be.author,
                    price = be.price.Value,
                    quantity = be.quantity.Value
                }).ToList();
            };
        }
    }
}
