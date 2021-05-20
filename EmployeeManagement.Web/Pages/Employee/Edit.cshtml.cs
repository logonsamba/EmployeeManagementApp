using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Web.Interfaces;
using EmployeeManagement.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Web.Pages.Employee
{
    public class EditModel : PageModel
    {
        private readonly IEmployeePageService _employeePageService;
        public EditModel(IEmployeePageService employeePageService)
        {
            _employeePageService = employeePageService ?? throw new ArgumentNullException(nameof(employeePageService));
        }

        [BindProperty]
        public EmployeeViewModel Employee { get; set; }
        public async Task<IActionResult> OnGetAsync(int empId)
        {
            if (empId == null) { return NotFound(); }
            Employee = await _employeePageService.GetEmployeeById(empId);
            if (Employee == null) { return NotFound(); }
            ViewData["DepartmentId"] = new SelectList(await _employeePageService.GetDepartments(), "Id", "DepartmentName");
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _employeePageService.UpdateEmployee(Employee);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!employeeExists(Employee.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToPage("./Index");
        }

        private bool employeeExists(int id)
        {
            var employee = _employeePageService.GetEmployeeById(id);
            return employee != null;
        }
    }
}
