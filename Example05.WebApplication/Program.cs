var builder = WebApplication.CreateBuilder(args);

//Controllers ve Views Yapısını Service eklentisini dahil ediyoruz.
builder.Services.AddControllersWithViews();

var app = builder.Build();

//Https otomatik yönlendirmesi 
app.UseHttpsRedirection();

//CSS, JS vb statik sayfalar çağrıla bilsindiye
app.UseStaticFiles();

app.MapDefaultControllerRoute();

//app.MapControllerRoute(name: "yeniRota", pattern: "{action=Index}/{controller=Home}/{id?}");

// News/Breaking/5?cat=Sport&subCat=Bundesliga

// News/Breaking/Sport/Budesliga/5 => /Controller/Action/CatName/SubCatNem/id?

app.Run();
