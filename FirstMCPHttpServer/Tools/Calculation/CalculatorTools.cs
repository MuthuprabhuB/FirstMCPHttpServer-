using ModelContextProtocol.Server;
using System.ComponentModel;

namespace FirstMCPHttpServer.Tools;

[McpServerToolType]
public class CalculatorTools
{
    [McpServerTool]
    [Description("Adds two numbers.")]
    public static double Add(double a, double b)
    {
        return a + b;
    }

    [McpServerTool]
    [Description("Multiplies two numbers.")]
    public static double Multiply(double a, double b)
    {
        return a * b;
    }

    [McpServerTool]
    [Description("Subtracts two numbers.")]
    public static double Subtract(double a, double b)
    {
        return a - b;
    }

    [McpServerTool]
    [Description("Divides two numbers.")]
    public static double Divide(double a, double b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("Cannot divide by zero.");
        }
        return a / b;
    }
}