using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Web.Interfaces;
using EmployeeManagement.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeManagement.Web.Pages.Employee
{
    public class DetailsModel : PageModel
    {
        private readonly IEmployeePageService _employeePageService;
        public DetailsModel(IEmployeePageService employeePageService)
        {
            _employeePageService = employeePageService ?? throw new ArgumentNullException();
        }
        public EmployeeViewModel Employee { get; set; }
        public async Task<IActionResult> OnGetAsync(int? empId)
        {
            if (empId == null)
            {
                return NotFound();
            }

            Employee = await _employeePageService.GetEmployeeById(empId.Value);
            if (Employee == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

