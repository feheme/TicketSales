using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSales.BLL.Abstract;
using TicketSales.DAL.Abstract;
using TicketSales.DAL.Concrete;
using TicketSales.Model.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TicketSales.BLL.Concrete
{
    internal class EventService : IEventBLL
    {
        private readonly IEventDAL _eventDAL;

        public EventService(IEventDAL eventDAL)
        {
            _eventDAL = eventDAL;
        }

        public void Delete(Event entity)
        {
            _eventDAL.Remove(entity);
        }

        public void DeleteByID(int entityID)
        {
            Event _entity = Get(entityID);
            _entity.IsActive = false;
            _eventDAL.Update(_entity);

        }

        public void EventStatusChangeApproved(int id)
        {
            _eventDAL.EventStatusChangeApproved(id);
        }

        public void EventStatusRemove(int id)
        {
            _eventDAL.EventStatusRemove(id);
        }

        public Event Get(int entityID)
        {
            return _eventDAL.Get(a => a.ID == entityID);
        }

        public ICollection<Event> GetAll()
        {
            return _eventDAL.GetAll();
        }

        public List<Event> GetEvents(string category = null, string city = null)
        {

            using var context = new TicketSalesDbContext();
            var query = context.Events.AsQueryable();

            if (!string.IsNullOrEmpty(category))
            {
                 query = query.Where(x => x.Category.CategoryName == category);
            }
            if (!string.IsNullOrEmpty(city))
            {
                 query = query.Where(e => e.City.CityName == city);
            }

            return query.ToList();
        }

        public void Insert(Event entity)
        {
            _eventDAL.Add(entity);
        }

        public void Update(Event entity)
        {
            _eventDAL.Update(entity);
        }
    }
}
