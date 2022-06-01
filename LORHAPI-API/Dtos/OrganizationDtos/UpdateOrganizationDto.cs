using LORHAPI_API.Data;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace LORHAPI_API.Dtos.OrganizationDtos
{
    public record UpdateOrganizationDto
    {
        public string Phone { get; set; }

        public string Adress { get; set; }

        public string ZIP { get; set; }

        public string City { get; set; }
    }
}
