using Example02.IdentityWebApp.Data;
using Example02.IdentityWebApp.Data.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Authentication Service Implementation
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie();

// DbContext Service Implementation
builder.Services.AddDbContext<AppDbContext>( opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("AppDbConStr"));
});

// Identity Service Implementation
builder.Services.AddIdentity<AppUser,IdentityRole>(opt =>
{
    opt.SignIn.RequireConfirmedEmail = true;

    opt.Password.RequiredLength = 10;
    //opt.Password.RequiredUniqueChars = 0;
    //opt.Password.RequireNonAlphanumeric = false;
    //opt.Password.RequireLowercase = false;
    //opt.Password.RequireUppercase = false;

    opt.User.RequireUniqueEmail = true;

}).AddDefaultTokenProviders()
  .AddEntityFrameworkStores<AppDbContext>();



builder.Services.ConfigureApplicationCookie(opt =>
{
    //opt.LoginPath = "/User/Login";
    //opt.LogoutPath = "/User/Logout";
    //opt.AccessDeniedPath = "/Home/AccessDenied";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//app.UseSession();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
