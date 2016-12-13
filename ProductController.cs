using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookLibrary_Client.Models;
using BookLibrary_Client.ViewModels;

namespace BookLibrary_Client.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            ProductServiceClient psc = new ProductServiceClient();
            ViewBag.listProducts = psc.findAll();
            return View();
        }

        [HttpGet]

        // Create a new Product
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        // GET: Product
        public ActionResult Create(ProductViewModel pvm)
        {
            ProductServiceClient psc = new ProductServiceClient();
            psc.create(pvm.Product);
            return RedirectToAction("Index");
        }


        // Delete the book
        public ActionResult Delete(string book_id)
        {
            ProductServiceClient psc = new ProductServiceClient();
            psc.delete(psc.find(book_id));
            return RedirectToAction("Index");
        }

        [HttpGet]

        public ActionResult Edit(string book_id)
        {
            ProductServiceClient psc = new ProductServiceClient();
            ProductViewModel pvm = new ProductViewModel();
            pvm.Product = psc.find(book_id);
            return View("Edit", pvm);
        }


        [HttpPost]

        public ActionResult Edit(ProductViewModel pvm)
        {
            ProductServiceClient psc = new ProductServiceClient();
            psc.edit(pvm.Product);
            return RedirectToAction("Index");
        }

    }
}