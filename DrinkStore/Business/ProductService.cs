using Entity;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService : IProductService
    {
        private readonly IProductDB _IProductDB;

        public ProductService(IProductDB IProductDB)
        {
            _IProductDB = IProductDB;
        }

         public async Task<List<Product>> getProducts(string? name, int?[] categoryIds, int? minPrice, int? maxPrice)
         {
            return await _IProductDB.getProducts(name,categoryIds,minPrice,maxPrice);
         }
        //public async Task<IEnumerable<Product>> getProducts()
       // {

        //    return await _IProductDB.getProducts();
        //}
    }
}
