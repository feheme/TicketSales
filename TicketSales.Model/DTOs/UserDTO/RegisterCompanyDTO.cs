using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSales.Model.Enums;

namespace TicketSales.Model.DTOs.UserDTO
{
    public class RegisterCompanyDTO
    {

      
        public string? CompanyName { get; set; }
        public string? WebSite { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }     



        public string? Password { get; set; }

        
    }
}
