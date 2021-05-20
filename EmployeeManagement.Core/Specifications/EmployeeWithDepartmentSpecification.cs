using EmployeeManagement.Core.Entities;
using EmployeeManagement.Core.Specifications.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Core.Specifications
{
    public class EmployeeWithDepartmentSpecification : BaseSpecification<Employee>
    {
        public EmployeeWithDepartmentSpecification(string empName) : base(b => b.EmpName == empName)
        {
            AddInclude(b => b.Department);
        }
        public EmployeeWithDepartmentSpecification(int deptId) : base(b => b.Department.Id == deptId)
        {
            AddInclude(b => b.Department);
        }
        public EmployeeWithDepartmentSpecification():base(null)
        {
            AddInclude(b => b.Department);
        }
    }
}
