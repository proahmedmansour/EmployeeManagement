using Entities.Base;
using System;
using System.Collections.Generic;

namespace Entities.Model
{
    public class Department : Entity<Guid>
    {
        public string Name { get; set; }

        public Guid? ManagerId { get; set; }

        public string ManagerName { get; set; }

        //[ForeignKey(nameof(EmployeeId))]
        //public Guid EmployeeId { get; set; }
        //public Employee Employee { get; set; }

        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

        public bool HasDependant() => Employees.Count > 0;

        public void RelateToManager(Employee employee)
        {
            if (employee == null)
                return;

            this.ManagerId = employee.ManagerId;
            this.ManagerName = employee.Name;
        }
    }
}
