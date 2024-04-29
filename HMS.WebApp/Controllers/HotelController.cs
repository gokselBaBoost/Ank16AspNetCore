using Microsoft.AspNetCore.Mvc;

namespace HMS.WebApp.Controllers
{
    public class HotelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
