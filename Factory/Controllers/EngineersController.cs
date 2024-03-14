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
      return View();
    }

    [HttpPost]
    public ActionResult Create(Engineer eng)
    {
      _db.Engineers.Add(eng);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Engineer eng = _db.Engineers
        .Include(e => e.Machines)
        .FirstOrDefault(e => e.EngineerId == id);
      return View(eng);
    }

    public ActionResult Edit(int id)
    {
      Engineer eng = _db.Engineers.FirstOrDefault(e => e.EngineerId == id);
      var jobTitles = new List<SelectListItem>
      {
        new SelectListItem { Value = "Intern", Text = "Intern" },
        new SelectListItem { Value = "Junior Engineer", Text = "Junior Engineer" },
        new SelectListItem { Value = "Senior Engineer", Text = "Senior Engineer" },
        new SelectListItem { Value = "Engineering Lead", Text = "Engineering Lead" }
      };
      ViewBag.JobTitles = jobTitles;
      return View(eng);
    }

    [HttpPost]
    public ActionResult Edit(Engineer eng)
    {
      _db.Engineers.Update(eng);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = eng.EngineerId });
    }

    public ActionResult Delete(int id)
    {
      Engineer eng = _db.Engineers
        .FirstOrDefault(e => e.EngineerId == id);
      if (eng == null)
      {
        return NotFound();
      }
      return View(eng);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteCompleted(int id)
    {
      Engineer eng = _db.Engineers
        .FirstOrDefault(e => e.EngineerId == id);
      _db.Engineers.Remove(eng);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}