using Microsoft.EntityFrameworkCore;
using FirstMCPHttpServer.Models;

namespace FirstMCPHttpServer.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; } = null!;
    }
}
