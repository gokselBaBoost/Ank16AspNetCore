using Example01.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;

namespace Example01.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private List<Category> _categories;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            SetCategories();
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        //Cookie set 
        public IActionResult SetCategory(int catId)
        {
            HttpContext.Response.Cookies.Append("catId", catId.ToString());

            return RedirectToAction(nameof(Category));
        }

        //Cookie set 
        public IActionResult SetSubCategory(int subCatId, bool httpItems = false)
        {
            if(!httpItems)
                HttpContext.Response.Cookies.Append("subCatId", subCatId.ToString());
            else
            {
                HttpContext.Items["subCatId"] = subCatId.ToString();
                return RedirectToAction(nameof(SubCategory));
            }
                

            return RedirectToAction(nameof(Category));
        }

        //Cookie get
        public IActionResult Category() 
        {
            var cookie = HttpContext.Request.Cookies;
            var cookieCatId = HttpContext.Request.Cookies["catId"];
            var cookieSubCatId = HttpContext.Request.Cookies["subCatId"];

            int catId;
            int subCatId;

            int.TryParse(cookieCatId, out catId);
            int.TryParse(cookieSubCatId, out subCatId);

            //int sonuc;

            //this.CustomTryOut(catId, out sonuc);

            //int sonuc2 = 1;

            //this.CustomTryRef(catId, ref sonuc2);

            StringBuilder sb = new StringBuilder();

            if(catId == 0)
            {
                foreach(Category item in _categories)
                {
                    sb.Append(item.Name + "\n");
                    if (item.SubCategories.Any())
                    {
                        item.SubCategories.ForEach(item => {  sb.Append("\t" + item.Name + "\n"); });
                    }
                }
            }
            else
            {
                
                if (subCatId == 0)
                {
                    foreach (Category item in _categories.Where(c => c.Id == catId))
                    {
                        sb.Append(item.Name + "\n");
                        if (item.SubCategories.Any())
                        {
                            item.SubCategories.ForEach(item => { sb.Append("\t" + item.Name + "\n"); });
                        }
                    }
                }
                else
                {
                    foreach (Category item in _categories.Where(c => c.Id == catId))
                    {
                        sb.Append(item.Name + "\n");
                        if (item.SubCategories.Any())
                        {
                            item.SubCategories.Where(sc => sc.Id == subCatId).ToList().ForEach(item => { sb.Append("\t" + item.Name + "\n"); });
                        }
                    }
                }

            }

            return Content(sb.ToString());
        }

        public IActionResult SubCategory()
        {
            var subCatIdObject = HttpContext.Items["subCatId"];

            int subCatId = Convert.ToInt32(subCatIdObject);

            string name = _categories.Where(cat => cat.SubCategories.Where(sc => sc.Id == subCatId).Any()).FirstOrDefault()?.Name;

            HttpContext.Items["CategoryName"] = name.Replace(" ", "-");

            return Content($"Sub Category Name : {name}");
        }


        public IActionResult SetUserInfo()
        {
            string name = "Göksel";
            int age = 5;
            string email = "goksel@mail.com";

            try
            {
                HttpContext.Session.Set("user-mail", Encoding.UTF8.GetBytes(email));
                HttpContext.Session.SetString("user-name", name);
                HttpContext.Session.SetInt32("user-age", age);
            }
            catch (Exception ex)
            {
                TempData["Status"] = -1;
                TempData["ErrorMessage"] = ex.Message + " SetUserInfo Exception";

            }


            return RedirectToAction(nameof(GetUserInfo));
        }

        public IActionResult GetUserInfo()
        {
            try
            {
                if (HttpContext.Session.Keys.Any())
                {
                    ViewBag.SessionId = HttpContext.Session.Id;
                    ViewBag.UserName = HttpContext.Session.GetString("user-name");
                    ViewBag.UserAge = HttpContext.Session.GetInt32("user-age");

                    byte[] userMail;

                    HttpContext.Session.TryGetValue("user-mail", out userMail);

                    ViewBag.UserMail = userMail;
                    ViewBag.UserMailString = userMail!=null ? Encoding.UTF8.GetString(userMail) : "--";

                    ViewBag.Status = 1;
                }
                else
                {
                    ViewBag.Status = 0;
                    ViewBag.ErrorMessage = "Session da henüz bir key yoktur.";
                }
            }
            catch(Exception ex)
            {
                ViewBag.Status = TempData["Status"] ?? - 1;
                ViewBag.ErrorMessage = TempData["ErrorMessage"] ?? ex.Message;
            }
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public void SetCategories()
        {
            //Db den veri insert

            Category subCat11 = new Category { Id = 11, Name = "Kategori 1-1" };
            Category subCat12 = new Category { Id = 12, Name = "Kategori 1-2" };
            Category subCat13 = new Category { Id = 13, Name = "Kategori 1-3" };

            List<Category> subCategories1 = new List<Category>();
            subCategories1.Add(subCat11);
            subCategories1.Add(subCat12);
            subCategories1.Add(subCat13);

            Category subCat21 = new Category { Id = 21, Name = "Kategori 2-1" };
            Category subCat22 = new Category { Id = 22, Name = "Kategori 2-2" };
            Category subCat23 = new Category { Id = 23, Name = "Kategori 2-3" };

            List<Category> subCategories2 = new List<Category>();
            subCategories2.Add(subCat21);
            subCategories2.Add(subCat22);
            subCategories2.Add(subCat23);


            Category cat1 = new Category { Id = 1, Name = "Kategori 1", SubCategories = subCategories1 };
            Category cat2 = new Category { Id = 2, Name = "Kategori 2", SubCategories = subCategories2 };
            Category cat3 = new Category { Id = 3, Name = "Kategori 3", SubCategories = new List<Category>() };

            _categories = new List<Category> { cat1, cat2, cat3 };
        }

        public bool CustomTryOut(int a, out int b)
        {
            b = 10;

            return (a * b) > 0;
        }

        public bool CustomTryRef(int a, ref int b)
        {
            return (a * b) > 0;
        }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Category> SubCategories { get; set; }
    }
}
