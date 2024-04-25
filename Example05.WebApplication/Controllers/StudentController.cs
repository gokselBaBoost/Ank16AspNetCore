using Example05.WebApplication.Models;
using Example05.WebApplication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Example05.WebApplication.Controllers
{
    public class StudentController : Controller
    {
        private const string _pageTitle = "Student";

        // GET: StudentController
        public ActionResult Index()
        {
            ViewBag.Title = $"{_pageTitle} Index";

            ViewData["Baslik"] = "Öğrenciler";


            //ViewBag.KayitDeneme = ViewBag.Deneme ?? "ViewBag.Deneme gelemedi...";
            //ViewData["KayitEkBilgi"] = ViewData["EkBilgi"] ?? "ViewData['EkBilgi'] gelemedi...";

            //string tempData = "TempData['KayitDurumu'] henüz gönderilmedi";

            //if(TempData["KayitDurumu"]  != null)
            //{
            //    tempData = TempData["KayitDurumu"].ToString(); 
            //}

            //ViewBag.KayitTempData = tempData;

            //ViewData["Title"] = "Ben değiştim Hayat :)"; // Bu Title keyi ViewBag de ki property değiştirecektir. AMAN DİKKAT!!!

            List<Student> students = StudentService.Students();

            if (TempData.Any())
            {
                if (TempData["CreateStatus"] != null)
                {
                    if ((bool)TempData["CreateStatus"])
                    {
                        ViewBag.CreateStatus = true;
                    }
                    else
                    {
                        ViewBag.CreateStatus = false;
                    }
                    
                    ViewBag.CreateMessage = TempData["CreateMessage"];
                }
            }


            return View(students);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.Title = $"{_pageTitle} Index";
            return View();
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            ViewData["Baslik"] = "Yeni Öğrenci";

            Student student = new Student();

            return View(student);
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //public ActionResult Create(string name, string surname, string email, string birthDate, string gender, string studentStatus)
        public ActionResult Create(Student student)
        {
            try
            {
                //ViewBag.Deneme = "view Bag geldin mi?";
                //ViewData["EkBilgi"] = "View Data geldin mi?";

                //TempData["KayitDurumu"] = "Kayıt başarılı oldu.";

                //string name = collection["Name"];
                //string surname = collection["Surname"];
                //string email = collection["Email"];
                //string birthDate = collection["BirthDate"];
                //string gender = collection["Gender"];
                //string status = collection["StudentStatus"];

                string name = student.Name;
                string surname = student.Surname;
                string email = student.Email;
                DateOnly birthDate = student.BirthDate;
                Gender gender = student.Gender;
                StudentStatus status = student.StudentStatus;

                StudentService.AddStudent(student);

                TempData["CreateStatus"] = false;
                TempData["CreateMessage"] = $"{name} {surname} sistemimize başarıyla kayıt oldu.";


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
