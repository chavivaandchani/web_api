using Entity;

namespace Services
{
    public interface IOrderServise
    {
        public Task<Order> insertUser(Order order);
    }
}