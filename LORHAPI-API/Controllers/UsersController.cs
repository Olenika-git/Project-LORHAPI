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
        [HttpGet ("{id}")]
        public async Task<ActionResult<UserDto>> GetUserByID(int id)
        {

            User user = await repository.GetUserByIdAsync(id);

            return user.AsDto();
        }

        //[HttpPost]
        //public ActionResult<User> CreateUser()
        //{
        //    return;
        //}

    }
}
