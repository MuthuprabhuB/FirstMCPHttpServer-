using FirstMCPHttpServer.Service;
using ModelContextProtocol.Server;
using System.ComponentModel;

namespace FirstMCPHttpServer.Tools.EmployeeTools
{
    [McpServerToolType]
    public class EmployeeTools
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeTools(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [McpServerTool]
        [Description("Gets employee details including name, department, and salary using employee ID.")]
        public async Task<string> GetEmployeeById(int employeeId)
        {
            return await _employeeService.GetEmployeeByIdAsync(employeeId);
        }
    }
}
