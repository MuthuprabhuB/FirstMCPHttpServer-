# FirstMCPHttpServer

A modern, high-performance HTTP-based **Model Context Protocol (MCP)** server built with **.NET 10** and **ASP.NET Core**. 

This server exposes AI tools for managing and querying employee records backed by **Entity Framework Core** and **Microsoft SQL Server**, alongside utility tools for mathematical calculations and random number generation.

---

## 🚀 Features

- **Model Context Protocol (MCP) over HTTP**: Uses `ModelContextProtocol.AspNetCore` with stateless HTTP transport served at `/mcp` on `http://localhost:3001`.
- **Database-Backed AI Tools**: Query live SQL Server records through Entity Framework Core using repository and service patterns.
- **Calculator Tools**: Perform basic arithmetic operations (`Add`, `Subtract`, `Multiply`, `Divide`).
- **Random Number Generator**: Configurable min/max random number generation.
- **Clean Layered Architecture**: Clean separation of concerns across Models, Data, Repository, Service, and Tool layers.

---

## 🛠️ Exposed MCP Tools

The server automatically registers and exposes tools discovered from the assembly:

| Tool Name | Class | Description | Parameters |
| :--- | :--- | :--- | :--- |
| `GetEmployeeById` | `EmployeeTools` | Retrieves employee details (Name, Department, Salary) from the SQL database. | `employeeId` (int) |
| `Add` | `CalculatorTools` | Adds two double-precision numbers. | `a` (double), `b` (double) |
| `Subtract` | `CalculatorTools` | Subtracts `b` from `a`. | `a` (double), `b` (double) |
| `Multiply` | `CalculatorTools` | Multiplies two numbers. | `a` (double), `b` (double) |
| `Divide` | `CalculatorTools` | Divides `a` by `b` (throws on zero division). | `a` (double), `b` (double) |
| `GetRandomNumber` | `RandomNumberTools` | Generates a random integer within a range. | `min` (int, default: 0), `max` (int, default: 100) |

---

## 🏗️ Architecture & Project Structure

```text
FirstMCPHttpServer/
├── Data/
│   └── EmployeeDbContext.cs          # EF Core database context
├── Migrations/                       # EF Core database schema migrations
├── Models/
│   └── Employee.cs                   # Employee entity model (Id, Name, Department, Salary)
├── Repository/
│   ├── IEmployeeRepository.cs        # Repository contract
│   └── EmployeeRepository.cs         # EF Core repository implementation
├── Service/
│   ├── IEmployeeService.cs           # Business logic contract
│   └── EmployeeService.cs            # Service formatting employee data
├── Tools/
│   ├── EmployeeTools/
│   │   └── EmployeeTools.cs          # Employee query MCP tool
│   ├── Calculation/
│   │   └── CalculatorTools.cs        # Math calculation MCP tools
│   └── RandomNumberTools.cs          # Random number MCP tool
├── appsettings.json                  # Database connection string and app config
├── Program.cs                        # Application entry point & MCP server setup
└── FirstMCPHttpServer.csproj         # Project configuration (.NET 10.0)
```

---

## 📋 Prerequisites

Before running the project, ensure you have:

- [.NET 10.0 SDK](https://dotnet.microsoft.com/download)
- [Microsoft SQL Server](https://www.microsoft.com/sql-server) or SQL Server Express / LocalDB
- [dotnet-ef CLI tool](https://learn.microsoft.com/ef/core/cli/dotnet) (optional, for applying migrations):
  ```bash
  dotnet tool install --global dotnet-ef
  ```

---

## ⚙️ Configuration & Setup

### 1. Clone the Repository

```bash
git clone https://github.com/MuthuprabhuB/FirstMCPHttpServer-.git
cd FirstMCPHttpServer-/FirstMCPHttpServer
```

### 2. Configure Database Connection

Update the SQL Server connection string in `appsettings.json` to point to your database instance:

```json
{
  "ConnectionStrings": {
    "EmployeeDb": "Server=localhost;Database=EmployeeMCPDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

### 3. Apply Database Migrations

Apply the included EF Core migrations to initialize the `EmployeeMCPDB` database and `Employees` table:

```bash
dotnet ef database update
```

*(Optional)* Seed sample data into the `Employees` table in your SQL Server database:

```sql
USE EmployeeMCPDB;
INSERT INTO Employees (Name, Department, Salary)
VALUES 
  ('Alice Johnson', 'Engineering', 95000.00),
  ('Bob Smith', 'Marketing', 75000.00),
  ('Charlie Davis', 'Human Resources', 68000.00);
```

---

## 🏃 Running the Server

Start the application using the .NET CLI:

```bash
dotnet run
```

The MCP HTTP server will launch and listen on:
- **Base URL**: `http://localhost:3001`
- **MCP Endpoint**: `http://localhost:3001/mcp`

---

## 🔌 Connecting MCP Clients

You can configure your favorite AI assistant or MCP client to connect to this server.

### VS Code / Claude Desktop / Cursor / Antigravity

Add the server to your MCP configuration file (`mcp.json` / `claude_desktop_config.json`):

```json
{
  "mcpServers": {
    "FirstMCPHttpServer": {
      "url": "http://localhost:3001/mcp"
    }
  }
}
```

> **Note**: For clients using SSE or stream transports, configure the type as HTTP or SSE pointing to `http://localhost:3001/mcp`.

---

## 🧪 Example Prompts for AI Clients

Once connected to your MCP client, test the tools with queries like:

- **Employee Tool**:
  > *"Fetch the details for employee ID 1."*
- **Calculator Tools**:
  > *"What is 245 multiplied by 18?"*
  > *"Calculate (150 + 75) / 5 using the calculator tools."*
- **Random Number Tool**:
  > *"Generate a random number between 50 and 500."*

---

## 🧰 Technology Stack

- **Platform**: [.NET 10](https://dotnet.microsoft.com/) / ASP.NET Core
- **MCP Framework**: [ModelContextProtocol.AspNetCore](https://www.nuget.org/packages/ModelContextProtocol.AspNetCore) (v2.4.0)
- **ORM**: [Entity Framework Core](https://learn.microsoft.com/ef/core/) (v10.0.15)
- **Database**: Microsoft SQL Server

---

## 📄 License

This project is licensed under the MIT License - see the LICENSE file for details.
