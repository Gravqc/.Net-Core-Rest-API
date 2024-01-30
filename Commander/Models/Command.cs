using System.ComponentModel.DataAnnotations;

namespace Commander.Models
{
  public class Command
  {
    [Key]
    public int Id { get; set; }
    [Required]
    public string HowTo { get; set; } = string.Empty;
    [Required]
    public string Line { get; set; } = string.Empty;
    [Required]
    public string PlatForm { get; set; } = string.Empty;
  }
}