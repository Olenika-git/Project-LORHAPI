using LORHAPI_API.Data;
using LORHAPI_API.Model;
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


        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger, Db_Context context) // on donne en parametre un Db_Context)
        {
            _logger = logger;
            UserContext = context;  //on assigne le Db_Context
        }

        // GET /Users
        /// <summary>
        /// Get a list of User
        /// </summary>
        /// <returns>List of User</returns>
        [HttpGet]
        public List<User> GetUser()
        {
            List<User> UserList = new();

            foreach (User user in UserContext.Users) //On utilise le DbContext
            {
                UserList.Add(user);
            }

            return UserList;
        }

        // GET /Users/id
        /// <summary>
        /// Get a User by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>User</returns>
        [HttpGet ("{id}")]
        public ActionResult<List<User>> GetUserByID(int id)
        {
                

                if(UserContext.Users.Find(id) is null)
                {
                    return NotFound();
                }
                else
                {
                    List<User> user = UserContext.Users.Where(user => user.IdClient == id).ToList();
                    return user;
                }
        }

        //[HttpPost]
        //public ActionResult<User> CreateUser()
        //{
        //    return;
        //}
    }
}
