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
      List<Machine> model = _db.Machines
        .Include(m => m.Engineer)
        .ToList();
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
      if (mac.EngineerId == 0)
      {
        return RedirectToAction("Create");
      }
      _db.Machines.Add(mac);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Machine mac = _db.Machines
        .Include(m => m.Engineer)
        .FirstOrDefault(m => m.MachineId == id);
      return View(mac);
    }

    public ActionResult Edit(int id)
    {
      Machine mac = _db.Machines
        .FirstOrDefault(m => m.MachineId == id);
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
      var difficulties = new List<SelectListItem>
      {
        new SelectListItem { Value = "Beginner", Text = "Beginner" },
        new SelectListItem { Value = "Intermediate", Text = "Intermediate" },
        new SelectListItem { Value = "Advanced", Text = "Advanced" }
      };
      ViewBag.Difficulties = difficulties;
      return View(mac);
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
      Machine mac = _db.Machines
        .FirstOrDefault(m => m.MachineId == id);
      return View(mac);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteCompleted(int id)
    {
      Machine mac = _db.Machines
        .FirstOrDefault(m => m.MachineId == id);
      _db.Machines.Remove(mac);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}