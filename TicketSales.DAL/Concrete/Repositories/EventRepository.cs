using Microsoft.EntityFrameworkCore;
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
    internal class EventRepository : EFRepositoryBase<Event, TicketSalesDbContext>, IEventDAL
    {
        

        public void EventStatusChangeApproved(int id)
        {
            using var context = new TicketSalesDbContext();
            var values = context.Events.Find(id);
            values.IsActive = true;
            context.SaveChanges();
        }

        public void EventStatusRemove(int id)
        {
            using var context = new TicketSalesDbContext();
            var values = context.Events.Find(id);
            context.Remove(values);
            context.SaveChanges();
        }

        public void Join(int id)
        {
            using var context = new TicketSalesDbContext();
            var values = context.Events.Find(id);
            context.Remove(values);
            context.SaveChanges();
        }
    }
}
