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
    [Required(ErrorMessage = "Please select a date.")]
    public string HiredDate { get; set; }
    public List<EngineerMachine> AssignedMachines { get; }
  }
}