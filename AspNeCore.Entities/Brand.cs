using System.ComponentModel.DataAnnotations;

namespace AspNetCore.Entities
{
    public class Brand : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Marka Adı"), Required(ErrorMessage = "Marka Adı Boş Geçilemez!")]
        public string Name { get; set; }
        [Display(Name = "Marka Açıklama"), DataType(DataType.MultilineText)]
        public string? Description { get; set; }
        [Display(Name = "Marka Logosu")]
        public string? Logo { get; set; }
        public virtual List<Product>? Products { get; set; }
    }
}
