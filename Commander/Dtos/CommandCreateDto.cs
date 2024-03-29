using System.ComponentModel.DataAnnotations;

namespace Commander.Dtos
{
  //Maps to our internal Command model
  public class CommandCreateDtos
  {
    // public int id { get; set; } --> remove because db will create itself the id number

    //data annotation validators here will require these during creation; in case of error, return 400 instead of 500 to client
    [Required]
    public string HowTo { get; set; } = string.Empty;
    [Required]
    public string Line { get; set; } = string.Empty;
    [Required]
    public string PlatForm { get; set; } = string.Empty;

  }
}