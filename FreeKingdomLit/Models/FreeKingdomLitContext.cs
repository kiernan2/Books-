using Microsoft.EntityFrameworkCore;

namespace FreeKingdomLit.Models
{
  public class FreeKingdomLitContext : DbContext
  {
    public DbSet<Book> Books { get; set;}
    public DbSet<Genre> Genres { get; set;}

    public FreeKingdomLitContext(DbContextOptions options) : base(options)
    {
      
    }
  }
}