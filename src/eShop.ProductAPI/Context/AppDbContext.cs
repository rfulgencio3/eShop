using eShop.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace eShop.ProductAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        //Fluent API
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //category
            builder.Entity<Category>().HasKey(c => c.CategoryId);
            
            builder.Entity<Category>()
                .Property(c => c.Name)
                .HasMaxLength(100)
                .IsRequired();

            //product
            builder.Entity<Product>().HasKey(c => c.ProductId);
            
            builder.Entity<Product>()
                .Property(c => c.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Entity<Product>()
                .Property(c => c.Description)
                .HasMaxLength(255)
                .IsRequired();

            builder.Entity<Product>()
                .Property(c => c.ImageUrl)
                .HasMaxLength(255)
                .IsRequired();

            builder.Entity<Product>()
                .Property(c => c.Price)
                .HasPrecision(12, 2);

            //relations
            builder.Entity<Category>()
                .HasMany(p => p.Products)
                .WithOne(c => c.Category)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    Name = "Material Escolar",
                },
                new Category
                {
                    CategoryId = 2,
                    Name = "Acessórios"
                });
        }

    }
}
