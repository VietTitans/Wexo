using Newtonsoft.Json;

namespace Webapplication.Models;

public class MediaDetailsGenreId
{
    [JsonProperty("id")]
    public int Id { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }
}
