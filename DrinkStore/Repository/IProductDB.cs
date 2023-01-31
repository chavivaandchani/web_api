using Entity;

namespace Repository
{
    public interface IProductDB
    {
        Task<List<Product>> getProducts(string? name, int?[] categoryIds, int? minPrice, int? maxPrice);
       
    }
}