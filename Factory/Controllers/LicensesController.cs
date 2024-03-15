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
  }
}