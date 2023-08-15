using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FreeKingdomLit.Models;
using System.Collections.Generic;
using System.Linq;

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
      List<Book> newlist = _db.Books.ToList();
      return View(newlist);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Book book)
    {
      _db.Books.Add(book);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Book thisBook = _db.Books.FirstOrDefault(book => book.BookId == id);
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

    // [HttpGet("/Books/{id}/Delete")]
    // public ActionResult Delete(int id)
    // {
    //   Book book = Book.GetBook(id);
    //   return View(book);
    // }

    // [HttpPost("/Books/Delete"), ActionName("Delete")]
    // public ActionResult DeleteConfirmed (int id)
    // {
    //   Book book = Book.GetBook(id);
    //   Book._instances.Remove(book);
    //   return RedirectToAction("Index");
    // }
  }
}