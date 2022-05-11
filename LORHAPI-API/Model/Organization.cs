using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LORHAPI_API.Model
{
    public class Organization
    {
        [Key]
<<<<<<< HEAD
        public string OrgName { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public string ZipCode { get; set; }
=======
        
        public string OrgName { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public string ZIP { get; set; }
>>>>>>> 3d2e19630eaac164107ead4f5cf5abae72199636
        public string City { get; set; }

    }
}
