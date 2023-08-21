using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using FreeKingdomLit.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FreeKingdomLit.Controllers
{
  [Authorize]
  public class BooksController : Controller
  {

    private readonly FreeKingdomLitContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public BooksController(FreeKingdomLitContext db, UserManager<ApplicationUser> userManager)
    {
      _userManager = userManager;
      _db = db;
    }

    public async Task<ActionResult> Index()
    {
      string userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
      List<Book> newList = _db.Books.Where(entry => entry.User.Id == currentUser.Id).ToList();
      return View(newList);
    }

    public ActionResult Create()
    {
      ViewBag.GenreId = new SelectList(_db.Genres, "GenreId", "Name");
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(Book book, int genreId)
    {
      string userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
      book.User = currentUser;

      _db.Books.Add(book);
      _db.SaveChanges();
      if (genreId != 0)
      {
        _db.BooksGenres.Add(new BookGenre() { GenreId = genreId, BookId = book.BookId });
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
      ViewBag.GenreId = new SelectList(_db.Genres, "GenreId", "Name");
      return View(thisBook);
    }

    [HttpPost]
    public ActionResult Edit(Book book, int genreId)
    {
      bool duplicate = _db.BooksGenres.Any(join => join.GenreId == genreId && join.BookId == book.BookId);
      if(!duplicate && genreId != 0)
      {
        _db.BooksGenres.Add(new BookGenre() {BookId = book.BookId, GenreId = genreId});
      }
      _db.Entry(book).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", new {id = book.BookId});
    }

    public ActionResult AddGenre(int id)
    {
      Book thisBook = _db.Books.FirstOrDefault(book => book.BookId == id);
      ViewBag.GenreId = new SelectList(_db.Genres, "GenreId", "Name"); 
      return View(thisBook);
    }

    [HttpPost]
    public ActionResult AddGenre(Book book, int genreId)
    {
      bool duplicate = _db.BooksGenres.Any(join => join.GenreId == genreId && join.BookId == book.BookId);
      if (genreId != 0 && !duplicate)
      {
        _db.BooksGenres.Add(new BookGenre() { GenreId = genreId, BookId = book.BookId});
      }
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

    [HttpPost]
    public ActionResult DeleteGenre (int joinId)
    {
      BookGenre thisBookGenre = _db.BooksGenres.FirstOrDefault(join => join.BookGenreId == joinId);
      _db.BooksGenres.Remove(thisBookGenre);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}