using Commander.Models;
using Microsoft.EntityFrameworkCore;

namespace Commander.Data
{
  // CommanderContext class, inheriting from DbContext, part of the Entity Framework Core.
  // DbContext instances represent a session with the database, allowing for querying and saving data.
  public class CommanderContext : DbContext
  {
    // Constructor for CommanderContext.
    // Takes DbContextOptions of type CommanderContext as a parameter, which includes configuration options like the database provider, connection string, etc.
    // The 'base(opt)' call passes these options to the base DbContext class, which handles the database interactions.
    public CommanderContext(DbContextOptions<CommanderContext> opt) : base(opt)
    {

    }
    // A DbSet representing 'Command' entities.
    // DbSet<Command> corresponds to a table in the database, and each instance of 'Command' will be a row in that table.
    // This property allows querying and saving instances of the 'Command' class.
    public DbSet<Command> Commands { get; set; }

  }
}