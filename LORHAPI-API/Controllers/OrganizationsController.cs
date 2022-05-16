using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LORHAPI_API.Data;
using LORHAPI_API.Model;
using Microsoft.Extensions.Logging;

namespace LORHAPI_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrganizationsController : Controller
    {
        private readonly Db_Context OrganizationContext; //Injection de Dépendances
        private readonly ILogger<OrganizationsController> _logger; //INjecion de dépendances

        public OrganizationsController(ILogger<OrganizationsController> logger, Db_Context context)
        {
            _logger = logger;
            OrganizationContext = context;
        }

        // GET /Organization
        /// <summary>
        /// Get a list of Organization
        /// </summary>
        /// <returns>List of Organization</returns>
        [HttpGet]
        public ActionResult<List<Organization>> GetOrganization()
        {
            List<Organization> OrganizationList = new();

            foreach (Organization organization in OrganizationContext.Organizations) //On utilise le DbContext
            {
                OrganizationList.Add(organization);
            }

            return Ok(OrganizationList);
        }

        // GET /Organization/id
        /// <summary>
        /// Get a Organization by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Organization</returns>
        [HttpGet("{orgName}")]
        public ActionResult<List<Organization>> GetOrganizationByName(string orgName) //ActionResult sert à renvoyer plusieurs valeur selon la conditions
        {


            if (OrganizationContext.Organizations.Find(orgName) is null)
            {
                return NotFound();
            }
            else
            {
                List<Organization> OrganizationFound = OrganizationContext.Organizations.Where(organization => organization.OrgName == orgName).ToList();
                return OrganizationFound;
            }
        }
    }
}
