using Entity;

namespace Services
{
    public interface IProductService 
    {
     public   Task<List<Product>> getProducts(string? name, int?[] categoryIds, int? minPrice, int? maxPrice);
    }
}