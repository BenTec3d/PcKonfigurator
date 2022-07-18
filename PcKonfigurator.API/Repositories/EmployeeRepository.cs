using Microsoft.EntityFrameworkCore;
using PcKonfigurator.API.DbContexts;
using PcKonfigurator.API.Entities;

namespace PcKonfigurator.API.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly PcKonfiguratorContext _context;

        public EmployeeRepository(PcKonfiguratorContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<EmployeeEntity>> GetEmployeesAsync(string login)
        {
            return await _context.Employee.Where(x => x.Login == login).ToListAsync();
        }

        public async Task<EmployeeEntity?> GetEmployeeAsync(int employeeId)
        {
            return await _context.Employee.Where(x => x.Id == employeeId).FirstOrDefaultAsync();
        }
    }
}
