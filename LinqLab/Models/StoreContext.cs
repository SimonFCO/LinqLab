using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LinqLab.Models
{
    internal class StoreContext : DbContext
    {
        private static IConfiguration _config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();


        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        public StoreContext()
        {

        }
    }
}
