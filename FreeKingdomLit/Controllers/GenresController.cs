using Microsoft.AspNetCore.Mvc;
using FreeKingdomLit.Models;
using System.Collections.Generic;

namespace FreeKingdomLit.Controllers
{
  public class GenresController : Controller
  {
    [HttpGet("/Genres/")]
    public ActionResult Index()
    {
      List<Genre> genres = Genre._instances;
      return View(genres);
    }
  }
}