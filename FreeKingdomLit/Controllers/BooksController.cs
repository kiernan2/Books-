using Microsoft.AspNetCore.Mvc;
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

    // [HttpGet("/Books/{id}")]
    // public ActionResult Details(int id)
    // {
    //   Book book = Book.GetBook(id);
    //   return View(book);
    // }

    // [HttpGet("/Books/{id}/Edit")]
    // public ActionResult Edit(int id)
    // {
    //   Book book = Book.GetBook(id);
    //   return View(book);
    // }

    // [HttpPost("/Books/{id}/Edit")]
    // public ActionResult Edit(string title, int pageNumber , int id)
    // {
    //   Book book = Book.GetBook(id);
    //   book.Title = title;
    //   book.Pages = pageNumber;
    //   return RedirectToAction("Details", new {id});
    // }

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