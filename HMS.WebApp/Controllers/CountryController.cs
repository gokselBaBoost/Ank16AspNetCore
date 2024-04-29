using HMS.WebApp.Data;
using HMS.WebApp.Data.Entities;
using HMS.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace HMS.WebApp.Controllers
{
    public class CountryController : Controller
    {
        private HmsDbContext _hmsDbContext;
        public CountryController(HmsDbContext hmsDbContext)
        {
            _hmsDbContext = hmsDbContext;
        }

        public IActionResult Index()
        {
            List<Country> countries = _hmsDbContext.Countries.ToList();

            List<CountryEditListViewModel> list = new List<CountryEditListViewModel>();

            foreach (Country country in countries)
            {
                CountryEditListViewModel vm = new CountryEditListViewModel();
                vm.Id = country.Id;
                vm.Name = country.Name;
                vm.IsActive = country.IsActive;

                list.Add(vm);
            }

            return View(list);
        }
    }
}
