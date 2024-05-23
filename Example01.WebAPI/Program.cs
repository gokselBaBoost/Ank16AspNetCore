using Example01.WebAPI.Data;
using Example01.WebAPI.Data.Entities.Concrete;
using Example01.WebAPI.Library;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProductDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("ProductDbConStr"));
});

var app = builder.Build();

VirtualDb db = new VirtualDb();

app.MapGet("/", () => "Hello World");


#region Student Endpoints
#region Get
app.MapGet("/Students", () =>
{

    return Results.Ok(db.GetAll());
});

app.MapGet("/Students/{id}", (int id) =>
{
    return Results.Ok(db.Get(id));
});
#endregion

#region Post
app.MapPost("/Students", (Student student) =>
{
    int id = db.Add(student);

    return Results.Created($"/Students/{id}", student);
});
#endregion

#region Put
app.MapPut("/Students/{id}", (int id, Student student) =>
{
    db.Update(id, student);

    return Results.Created($"/Students/{id}", student);
});
#endregion

#endregion


#region Product EndPoints

//GET
app.MapGet("/Products", (ProductDbContext _context) => {
    return Results.Ok(_context.Products.ToList());
});

app.MapGet("/Products/{id}", (int id, ProductDbContext _context) => {
    return Results.Ok(_context.Products.Find(id));
});

app.MapPost("/Products", (Product product, ProductDbContext _context) =>
{
    _context.Products.Add(product);
    _context.SaveChanges();

    return Results.Created($"/Products/{product.Id}", product);
});

app.MapPut("/Products/{id}", (int id, Product updateProduct, ProductDbContext _context) =>
{
    Product product = _context.Products.Find(id);

    if(product is null) return Results.NotFound();

    //_context.Update(updateProduct);

    product.Name = updateProduct.Name;
    product.Description = updateProduct.Description;
    product.UnitPrice = updateProduct.UnitPrice;
    product.Stock = updateProduct.Stock;
    product.CategoryId = updateProduct.CategoryId;
    product.Updated = DateTime.Now;

    _context.SaveChanges();

    return Results.NoContent();
});

app.MapDelete("/Products/{id}", (int id, ProductDbContext _context) =>
{

    Product? product = _context.Products.Find(id);

    if (product is null) return Results.NotFound();

    _context.Products.Remove(product);
    _context.SaveChanges();

    return Results.NoContent();
});

#endregion

#region Category EndPoints

//GET
app.MapGet("/Categories", (ProductDbContext _context) => {
    return Results.Ok(_context.Categories.ToList());
});

app.MapGet("/Categories/{id}", (int id, ProductDbContext _context) => {
    return Results.Ok(_context.Categories.Find(id));
});

app.MapPost("/Categories", (Category category, ProductDbContext _context) =>
{
    _context.Categories.Add(category);
    _context.SaveChanges();

    return Results.Created($"/Categories/{category.Id}", category);
});

app.MapPut("/Categories/{id}", (int id, Category updateCategory, ProductDbContext _context) =>
{
    Category category = _context.Categories.Find(id);

    if (category is null) return Results.NotFound();

    //_context.Update(updateProduct);

    category.Name = updateCategory.Name;
    category.Description = updateCategory.Description;

    _context.SaveChanges();

    return Results.NoContent();
});

app.MapDelete("/Categories/{id}", (int id, ProductDbContext _context) =>
{

    Category? category = _context.Categories.Find(id);

    if (category is null) return Results.NotFound();

    _context.Categories.Remove(category);
    _context.SaveChanges();

    return Results.NoContent();
});

#endregion



app.Run();
