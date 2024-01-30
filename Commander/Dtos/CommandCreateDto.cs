using System.ComponentModel.DataAnnotations;

namespace Commander.Dtos
{
  public class CommandCreateDtos
  {
    [Required]
    public string HowTo { get; set; } = string.Empty;
    [Required]
    public string Line { get; set; } = string.Empty;
    [Required]
    public string PlatForm { get; set; } = string.Empty;

  }
}