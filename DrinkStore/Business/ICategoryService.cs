using Entity;

namespace Services
{
    public interface ICategoryService
    {
         public Task<IEnumerable<Category>> getCategories();
      
    }
}