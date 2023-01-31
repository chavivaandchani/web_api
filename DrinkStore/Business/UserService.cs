using Entity;
using Repository;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUserDB _UserDB;
        public UserService(IUserDB UserDB)
        {
            _UserDB = UserDB;
        }

        public async Task<User> getUsers(string Name, string password)
        {
            User UserDB = await _UserDB.getUsers(Name, password);
            if (UserDB == null)
                return null;
            return UserDB;
        }

        public async Task<User> insertUser(User user)
        {
            User newUser = await _UserDB.insertUser(user);
            if (newUser == null)
                return null;
            return newUser;
        }

        public async Task<User> updateUser(int id, User User)
        {
            return await _UserDB.updateUser(id, User);
        }
    }
}
