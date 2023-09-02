using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSales.Model.DTOs.UserDTO
{
    public class RegisterUserDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Şifre en az 8 karakter içermelidir.")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$",
        ErrorMessage = "Şifre hem harf hem rakam içermelidir.")]
        public string? Password { get; set; }

        [Compare("Password", ErrorMessage = "Şifreler Uyuşmuyor")] // doğrulama işlemi
        public string? ConfirmPassword { get; set; }
      
    }
}
