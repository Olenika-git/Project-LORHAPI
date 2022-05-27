using LORHAPI_API.Data;
using LORHAPI_API.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LORHAPI_API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private List<User> UserList = new();
        private readonly Db_Context _dbcontext;

        public UserRepository(Db_Context context)
        {
            _dbcontext = context;  //on assigne le Db_Context
        }

        public async Task<List<User>> GetUsersAsync()
        {
            UserList = _dbcontext.Users.ToList();

            return await Task.FromResult(UserList);
        }
        public async Task<User> GetUserByIdAsync(int id)
        {
            User user = UserList.Where(theUser => theUser.IdClient == id).SingleOrDefault();
            return await Task.FromResult(user);
        }
        public async Task CreateUserAsync(User user)
        {
            UserList.Add(user);
            await Task.CompletedTask;
        }
        public async Task UpdateUserAsync(User user)
        {
            int index = UserList.FindIndex(ExistingUser => ExistingUser.IdClient == user.IdClient);
            UserList[index] = user;
            await Task.CompletedTask;
        }
        public async Task DeleteUserAsync(int id)
        {
            int index = UserList.FindIndex(ExistingUser => ExistingUser.IdClient ==id);
            UserList.RemoveAt(index);
            await Task.CompletedTask;
        }

    }
}
