using Contracts;
using Entities.Data;
using InterViewTask.DepartmentManagement.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Repository;
using System;

namespace InterViewTask.DepartmentManagement.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });

        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddScoped<ILoggerManager, LoggerManager>();

        public static void ConfigureSqlContext(this IServiceCollection services,
            IConfiguration configuration) =>
             services.AddDbContext<RepositoryContext>(opts =>
                opts.UseSqlServer(configuration.GetConnectionString("MSSQL"), b => b.MigrationsAssembly("InterviewTask.EmployeeManagement")));

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
             services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Interview Task",
                    Description = "A simple example for employee/department task in ASP.NET Core.",
                    Contact = new OpenApiContact
                    {
                        Name = "Shayne Boyer",
                        Email = string.Empty,
                        Url = new Uri("https://twitter.com/proahmedmansour"),
                    }
                });
            });
        }
    }
}
