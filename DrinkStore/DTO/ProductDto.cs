using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } ///
        public string Color { get; set; } = null!;
        public int Price { get; set; }
        public string ImageUrl { get; set; } = null!;
    }
}
