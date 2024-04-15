WebApplicationBuilder builder = WebApplication.CreateBuilder();

//Burası ilgili web server için gerekli duyulan eklentilerin
//yazılacağı yer

WebApplication app = builder.Build();

app.MapGet("/", async (httpContext) =>
{
    //Console.WriteLine("Hello Web Application");
    await httpContext.Response.WriteAsync("<b>Hello Web Application</b>");
});

//app.MapGet("/", () => "<b>Hello World</b>");

app.Run();