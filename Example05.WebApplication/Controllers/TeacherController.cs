using Example05.WebApplication.Models;
using Example05.WebApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace Example05.WebApplication.Controllers
{
    public class TeacherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //public IActionResult Create(string name, string surname, string email)
        //public IActionResult Create(IFormCollection form)
        //public IActionResult Create([Bind("Name","BirthDate")]TeacherViewModel model)
        public IActionResult Create([Bind("Name","BirthDate")]Teacher model)
        {
            model.BirthDate = new DateOnly(2000, 1, 1);
            model.Name += " Kazım";
            //var request = HttpContext.Request;
            //var queryString = request.QueryString;
            //var query = request.Query;

            //if (request.Method == "POST")
            //{
            //    var form = request.Form;

            //    string name = form["Name"];
            //    string surname = form["Surname"];
            //}

            return View(model);
        }
    }
}
