using Newtonsoft.Json;

namespace Webapplication.Models;

public class MediaDetailsResponse
{
    [JsonProperty("adult")]
    public bool Adult { get; init; }

    [JsonProperty("backdrop_path")]
    public string BackdropPath { get; init; }

    [JsonProperty("budget")]
    public int Budget { get; init; }

    [JsonProperty("genres")]
    public List<MediaDetailsGenreId> Genres { get; init; }

    [JsonProperty("homepage")]
    public string Homepage { get; init; }

    [JsonProperty("id")]
    public int Id { get; init; }

    [JsonProperty("imdb_id")]
    public string ImdbId { get; init; }

    [JsonProperty("origin_country")]
    public List<string> OriginCountry { get; init; }

    [JsonProperty("original_language")]
    public string OriginalLanguage { get; init; }

    [JsonProperty("original_title")]
    public string OriginalTitle { get; init; }

    [JsonProperty("overview")]
    public string Overview { get; init; }

    [JsonProperty("popularity")]
    public double Popularity { get; init; }

    [JsonProperty("poster_path")]
    public string PosterPath { get; init; }

    //[JsonProperty("production_companies")]
    //public List<ProductionCompany> ProductionCompanies { get; init; }

    //[JsonProperty("production_countries")]
    //public List<ProductionCountry> ProductionCountries { get; init; }

    [JsonProperty("release_date")]
    public string ReleaseDate { get; init; }

    [JsonProperty("revenue")]
    public int Revenue { get; init; }

    [JsonProperty("runtime")]
    public int Runtime { get; init; }

    //[JsonProperty("spoken_languages")]
    //public List<SpokenLanguage> SpokenLanguages { get; init; }

    [JsonProperty("status")]
    public string Status { get; init; }

    [JsonProperty("tagline")]
    public string Tagline { get; init; }

    [JsonProperty("title")]
    public string Title { get; init; }

    [JsonProperty("video")]
    public bool Video { get; init; }

    [JsonProperty("vote_average")]
    public double VoteAverage { get; init; }

    [JsonProperty("vote_count")]
    public int VoteCount { get; init; }

    public List<CastMember> Actors { get; set; } = new();

    public List<CrewMember> Directors { get; set; } = new();

}
    