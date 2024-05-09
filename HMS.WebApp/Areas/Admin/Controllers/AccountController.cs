using AutoMapper;
using HMS.BLL.Managers.Concrete;
using HMS.DTO;
using HMS.WebApp.Areas.Admin.Models.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace HMS.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private AccountUserManager _accountUserManager;
        private IMapper _mapper;

        public AccountController(AccountUserManager accountUserManager)
        {
            _accountUserManager = accountUserManager;

            MapperConfiguration config = new MapperConfiguration(config =>
            {
                config.CreateMap<RegisterViewModel, AccountUserDto>().ReverseMap();
            });

            _mapper = config.CreateMapper();
        }

        public IActionResult Login()
        {
            //string deneme = Sifreleme.Md5Hash("abc123");

            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //email ve password check edilecek
            //db ye gidilip sorulacaktır.

            AccountUserDto? userDto = _accountUserManager.FindLoginUser(model.Email, Sifreleme.Md5Hash(model.Password));

            if(userDto is not null)
            {
                Claim name = new Claim(ClaimTypes.Name, userDto.Name);
                Claim surname = new Claim(ClaimTypes.Surname, userDto.Surname);
                Claim id = new Claim(ClaimTypes.NameIdentifier, userDto.Id.ToString());
                Claim emailAddres = new Claim(ClaimTypes.Email, userDto.Email);

                List<Claim> claims = new List<Claim>();
                claims.Add(name);
                claims.Add(surname);
                claims.Add(id);
                claims.Add(emailAddres);


                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                //claimsIdentity.AddClaims(claims);     


                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                return RedirectToAction("Index", "Home", new { area = "Admin" });
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
            RegisterViewModel model = new RegisterViewModel();

            return View(model);
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            AccountUserDto userDto = _mapper.Map<AccountUserDto>(model);
            userDto.AccountType = AccountType.OperationUser;
            userDto.Password = Sifreleme.Md5Hash(userDto.Password);

            if(_accountUserManager.Add(userDto) > 0) 
                return RedirectToAction(nameof(Login));


            ViewBag.FailLogin = "Veri tabanına kayıt esnasında bir sorun oldu.";
            return View(model);
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }
    }

    internal static class Sifreleme
    {
        public static string Md5Hash(string text)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            // asd123 => 

            byte[] dizi = Encoding.UTF8.GetBytes(text);

            dizi = md5.ComputeHash(dizi);

            //string passHash = "";
            StringBuilder sb = new StringBuilder();

            foreach(byte b in dizi)
            {
                //passHash += b.ToString("X2").ToLower();

                sb.Append(b.ToString("X2").ToLower());
            }

            //return passHash;

            return sb.ToString();
        }
    }
}
