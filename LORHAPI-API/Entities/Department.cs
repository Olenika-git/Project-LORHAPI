using System.ComponentModel.DataAnnotations;

namespace LORHAPI_API.Entities
{
    public class Department
    {
        [Key]
        public int IdDepartment { get; set; }
        public string Name { get; set; }

        public Department(int idDepartment, string name)
        {
            IdDepartment = idDepartment;
            Name = name;
        }
    }
}
