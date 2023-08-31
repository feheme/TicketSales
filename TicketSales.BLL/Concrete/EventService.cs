using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSales.BLL.Abstract;
using TicketSales.DAL.Abstract;
using TicketSales.Model.Entities;

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

        public Event Get(int entityID)
        {
            return _eventDAL.Get(a => a.ID == entityID);
        }

        public ICollection<Event> GetAll()
        {
            return _eventDAL.GetAll();
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
