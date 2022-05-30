using LORHAPI_API.Dtos;
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
                isActive = user.isActive,
                UserType = user.UserType,
                CreationDateTime = user.CreationDateTime,
                LastConnectionDateTime = user.LastConnectionDateTime,
                OrgName = user.OrgName
            };
        }
    }
}
