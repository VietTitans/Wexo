using Newtonsoft.Json;

namespace Webapplication.Models;

public class TVSerie : Media
{
    public List<int> GenreIds { get; set; }

    [JsonProperty("Name")]
    public string Title { get; set; }
}
