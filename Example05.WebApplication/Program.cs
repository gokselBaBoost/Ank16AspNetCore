var builder = WebApplication.CreateBuilder(args);

//Controllers ve Views Yapısını Service eklentisini dahil ediyoruz.
builder.Services.AddControllersWithViews();

var app = builder.Build();

//Https otomatik yönlendirmesi 
app.UseHttpsRedirection();

//CSS, JS vb statik sayfalar çağrıla bilsindiye
app.UseStaticFiles();

app.MapDefaultControllerRoute();

app.Run();
