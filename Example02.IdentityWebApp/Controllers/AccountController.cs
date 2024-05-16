using Example02.IdentityWebApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Example02.IdentityWebApp.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
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

            IdentityUser? user = _userManager.FindByEmailAsync(model.Email).Result;

            if(user == null)
            {
                ViewBag.ErrorMessage = "Kullanıcı adı veya şifre yanlışır.";
                return View(model);
            }

            bool emailConfirm = _userManager.IsEmailConfirmedAsync(user).Result;

            if(!emailConfirm)
            {
                ViewBag.ErrorMessage = "Mail doğrulanmamıştır.";
                return View(model);
            }

            Microsoft.AspNetCore.Identity.SignInResult signInResult = _signInManager.PasswordSignInAsync(user, model.Password, false, false).Result;

            if(!signInResult.Succeeded)
            {
                ViewBag.ErrorMessage = "Kullanıcı adı veya şifre yanlışır.";
                return View(model);
            }


            return RedirectToAction("Privacy", "Home");
        }
    }
}
