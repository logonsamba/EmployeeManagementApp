using EmployeeManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Infrastructure.Data
{
    public class EmployeeManagementAppContextSeed
    {
        public static async Task SeedAsync(EmployeeManagementAppContext empManagementContext, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;

            try
            {
                // TODO: Only run this if using a real database
                empManagementContext.Database.Migrate();
                empManagementContext.Database.EnsureCreated();

                if (!empManagementContext.Departments.Any())
                {
                    empManagementContext.Departments.AddRange(GetPreconfiguredDepartments());
                    await empManagementContext.SaveChangesAsync();
                }

                if (!empManagementContext.Employees.Any())
                {
                    empManagementContext.Employees.AddRange(GetPreconfiguredEmployees());
                    await empManagementContext.SaveChangesAsync();
                }
            }
            catch (Exception exception)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<EmployeeManagementAppContextSeed>();
                    log.LogError(exception.Message);
                    await SeedAsync(empManagementContext, loggerFactory, retryForAvailability);
                }
                throw;
            }
        }

        private static IEnumerable<Department> GetPreconfiguredDepartments()
        {
            return new List<Department>()
            {
                new Department() { DepartmentName = "IT"},
                new Department() { DepartmentName = "HR"}
            };
        }

        private static IEnumerable<Employee> GetPreconfiguredEmployees()
        {
            return new List<Employee>()
            {
                new Employee() { EmpName = "Sambasivarao Morla",Department= new Department(){ DepartmentName="IT"},DOJ=Convert.ToDateTime("10/05/2012"),Email="samba.084@gmail.com"  },
                new Employee() {EmpName = "Virat Rishi Morla",Department= new Department(){ DepartmentName="HR"},DOJ=Convert.ToDateTime("10/05/2012"),Email="virat.084@gmail.com" },
                new Employee() { EmpName = "Surya Morla",Department= new Department(){ DepartmentName="IT"},DOJ=Convert.ToDateTime("10/05/2012"),Email="surya.084@gmail.com"}
            };
        }
    }
}
