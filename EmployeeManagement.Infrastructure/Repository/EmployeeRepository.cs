using EmployeeManagement.Core.Entities;
using EmployeeManagement.Core.Repositories;
using EmployeeManagement.Core.Specifications;
using EmployeeManagement.Infrastructure.Data;
using EmployeeManagement.Infrastructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Infrastructure.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(EmployeeManagementAppContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<Employee>> GetEmployeeByDepartmentAsync(int deptId)
        {
            var spec = new EmployeeWithDepartmentSpecification(deptId);
            return await GetAsync(spec);
        }

        public async Task<IEnumerable<Employee>> GetEmployeeByNameAsync(string empName)
        {
            var spec = new EmployeeWithDepartmentSpecification(empName);
            return await GetAsync(spec);
        }

        public async Task<IEnumerable<Employee>> GetEmployeeListAsync()
        {
            var spec = new EmployeeWithDepartmentSpecification();
            return await GetAsync(spec);
        }
    }
}
