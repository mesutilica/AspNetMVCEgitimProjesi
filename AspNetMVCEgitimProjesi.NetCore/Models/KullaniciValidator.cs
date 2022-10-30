using FluentValidation;

namespace AspNetMVCEgitimProjesi.NetCore.Models
{
    public class KullaniciValidator : AbstractValidator<Kullanici>
    {
        public KullaniciValidator()
        {
            RuleFor(x => x.Ad).NotNull();
            RuleFor(x => x.Soyad).NotEmpty().WithMessage("Soyadı Boş Geçilemez!");
            RuleFor(x => x.Email).EmailAddress().NotNull().WithMessage("Email Boş Geçilemez!");
            RuleFor(x => x.KullaniciAdi).NotEmpty();
            RuleFor(x => x.Sifre).NotNull().WithMessage("Şifre Boş Geçilemez!").Length(0, 20);
        }
    }
}
