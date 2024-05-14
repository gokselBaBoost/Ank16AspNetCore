using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Xml.Linq;

namespace Example01.WebApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username)
        {
            HttpContext.Session.SetString("user-name", username);
            HttpContext.Response.Cookies.Append("user-name", username);

            Claim name = new Claim(ClaimTypes.Name, username);

            List<Claim> claims = new List<Claim>();
            claims.Add(name);

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);


            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

            return RedirectToAction("Privacy", "Home");
        }
    }
}
