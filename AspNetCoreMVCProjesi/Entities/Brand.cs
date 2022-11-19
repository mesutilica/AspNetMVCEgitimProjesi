using System.ComponentModel.DataAnnotations;

namespace AspNetCoreMVCProjesi.Entities
{
    public class Brand
    {
        public int Id { get; set; }
        [Display(Name = "Marka Adı"), StringLength(50), Required(ErrorMessage = "Marka Adı Boş Geçilemez!")]
        public string Name { get; set; }
        [Display(Name = "Marka Açıklama"), DataType(DataType.MultilineText)]
        public string? Description { get; set; }
        [Display(Name = "Marka Logosu"), StringLength(50)]
        public string? Logo { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public Brand()
        {
            Products = new List<Product>();
        }
    }
}
