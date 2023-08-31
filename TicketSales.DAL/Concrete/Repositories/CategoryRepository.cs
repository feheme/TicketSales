using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSales.Core.DataAccess;
using TicketSales.DAL.Abstract;
using TicketSales.Model.Entities;

namespace TicketSales.DAL.Concrete.Repositories
{
    internal class CategoryRepository : EFRepositoryBase<Category, TicketSalesDbContext>, ICategoryDAL
    {
    }
}
