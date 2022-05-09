using InterviewTask.EmployeeManagement.Dtos.Base;
using System;

namespace InterviewTask.EmployeeManagement.Dtos
{
    public class DepartmentDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public string ManagerId { get; set; }

        public string ManagerName { get; set; }
    }

}
