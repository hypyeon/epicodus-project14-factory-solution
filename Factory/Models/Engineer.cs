using System.Collections.Generic;

namespace Factory.Models
{
  public class Engineer
  {
    public int EngineerId { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public string HiredDate { get; set; }
    public List<Machine> Machines { get; set; }
    public List<EngineerLicense> JoinEntities { get; }
  }
}