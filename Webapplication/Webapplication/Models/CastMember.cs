using Newtonsoft.Json;

namespace Webapplication.Models;

public class CastMember
{
    [JsonProperty("adult")]
    public bool Adult { get; init; }

    [JsonProperty("gender")]
    public int? Gender { get; init; }

    [JsonProperty("id")]
    public int Id { get; init; }

    [JsonProperty("known_for_department")]
    public string KnownForDepartment { get; init; }

    [JsonProperty("name")]
    public string Name { get; init; }

    [JsonProperty("original_name")]
    public string OriginalName { get; init; }

    [JsonProperty("popularity")]
    public double Popularity { get; init; }

    [JsonProperty("profile_path")]
    public string ProfilePath { get; init; }

    [JsonProperty("cast_id")]
    public int? CastId { get; init; }

    [JsonProperty("character")]
    public string Character { get; init; }

    [JsonProperty("credit_id")]
    public string CreditId { get; init; }

    [JsonProperty("order")]
    public int Order { get; init; }
}
