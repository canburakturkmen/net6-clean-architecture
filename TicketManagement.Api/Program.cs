using TicketManagement.Api;

var builder = WebApplication.CreateBuilder(args);

var app = builder
    .ConfigureServices()
    .ConfigurePipeline();

if (builder.Environment.IsDevelopment())
{
    await app.ResetDatabaseAsync();
}

app.Run();

public partial class Program { }