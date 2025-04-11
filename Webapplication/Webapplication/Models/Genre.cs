namespace Webapplication.Models;

public class Genre
{
    public int Id { get; init; }
    public string Name { get; init; }
    public List<Media>? Items { get; init; } = new List<Media>();
    public int TotalMovieCount { get; init; }
}
    