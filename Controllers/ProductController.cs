using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ECommerce.Models;

namespace ECommerce.Controllers
{
    public class ProductController : Controller
    {
        private ProductContext db = new ProductContext();

        // GET: Products
        public ActionResult Index(string searchString)
        {
            var products = from p in db.Products select p;
            if(!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(p => p.ProductName.ToUpper().Contains(searchString.ToUpper()) || p.Category.CategoryName.ToUpper().Contains(searchString.ToUpper())); 
            }
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
