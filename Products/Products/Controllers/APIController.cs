using Microsoft.AspNetCore.Mvc;
using Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Controllers
{
    public class APIController : Controller
    {

        private readonly IProductRepository productRepository;

        public APIController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet("GetAll")]
        public ViewResult List_All() => View(productRepository.Products);

        [HttpGet("GetByCategory")]
        public ViewResult List(string category) => View(productRepository.Products.Where(p => p.Category == category));
        
        [HttpGet("GetById")]
        public ViewResult GetById(int id) => View(productRepository.Products.Single(p => p.ProductId == id));

        [HttpPost]
        public ActionResult<Product> AddProduct(Product product)
        {
            productRepository.SaveProduct(product);
            return Ok(product);
        }

        [HttpDelete]
        public ActionResult<Product> Delete(int productId)
        {
            productRepository.DeleteProduct(productId);
            return NoContent();
        }

        [HttpPut]
        public ActionResult UpdateProduct(Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (!productRepository.Products.Any(p => p.ProductId == product.ProductId))
                return NotFound();

            productRepository.SaveProduct(product);
            return NoContent();
        }

    }
}
