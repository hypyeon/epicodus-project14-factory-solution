using System.Collections.Generic;

namespace Factory.Models
{
  public class Machine
  {
    public int MachineId { get; set; }
    public string Name { get; set; }
    public string Difficulty { get; set; }
    public List<EngineerMachine> AssignedEngineers { get; }
  }
}