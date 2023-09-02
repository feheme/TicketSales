using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TicketSales.BLL.Abstract;
using TicketSales.Model.DTOs.CategoryDTO;
using TicketSales.Model.DTOs.CityDTO;
using TicketSales.Model.Entities;

namespace TicketSales.API.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    [Authorize(Roles = "Admin")]  

    public class CityController : ControllerBase
    {
        private readonly ICityBll _cityBll;
        private readonly IMapper _mapper;

        public CityController(ICityBll cityBll, IMapper mapper)
        {
            _cityBll = cityBll;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCities()
        {
            var values = _cityBll.GetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddCity(AddCityDTO addCityDTO)
        {

            var values = _mapper.Map<City>(addCityDTO);
            

            _cityBll.Insert(values);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteCity(int id)
        {

            _cityBll.DeleteByID(id);
            return Ok();
        }

        //[HttpPut]
        //public IActionResult UpdateSubscribe(Subscribe subscribe)
        //{
        //    _subscribeService.TUpdate(subscribe);
        //    return Ok();
        //}

        [HttpGet("{id}")]
        public IActionResult GetCity(int id)
        {
            var values = _cityBll.Get(id);
            return Ok(values);
        }
    }
}
