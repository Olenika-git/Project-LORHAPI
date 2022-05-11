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
        private readonly Db_Context OrganizationContext;
        private readonly ILogger<OrganizationsController> _logger;

        public OrganizationsController(ILogger<OrganizationsController> logger, Db_Context context)
        {
            _logger = logger;
            OrganizationContext = context;
        }

        // GET /Users
        /// <summary>
        /// Get a list of User
        /// </summary>
        /// <returns>List of User</returns>
        [HttpGet]
        public List<Organization> GetInsertion()
        {
            List<Organization> OrganizationList = new();

            foreach (Organization organization in OrganizationContext.Organizations) //On utilise le DbContext
            {
                OrganizationList.Add(organization);
            }

            return OrganizationList;
        }
    }
}
