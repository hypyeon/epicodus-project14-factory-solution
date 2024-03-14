using Microsoft.AspNetCore.Mvc;

namespace Factory.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      //ViewBag.PageTitle = "Eau Clair's Hair Salon";
      return View();
    }
  }
}