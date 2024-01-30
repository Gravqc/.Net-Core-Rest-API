using Commander.Data;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add basic services and Swagger for API documentation.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency injection setup for ICommanderRepo and CommanderContext.
builder.Services.AddScoped<ICommanderRepo, SqlCommanderRepo>(); // Use SqlCommanderRepo for real implementation.
builder.Services.AddDbContext<CommanderContext>(opt => 
    opt.UseSqlServer(builder.Configuration.GetConnectionString("CommanderConnection"))); // SQL Server configuration.

// Registers AutoMapper for object-to-object mapping, scanning for profiles in all assemblies.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Enable controllers in the application.
builder.Services.AddControllers();

var app = builder.Build();

// Swagger setup for development environment.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware for HTTPS redirection and routing.
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization(); // Enable if using authentication/authorization.

// Configure API endpoints.
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers(); // Map controller actions to routes.
});

app.Run(); // Start the application.
