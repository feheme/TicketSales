using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketSales.BLL.Abstract;
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

        [HttpGet]
        public IActionResult SubscribeList()
        {
            var values = _eventBLL.GetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddSubscribe(AddEventDTO addEventDTO)
        {

            var values = _mapper.Map<Event>(addEventDTO);

            _eventBLL.Insert(values);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteSubscribe(int id)
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
        [HttpGet("{id}")]
        public IActionResult GetSubscribe(int id)
        {
            var values = _eventBLL.Get(id);
            return Ok(values);
        }
    }
}
