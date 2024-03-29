﻿using LORHAPI_API.Data;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace LORHAPI_API.Dtos.UserDtos
{
    public record CreateUserDto
    {
        [Required]
        public string Mail { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public int IdOrganization { get; set; }


        /// <summary>
        /// Return the Last ID of user used in the Database
        /// </summary>
        /// <returns>ID</returns>
        public int GetNextID(Db_Context context)
        {
            return context.Users.Max(x => x.IdClient) + 1;
        }

    }
}
