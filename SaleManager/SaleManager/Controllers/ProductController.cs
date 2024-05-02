using SaleManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SaleManager.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext context = new ApplicationDbContext();

        // GET: Product/Index
        public ActionResult Index()
        {
            var products = context.Products.ToList();

            
            var productViewModels = products.Select(p => new ProductViewModel
            {
                ID = p.Id,
                Name = p.Name,
                Price = p.Price,
                CategoryID = p.CategoryID.Id,
                Categories = context.Categories.ToList() 
            }).ToList();

            return View(productViewModels);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            var viewModel = new ProductViewModel
            {
                Categories = context.Categories.ToList()
            };

            return View(viewModel);
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(ProductViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                
                var cate = context.Categories.FirstOrDefault(c => c.Id == viewModel.CategoryID);

                
                var product = new Product
                {
                    Name = viewModel.Name,
                    Price = viewModel.Price,
                    CategoryID = cate
                };

                context.Products.Add(product);
                context.SaveChanges();

                return RedirectToAction("Index", "Product");
            }
            viewModel.Categories = context.Categories.ToList();
            return View(viewModel);
        }

        // GET: Product/Delete/{id}
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            
            var product = context.Products.Find(id);

            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

        // POST: Product/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            
            var product = context.Products.Find(id);

            if (product == null)
            {
                return HttpNotFound();
            }

            
            context.Products.Remove(product);
            context.SaveChanges();

            return RedirectToAction("Index");
        }


        // GET: Product/Edit/{id}
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            
            var product = context.Products.Find(id);

            if (product == null)
            {
                return HttpNotFound();
            }

            
            var viewModel = new ProductViewModel
            {
                ID = product.Id,
                Name = product.Name,
                Price = product.Price,
                CategoryID = product.CategoryID.Id,
                Categories = context.Categories.ToList() 
            };

            return View(viewModel);
        }

        // POST: Product/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var product = context.Products.Find(viewModel.ID);

                if (product == null)
                {
                    return HttpNotFound();
                }

                var category = context.Categories.Find(viewModel.CategoryID);

                if (category == null)
                {
                    return HttpNotFound();
                }

                
                product.Name = viewModel.Name;
                product.Price = viewModel.Price;
                product.CategoryID = category; 
                
                context.SaveChanges();

                return RedirectToAction("Index");
            }

            
            viewModel.Categories = context.Categories.ToList();
            return View(viewModel);
        }

    }
}
    