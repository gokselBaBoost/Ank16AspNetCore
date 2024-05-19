using HMS.DAL.Common;
using HMS.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Context
{
    public class HmsDbContext : IdentityDbContext<AppUser>
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
            base.OnModelCreating(modelBuilder);

            string userId = Guid.NewGuid().ToString();
            string roleId = Guid.NewGuid().ToString();

            //User sees Data
            var hasher = new PasswordHasher<AppUser>();

            modelBuilder.Entity<AppUser>().HasData(
                    new AppUser
                    {
                        Id = userId,
                        Name = "Admin",
                        Surname = "Admin",
                        BirthDate = new DateOnly(2000,1,1),
                        Gender = Entities.Common.Gender.Male,
                        UserName = "Admin",
                        NormalizedUserName = "Admin".ToUpper(),
                        Email = "admin@mail.com",
                        NormalizedEmail = "admin@mail.com".ToUpper(),
                        PasswordHash = hasher.HashPassword(null, "12345*Abcde")
                    }
                );

            //Role seed Data
            modelBuilder.Entity<IdentityRole>().HasData(
                    new IdentityRole
                    {
                        Id = roleId,
                        Name = "Admin",
                        NormalizedName = "Admin".ToUpper()
                    }
                );

            //UserRole seed Data

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                    new IdentityUserRole<string>
                    {
                        UserId = userId,
                        RoleId = roleId
                    }
                );

            //modelBuilder.Entity<AccountUser>().HasData(new AccountUser
            //{
            //    Id = 1,
            //    Name = "Admin",
            //    Surname = "Admin",
            //    Email = "admin@hmsapp.com",
            //    AccountType = Entities.Common.AccountType.Admin,
            //    BirthDate = new DateOnly(2000,1,1),
            //    Created = DateTime.Now,
            //    Password = Sifreleme.Md5Hash("Abcd*1234")
            //});
        }
    }
}
