using System.ComponentModel.DataAnnotations; // Validation işlemleri için gerekli kütüphane

namespace AspNetMVCEgitimProjesi.NetCore.Models
{
    public class Uye
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ad alanı boş geçilemez!"), StringLength(50)] // Her attribute altındaki property için geçerlidir
        public string Ad { get; set; }
        [Required(ErrorMessage = "Soyad alanı boş geçilemez!"), StringLength(50)]
        public string Soyad { get; set; }
        [Required(ErrorMessage = "Email alanı boş geçilemez!"), StringLength(50)]
        [EmailAddress(ErrorMessage = "Geçersiz Email Adresi!")] // Aşağıdaki alana email adresi türünde veri girilebilsin
        public string Email { get; set; }
        [Phone(ErrorMessage = "Geçersiz Telefon Formatı!")]
        public string? Telefon { get; set; } // string? soru işareti bu alanın nullable yani boş geçilebilir olmasını sağlar
        [Required(ErrorMessage = "TC Kimlik Numarası boş geçilemez!"), StringLength(11)]
        [Display(Name = "TC Kimlik Numarası")] // Ekranda TcKimlikNo yerine TC Kimlik Numarası yazısı yazsın
        [MinLength(11, ErrorMessage = "TC Numarası 11 Karakter Olmalıdır!")]
        [MaxLength(11, ErrorMessage = "TC Numarası 11 Karakter Olmalıdır!")]
        public string TcKimlikNo { get; set; }
        [Display(Name = "Doğum Tarihi")]
        public DateTime DogumTarihi { get; set; }
        [Display(Name = "Kullanıcı Adı")]
        public string KullaniciAdi { get; set; }
        [Display(Name = "Şifre"), DataType(DataType.Password)]
        [StringLength(15, ErrorMessage = "{0} {2} Karakterden Az Olamaz!", MinimumLength = 5)]
        [Required(ErrorMessage = "{0} alanı boş geçilemez!")]
        public string Sifre { get; set; }
        [Display(Name = "Şifreyi Tekrar Giriniz"), DataType(DataType.Password)]
        [Required(ErrorMessage = "{0} alanı boş geçilemez!")]
        [Compare("Sifre")] // Sifre property si ile karşılaştır
        public string SifreTekrar { get; set; }
    }
}
