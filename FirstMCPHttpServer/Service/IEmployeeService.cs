using FirstMCPHttpServer.Models;

namespace FirstMCPHttpServer.Service
{
    public interface IEmployeeService
    {
        Task<string> GetEmployeeByIdAsync(int employeeId);
    }
}
