using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Web.Interfaces;
using EmployeeManagement.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeManagement.Web.Pages.Employee
{
    public class CreateModel : PageModel
    {
        private readonly IEmployeePageService _EmployeePageService;

        public CreateModel(IEmployeePageService EmployeePageService)
        {
            _EmployeePageService = EmployeePageService ?? throw new ArgumentNullException(nameof(EmployeePageService));
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var categories = await _EmployeePageService.GetDepartments();
            ViewData["DepartmentId"] = new SelectList(categories, "Id", "DepartmentName");
            return Page();
        }

        [BindProperty]
        public EmployeeViewModel Employee { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Employee = await _EmployeePageService.CreateEmployee(Employee);
            return RedirectToPage("./Index");
        }
    }
}
