using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSales.Model.Entities;

namespace TicketSales.BLL.Abstract
{
    public interface IUserBLL : IBaseBLL<User>
    {
        User GetUserByLoginData(string mail, string password);
     

    }
}
