using Entity;

namespace Repository
{
    public interface IOrderDB
    {
        Task<Order> insertOrder(Order order);
    }
}