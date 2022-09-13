using System.ComponentModel.DataAnnotations;

namespace AspNetMVCEgitimProjesi.NetCore.Areas.Admin.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Display(Name = "Kategori Adı")]
        public string Name { get; set; }
        [Display(Name = "Durum")]
        public bool IsActive { get; set; }
    }
}
