namespace Factory.Models
{
  public class Machine
  {
    public int MachineId { get; set; }
    public string Name { get; set; }
    public string Difficulty { get; set; }
    public int EngineerId { get; set; }
    public Engineer Engineer { get; set; }
  }
}