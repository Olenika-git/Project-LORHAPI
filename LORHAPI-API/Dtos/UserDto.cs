using System;

namespace LORHAPI_API.Dtos
{
   public record UserDto
    {
        public int IdClient { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public bool isActive { get; set; }
        public int UserType { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime LastConnectionDateTime { get; set; }
        public string OrgName { get; set; }
    }
}
