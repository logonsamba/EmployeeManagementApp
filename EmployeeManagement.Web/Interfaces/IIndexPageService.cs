using EmployeeManagement.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Interfaces
{
    // NOTE : This is the whole page service, it could be include all Departments and Employees
    // this is the razor page based service
    public interface IIndexPageService
    {
        Task<IEnumerable<EmployeeViewModel>> GetEmployees();
    }
}
