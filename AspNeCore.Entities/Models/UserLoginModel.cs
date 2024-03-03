using System.ComponentModel.DataAnnotations;

namespace AspNetCore.Entities.Models
{
    public class UserLoginModel
    {
        [StringLength(50)]
        public string Email { get; set; }
        [Display(Name = "Şifre"), StringLength(50)]
        public string Password { get; set; }
    }
}
