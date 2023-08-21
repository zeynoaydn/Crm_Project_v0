using AutoMapper;
using Business.Abstract;
using Business.Dtos;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace WebUI.Controllers
{
    public class CitiesController : Controller
    {
        private readonly ILogger<CitiesController> _logger;
        private readonly ICitiesService _citiesService;
        private readonly IMapper _mapper;

        public CitiesController(ILogger<CitiesController> logger, ICitiesService citiesService, IMapper mapper)
        {
            _logger = logger;
            _citiesService = citiesService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            //return View();
            var result=_citiesService.GetAll();
            //ViewData["Cities"] = result.Data;
            //return View();
            var citiesDtos = _mapper.Map<List<CitiesDto>>(result.Data);
            return View(citiesDtos);
        }

        [HttpPost]
        public List<CitiesDto> GetCities()
        {
            var result = _citiesService.GetAll();
            //return result.Data;
            var citiesDtos = _mapper.Map<List<CitiesDto>>(result.Data);
            return citiesDtos;
        }
    }
}
