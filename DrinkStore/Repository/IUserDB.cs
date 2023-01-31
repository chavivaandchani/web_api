using Entity;

namespace Repository
{
    public interface IUserDB
    {
        Task<User> getUsers(string userName, string password);
        Task<User> insertUser(User user);
        Task<User> updateUser(int id, User user);
    }
}