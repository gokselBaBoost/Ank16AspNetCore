using Example04.WebAPI.Data;
using Example04.WebAPI.Data.Entities.Concrete;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Example04.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }


        // GET /Products => Tüm ürünleri göstermek için
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Products.ToList());
        }

        // GET /Products/{id} => Bir tane ürün getirmek için
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_context.Products.Find(id));
        }

        // POSt /Products => Yeni Ürün Ekler
        [HttpPost]
        public IActionResult Post(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return Created($"/Products/{product.Id}", product);
        }


        // PUT /Products/{id} => Id li ürünü günceller
        // PATCH /Products/{id}/Price => Id li ürünü Sadec 
        [HttpPut("{id}")]
        public IActionResult Put(int id, Product product)
        {
            //Product? _product = _context.Products.Find(id);

            //if (_product == null)
            //    return NotFound($"ID: {id} olan bir ürün bulunamamıştır.");

            //_product.Name = product.Name;
            //_product.Description = product.Description;
            //_product.Stock = product.Stock;
            //_product.Price = product.Price;
            //_product.Updated = DateTime.Now;

            _context.Products.Update(product); // UPDATE Products SET Name="Name", ... where Id = id

            _context.SaveChanges();

            return Created($"/Products/{product.Id}", product);
        }

        // DELETE /Products/{id} => Id li ürünü siler
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Product? _product = _context.Products.Find(id);

            if (_product == null)
                return NotFound($"ID: {id} olan bir ürün bulunamamıştır.");

            _context.Remove(_product);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
