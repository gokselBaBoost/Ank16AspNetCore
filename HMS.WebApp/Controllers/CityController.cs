using Microsoft.AspNetCore.Mvc;

namespace HMS.WebApp.Controllers
{
    public class CityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
