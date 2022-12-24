using System.ComponentModel.DataAnnotations;

namespace AspNetCoreWebAPI.Entities
{
    public class Brand
    {
        public int Id { get; set; }
        [Display(Name = "Marka Adı"), Required(ErrorMessage = "Marka Adı Boş Geçilemez!")]
        public string Name { get; set; }
        [Display(Name = "Marka Açıklama"), DataType(DataType.MultilineText)]
        public string? Description { get; set; }
        [Display(Name = "Marka Logosu")]
        public string? Logo { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public Brand()
        {
            Products = new List<Product>();
        }
    }
}
