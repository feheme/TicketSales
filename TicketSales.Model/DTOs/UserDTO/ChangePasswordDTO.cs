using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSales.Model.DTOs.UserDTO
{
    public class ChangePasswordDTO
    {
        [Required]
        public string OldPassword { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Şifre en az 8 karakter içermelidir.")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$", ErrorMessage = "Şifre hem harf hem rakam içermelidir.")]       

        public string NewPassword { get; set; }

        [Compare("NewPassword", ErrorMessage = "Yeni Şifre Uyuşmuyor.")]
        public string ConfirmPassword { get; set; }
    }
}
