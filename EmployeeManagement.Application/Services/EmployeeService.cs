using AutoMapper;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Application.Mapper;
using EmployeeManagement.Application.Models;
using EmployeeManagement.Core.Entities;
using EmployeeManagement.Core.Interfaces;
using EmployeeManagement.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _EmployeeRepository;
        private readonly IAppLogger<EmployeeService> _logger;

        public EmployeeService(IEmployeeRepository EmployeeRepository, IAppLogger<EmployeeService> logger)
        {
            _EmployeeRepository = EmployeeRepository ?? throw new ArgumentNullException(nameof(EmployeeRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<EmployeeModel>> GetEmployeeList()
        {
            var EmployeeList = await _EmployeeRepository.GetEmployeeListAsync();
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<EmployeeModel>>(EmployeeList);
            return mapped;
        }

        public async Task<EmployeeModel> GetEmployeeById(int EmployeeId)
        {
            var Employee = await _EmployeeRepository.GetByIdAsync(EmployeeId);
            var mapped = ObjectMapper.Mapper.Map<EmployeeModel>(Employee);
            return mapped;
        }

        public async Task<IEnumerable<EmployeeModel>> GetEmployeeByName(string EmployeeName)
        {
            var EmployeeList = await _EmployeeRepository.GetEmployeeByNameAsync(EmployeeName);
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<EmployeeModel>>(EmployeeList);
            return mapped;
        }

        public async Task<IEnumerable<EmployeeModel>> GetEmployeeBydepartment(int departmentId)
        {
            var EmployeeList = await _EmployeeRepository.GetEmployeeByDepartmentAsync(departmentId);
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<EmployeeModel>>(EmployeeList);
            return mapped;
        }

        public async Task<EmployeeModel> Create(EmployeeModel EmployeeModel)
        {
            await ValidateEmployeeIfExist(EmployeeModel);

            var mappedEntity = ObjectMapper.Mapper.Map<Employee>(EmployeeModel);
            if (mappedEntity == null)
                throw new ApplicationException($"Entity could not be mapped.");

            var newEntity = await _EmployeeRepository.AddAsync(mappedEntity);
            _logger.LogInformation($"Entity successfully added - EmployeeManagementAppService");

            var newMappedEntity = ObjectMapper.Mapper.Map<EmployeeModel>(newEntity);
            return newMappedEntity;
        }

        public async Task Update(EmployeeModel EmployeeModel)
        {
            ValidateEmployeeIfNotExist(EmployeeModel);

            var editEmployee = await _EmployeeRepository.GetByIdAsync(EmployeeModel.Id);
            if (editEmployee == null)
                throw new ApplicationException($"Entity could not be loaded.");

            ObjectMapper.Mapper.Map<EmployeeModel, Employee>(EmployeeModel, editEmployee);

            await _EmployeeRepository.UpdateAsync(editEmployee);
            _logger.LogInformation($"Entity successfully updated - EmployeeManagementAppService");
        }

        public async Task Delete(EmployeeModel EmployeeModel)
        {
            ValidateEmployeeIfNotExist(EmployeeModel);
            var deletedEmployee = await _EmployeeRepository.GetByIdAsync(EmployeeModel.Id);
            if (deletedEmployee == null)
                throw new ApplicationException($"Entity could not be loaded.");

            await _EmployeeRepository.DeleteAsync(deletedEmployee);
            _logger.LogInformation($"Entity successfully deleted - EmployeeManagementAppService");
        }

        private async Task ValidateEmployeeIfExist(EmployeeModel EmployeeModel)
        {
            var existingEntity = await _EmployeeRepository.GetByIdAsync(EmployeeModel.Id);
            if (existingEntity != null)
                throw new ApplicationException($"{EmployeeModel.ToString()} with this id already exists");
        }

        private void ValidateEmployeeIfNotExist(EmployeeModel EmployeeModel)
        {
            var existingEntity = _EmployeeRepository.GetByIdAsync(EmployeeModel.Id);
            if (existingEntity == null)
                throw new ApplicationException($"{EmployeeModel.ToString()} with this id is not exists");
        }
    }
}
