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
                    Console.WriteLine($"\n" + @"System\>Supplier: " + currentSupplier.Name);

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
                var MonthAgo = DateTime.Now.AddMonths(-1);
                var DetailsThisMonth = ctx.OrderDetails
                   .Where(od => od.Order.OrderDate >= MonthAgo)
                   .Sum(od => od.Quantity * od.UnitPrice);

                Console.WriteLine(DetailsThisMonth.ToString());

            }
        }

        public static void GetTop3BestSellingProducts()
        {
            using (var ctx = new StoreContext())
            {
                var products = ctx.Products
                    .Select(p => new
                    {
                        p.Name,
                        TotalSold = p.OrderDetails.Sum(od => od.Quantity)
                    })
                    .OrderByDescending(p => p.TotalSold)
                    .Take(3)
                    .ToList();

                foreach(var product in products)
                {
                    Console.WriteLine($"Namn: {product.Name}, Antal Sålda: {product.TotalSold}");
                }


            }
        }

        public static void GetCategoriesWithProductCount()
        {
            using (var ctx = new StoreContext())
            {
                var categoryList = ctx.Categories
                    .Select(c => new
                    {
                        c.Name,
                        productCount = c.Products.Count()
                        

                    })
                    .ToList();

                Console.WriteLine("Alla kategorier");
                foreach(var category in categoryList)
                {
                    Console.WriteLine($"Namn: {category.Name}, Antal: {category.productCount}");
                }
            }
        }

        public static void GetHighValueOrdersWithDetails()
        {
            using (var ctx = new StoreContext())
            {
                var OrderLists = ctx.Orders
                    .Include(s => s.OrderDetails)
                        .ThenInclude(od => od.Product)
                    .Include(s => s.Customer)
                    .Where(od => od.TotalAmount > 1000)
                    .ToList();

                foreach (var order in OrderLists)
                {
                    Console.WriteLine($"Order-ID: {order.Id} | Belopp: {order.TotalAmount} kr");
                    Console.WriteLine($"Kundnamn: {order.Customer.Name}");
                    Console.WriteLine("Orderdetaljer:");

                    foreach (var detail in order.OrderDetails)
                    {
                        Console.WriteLine($"  - Produkt ID: {detail.ProductId}, Namn: {detail.Product.Name}, Antal: {detail.Quantity}");
                    }

                    Console.WriteLine("------------------------------------------------");
                }
            }
        }
    }
}

