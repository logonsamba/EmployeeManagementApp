using EmployeeManagement.Core.Entities;
using EmployeeManagement.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Core.Repositories
{
    public interface IEmployeeRepository:IRepository<Employee>
    {
        Task<IEnumerable<Employee>> GetEmployeeListAsync();
        Task<IEnumerable<Employee>> GetEmployeeByNameAsync(string empName);
        Task<IEnumerable<Employee>> GetEmployeeByDepartmentAsync(int deptId);
    }
}
