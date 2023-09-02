using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSales.Model.Entities;

namespace TicketSales.BLL.Abstract
{
    public interface IEventBLL : IBaseBLL<Event>
    {
        void EventStatusChangeApproved(int id);
        void EventStatusRemove(int id);


    }
}
