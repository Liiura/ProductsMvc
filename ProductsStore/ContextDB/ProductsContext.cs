using Microsoft.EntityFrameworkCore;
using ProductsStore.Models;
using System;
namespace ProductsStore.ContextDB
{
    public class ProductsContext : DbContext
    {
        public ProductsContext(DbContextOptions<ProductsContext> options)
    : base(options)
        {
            Database.Migrate();
        }
        public DbSet<Product> Product { get; set; }
        public DbSet<TypeProduct> TypeProduct { get; set; }
        public DbSet<UserClient> UserClient { get; set; }
        public DbSet<RoleType> RoleType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var adminRole = new RoleType
            {
                Id = Guid.NewGuid(),
                Description = "Admin",
                Name = "Admin",
                CreatedDate = DateTime.Now,
            };
            modelBuilder.Entity<TypeProduct>().HasData(
                new TypeProduct
                {
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    TypeName = "Bienes",
                    Description = "Bienes",
                },
                new TypeProduct
                {
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    TypeName = "Vehiculos",
                    Description = "Vehiculos",
                },
                new TypeProduct
                {
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    TypeName = "Terrenos",
                    Description = "Terrenos",
                },
                new TypeProduct
                {
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    TypeName = "Apartamentos",
                    Description = "Apartamentos",
                }
                );
            modelBuilder.Entity<RoleType>().HasData(
                new RoleType
                {
                    Id = Guid.NewGuid(),
                    Description = "Client",
                    Name = "Client",
                    CreatedDate = DateTime.Now,
                },
                adminRole
                );
            modelBuilder.Entity<UserClient>().HasData(
                new UserClient
                {
                    Name = "Admin",
                    LastName = "Admin",
                    UserName = "Admin.dev",
                    Password = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92",
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    RoleTypeId = adminRole.Id
                }
                );
        }
    }
}
