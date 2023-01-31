using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderDB : IOrderDB
    {
        readonly DrinksContext _DrinksContext;

        public OrderDB(DrinksContext _DrinksContext)
        {
            this._DrinksContext = _DrinksContext;
        }
        public async Task<Order> insertOrder(Order order)
        {
            await _DrinksContext.Orders.AddAsync(order);
            await _DrinksContext.SaveChangesAsync();
            return order;


        }
    }
}
