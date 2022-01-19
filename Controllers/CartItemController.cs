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
    public class CartItemController : Controller
    {
        private ProductContext db = new ProductContext();

        // GET: CartItem
        [Authorize]
        public ActionResult Index()
        {
            ViewBag.Total = 0;
            var cartItems = db.CartItems.Include(c => c.Product);
            foreach(CartItem item in cartItems)
            {
                ViewBag.Total += item.TotalPrice;
            }
            return View(cartItems.ToList());
        }

        // GET: CartItem/Details/5
        [Authorize]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CartItem cartItem = db.CartItems.Find(id);
            if (cartItem == null)
            {
                return HttpNotFound();
            }
            return View(cartItem);
        }

        // GET: CartItem/Create
        [Authorize]
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var product = db.Products.Find(id);
                CartItem cartItem = new CartItem { ItemID = Guid.NewGuid().ToString(), CartID = Guid.NewGuid().ToString(), Quantity = 1, DateCreated = DateTime.Now, ProductID = (int)id };
                cartItem.TotalPrice = cartItem.Quantity * product.UnitPrice;
                db.CartItems.Add(cartItem);
                db.SaveChanges();
            }
            ViewBag.ProductID = new SelectList(db.Products, "ID", "ProductName");
            return RedirectToAction("Index");
        }

        
        // GET: CartItem/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CartItem cartItem = db.CartItems.Find(id);
            if (cartItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Products, "ID", "ProductName", cartItem.ProductID);
            return View(cartItem);
        }

        // POST: CartItem/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemID,CartID,Quantity,TotalPrice,DateCreated,ProductID")] CartItem cartItem)
        {
            if (ModelState.IsValid)
            {
                CartItem TempItem = db.CartItems.Find(cartItem.ItemID);
                if (TempItem != null)
                {
                    TempItem.Quantity = cartItem.Quantity;
                    var product = db.Products.Find(TempItem.ProductID);
                    TempItem.TotalPrice = TempItem.Quantity * product.UnitPrice;
                    db.Entry(TempItem).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ProductID = new SelectList(db.Products, "ID", "ProductName", cartItem.ProductID);
            return View(cartItem);
        }

        // GET: CartItem/Delete/5
        [Authorize]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CartItem cartItem = db.CartItems.Find(id);
            if (cartItem == null)
            {
                return HttpNotFound();
            }
            return View(cartItem);
        }

        // POST: CartItem/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CartItem cartItem = db.CartItems.Find(id);
            db.CartItems.Remove(cartItem);
            db.SaveChanges();
            return RedirectToAction("Index");
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
