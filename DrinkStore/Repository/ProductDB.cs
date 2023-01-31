using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductDB : IProductDB
    {
        readonly DrinksContext _DrinksContext;
        public ProductDB(DrinksContext DrinksContext)
        {
            this._DrinksContext = DrinksContext;
        }

        public async Task<List<Product>> getProducts(string? name, int?[] categoryIds, int? minPrice, int? maxPrice)
        {
            var query = _DrinksContext.Products.Where(product =>
           (name == null ? (true) : (product.Description.Contains(name)))
           && ((minPrice == null) ? (true) : (product.Price >= minPrice))
             && ((maxPrice == null) ? (true) : (product.Price <= maxPrice))
&& ((categoryIds.Length == 0) ? (true) : (categoryIds.Contains(product.CategoryId))))
.OrderBy(product => product.Price);
            List<Product> products = await query.ToListAsync();


            return products;
        }
    }
}
