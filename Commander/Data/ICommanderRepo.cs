// THis is the interface: A list of methods we are providing the end user
using Commander.Models;

namespace Commander.Data
{
  public interface ICommanderRepo
  {
    // Give me a list of all command objects
    // In the interface we just define the operations/methods available via the interface
    IEnumerable<Command> GetAllCommands();
    Command GetCommanById(int id);
  }
}