using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models
{
  public class Engineer
  {
    public int EngineerId { get; set; }
    [Required(ErrorMessage = "Engineer's name should have a value.")]
    public string Name { get; set; }
    public string Title { get; set; }
    public string HiredDate { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "You must assign this engineer to a machine.")]
    public List<EngineerMachine> AssignedMachines { get; }
  }
}