using System.ComponentModel.DataAnnotations;

namespace AspNetCoreMVCEgitimKonulari.Dtos
{
    public class UyeListDto
    {
        [Required(ErrorMessage = "Ad alanı boş geçilemez!"), StringLength(50)] // Her attribute altındaki property için geçerlidir
        public string Ad { get; set; }
        [Required(ErrorMessage = "{0} alanı boş geçilemez!"), StringLength(50)]
        public string Soyad { get; set; }
        [EmailAddress(ErrorMessage = "Geçersiz Email Adresi!"), StringLength(50)] // Aşağıdaki alana email adresi türünde veri girilebilsin
        public string? Email { get; set; }
        [Phone(ErrorMessage = "Geçersiz Telefon Formatı!")]
        public string? Telefon { get; set; } // string? soru işareti bu alanın nullable yani boş geçilebilir olmasını sağlar
        [Display(Name = "TC Kimlik Numarası"), StringLength(11)] // Ekranda TcKimlikNo yerine TC Kimlik Numarası yazısı yazsın
        [MinLength(11, ErrorMessage = "{0} 11 Karakter Olmalıdır!")]
        [MaxLength(11, ErrorMessage = "{0} 11 Karakter Olmalıdır!")]
        public string? TcKimlikNo { get; set; }
        [Display(Name = "Doğum Tarihi")]
        public DateTime? DogumTarihi { get; set; }
    }
}
