using System.ComponentModel.DataAnnotations;

namespace AspNetMVCEgitimProjesi.NetCore.Areas.Admin.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Display(Name = "Kategori Adı"), StringLength(50)]
        public string Name { get; set; }
        [Display(Name = "Durum")]
        public bool IsActive { get; set; }
        public virtual List<Product>? Products { get; set; }
    }
}
