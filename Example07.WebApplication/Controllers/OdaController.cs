using Microsoft.AspNetCore.Mvc;

namespace Example07.WebApplication.Controllers
{
    public class OdaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(IFormCollection form)
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
