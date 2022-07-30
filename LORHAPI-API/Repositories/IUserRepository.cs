using LORHAPI_API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LORHAPI_API.Repositories
{
    public interface IUserRepository
    {
        //Notre Interface pour l'Injection de dépendances

        /// <summary>
        /// Get Users List
        /// </summary>
        /// <returns>List of User</returns>
        Task<List<User>> GetUsersAsync();

        /// <summary>
        /// Get User
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>Return User</returns>
        Task<User> GetUserByIdAsync(int id);

        /// <summary>
        /// Create User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task CreateUserAsync(User user);

        /// <summary>
        /// Update User
        /// </summary>
        /// <param name="user">User to update</param>
        /// <returns></returns>
        Task UpdateUserAsync(User user);

        /// <summary>
        /// Delete User
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns></returns>
        Task DeleteUserAsync(int id);

        Task UpdateDate(User user);
    }
}
