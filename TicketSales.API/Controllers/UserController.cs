using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketSales.BLL.Abstract;

namespace TicketSales.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBLL _userBLL;

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
        //[HttpPost]
        //public IActionResult AddSubscribe(Subscribe subscribe)
        //{
        //    _subscribeService.TInsert(subscribe);
        //    return Ok();
        //}
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
        }
        //[HttpGet("{id}")]
        //public IActionResult GetSubscribe(int id)
        //{
        //    var values = _userBLL.
        //}
}
