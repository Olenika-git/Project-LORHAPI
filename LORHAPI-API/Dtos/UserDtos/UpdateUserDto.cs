using LORHAPI_API.Data;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace LORHAPI_API.Dtos.UserDtos
{
    public record UpdateUserDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }


    }
}
