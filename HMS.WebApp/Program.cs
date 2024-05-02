using HMS.BLL.Managers;
using HMS.DAL.Context;
using HMS.WebApp.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

Console.WriteLine(builder.Configuration.GetConnectionString("HmsDbConStr"));

// Add services to the container.
builder.Services.AddDbContext<HmsDbContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration.GetConnectionString("HmsDbConStr"));
});

builder.Services.AddSingleton<CountryManager>();

builder.Services.AddScoped<IMailService,HotmailService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
