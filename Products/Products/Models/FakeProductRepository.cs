using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Models
{
    public class FakeProductRepository : IProductRepository
    {
        public IQueryable<Product> Products => new List<Product>
        {
            new Product {Name = "Pilka nozna", Price = 25},
            new Product {Name = "Pilka nozna", Price = 179},
            new Product {Name = "Pilka nozna", Price = 95}
        }.AsQueryable<Product>();
    }
}
