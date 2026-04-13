using LinqLab.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinqLab
{
    internal class Commands
    {
        public static void GetElectronics()
        {
            using (var ctx = new StoreContext())
            {
                ctx.Database.EnsureCreated();
                var Electronics = ctx.Products
                    .Where(p => p.Category.Name == "Electronics")
                    .OrderByDescending(p => p.Price)
                    .Select(p => new
                    {
                        p.Name,
                        p.Price
                    });

                Console.WriteLine(@"System\> All Electronic Products:");
                foreach (var product in Electronics)
                {
                    Console.WriteLine($"{product.Name} {product.Price} SEK");
                }
            }
        }

        public static void GetSuppliersLess10()
        {
            using (var ctx = new StoreContext())
            {
                ctx.Database.EnsureCreated();

                var suppliers = ctx.Suppliers
                    .Include(s => s.Products)
                    .Where(s => s.Products.Any(p => p.StockQuantity < 10))
                    .ToList();

                foreach (var currentSupplier in suppliers)
                {
                    Console.WriteLine($"\n" + @"System\>Supplier: {currentSupplier.Name}");

                    foreach (var product in currentSupplier.Products)
                    {
                        if (product.StockQuantity < 10)
                        {
                            Console.WriteLine($"  - Product: {product.Name} (Stock: {product.StockQuantity})");
                        }
                    }
                }
            }

        }

        public static void GetTotalOrderValueLastMonth()
        {
            using (var ctx = new StoreContext())
            {
               
            }
        }

        public static void GetTop3BestSellingProducts()
        {
            using (var ctx = new StoreContext())
            {
                
            }
        }

        public static void GetCategoriesWithProductCount()
        {
            using (var ctx = new StoreContext())
            {
               
            }
        }

        public static void GetHighValueOrdersWithDetails()
        {
            using (var ctx = new StoreContext())
            {
               
            }
        }
    }
}

