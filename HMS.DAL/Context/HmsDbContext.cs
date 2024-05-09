using HMS.DAL.Common;
using HMS.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Context
{
    public class HmsDbContext : DbContext
    {
        public HmsDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<AccountUser> AccountUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountUser>().HasData(new AccountUser
            {
                Id = 1,
                Name = "Admin",
                Surname = "Admin",
                Email = "admin@hmsapp.com",
                AccountType = Entities.Common.AccountType.Admin,
                BirthDate = new DateOnly(2000,1,1),
                Created = DateTime.Now,
                Password = Sifreleme.Md5Hash("Abcd*1234")
            });
        }
    }
}
