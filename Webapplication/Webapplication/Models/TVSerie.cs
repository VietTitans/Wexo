using Newtonsoft.Json;

namespace Webapplication.Models;

public class TVSerie : Media
{
    public List<int> GenreIds { get; init; }

    [JsonProperty("Name")]
    public string Title { get; init; }
}
