using Example02.IdentityWebApp.Data.Entities;
using Example02.IdentityWebApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Example02.IdentityWebApp.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            LoginViewModel model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {

            if(!ModelState.IsValid) {
                return View(model);
            }

            AppUser? user = _userManager.FindByEmailAsync(model.Email).Result;

            if (user == null)
            {
                ViewBag.ErrorMessage = "Kullanıcı adı veya şifre yanlışır.";
                return View(model);
            }

            Microsoft.AspNetCore.Identity.SignInResult signInResult = _signInManager.PasswordSignInAsync(user, model.Password, false, false).Result;

            if(!signInResult.Succeeded)
            {
                bool emailConfirm = _userManager.IsEmailConfirmedAsync(user).Result;

                if (!emailConfirm)
                {
                    ViewBag.ErrorMessage = "Mail doğrulanmamıştır.";
                    return View(model);
                }

                ViewBag.ErrorMessage = "Kullanıcı adı veya şifre yanlışır.";
                return View(model);
            }


            return RedirectToAction("Privacy", "Home");
        }
    
        public IActionResult AccessDenied()
        {
            var user = HttpContext.User;

            return View();
        }
    }
}
