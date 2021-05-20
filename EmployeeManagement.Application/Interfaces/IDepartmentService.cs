using EmployeeManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Interfaces
{
   public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentModel>> GetDepartmentList();
    }
}
