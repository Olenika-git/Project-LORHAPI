using System;
using System.Collections.Generic;
using System.Text;

namespace LORHAPI_ClientMobile.Model
{
    public class Insertion
    {
        public int IdInsertion { get; set; }
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
        public int IdOrganization { get; set; }
        public string DiplomeRequis { get; set; }
        public string DiplomeObtenu { get; set; }
        public int IdSecteur { get; set; }


    }
}
