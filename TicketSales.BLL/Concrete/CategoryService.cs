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
    internal class CategoryService : ICategoryBLL
    {
        private readonly ICategoryDAL _categoryDAL;

        public CategoryService(ICategoryDAL categoryDAL)
        {
            _categoryDAL = categoryDAL;
        }

        public void Delete(Category entity)
        {
            _categoryDAL.Remove(entity);

        }

        public void DeleteByID(int entityID)
        {
            Category _entity = Get(entityID);
            _entity.IsActive = false;
            _categoryDAL.Update(_entity);
        }

        public Category Get(int entityID)
        {
            return _categoryDAL.Get(a => a.ID == entityID);

        }

        public ICollection<Category> GetAll()
        {
            return _categoryDAL.GetAll();

        }

      

        public void Insert(Category entity)
        {
            _categoryDAL.Add(entity);

        }

        public void Update(Category entity)
        {
            _categoryDAL.Update(entity);

        }
    }
}
