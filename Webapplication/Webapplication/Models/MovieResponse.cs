using Newtonsoft.Json;

namespace Webapplication.Models;

public class MovieResponse
{
    [JsonProperty("page")]
    public int Page { get; set; }

    [JsonProperty("results")]
    public List<Media> Results { get; set; }

    [JsonProperty("total_pages")]
    public int TotalPages { get; set; }

    [JsonProperty("total_results")]
    public int TotalResults { get; set; }
}
