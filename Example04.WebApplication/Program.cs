WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
// Statik dosyalar�n root klas�r�n�n de�i�tirmek istersek a�a��da ki kod
//builder.Environment.ContentRootPath = "rootFolder";

//Controller ve View yap�s�n� projeye dahil ediyoruz.
builder.Services.AddControllersWithViews();

WebApplication app = builder.Build();

//Https Y�nlendirmesini ve CSS,JS ve benzeri Statik sayfalar�n �al��mas�n� sa�lamak
app.UseHttpsRedirection();
app.UseStaticFiles(); // root folder => wwwroot

//app.UseRouting();
//app.MapControllers();

// Controller seviyesinde otomatik Rotalama i�lemini devreye al�yorum
app.MapDefaultControllerRoute();

//Controller seviyesinde �zelle�tirilmi� Rotalama i�lemi yapmak i�in
//app.MapControllerRoute(
//    name: "public",
//    pattern: "Public/{controller=Home}/{action=Index}/{Id?}"
//    );

//app.MapControllerRoute(
//    name: "admin",
//    pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}"
//    );

app.Run();
