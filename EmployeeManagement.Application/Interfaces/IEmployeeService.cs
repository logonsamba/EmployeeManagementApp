using EmployeeManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeModel>> GetEmployeeList();
        Task<EmployeeModel> GetEmployeeById(int EmployeeId);
        Task<IEnumerable<EmployeeModel>> GetEmployeeByName(string EmployeeName);
        Task<IEnumerable<EmployeeModel>> GetEmployeeBydepartment(int departmentId);
        Task<EmployeeModel> Create(EmployeeModel EmployeeModel);
        Task Update(EmployeeModel EmployeeModel);
        Task Delete(EmployeeModel EmployeeModel);
    }
}
