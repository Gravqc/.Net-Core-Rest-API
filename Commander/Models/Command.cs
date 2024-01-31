using System.ComponentModel.DataAnnotations;

namespace Commander.Models
{
  public class Command
  {
     //This one doesn't need [Required] because by convention, migration will know that id is primary key (not nullable by nature)
    [Key] //making it primary key
    public int Id { get; set; }
    [Required] //attribute to specify value cannot be numm
    public string HowTo { get; set; } = string.Empty;
    [Required]
    public string Line { get; set; } = string.Empty; //command line snippet we'll store in database
    [Required]
    public string PlatForm { get; set; } = string.Empty; //application platform 
  }
}