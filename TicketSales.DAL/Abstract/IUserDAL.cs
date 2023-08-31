using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSales.Core.DataAccess;
using TicketSales.Model.Entities;

namespace TicketSales.DAL.Abstract
{
    public interface IUserDAL : IRepository<User>
    {
    }
}
