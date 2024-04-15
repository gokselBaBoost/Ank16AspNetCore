using Microsoft.AspNetCore.Mvc;

namespace Example01.WebApplication.Controllers
{
    public class AnasayfaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Merhaba()
        {
            return View();
        }
    }
}
