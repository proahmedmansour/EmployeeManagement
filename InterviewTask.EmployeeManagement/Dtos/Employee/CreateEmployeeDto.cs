using System;
using System.ComponentModel.DataAnnotations;

namespace InterviewTask.EmployeeManagement.Dtos
{
    public class CreateEmployeeDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Salary { get; set; }

        [Required]
        public Guid DepartmentId { get; set; }

        [Required]
        public Guid ManagerId { get; set; }
    }
}
