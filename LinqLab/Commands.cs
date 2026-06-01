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

            foreach (var product in Electronics)
            {
                Console.WriteLine($"Name: {product.Name} | Price: {product.Price}");
            }

        }

        public void GetSuppliersWithLess10Products()
        {
            var Suppliers = _ctx.Products
                 .Where(p => p.StockQuantity < 10)
                 .GroupBy(p => p.Supplier)
                 .Select(g => new
                 {
                     g.Key.Name,
                     products = g.Select(p => new
                     {
                         p.Name,
                         p.StockQuantity
                     })
                 });

            foreach(var supplier in Suppliers)
            {
                Console.WriteLine($"Supplier Name: {supplier.Name}");
                foreach(var product in supplier.products)
                {
                    Console.WriteLine($"--- Product Name: {product.Name} | Quantity: {product.StockQuantity}");
                }
            }

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
