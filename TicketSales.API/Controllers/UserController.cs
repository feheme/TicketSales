using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TicketSales.BLL.Abstract;
using TicketSales.Model.DTOs.UserDTO;
using TicketSales.Model.Entities;

namespace TicketSales.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]


    public class UserController : ControllerBase
    {
        private readonly IUserBLL _userBLL;
        private readonly IMapper _mapper;


        public UserController(IUserBLL userBLL)
        {
            _userBLL = userBLL;
        }


        [HttpGet]
        public IActionResult GetUsers()
        {
            var values = _userBLL.GetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddUser(AddUserDTO userDTO)
        {

            var values = _mapper.Map<User>(userDTO);

            _userBLL.Insert(values);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {

            _userBLL.DeleteByID(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var values = _userBLL.Get(id);
            return Ok(values);
        }
    }
}
