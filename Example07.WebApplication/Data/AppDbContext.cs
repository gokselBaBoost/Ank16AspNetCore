using Example07.WebApplication.Data.Entites;
using Microsoft.EntityFrameworkCore;

namespace Example07.WebApplication.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {}

        public DbSet<Country> Countries { get; set; }
        public DbSet<Example07.WebApplication.Data.Entites.Hotel> Hotel { get; set; } = default!;

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);

        //    optionsBuilder.UseSqlServer("aaa");
        //}
    }
}
