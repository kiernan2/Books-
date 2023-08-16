using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FreeKingdomLit.Models;
using System.Collections.Generic;
using System.Linq;

namespace FreeKingdomLit.Controllers
{
  public class HomeController : Controller
  {
    private readonly FreeKingdomLitContext _db;

    public HomeController(FreeKingdomLitContext db)
    {
      _db = db;
    }

    [Route("/")]
    public ActionResult Index()
    {
      List<Genre> genreList = _db.Genres.ToList();
      ViewBag.GenreList = genreList;
      List<Book> bookList = _db.Books.ToList();
      return View(bookList);
    }
  }
}