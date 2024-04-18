using Microsoft.AspNetCore.Mvc;

namespace Practice01.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
