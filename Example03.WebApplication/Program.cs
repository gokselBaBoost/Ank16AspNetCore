var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddControllersWithViews();

var app = builder.Build();

//app.UseDeveloperExceptionPage();

//app.MapDefaultControllerRoute();
//app.MapControllerRoute(
//    name:"default",
//    pattern:"{action=Index}/{controller=Home}/{id?}"
//    );

//app.MapGet("/", async (httpContext) =>
//{
//    //return "Ana sayfa <b>Test</b>";
//    httpContext.Response.ContentType = "text/html";
//    await httpContext.Response.WriteAsync("Ana sayfa <b>Test</b>");
//});

app.Run();
