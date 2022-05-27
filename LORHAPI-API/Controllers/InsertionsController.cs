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
    public class InsertionsController : ControllerBase
    {
        private readonly Db_Context InsertionContext;  //ont initialise le DbContext


        private readonly ILogger<InsertionsController> _logger;

        public InsertionsController(ILogger<InsertionsController> logger, Db_Context context) // on donne en parametre un Db_Context)
        {
            _logger = logger;
            InsertionContext = context;  //on assigne le Db_Context
        }

        // GET /Users
        /// <summary>
        /// Get a list of User
        /// </summary>
        /// <returns>List of User</returns>
        [HttpGet]
        public List<Insertion> GetInsertion()
        {
            List<Insertion> InsertionList = InsertionContext.Insertions.ToList();

            //foreach (Insertion insertion in InsertionContext.Insertions) //On utilise le DbContext
            //{
            //    InsertionList.Add(insertion);
            //}

            return InsertionList;
        }

        // GET /Users/id
        /// <summary>
        /// Get a User by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>User</returns>
        [HttpGet("{id}")]
        public ActionResult<List<Insertion>> GetInsertionByID(int id)
        {


            if (InsertionContext.Users.Find(id) is null)
            {
                return NotFound();
            }
            else
            {
                List<Insertion> InsertionFound = InsertionContext.Insertions.Where(insertion => insertion.IdInsertion == id).ToList();
                return InsertionFound;
            }
        }

        //[HttpPost]
        //public ActionResult<User> CreateUser()
        //{
        //    return;
        //}
    }
}
