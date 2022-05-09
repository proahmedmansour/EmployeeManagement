using Entities.Model;
using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAllDepartments(bool trackChanges);

        Department GetDepartment(Guid departmentId, bool trackChanges);

        void DeleteDepartment(Department department);

        void AddDepartment(Department department);

        void UpdateDepartment(Department department);
    }
}
