using LORHAPI_API.Data;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace LORHAPI_API.Dtos.OrganizationDtos
{
    public record CreateOrganizationDto
    {
        [Required]        
        public string OrgName { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Adress { get; set; }

        [Required]
        public string ZIP { get; set; }

        [Required]
        public string City { get; set; }

        /// <summary>
        /// Return the Last ID of user used in the Database
        /// </summary>
        /// <returns>ID</returns>
        public int GetNextID(Db_Context context)
        {
            return context.Organizations.Max(x => x.IdOrganization) + 1;
        }

    }
}
