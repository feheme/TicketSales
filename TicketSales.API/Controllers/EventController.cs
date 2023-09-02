using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;
using TicketSales.BLL.Abstract;
using TicketSales.DAL.Concrete;
using TicketSales.Model.DTOs.EventDTO;
using TicketSales.Model.DTOs.UserDTO;
using TicketSales.Model.Entities;

namespace TicketSales.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]



    public class EventController : ControllerBase
    {
        private readonly IEventBLL _eventBLL;
        private readonly IMapper _mapper;

        public EventController(IEventBLL eventBLL, IMapper mapper)
        {
            _eventBLL = eventBLL;
            _mapper = mapper;
        }


        [Authorize(Roles = "Standart,Admin,Company")]

        [Produces("application/json", "application/xml")] // JSON ve XML formatlarını destekler
        [Consumes("application/json", "application/xml")] // JSON ve XML formatlarını kabul eder
        [HttpGet]

        public IActionResult GetEvents()
        {
            var values = _eventBLL.GetAll();
            return Ok(values);
        }

        [Authorize(Roles = "Standart")]
        [HttpGet("[action]")]
        public IActionResult GetEventsWithCategoryAndCity(string category = null, string city = null)
        {
            var values = _eventBLL.GetEvents(category, city);
            return Ok(values);
        }

        [Authorize(Roles = "Standart")]
        [HttpPost]
        public IActionResult AddEvent(AddEventDTO addEventDTO)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;


            var values = _mapper.Map<Event>(addEventDTO);
            values.OrganizerId = Convert.ToInt32(userId);
            values.IsActive = false;


            _eventBLL.Insert(values);
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public IActionResult DeleteEvent(int id)
        {

            _eventBLL.DeleteByID(id);
            return Ok();
        }
        //[HttpPut]
        //public IActionResult UpdateSubscribe(Subscribe subscribe)
        //{
        //    _subscribeService.TUpdate(subscribe);
        //    return Ok();
        //}

        [Authorize(Roles = "Standart")]
        [HttpGet("{id}")]
        public IActionResult GetEvent(int id)
        {
            var values = _eventBLL.Get(id);
            return Ok(values);
        }

        [Authorize(Roles = "Admin")]
        [HttpPatch("[action]/{id}")]
        public IActionResult EventApproved(int id)
        {
            _eventBLL.EventStatusChangeApproved(id);
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpPatch("[action]/{id}")]
        public IActionResult EventDelete(int id)
        {
            _eventBLL.EventStatusRemove(id);
            return NoContent();
        }
        [HttpPatch("[action]/{id}")]

        [Authorize(Roles = "Standart")]
        public IActionResult EventJoin(int id)
        {

            using var context = new TicketSalesDbContext();
            var values = context.Events.Find(id);

            if (values.Capacity < 1)
            {
                return BadRequest("Kapasitesi dolmuştur.");
            }

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var join = context.Users.Find(Convert.ToInt32(userId));
            join.IdEvent = values.ID;
            values.Capacity--;
            context.SaveChanges();

            return Ok();


        }

    }
}
