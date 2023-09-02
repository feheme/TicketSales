using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.IdentityModel.Abstractions;
using System.Data;
using System.Security.Claims;
using TicketSales.BLL.Abstract;
using TicketSales.Model.DTOs.UserDTO;

namespace TicketSales.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Standart")]


    public class ProfileController : ControllerBase
    {
        private readonly IUserBLL _userBLL;

        public ProfileController(IUserBLL userBLL)
        {
            _userBLL = userBLL;
        }

        [HttpGet]
        public IActionResult GetProfile()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user =  _userBLL.Get(Convert.ToInt32(userId));

                           

            return Ok(user);
        }


        [HttpPut("changepassword")]
        public  IActionResult ChangePassword(ChangePasswordDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = _userBLL.Get(Convert.ToInt32(userId));

            if (model.OldPassword == model.NewPassword)
            {
                return BadRequest("Yeni Şifreyle Eski Şifre Aynı Olamaz");

            }
            if (user.Password != model.OldPassword)
            {
                return BadRequest("Eski Şifreyi Kontrol Ediniz.");

            }

            user.Password = model.NewPassword;

            _userBLL.Update(user);


            return Ok();

          

           
        }
    }
}
