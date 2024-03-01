using System.ComponentModel.DataAnnotations;

namespace AspNetCore.Entities
{
    public class Slider : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Kategori Resmi"), StringLength(50)]
        public string? Image { get; set; }
    }
}
