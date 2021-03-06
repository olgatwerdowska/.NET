﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Models
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }

        void SaveProduct(Product product);
        Product DeleteProduct(int productId);

        //warstwa odpowiadająca za dostęp do bazy danych
    }
}
