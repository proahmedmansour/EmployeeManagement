using InterviewTask.EmployeeManagement.Dtos.Base;
using System;

namespace InterviewTask.EmployeeManagement.Dtos
{
    public class EmployeeDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public string DepartmentName { get; set; }

        public string ManagerName { get; set; }

        public string ManagerId { get; set; }

        public string DepartmentId { get; set; }

        public decimal Salary { get; set; }
    }
}