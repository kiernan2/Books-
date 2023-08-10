using System.Collections.Generic;

namespace FreeKingdomLit.Models
{
  public class Genre
  {
    public int GenreId { get; set; }
    public string Name { get; set; }
    public static List<Genre> _instances = new List<Genre>();

    public Genre(string name)
    {
      Name = name;
      _instances.Add(this);
      GenreId = _instances.Count;
    }

    public static Genre GetGenre(int id)
    {
      return _instances[id - 1];
    }
  }
}
