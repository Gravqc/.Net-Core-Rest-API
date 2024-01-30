using Commander.Models;

namespace Commander.Data
{
    // Interface defining data operations for Command objects.
    public interface ICommanderRepo
    {
        bool SaveChanges();

        // Retrieves all Command objects.
        IEnumerable<Command> GetAllCommands();

        // Retrieves a Command object by its ID.
        Command GetCommandById(int id);
        
        void CreateCommand(Command cmd);
    }
}
