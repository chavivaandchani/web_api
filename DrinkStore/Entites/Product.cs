using System;
using System.Collections.Generic;

namespace Entity
{
    public partial class Product
    {
        public Product()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int CategoryId { get; set; }
        public string Color { get; set; } = null!;
        public int Price { get; set; }
        public string ImageUrl { get; set; } = null!;

        public Category Category { get; set; } = null!;
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
