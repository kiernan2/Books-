using System.Collections.Generic;

namespace FreeKingdomLit.Models
{
  public class Book
  {
    public int BookId { get; set; }
    public string Title { get; set; }
    public int Pages { get; set; }
    public virtual ICollection<BookGenre> JoinEntities { get; }

    public Book()
    {
      this.JoinEntities = new HashSet<BookGenre>();
    } 
  }
}