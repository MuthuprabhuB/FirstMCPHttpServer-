using FirstMCPHttpServer.Models;
using FirstMCPHttpServer.Repository;

namespace FirstMCPHttpServer.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<string> GetEmployeeByIdAsync(int employeeId)
        {
            var employee = await _employeeRepository.GetByIdAsync(employeeId);
            if (employee == null)
            {
                return "Employee not found.";
            }

            return $"""
            Employee ID: {employee.Id}
            Name: {employee.Name}
            Department: {employee.Department}
            Salary: {employee.Salary}
            """;
        }
    }
    
 
}

