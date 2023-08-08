using Microsoft.AspNetCore.Mvc;
using FreeKingdomLit.Models;

namespace FreeKingdomLit.Controllers
{
  public class BooksController : Controller
  {
    public ActionResult Index()
    {
      Book newbook = new Book("soo", 345);
      return View(newbook);
    }
  }
}