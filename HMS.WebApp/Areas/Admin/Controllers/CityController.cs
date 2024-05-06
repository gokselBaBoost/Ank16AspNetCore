using HMS.BLL.Managers.Abstract;
using HMS.BLL.Managers.Concrete;
using HMS.DTO;
using HMS.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HMS.WebApp.Areas.Admin.Controllers
{
    public class CityController : Controller
    {
        private readonly CityManager _cityManager;
        private readonly CountryManager _countryManager;
        private int _pageSize = 3;
        private int _pageNo = 1;
        private int _rowId = 1;

        private IEnumerable<CityDto> _citylist;
        private IEnumerable<CityDto> _cityPagelist;


        public CityController(CityManager cityManager, CountryManager countryManager)
        {
            _cityManager = cityManager;
            _countryManager = countryManager;

            _citylist = _cityManager.GetAll();
            _cityPagelist = _citylist.Skip((_pageNo - 1) * _pageSize).Take(_pageSize).ToList();
        }

        public IActionResult Index()
        {

            List<CityEditListViewModel> vmlist = new List<CityEditListViewModel>();

            foreach (CityDto city in _cityPagelist)
            {
                CountryEditListViewModel country = new CountryEditListViewModel();
                if (city.Country is not null)
                {
                    country.Id = city.Country.Id;
                    country.Name = city.Country.Name;
                }



                CityEditListViewModel vm = new CityEditListViewModel();
                vm.Id = city.Id;
                vm.Name = city.Name;
                vm.IsActive = city.IsActive;
                vm.Country = country;
                vm.RowNum = _rowId + (_pageSize * (_pageNo - 1));

                vmlist.Add(vm);

                _rowId++;
            }

            double pageCount = _citylist.Count() / (_pageSize * 1.0);

            ViewBag.PageCount = Math.Ceiling(pageCount);

            return View(vmlist);
        }

        public IActionResult CityList(int pageSize = 0, int pageNo = 0)
        {

            IEnumerable<CityDto> cities = _citylist.Skip((pageNo - 1) * pageSize)
                                                                    .Take(pageSize)
                                                                    .ToList();

            List<CityEditListViewModel> list = new List<CityEditListViewModel>();

            foreach (CityDto country in cities)
            {
                CityEditListViewModel vm = new CityEditListViewModel();
                vm.Id = country.Id;
                vm.Name = country.Name;
                vm.IsActive = country.IsActive;
                vm.RowNum = _rowId + (pageSize * (pageNo - 1));

                list.Add(vm);

                _rowId++;
            }

            return PartialView("_CityList", list);
        }

        public IActionResult Add()
        {
            CityAddViewModel vm = new CityAddViewModel();

            List<SelectListItem> countries = new List<SelectListItem>();

            //_countryManager.GetAll().Where(c => c.IsActive == true);
            List<CountryDto> countriesDto = ((ICountryManager)_countryManager).GetActiveList().ToList();

            countries.Add(new SelectListItem { Text = "Ülke Seçiniz", Value = "-1", Selected = true });

            foreach (CountryDto country in countriesDto)
            {
                countries.Add(new SelectListItem { Text = country.Name, Value = country.Id.ToString() });
            }

            ViewBag.Countries = countries;

            return View(vm);
        }

        [HttpPost]
        public IActionResult Add(CityAddViewModel vm)
        {
            //Validation Check
            if (!ModelState.IsValid)
            {
                return View(vm);
            }


            //Model to Dto Mapping

            CityDto cityDto = new CityDto();
            cityDto.Name = vm.Name;
            cityDto.IsActive = vm.IsActive;
            cityDto.CountryId = vm.CountryId;

            //Service Call

            _cityManager.Add(cityDto);

            return RedirectToAction(nameof(Index));
        }
    }
}
