using System;
using EmployeeManagement.Core.Entities;
using EmployeeManagement.Core.Specifications.Base;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Core.Specifications
{
    public class DepartmentWithEmployeeSpecification : BaseSpecification<Department>
    {
        public DepartmentWithEmployeeSpecification(int deptId) : base(b => b.Id == deptId)
        {
            AddInclude(b => b.Employees);
        }
    }
}
