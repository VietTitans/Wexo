using Newtonsoft.Json;

namespace Webapplication.Models;

public class Movie : Media
{
    /// <summary>
    /// Properties correponse to the GET request https://developer.themoviedb.org/reference/discover-movie
    /// with additional properties.
    /// This allows for future feature functionality extensions.
    /// </summary>

    public List<string> ActorsList { get; set; }
    public List<string> DirectorsList { get; set; }

}
