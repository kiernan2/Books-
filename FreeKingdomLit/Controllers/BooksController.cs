using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FreeKingdomLit.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FreeKingdomLit.Controllers
{
  public class BooksController : Controller
  {

    private readonly FreeKingdomLitContext _db;

    public BooksController(FreeKingdomLitContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Book> newList = _db.Books.ToList();
      return View(newList);
    }

    public ActionResult Create()
    {
      ViewBag.GenreId = new SelectList(_db.Genres, "GenreId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Book book, int genreId)
    {
      _db.Books.Add(book);
      _db.SaveChanges();
      if (genreId != 0)
      {
        _db.BooksGenres.Add(new BookGenre() { GenreId = genreId , BookId = book.BookId });
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Book thisBook = _db.Books
        .Include(book => book.JoinEntities)
          .ThenInclude(join => join.Genre)
        .FirstOrDefault(book => book.BookId == id);
      return View(thisBook);
    }

    public ActionResult Edit(int id)
    {
      Book thisBook = _db.Books.FirstOrDefault(book => book.BookId == id);
      return View(thisBook);
    }

    [HttpPost]
    public ActionResult Edit(Book book)
    {
      _db.Entry(book).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", new {id = book.BookId});
    }

    public ActionResult Delete(int id)
    {
      Book thisBook = _db.Books.FirstOrDefault(book => book.BookId == id);
      return View(thisBook);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed (int id)
    {
      Book thisBook = _db.Books.FirstOrDefault(book => book.BookId == id);
      _db.Books.Remove(thisBook);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}