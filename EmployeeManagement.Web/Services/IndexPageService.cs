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
    public class IndexPageService : IIndexPageService
    {
        private readonly IEmployeeService _EmployeeAppService;
        private readonly IMapper _mapper;

        public IndexPageService(IEmployeeService EmployeeAppService, IMapper mapper)
        {
            _EmployeeAppService = EmployeeAppService ?? throw new ArgumentNullException(nameof(EmployeeAppService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<EmployeeViewModel>> GetEmployees()
        {
            var list = await _EmployeeAppService.GetEmployeeList();
            var mapped = _mapper.Map<IEnumerable<EmployeeViewModel>>(list);
            return mapped;
        }
    }
}
