using System.ComponentModel.DataAnnotations;

namespace AspNetCore.Entities
{
    public class Contact : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Adınız"), Required(ErrorMessage = "{0} Boş Geçilemez!"), StringLength(50)]
        public string Name { get; set; }
        [Display(Name = "Soyadınız"), Required(ErrorMessage = "{0} Boş Geçilemez!"), StringLength(50)]
        public string Surname { get; set; }
        [StringLength(50), EmailAddress]
        public string? Email { get; set; }
        [Display(Name = "Telefon"), StringLength(50)]
        public string? Phone { get; set; }
        [Display(Name = "Mesaj"), Required(ErrorMessage = "{0} Boş Geçilemez!"), DataType(DataType.MultilineText)]
        public string Message { get; set; }
        [Display(Name = "Eklenme Tarihi"), ScaffoldColumn(false)]
        public DateTime? CreateDate { get; set; } = DateTime.Now;
    }
}
