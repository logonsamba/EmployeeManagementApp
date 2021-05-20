using EmployeeManagement.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Core.Entities
{
    public class Department : Entity
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }
        public string DepartmentName { get; set; }
        public ICollection<Employee> Employees { get; private set; }
        public static Department Create(int id, string name)
        {
            var dept = new Department
            {
                Id = id,
                DepartmentName = name,
            };
            return dept;
        }
    }
}
