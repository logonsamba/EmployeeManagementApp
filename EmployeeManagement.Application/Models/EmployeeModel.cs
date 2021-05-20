using EmployeeManagement.Application.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.Models
{
    public class EmployeeModel:BaseModel
    {
        public string EmpName { get; set; }
        public string Email { get; set; }
        public DateTime DOJ { get; set; }
        public decimal? Salary { get; set; }
        public int DepartmentId { get; set; }
        public DepartmentModel Department { get; set; }
    }
}
