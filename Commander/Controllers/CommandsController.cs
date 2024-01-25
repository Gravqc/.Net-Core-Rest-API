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
        // HTTP GET method to retrieve all command items.
        // When called, it should return an enumerable collection of Command objects.
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands()// IEnumerable<> can be thought of as a list/collection of objects
        {
            
        }

        // HTTP GET method to retrieve a single command item by its ID.
        // The 'id' parameter in the route is used to fetch the specific command.
        [HttpGet("{id}")]
        public ActionResult<Command> GetCommandById(int id)
        {
            
        }
    }
}
