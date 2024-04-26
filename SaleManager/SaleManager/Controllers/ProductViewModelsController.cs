using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SaleManager.Models;

namespace SaleManager.Controllers
{
    public class ProductViewModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProductViewModels
        public ActionResult Index()
        {
            return View(db.ProductViewModels.ToList());
        }

        // GET: ProductViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductViewModel productViewModel = db.ProductViewModels.Find(id);
            if (productViewModel == null)
            {
                return HttpNotFound();
            }
            return View(productViewModel);
        }

        // GET: ProductViewModels/Create
        public ActionResult Create()
        {
            var viewModel = new ProductViewModel()
            {
                Categories = db.Categories.ToList()
        };
            return View(viewModel);
        }

        // POST: ProductViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Price,CategoryID")] ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                db.ProductViewModels.Add(productViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productViewModel);
        }

        // GET: ProductViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductViewModel productViewModel = db.ProductViewModels.Find(id);
            if (productViewModel == null)
            {
                return HttpNotFound();
            }
            return View(productViewModel);
        }

        // POST: ProductViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Price,CategoryID")] ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productViewModel);
        }

        // GET: ProductViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductViewModel productViewModel = db.ProductViewModels.Find(id);
            if (productViewModel == null)
            {
                return HttpNotFound();
            }
            return View(productViewModel);
        }

        // POST: ProductViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductViewModel productViewModel = db.ProductViewModels.Find(id);
            db.ProductViewModels.Remove(productViewModel);
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
