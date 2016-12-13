using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BookLibrary_Client.Models
{
    public class Product
    {
        [Display(Name ="bookID")]
        //get ad set the Id
        public int bookID
        {
            get;
            set;
        }

        [Display(Name = "title")]
        //get ad set the title
        public string title
        {
            get;
            set;
        }

        [Display(Name = "author")]
        //get ad set the author
        public string author
        {
            get;
            set;
        }

        [Display(Name = "price")]
        //get ad set the price
        public decimal price
        {
            get;
            set;
        }


        [Display(Name = "quantity")]
        //get ad set the quantity
        public int quantity
        {
            get;
            set;
        }

        //get ad set the creationDate
       // public DateTime creationDate
       // {
         //   get;
        //    set;
       // }
    }
}