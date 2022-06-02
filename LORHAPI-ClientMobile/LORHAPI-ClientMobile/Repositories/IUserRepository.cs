using LORHAPI_ModelClientMobile.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LORHAPI_ClientMobile.Repositories
{
    public interface IUserRepository
    {
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
    }
}
