using Entity;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderServise : IOrderServise
    {
        private readonly IOrderDB _IOrderDB;
        public OrderServise(IOrderDB IOrderDB)
        {
            IOrderDB = IOrderDB;
        }



        public async Task<Order> insertUser(Order order)
        {
            Order newOrder = await _IOrderDB.insertOrder(order);
            if (newOrder == null)
                return null;
            return newOrder;
        }

        public static Task<Order> insertOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
