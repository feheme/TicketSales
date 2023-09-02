using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSales.Core.Entity;

namespace TicketSales.Model.Entities
{
    public class City : BaseEntity
    {
        public City()
        {
            IsActive = true;
        }

        public string CityName { get; set; }
        public ICollection<Event> Events { get; set; }

    }
}
