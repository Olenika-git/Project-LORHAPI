using LORHAPI_API.Data;
using LORHAPI_API.Model;
using System;
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
            UserList = _dbcontext.Users.ToList();
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await Task.FromResult(UserList);
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            User user = UserList.Where(theUser => theUser.IdClient == id).SingleOrDefault();
            return await Task.FromResult(user);
        }
        
        public async Task CreateUserAsync(User user)
        {
            if (user == null)
            {
                return;
            }
            else
            {
                UserList.Add(user);
                _dbcontext.Add(user);
                await _dbcontext.SaveChangesAsync();
            }

            
            await Task.CompletedTask;
        }

        public async Task UpdateUserAsync(User user)
        {
            int UserIndex = UserList.FindIndex(ExistingUser => ExistingUser.IdClient == user.IdClient);
            
            if (UserIndex == -1)
            {
                return;
            }
            else
            {
                UserList[UserIndex] = user;
                _dbcontext.Update(user);
                await _dbcontext.SaveChangesAsync();
            }
            
            await Task.CompletedTask;
        }
        
        public async Task DeleteUserAsync(int id)
        {
            int UserIndex = UserList.FindIndex(ExistingUser => ExistingUser.IdClient == id);
            User user = UserList.Where(theUser => theUser.IdClient == id).SingleOrDefault();

            if (UserIndex == -1)
            {
                return;
            }
            else
            {
                UserList.RemoveAt(UserIndex);
                _dbcontext.Remove(user);
                await _dbcontext.SaveChangesAsync();
            }
            
            await Task.CompletedTask;
        }

        public async Task UpdateDate(User user)
        {
            int UserIndex = UserList.FindIndex(ExistingUser => ExistingUser.IdClient == user.IdClient);

            if (UserIndex == -1)
            {
                return;
            }
            else
            {
                user.LastConnectionDateTime = DateTime.Now;
                UserList[UserIndex] = user;
                _dbcontext.Update(user);
                await _dbcontext.SaveChangesAsync();
            }

            await Task.CompletedTask;
        }

    }
}
