using AspNetCore.Data;
using AspNetCore.Entities;

namespace AspNetCore.Service
{
    public class CategoryService : ICategoryService
    {
        // iş katmanından data ve entities e erişmek için references a sağ tıklayıp add reference diyerek açılan pencereden data ve entities katmanlarına tik atıp ok diyerek erişim veriyoruz yoksa kullanamayız diğer katmandakileri!
        private readonly DatabaseContext _context;

        public CategoryService(DatabaseContext context)
        {
            _context = context;
        }

        public void Add(Category category)
        {
            _context.Categories.Add(category);
        }

        public void Delete(Category category)
        {
            _context.Categories.Remove(category);
        }

        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.Find(id);
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
        }
    }
}
