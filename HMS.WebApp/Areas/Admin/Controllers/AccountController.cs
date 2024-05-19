using HMS.DTO;
using HMS.WebApp.Areas.Admin.Models.Account;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using FluentValidation;
using FluentValidation.Results;
using FluentValidation.AspNetCore;
using HMS.Entities;
using Microsoft.AspNetCore.Identity;
using HMS.WebApp.Services;

namespace HMS.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private IValidator<LoginViewModel> _validator;
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        private IMailService _mailService;

        public AccountController(IValidator<LoginViewModel> validator, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMailService mailService)
        {
            _validator = validator;
            _userManager = userManager;
            _signInManager = signInManager;
            _mailService = mailService;
        }
        public IActionResult Login()
        {
            LoginViewModel model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            ValidationResult validationResult = await _validator.ValidateAsync(model);

            if (!validationResult.IsValid)
            {
                ModelState.Clear();
                validationResult.AddToModelState(ModelState);
                return View(model);
            }

            AppUser? user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                ModelState.AddModelError("UserNotFound", "Kullanıcı adı veya şifre yanlış");
                return View(model);
            }

            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, true);

            if (result.Succeeded)
                return RedirectToAction("Index", "Home", new { area = "Admin" });

            if (result.IsLockedOut)
            {
                //return RedirectToAction("LockOut", "Account", new { area = "Admin" });
                ModelState.AddModelError("UserNotFound", "Hesabınız kitlenmiştir.");
                return View(model);
            }

            if (result.RequiresTwoFactor)
            {
                return RedirectToAction("LoginWith2fa", "Account", new { area = "Admin" });
            }

            if (result.IsNotAllowed)
            {
                //return RedirectToAction("IsNotAllowed", "Account", new { area = "Admin" });
                string? link = Url.ActionLink("SendValidateMail", "Account", new { area = "Admin" });

                ModelState.AddModelError("UserNotFound", $"Hesabınız henüz doğrulanmamış lütfen mail adresinizi doğrulayın.<a href=\"{link}\">Tekrar Gönder</a>");
                return View(model);
            }

            ModelState.AddModelError("UserNotFound", "Kullanıcı adı veya şifre yanlış");
            return View(model);
        }
    
        public IActionResult LockOut()
        {
            return View();
        }

        public IActionResult LoginWith2fa()
        {
            return View();
        }

        public IActionResult IsNotAllowed()
        {
            return View();
        }
    }
}
