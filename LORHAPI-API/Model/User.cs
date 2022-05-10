using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LORHAPI_API.Model
{
    public class User
    {
        [Key]
        public int IdClient { get; set; }
        
        public string Email { get; set; }
        public string Password { get; set; }
        public bool isActive { get; set; }
        public int UserType { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime LastConnectionDateTime { get; set; }
        public string OrgName { get; set; }

        public User(int idClient, string email, string password, bool isActive, int userType, DateTime creationDateTime, DateTime lastConnectionDateTime, string orgName)
        {
            IdClient = idClient;
            Email = email;
            Password = password;
            this.isActive = isActive;
            UserType = userType;
            CreationDateTime = creationDateTime;
            LastConnectionDateTime = lastConnectionDateTime;
            OrgName = orgName;
        }
    }
}
