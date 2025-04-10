namespace Webapplication.Models;

public class Genre
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Media>? Items { get; set; } = new List<Media>();
    public int TotalMovieCount { get; set; }
}
    