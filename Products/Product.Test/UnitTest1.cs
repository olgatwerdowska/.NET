using System;
using Xunit;
using Products.Models;
using Moq;
using System.Linq;
using Products.Controllers;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Products.Test
{
    public class ProductControllerTest

    {
        private static T GetViewModel<T>(IActionResult result) where T : class
        {
            return (result as ViewResult)?.ViewData.Model as T;
        }

        [Fact]
        public void AllProductsTest()
        {
            var mock = new Mock<IProductRepository>();

            mock.Setup(m => m.Products).Returns(new[]
            {
                new Product {Name = "Test1", ProductId = 1, Category = "categoryTest1", Description = "DescriptionTest1", Price = 100},
                new Product {Name = "Test2", ProductId = 2, Category = "categoryTest2", Description = "DescriptionTest2", Price = 100},
                new Product {Name = "Test3", ProductId = 3, Category = "categoryTest3", Description = "DescriptionTest3", Price = 100},
            }.AsQueryable());

            var controller = new AdminController(mock.Object);

            var result = GetViewModel<IEnumerable<Product>>(controller.Index())?.ToArray();

            Assert.NotNull(result);
            Assert.Equal(3, result.Length);
            Assert.Equal("Test1", result[0].Name);
            Assert.Equal("Test2", result[1].Name);
            Assert.Equal("Test3", result[2].Name);
        }

        [Fact]
        public void EditTest()
        {
            var mock = new Mock<IProductRepository>();

            mock.Setup(m => m.Products).Returns(new[] {
                new Product {Name = "Test1", ProductId = 1, Category = "categoryTest1", Description = "DescriptionTest1", Price = 100},
                new Product {Name = "Test2", ProductId = 2, Category = "categoryTest2", Description = "DescriptionTest2", Price = 100},
                new Product {Name = "Test3", ProductId = 3, Category = "categoryTest3", Description = "DescriptionTest3", Price = 100},
            }.AsQueryable());

            var controller = new AdminController(mock.Object);

            var p1 = GetViewModel<Product>(controller.Edit(1));
            var p2 = GetViewModel<Product>(controller.Edit(2));
            var p3 = GetViewModel<Product>(controller.Edit(3));

            Assert.Equal(1, p1.ProductId);
            Assert.Equal(2, p2.ProductId);
            Assert.Equal(3, p3.ProductId);
        }

        [Fact]
        public void DeleteTest()
        {
            var mock = new Mock<IProductRepository>();

            mock.Setup(m => m.Products).Returns(new[] {
                new Product {Name = "Test1", ProductId = 1, Category = "categoryTest1", Description = "DescriptionTest1", Price = 100},
                new Product {Name = "Test2", ProductId = 2, Category = "categoryTest2", Description = "DescriptionTest2", Price = 100},
                new Product {Name = "Test3", ProductId = 3, Category = "categoryTest3", Description = "DescriptionTest3", Price = 100},
            }.AsQueryable());

            var product_delete = new Product { Name = "Test1", ProductId = 1, Category = "categoryTest1", Description = "DescriptionTest1", Price = 100 };

            var controller = new AdminController(mock.Object);

            controller.Delete(product_delete.ProductId);

            mock.Verify(m => m.DeleteProduct(product_delete.ProductId));

        }

        [Fact]
        public void CategoryFilterTest()
        {
            var mock = new Mock<IProductRepository>();

            mock.Setup(m => m.Products).Returns(new[]
            {
                new Product {Name = "Test1", ProductId = 1, Category = "categoryTest1", Description = "DescriptionTest1", Price = 100},
                new Product {Name = "Test2", ProductId = 2, Category = "categoryTest2", Description = "DescriptionTest2", Price = 100},
                new Product {Name = "Test3", ProductId = 3, Category = "categoryTest3", Description = "DescriptionTest3", Price = 100},
            }.AsQueryable());

            var controller = new ProductController(mock.Object);;

            Product[] result = GetViewModel<IEnumerable<Product>>(controller.List("categoryTest1")).ToArray();

            Assert.Single(result);
            Assert.True(result[0].Category == "categoryTest1");

        }

    }
}
