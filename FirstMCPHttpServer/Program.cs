using FirstMCPHttpServer.Data;
using FirstMCPHttpServer.Repository;
using FirstMCPHttpServer.Service;
using FirstMCPHttpServer.Tools.EmployeeTools;
using Microsoft.EntityFrameworkCore;
using ModelContextProtocol.AspNetCore;
using ModelContextProtocol.Server;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EmployeeDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("EmployeeDb")));

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<EmployeeTools>();

builder.Services
    .AddMcpServer()
    .WithHttpTransport(options =>
    {
        options.SessionMode = HttpServerSessionMode.Stateless;
    })
    .WithToolsFromAssembly();

var app = builder.Build();

// Create MCP endpoint
app.MapMcp("/mcp");

app.Run("http://localhost:3001");