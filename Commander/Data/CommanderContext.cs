using Commander.Models;
using Microsoft.EntityFrameworkCore;

namespace Commander.Data
{
    // Entity Framework DbContext for Commander application.
    public class CommanderContext : DbContext
    {
        // Constructor injecting configuration options for the DbContext.
        public CommanderContext(DbContextOptions<CommanderContext> opt) : base(opt)
        {
        }

        // DbSet for 'Command' entities, representing the Commands table in the database.
        public DbSet<Command> Commands { get; set; }
    }
}
