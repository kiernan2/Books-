using Microsoft.AspNetCore.Mvc;
using FreeKingdomLit.Models;
using System.Collections.Generic;

namespace FreeKingdomLit.Controllers
{
  public class BooksController : Controller
  {
    [HttpGet("/Books/")]
    public ActionResult Index()
    {
      List<Book> newlist = Book._instances;
      return View(newlist);
    }

    [HttpGet("/Books/new")]
    public ActionResult Create()
    {
      return View();
    }

    [HttpPost("/Books/Create")]
    public ActionResult Create(string title, int pageNumber)
    {
      Book book = new Book(title, pageNumber);
      return RedirectToAction("Index");
    }

    [HttpGet("/Books/{id}")]
    public ActionResult Details(int id)
    {
      Book book = Book.GetBook(id);
      return View(book);
    }

    [HttpGet("/Books/{id}/Edit")]
    public ActionResult Edit(int id)
    {
      Book book = Book.GetBook(id);
      return View(book);
    }

    [HttpPost("/Books/{id}/Edit")]
    public ActionResult Edit(string title, int pageNumber , int id)
    {
      Book book = Book.GetBook(id);
      book.Title = title;
      book.Pages = pageNumber;
      return RedirectToAction("Details", new {id});
    }

    [HttpGet("/Books/{id}/Delete")]
    public ActionResult Delete(int id)
    {
      Book book = Book.GetBook(id);
      return View(book);
    }

    [HttpPost("/Books/Delete"), ActionName("Delete")]
    public ActionResult DeleteConfirmed (int id)
    {
      Book book = Book.GetBook(id);
      Book._instances.Remove(book);
      return RedirectToAction("Index");
    }
  }
}