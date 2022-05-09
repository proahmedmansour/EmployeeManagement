using Contracts;
using Entities.Data;
using Entities.Model;
using Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class CompanyRepository : RepositoryBase<Department>, IDepartmentRepository
    {
        public CompanyRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public IEnumerable<Department> GetAllDepartments(bool trackChanges) =>
             FindAll(trackChanges)
             .OrderBy(c => c.Name)
             .ToList();

        public Department GetDepartment(Guid departmentId, bool trackChanges) =>
             FindByCondition(c => c.Id.Equals(departmentId), trackChanges)
             .SingleOrDefault();

        public void DeleteDepartment(Department department) => Delete(department);

        public void AddDepartment(Department department) => Create(department);

        public void UpdateDepartment(Department department) => Update(department);
    }
}
