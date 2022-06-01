using LORHAPI_API.Dtos.OrganizationDtos;
using LORHAPI_API.Dtos.UserDtos;
using LORHAPI_API.Model;

namespace LORHAPI_API
{
    public static class Extensions
    {
        public static UserDto AsDto(this User user) //Extension Method User => EnTantQueDTO
        {
            return new UserDto
            {
                IdClient = user.IdClient,
                Email    = user.Email,
                Password = user.Password,
                isActive = user.IsActive,
                UserType = user.UserType,
                CreationDateTime = user.CreationDateTime,
                LastConnectionDateTime = user.LastConnectionDateTime,
                IdOrganization = user.IdOrganization
            };
        }

        public static OrganizationDto AsDto(this Organization organization) //Extension Method User => EnTantQueDTO
        {
            return new OrganizationDto
            {
                IdOrganization = organization.IdOrganization,
                OrgName = organization.OrgName,
                Phone = organization.Phone,
                Adress = organization.Adress,
                ZIP = organization.ZIP,
                City = organization.City,
            };
        }
    }
}
