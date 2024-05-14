using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(); 

builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.Use(async(context, next) =>
{
    var subCatId =  context.Request.Cookies["subCatId"];

    if (subCatId != null)
        context.Items["subCatId"] = subCatId;

    //Stream originalBody = context.Response.Body;
    //context.Response.OnStarting(OnStartingCallBack);

    context.Response.OnStarting(() => {

        if (context.Items["CategoryName"] != null)
        {
            context.Response.Cookies.Append("catName", context.Items["CategoryName"].ToString());
            //context.Response.Body = originalBody;
        }

        return Task.FromResult(0);
    });

    await next.Invoke();

    //if (context.Items["CategoryName"] != null)
    //{
    //    context.Response.Cookies.Append("catName", context.Items["CategoryName"].ToString());
    //    //context.Response.Body = originalBody;
    //}

    //Task OnStartingCallBack()
    //{
    //    if (context.Items["CategoryName"] != null)
    //    {
    //        context.Response.Cookies.Append("catName", context.Items["CategoryName"].ToString());
    //        context.Response.Body = originalBody;
    //    }
    //    return Task.FromResult(0);
    //}

});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
