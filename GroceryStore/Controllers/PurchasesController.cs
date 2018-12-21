using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GroceryStore.Models;

namespace GroceryStore.Controllers
{
    public class PurchasesController : Controller
    {
        private GroceryModelContext db = new GroceryModelContext();

        // GET: Purchases
        public ActionResult Index()
        {
            var purchase = db.Purchase.Include(p => p.customers).Include(p => p.products).Include(p => p.staff);
            return View(purchase.ToList());
        }

        // GET: Purchases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase purchase = db.Purchase.Find(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            return View(purchase);
        }

        // GET: Purchases/Create
        public ActionResult Create()
        {
            ViewBag.CustomersID = new SelectList(db.Customers, "CustomersId", "customerName");
            ViewBag.ProductsID = new SelectList(db.Products, "ProductsId", "productName");
            ViewBag.StaffID = new SelectList(db.Staff, "staffID", "staffName");
            return View();
        }

        // POST: Purchases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PurchaseId,purchaseAmt,ProductsID,CustomersID,StaffID")] Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                db.Purchase.Add(purchase);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomersID = new SelectList(db.Customers, "CustomersId", "customerName", purchase.CustomersID);
            ViewBag.ProductsID = new SelectList(db.Products, "ProductsId", "productName", purchase.ProductsID);
            ViewBag.StaffID = new SelectList(db.Staff, "staffID", "staffName", purchase.StaffID);
            return View(purchase);
        }

        // GET: Purchases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase purchase = db.Purchase.Find(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomersID = new SelectList(db.Customers, "CustomersId", "customerName", purchase.CustomersID);
            ViewBag.ProductsID = new SelectList(db.Products, "ProductsId", "productName", purchase.ProductsID);
            ViewBag.StaffID = new SelectList(db.Staff, "staffID", "staffName", purchase.StaffID);
            return View(purchase);
        }

        // POST: Purchases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PurchaseId,purchaseAmt,ProductsID,CustomersID,StaffID")] Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomersID = new SelectList(db.Customers, "CustomersId", "customerName", purchase.CustomersID);
            ViewBag.ProductsID = new SelectList(db.Products, "ProductsId", "productName", purchase.ProductsID);
            ViewBag.StaffID = new SelectList(db.Staff, "staffID", "staffName", purchase.StaffID);
            return View(purchase);
        }

        // GET: Purchases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase purchase = db.Purchase.Find(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            return View(purchase);
        }

        // POST: Purchases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Purchase purchase = db.Purchase.Find(id);
            db.Purchase.Remove(purchase);
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
