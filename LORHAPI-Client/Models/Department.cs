using System.ComponentModel.DataAnnotations;

namespace LORHAPI_Client.Models
{
    public class Department
    {
        [Key]
        public int IdDepartment { get; set; }
        public string Name { get; set; }
    }



}
