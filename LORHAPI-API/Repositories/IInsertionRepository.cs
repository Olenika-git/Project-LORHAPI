using LORHAPI_API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LORHAPI_API.Repositories
{
    public interface IInsertionRepository
    {
        //Notre Interface pour l'Injection de dépendances

        /// <summary>
        /// Get Insertion List
        /// </summary>
        /// <returns>List of Insertion</returns>
        Task<List<Insertion>> GetInsertionAsync();

        /// <summary>
        /// Get Insertion by ID
        /// </summary>
        /// <param name="id">Insertion ID</param>
        /// <returns>Return Insertion</returns>
        Task<Insertion> GetInsertionByIdAsync(int id);

        /// <summary>
        /// Create Insertion
        /// </summary>
        /// <param name="insertion"></param>
        /// <returns></returns>
        Task CreateInsertionAsync(Insertion insertion);

        /// <summary>
        /// Update Insertion
        /// </summary>
        /// <param name="insertion">Insertion to update</param>
        /// <returns></returns>
        Task UpdateInsertionAsync(Insertion insertion);

        /// <summary>
        /// Delete Insertion
        /// </summary>
        /// <param name="id">Insertion ID</param>
        /// <returns></returns>
        Task DeleteInsertionAsync(int id);
    }
}
