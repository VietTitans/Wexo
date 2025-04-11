using Newtonsoft.Json;

namespace Webapplication.Models;

public class MovieResponse
{
    [JsonProperty("page")]
    public int Page { get; init; }

    [JsonProperty("results")]
    public List<Media> Results { get; init; }

    [JsonProperty("total_pages")]
    public int TotalPages { get; init; }

    [JsonProperty("total_results")]
    public int TotalResults { get; init; }
}
