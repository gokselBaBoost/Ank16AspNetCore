WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
// Statik dosyalarýn root klasörünün deðiþtirmek istersek aþaðýda ki kod
//builder.Environment.ContentRootPath = "rootFolder";

//Controller ve View yapýsýný projeye dahil ediyoruz.
builder.Services.AddControllersWithViews();

WebApplication app = builder.Build();

//Https Yönlendirmesini ve CSS,JS ve benzeri Statik sayfalarýn çalýþmasýný saðlamak
app.UseHttpsRedirection();
app.UseStaticFiles(); // root folder => wwwroot

//app.UseRouting();
//app.MapControllers();

// Controller seviyesinde otomatik Rotalama iþlemini devreye alýyorum
app.MapDefaultControllerRoute();

//Controller seviyesinde özelleþtirilmiþ Rotalama iþlemi yapmak için
//app.MapControllerRoute(
//    name: "public",
//    pattern: "Public/{controller=Home}/{action=Index}/{Id?}"
//    );

//app.MapControllerRoute(
//    name: "admin",
//    pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}"
//    );

app.Run();
