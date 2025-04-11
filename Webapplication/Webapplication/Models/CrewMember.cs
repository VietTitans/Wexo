using Newtonsoft.Json;

namespace Webapplication.Models;

public class CrewMember
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

    [JsonProperty("credit_id")]
    public string CreditId { get; init; }

    [JsonProperty("department")]
    public string Department { get; init; }

    [JsonProperty("job")]
    public string Job { get; init; }
}
