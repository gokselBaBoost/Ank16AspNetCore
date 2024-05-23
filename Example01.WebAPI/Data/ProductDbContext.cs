using Example01.WebAPI.Data.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Example01.WebAPI.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; } 
    }
}
