using Microsoft.EntityFrameworkCore;

namespace FreeKingdomLit.Models
{
  public class FreeKingdomLitContext : DbContext
  {
    public DbSet<Book> Books { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<BookGenre> BooksGenres { get; set; }

    public FreeKingdomLitContext(DbContextOptions options) : base(options)
    {
      
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}