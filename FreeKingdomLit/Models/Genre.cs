using System.Collections.Generic;

namespace FreeKingdomLit.Models
{
  public class Genre
  {
    public int GenreId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<BookGenre> JoinEntities { get; }

    public Genre()
    {
      this.JoinEntities = new HashSet<BookGenre>();
    }
  }
}
