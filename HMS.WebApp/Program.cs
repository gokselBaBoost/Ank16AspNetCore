﻿using HMS.BLL.Managers.Concrete;
using HMS.DAL.Context;
using HMS.DAL.Repositories.Concrete;
using HMS.DAL.Services.Concrete;
using HMS.DAL.Services.Profiles;
using HMS.WebApp.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

Console.WriteLine(builder.Configuration.GetConnectionString("HmsDbConStr"));

// Add services to the container.
builder.Services.AddDbContext<HmsDbContext>(opts =>
{
    opts.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("HmsDbConStr"));
});


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
