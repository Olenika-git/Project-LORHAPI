using LORHAPI_API.Dtos.InsertionDtos;
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
                Mail    = user.Mail,
                isActive = user.IsActive,
                UserType = user.UserType,
                CreationDateTime = user.CreationDateTime,
                LastConnectionDateTime = user.LastConnectionDateTime,
                IdOrganization = user.IdOrganization
            };
        }

        public static OrganizationDto AsDto(this Organization organization) //Extension Method Organization => EnTantQueDTO
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

        public static InsertionDto AsDto(this Insertion insertion) //Extension Method Insertion => EnTantQueDTO
        {
            return new InsertionDto
            {
                IdInsertion = insertion.IdInsertion,
                Title = insertion.Title,
                Description = insertion.Description,
                AgeMin = insertion.AgeMin,
                AgeMax = insertion.AgeMax,
                Salary = insertion.Salary,
                Place = insertion.Place,
                Duration = insertion.Duration,
                StartDate = insertion.StartDate,
                EndDate = insertion.EndDate,
                RedirectionLink = insertion.RedirectionLink,
                IdOrganization = insertion.IdOrganization,
                DegreeRequired = insertion.DegreeRequired,
                DegreeObtained = insertion.DegreeObtained,
                IdSector = insertion.IdSector
            };
        }
    }
}
