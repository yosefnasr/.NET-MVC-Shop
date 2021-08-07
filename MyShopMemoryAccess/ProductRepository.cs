﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using MyShopMain.Models;

namespace MyShopMemoryAccess
{
    public class ProductRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Product> products;

        public ProductRepository()
        {
            products = cache["products"] as List<Product>;
            if (products == null)
                products = new List<Product>();
        }

        public void Commit()
        {
            cache["products"] = products;
        }

        public void Insert(Product product)
        {
            products.Add(product);
        }

        public void Update(Product product)
        {
            Product oldProduct = products.Find(p => p.Id == product.Id);
            if (oldProduct != null)
                oldProduct = product;
            else
                throw new Exception("Product not found");
        }

        public Product Find(string Id)
        {
            Product product = products.Find(p => p.Id == Id);
            if (product != null)
                return product;
            else
                throw new Exception("Product not found");
        }

        public IQueryable<Product> Collection()
        {
            return products.AsQueryable();
        }

        public void Delete(string Id)
        {
            Product product = products.Find(p => p.Id == Id);
            if (product != null)
                products.Remove(product);
            else
                throw new Exception("Product not found");
        }
    }
}
