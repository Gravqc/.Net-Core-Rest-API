using System.ComponentModel.DataAnnotations;

namespace Commander.Dtos
{
  public class CommandUpdateDto
  {
     //Maps to our internal Command model
    [Required]
    public string HowTo { get; set; } = string.Empty;
    [Required]
    public string Line { get; set; } = string.Empty;
    [Required]
    public string PlatForm { get; set; } = string.Empty;

  }
}