using Commander.Models;

// data is our repository
namespace Commander.Data
{
    // Interface defining data operations for Command objects.
    // Since we are building a CRUD app, our repository interface imitates the CRUD dunctionalities
    public interface ICommanderRepo
    {
        //every time you make change via dbcontext, the data won't be changed in db unless you use SaveChanges()
        bool SaveChanges();

        // Retrieves all Command objects.
        IEnumerable<Command> GetAllCommands();

        // Retrieves a Command object by its ID.
        Command GetCommandById(int id);
        // Create a Command object (POST)
        void CreateCommand(Command cmd);
        // PUT
        void UpdateCommand(Command cmd);
        //DELETE
        void DeleteCommand(Command cmd);
    }
}
