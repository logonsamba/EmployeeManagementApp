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
    public class IndexModel : PageModel
    {
        private readonly IEmployeePageService _EmployeePageService;
        public IndexModel(IEmployeePageService service)
        {
            _EmployeePageService = service ?? throw new ArgumentNullException(nameof(service));
        }
        public IEnumerable<EmployeeViewModel> EmpList { get; set; } = new List<EmployeeViewModel>();

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            EmpList = await _EmployeePageService.GetEmployees();
            return Page();
        }
    }
}
