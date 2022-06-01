using LORHAPI_API.Data;
using LORHAPI_API.Dtos.InsertionDtos;
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
    public class InsertionsController : ControllerBase
    {
        private readonly Db_Context InsertionContext; //Injection de Dépendances

        private readonly IInsertionRepository repository; //ont initialise le repository

        private readonly ILogger<InsertionsController> _logger; //Injection de dépendances

        public InsertionsController(ILogger<InsertionsController> logger, Db_Context context, IInsertionRepository repository)
        {
            _logger = logger;
            InsertionContext = context;
            this.repository = repository; //on assigne le repo
        }

        // GET /Insertion
        /// <summary>
        /// Get a list of Insertion
        /// </summary>
        /// <returns>List of Insertion</returns>
        [HttpGet]
        public async Task<ActionResult<List<InsertionDto>>> GetInsertion()
        {
            List<InsertionDto> InsertionList = new();

            try
            {
                InsertionList = (await repository.GetInsertionAsync()).Select(insertion => insertion.AsDto()).ToList();

            }
            finally
            {
                _logger.LogInformation($"{DateTime.UtcNow.ToString("hh:mm:ss")}: Retrieved {InsertionList.Count}");


            }

            return await Task.FromResult(InsertionList);

        }

        // GET /Insertion/id
        /// <summary>
        /// Get a Insertion by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Insertion</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<InsertionDto>> GetInsertionByID(int id)
        {
            Insertion insertion;

            try
            {
                insertion = await repository.GetInsertionByIdAsync(id);

                if (insertion == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(insertion.AsDto());
                }
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return NotFound();
        }

        //POST /Insertion
        /// <summary>
        /// Create Insertion
        /// </summary>
        /// <param name="CreateInsertion"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<InsertionDto>> CreateInsertion(CreateInsertionDto CreateInsertion)
        {
            Insertion insertion = new();

            try
            {
                insertion = new()
                {
                    IdInsertion = CreateInsertion.GetNextID(InsertionContext),
                    Title = CreateInsertion.Title,
                    Description = CreateInsertion.Description,
                    AgeMin = CreateInsertion.AgeMin,
                    AgeMax = CreateInsertion.AgeMax,
                    Salary = CreateInsertion.Salary,
                    Place = CreateInsertion.Place,
                    Duration = CreateInsertion.Duration,
                    DateDebut = CreateInsertion.DateDebut,
                    DateFin = CreateInsertion.DateFin,
                    RedirectionLink = CreateInsertion.RedirectionLink,
                    IdOrganization = CreateInsertion.IdOrganization,
                    DiplomeRequis = CreateInsertion.DiplomeRequis,
                    DiplomeObtenu = CreateInsertion.DiplomeObtenu,
                    IdSecteur = CreateInsertion.IdSecteur,
                };
                
                if (insertion == null)
                {
                    return NotFound();
                }
                else
                {
                    await repository.CreateInsertionAsync(insertion);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return CreatedAtAction(nameof(GetInsertionByID), new { id = insertion.IdInsertion }, insertion.AsDto());
        }

        // PUT /Insertion/{id}
        /// <summary>
        /// Update Insertion
        /// </summary>
        /// <param name="id">User ID</param>
        /// <param name="UpdateInsertionDto">Insertion Entry</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateInsertion(int id, UpdateInsertionDto insertionDto)
        {
            Insertion existingInsertion = new();
            try
            {
                existingInsertion = await repository.GetInsertionByIdAsync(id);

                if (existingInsertion is null)
                {
                    return NotFound();
                }
                else
                {
                    existingInsertion.Title = insertionDto.Title;
                    existingInsertion.Description = insertionDto.Description;
                    existingInsertion.AgeMin = insertionDto.AgeMin;
                    existingInsertion.AgeMax = insertionDto.AgeMax;
                    existingInsertion.Salary = insertionDto.Salary;
                    existingInsertion.Place = insertionDto.Place;
                    existingInsertion.Duration = insertionDto.Duration;
                    existingInsertion.DateDebut = insertionDto.DateDebut;
                    existingInsertion.DateFin = insertionDto.DateFin;
                    existingInsertion.RedirectionLink = insertionDto.RedirectionLink;
                    existingInsertion.DiplomeRequis = insertionDto.DiplomeRequis;
                    existingInsertion.DiplomeObtenu = insertionDto.DiplomeObtenu;
                    existingInsertion.IdSecteur = insertionDto.IdSecteur;



                    await repository.UpdateInsertionAsync(existingInsertion);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in UpdateInsertion " + ex.Message);
            }

            return NoContent();
        }

        //Delete /Insertion/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteInsertion(int id)
        {
            try
            {
                Insertion existingInsertion = await repository.GetInsertionByIdAsync(id);

                if (existingInsertion == null)
                {
                    return NotFound();
                }
                else
                {
                    await repository.DeleteInsertionAsync(id);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in DeleteInsertion " + ex.Message);
            }

            return NoContent();
        }
    }
}
