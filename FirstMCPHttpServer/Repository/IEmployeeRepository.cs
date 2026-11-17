using FirstMCPHttpServer.Models;

namespace FirstMCPHttpServer.Repository
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetByIdAsync(int id);
    }
}
