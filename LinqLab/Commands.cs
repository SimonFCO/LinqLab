using LinqLab.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LinqLab
{
    internal class Commands
    {
        private readonly StoreDbContext _ctx;
        public Commands(StoreDbContext context)
        {
            _ctx = context;   
        }

        public void GetElectronics()
        {
            var Electronics = _ctx.Products
                .Where(p => p.Category.Name == "Electronics")
                .OrderByDescending(p => p.Price)
                .Select(p => new
                {
                    p.Name,
                    p.Price
                });
  
            foreach(var product in Electronics)
            {
                Console.WriteLine($"Name: {product.Name} | Price: {product.Price}");
            }
                  
        }

        public void GetSuppliersWithLess10Products()
        {
           
        }

        public void GetTotalOrderValueLastMonth()
        {
                   
        }

        public void GetTop3BestSellingProducts()
        {
                   
        }

        public void GetCategoriesWithProductCount()
        {
                   
        }

        public void GetHighValueOrdersWithDetails()
        {

        }     
    }
}
