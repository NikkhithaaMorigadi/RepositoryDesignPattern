using RepositoryDesignPattern.Entities;

namespace RepositoryDesignPattern.Repository
{
    public interface IEmployeeRepository
    {
        Employee GetById(int EmployeeID);
        void Insert(Employee employee);
        bool Update(Employee employee);
        void Delete(int EmployeeID);
        void Save();
        IEnumerable<Employee> GetAlls();
    }
}
