using EmployeeManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Infrastructure.Data
{
    public class EmployeeManagementAppContext : DbContext
    {
        public EmployeeManagementAppContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Employee>(ConfigureEmployee);
            builder.Entity<Department>(ConfigureDepartment);
        }

        private void ConfigureEmployee(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");

            builder.HasKey(ci => ci.Id);

            builder.Property(cb => cb.Id)
                .IsRequired()
                .HasMaxLength(100);
        }

        private void ConfigureDepartment(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Department");

            builder.HasKey(ci => ci.Id);

            builder.Property(cb => cb.Id)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
