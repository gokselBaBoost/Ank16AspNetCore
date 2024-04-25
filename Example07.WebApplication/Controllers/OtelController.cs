using Microsoft.AspNetCore.Mvc;

namespace Example07.WebApplication.Controllers
{
    public class OtelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(bool isPartial = false)
        {
            ViewBag.IsPartial = isPartial;
            if (isPartial)
            {
                return PartialView();
            }
            else
            {
                return View();
            }

        }

        [HttpPost]
        public IActionResult Create(IFormCollection form)
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
