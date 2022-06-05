using System;
using System.ComponentModel.DataAnnotations;

namespace LORHAPI_Client.Areas.User.Models
{
    public class User
    {
        [Key]
        public int IdClient { get; set; }

        public string Mail { get; set; }

        public string Password { get; set; }
        public bool IsActive { get; set; }
        public UserTypes UserType { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime LastConnectionDateTime { get; set; }
        public int IdOrganization { get; set; }

        public User()
        {

        }

        public User(int idClient, string email, string password, bool IsActive, UserTypes userType, DateTime creationDateTime, DateTime lastConnectionDateTime, int idOrganization)
        {
            IdClient = idClient;
            Mail = email;
            Password = password;
            this.IsActive = IsActive;
            UserType = userType;
            CreationDateTime = creationDateTime;
            LastConnectionDateTime = lastConnectionDateTime;
            IdOrganization = idOrganization;
        }

    }
}
