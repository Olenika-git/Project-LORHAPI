using LORHAPI_API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LORHAPI_API.Repositories
{
    public interface IDepartmentRepository
    {
        //Notre Interface pour l'Injection de dépendances

        /// <summary>
        /// Get Department List
        /// </summary>
        /// <returns>List of Department</returns>
        Task<List<Department>> GetDepartmentAsync();

        /// <summary>
        /// Get Department
        /// </summary>
        /// <param name="id">Department ID</param>
        /// <returns>Return Department</returns>
        Task<Department> GetDepartmentByIdAsync(int id);

    }
}
