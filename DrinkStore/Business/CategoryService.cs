using Entity;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryService : ICategoryService
    {
        readonly ICategoryDB _ICategoryDB;

        public CategoryService(ICategoryDB IcategoryDB)
        {
            _ICategoryDB = IcategoryDB;
        }

        public async Task<IEnumerable<Category>> getCategories()
        {
            return await _ICategoryDB.getCategories();
        }
    }
}
