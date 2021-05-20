using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Web.Interfaces;
using EmployeeManagement.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeManagement.Web.Pages.Department
{
    public class IndexModel : PageModel
    {
        private readonly IDepartmentPageService _DepartmentPageService;

        public IndexModel(IDepartmentPageService DepartmentPageService)
        {
            _DepartmentPageService = DepartmentPageService ?? throw new ArgumentNullException(nameof(DepartmentPageService));
        }

        public IEnumerable<DepartmentViewModel> DepartmentList { get; set; } = new List<DepartmentViewModel>();

        public async Task<IActionResult> OnGetAsync()
        {
            DepartmentList = await _DepartmentPageService.GetDepartments();
            return Page();
        }
    }
}
