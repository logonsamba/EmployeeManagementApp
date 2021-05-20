using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.ViewModels
{
    public class EmployeeViewModel:BaseViewModel
    {
        public string EmpName { get; set; }
        public string Email { get; set; }
        public DateTime DOJ { get; set; }
        public decimal? Salary { get; set; }
        public int DepartmentId { get; set; }
        public DepartmentViewModel Department { get; set; }
    }
}
