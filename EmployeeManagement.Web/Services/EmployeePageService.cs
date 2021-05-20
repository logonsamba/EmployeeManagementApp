using AutoMapper;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Application.Models;
using EmployeeManagement.Web.Interfaces;
using EmployeeManagement.Web.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Services
{
    public class EmployeePageService:IEmployeePageService
    {
        private readonly IEmployeeService _EmployeeAppService;
        private readonly IDepartmentService _DepartmentAppService;
        private readonly IMapper _mapper;
        private readonly ILogger<EmployeePageService> _logger;

        public EmployeePageService(IEmployeeService EmployeeAppService, IDepartmentService DepartmentAppService, IMapper mapper, ILogger<EmployeePageService> logger)
        {
            _EmployeeAppService = EmployeeAppService ?? throw new ArgumentNullException(nameof(EmployeeAppService));
            _DepartmentAppService = DepartmentAppService ?? throw new ArgumentNullException(nameof(DepartmentAppService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<EmployeeViewModel>> GetEmployees(string EmployeeName)
        {
            if (string.IsNullOrWhiteSpace(EmployeeName))
            {
                var list = await _EmployeeAppService.GetEmployeeList();
                var mapped = _mapper.Map<IEnumerable<EmployeeViewModel>>(list);
                return mapped;
            }

            var listByName = await _EmployeeAppService.GetEmployeeByName(EmployeeName);
            var mappedByName = _mapper.Map<IEnumerable<EmployeeViewModel>>(listByName);
            return mappedByName;
        }

        public async Task<EmployeeViewModel> GetEmployeeById(int EmployeeId)
        {
            var Employee = await _EmployeeAppService.GetEmployeeById(EmployeeId);
            var mapped = _mapper.Map<EmployeeViewModel>(Employee);
            return mapped;
        }
        public async Task<IEnumerable<EmployeeViewModel>> GetEmployees()
        {
            var list = await _EmployeeAppService.GetEmployeeList();
            var mapped = _mapper.Map<IEnumerable<EmployeeViewModel>>(list);
            return mapped;
        }
        public async Task<IEnumerable<EmployeeViewModel>> GetEmployeeByDepartment(int DepartmentId)
        {
            var list = await _EmployeeAppService.GetEmployeeBydepartment(DepartmentId);
            var mapped = _mapper.Map<IEnumerable<EmployeeViewModel>>(list);
            return mapped;
        }

        public async Task<IEnumerable<DepartmentViewModel>> GetDepartments()
        {
            var list = await _DepartmentAppService.GetDepartmentList();
            var mapped = _mapper.Map<IEnumerable<DepartmentViewModel>>(list);
            return mapped;
        }

        public async Task<EmployeeViewModel> CreateEmployee(EmployeeViewModel EmployeeViewModel)
        {
            var mapped = _mapper.Map<EmployeeModel>(EmployeeViewModel);
            if (mapped == null)
                throw new Exception($"Entity could not be mapped.");

            var entityDto = await _EmployeeAppService.Create(mapped);
            _logger.LogInformation($"Entity successfully added - IndexPageService");

            var mappedViewModel = _mapper.Map<EmployeeViewModel>(entityDto);
            return mappedViewModel;
        }

        public async Task UpdateEmployee(EmployeeViewModel EmployeeViewModel)
        {
            var mapped = _mapper.Map<EmployeeModel>(EmployeeViewModel);
            if (mapped == null)
                throw new Exception($"Entity could not be mapped.");

            await _EmployeeAppService.Update(mapped);
            _logger.LogInformation($"Entity successfully added - IndexPageService");
        }

        public async Task DeleteEmployee(EmployeeViewModel EmployeeViewModel)
        {
            var mapped = _mapper.Map<EmployeeModel>(EmployeeViewModel);
            if (mapped == null)
                throw new Exception($"Entity could not be mapped.");

            await _EmployeeAppService.Delete(mapped);
            _logger.LogInformation($"Entity successfully added - IndexPageService");
        }
    }
}
