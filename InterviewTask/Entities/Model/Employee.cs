using Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Model
{
    public class Employee : Entity<Guid>
    {
        public string Name { get; set; }

        [Column(TypeName = "decimal (15,2)")]
        public decimal Salary { get; set; }

        [ForeignKey(nameof(DepartmentId))]

        public Guid DepartmentId { get; set; }

        [ForeignKey(nameof(ManagerId))]
        public Guid ManagerId { get; set; }

        public virtual Department Department { get; set; }

        public virtual Employee Manager { get; set; }

        public virtual ICollection<Employee> Employees { get; } = new List<Employee>();

        public bool HasDependant() => Employees.Count > 0;
        public void RelateToManager(Employee employee)
        {
            if (employee == null)
                return;

            this.ManagerId = employee.ManagerId;
        }
    }
}
