using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Products.Models;

namespace Products.Controllers
    
{
    [Authorize]
    public class AdminController : Controller


    {
        private IProductRepository repository;

        public AdminController(IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index() => View(repository.Products);

        public ViewResult Edit(int productId) => View(repository.Products.FirstOrDefault(p => p.ProductId == productId));
        [HttpPost]

        public ActionResult Save(Product product)
        {
            if(ModelState.IsValid)
            {
                repository.SaveProduct(product);
                TempData["message"] = $"Zapisano{product.Name}";
                return RedirectToAction("Index");
            }
            else
            {
                return View("Edit", product);
            }
        }

        public ViewResult Create() => View("Edit", new Product());

        [HttpPost]

        public ActionResult Delete(int productId)
        {
            Product deleteProduct = repository.DeleteProduct(productId);

            if(deleteProduct != null)
            {
                TempData["message"] = $"Usunieto{deleteProduct.Name}";
            }

            return RedirectToAction("Index");
        }
    }
}
