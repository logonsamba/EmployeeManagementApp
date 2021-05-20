using AutoMapper;
using EmployeeManagement.Application.Models;
using EmployeeManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.Mapper
{
    // The best implementation of AutoMapper for class libraries -> https://www.abhith.net/blog/using-automapper-in-a-net-core-class-library/
    public static class ObjectMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                // This line ensures that internal properties are also mapped over.
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<EmployeeManagementAppDtoMapper>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });
        public static IMapper Mapper => Lazy.Value;
    }

    public class EmployeeManagementAppDtoMapper : Profile
    {
        public EmployeeManagementAppDtoMapper()
        {
            CreateMap<Employee, EmployeeModel>()
                .ForMember(dest => dest.EmpName, opt => opt.MapFrom(src => src.EmpName)).ReverseMap();

            CreateMap<Department, DepartmentModel>().ReverseMap();
        }
    }
}
