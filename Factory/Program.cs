using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Factory.Models;
using Microsoft.EntityFrameworkCore;

namespace Factory
{
  class Program
  {
    static void Main(string[] args)
    {
      WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

      builder.Services.AddControllersWithViews();

      builder.Services.AddDbContext<FactoryContext>(
        DbContextOptions => DbContextOptions
          .UseMySql(
              builder.Configuration["ConnectionStrings:DefaultConnection"], 
              ServerVersion.AutoDetect(builder.Configuration["ConnectionStrings:DefaultConnection"]
            )
          )
      );

      WebApplication app = builder.Build();

      app.UseHttpsRedirection();
      app.UseStaticFiles();

      app.UseRouting();

      app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
      );

      app.Run();
    }
  }
}
