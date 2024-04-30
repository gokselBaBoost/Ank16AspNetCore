using HMS.WebApp.Data;
using HMS.WebApp.Data.Entities;
using HMS.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace HMS.WebApp.Controllers
{
    public class CountryController : Controller
    {
        private HmsDbContext _hmsDbContext;
        private int _pageSize = 3;
        private int _pageNo = 1;
        private int _rowId = 1;
        public CountryController(HmsDbContext hmsDbContext)
        {
            _hmsDbContext = hmsDbContext;
        }

        public IActionResult Index()
        {
            List<Country> countries = GetCountries(); //_hmsDbContext.Countries.ToList();

            List<CountryEditListViewModel> list = new List<CountryEditListViewModel>();

            

            foreach (Country country in countries)
            {
                CountryEditListViewModel vm = new CountryEditListViewModel();
                vm.Id = country.Id;
                vm.Name = country.Name;
                vm.IsActive = country.IsActive;
                vm.RowNum = _rowId + (_pageSize * (_pageNo - 1));

                list.Add(vm);

                _rowId++;
            }

            double pageCount = GetCountriesCount() / (_pageSize * 1.0);

            ViewBag.PageCount = Math.Ceiling(pageCount);
            //ViewData["Model"] = list;

            return View(list);
        }

        public IActionResult CountryList(int pageSize = 0, int pageNo = 0)
        {
            List<Country> countries = GetCountries(pageSize, pageNo);

            List<CountryEditListViewModel> list = new List<CountryEditListViewModel>();

            foreach (Country country in countries)
            {
                CountryEditListViewModel vm = new CountryEditListViewModel();
                vm.Id = country.Id;
                vm.Name = country.Name;
                vm.IsActive = country.IsActive;
                vm.RowNum = _rowId + (pageSize * (pageNo - 1));

                list.Add(vm);

                _rowId++;
            }

            return PartialView("_CountryList", list);
        }

        public IActionResult AddCountry()
        {
            CountryAddViewModel model = new CountryAddViewModel();

            return PartialView("_AddCountry", model);
        }

        [HttpPost]
        public IActionResult SaveCountry(CountryAddViewModel model)
        {
            Country entity = new Country();
            entity.Name = model.Name;
            entity.IsActive = model.IsActive;

            _hmsDbContext.Countries.Add(entity);

            int result = _hmsDbContext.SaveChanges();

            ResponseViewModel response = new ResponseViewModel();

            if(result > 0)
            {
                response.IsSuccess = true;
                response.Record = entity;
            }
            else
            {
                response.IsSuccess = false;
                response.Error = "Bir hata oluştu.";
            }

            return Json(response);
        }
    
        public List<Country> GetCountries(int pageSize = 0, int pageNo = 0)
        {
            pageSize = pageSize == 0 ? _pageSize : pageSize;
            pageNo = pageNo == 0 ? _pageNo : pageNo;

            return  _hmsDbContext.Countries
                                 .Skip((pageNo - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToList();
        }

        public int GetCountriesCount()
        {
            return _hmsDbContext.Countries.Count();
        }
    }
}
