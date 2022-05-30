using LORHAPI_API.Data;
using LORHAPI_API.Dtos;
using LORHAPI_API.Model;
using LORHAPI_API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LORHAPI_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly Db_Context UserContext;  //ont initialise le DbContext

        private readonly IUserRepository repository; //ont initialise le repository


        private readonly ILogger<UsersController> _logger; //ont initialise le Log System

        public UsersController(ILogger<UsersController> logger, Db_Context context, IUserRepository repository) // on donne en parametre un Db_Context)
        {
            _logger = logger;
            UserContext = context;  //on assigne le Db_Context
            this.repository = repository; //on assigne le repo
        }

        // GET /Users
        /// <summary>
        /// Get a list of User
        /// </summary>
        /// <returns>List of User</returns>
        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> GetUser()
        {
            List<UserDto> UserList = new();

            try
            {
                UserList = (await repository.GetUsersAsync()).Select(user => user.AsDto()).ToList();

            }
            finally
            {
                _logger.LogInformation($"{DateTime.UtcNow.ToString("hh:mm:ss")}: Retrieved {UserList.Count()}");


            }

            return await Task.FromResult(UserList);

        }

        // GET /Users/id
        /// <summary>
        /// Get a User by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>User</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUserByID(int id)
        {
            User user;

            try
            {
                user = await repository.GetUserByIdAsync(id);

                if (user == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(user.AsDto());
                }
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return NotFound();
        }

        //POST /Users
        /// <summary>
        /// Create User
        /// </summary>
        /// <param name="CreateUser"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<CreateUserDto>> CreateUser(CreateUserDto CreateUser)
        {
            User user = new();

            try
            {
                user = new()
                {
                    IdClient = CreateUser.GetNextID(UserContext),
                    Email = CreateUser.Email,
                    Password = CreateUser.Password,
                    isActive = true,
                    UserType = 0,
                    CreationDateTime = DateTime.Now,
                    OrgName = "Pôle Emploi"

                };

                if (user == null)
                {
                    return NotFound();
                }
                else
                {
                    await repository.CreateUserAsync(user);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return CreatedAtAction(nameof(GetUserByID), new { id = user.IdClient }, user.AsDto());
        }

        // PUT /items/{id}
        /// <summary>
        /// Update User
        /// </summary>
        /// <param name="id">User ID</param>
        /// <param name="userDto">User Entry</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id, UpdateUserDto userDto)
        {
            try
            {
                User existingUser = await repository.GetUserByIdAsync(id);

                if (existingUser is null)
                {
                    return NotFound();
                }
                else
                {
                    existingUser.Email = userDto.Email;
                    existingUser.Password = userDto.Password;

                    await repository.UpdateUserAsync(existingUser);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in UpdateUser " + ex.Message);
            }

            return NoContent();
        }

        //Delete /Users/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            try
            {
                User ExistingUser = await repository.GetUserByIdAsync(id);

                if (ExistingUser == null)
                {
                    return NotFound();
                }
                else
                {
                    await repository.DeleteUserAsync(id);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in DeleteUser " + ex.Message);
            }

            return NoContent();
        }
    }
}
