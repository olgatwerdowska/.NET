using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Products.Models;

namespace Products.Controllers
{
    public class ProductController : Controller
    {

            private readonly IProductRepository productRepository;

            public ProductController(IProductRepository productRepository)
            {
                this.productRepository = productRepository;
            }

            public ViewResult List_All() => View(productRepository.Products);  // zwraca liste produktow

        public ViewResult List(string category) => View(productRepository.Products.Where(p => p.Category == category)); //zwraca liste produktow wedlug kategorii
            public IActionResult Index()
            {
                return View();
            }

    }
}
