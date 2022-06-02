using LORHAPI_ClientMobile.Services;
using LORHAPI_ModelClientMobile.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LORHAPI_ClientMobile.Repositories
{
    public class UserRepository : IUserRepository
    {
        private List<User> UserList = new List<User>();
        private readonly RestService service;

        public UserRepository(RestService context)
        {
            service = context;  //on assigne le Db_Context
            UserList = service.Users.ToList();
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
                await service.SaveTodoItemAsync(user);
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
                await service.SaveTodoItemAsync(user);
            }

            await Task.CompletedTask;
        }

        public async Task DeleteUserAsync(int id)
        {
            int UserIndex = UserList.FindIndex(ExistingUser => ExistingUser.IdClient == id);
            User user = UserList.Where(theUser => theUser.IdClient == id).SingleOrDefault();

            if (UserIndex == -1 || UserIndex == 0)
            {
                return;
            }
            else
            {
                UserList.RemoveAt(UserIndex);
                await service.DeleteTodoItemAsync(UserIndex);
                await service.SaveTodoItemAsync(user);
            }

            await Task.CompletedTask;
        }

    }
}
