using System;

namespace LORHAPI_Client.Models
{
    public class User
    {
        public int IdClient { get; set; }

        public string Mail { get; set; }

        public string Password { get; set; }
        public bool IsActive { get; set; }
        public UserTypes UserType { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime LastConnectionDateTime { get; set; }
        public int IdOrganization { get; set; }
    }
}
