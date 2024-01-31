namespace Commander.Dtos
{
  public class CommandReadDtos
  {
    //Maps to our internal Command model
    public int Id { get; set; }
    public string HowTo { get; set; } = string.Empty;
    public string Line { get; set; } = string.Empty;
  
    // public string Platform { get; set; } //we can remove this if we don't want to show it to client
    
  }
}