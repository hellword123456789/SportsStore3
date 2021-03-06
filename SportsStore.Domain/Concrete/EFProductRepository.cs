﻿using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using System.Collections.Generic;

namespace SportsStore.Domain.Concrete
{
    public class EFProductRepository:IProductRepository
    {
        private EFDbContext context = Repository.GetDbContext;
        public IEnumerable<Product> Products
        {
            get { return context.Products; }
        }

        public void SaveProduct(Product product)
        {
            if (product.ProductID == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                Product dbentry = context.Products.Find(product.ProductID);
                if (dbentry != null)
                {
                    dbentry.Name = product.Name;
                    dbentry.Description = product.Description;
                    dbentry.Price = product.Price;
                    dbentry.Category = product.Category;
                    dbentry.ImageData = product.ImageData;
                    dbentry.ImageMimeType = product.ImageMimeType;
                }
            }
            context.SaveChanges();
        }
        
        public Product DeleteProduct(int productId)
        {
            Product dbentry = context.Products.Find(productId);
            if (dbentry != null)
            {
                context.Products.Remove(dbentry);
                context.SaveChanges();
            }
            return dbentry;
        }

       
    }
}
