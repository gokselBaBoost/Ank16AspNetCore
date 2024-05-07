using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HMS.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password) {

            //email ve password check edilecek
            //db ye gidilip sorulacaktır.

            if(email == "goksel@mail.com" &&  password == "123456")
            {
                Claim name = new Claim(ClaimTypes.Name, "Göksel");
                Claim surname = new Claim(ClaimTypes.Surname, "Kalyoncu");
                Claim id = new Claim(ClaimTypes.NameIdentifier, "123");
                Claim emailAddres = new Claim(ClaimTypes.Email, email);

                List<Claim> claims = new List<Claim>();
                claims.Add(name);
                claims.Add(surname);
                claims.Add(id);
                claims.Add(emailAddres);


                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                //claimsIdentity.AddClaims(claims);     


                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                return RedirectToAction("Index", "Country", new { area = "Admin"});
            }

            ViewBag.FailLogin = "Girişmiş olduğunuz bilgiler yanlıştır.";

            return View();
            //doğru ise login yap ve İstenilen sayfaya yönlendir.

            //yanlış ise login sayfasına gerekli uyarı ile yönlendir.


        }

        public IActionResult Logout()
        {
            //Logout işlemi yapılacak

            HttpContext.SignOutAsync();

            return RedirectToAction(nameof(Login));
        }

        public IActionResult Register()
        {
            return View();
        }
    }
}
