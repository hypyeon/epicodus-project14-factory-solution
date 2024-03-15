using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;

namespace Factory.Controllers
{
  public class MachinesController: Controller
  {
    private readonly FactoryContext _db;
    public MachinesController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Machine> model = _db.Machines.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
      var difficulties = new List<SelectListItem>
      {
        new SelectListItem { Value = "Beginner", Text = "Beginner" },
        new SelectListItem { Value = "Intermediate", Text = "Intermediate" },
        new SelectListItem { Value = "Advanced", Text = "Advanced" }
      };
      ViewBag.Difficulties = difficulties;
      return View();
    }

    [HttpPost]
    public ActionResult Create(Machine mac)
    {
      _db.Machines.Add(mac);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = mac.MachineId });
    }

    public ActionResult Details(int id)
    {
      Machine machine = _db.Machines
        .Include(mac => mac.AssignedEngineers)
        .ThenInclude(join => join.Engineer)
        .FirstOrDefault(m => m.MachineId == id);
      return View(machine);
    }

    public ActionResult Edit(int id)
    {
      Machine machine = _db.Machines.FirstOrDefault(mac => mac.MachineId == id);
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
      var difficulties = new List<SelectListItem>
      {
        new SelectListItem { Value = "Beginner", Text = "Beginner" },
        new SelectListItem { Value = "Intermediate", Text = "Intermediate" },
        new SelectListItem { Value = "Advanced", Text = "Advanced" }
      };
      ViewBag.Difficulties = difficulties;
      return View(machine);
    }

    [HttpPost]
    public ActionResult Edit(Machine mac)
    {
      _db.Machines.Update(mac);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = mac.MachineId });
    }

    public ActionResult Delete(int id)
    {
      Machine machine = _db.Machines
        .FirstOrDefault(mac => mac.MachineId == id);
      return View(machine);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteCompleted(int id)
    {
      Machine machine = _db.Machines
        .FirstOrDefault(mac => mac.MachineId == id);
      _db.Machines.Remove(machine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddEngineer(int id)
    {
      Machine machine = _db.Machines.FirstOrDefault(mac => mac.MachineId == id);
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
      return View(machine);
    }

    [HttpPost]
    public ActionResult AddEngineer(Machine mac, int enId)
    {
      #nullable enable
      EngineerMachine? joinEntity = _db.EngineerMachines.FirstOrDefault(join => (
        join.EngineerId == enId && join.MachineId == mac.MachineId
      ));
      #nullable disable
      if (joinEntity == null && enId != 0)
      {
        _db.EngineerMachines.Add(
          new EngineerMachine() {
            EngineerId = enId, MachineId = mac.MachineId
          }
        );
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = mac.MachineId });
    }
  }
}