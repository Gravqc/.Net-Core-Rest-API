using Commander.Data;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
  // Defines the route for this controller as 'api/commands'.
  // Marks this class as an API controller with specific behaviors like automatic HTTP 400 responses.
  [Route("api/commands")]
  [ApiController]
  public class CommandsController : ControllerBase
  {
    // A private read-only field that holds a reference to the ICommanderRepo.
    private readonly ICommanderRepo _repository;
    // The constructor for the CommandsController class.
    // It takes an ICommanderRepo as a parameter, which is provided by ASP.NET Core's dependency injection system.
    // This approach allows for decoupling the controller from a specific implementation of ICommanderRepo, enhancing testability and flexibility.
    public CommandsController(ICommanderRepo repository)
    {
      _repository = repository;
    }
    // Creates an instance of MockCommanderRepo to simulate data storage and retrieval.
    // This mock repository is used for demonstration and testing purposes.

    // HTTP GET method to retrieve all command items.
    // When called, it should return an enumerable collection of Command objects.
    [HttpGet]
    public ActionResult<IEnumerable<Command>> GetAllCommands() // IEnumerable<> can be thought of as a list/collection of objects
    {
      // Retrieves all command items from the repository.
      var CommandItems = _repository.GetAllCommands(); // 'var' is used because the type is determined by the return value of GetAppCommands()

      // Returns an 'Ok' response (200 status code) along with the retrieved command items.
      return Ok(CommandItems);
    }

    // HTTP GET method to retrieve a single command item by its ID.
    // The 'id' parameter in the route is used to fetch the specific command.
    [HttpGet("{id}")]
    public ActionResult<Command> GetCommandById(int id)
    {
      // Retrieves a command item by its ID from the repository.
      var CommandItem = _repository.GetCommanById(id); // The method's return type determines the type of CommandItem

      // Returns an 'Ok' response (200 status code) along with the retrieved command item.
      return Ok(CommandItem);
    }
  }
}
