using Example08.WebApplication.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(opt =>
{
    //opt.Filters.Add<CheckCookieUser>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

#region Use Middleware
//app.Use(async (context, next) =>
//{
//    if (context.Request.Path.Value.Contains(".js") || context.Request.Path.Value.Contains(".css") || context.Request.Path.Value.Contains(".ico"))
//    {
//        await next();
//    }
//    else
//    {
//        if (context.Request.Path != "/Home/ApiKeyNotFound")
//        {
//            //İstek geldiğinde yapacaklarım

//            bool hasAppKey = context.Request.HttpContext.Request.Query.ContainsKey("app-key");

//            if (!hasAppKey)
//            {
//                Console.WriteLine($"app-key : {hasAppKey}");

//                context.Request.HttpContext.Request.QueryString = QueryString.Create("app-key", "123456");

//                context.Response.Redirect("/Home/ApiKeyNotFound");
//            }
//            else
//            {
//                await next();

//                if (context.Response.StatusCode == 200)
//                {
//                    string userInfo = context.Response.HttpContext.Response.Headers["user-info"];

//                    Console.WriteLine($"user-info : {userInfo}");

//                    // Bende sonraki middlewareların işlemlerinin bitiminde çalıştıracağım işlemler
//                }
//            }
//        }
//        else
//        {
//            await next();
//        }
//    }
//}); 
#endregion


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

#region Run Short Circuit (Kısa Devre)
//app.Run(async context =>
//{
//    if (context.Request.Path != "/Home/ApiKeyNotFound")
//    {
//        IQueryCollection querys = context.Request.HttpContext.Request.Query;

//        bool hasAppKey = querys.ContainsKey("app-key");

//        if (hasAppKey)
//        {
//            Console.WriteLine($"app-key : {hasAppKey}");
//            // Format kontrolü olabilir

//            if (querys["app-key"] == "123456")
//            {
//                context.Response.StatusCode = 200;
//                await context.Response.WriteAsync("<b>Api Key not founded!</b>");
//            }
//        }
//    }

//});

#endregion

app.Run();

// Bu kısım çalışmıyor...

app.Use(async (content, next) =>
{
    //İstek geldiğinde yapacaklarım

    await next();

    // Bende sonraki middlewareların işlemlerinin bitiminde çalıştıracağım işlemler
});