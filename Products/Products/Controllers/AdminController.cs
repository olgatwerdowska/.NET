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

        public ViewResult Index() => View(repository.Products); // zwraca wszytskie produkty

        public ViewResult GetById(int id) => View(repository.Products.Single(p => p.ProductId == id)); // zwraca produkt wyvrany po id


        public ViewResult Edit(int productId) => View(repository.Products.FirstOrDefault(p => p.ProductId == productId)); //Do widoku edycji zwraca model produktu na podstawie podanego ID
        [HttpPost]

        public ActionResult Save(Product product) //zapisuje podaną encję w bazie danych (przez repozytorium)
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

        public ViewResult Create() => View("Edit", new Product()); //Do widoku edycji zwraca nową encję produktu

        [HttpPost]

        public ActionResult Delete(int productId) //Na podstawie podanego id poprzez repozytorium usuwa produkt z bazy
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
