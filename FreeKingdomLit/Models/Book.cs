using System.Collections.Generic;

namespace FreeKingdomLit.Models
{
  public class Book
  {
    public int BookId { get; set; }
    public string Title { get; set; }
    public int Pages { get; set; }
    public static List<Book> _instances = new List<Book>();

    public Book(string title,int pages)
    {
      _instances.Add(this);
      BookId = _instances.Count;
      Title = title;
      Pages = pages;
    }

    public static Book GetBook(int id)
    {
      return _instances[id - 1];
    }
  }
}