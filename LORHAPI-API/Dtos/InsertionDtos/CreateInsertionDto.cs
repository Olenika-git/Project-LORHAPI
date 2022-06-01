using LORHAPI_API.Data;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace LORHAPI_API.Dtos.InsertionDtos
{
    public record CreateInsertionDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int AgeMin { get; set; }

        [Required]
        public int AgeMax { get; set; }

        [Required]
        public double Salary { get; set; }

        [Required]
        public string Place { get; set; }

        [Required]
        public string Duration { get; set; }

        [Required]
        public DateTime DateDebut { get; set; }

        [Required]
        public DateTime DateFin { get; set; }

        [Required]
        public string RedirectionLink { get; set; }

        [Required]
        public int IdOrganization { get; set; }

        [Required]
        public string DiplomeRequis { get; set; }

        [Required]
        public string DiplomeObtenu { get; set; }

        [Required]        
        public int IdSecteur { get; set; }

        /// <summary>
        /// Return the Last ID of user used in the Database
        /// </summary>
        /// <returns>ID</returns>
        public int GetNextID(Db_Context context)
        {
            return context.Insertions.Max(x => x.IdInsertion) + 1;
        }

    }
}
