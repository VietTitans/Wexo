using Newtonsoft.Json;

namespace Webapplication.Models;

public class MediaDetailsGenreId
{
    [JsonProperty("id")]
    public int Id { get; init; }
    [JsonProperty("name")]
    public string Name { get; init; }
}
