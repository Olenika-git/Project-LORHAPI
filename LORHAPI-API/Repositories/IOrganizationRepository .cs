using LORHAPI_API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LORHAPI_API.Repositories
{
    public interface IOrganizationRepository
    {
        //Notre Interface pour l'Injection de dépendances

        /// <summary>
        /// Get Organization List
        /// </summary>
        /// <returns>List of Organization</returns>
        Task<List<Organization>> GetOrganizationAsync();

        /// <summary>
        /// Get Organization by ID
        /// </summary>
        /// <param name="id">Organization ID</param>
        /// <returns>Return Organization</returns>
        Task<Organization> GetOrganizationByIdAsync(int id);

        /// <summary>
        /// Create Organization
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        Task CreateOrganizationAsync(Organization organization);

        /// <summary>
        /// Update Organization
        /// </summary>
        /// <param name="organization">Organization to update</param>
        /// <returns></returns>
        Task UpdateOrganizationAsync(Organization organization);

        /// <summary>
        /// Delete Organization
        /// </summary>
        /// <param name="id">Organization ID</param>
        /// <returns></returns>
        Task DeleteOrganizationAsync(int id);
    }
}
