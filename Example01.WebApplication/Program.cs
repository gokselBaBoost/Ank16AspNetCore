using Example01.WebApplication.Fonksiyonlar;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

WebApplication app = builder.Build();

#region Map Yapısı
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

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseHsts();

app.MapDefaultControllerRoute();// https://localhost:1234/

//app.UseRouting();

//app.MapGet("/", () => "Hello world");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{test?}"
    );

//app.MapControllerRoute(
//    name: "admin",
//    pattern: "admin/{controller=Anasayfa}/{action=Merhaba}/{sayfaNo?}"
//    );

//app.UseEndpoints(endpoints =>
//{
//    app.MapGet("/hakkimizda", () => "Hakkımızda sayfası");
//});

app.Run();
