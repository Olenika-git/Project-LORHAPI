using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LORHAPI_API.Model
{
    public class Insertion
    {
        [Key]
        public int IdInsertion { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AgeMin { get; set; }
        public int AgeMax { get; set; }
        public double Salary { get; set; }
        public string Place { get; set; }
        public string Duration { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string RedirectionLink { get; set; }
        public int IdOrganization { get; set; }
        public int DegreeRequired { get; set; }
        public int DegreeObtained { get; set; }
        public int IdSector { get; set; }


    }
}
