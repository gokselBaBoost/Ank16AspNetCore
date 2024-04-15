using Example01.WebApplication.Fonksiyonlar;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

WebApplication app = builder.Build();

#region Map Yapýsý
//app.MapGet("/", () => "Hello World!");

//app.MapGet("/anasayfa", async (httpContext) =>
//{
//    Anasayfa anasayfa = new Anasayfa(httpContext);
//    anasayfa.HomePage();
//});

//app.MapGet("/anasayfa/hakkimizda", async (httpContext) =>
//{
//    Anasayfa anasayfa = new Anasayfa(httpContext);
//    anasayfa.AboutPage();
//});

//app.MapGet("/anasayfa/iletisim", async (httpContext) =>
//{
//    Anasayfa anasayfa = new Anasayfa(httpContext);
//    anasayfa.ContactPage();
//}); 
#endregion

app.MapDefaultControllerRoute();// https://localhost:1234/

//app.MapControllerRoute(
//    name: "default", 
//    pattern: "api/{action=Merhaba}/{controller=Anasayfa}/{sayfaNo?}"
//    );

//app.MapControllerRoute(
//    name: "admin",
//    pattern: "admin/{controller=Anasayfa}/{action=Merhaba}/{sayfaNo?}"
//    );

app.Run();
