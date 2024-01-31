using Commander.Models;
// read repo
// Implementation class of ICommanderRepo using DbContext.
namespace Commander.Data
{
    // Repository for Command entities using Entity Framework Core.
    public class SqlCommanderRepo : ICommanderRepo
    {
        // Database context for data operations, injected via DI.
        private readonly CommanderContext _context;

        //Constructor injection: our dependency injection system will populate this 'context' variable with db data
        public SqlCommanderRepo(CommanderContext context)
        {
            _context = context;
        }

        //adds a command obj to our _context db, saving is needed afterwards
        public void CreateCommand(Command cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.Commands.Add(cmd);
        }

        //DELETE endpoint (no need dto)
        public void DeleteCommand(Command cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            //remove command
            _context.Commands.Remove(cmd);
        }

        // Retrieves all Command entities from the database.
        public IEnumerable<Command> GetAllCommands()
        {
            return _context.Commands.ToList();
        }

        // Retrieves a Command entity by its ID.
        public Command GetCommandById(int id)
        {
            //FirstOrDefault = LINQ command
            return _context.Commands.FirstOrDefault(p => p.Id == id);
        }

        //every time you make change via dbcontext, the data won't be changed in db unless you use SaveChanges()
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        //PUT endpoint
        public void UpdateCommand(Command cmd)
        {
            //nothing
        }
    }
}
