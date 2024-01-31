using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

//Decoupling: We use this controller to access the repository's implemented class. Then that class accesses the database.

namespace Commander.Controllers
{
  //The [] are attributes: declarative tags to give runtime info for the whole class
  //controller level route (base route): how you get to resources/api endpoints
  //Route(".."): matches URI to an action -->  will use the routing path from actions
  [Route("api/commands")]
  [ApiController] //gives out of the box behaviours (makes life easier)
  public class CommandsController : ControllerBase
  {
    //declaring interface repo
    //readonly = allows variable to be calculated at runtime | const = must have value at compile time
    //_ (underscore) indicates private (naming convention)
    private readonly ICommanderRepo _repository;
    // AutoMapper Instance.
    private readonly IMapper _mapper;

    //Constructor: dependency is injected into 'repository' variable
    //Also: injects an instance of AutoMapper object
    public CommandsController(ICommanderRepo repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    // desc of the opration on swaggerui
    [SwaggerOperation(Summary ="Get all the commands")]
    // GET: api/commands - Retrieves all commands.
    [HttpGet]
    //create first action result endpoint
    public ActionResult<IEnumerable<CommandReadDtos>> GetAllCommands()
    {
      var commandItems = _repository.GetAllCommands();
      //return HTTP 200 OK result + commandItems
      return Ok(_mapper.Map<IEnumerable<CommandReadDtos>>(commandItems));
    }

    [SwaggerOperation(Summary ="Get the Command by the given Id ")]  
    //putting {id} gives us a route to this action result, respond to: "GET api/commands/5"
    [HttpGet("{id}", Name = "GetCommandById")] //since this one and above both respond to GET (same verb), their URI must be differentiated
    public ActionResult<CommandReadDtos> GetCommandById(int id) // This 'id' comes from the request we pass via the URL using PostMan.
                                                                // Model Binding: because we set [ApiController]: using default behaviour, id will come from [FromBody]
    {
      var commandItem = _repository.GetCommandById(id);
      if (commandItem != null)
      {
        return Ok(_mapper.Map<CommandReadDtos>(commandItem));
      }
      else
      {
        return NotFound();
      }
    }

    [SwaggerOperation(Summary ="Create a new Command, by passing 3 different attributes, 'How To' is the Command description, 'Line' is the cli code, 'PlatForm' is the application platform")]
    //POST api/commands
    [HttpPost]
    public ActionResult<CommandReadDtos> CreateCommand(CommandCreateDtos commandCreateDto)
    {
      // Source -> Target
      var commandModel = _mapper.Map<Command>(commandCreateDto);
      _repository.CreateCommand(commandModel);
      _repository.SaveChanges();
      // return a dto instread
      var commandReadDto = _mapper.Map<CommandReadDtos>(commandModel);

      //should also be sending back URI + HTTP 201 (REST principle)
      return CreatedAtRoute(nameof(GetCommandById), new { Id = commandReadDto.Id }, commandReadDto);

      //return Ok(commandReadDto);  --> returns 200
    }

    [SwaggerOperation(Summary ="Replace the command of the given Id with a new command specified by you")]
    //PUT api/commands/{id}
    //Since we only return http 204, return type = ActionResult
    [HttpPut("{id}")]
    public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
    {
      // check if model exists
      var commandModelFromRepo = _repository.GetCommandById(id);
      if (commandModelFromRepo == null)
      {
        return NotFound();
      }
      //maps the newly created model to the requested one from repo --> updates dbcontext directly
      _mapper.Map(commandUpdateDto, commandModelFromRepo);

      _repository.UpdateCommand(commandModelFromRepo);

      // flush changes to db
      _repository.SaveChanges();

      // return 204 no content
      return NoContent();
    }

    [SwaggerOperation(Summary ="Delete a command")]
    //DELETE api/commands/{id}
    [HttpDelete("{id}")]
    public ActionResult DeleteCommand(int id)
    {
      // check if model exits
      var commandModelFromRepo = _repository.GetCommandById(id);
      if (commandModelFromRepo == null)
      {
        return NotFound();
      }
      // delete model
      _repository.DeleteCommand(commandModelFromRepo);
      _repository.SaveChanges();

      return NoContent();
    }

  }
}
