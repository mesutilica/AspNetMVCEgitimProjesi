using AspNetCore.Entities;

namespace AspNetCoreMVCWebAPIUsing.Models
{
    public class ProductDetailViewModel
    {
        public Product? Product { get; set; }
        public List<Product>? RelatedProducts { get; set; }
    }
}
