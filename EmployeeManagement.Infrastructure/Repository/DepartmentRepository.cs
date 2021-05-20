using EmployeeManagement.Core.Entities;
using EmployeeManagement.Core.Repositories;
using EmployeeManagement.Infrastructure.Data;
using EmployeeManagement.Core.Specifications;
using EmployeeManagement.Infrastructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace EmployeeManagement.Infrastructure.Repository
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(EmployeeManagementAppContext dbContext) : base(dbContext)
        {

        }

        public async Task<Department> GetDepartmentWithEmployeesAsync(int deptId)
        {
            var spec = new DepartmentWithEmployeeSpecification(deptId);
            var dept = (await GetAsync(spec)).FirstOrDefault();
            return dept;
        }
    }
}
