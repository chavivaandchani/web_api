using Entity;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class UserDB : IUserDB
    {
        readonly DrinksContext _DrinksContext;
        public UserDB(DrinksContext DrinksContext)
        {
            this._DrinksContext = DrinksContext;
        }

        public async Task<User> getUsers(string Name, string password)
        {
            User user = await _DrinksContext.Users.Where(u => u.Name == Name && u.Password == password).FirstAsync();
            return user;

        }

        public async Task<User> insertUser(User User)
        {
            await _DrinksContext.Users.AddAsync(User);
            await _DrinksContext.SaveChangesAsync();
            return await this.getUsers(User.FirstName, User.Password);

        }

        public async Task<User> updateUser (int id, User User)
        {
            var userToUpdate = await _DrinksContext.Users.FindAsync(id);
            if (userToUpdate == null)
            {
                return null;
            }

           
           _DrinksContext.Entry(userToUpdate).CurrentValues.SetValues(User);
            await _DrinksContext.SaveChangesAsync();
            return User;

        }

    }
}