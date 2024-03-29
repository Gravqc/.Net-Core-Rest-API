using Commander.Models;

namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public void CreateCommand(Command cmd)
        {
            throw new NotImplementedException();
        }

        public void DeleteCommand(Command cmd)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
          var commands = new List<Command>
          {
            new Command{Id=0, HowTo="Testh", Line="Testl", PlatForm="Testp"},
            new Command{Id=1, HowTo="Testh2", Line="Testl2", PlatForm="Testp2"},
            new Command{Id=2, HowTo="Testh3", Line="Testl3", PlatForm="Testp3"},
            new Command{Id=3, HowTo="Testh4", Line="Testl4", PlatForm="Testp4"}
          };
          return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command{Id=0, HowTo="Test", Line="Test", PlatForm="Test"};
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateCommand(Command cmd)
        {
            throw new NotImplementedException();
        }
    }
}