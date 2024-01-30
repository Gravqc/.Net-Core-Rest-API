using Commander.Models;
using Microsoft.EntityFrameworkCore;

namespace Commander.Data
{
  public class CommanderContext : DbContext
  {
    public CommanderContext(DbContextOptions<CommanderContext> opt) : base(opt)
    {

    }
    // Represent our Command object as a DbSet
    public DbSet<Command> Commands { get; set; }

  }
}