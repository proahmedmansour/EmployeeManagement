using Contracts;
using Entities.Data;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private IDepartmentRepository _departmentRepository;
        private IEmployeeRepository _employeeRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public IDepartmentRepository Department => _departmentRepository ??= new CompanyRepository(_repositoryContext);

        public IEmployeeRepository Employee => _employeeRepository ??= new EmployeeRepository(_repositoryContext);

        public bool Save() => _repositoryContext.SaveChanges() > 0;
    }
}