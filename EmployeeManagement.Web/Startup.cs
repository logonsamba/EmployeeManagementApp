using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Application.Services;
using EmployeeManagement.Core.Configuration;
using EmployeeManagement.Core.Interfaces;
using EmployeeManagement.Core.Repositories;
using EmployeeManagement.Core.Repositories.Base;
using EmployeeManagement.Infrastructure.Data;
using EmployeeManagement.Infrastructure.Logging;
using EmployeeManagement.Infrastructure.Repository;
using EmployeeManagement.Infrastructure.Repository.Base;
using EmployeeManagement.Web.HealthChecks;
using EmployeeManagement.Web.Interfaces;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // EmployeeManagement dependencies
            ConfigureEmployeeManagementAppServices(services);

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for Employeeion scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
        private void ConfigureEmployeeManagementAppServices(IServiceCollection services)
        {
            // Add Core Layer
            services.Configure<EmployeeManagementAppSettigs>(Configuration);

            // Add Infrastructure Layer
            ConfigureDatabases(services);
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

            // Add Application Layer
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IDepartmentService, DepartmentService>();

            // Add Web Layer
            services.AddAutoMapper(typeof(Startup)); // Add AutoMapper
            services.AddScoped<IIndexPageService, IndexPageService>();
            services.AddScoped<IEmployeePageService, EmployeePageService>();
            services.AddScoped<IDepartmentPageService, DepartmentPageService>();

            // Add Miscellaneous
            services.AddHttpContextAccessor();
            services.AddHealthChecks()
                .AddCheck<IndexPageHealthCheck>("home_page_health_check");
        }

        public void ConfigureDatabases(IServiceCollection services)
        {
            // use in-memory database
            //services.AddDbContext<EmployeeManagementAppContext>(c =>
            //    c.UseInMemoryDatabase("EmployeeManagementConnection"));

            //// use real database
            services.AddDbContext<EmployeeManagementAppContext>(c =>
                c.UseSqlServer(Configuration.GetConnectionString("EmployeeManagementConnection")));
        }
    }
}
