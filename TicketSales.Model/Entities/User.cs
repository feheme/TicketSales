using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSales.Core.Entity;
using TicketSales.Model.Enums;

namespace TicketSales.Model.Entities
{
    public class User : BaseEntity
    {
        public User()
        {
            IsActive = false;
        }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public UserRole? Role { get; set; }

        public int IdEvent { get; set; }

        public Event? Event { get; set; }









    }
}
