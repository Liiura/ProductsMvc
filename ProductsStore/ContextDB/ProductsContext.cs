using Microsoft.EntityFrameworkCore;
using ProductsStore.Models;

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
    }
}
