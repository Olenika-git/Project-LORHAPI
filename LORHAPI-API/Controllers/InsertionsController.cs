using LORHAPI_API.Data;
using LORHAPI_API.Manager;
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
        public InsertionManager CurrentInsertion { get; set; }
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
            List<Insertion> InsertionList = new();

            foreach (Insertion insertion in InsertionContext.Insertions) //On utilise le DbContext
            {
                InsertionList.Add(insertion);
            }

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

        [HttpPost]
        public async Task<ActionResult<Insertion>> CreateInsertion(Insertion Insertion)
        {
            InsertionContext.Insertions.Add(Insertion);
            await InsertionContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetInsertion), new { id = Insertion.IdInsertion }, Insertion);
        }

        [HttpDelete("{id}")]
        //Envoyer cette insertion vers un autre model "IdleInsertion" devienne inactif
        public async Task<IActionResult> DeleteInsertion(int id)
        {
            Insertion Insertion = InsertionContext.Insertions.FirstOrDefault(x => x.IdInsertion == id);
            if (Insertion != null)
            {
                InsertionContext.Insertions.Remove(Insertion);
                await InsertionContext.SaveChangesAsync();
                return NoContent();
            }
            else
            {
                return NotFound(CurrentInsertion.ErrorMessageVerificationMatchId(id));
            }
        }

        //Use a create Insertion to transform it into a new insertion
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInsertion(int id, Insertion insertion)
        {
            if (!id.Equals(insertion.IdInsertion))
            {
                return BadRequest("Ids are different");
            }

            Insertion InsertionToUpdate = await InsertionContext.Insertions.FindAsync(insertion.IdInsertion);
            if (InsertionToUpdate == null)
            {
                return NotFound(CurrentInsertion.ErrorMessageVerificationMatchId(id)); ;
            }

            //Use insertion in parameters to update the actual insertion
            CurrentInsertion.PropUpdate(insertion, InsertionToUpdate);
            await InsertionContext.SaveChangesAsync();
            return NoContent();
        }
    }

}
