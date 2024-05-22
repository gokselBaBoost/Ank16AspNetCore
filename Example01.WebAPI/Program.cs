using Example01.WebAPI.Library;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World");

app.MapGet("/Student/{id}", (int id) =>
{
    VirtualDb db = new VirtualDb();

    return Results.Ok(db.Get(id));
});

app.MapGet("/Students", () =>
{
    VirtualDb db = new VirtualDb();

    return Results.Ok(db.GetAll());
});

app.Run();
