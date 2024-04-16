using Example01.WebApplication.Library;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Example01.WebApplication.Controllers
{
    public class OperationController : Controller
    {
        public IActionResult Index()
        {
            List<Person> people = new List<Person>();
            people.Add(new Person() { Id = 1, Name = "Göksel", Surname = "Kalyoncu", BirthDate = new DateOnly(1980, 3, 5) });
            people.Add(new Person() { Id = 2, Name = "Kazım", Surname = "Kalyoncu", BirthDate = new DateOnly(1990, 4, 6) });
            people.Add(new Person() { Id = 3, Name = "Kazım Göksel", Surname = "Kalyoncu", BirthDate = new DateOnly(2000, 5, 7) });

            return View(people);
        }

        public string GetPerson(int test, int id)
        {
            Islem(5, "değer", true);
            Islem(z:true, x:5, y:"değer");

            return $"Sonuç: id:{id} test:{test}";
        }

        public void Islem(int x, string y, bool z)
        {
            
        }
    }
}
