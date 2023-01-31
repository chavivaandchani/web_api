using Entity;
namespace Services
{
    public interface IUserService
    {
    public    Task<User> getUsers(string Name, string password);
      public  Task<User> insertUser(User user);
     public   Task<User> updateUser(int id, User user);
    }
}


