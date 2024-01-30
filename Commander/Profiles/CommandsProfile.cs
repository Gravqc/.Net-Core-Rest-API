using AutoMapper;
using Commander.Dtos;
using Commander.Models;

namespace Commander.Profiles
{
  public class CommandsProfiles : Profile
  {
    public CommandsProfiles()
    {
      //source -> destination
      CreateMap<Command,CommandReadDtos>();
      CreateMap<CommandCreateDtos, Command>();
    }
  }
}