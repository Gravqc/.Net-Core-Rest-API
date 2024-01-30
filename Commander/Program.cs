using Commander.Data; // Ensure you have using statements for your namespaces
using Commander.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register your repository for dependency injection
builder.Services.AddScoped<ICommanderRepo, MockCommanderRepo>(); // Replace MockCommanderRepo with the actual implementation if needed

// Registers the CommanderContext with the ASP.NET Core dependency injection system.
// Configures the context to use SQL Server as the database provider.
builder.Services.AddDbContext<CommanderContext>(opt => 
opt.UseSqlServer( // Retrieves the database connection string named "CommanderConnection" from the application's configuration.& connectionstring is in appsettings.json
    builder.Configuration.GetConnectionString("CommanderConnection")));

// Add services for controllers (This is important for using controllers)
builder.Services.AddControllers();

// Registers ICommanderRepo and its implementation MockCommanderRepo with the dependency injection system.
// Each time an ICommanderRepo is requested, a new instance of MockCommanderRepo will be provided within the scope of a single request.
builder.Services.AddScoped<ICommanderRepo, MockCommanderRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Enable routing and use controllers (This is crucial for your API endpoints to work)
app.UseRouting();

app.UseAuthorization(); // Add this if you have [Authorize] attributes or plan to use authentication/authorization

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers(); // Maps controllers to their respective routes
});

app.Run();
