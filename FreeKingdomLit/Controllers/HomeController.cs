using Microsoft.AspNetCore.Mvc;

namespace FreeKingdomLit.Controllers
{
  public class HomeController : Controller
  {
    [Route("/")]
    public ActionResult Index()
    {
      return View();
    }
  }
}