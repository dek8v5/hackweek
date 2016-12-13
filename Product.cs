using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookLibrary
{
    public class Product
    {
        //get ad set the Id
        public int bookID
        {
            get;
            set;
        }

        //get ad set the title
        public string title
        {
            get;
            set;
        }

        //get ad set the author
        public string author
        {
            get;
            set;
        }

        //get ad set the price
        public decimal price
        {
            get;
            set;
        }

        //get ad set the quantity
        public int quantity
        {
            get;
            set;
        }

        //get ad set the creationDate
        //public DateTime creationDate
        //{
         //   get;
          //  set;
        //}
    }
}