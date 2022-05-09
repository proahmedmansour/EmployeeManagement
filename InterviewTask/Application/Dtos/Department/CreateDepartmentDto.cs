using System;
using System.ComponentModel.DataAnnotations;

namespace InterviewTask.EmployeeManagement.Dtos
{
    public class CreateDepartmentDto
    {
        [Required]
        public string Name { get; set; }

        public Guid? ManagerId { get; set; }
    }
}
