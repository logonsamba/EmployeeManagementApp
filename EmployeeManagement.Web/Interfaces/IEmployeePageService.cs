using EmployeeManagement.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Interfaces
{
    public interface IEmployeePageService
    {
        Task<IEnumerable<EmployeeViewModel>> GetEmployees(string EmployeeName);
        Task<IEnumerable<EmployeeViewModel>> GetEmployees();
        Task<EmployeeViewModel> GetEmployeeById(int EmployeeId);
        Task<IEnumerable<EmployeeViewModel>> GetEmployeeByDepartment(int DepartmentId);
        Task<IEnumerable<DepartmentViewModel>> GetDepartments();
        Task<EmployeeViewModel> CreateEmployee(EmployeeViewModel EmployeeViewModel);
        Task UpdateEmployee(EmployeeViewModel EmployeeViewModel);
        Task DeleteEmployee(EmployeeViewModel EmployeeViewModel);
    }
}
