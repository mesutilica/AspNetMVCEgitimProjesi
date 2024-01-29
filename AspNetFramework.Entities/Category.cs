using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AspNetFramework.Entities
{
    public class Category
    {
        public int Id { get; set; }
        [Display(Name = "Kategori Adı"), StringLength(50), Required(ErrorMessage = "Kategori Adı Boş Geçilemez!")]
        public string Name { get; set; }
        [Display(Name = "Kategori Açıklama"), DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Display(Name = "Kategori Resmi"), StringLength(50), DataType(DataType.Upload)]
        public string Image { get; set; }
        [Display(Name = "Eklenme Tarihi"), ScaffoldColumn(false)] // ScaffoldColumn(false) : sayfa oluştururken bu kolon oluşmasın
        public DateTime CreateDate { get; set; } = DateTime.Now;
        [Display(Name = "Durum")]
        public bool IsActive { get; set; }
        //public virtual IEnumerable<Product> Products { get; set; } // web api kullanımında navigation property tavsiye edilmiyor
    }
}
