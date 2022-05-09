using Contracts;
using Entities.Data;
using Entities.Model;
using Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }
        public IEnumerable<Employee> GetAllEmployees(bool trackChanges) =>
                   FindAll(trackChanges)
                   .OrderBy(c => c.Name)
                   .ToList();

        public Employee GetEmployee(Guid EmployeeId, bool trackChanges) =>
             FindByCondition(c => c.Id.Equals(EmployeeId), trackChanges)
             .SingleOrDefault();

        public void DeleteEmployee(Employee Employee) => Delete(Employee);

        public void AddEmployee(Employee Employee) => Create(Employee);

        public void UpdateEmployee(Employee Employee) => Update(Employee);
    }
}
