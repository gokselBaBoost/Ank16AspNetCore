using Example08.WebApplication.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Example08.WebApplication.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
