using EmployeeManagement.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Interfaces
{
    public interface IDepartmentPageService
    {
        Task<IEnumerable<DepartmentViewModel>> GetDepartments();
    }
}
