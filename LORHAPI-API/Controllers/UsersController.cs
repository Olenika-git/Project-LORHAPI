using LORHAPI_API.Data;
using LORHAPI_API.Dtos.UserDtos;
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
                
                _logger.LogInformation($"{DateTime.UtcNow.ToString("hh:mm:ss")}: Retrieved {UserList.Count()}");
                

                return await Task.FromResult(UserList);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while getting User: {ex.Message}");
                
                return StatusCode(500, $"Error while getting User: {ex.Message}");
            }
        }

        // GET /Users/id
        /// <summary>
        /// Get a User by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>User</returns>
        [HttpGet("{id:int}")]
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
            catch (Exception ex)
            {
                _logger.LogError($"Error while getting UserID: {ex.Message}");

                return StatusCode(500, $"Error while getting UserID: {ex.Message}");
            }
        }

        //POST /Users
        /// <summary>
        /// Create User
        /// </summary>
        /// <param name="CreateUser"></param>
        /// <returns></returns>
        [HttpPost("CreateUser")]
        public async Task<ActionResult<CreateUserDto>> CreateUser(CreateUserDto CreateUser)
        {
            User user = new();
            
            try
            {
                User CheckEmailFirst = UserContext.Users.Where(u => u.Mail == CreateUser.Mail).FirstOrDefault();


                user = new()
                {
                    Mail = CreateUser.Mail,
                    Password = BCrypt.Net.BCrypt.HashPassword(CreateUser.Password),
                    IsActive = true,
                    UserType = UserTypes.User,
                    CreationDateTime = DateTime.Now,
                    IdOrganization = CreateUser.IdOrganization

                };

                
                if (user == null)
                {
                    return NotFound();
                }
                if (CheckEmailFirst != null)
                {
                    ModelState.AddModelError("Mail", "Sorry, this email is already used");
                    return BadRequest(ModelState);
                }
                if (user.IdOrganization == 0)
                {
                    ModelState.AddModelError("IdOrganization", "Invalid Organization");
                    return BadRequest(ModelState);
                }
                
                await repository.CreateUserAsync(user);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while creating User: {ex.Message}");

                return StatusCode(500, $"Error while creating User: {ex.Message}");
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
        [HttpPut("{id:int}")]
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
                    existingUser.Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password);

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
        [HttpDelete("{id:int}")]
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

        //Login /Users/Login
        [HttpPost("Login")]
        public async Task<ActionResult> LoginUser(LoginUserDto loginUser)
        {
            try
            {
                User ExistingUser = UserContext.Users.Where(u => u.Mail == loginUser.Mail).FirstOrDefault();

                if (ExistingUser == null)
                {
                    return NotFound();
                }
                else
                {
                    if (BCrypt.Net.BCrypt.Verify(loginUser.Password, ExistingUser.Password))
                    {
                        await repository.UpdateDate(ExistingUser);

                        return Ok(ExistingUser.AsDto());
                    }
                    else
                    {
                        return Unauthorized();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in LoginUser " + ex.Message);
            }

            return NoContent();
        }
    }
}
