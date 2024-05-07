using HMS.BLL.Managers.Concrete;
using HMS.DAL.Context;
using HMS.DAL.Repositories.Concrete;
using HMS.DAL.Services.Concrete;
using HMS.DAL.Services.Profiles;
using HMS.WebApp.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

Console.WriteLine(builder.Configuration.GetConnectionString("HmsDbConStr"));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(opt =>
                {
                    opt.LoginPath = "/Admin/Account/Login";     // Account/Login
                    opt.LogoutPath = "/Admin/Account/Logout";   // Account/Logout
                });

// Add services to the container.
builder.Services.AddDbContext<HmsDbContext>(opts =>
{
    opts.UseLazyLoadingProxies(false).UseSqlServer(builder.Configuration.GetConnectionString("HmsDbConStr"));
});

builder.Services.AddAutoMapper(typeof(Assembly));

// Country Implimentation
builder.Services.AddSingleton<CountryRepo>();
builder.Services.AddSingleton<CountryService>();
builder.Services.AddSingleton<CountryManager>();

// City Implimentation
builder.Services.AddSingleton<CityRepo>();
builder.Services.AddSingleton<CityService>();
builder.Services.AddSingleton<CityManager>();


builder.Services.AddSingleton<IMailService, GmailService>();    // Her zaman her istek tek örnek
//builder.Services.AddScoped<IMailService, GmailService>();     // İstek başına tek örnek
//builder.Services.AddTransient<IMailService, GmailService>();  // İstek başına ve istenmesi ayrı örnek

builder.Services.AddControllersWithViews();

var app = builder.Build();

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

app.UseAuthentication();
app.UseAuthorization();

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
