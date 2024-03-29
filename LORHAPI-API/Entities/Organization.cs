﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LORHAPI_API.Model
{
    public class Organization
    {
        [Key]
        public int IdOrganization { get; set; }

        public string OrgName { get; set; }
        
        public string Phone { get; set; }
        
        public string Adress { get; set; }
        
        public string ZIP { get; set; }
        
        public string City { get; set; }
        
    }
}
