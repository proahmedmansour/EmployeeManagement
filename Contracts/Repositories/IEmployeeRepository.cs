using Entities.Model;
using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees(bool trackChanges);

        Employee GetEmployee(Guid EmployeeId, bool trackChanges);

        void DeleteEmployee(Employee Employee);

        void AddEmployee(Employee Employee);

        void UpdateEmployee(Employee Employee);
    }
}
