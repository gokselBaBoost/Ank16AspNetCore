using Example04.WebAPI.Data.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Example04.WebAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {}

        public DbSet<Product> Products { get; set; }
    }
}
