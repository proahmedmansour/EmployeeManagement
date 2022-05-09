using Entities.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Entities.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData(
                new Employee
                {
                    Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                    Name = "Ahmed Mansour",
                    CreatedTime = DateTime.Now,
                    Salary = 10000
                },
                new Employee
                {
                    Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                    Name = "Mohamed Taha",
                    CreatedTime = DateTime.Now,
                    Salary = 15000
                }
            );
        }
    }
}