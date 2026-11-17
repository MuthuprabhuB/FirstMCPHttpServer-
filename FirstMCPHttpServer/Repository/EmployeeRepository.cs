using FirstMCPHttpServer.Data;
using FirstMCPHttpServer.Models;
using FirstMCPHttpServer.Repository;
using Microsoft.EntityFrameworkCore;

namespace FirstMCPHttpServer.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _context;

        public EmployeeRepository(EmployeeDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _context.Employees.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);

        }
    }
}
