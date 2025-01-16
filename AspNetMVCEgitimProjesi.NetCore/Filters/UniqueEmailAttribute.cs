using AspNetMVCEgitimProjesi.NetCore.Models;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreMVCEgitimKonulari.Filters
{
    public class UniqueEmailAttribute : ValidationAttribute
    {
        private readonly UyeContext _context;

        public UniqueEmailAttribute(UyeContext context)
        {
            _context = context;
        }

        public UniqueEmailAttribute()
        {
            
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var email = value.ToString();
                using (var db = new UyeContext())
                {
                    var user = db.Uyeler.FirstOrDefault(x => x.Email == email);
                    if (user != null)
                    {
                        return new ValidationResult("Bu email adresi kullanılmaktadır.");
                    }
                }
            }
            return ValidationResult.Success;
        }
    }
}
