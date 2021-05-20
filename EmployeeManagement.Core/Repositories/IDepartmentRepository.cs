using EmployeeManagement.Core.Entities;
using EmployeeManagement.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Core.Repositories
{
    public interface IDepartmentRepository:IRepository<Department>
    {
        Task<Department> GetDepartmentWithEmployeesAsync(int deptId);
    }
}
