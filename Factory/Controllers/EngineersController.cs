using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Factory.Controllers
{
  public class EngineersController : Controller
  {
    private readonly FactoryContext _db;

    public EngineersController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Engineer> model = _db.Engineers.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      var jobTitles = new List<SelectListItem>
      {
        new SelectListItem { Value = "Intern", Text = "Intern" },
        new SelectListItem { Value = "Junior Engineer", Text = "Junior Engineer" },
        new SelectListItem { Value = "Senior Engineer", Text = "Senior Engineer" },
        new SelectListItem { Value = "Engineering Lead", Text = "Engineering Lead" }
      };
      ViewBag.JobTitles = jobTitles;
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Engineer en)
    {
      if (!ModelState.IsValid)
      {
        return View(en);
      }
      else {
        _db.Engineers.Add(en);
        _db.SaveChanges();
        return RedirectToAction("Details", new { id = en.EngineerId });
      }
    }

    public ActionResult Details(int id)
    {
      Engineer engineer = _db.Engineers
        .Include(en => en.AssignedMachines)
        .ThenInclude(join => join.Machine)
        .FirstOrDefault(en => en.EngineerId == id);
      return View(engineer);
    }

    public ActionResult Edit(int id)
    {
      Engineer engineer = _db.Engineers.FirstOrDefault(en => en.EngineerId == id);
      var jobTitles = new List<SelectListItem>
      {
        new SelectListItem { Value = "Intern", Text = "Intern" },
        new SelectListItem { Value = "Junior Engineer", Text = "Junior Engineer" },
        new SelectListItem { Value = "Senior Engineer", Text = "Senior Engineer" },
        new SelectListItem { Value = "Engineering Lead", Text = "Engineering Lead" }
      };
      ViewBag.JobTitles = jobTitles;
      return View(engineer);
    }

    [HttpPost]
    public ActionResult Edit(Engineer en)
    {
      _db.Engineers.Update(en);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = en.EngineerId });
    }

    public ActionResult Delete(int id)
    {
      Engineer engineer = _db.Engineers
        .FirstOrDefault(en => en.EngineerId == id);
      return View(engineer);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteCompleted(int id)
    {
      Engineer engineer = _db.Engineers
        .FirstOrDefault(en => en.EngineerId == id);
      _db.Engineers.Remove(engineer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddMachine(int id)
    {
      Engineer engineer = _db.Engineers.FirstOrDefault(en => en.EngineerId == id);
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
      return View(engineer);
    }

    [HttpPost]
    public ActionResult AddMachine(Engineer en, int macId)
    {
      #nullable enable
      EngineerMachine? joinEntity = _db.EngineerMachines
        .FirstOrDefault(join => 
          (join.MachineId == macId && join.EngineerId == en.EngineerId)
        );
      #nullable disable
      if (joinEntity == null && macId != 0)
      {
        _db.EngineerMachines.Add(
          new EngineerMachine() {
            MachineId = macId, EngineerId = en.EngineerId
          }
        );
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = en.EngineerId });
    }
  }
}