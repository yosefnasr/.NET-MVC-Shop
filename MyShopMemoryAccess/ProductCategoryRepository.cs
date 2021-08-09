﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using MyShopMain.Models;

namespace MyShopMemoryAccess
{
    public class ProductCategoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> productCategories;

        public ProductCategoryRepository()
        {
            productCategories = cache["productCategories"] as List<ProductCategory>;
            if (productCategories == null)
                productCategories = new List<ProductCategory>();
        }

        public void Commit()
        {
            cache["productCategories"] = productCategories;
        }

        public void Insert(ProductCategory productCategory)
        {
            productCategories.Add(productCategory);
        }

        public void Update(ProductCategory productCategory)
        {
            ProductCategory oldProduct = productCategories.Find(c => c.Id == productCategory.Id);
            if (oldProduct != null)
                oldProduct = productCategory;
            else
                throw new Exception("Product not found");
        }

        public ProductCategory Find(string Id)
        {
            ProductCategory productCategory = productCategories.Find(c => c.Id == Id);
            if (productCategory != null)
                return productCategory;
            else
                throw new Exception("Product not found");
        }

        public IQueryable<ProductCategory> Collection()
        {
            return productCategories.AsQueryable();
        }

        public void Delete(string Id)
        {
            ProductCategory productCategory = productCategories.Find(c => c.Id == Id);
            if (productCategory != null)
                productCategories.Remove(productCategory);
            else
                throw new Exception("Product not found");
        }
    }
}
