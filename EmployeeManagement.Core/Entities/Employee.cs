using EmployeeManagement.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Core.Entities
{
    public class Employee : Entity
    {
        public Employee()
        {
           
        }
        public string EmpName { get; set; }
        public string Email { get; set; }
        public DateTime DOJ { get; set; }
        public decimal? Salary { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public static Employee Create(int emdId, string empName, string email, DateTime doj, decimal? salary,int deptId)
        {
            var employee = new Employee
            {
                Id = emdId,
                EmpName = empName,
                Email = email,
                DOJ = doj,
                Salary = salary,
                DepartmentId = deptId
            };
            return employee;

        }
    }
}
