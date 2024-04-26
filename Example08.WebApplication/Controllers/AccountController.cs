using Microsoft.AspNetCore.Mvc;

namespace Example08.WebApplication.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult LoginCookie()
        {
            CookieOptions cookieOptions = new CookieOptions();

            cookieOptions.Expires = DateTime.Now.AddMinutes(3);

            string[] users = ["admin", "user", "moderator"];
            int index = new Random().Next(users.Length);

            HttpContext.Response.Cookies.Append("user", users[index], cookieOptions);

            return RedirectToAction("Index","Home");
        }
    }
}
