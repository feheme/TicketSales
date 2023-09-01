using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketSales.BLL.Abstract;
using TicketSales.Model.DTOs.UserDTO;
using TicketSales.Model.Entities;

namespace TicketSales.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBLL _userBLL;
        private readonly IMapper _mapper;


        public UserController(IUserBLL userBLL)
        {
            _userBLL = userBLL;
        }


        [HttpGet]
        public IActionResult SubscribeList()
        {
            var values = _userBLL.GetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddSubscribe(AddUserDTO userDTO)
        {
         
            var values = _mapper.Map<User>(userDTO);

            _userBLL.Insert(values);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteSubscribe(int id)
        {

            _userBLL.DeleteByID(id);
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
            var values = _userBLL.Get(id);
            return Ok(values);
        }
    }
}
