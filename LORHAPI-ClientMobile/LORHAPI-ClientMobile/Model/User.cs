using System;
using System.Collections.Generic;
using System.Text;

namespace LORHAPI_ModelClientMobile.Model
{
    public class User
    {
        public int IdClient { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public int UserType { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime LastConnectionDateTime { get; set; }
        public int IdOrganization { get; set; }

        public User()
        {

        }

        public User(int idClient, string email, string password, bool IsActive, int userType, DateTime creationDateTime, DateTime lastConnectionDateTime, int idOrganization)
        {
            IdClient = idClient;
            Email = email;
            Password = password;
            this.IsActive = IsActive;
            UserType = userType;
            CreationDateTime = creationDateTime;
            LastConnectionDateTime = lastConnectionDateTime;
            IdOrganization = idOrganization;
        }

    }

}
