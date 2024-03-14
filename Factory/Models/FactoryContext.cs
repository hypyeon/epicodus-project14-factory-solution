using Microsoft.EntityFrameworkCore;

namespace Factory.Models
{
  public class FactoryContext : DbContext
  {
    public DbSet<Engineer> Engineers { get; set; }
    public DbSet<Machine> Machiness { get; set; }

    public FactoryContext(DbContextOptions options) : base(options) { }
  }
}