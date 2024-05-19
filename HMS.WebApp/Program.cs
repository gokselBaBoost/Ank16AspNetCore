using FluentValidation;
using HMS.BLL.Managers.Concrete;
using HMS.DAL.Context;
using HMS.DAL.Repositories.Concrete;
using HMS.DAL.Services.Concrete;
using HMS.DAL.Services.Profiles;
using HMS.Entities;
using HMS.WebApp.Areas.Admin.Filters;
using HMS.WebApp.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

Console.WriteLine(builder.Configuration.GetConnectionString("HmsDbConStr"));

//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//                .AddCookie(opt =>
//                {
//                    opt.Cookie.Name = "HmsApp.Session";
//                    opt.Cookie.MaxAge = TimeSpan.FromSeconds(10);
//                    opt.LoginPath = "/Admin/Account/Login";     // Account/Login
//                    opt.LogoutPath = "/Admin/Account/Logout";   // Account/Logout
//                    opt.ExpireTimeSpan = TimeSpan.FromSeconds(20);
//                    opt.SlidingExpiration = true;
//                });

//builder.Services.AddSession(opt =>
//{
//    opt.Cookie.Name = "HmsApp.Session";
//    opt.IdleTimeout = TimeSpan.FromSeconds(30);
//    opt.Cookie.IsEssential = true;
//});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie();

// Add services to the container.
builder.Services.AddDbContext<HmsDbContext>(opts =>
{
    opts.UseLazyLoadingProxies(false).UseSqlServer(builder.Configuration.GetConnectionString("HmsDbConStr"));
}, ServiceLifetime.Scoped);

builder.Services.AddAutoMapper(typeof(Assembly));

//builder.Services.AddResponseCaching();

builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
{
    opt.SignIn.RequireConfirmedEmail = true;

    opt.User.RequireUniqueEmail = true;
    
    opt.Password.RequireDigit = true;
    opt.Password.RequireLowercase = true;
    opt.Password.RequireUppercase = true;
    opt.Password.RequireNonAlphanumeric = true;
    opt.Password.RequiredUniqueChars = 1;
    opt.Password.RequiredLength = 10;

})
.AddDefaultTokenProviders()
.AddEntityFrameworkStores<HmsDbContext>();

builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

builder.Services.ConfigureApplicationCookie(opt =>
{
    opt.Cookie.Name = "HmsApp.Session";
    opt.Cookie.MaxAge = TimeSpan.FromSeconds(10);
    opt.LoginPath = "/Admin/Account/Login";     // Account/Login
    opt.LogoutPath = "/Admin/Account/Logout";   // Account/Logout
    opt.ExpireTimeSpan = TimeSpan.FromSeconds(20);
    opt.SlidingExpiration = true;
});

builder.Services.AddSession(opt =>
{
    opt.Cookie.Name = "HmsApp.Session";
    opt.IdleTimeout = TimeSpan.FromSeconds(30);
    opt.Cookie.IsEssential = true;
});

// Country Implimentation
builder.Services.AddScoped<CountryRepo>();
builder.Services.AddScoped<CountryService>();
builder.Services.AddScoped<CountryManager>();

// City Implimentation
builder.Services.AddScoped<CityRepo>();
builder.Services.AddScoped<CityService>();
builder.Services.AddScoped<CityManager>();

// Menu Implimentation
builder.Services.AddScoped<MenuRepo>();
builder.Services.AddScoped<MenuService>();
builder.Services.AddScoped<MenuManager>();

// AccountUser Implimentation
builder.Services.AddScoped<AccountUserRepo>();
builder.Services.AddScoped<AccountUserService>();
builder.Services.AddScoped<AccountUserManager>();


builder.Services.AddScoped<IMailService, GmailService>();    // Her zaman her istek tek örnek
//builder.Services.AddScoped<IMailService, GmailService>();     // İstek başına tek örnek
//builder.Services.AddTransient<IMailService, GmailService>();  // İstek başına ve istenmesi ayrı örnek

builder.Services.AddControllersWithViews(opt =>
{
    var x = opt.Filters;

    opt.Filters.Add<UserInfoActionFilter>();
});

var app = builder.Build();

app.UseDeveloperExceptionPage();

// Configure the HTTP request pipeline.
if (app.Environment.EnvironmentName == "Home")
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.Use(async (context, next) =>
{
    // İlk yapılacaklar
    Console.WriteLine($"En ilk ben çalıştım. Time : {DateTime.Now}");


    await next.Invoke();

    // son yapılacaklar

    Console.WriteLine($"En son ben çalıştım. Time : {DateTime.Now}");

    if(context.Response.StatusCode == StatusCodes.Status404NotFound)
    {
        context.Response.WriteAsync("Aradığınız sayfa bulunamadı. 404 Page Not Found");
    }

});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.UseResponseCaching();

//app.Use(async (context, next) =>
//{
//    context.Response.GetTypedHeaders().CacheControl =
//        new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
//        {
//            Public = true,
//            MaxAge = TimeSpan.FromSeconds(10)
//        };
//    context.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.Vary] =
//        new string[] { "Accept-Encoding" };

//    await next();
//});

app.MapControllerRoute(
    name: "anasayfa",
    pattern: "anasayfa", 
    defaults: new { Controller = "Home", Action = "Index" }
);

app.MapControllerRoute(
    name: "ulke",
    pattern: "admin/ulkeler",
    defaults: new { Controller = "Country", Action = "Index" }
);

app.MapControllerRoute(
    name: "ulke",
    pattern: "admin/ulkeler/yeni-ulke",
    defaults: new { Controller = "Country", Action = "Add" }
);

app.MapControllerRoute(
    name: "ulke",
    pattern: "admin/ulkeler/{id}/detay",
    defaults: new { Controller = "Country", Action = "Detail", Id = "{id}" }
);

app.MapControllerRoute(
    name: "sehir",
    pattern: "admin/sehirler",
    defaults: new { Controller = "City", Action = "Index" }
);

app.MapControllerRoute(
    name: "sehir",
    pattern: "admin/sehirler/yeni-sehir",
    defaults: new { Controller = "City", Action = "Add" }
);

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.MapDefaultControllerRoute();

app.Run();
