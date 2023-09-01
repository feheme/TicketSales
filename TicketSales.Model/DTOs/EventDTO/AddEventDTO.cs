using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSales.Model.DTOs.EventDTO
{
    public class AddEventDTO
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public DateTime ApplicationDeadline { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public int Capacity { get; set; }
        public bool IsPaid { get; set; }
        public decimal? TicketPrice { get; set; }
        public int CategoryId { get; set; }
        public int CityId { get; set; }
        public bool IsApproved { get; set; }
        public int OrganizerId { get; set; }
    }
}
