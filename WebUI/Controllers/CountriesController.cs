using AutoMapper;
using Business.Abstract;
using Business.Dtos;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace WebUI.Controllers
{
    public class CountriesController:Controller
    {
        private readonly ILogger<CountriesController> _logger;
        private readonly ICountriesService _countriesService;
        private readonly IMapper _mapper;

        public CountriesController(ILogger<CountriesController> logger, ICountriesService countriesService,IMapper mapper)
        {
            _logger = logger;
            _countriesService = countriesService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var result=_countriesService.GetAll();
            var countriesDtos = _mapper.Map<List<CountriesDto>>(result.Data);
            return View(countriesDtos);
        }

        [HttpPost]
        public List<CountriesDto> GetCountries()
        {
            var result = _countriesService.GetAll();
            var countriesDtos = _mapper.Map<List<CountriesDto>>(result.Data);
            return countriesDtos;
        }
    }
}
