using eShop.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace eShop.ProductAPI.Contect
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
