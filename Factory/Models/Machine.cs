using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models
{
  public class Machine
  {
    public int MachineId { get; set; }
    [Required(ErrorMessage = "Name of machine should have a value.")]
    public string Name { get; set; }
    public string Difficulty { get; set; }
    public List<EngineerMachine> AssignedEngineers { get; }
  }
}