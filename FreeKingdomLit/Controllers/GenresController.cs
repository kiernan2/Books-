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

    [HttpGet("/Genres/new")]
    public ActionResult Create()
    {
      return View();
    }

    [HttpPost("/Genres/Create")]
    public ActionResult Create(string name)
    {
      Genre genre = new Genre(name);
      return RedirectToAction("Index");
    }

    [HttpGet("/Genres/{id}")]
    public ActionResult Details(int id)
    {
      Genre genre = Genre.GetGenre(id);
      return View(genre);
    }

    [HttpGet("/Genres/{id}/Edit")]
    public ActionResult Edit(int id)
    {
      Genre genre = Genre.GetGenre(id);
      return View(genre);
    }

    [HttpPost("/Genres/{id}/Edit")]
    public ActionResult Edit(string name, int id)
    {
      Genre genre = Genre.GetGenre(id);
      genre.Name = name;
      return RedirectToAction("Details", new {id});
    }

    [HttpGet("/Genres/{id}/Delete")]
    public ActionResult Delete(int id)
    {
      Genre genre = Genre.GetGenre(id);
      return View(genre);
    }

    [HttpPost("/Genres/Delete"), ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Genre genre = Genre.GetGenre(id);
      Genre._instances.Remove(genre);
      return RedirectToAction("Index");
    }
  }
}