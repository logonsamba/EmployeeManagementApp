using AutoMapper;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Application.Mapper;
using EmployeeManagement.Application.Models;
using EmployeeManagement.Core.Interfaces;
using EmployeeManagement.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _DepartmentRepository;
        private readonly IAppLogger<DepartmentService> _logger;
        public DepartmentService(IDepartmentRepository DepartmentRepository, IAppLogger<DepartmentService> logger)
        {
            _DepartmentRepository = DepartmentRepository ?? throw new ArgumentNullException(nameof(DepartmentRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<DepartmentModel>> GetDepartmentList()
        {
            var Department = await _DepartmentRepository.GetAllAsync();
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<DepartmentModel>>(Department);
            return mapped;
        }
    }
}
