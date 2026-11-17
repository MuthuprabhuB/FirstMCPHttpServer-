using Microsoft.Extensions.AI;
using ModelContextProtocol.Client;
using OllamaSharp;

Console.WriteLine("=== Starting AI MCP Host ===");

// 1. Connect to Ollama AI model
IChatClient chatClient = new OllamaApiClient(
    new Uri("http://localhost:11434/"),
    "qwen2.5:3b");

// 2. Enable automatic function/tool calling
chatClient = chatClient
    .AsBuilder()
    .UseFunctionInvocation()
    .Build();

// 3. Connect to your running MCP Server
var transport = new HttpClientTransport(
    new HttpClientTransportOptions
    {
        Endpoint = new Uri("http://localhost:3001/mcp"),
        TransportMode = HttpTransportMode.StreamableHttp
    });

Console.WriteLine("Connecting to MCP Server at http://localhost:3001/mcp...");
await using var mcpClient = await McpClient.CreateAsync(transport);

// 4. Discover tools provided by the MCP server
var tools = await mcpClient.ListToolsAsync();
Console.WriteLine($"\nDiscovered {tools.Count} MCP Tools:");
foreach (var tool in tools)
{
    Console.WriteLine($" - {tool.Name}: {tool.Description}");
}

// 5. Build conversation prompt
var messages = new List<ChatMessage>
{
    new(ChatRole.System,
        "You are an employee management assistant. " +
        "Always use the available MCP tools to find employee details such as name, department, or salary. " +
        "After receiving the tool result, answer the user's question clearly."),
    new(ChatRole.User,
        "Find the employee with ID 1 and  tell me their salary.")
};

Console.WriteLine("\nAsking AI: \"Find the employee with ID 1 and  tell me their salary.\"");
Console.WriteLine("Waiting for AI response (model may invoke MCP tool)...\n");

// 6. Invoke AI with MCP tools attached
var response = await chatClient.GetResponseAsync(
    messages,
    new ChatOptions
    {
        Tools = [.. tools],
        Temperature = 0.0f
    });

Console.WriteLine("=== AI Response ===");
Console.WriteLine(response.Text);

Console.WriteLine("\nPress Enter to exit...");
Console.ReadLine();
