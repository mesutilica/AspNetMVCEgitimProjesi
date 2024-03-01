using AspNetCore.Entities;

namespace AspNetCore.Service
{
    public interface ICategoryService
    {
        List<Category> GetCategories();
        void Add(Category category);
        Category GetCategory(int id);
        void Update(Category category);
        void Delete(Category category);
        int Save();
    }
}