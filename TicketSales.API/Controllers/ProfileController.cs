using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.IdentityModel.Abstractions;
using System.Data;
using System.Security.Claims;
using TicketSales.BLL.Abstract;
using TicketSales.DAL.Concrete;
using TicketSales.Model.DTOs.EventDTO;
using TicketSales.Model.DTOs.UserDTO;

namespace TicketSales.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Standart")]


    public class ProfileController : ControllerBase
    {
        private readonly IUserBLL _userBLL;
        

        public ProfileController(IUserBLL userBLL, IEventBLL eventBLL)
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


        [HttpGet("action")]
        public IActionResult GetProfileCreated()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;            
            

            var context = new TicketSalesDbContext();
            var naber = context.Events.Where(x => x.OrganizerId == Convert.ToInt32(userId)).ToList();     
            
            
                      
            return Ok(naber);
        }



        [HttpPatch("naber")]
        public IActionResult naber(UpdateEventDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var context = new TicketSalesDbContext();

            var naber = context.Events.Where(x => x.OrganizerId == Convert.ToInt32(userId) && x.IsActive == false).FirstOrDefault();

            naber.Address = model.Address;
            naber.Capacity = model.Capacity;

            context.SaveChanges();

            return Ok();




        }


        [HttpPatch("changepassword")]
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
