using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCore.Entities
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Ürün Adı"), StringLength(50), Required(ErrorMessage = "Ürün Adı Boş Geçilemez!")]
        public string Name { get; set; }
        [Display(Name = "Ürün Fiyatı")]
        public decimal Price { get; set; }
        [Display(Name = "Ürün Stok")]
        public int Stock { get; set; }
        [Display(Name = "Ürün Açıklama"), DataType(DataType.MultilineText)] // Description inputunun textbox yerine textarea olması için
        public string? Description { get; set; }
        [Column("Image", TypeName = "Varchar")]
        [Display(Name = "Ürün Resmi"), MaxLength(50)]
        public string? Image { get; set; }
        //[Display(Name = "Durum")]
        //public bool IsActive { get; set; }
        //[Display(Name = "Anasayfada Göster")]
        //public bool IsHome { get; set; }
        [Display(Name = "Eklenme Tarihi"), ScaffoldColumn(false)]
        public DateTime? CreateDate { get; set; } = DateTime.Now;
        [Display(Name = "Ürün Kategorisi"), Required(ErrorMessage = "Ürün Kategorisi Boş Geçilemez!")]
        public int CategoryId { get; set; }
        [Display(Name = "Ürün Kategorisi")]
        public virtual Category? Category { get; set; }
        [Display(Name = "Ürün Markası"), Required(ErrorMessage = "Ürün Markası Boş Geçilemez!")]
        public int BrandId { get; set; }
        [Display(Name = "Ürün Markası")]
        public virtual Brand? Brand { get; set; }
    }
}
