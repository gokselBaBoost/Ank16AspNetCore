using Microsoft.AspNetCore.Mvc;

namespace HMS.WebApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}
