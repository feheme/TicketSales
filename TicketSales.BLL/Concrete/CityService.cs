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
    internal class CityService : ICityBll
    {
        private readonly ICityDAL _cityDAL;

        public CityService(ICityDAL cityDAL)
        {
            _cityDAL = cityDAL;
        }

        public void Delete(City entity)
        {
            _cityDAL.Remove(entity);
        }

        public void DeleteByID(int entityID)
        {
            City _entity = Get(entityID);
            _entity.IsActive = false;
            _cityDAL.Update(_entity);
        }

        public City Get(int entityID)
        {
            return _cityDAL.Get(a => a.ID == entityID);

        }

        public ICollection<City> GetAll()
        {
            return _cityDAL.GetAll();

        }

        public void Insert(City entity)
        {
            _cityDAL.Add(entity);

        }

        public void Update(City entity)
        {
            _cityDAL.Update(entity);

        }
    }
}
