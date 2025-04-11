using Newtonsoft.Json;

namespace Webapplication.Models;

public class Media
{
    [JsonProperty("backdrop_path")]
    public string BackdropPath { get; init; }

    [JsonProperty("id")]
    public int Id { get; init; }

    [JsonProperty("title")]
    public string Title { get; init; }

    [JsonProperty("original_title")]
    public string OriginalTitle { get; init; }

    [JsonProperty("overview")]
    public string Description { get; init; }

    [JsonProperty("poster_path")]
    public string PosterPath { get; init; }

    [JsonProperty("media_type")]
    public string MediaType { get; init; }

    [JsonProperty("adult")]
    public bool Adult { get; init; }

    [JsonProperty("original_language")]
    public string OriginalLanguage { get; init; }

    [JsonProperty("genre_ids")]
    public List<int> GenreIds { get; init; }

    [JsonProperty("popularity")]
    public double Popularity { get; init; }

    [JsonProperty("release_date")]
    public string ReleaseDate { get; init; } 

    [JsonProperty("video")]
    public bool Video { get; init; }

    [JsonProperty("vote_average")]
    public double VoteAverage { get; init; }

    [JsonProperty("vote_count")]
    public int VoteCount { get; init; }

    public string Genre { get; init; }
}
