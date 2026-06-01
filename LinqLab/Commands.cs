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
            DateTime oneMonthAgo = DateTime.Now.AddMonths(-1); // tog mig för lång tid att göra labben så en månad sedan är för lite och ger inga result :(

            var TotalOrderPrice = _ctx.Orders
                .Where(o => o.OrderDate >=  oneMonthAgo)
                .Sum(o => o.TotalAmount);

            Console.WriteLine("Total Order Price for the last month");
            Console.WriteLine(TotalOrderPrice);
                
        }

        public void GetTop3BestSellingProducts()
        {
            var Best3Sellers = _ctx.Products
                .Select(p => new
                {
                    p.Name,
                    TotalAmmountSold = p.OrderDetails.Sum(od => od.Quantity)
                })
                .OrderByDescending(p => p.TotalAmmountSold)
                .Take(3)
                .ToList();

            foreach (var product in Best3Sellers)
            {
                Console.WriteLine($"Namn: {product.Name}, Antal Sålda: {product.TotalAmmountSold}");
            }
        }

        public void GetCategoriesWithProductCount()
        {
            var Catagories = _ctx.Categories
                .Select(c => new
                {
                    c.Name,
                    ProductAmmount = c.Products.Count()
                })
                .ToList();

            foreach ( var catagory in Catagories )
            {
                Console.WriteLine($"Catagory: {catagory.Name} | Product Ammount: {catagory.ProductAmmount}");
            }
          }

        public void GetHighValueOrdersWithDetails()
        {
            var RichOrders = _ctx.Orders
                .Where(o => o.TotalAmount > 1000)
                .Select(o => new
                {
                    name = o.Customer.Name,
                    mail = o.Customer.Email,
                    Total = o.TotalAmount,
                    OrderDetails = o.OrderDetails.Select(od => new
                    {
                        od.Product.Name,
                        od.Quantity,
                        od.UnitPrice
                    })
                });

            foreach(var order in RichOrders)
            {
                Console.WriteLine($"Customer: {order.name} | Mail: {order.mail} | Total Sum: {order.Total}");
                foreach(var orderDetail in order.OrderDetails)
                {
                    Console.WriteLine($"--- Product Name: {orderDetail.Name} | Price: {orderDetail.UnitPrice} | Ammount: {orderDetail.Quantity}");
                }
                Console.WriteLine(" ");
            }
        }
    }
}
