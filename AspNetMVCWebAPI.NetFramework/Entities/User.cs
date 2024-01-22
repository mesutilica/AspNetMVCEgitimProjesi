using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetMVCWebAPI.NetFramework.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Display(Name = "Kullanıcı Adı"), StringLength(50)]
        public string UserName { get; set; }
        [Display(Name = "Şifre"), StringLength(50)]
        public string Password { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [Display(Name = "Adı"), StringLength(50)]
        public string Name { get; set; }
        [Display(Name = "Soyadı"), StringLength(50)]
        public string Surname { get; set; }
        [Display(Name = "Aktif?")]
        public bool IsActive { get; set; }
        [Display(Name = "Admin?")]
        public bool IsAdmin { get; set; }
        [Display(Name = "Eklenme Tarihi"), ScaffoldColumn(false)]
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public Guid? UserGuid { get; set; } = Guid.NewGuid();
        // Jwt için propertyler
        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenExpireDate { get; set; }
    }
}
