using AutoMapper;
using Commander.Dtos;
using Commander.Models;

namespace Commander.Profiles
{
  //map our Command model to our Dtos
  //inherit base class Profile from AutoMapper namespace
  public class CommandsProfiles : Profile
  {
    public CommandsProfiles()
    {
      //<Source -> Target>
      //automapper: maps from Command & to ReadDto
      CreateMap<Command, CommandReadDtos>();
      //mapping the created dto to an actual command obj
      CreateMap<CommandCreateDtos, Command>();
      //mapping for PUT
      CreateMap<CommandUpdateDto, Command>();
    }
  }
}