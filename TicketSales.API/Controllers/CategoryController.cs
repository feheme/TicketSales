using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketSales.BLL.Abstract;
using TicketSales.Model.DTOs.CategoryDTO;
using TicketSales.Model.DTOs.UserDTO;
using TicketSales.Model.Entities;

namespace TicketSales.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryBLL _categoryBLL;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryBLL categoryBLL, IMapper mapper)
        {
            _categoryBLL = categoryBLL;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SubscribeList()
        {
            var values = _categoryBLL.GetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddSubscribe(AddCategoryDTO addCategoryDTO)
        {

            var values = _mapper.Map<Category>(addCategoryDTO);

            _categoryBLL.Insert(values);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteSubscribe(int id)
        {

            _categoryBLL.DeleteByID(id);
            return Ok();
        }
        //[HttpPut]
        //public IActionResult UpdateSubscribe(Subscribe subscribe)
        //{
        //    _subscribeService.TUpdate(subscribe);
        //    return Ok();
        //}
        [HttpGet("{id}")]
        public IActionResult GetSubscribe(int id)
        {
            var values = _categoryBLL.Get(id);
            return Ok(values);
        }
    }
}
