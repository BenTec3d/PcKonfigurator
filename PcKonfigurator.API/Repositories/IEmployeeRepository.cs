using PcKonfigurator.API.Entities;

namespace PcKonfigurator.API.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeEntity>> GetEmployeesAsync(string login);
        Task<EmployeeEntity?> GetEmployeeAsync(int employeeId);
    }
}
