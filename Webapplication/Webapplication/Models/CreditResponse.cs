using Newtonsoft.Json;

namespace Webapplication.Models;

public class CreditResponse
{
    [JsonProperty("id")]
    public int Id { get; init; }

    [JsonProperty("cast")]
    public List<CastMember> Cast { get; init; }

    [JsonProperty("crew")]
    public List<CrewMember> Crew { get; init; }
}
