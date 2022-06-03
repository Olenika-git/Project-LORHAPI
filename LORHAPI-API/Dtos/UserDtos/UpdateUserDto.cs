using LORHAPI_API.Data;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace LORHAPI_API.Dtos.UserDtos
{
    public record UpdateUserDto
    {
        public string Mail { get; set; }

        public string Password { get; set; }


    }
}
