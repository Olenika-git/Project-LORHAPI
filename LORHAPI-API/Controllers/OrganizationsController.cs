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
using LORHAPI_API.Dtos.OrganizationDtos;
using LORHAPI_API.Repositories;

namespace LORHAPI_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrganizationsController : ControllerBase
    {
        private readonly Db_Context OrganizationContext; //Injection de Dépendances
        
        private readonly IOrganizationRepository repository; //ont initialise le repository
        
        private readonly ILogger<OrganizationsController> _logger; //Injection de dépendances

        public OrganizationsController(ILogger<OrganizationsController> logger, Db_Context context, IOrganizationRepository repository)
        {
            _logger = logger;
            OrganizationContext = context;
            this.repository = repository; //on assigne le repo
        }

        // GET /Organization
        /// <summary>
        /// Get a list of Organization
        /// </summary>
        /// <returns>List of Organization</returns>
        [HttpGet]
        public async Task<ActionResult<List<OrganizationDto>>> GetOrganization()
        {
            List<OrganizationDto> OrganizationList = new();

            try
            {
                OrganizationList = (await repository.GetOrganizationAsync()).Select(organization => organization.AsDto()).ToList();

            }
            finally
            {
                _logger.LogInformation($"{DateTime.UtcNow.ToString("hh:mm:ss")}: Retrieved {OrganizationList.Count}");


            }

            return await Task.FromResult(OrganizationList);

        }

        // GET /Organization/id
        /// <summary>
        /// Get a Organization by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Organization</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<OrganizationDto>> GetOrganizationByID(int id)
        {
            Organization organization;

            try
            {
                organization = await repository.GetOrganizationByIdAsync(id);

                if (organization == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(organization.AsDto());
                }
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return NotFound();
        }

        //POST /Organization
        /// <summary>
        /// Create Organization
        /// </summary>
        /// <param name="CreateOrganization"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<CreateOrganizationDto>> CreateOrganization(CreateOrganizationDto CreateOrganization)
        {
            Organization organization = new();

            try
            {
                organization = new()
                {
                    IdOrganization = CreateOrganization.GetNextID(OrganizationContext),
                    OrgName = CreateOrganization.OrgName,
                    Phone = CreateOrganization.Phone,
                    Adress = CreateOrganization.Adress,
                    ZIP = CreateOrganization.ZIP,
                    City = CreateOrganization.City,
                };

                if (organization == null)
                {
                    return NotFound();
                }
                else
                {
                    await repository.CreateOrganizationAsync(organization);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return CreatedAtAction(nameof(GetOrganizationByID), new { id = organization.IdOrganization }, organization.AsDto());
        }
        
        // PUT /Organization/{id}
        /// <summary>
        /// Update Organization
        /// </summary>
        /// <param name="id">User ID</param>
        /// <param name="UpdateOrganizationDto">Organization Entry</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOrganization(int id, UpdateOrganizationDto organizationDto)
        {
            Organization organization = new();
            try
            {
                Organization existingOrganization = await repository.GetOrganizationByIdAsync(id);

                if (existingOrganization is null)
                {
                    return NotFound();
                }
                else
                {
                    existingOrganization.Phone = organizationDto.Phone;
                    existingOrganization.Adress = organizationDto.Adress;
                    existingOrganization.ZIP = organizationDto.ZIP;
                    existingOrganization.City = organizationDto.City;

                    await repository.UpdateOrganizationAsync(existingOrganization);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in UpdateOrganization " + ex.Message);
            }

            return NoContent();
        }

        //Delete /Organization/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            try
            {
                Organization existingOrganization = await repository.GetOrganizationByIdAsync(id);

                if (existingOrganization == null)
                {
                    return NotFound();
                }
                else
                {
                    await repository.DeleteOrganizationAsync(id);
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
