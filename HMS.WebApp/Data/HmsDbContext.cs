using HMS.WebApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HMS.WebApp.Data
{
    public class HmsDbContext : DbContext
    {
        public HmsDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {}

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
    }
}
