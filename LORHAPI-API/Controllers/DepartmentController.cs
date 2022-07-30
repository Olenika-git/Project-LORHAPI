using LORHAPI_API.Data;
using LORHAPI_API.Dtos.DepartmentDtos;
using LORHAPI_API.Entities;
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
    public class DepartmentController : Controller
    {
        private readonly Db_Context DepartmentContext;  //ont initialise le DbContext

        private readonly IDepartmentRepository repository; //ont initialise le repository


        private readonly ILogger<DepartmentController> _logger; //ont initialise le Log System

        // GET /Department
        /// <summary>
        /// Get a list of Department
        /// </summary>
        /// <returns>List of Department</returns>
        [HttpGet]
        public async Task<ActionResult<List<DepartmentDto>>> GetDepartment()
        {
            List<DepartmentDto> DepartmentList = new();
            
            try
            {
                DepartmentList = (await repository.GetDepartmentAsync()).Select(department => department.AsDto()).ToList();

                _logger.LogInformation($"{DateTime.UtcNow.ToString("hh:mm:ss")}: Retrieved {DepartmentList.Count()}");


                return await Task.FromResult(DepartmentList);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while getting Department: {ex.Message}");

                return StatusCode(500, $"Error while getting Department: {ex.Message}");
            }
        }

        // GET /Department/id
        /// <summary>
        /// Get a Department by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Department</returns>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<DepartmentDto>> GetDepartmentByID(int id)
        {
            Department department;

            try
            {
                department = await repository.GetDepartmentByIdAsync(id);

                if (department == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(department.AsDto());
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while getting DepartmentID: {ex.Message}");

                return StatusCode(500, $"Error while getting DepartmentID: {ex.Message}");
            }
        }
    }
}
