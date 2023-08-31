using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSales.Core.Entity;

namespace TicketSales.Model.Entities
{
    public class Category : BaseEntity
    {
        public Category()
        {
            IsActive = true;
        }

        public string? CategoryName { get; set; }
    }
}
