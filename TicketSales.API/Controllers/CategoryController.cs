using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TicketSales.BLL.Abstract;
using TicketSales.Model.DTOs.CategoryDTO;
using TicketSales.Model.DTOs.UserDTO;
using TicketSales.Model.Entities;

namespace TicketSales.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]

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
        public IActionResult GetCategories()
        {
            var values = _categoryBLL.GetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddCategory(AddCategoryDTO addCategoryDTO)
        {

            var values = _mapper.Map<Category>(addCategoryDTO);

            _categoryBLL.Insert(values);
            return CreatedAtAction(nameof(GetCategory), new { ID = values.ID }, addCategoryDTO);
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
        public IActionResult GetCategory(int id)
        {
            var values = _categoryBLL.Get(id);
            if (values == null)
            {
                return NotFound();
            }

            return Ok(values);
        }
    }
}
