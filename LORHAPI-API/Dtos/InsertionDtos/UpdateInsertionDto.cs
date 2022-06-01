using LORHAPI_API.Data;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace LORHAPI_API.Dtos.InsertionDtos
{
    public record UpdateInsertionDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int AgeMin { get; set; }
        public int AgeMax { get; set; }
        public double Salary { get; set; }
        public string Place { get; set; }
        public string Duration { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public string RedirectionLink { get; set; }
        public string DiplomeRequis { get; set; }
        public string DiplomeObtenu { get; set; }
        public int IdSecteur { get; set; }
        


    }
}
