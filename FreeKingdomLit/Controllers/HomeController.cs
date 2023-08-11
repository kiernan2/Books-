using Microsoft.AspNetCore.Mvc;
using FreeKingdomLit.Models;
using System.Collections.Generic;

namespace FreeKingdomLit.Controllers
{
  public class HomeController : Controller
  {
    [Route("/")]
    public ActionResult Index()
    {
      List<Genre> genreList = Genre._instances;
      ViewBag.GenreList = genreList;
      List<Book> bookList = Book._instances;
      return View(bookList);
    }
  }
}