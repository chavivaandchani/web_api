using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CategoryDB : ICategoryDB
    {
        readonly DrinksContext _DrinksContext;
        public CategoryDB(DrinksContext _DrinksContext)
        {

            this._DrinksContext = _DrinksContext;
        }

        public async Task<IEnumerable<Category>> getCategories()
        {
            // IEnumerable<Category> Category = await _DrinksContext.Categories.ToArrayAsync();
            var categoryQuery = await (from category in _DrinksContext.Categories
                                       select category).ToListAsync<Category>();
            return categoryQuery;
            // return Category;

        }
    }
}
