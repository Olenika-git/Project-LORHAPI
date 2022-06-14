using System;

namespace LORHAPI_API.Dtos.UserDtos
{
    public record UserDto
    {
        public int IdClient { get; set; }

        public string Mail { get; set; }

        public bool isActive { get; set; }

        public UserTypes UserType { get; set; }

        public DateTime CreationDateTime { get; set; }

        public DateTime LastConnectionDateTime { get; set; }

        public int IdOrganization { get; set; }
    }
}
