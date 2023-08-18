using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FreeKingdomLit.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering; 

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
      ViewBag.BookId = new SelectList(_db.Books, "BookId", "Title");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Genre genre, int bookId)
    {
      _db.Genres.Add(genre);
      _db.SaveChanges();
      if (bookId != 0)
      {
        _db.BooksGenres.Add(new BookGenre() { BookId = bookId, GenreId = genre.GenreId});
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Genre thisGenre = _db.Genres
        .Include(genre => genre.JoinEntities)
          .ThenInclude(join => join.Book)
        .FirstOrDefault(genre => genre.GenreId == id);
      return View(thisGenre);
    }

    public ActionResult Edit(int id)
    {
      Genre thisGenre = _db.Genres.FirstOrDefault(genre => genre.GenreId == id);
      ViewBag.BookId = new SelectList(_db.Books, "BookId", "Title");
      return View(thisGenre);
    }

    [HttpPost]
    public ActionResult Edit(Genre genre, int bookId)
    {
      bool duplicate = _db.BooksGenres.Any(join => join.BookId == bookId && join.GenreId == genre.GenreId);
      if(!duplicate && bookId != 0)
      {
        _db.BooksGenres.Add(new BookGenre() { GenreId = genre.GenreId, BookId = bookId});
      }
      _db.Entry(genre).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = genre.GenreId });
    }

    public ActionResult AddBook(int id)
    {
      Genre thisGenre = _db.Genres.FirstOrDefault(genre => genre.GenreId == id);
      ViewBag.BookId = new SelectList(_db.Books, "BookId", "Title");
      return View(thisGenre);
    }

    [HttpPost]
    public ActionResult AddBook(Genre genre, int bookId)
    {
      bool duplicate = _db.BooksGenres.Any(join => join.BookId == bookId && join.GenreId == genre.GenreId);
      if (bookId != 0 && !duplicate)
      {
        _db.BooksGenres.Add(new BookGenre() { BookId = bookId, GenreId = genre.GenreId });
      }
      _db.SaveChanges();
      return RedirectToAction("Details", new {id = genre.GenreId});
    }

    public ActionResult Delete(int id)
    {
      Genre genre = _db.Genres.FirstOrDefault(genre => genre.GenreId == id);
      return View(genre);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Genre thisGenre = _db.Genres.FirstOrDefault(genre => genre.GenreId == id);
      _db.Genres.Remove(thisGenre);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}