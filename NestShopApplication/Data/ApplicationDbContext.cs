using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NestShopApplication.Models;

namespace NestShopApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Banner> Banners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Clothing", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Shoes", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Watches", DisplayOrder = 3 }
                );
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "ORTOREX Men Orthopedic Diabetic Walking Sneakers Edema Shoes for Swollen Feet",
                    Description = "Wide-opening Strap Design: Our diabetic shoes feature an easy-to-use, adjustable strap design that allows for a custom fit.",
                    Price = 44.99,
                    CategoryId = 1,
                    ImageUrl = "",
                },
                new Product
                {
                    Id = 2,
                    Name = "Men's Fashion Leather Sneakers - Orthopedic Casual Dress Shoes",
                    Description = "Balanced Arch & Heel Support：Dual-density PU insoles deliver stable, fatigue-free support for long hours of walking or standing. The contoured design offers moderate arch support and a secure heel fit for everyday comfort",
                    Price = 64.5,
                    CategoryId = 2,
                    ImageUrl = "",

                },
                new Product
                {
                    Id = 3,
                    Name = "New Balance Men's 608 V5 Casual Comfort Cross Trainer",
                    Description = "NDurance rubber outsole technology provides superior durability in high-wear areas to help get more out of the shoes",
                    Price = 54.99,
                    CategoryId = 3,
                    ImageUrl = "",

                }

                );

            modelBuilder.Entity<IdentityRole>().HasData(
               new IdentityRole { Name ="admin", NormalizedName = "admin" },
               new IdentityRole { Name ="client", NormalizedName ="client" },
               new IdentityRole {Name = "seller", NormalizedName="seller" }
               );

        }
    }
}
