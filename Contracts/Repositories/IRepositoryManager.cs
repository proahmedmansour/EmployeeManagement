namespace Contracts
{
    public interface IRepositoryManager
    {
        IDepartmentRepository Department { get; }
        IEmployeeRepository Employee { get; }
        bool Save();
    }
}
