using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
  // API controller for 'commands' routes.
  [Route("api/commands")]
  [ApiController]
  public class CommandsController : ControllerBase
  {
    // Repository for command data operations, injected via DI.
    private readonly ICommanderRepo _repository;
    private readonly IMapper _mapper;

    // Constructor injecting ICommanderRepo.
    public CommandsController(ICommanderRepo repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    // GET: api/commands - Retrieves all commands.
    [HttpGet]
    public ActionResult<IEnumerable<CommandReadDtos>> GetAllCommands()
    {
      var commandItems = _repository.GetAllCommands();
      return Ok(_mapper.Map<IEnumerable<CommandReadDtos>>(commandItems));
    }

    // GET: api/commands/{id} - Retrieves a command by ID.
    [HttpGet("{id}", Name ="GetCommandById")]
    public ActionResult<CommandReadDtos> GetCommandById(int id)
    {
      // Correct the method name to match the updated one in the interface
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
    //POST api/commands
    [HttpPost]
    public ActionResult<CommandReadDtos> CreateCommand(CommandCreateDtos commandCreateDto)
    {
      var commandModel = _mapper.Map<Command>(commandCreateDto);
      _repository.CreateCommand(commandModel);
      _repository.SaveChanges();

      var commandReadDto = _mapper.Map<CommandReadDtos>(commandModel);

      return CreatedAtRoute(nameof(GetCommandById), new {Id = commandReadDto.Id}, commandReadDto);

    }

  }
}
