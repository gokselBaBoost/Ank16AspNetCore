var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseDeveloperExceptionPage();

app.MapDefaultControllerRoute();
//app.MapControllerRoute(
//    name:"default",
//    pattern:"{action=Index}/{controller=Home}/{id?}"
//    );

app.Run();
