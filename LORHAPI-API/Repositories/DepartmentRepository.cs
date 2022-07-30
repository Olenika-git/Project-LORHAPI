using LORHAPI_API.Data;
using LORHAPI_API.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LORHAPI_API.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private List<Department> DepartmentList = new();
        private readonly Db_Context _dbcontext;

        public DepartmentRepository(Db_Context context)
        {
            _dbcontext = context;  //on assigne le Db_Context
            DepartmentList = _dbcontext.Departments.ToList();
        }

        public async Task<List<Department>> GetDepartmentAsync()
        {
            return await Task.FromResult(DepartmentList);
        }

        public async Task<Department> GetDepartmentByIdAsync(int id)
        {
            Department department = DepartmentList.Where(theDepartment => theDepartment.IdDepartment == id).SingleOrDefault();
            return await Task.FromResult(department);
        }

    }
}
