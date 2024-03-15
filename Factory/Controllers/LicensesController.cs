using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Factory.Controllers
{
  public class LicensesController : Controller
  {
    private readonly FactoryContext _db;

    public LicensesController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Licenses.ToList());
    }

    public ActionResult Details(int id)
    {
      License license = _db.Licenses
        .Include(li => li.JoinEntities)
        .ThenInclude(join => join.Engineer)
        .FirstOrDefault(li => li.LicenseId == id);
      return View(license);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(License li)
    {
      _db.Licenses.Add(li);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddEngineer(int id)
    {
      License license = _db.Licenses.FirstOrDefault(li => li.LicenseId == id);
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
      return View(license);
    }

    [HttpPost]
    public ActionResult AddEngineer(License li, int engineerId)
    {
      #nullable enable
      EngineerLicense? joinEntity = _db.EngineerLicenses
        .FirstOrDefault(join => 
          (join.EngineerId == engineerId && join.LicenseId == li.LicenseId)
        );
      #nullable disable
      if (joinEntity == null && engineerId != 0)
      {
        _db.EngineerLicenses.Add(
          new EngineerLicense() {
            EngineerId = engineerId, LicenseId = li.LicenseId
          }
        );
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = li.LicenseId });
    }
  }
}