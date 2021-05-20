using AutoMapper;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Web.Interfaces;
using EmployeeManagement.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Services
{
    public class DepartmentPageService : IDepartmentPageService
    {
        private readonly IDepartmentService _DepartmentAppService;
        private readonly IMapper _mapper;

        public DepartmentPageService(IDepartmentService DepartmentAppService, IMapper mapper)
        {
            _DepartmentAppService = DepartmentAppService ?? throw new ArgumentNullException(nameof(DepartmentAppService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<DepartmentViewModel>> GetDepartments()
        {
            var list = await _DepartmentAppService.GetDepartmentList();
            var mapped = _mapper.Map<IEnumerable<DepartmentViewModel>>(list);
            return mapped;
        }
    }
}
