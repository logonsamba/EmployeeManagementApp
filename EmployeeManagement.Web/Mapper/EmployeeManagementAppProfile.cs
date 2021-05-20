using AutoMapper;
using EmployeeManagement.Application.Models;
using EmployeeManagement.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Mapper
{
    public class EmployeeManagementAppProfile:Profile
    {
        public EmployeeManagementAppProfile()
        {
            CreateMap<EmployeeModel, EmployeeViewModel>().ReverseMap();
            CreateMap<DepartmentModel, DepartmentViewModel>().ReverseMap();
        }
    }
}
