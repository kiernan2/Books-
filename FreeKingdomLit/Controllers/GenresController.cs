using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FreeKingdomLit.Models;
using System.Collections.Generic;
using System.Linq;

namespace FreeKingdomLit.Controllers
{
  public class GenresController : Controller
  {

    private readonly FreeKingdomLitContext _db;

    public GenresController(FreeKingdomLitContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Genre> genres = _db.Genres.ToList();
      return View(genres);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Genre genre)
    {
      _db.Genres.Add(genre);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    // [HttpGet("/Genres/{id}")]
    // public ActionResult Details(int id)
    // {
    //   Genre genre = Genre.GetGenre(id);
    //   return View(genre);
    // }

    // [HttpGet("/Genres/{id}/Edit")]
    // public ActionResult Edit(int id)
    // {
    //   Genre genre = Genre.GetGenre(id);
    //   return View(genre);
    // }

    // [HttpPost("/Genres/{id}/Edit")]
    // public ActionResult Edit(string name, int id)
    // {
    //   Genre genre = Genre.GetGenre(id);
    //   genre.Name = name;
    //   return RedirectToAction("Details", new {id});
    // }

    // [HttpGet("/Genres/{id}/Delete")]
    // public ActionResult Delete(int id)
    // {
    //   Genre genre = Genre.GetGenre(id);
    //   return View(genre);
    // }

    // [HttpPost("/Genres/Delete"), ActionName("Delete")]
    // public ActionResult DeleteConfirmed(int id)
    // {
    //   Genre genre = Genre.GetGenre(id);
    //   Genre._instances.Remove(genre);
    //   return RedirectToAction("Index");
    // }
  }
}