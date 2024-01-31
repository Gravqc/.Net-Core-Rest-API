using Commander.Data;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add basic services and Swagger for API documentation.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency injection setup for ICommanderRepo and CommanderContext.
//Registering service container: whenever ICommanderRepo is asked, give SqlCommanderRepo
//to change implementation, all you have to do is change second parameter!
builder.Services.AddScoped<ICommanderRepo, SqlCommanderRepo>(); // Use SqlCommanderRepo for real implementation.

//Configure our DB context class for use within rest of app; dependency injection support, adds dbcontext to service container
builder.Services.AddDbContext<CommanderContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("CommanderConnection"))); // SQL Server configuration.

// Registers AutoMapper for object-to-object mapping, scanning for profiles in all assemblies.
//makes automapper available through dependency injection to the rest of our app (for DTOs)
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Enable controllers in the application.
builder.Services.AddControllers();

//add swaggergenerator to the services collection
builder.Services.AddSwaggerGen(c =>
            {   
                c.EnableAnnotations();
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Gaurav's Commander API", Version = "v1" });
            });

var app = builder.Build();

// Swagger setup for development environment.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.RoutePrefix = "";
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Commands API v1");
    });
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
