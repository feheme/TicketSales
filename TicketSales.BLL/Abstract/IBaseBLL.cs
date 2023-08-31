using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSales.Core.Entity;

namespace TicketSales.BLL.Abstract
{
    public interface IBaseBLL<TEntity> where TEntity : BaseEntity
    {
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void DeleteByID(int entityID);
        TEntity Get(int entityID);
        ICollection<TEntity> GetAll();
    }
}
