namespace FreeKingdomLit.Models
{
  public class Book
  {
    public string Title { get; set; }
    public int Pages { get; set; }

    public Book(string title,int pages)
    {
      Title = title;
      Pages = pages;
    }
  }
}