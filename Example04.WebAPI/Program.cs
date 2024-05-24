using Example04.WebAPI.Controllers;
using Example04.WebAPI.Data;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("AppDbConStr"));
});

builder.Services.AddEndpointsApiExplorer(); // Api endpointlerini Browserdan Swagger ile kullanmak için gerekli servis

builder.Services.AddSwaggerGen(); // Swagger Servisi OpenAPI kullanımı için

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.UseSwagger();
app.UseSwaggerUI();

//app.UseHttpsRedirection();
//app.UseAuthorization();

app.MapControllers();

app.MapTeacherEndpoints();

app.Run();