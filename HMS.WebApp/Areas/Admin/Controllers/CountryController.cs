using AutoMapper;
using HMS.BLL.Managers.Concrete;
using HMS.DTO;
using HMS.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HMS.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CountryController : Controller
    {
        private CountryManager _countryManager;
        private int _pageSize = 3;
        private int _pageNo = 1;
        private int _rowId = 1;

        private IMapper _mapper;

        public CountryController(CountryManager countryManager)
        {
            _countryManager = countryManager;

            MapperConfiguration config = new MapperConfiguration(config =>
            {
                config.CreateMap<CountryDto, CountryEditListViewModel>()
                      .ForMember(dest => dest.Cities, opt => opt.MapFrom(src => src.Cities));

                config.CreateMap<CityDto, CityEditListViewModel>().ReverseMap();
            });

            _mapper = config.CreateMapper();
        }

        [Authorize]
        public IActionResult Index()
        {
            //List<Country> countries = GetCountries(); //_hmsDbContext.Countries.ToList();

            IEnumerable<CountryDto> countrylist = _countryManager.GetAll();

            IEnumerable<CountryDto> countryDtoList = countrylist.Skip((_pageNo - 1) * _pageSize)
                                                                    .Take(_pageSize)
                                                                    .ToList();

            List<CountryEditListViewModel> vmlist = new List<CountryEditListViewModel>();

            foreach (CountryDto country in countryDtoList)
            {
                CountryEditListViewModel vm = new CountryEditListViewModel();
                vm.Id = country.Id;
                vm.Name = country.Name;
                vm.IsActive = country.IsActive;
                vm.RowNum = _rowId + (_pageSize * (_pageNo - 1));

                vmlist.Add(vm);

                _rowId++;
            }

            double pageCount = countrylist.Count() / (_pageSize * 1.0);

            ViewBag.PageCount = Math.Ceiling(pageCount);

            return View(vmlist);
        }

        public IActionResult CountryList(int pageSize = 0, int pageNo = 0)
        {
            IEnumerable<CountryDto> countrylist = _countryManager.GetAll();

            IEnumerable<CountryDto> countries = countrylist.Skip((pageNo - 1) * pageSize)
                                                                    .Take(pageSize)
                                                                    .ToList();

            List<CountryEditListViewModel> list = new List<CountryEditListViewModel>();

            foreach (CountryDto country in countries)
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

        //[HttpPost]
        //public IActionResult SaveCountry(CountryAddViewModel model)
        //{
        //    Country entity = new Country();
        //    entity.Name = model.Name;
        //    entity.IsActive = model.IsActive;

        //    _hmsDbContext.Countries.Add(entity);

        //    int result = _hmsDbContext.SaveChanges();

        //    ResponseViewModel response = new ResponseViewModel();

        //    if(result > 0)
        //    {
        //        response.IsSuccess = true;
        //        response.Record = entity;
        //    }
        //    else
        //    {
        //        response.IsSuccess = false;
        //        response.Error = "Bir hata oluştu.";
        //    }

        //    return Json(response);
        //}

        //public List<Country> GetCountries(int pageSize = 0, int pageNo = 0)
        //{
        //    pageSize = pageSize == 0 ? _pageSize : pageSize;
        //    pageNo = pageNo == 0 ? _pageNo : pageNo;

        //    return  _hmsDbContext.Countries
        //                         .Skip((pageNo - 1) * pageSize)
        //                         .Take(pageSize)
        //                         .ToList();
        //}

        //public int GetCountriesCount()
        //{
        //    return _hmsDbContext.Countries.Count();
        //}

        public IActionResult Add([FromServices] ILogger<CountryController> logger)
        {
            logger.LogInformation("Bu bir info log kaydıdır.");

            return View(new CountryAddViewModel());
        }

        [HttpPost]
        public IActionResult Add(CountryAddViewModel viewModel)
        {
            //Validation 

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            //Managera gönderim


            CountryDto countryDto = new CountryDto();
            countryDto.Name = viewModel.Name;
            countryDto.IsActive = viewModel.IsActive;

            if (_countryManager.Add(countryDto) > 0)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);

        }

        public IActionResult Detail(int id)
        {
            CountryDto countryDto = _countryManager.Get(id);

            //CountryEditListViewModel vm = new CountryEditListViewModel();
            //vm.Id = countryDto.Id;
            //vm.Name = countryDto.

            CountryEditListViewModel vm = _mapper.Map<CountryEditListViewModel>(countryDto);


            return View(vm);
        }

    }
}
