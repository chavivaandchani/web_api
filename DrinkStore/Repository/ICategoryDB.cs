using Entity;

namespace Repository
{
    public interface ICategoryDB
    {
        Task<IEnumerable<Category>> getCategories();
    }
}