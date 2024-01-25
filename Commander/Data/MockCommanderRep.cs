using Commander.Modles;

namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public IEnumerable<Command> GetAppCommands()
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

        public Command GetCommanById(int id)
        {
            return new Command{Id=0, HowTo="Test", Line="Test", PlatForm="Test"};
        }
    }
}