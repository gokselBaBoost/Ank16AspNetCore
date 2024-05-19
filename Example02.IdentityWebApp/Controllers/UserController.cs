using Example02.IdentityWebApp.Data;
using Example02.IdentityWebApp.Data.Entities;
using Example02.IdentityWebApp.Helpers;
using Example02.IdentityWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Configuration;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Example02.IdentityWebApp.Controllers
{
    public class UserController : Controller
    {
        private AppDbContext _dbContext;
        private ControllerContext _controllerContext;
        private ICompositeViewEngine _viewEngine;
        private readonly IConfiguration _configuration;
        private readonly string _username;
        private readonly string _password;
        private UserManager<AppUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public UserController(AppDbContext dbContext, UserManager<AppUser> userManager, ICompositeViewEngine viewEngine, IConfiguration configuration, RoleManager<IdentityRole> roleManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _viewEngine = viewEngine;
            _configuration = configuration;

            _username = _configuration.GetSection("Mail:UserName").Value;
            _password = Encoding.UTF8.GetString(Convert.FromBase64String(_configuration.GetSection("Mail:Password").Value));
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {

            //MailGonder("goksel.kalyoncu@bilgeadam.com", "Kazım Göksel KALYONCU", null);

            //MailViewModel model = new MailViewModel { Title = "Yeni Üyex", Body = "xSisteme kaydınız başarıyla tamamlanmıştır.", Link = Url.ActionLink("Validate", "User", new { token = "xyz12345" }) };
            ////ViewData.Model = model;

            //return View("_NewUserMail", model);

            List<AppUser> users = _userManager.Users.ToList();
            List<UserViewModel> usersViewModel = new List<UserViewModel>();

            foreach(AppUser user in users)
            {
                UserViewModel userViewModel = new UserViewModel();
                userViewModel.Name = user.Name;
                userViewModel.Surname = user.Surname;
                userViewModel.Email = user.Email;
                userViewModel.UserName = user.UserName;
                userViewModel.UserId = user.Id;
                userViewModel.BirthDate = user.BirthDate;

                usersViewModel.Add(userViewModel);
            }

            return View(usersViewModel);
        }


        public IActionResult Add()
        {
            UserViewModel model = new UserViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(UserViewModel model)
        {
            ModelState.Remove("UserId");

            if (!ModelState.IsValid)
            {
                return View(model);
            }


            //var users = _userManager;
            var users = _userManager.Users.ToList();

            //AppUser userCheck = _dbContext.AppUsers.Where(u => u.Email == "admin@mail.com").SingleOrDefault();  //FindByNameAsync(model.UserName).Result; // Email e bakıyor

            //if(userCheck != null)
            //{
            //    ViewBag.Error = "Kullanıcı Adı daha önceden kullanılmıştır";

            //    ModelState.AddModelError("UserName", "Kullanıcı Adı daha önceden kullanılıyor.");

            //    return View(model);
            //}

            //User Kayıt işlemleri yapılacaktır.

            AppUser user = new AppUser();
            user.UserName = model.UserName;
            user.Email = model.Email;
            user.Name = model.Name;
            user.Surname = model.Surname;
            user.BirthDate = model.BirthDate;
            user.FavoriteTeam = model.FavoriteTeam;
            //user.PasswordHash = Sifreleme.Md5Hash(model.Password); //Password Hash size ait olan bir hash provider ile çözümleye bilirsiniz.

            //_dbContext.Users.Add(user);
            //_dbContext.SaveChanges();


            //var result = await _userManager.CreateAsync(user);
            //Task<IdentityResult> result = _userManager.CreateAsync(user);

            IdentityResult result = _userManager.CreateAsync(user,model.Password).Result;

            //Eğer kayıt başarılı ise Index sayfasına geri döncektir.
            if(result.Succeeded)
            {
                //Mail Gönderimi yapılır
                string token = _userManager.GenerateEmailConfirmationTokenAsync(user).Result;

                string link = Url.ActionLink("ValidationEmail","User",new { UserMail = user.Email, Token = token});

                MailGonder(user.Email, user.Name + " " + user.Surname, link);

                return RedirectToAction(nameof(Index));
            }


            //Hatalı durumda hataları Model e ekleyerek geri dönceğiz
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }

            return View(model);

        }

        public IActionResult ValidationEmail(string usermail, string token)
        {
            AppUser? user = _userManager.FindByEmailAsync(usermail).Result;

            if (user == null)
            {
                ViewBag.NotFoundUser = "Kullanıcı bulunamadı.";

                return RedirectToAction("Index", "Home");
            }


            IdentityResult result = _userManager.ConfirmEmailAsync(user, token).Result;

            if (!result.Succeeded) {

                StringBuilder errorSb = new StringBuilder();

                foreach (var error in result.Errors)
                {
                    errorSb.Append(error.Code + " " + error.Description + "<br>");
                }

                ViewBag.Error = errorSb.ToString();

                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Login","Account");
        }

        public IActionResult AddRole(string id)
        {
            List<IdentityRole> roles = _roleManager.Roles.ToList();

            if (!roles.Any())
            {
                ViewBag.Error = "Sistemde kayıtlı role hiç yoktur.";
            }


            List<SelectListItem> list = new List<SelectListItem>();

            foreach (IdentityRole role in roles)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = role.Name;
                selectListItem.Value = role.Id;

                list.Add(selectListItem);
            }

            ViewBag.RoleList = list;
            ViewBag.UserId = id;

            return View();

        }

        [HttpPost]
        public IActionResult AddRole(string userId, string roleId)
        {
            IdentityRole? role = _roleManager.FindByIdAsync(roleId).Result;

            if (role == null)
            {
                return View("Error");
            }

            AppUser? user = _userManager.FindByIdAsync(userId).Result;

            if (user == null)
            {
                return View("Error");
            }

            IdentityResult result = _userManager.AddToRoleAsync(user, role.Name).Result;

            if (!result.Succeeded)
            {
                return View("Error");
            }

            return RedirectToAction(nameof(Index));
        }

        //public IActionResult Login(string returnUrl)
        //{
        //    ViewBag.ReturnUrl = returnUrl;
        //    return View();
        //}

        private void MailGonder(string mail, string displayName, string link)
        {
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host ="smtp.gmail.com";
            smtpClient.Port = 587;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential(_username, _password);

            MailAddress from = new MailAddress("gokselbilgeadam@gmail.com", "Göksel KALYONCU (BilgeAdam)");
            MailAddress to = new MailAddress(mail, displayName);

            MailMessage message = new MailMessage(from, to);
            message.Subject = "App Email Validation";
            message.Body = $@"<p>Merhaba {displayName},</p>
                              <p>Sistemimize başarıyla kayıt oldunuz. Email adresiniz doğrulayarak giriş yapabilirsiniz.</p>
                              <p>Onay için <a href=""{link}"">tıklayınızı</a> </p>
                              <img src='https://picsum.photos/200/300' />";
            //message.Body = RenderMailBody();
            message.IsBodyHtml = true;

            smtpClient.Send(message);

        }

        private string RenderMailBody()
        {
            MailViewModel model = new MailViewModel { Title = "Yeni Üyex", Body = "xSisteme kaydınız başarıyla tamamlanmıştır.", Link = Url.ActionLink("Validate", "User", new { token = "xyz12345" }) };
            ViewData.Model = model;

            return RenderView().Result;
        }

        private async Task<string> RenderView()
        {
            //PartialViewResult result = new PartialViewResult();
            //result.ViewName = "_DemoPartial";

            using (var writer = new StringWriter())
            {
                ViewEngineResult viewEngineResult = _viewEngine.FindView(ControllerContext, "_NewUserMail", true);

                //MailViewModel model = new MailViewModel { Title = "Yeni Üye", Body = "Sisteme kaydınız başarıyla tamamlanmıştır.", Link = Url.ActionLink("Validate", "User", new { token = "xyz12345"}) };

                //IModelMetadataProvider modelMetadataProvider = HttpContext.RequestServices.GetService<IModelMetadataProvider>();

                //ViewDataDictionary<MailViewModel> viewData = new ViewDataDictionary<MailViewModel>(modelMetadataProvider, new ModelStateDictionary());
                //viewData.Model = model;

                ViewContext viewContext = new ViewContext(ControllerContext, viewEngineResult.View, ViewData, TempData, writer, new Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelperOptions());

                await viewEngineResult.View.RenderAsync(viewContext);

                return writer.GetStringBuilder().ToString();
            }
        }

    }
}
