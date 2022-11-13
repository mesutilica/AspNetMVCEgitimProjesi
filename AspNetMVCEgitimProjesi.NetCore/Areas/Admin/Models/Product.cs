using System.ComponentModel.DataAnnotations;

namespace AspNetMVCEgitimProjesi.NetCore.Areas.Admin.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Display(Name = "Ürün Adı"), StringLength(50)]
        public string Name { get; set; }
        [Display(Name = "Ürün Fiyatı")]
        public decimal Price { get; set; }
        [Display(Name = "Ürün Açıklaması")]
        public string? Description { get; set; }
        [Display(Name = "Ürün Stok")]
        public int Stock { get; set; }
        [Display(Name = "Ürün Resmi"), StringLength(50)]
        public string? Image { get; set; }
        [Display(Name = "Kategori")]
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }
    }
}
