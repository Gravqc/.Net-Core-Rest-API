using Commander.Models;

namespace Commander.Data
{
    // Repository for Command entities using Entity Framework Core.
    public class SqlCommanderRepo : ICommanderRepo
    {
        // Database context for data operations, injected via DI.
        private readonly CommanderContext _context;

        // Constructor for dependency injection of database context.
        public SqlCommanderRepo(CommanderContext context)
        {
            _context = context;
        }

        public void CreateCommand(Command cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.Commands.Add(cmd);
        }

        // Retrieves all Command entities from the database.
        public IEnumerable<Command> GetAllCommands()
        {
            return _context.Commands.ToList();
        }

        // Retrieves a Command entity by its ID.
        public Command GetCommandById(int id)
        {
            return _context.Commands.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
